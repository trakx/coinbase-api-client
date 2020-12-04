using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Trakx.Coinbase.Custody.ApiClient
{
    public interface IPagedResponse<T>
    {
#nullable disable
        public Pagination Pagination { get; set; }
        public List<T> Data { get; set; }
#nullable restore
    }

    public class PagedResponse<T> : IPagedResponse<T>
    {
#nullable disable
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }


        [JsonPropertyName("data")]
        public List<T> Data { get; set; }
#nullable restore
    }
}