using System.Collections.Generic;

namespace Trakx.Coinbase.Custody.ApiClient
{
    public interface IPagedResponse<T>
    {
#nullable disable
        public Pagination Pagination { get; set; }
        public List<T> Data { get; set; }
#nullable restore
    }
}