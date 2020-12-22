using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Trakx.Utils.Api;

namespace Trakx.Coinbase.Custody.ApiClient
{
    internal abstract class AuthorisedClient
    {
        protected readonly ICredentialsProvider CredentialsProvider;
        protected string BaseUrl { get; }

        protected AuthorisedClient(ClientConfigurator clientConfigurator)
        {
            CredentialsProvider = clientConfigurator.GetCredentialProvider();
            BaseUrl = clientConfigurator.CustodyApiConfiguration.BaseUrl;
        }

        protected Task<HttpRequestMessage> CreateHttpRequestMessageAsync(CancellationToken cancellationToken)
        {
            var msg = new HttpRequestMessage();
            CredentialsProvider.AddCredentials(msg);
            return Task.FromResult(msg);
        }
    }
}