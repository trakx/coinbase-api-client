using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Trakx.Coinbase.Custody.ApiClient.Tests.Integration
{
    public sealed class CurrenciesClientTests : CoinbaseClientTestsBase
    {
        private readonly ICurrenciesClient _currenciesClient;
        public CurrenciesClientTests(CoinbaseApiFixture apiFixture, ITestOutputHelper output) : base(apiFixture, output)
        {
            _currenciesClient = ServiceProvider.GetRequiredService<ICurrenciesClient>();
        }


        [Fact]
        public async Task GetCurrenciesAsync_should_return_results()
        {
            var currencies = (await _currenciesClient.GetCurrenciesAsync()).Result;
   
            Logger.Information("Found currencies: {currencies}", 
                JsonSerializer.Serialize(currencies, new JsonSerializerOptions {WriteIndented = true}));

            currencies.Data.Count.Should().BeGreaterOrEqualTo(1);
        }

    }
}
