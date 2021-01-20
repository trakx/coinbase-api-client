using System.ComponentModel.DataAnnotations;
using Trakx.Utils.Attributes;

namespace Trakx.Coinbase.Custody.ApiClient
{
    public class CoinbaseCustodyApiConfiguration
    {
#nullable disable
        [Required]
        public string BaseUrl { get; set; }

        [Required]
        [SecretEnvironmentVariable]
        public string AccessKey { get; set; }

        [Required]
        [SecretEnvironmentVariable] 
        public string PassPhrase { get; set; }

        public int? InitialRetryDelayInMilliseconds { get; set; }

        public int? MaxRetryCount { get; set; }
#nullable restore
    }
}