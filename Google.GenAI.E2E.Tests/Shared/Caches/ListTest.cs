using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Caches
{
    [TestClass]
    public class ListTest : SharedBaseTest
    {
        [TestMethod]
        public async Task TestListCachedContentsMldev()
        {
            SkipGeminiInApiMode();
            await RunLive(async () =>
            {
                var response = await geminiClient.Caches.ListAsync(new ListCachedContentsConfig { PageSize = 2 });
                Assert.IsNotNull(response);
            });
        }

        [TestMethod]
        public async Task TestListCachedContentsVertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                var response = await vertexClient.Caches.ListAsync(new ListCachedContentsConfig { PageSize = 2 });
                Assert.IsNotNull(response);
            });
        }
    }
}
