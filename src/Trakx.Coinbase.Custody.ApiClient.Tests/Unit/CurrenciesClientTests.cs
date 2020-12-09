using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Trakx.Coinbase.Custody.ApiClient.Tests.Unit
{
    public class ClientsExtensionsTests
    {
        private readonly ICurrenciesClient _client;

        public ClientsExtensionsTests()
        {
            _client = Substitute.For<ICurrenciesClient>();
        }

        private ResponseWrapper<Currencies> GetPagedResponse(int pageNumber, int size)
        {
            var data = Enumerable.Range(0, size).Select(i =>
                new Currency
                {
                    Symbol = $"SYM{pageNumber}N{i}",
                    Name = $"Currency {pageNumber} {i}"
                }).ToList();
            var pageResponse = new Currencies
            {
                Data = data,
                Pagination = new Pagination
                {
                    Before = $"SYM{pageNumber - 1}N{size}",
                    After = pageNumber == 0 ? null : $"SYM{pageNumber - 1}N{size}"
                }
            };
            return new ResponseWrapper<Currencies>(200, null, pageResponse);
        }

        [Fact]
        public async Task GetCurrencies_should_enumerate_page_responses_lazily()
        {
            var apiCallNumber = 0;

            _client.GetCurrenciesAsync(null, Pagination.Default).ReturnsForAnyArgs(ci =>
            {
                var page = GetPagedResponse(apiCallNumber, 10);
                apiCallNumber++;
                return page;
            });

            await _client.GetCurrencies(new Pagination { Limit = 10 }).Take(35).ToListAsync();

            await _client.ReceivedWithAnyArgs(4).GetCurrenciesAsync();
        }

        [Fact]
        public async Task GetCurrencies_should_enumerate_page_until_the_end()
        {
            _client.GetCurrenciesAsync().ReturnsForAnyArgs(
                GetPagedResponse(0, 10),
                GetPagedResponse(1, 5));

            var allCurrencies = await _client.GetCurrencies(new Pagination { Limit = 10 }).ToListAsync();

            await _client.ReceivedWithAnyArgs(2).GetCurrenciesAsync();
            allCurrencies.Count.Should().Be(15);
        }


        [Fact] public async Task GetCurrencies_should_work_onn_empty_sets()
        {
            var response = new ResponseWrapper<Currencies>(200, null, new Currencies { Data = new List<Currency>() });
            _client.GetCurrenciesAsync().ReturnsForAnyArgs(response);

            var allCurrencies = await _client.GetCurrencies(new Pagination { Limit = 10 }).ToListAsync();

            await _client.ReceivedWithAnyArgs(1).GetCurrenciesAsync();
            allCurrencies.Count.Should().Be(0);
        }
    }
}
