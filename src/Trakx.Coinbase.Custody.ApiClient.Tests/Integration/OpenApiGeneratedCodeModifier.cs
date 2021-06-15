using Xunit.Abstractions;

namespace Trakx.Coinbase.Custody.ApiClient.Tests.Integration
{
    public class OpenApiGeneratedCodeModifier : Trakx.Utils.Testing.OpenApiGeneratedCodeModifier
    {
        public OpenApiGeneratedCodeModifier(ITestOutputHelper output) : base(output)
        {
        }
    }
    
    public class EnvFileDocumentationUpdater : Trakx.Utils.Testing.EnvFileDocumentationUpdaterBase
    {
        public EnvFileDocumentationUpdater(ITestOutputHelper output) : base(output)
        {
        }
    }
}