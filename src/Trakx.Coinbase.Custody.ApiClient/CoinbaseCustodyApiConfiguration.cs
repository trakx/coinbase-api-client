using System.ComponentModel.DataAnnotations;
using Trakx.Utils.Attributes;

namespace Trakx.Coinbase.Custody.ApiClient
{
    public record CoinbaseCustodyApiConfiguration
    {
#nullable disable
        public string BaseUrl { get; init; }

        [SecretEnvironmentVariable]
        public string AccessKey { get; init; }

        [SecretEnvironmentVariable] 
        public string PassPhrase { get; init; }

        public int? InitialRetryDelayInMilliseconds { get; init; }

        public int? MaxRetryCount { get; init; }
#nullable restore
    }
}