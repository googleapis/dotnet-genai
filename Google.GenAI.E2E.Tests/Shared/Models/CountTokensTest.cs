using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Models
{
    [TestClass]
    public class CountTokensTest : SharedBaseTest
    {
        [TestMethod]
        public async Task TestCountTokensMldev()
        {
            SkipGeminiInApiMode();
            // countTokens is supported on the Gemini API: the canonical corpus specifies no
            // exceptionIfMldev for it, so this must succeed rather than tolerate an error.
            await RunLive(async () =>
            {
                var response = await geminiClient.Models.CountTokensAsync(
                    modelName, "The quick brown fox jumps over the lazy dog.");
                Assert.IsNotNull(response);
                Assert.IsNotNull(response.TotalTokens);
                Assert.IsTrue(response.TotalTokens > 0, "Expected a positive token count.");
            });
        }

        [TestMethod]
        public async Task TestCountTokensVertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                var response = await vertexClient.Models.CountTokensAsync(
                    modelName, "The quick brown fox jumps over the lazy dog.");
                Assert.IsNotNull(response);
                Assert.IsNotNull(response.TotalTokens);
                Assert.IsTrue(response.TotalTokens > 0, "Expected a positive token count.");
            });
        }
    }
}
