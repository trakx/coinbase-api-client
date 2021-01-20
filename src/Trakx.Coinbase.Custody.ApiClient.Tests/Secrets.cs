using Trakx.Utils.Attributes;
using Trakx.Utils.Testing;

namespace Trakx.Coinbase.Custody.ApiClient.Tests
{
    public record Secrets : SecretsBase
    {
        [SecretEnvironmentVariable(nameof(CoinbaseCustodyApiConfiguration), nameof(CoinbaseCustodyApiConfiguration.AccessKey))]
        public string AccessKey { get; init; }

        [SecretEnvironmentVariable(nameof(CoinbaseCustodyApiConfiguration), nameof(CoinbaseCustodyApiConfiguration.PassPhrase))]
        public string PassPhrase { get; init; }
    }
    
}