using Trakx.Utils.Attributes;
using Trakx.Utils.Testing;

namespace Trakx.Coinbase.Custody.ApiClient.Tests
{
    public record Secrets : SecretsBase
    {
#pragma warning disable CS8618
        [SecretEnvironmentVariable(nameof(CoinbaseCustodyApiConfiguration), nameof(CoinbaseCustodyApiConfiguration.AccessKey))]
        public string AccessKey { get; init; }

        [SecretEnvironmentVariable(nameof(CoinbaseCustodyApiConfiguration), nameof(CoinbaseCustodyApiConfiguration.PassPhrase))]
        public string PassPhrase { get; init; }
#pragma warning restore CS8618
    }
    
}