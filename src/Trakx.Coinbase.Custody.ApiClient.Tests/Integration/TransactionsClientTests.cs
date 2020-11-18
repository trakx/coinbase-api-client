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
        public async Task ListAccounts_and_GetAccount_should_return_results()
        {
            var transactions = (await _transactionsClient.GetTransactionsAsync()).Result;
   
            Logger.Information("Found address transactions: {transactions}", 
                JsonSerializer.Serialize(transactions));
            transactions.Data.Count.Should().BeGreaterOrEqualTo(1);
        }

    }
}
