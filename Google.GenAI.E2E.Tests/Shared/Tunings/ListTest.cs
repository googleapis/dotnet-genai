using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Tunings
{
    [TestClass]
    public class ListTest : SharedBaseTest
    {
        // Canonical tunings/list test: test_default.

        [TestMethod]
        public async Task TestDefaultVertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                var pager = await vertexClient.Tunings.ListAsync(new ListTuningJobsConfig { PageSize = 1 });
                Assert.IsNotNull(pager);

                int count = 0;
                await foreach (var item in pager)
                {
                    Assert.IsNotNull(item);
                    count++;
                    if (count >= 1) break;
                }
                Assert.IsTrue(count <= 1, $"Expected at most 1 tuning job per page, enumerated {count}.");
            });
        }
    }
}
