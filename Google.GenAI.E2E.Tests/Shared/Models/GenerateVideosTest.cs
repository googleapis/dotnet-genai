using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Models
{
    /// <summary>
    /// Canonical models/generate_videos: one case per Veo model, each run against the
    /// backend that serves it. The corpus sets httpOptions.retryOptions, which .NET does
    /// not yet support, so quota pressure is handled by SkipOnQuota instead.
    /// </summary>
    [TestClass]
    public class GenerateVideosTest : SharedBaseTest
    {
        private const string VertexVeoModel = "veo-3.1-lite-generate-001";
        private const string GeminiVeoModel = "veo-3.1-lite-generate-preview";

        private static GenerateVideosSource NewSource() =>
            new GenerateVideosSource { Prompt = "Man with a dog" };

        [TestMethod]
        public async Task TestSimplePromptVertexModelOnVertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                // Returns a long-running operation; the canonical test does not poll it.
                var response = await vertexClient.Models.GenerateVideosAsync(VertexVeoModel, NewSource());
                Assert.IsNotNull(response);
            });
        }

        [TestMethod]
        public async Task TestSimplePromptGeminiModelOnMldev()
        {
            SkipGeminiInApiMode();
            await RunLive(async () =>
            {
                var response = await geminiClient.Models.GenerateVideosAsync(GeminiVeoModel, NewSource());
                Assert.IsNotNull(response);
            });
        }
    }
}
