using System.Collections.Generic;
using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Models
{
    [TestClass]
    public class ComputeTokensTest : SharedBaseTest
    {
        private static List<Content> NewContents() => new List<Content>
        {
            new Content
            {
                Parts = new List<Part> { new Part { Text = "The quick brown fox jumps over the lazy dog." } },
                Role = "user"
            }
        };

        [TestMethod]
        public async Task TestComputeTokensVertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                var response = await vertexClient.Models.ComputeTokensAsync(modelName, NewContents());
                Assert.IsNotNull(response);
                Assert.IsNotNull(response.TokensInfo);
            });
        }
    }
}
