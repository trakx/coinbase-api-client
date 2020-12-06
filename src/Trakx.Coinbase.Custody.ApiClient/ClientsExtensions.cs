using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Trakx.Coinbase.Custody.ApiClient
{
    public partial class Transactions : IPagedResponse<Transaction> { }

    public static class TransactionsClientExtensions
    {
        public static async IAsyncEnumerable<Transaction> GetTransactions(
            this ITransactionsClient transactionsClient,
            string? currency = null,
            Transaction_state? state = null,
            string? walletId = null,
            Transaction_type? type = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? humanId = null,
            Pagination? pagination = null,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            pagination ??= Pagination.Default;
            var fetchPage = new Func<Pagination,Task<IPagedResponse<Transaction>>>(async p =>
            {
                var page = await transactionsClient.GetTransactionsAsync(currency, state, type, walletId,
                    startTime, endTime, humanId, p?.Limit, p?.Before, p?.After,  cancellationToken);
                return page.Result;
            });
            
            await foreach (var transaction in pagination.EnumerateAsynchronously(fetchPage)
                .WithCancellation(cancellationToken))
            {
                yield return transaction;
            }
        }
    }

    public partial class Users : IPagedResponse<User> { }
    public static class UsersClientExtensions
    {
        public static async IAsyncEnumerable<User> GetUsers(this IUsersClient usersClient, Pagination? pagination = null,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            pagination ??= Pagination.Default;
            var fetchPage = new Func<Pagination, Task<IPagedResponse<User>>>(async p =>
            {
                var page = await usersClient.GetUsersAsync(p?.Limit, p?.Before, p?.After, cancellationToken);
                return page.Result;
            });

            await foreach (var user in pagination.EnumerateAsynchronously(fetchPage)
                .WithCancellation(cancellationToken))
            {
                yield return user;
            }
        }
    }

    public partial class Wallets : IPagedResponse<Wallet> { }
    public static class WalletsClientExtensions
    {
        public static async IAsyncEnumerable<Wallet> GetWallets(this IWalletsClient walletsClient,
            string? currency = null, Pagination? pagination = null,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            pagination ??= Pagination.Default;
            var fetchPage = new Func<Pagination, Task<IPagedResponse<Wallet>>>(async p =>
            {
                var page = await walletsClient.GetWalletsAsync(currency, p?.Limit, p?.Before, p?.After, cancellationToken);
                return page.Result;
            });

            await foreach (var wallet in pagination.EnumerateAsynchronously(fetchPage)
                .WithCancellation(cancellationToken))
            {
                yield return wallet;
            }
        }
    }

    public partial class Addresses : IPagedResponse<Address> { }
    public static class AddressesClientExtensions
    {
        public static async IAsyncEnumerable<Address> GetAddresses(
            this IAddressesClient addressClient,
            string? walletId = default, 
            string? currency = default, 
            Address_state? state =  default, 
            Pagination? pagination = null,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            pagination ??= Pagination.Default;
            var fetchPage = new Func<Pagination, Task<IPagedResponse<Address>>>(async p =>
            {
                var page = await addressClient.GetAddressesAsync(walletId, currency, state, p?.Limit, p?.Before, p?.After, cancellationToken);
                return page.Result;
            });

            await foreach (var wallet in pagination.EnumerateAsynchronously(fetchPage)
                .WithCancellation(cancellationToken))
            {
                yield return wallet;
            }
        }
    }

    public partial class Currencies : IPagedResponse<Currency> { }
    public static class CurrenciesClientExtensions
    {
        public static async IAsyncEnumerable<Currency> GetCurrencies(
            this ICurrenciesClient currenciesClient,
            Pagination? pagination = null,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            pagination ??= Pagination.Default;
            var fetchPage = new Func<Pagination, Task<IPagedResponse<Currency>>>(async p =>
            {
                var page = await currenciesClient.GetCurrenciesAsync(null, p?.Limit, p?.Before, p?.After, cancellationToken);
                return page.Result;
            });

            await foreach (var wallet in pagination.EnumerateAsynchronously(fetchPage)
                .WithCancellation(cancellationToken))
            {
                yield return wallet;
            }
        }
    }

}
