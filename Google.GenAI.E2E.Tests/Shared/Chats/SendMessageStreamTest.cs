using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.AI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Chats
{
    [TestClass]
    public class SendMessageStreamTest : SharedBaseTest
    {
        [TestMethod]
        public async Task TestSendMessageStreamMldev()
        {
            SkipGeminiInApiMode();
            await RunLive(async () =>
            {
                var chatClient = geminiClient.AsIChatClient(modelName);
                var responseStream = chatClient.GetStreamingResponseAsync("Tell a joke.");

                int chunkCount = 0;
                var text = new StringBuilder();
                await foreach (var chunk in responseStream)
                {
                    Assert.IsNotNull(chunk);
                    chunkCount++;
                    text.Append(chunk.Text);
                }

                // An empty stream would silently pass a bare foreach, so assert we saw data.
                Assert.IsTrue(chunkCount > 0, "Expected at least one streamed chunk.");
                Assert.IsFalse(string.IsNullOrWhiteSpace(text.ToString()),
                               "Streamed chunks should contain text.");
            });
        }

        [TestMethod]
        public async Task TestSendMessageStreamVertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                var chatClient = vertexClient.AsIChatClient(modelName);
                var responseStream = chatClient.GetStreamingResponseAsync("Tell a joke.");

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
