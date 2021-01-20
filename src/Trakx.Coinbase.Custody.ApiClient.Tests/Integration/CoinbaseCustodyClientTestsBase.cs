using System;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Xunit;
using Xunit.Abstractions;

namespace Trakx.Coinbase.Custody.ApiClient.Tests.Integration
{
    [Collection(nameof(ApiTestCollection))]
    public class CoinbaseClientTestsBase
    {
        protected ServiceProvider ServiceProvider;
        protected ILogger Logger;

        public CoinbaseClientTestsBase(CoinbaseApiFixture apiFixture, ITestOutputHelper output)
        {
            Logger = new LoggerConfiguration().WriteTo.TestOutput(output).CreateLogger();

            ServiceProvider = apiFixture.ServiceProvider;
        }
    }

    [CollectionDefinition(nameof(ApiTestCollection))]
    public class ApiTestCollection : ICollectionFixture<CoinbaseApiFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    public class CoinbaseApiFixture : IDisposable
    {
        public ServiceProvider ServiceProvider;

        public CoinbaseApiFixture()
        {
            var configuration = new CoinbaseCustodyApiConfiguration()
            {
                AccessKey = new Secrets().AccessKey,
                PassPhrase = new Secrets().PassPhrase,
                BaseUrl = "https://api.custody.coinbase.com"
            };

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddCoinbaseCustodyClient(configuration);

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            ServiceProvider.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}