using Microsoft.Extensions.Options;
using Trakx.Coinbase.Custody.ApiClient.Utils;

namespace Trakx.Coinbase.Custody.ApiClient
{
    internal class ClientConfigurator
    {
        private readonly ICredentialsProvider _credentialsProvider;

        public ClientConfigurator(ICredentialsProvider credentialsProvider, IOptions<CoinbaseCustodyApiConfiguration> configuration)
        {
            _credentialsProvider = credentialsProvider;
            CustodyApiConfiguration = configuration.Value;
        }
         
        public CoinbaseCustodyApiConfiguration CustodyApiConfiguration { get; }

        public ICredentialsProvider GetCredentialProvider()
        {
            return _credentialsProvider;
        }
    }
}