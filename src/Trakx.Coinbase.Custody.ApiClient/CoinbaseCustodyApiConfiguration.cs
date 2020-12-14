using System.ComponentModel.DataAnnotations;

namespace Trakx.Coinbase.Custody.ApiClient
{
    public class CoinbaseCustodyApiConfiguration
    {
#nullable disable
        [Required] public string BaseUrl { get; set; }
        [Required] public string AccessKey { get; set; }
        [Required] public string PassPhrase { get; set; }
        public int? InitialRetryDelayInMilliseconds { get; set; }
        public int? MaxRetryCount { get; set; }
#nullable restore
    }
}