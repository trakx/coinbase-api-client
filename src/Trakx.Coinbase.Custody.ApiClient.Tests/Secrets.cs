using System;
using System.IO;
using Trakx.Utils.Extensions;

namespace Trakx.Coinbase.Custody.ApiClient.Tests
{
    public static class Secrets
    {
        static Secrets()
        {
            var isRootDirectory = DirectoryInfoExtensions.TryWalkBackToRepositoryRoot(null, out var rootDirectory);
            if (!isRootDirectory)
                rootDirectory = null;
            try
            {
                DotNetEnv.Env.Load(Path.Combine(rootDirectory?.FullName ?? string.Empty, "src", ".env"));
            }
            catch (Exception)
            {
                // Fail to load the file on the CI pipeline, it should have environment variables defined.
            }
        }

        public static string AccessKey => Environment.GetEnvironmentVariable("CoinbaseCustodyApiConfiguration__AccessKey")!;
        public static string PassPhrase => Environment.GetEnvironmentVariable("CoinbaseCustodyApiConfiguration__PassPhrase")!;
    }
    
}