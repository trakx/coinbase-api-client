using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;
using Serilog;
using Trakx.Coinbase.Custody.ApiClient.Utils;

namespace Trakx.Coinbase.Custody.ApiClient
{
    public static partial class AddCoinbaseCustodyClientExtension
    {
        public static IServiceCollection AddCoinbaseCustodyClient(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            var apiConfig = configuration.GetSection(nameof(CoinbaseCustodyApiConfiguration)).Get<CoinbaseCustodyApiConfiguration>();
            AddCoinbaseCustodyClient(services, apiConfig);

            return services;
        }

        public static IServiceCollection AddCoinbaseCustodyClient(
            this IServiceCollection services, CoinbaseCustodyApiConfiguration apiConfiguration)
        {
            var options = Options.Create(apiConfiguration);
            services.AddSingleton(options);
            
            AddCommonDependencies(services, apiConfiguration);

            return services;
        }

        private static void AddCommonDependencies(IServiceCollection services, CoinbaseCustodyApiConfiguration apiConfiguration)
        {
            services.AddSingleton<ClientConfigurator>();
            services.AddSingleton<ICredentialsProvider, ApiKeyCredentialsProvider>();
            AddClients(services, apiConfiguration);
        }

        private static void LogFailure(ILogger logger, DelegateResult<HttpResponseMessage> result, TimeSpan timeSpan, int retryCount, Context context)
        {
            if (result.Exception != null)
            {
                logger.Warning(result.Exception, "An exception occurred on retry {RetryAttempt} for {PolicyKey}. Retrying in {SleepDuration}ms.",
                    retryCount, context.PolicyKey, timeSpan.TotalMilliseconds);
            }
            else
            {
                logger.Warning("A non success code {StatusCode} with reason {Reason} and content {Content} was received on retry {RetryAttempt} for {PolicyKey}. Retrying in {SleepDuration}ms.",
                    (int)result.Result.StatusCode, result.Result.ReasonPhrase,
                    result.Result.Content?.ReadAsStringAsync().GetAwaiter().GetResult(),
                    retryCount, context.PolicyKey, timeSpan.TotalMilliseconds);
            }
        }
    }
}