using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;
using Serilog;


namespace Trakx.Coinbase.Custody.ApiClient
{
    public static partial class AddCoinbaseCustodyClientExtension
    {
        private static void AddClients(this IServiceCollection services, CoinbaseCustodyApiConfiguration configuration)
        {
            var delay = Backoff.DecorrelatedJitterBackoffV2(
                medianFirstRetryDelay: TimeSpan.FromMilliseconds(configuration.InitialRetryDelayInMilliseconds ?? 100), 
                retryCount: configuration.MaxRetryCount ?? 10, fastFirst: true);
                                    
            services.AddHttpClient<IAddressBookClient, AddressBookClient>("Trakx.Coinbase.Custody.ApiClient.AddressBookClient")
                .AddPolicyHandler((s, request) => 
                    Policy<HttpResponseMessage>
                    .Handle<ApiException>()
                    .Or<HttpRequestException>()
                    .OrTransientHttpStatusCode()
                    .WaitAndRetryAsync(delay,
                        onRetry: (result, timeSpan, retryCount, context) =>
                        {
                            var logger = Log.Logger.ForContext<AddressBookClient>();
                            LogFailure(logger, result, timeSpan, retryCount, context);
                        })
                    .WithPolicyKey("Trakx.Coinbase.Custody.ApiClient.AddressBookClient"));

                                
            services.AddHttpClient<IAddressesClient, AddressesClient>("Trakx.Coinbase.Custody.ApiClient.AddressesClient")
                .AddPolicyHandler((s, request) => 
                    Policy<HttpResponseMessage>
                    .Handle<ApiException>()
                    .Or<HttpRequestException>()
                    .OrTransientHttpStatusCode()
                    .WaitAndRetryAsync(delay,
                        onRetry: (result, timeSpan, retryCount, context) =>
                        {
                            var logger = Log.Logger.ForContext<AddressesClient>();
                            LogFailure(logger, result, timeSpan, retryCount, context);
                        })
                    .WithPolicyKey("Trakx.Coinbase.Custody.ApiClient.AddressesClient"));

                                
            services.AddHttpClient<IAddressesClient, AddressesClient>("Trakx.Coinbase.Custody.ApiClient.AddressesClient")
                .AddPolicyHandler((s, request) => 
                    Policy<HttpResponseMessage>
                    .Handle<ApiException>()
                    .Or<HttpRequestException>()
                    .OrTransientHttpStatusCode()
                    .WaitAndRetryAsync(delay,
                        onRetry: (result, timeSpan, retryCount, context) =>
                        {
                            var logger = Log.Logger.ForContext<AddressesClient>();
                            LogFailure(logger, result, timeSpan, retryCount, context);
                        })
                    .WithPolicyKey("Trakx.Coinbase.Custody.ApiClient.AddressesClient"));

                                
            services.AddHttpClient<ICurrenciesClient, CurrenciesClient>("Trakx.Coinbase.Custody.ApiClient.CurrenciesClient")
                .AddPolicyHandler((s, request) => 
                    Policy<HttpResponseMessage>
                    .Handle<ApiException>()
                    .Or<HttpRequestException>()
                    .OrTransientHttpStatusCode()
                    .WaitAndRetryAsync(delay,
                        onRetry: (result, timeSpan, retryCount, context) =>
                        {
                            var logger = Log.Logger.ForContext<CurrenciesClient>();
                            LogFailure(logger, result, timeSpan, retryCount, context);
                        })
                    .WithPolicyKey("Trakx.Coinbase.Custody.ApiClient.CurrenciesClient"));

                                
            services.AddHttpClient<ITransactionsClient, TransactionsClient>("Trakx.Coinbase.Custody.ApiClient.TransactionsClient")
                .AddPolicyHandler((s, request) => 
                    Policy<HttpResponseMessage>
                    .Handle<ApiException>()
                    .Or<HttpRequestException>()
                    .OrTransientHttpStatusCode()
                    .WaitAndRetryAsync(delay,
                        onRetry: (result, timeSpan, retryCount, context) =>
                        {
                            var logger = Log.Logger.ForContext<TransactionsClient>();
                            LogFailure(logger, result, timeSpan, retryCount, context);
                        })
                    .WithPolicyKey("Trakx.Coinbase.Custody.ApiClient.TransactionsClient"));

                                
            services.AddHttpClient<IUsersClient, UsersClient>("Trakx.Coinbase.Custody.ApiClient.UsersClient")
                .AddPolicyHandler((s, request) => 
                    Policy<HttpResponseMessage>
                    .Handle<ApiException>()
                    .Or<HttpRequestException>()
                    .OrTransientHttpStatusCode()
                    .WaitAndRetryAsync(delay,
                        onRetry: (result, timeSpan, retryCount, context) =>
                        {
                            var logger = Log.Logger.ForContext<UsersClient>();
                            LogFailure(logger, result, timeSpan, retryCount, context);
                        })
                    .WithPolicyKey("Trakx.Coinbase.Custody.ApiClient.UsersClient"));

                                
            services.AddHttpClient<IWalletsClient, WalletsClient>("Trakx.Coinbase.Custody.ApiClient.WalletsClient")
                .AddPolicyHandler((s, request) => 
                    Policy<HttpResponseMessage>
                    .Handle<ApiException>()
                    .Or<HttpRequestException>()
                    .OrTransientHttpStatusCode()
                    .WaitAndRetryAsync(delay,
                        onRetry: (result, timeSpan, retryCount, context) =>
                        {
                            var logger = Log.Logger.ForContext<WalletsClient>();
                            LogFailure(logger, result, timeSpan, retryCount, context);
                        })
                    .WithPolicyKey("Trakx.Coinbase.Custody.ApiClient.WalletsClient"));

        }
    }
}
