using System.Net.Http;
using System.Reflection;
using Microsoft.Extensions.Options;
using Serilog;
using Trakx.Utils.Apis;

namespace Trakx.Coinbase.Custody.ApiClient.Utils
{
    public interface ICoinbaseCredentialsProvider : ICredentialsProvider { };
    public class ApiKeyCredentialsProvider : ICoinbaseCredentialsProvider
    {
        internal const string AccessKeyHeader = "CB-ACCESS-KEY";
        internal const string PassPhraseHeader = "CB-ACCESS-PASSPHRASE";

        private readonly CoinbaseCustodyApiConfiguration _configuration;

        private static readonly ILogger Logger = Log.Logger.ForContext(MethodBase.GetCurrentMethod()!.DeclaringType);

        public ApiKeyCredentialsProvider(IOptions<CoinbaseCustodyApiConfiguration> configuration)
        {
            _configuration = configuration.Value;
        }

        
        #region Implementation of ICredentialsProvider

        /// <inheritdoc />
        public void AddCredentials(HttpRequestMessage msg)
        {
            msg.Headers.Add(AccessKeyHeader, _configuration.AccessKey);
            msg.Headers.Add(PassPhraseHeader, _configuration.PassPhrase);
            Logger.Verbose("Headers added");
        }
        #endregion
    }
}