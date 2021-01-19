using System.ComponentModel.DataAnnotations;
using Trakx.Utils.Attributes;

namespace Trakx.Coinbase.Custody.ApiClient
{
    public class CoinbaseCustodyApiConfiguration
    {
#nullable disable
        [Required]
        [SecretEnvironmentVariable("CoinbaseCustodyApiConfiguration__BaseUrl")]
        public string BaseUrl { get; set; }

        [Required]
        [SecretEnvironmentVariable("CoinbaseCustodyApiConfiguration__AccessKey")]
        public string AccessKey { get; set; }

        [Required]
        [SecretEnvironmentVariable("CoinbaseCustodyApiConfiguration__PassPhrase")] 
        public string PassPhrase { get; set; }

        [SecretEnvironmentVariable("CoinbaseCustodyApiConfiguration__InitialRetryDelayInMilliseconds")]
        public int? InitialRetryDelayInMilliseconds { get; set; }

        [SecretEnvironmentVariable("CoinbaseCustodyApiConfiguration__MaxRetryCount")]
        public int? MaxRetryCount { get; set; }
#nullable restore
    }
}