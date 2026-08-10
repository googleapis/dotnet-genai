using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Models
{
    [TestClass]
    public class ListTest : SharedBaseTest
    {
        [TestMethod]
        public async Task TestListMldev()
        {
            SkipGeminiInApiMode();
            await RunLive(async () =>
            {
                var config = new ListModelsConfig { PageSize = 1 };
                var response = await geminiClient.Models.ListAsync(config);
                Assert.IsNotNull(response);
            });
        }

        [TestMethod]
        public async Task TestListVertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                var config = new ListModelsConfig { PageSize = 1 };
                var response = await vertexClient.Models.ListAsync(config);
                Assert.IsNotNull(response);
            });
        }
    }
}
