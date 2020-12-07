using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Trakx.Coinbase.Custody.ApiClient.Tests.Integration
{
    public sealed class WalletsClientTests : CoinbaseClientTestsBase
    {
        private readonly IWalletsClient _walletsClient;
        public WalletsClientTests(CoinbaseApiFixture apiFixture, ITestOutputHelper output) : base(apiFixture, output)
        {
            _walletsClient = ServiceProvider.GetRequiredService<IWalletsClient>();
        }


        [Fact]
        public async Task GetWalletsAsync_should_return_results()
        {
            var wallets = (await _walletsClient.GetWalletsAsync()).Result;
   
            Logger.Information("Found wallets: {wallets}", 
                JsonSerializer.Serialize(wallets, new JsonSerializerOptions {WriteIndented = true}));

            wallets.Data.Count.Should().BeGreaterOrEqualTo(1);
        }

    }
}
