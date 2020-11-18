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
        private static void AddClients(this IServiceCollection services)
        {
            var delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromMilliseconds(100), retryCount: 10, fastFirst: true);
                                    
            services.AddHttpClient<IAddressBookClient, AddressBookClient>()
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
                    .WithPolicyKey("AddressBookClient"));

                                
            services.AddHttpClient<IAddressesClient, AddressesClient>()
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
                    .WithPolicyKey("AddressesClient"));

                                
            services.AddHttpClient<IAddressesClient, AddressesClient>()
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
                    .WithPolicyKey("AddressesClient"));

                                
            services.AddHttpClient<ICurrenciesClient, CurrenciesClient>()
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
                    .WithPolicyKey("CurrenciesClient"));

                                
            services.AddHttpClient<ITransactionsClient, TransactionsClient>()
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
                    .WithPolicyKey("TransactionsClient"));

                                
            services.AddHttpClient<IUsersClient, UsersClient>()
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
                    .WithPolicyKey("UsersClient"));

                                
            services.AddHttpClient<IWalletsClient, WalletsClient>()
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
                    .WithPolicyKey("WalletsClient"));

        }
    }
}
