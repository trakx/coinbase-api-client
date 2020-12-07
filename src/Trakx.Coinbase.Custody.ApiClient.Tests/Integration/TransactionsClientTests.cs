using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Trakx.Coinbase.Custody.ApiClient.Tests.Integration
{
    public sealed class TransactionsClientTests : CoinbaseClientTestsBase
    {
        private readonly ITransactionsClient _transactionsClient;
        public TransactionsClientTests(CoinbaseApiFixture apiFixture, ITestOutputHelper output) : base(apiFixture, output)
        {
            _transactionsClient = ServiceProvider.GetRequiredService<ITransactionsClient>();
        }


        [Fact]
        public async Task GetTransactionsAsync_should_return_results()
        {
            var transactions = (await _transactionsClient.GetTransactionsAsync()).Result;
   
            Logger.Information("Found transactions: {transactions}", 
                JsonSerializer.Serialize(transactions, new JsonSerializerOptions {WriteIndented = true}));

            transactions.Data.Count.Should().BeGreaterOrEqualTo(1);
        }

    }
}
