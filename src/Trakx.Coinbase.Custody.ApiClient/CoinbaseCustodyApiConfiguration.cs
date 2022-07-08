using System.ComponentModel.DataAnnotations;
using Trakx.Utils.Attributes;

namespace Trakx.Coinbase.Custody.ApiClient
{
    public record CoinbaseCustodyApiConfiguration
    {
#nullable disable
        public string BaseUrl { get; init; }

        [SecretEnvironmentVariable, AwsParameter]
        public string AccessKey { get; init; }

        [SecretEnvironmentVariable, AwsParameter]
        public string PassPhrase { get; init; }

        public int? InitialRetryDelayInMilliseconds { get; init; }

        public int? MaxRetryCount { get; init; }
#nullable restore
    }
}
