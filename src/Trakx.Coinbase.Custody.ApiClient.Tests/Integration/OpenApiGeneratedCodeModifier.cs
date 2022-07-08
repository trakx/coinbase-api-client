using Xunit.Abstractions;

namespace Trakx.Coinbase.Custody.ApiClient.Tests.Integration
{
    public class OpenApiGeneratedCodeModifier : Trakx.Utils.Testing.OpenApiGeneratedCodeModifier
    {
        public OpenApiGeneratedCodeModifier(ITestOutputHelper output) : base(output)
        {
        }
    }

    public class ReadmeDocumentationUpdater : Trakx.Utils.Testing.ReadmeUpdater.ReadmeDocumentationUpdaterBase
    {
        public ReadmeDocumentationUpdater(ITestOutputHelper output) : base(output)
        {
        }
    }
}
