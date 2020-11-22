using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trakx.Coinbase.Custody.ApiClient.Utils
{
    public static class PagedResponseExtensions
    {
        /// <summary>
        /// This function can be reused for all other page responses.
        /// </summary>
        internal static async IAsyncEnumerable<T> ToAsyncEnumerable<T>( 
            Func<Pagination, Task<IPagedResponse<T>>> fetchPage, Pagination paginationOptions)
        {
            IPagedResponse<T> page;
            do
            {
                try
                {
                    page = await fetchPage(paginationOptions).ConfigureAwait(false);
                    paginationOptions = new Pagination {
                        Before = page.Pagination?.After, 
                        After = default, 
                        //Limit = paginationOptions?.Limit
                        };
                }
                catch (Exception)
                {
                    yield break;
                }

                foreach (var data in page.Data)
                {
                    yield return data;
                }
            } while (page.Data.Length >= paginationOptions.Limit);
        }
    }
}
