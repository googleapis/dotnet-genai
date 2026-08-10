using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Models
{
    [TestClass]
    public class GenerateContentStreamTest : SharedBaseTest
    {
        [TestMethod]
        public async Task TestGenerateContentStreamMldev()
        {
            SkipGeminiInApiMode();
            // streamGenerateContent is supported on the Gemini API: the canonical corpus
            // specifies no exceptionIfMldev, so this must succeed rather than tolerate an
            // error.
            await RunLive(async () =>
            {
                var responseStream = geminiClient.Models.GenerateContentStreamAsync(
                    modelName, "The quick brown fox jumps over the lazy dog.");

                int chunkCount = 0;
                var text = new StringBuilder();
                await foreach (var chunk in responseStream)
                {
                    Assert.IsNotNull(chunk);
                    chunkCount++;
                    text.Append(chunk.Text);
                }

                Assert.IsTrue(chunkCount > 0, "Expected at least one streamed chunk.");
                Assert.IsFalse(string.IsNullOrWhiteSpace(text.ToString()),
                               "Streamed chunks should contain text.");
            });
        }

        [TestMethod]
        public async Task TestGenerateContentStreamVertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                var responseStream = vertexClient.Models.GenerateContentStreamAsync(
                    modelName, "The quick brown fox jumps over the lazy dog.");

                int chunkCount = 0;
                var text = new StringBuilder();
                await foreach (var chunk in responseStream)
                {
                    Assert.IsNotNull(chunk);
                    chunkCount++;
                    text.Append(chunk.Text);
                }

                Assert.IsTrue(chunkCount > 0, "Expected at least one streamed chunk.");
                Assert.IsFalse(string.IsNullOrWhiteSpace(text.ToString()),
                               "Streamed chunks should contain text.");
            });
        }
    }
}
