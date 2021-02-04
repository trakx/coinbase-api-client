using Microsoft.Extensions.Options;
using Trakx.Coinbase.Custody.ApiClient.Utils;
using Trakx.Utils.Apis;

namespace Trakx.Coinbase.Custody.ApiClient
{
    internal class ClientConfigurator
    {
        private readonly ICoinbaseCredentialsProvider _credentialsProvider;

        public ClientConfigurator(ICoinbaseCredentialsProvider credentialsProvider, 
            IOptions<CoinbaseCustodyApiConfiguration> configuration)
        {
            _credentialsProvider = credentialsProvider;
            CustodyApiConfiguration = configuration.Value;
        }
         
        public CoinbaseCustodyApiConfiguration CustodyApiConfiguration { get; }

        public ICoinbaseCredentialsProvider GetCredentialProvider()
        {
            return _credentialsProvider;
        }
    }
}