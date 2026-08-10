using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.AI;

namespace Google.GenAI.E2E.Tests.Shared.Chats
{
    [TestClass]
    public class SendMessageTest : SharedBaseTest
    {
        [TestMethod]
        public async Task TestSendMessageMldev()
        {
            SkipGeminiInApiMode();
            await RunLive(async () =>
            {
                var chatClient = geminiClient.AsIChatClient(modelName);
                var response = await chatClient.GetResponseAsync("Hello");
                Assert.IsNotNull(response);
                Assert.IsFalse(string.IsNullOrWhiteSpace(response.Text),
                               "Chat response should contain text.");
            });
        }

        [TestMethod]
        public async Task TestSendMessageVertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                var chatClient = vertexClient.AsIChatClient(modelName);
                var response = await chatClient.GetResponseAsync("Hello");
                Assert.IsNotNull(response);
                Assert.IsFalse(string.IsNullOrWhiteSpace(response.Text),
                               "Chat response should contain text.");
            });
        }
    }
}
