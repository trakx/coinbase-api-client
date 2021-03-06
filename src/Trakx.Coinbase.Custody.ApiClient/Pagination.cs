﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trakx.Coinbase.Custody.ApiClient
{
    public partial class Pagination
    {
        public static readonly Pagination Default = new Pagination{Limit = 10};

        public Pagination Clone()
        {
            var clone = new Pagination
            {
                After = After,
                Before = Before,
                Limit = Limit
            };
            return clone;
        }

        public Pagination Next<T>(IPagedResponse<T> page)
        {
            var next = new Pagination
            {
                After = default,
                Before = page.Pagination?.After,
                Limit = Limit
            };
            return next;
        }

        /// <summary>
        /// This function can be reused for all other page responses.
        /// </summary>
        internal async IAsyncEnumerable<T> EnumerateAsynchronously<T>(Func<Pagination, Task<IPagedResponse<T>>> fetchPage)
        {
            if(Limit <= 0) throw new InvalidOperationException($"unable to enumerate with a null or negative {nameof(Limit)}.");
            IPagedResponse<T> page;
            var nextPagination = Clone();
            do
            {
                try
                {
                    page = await fetchPage(nextPagination).ConfigureAwait(false);
                    nextPagination = Next(page);
                }
                catch (Exception)
                {
                    yield break;
                }

                foreach (var data in page.Data)
                {
                    yield return data;
                }
            } while (page.Data.Count >= Limit);
        }
    }
}
