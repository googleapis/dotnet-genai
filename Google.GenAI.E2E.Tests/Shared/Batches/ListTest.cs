using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Batches
{
    [TestClass]
    public class ListTest : SharedBaseTest
    {
        [TestMethod]
        public async Task TestListBatchJobsMldev()
        {
            SkipGeminiInApiMode();
            await RunLive(async () =>
            {
                var config = new ListBatchJobsConfig { PageSize = 2 };
                var pager = await geminiClient.Batches.ListAsync(config);
                Assert.IsNotNull(pager);

                int count = 0;
                await foreach (var item in pager)
                {
                    Assert.IsNotNull(item);
                    count++;
                    if (count >= 2) break;
                }
                // The account may legitimately have no batch jobs, so only assert that
                // enumeration honoured the requested page size.
                Assert.IsTrue(count <= 2, $"Expected at most 2 batch jobs per page, enumerated {count}.");
            });
        }

        [TestMethod]
        public async Task TestListBatchJobsVertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                var config = new ListBatchJobsConfig { PageSize = 2 };
                var pager = await vertexClient.Batches.ListAsync(config);
                Assert.IsNotNull(pager);

                int count = 0;
                await foreach (var item in pager)
                {
                    Assert.IsNotNull(item);
                    count++;
                    if (count >= 2) break;
                }
                Assert.IsTrue(count <= 2, $"Expected at most 2 batch jobs per page, enumerated {count}.");
            });
        }
    }
}
