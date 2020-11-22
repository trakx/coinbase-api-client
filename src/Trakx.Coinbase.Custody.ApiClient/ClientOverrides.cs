using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Trakx.Coinbase.Custody.ApiClient
{
    internal partial class TransactionsClient
    {
        public async IAsyncEnumerable<Transaction> GetTransactions(string? currency = null,
            Transaction_state? state = null,
            string? walletId = null,
            Transaction_type? type = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? humanId = null,
            Pagination? paginationOptions = null,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            async Task<IPagedResponse<Transaction>> FetchPage(Pagination? pagination) =>
                await GetTransactionsAsync(currency, state, type, walletId,
                    startTime, endTime, humanId, cancellationToken);

            await foreach (var transaction in FromPagedResponse(FetchPage, paginationOptions)
                .WithCancellation(cancellationToken))
            {
                yield return transaction;
            }
            yield break;
        }
    }

    public interface IPagedResponse<T>
    {
#nullable disable
        public Pagination Pagination { get; set; }
        public T[] Data { get; set; }
#nullable restore
    }
}
