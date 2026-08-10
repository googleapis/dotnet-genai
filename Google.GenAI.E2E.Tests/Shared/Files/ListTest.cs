using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Files
{
    [TestClass]
    public class ListTest : SharedBaseTest
    {
        [TestMethod]
        public async Task TestListFilesMldev()
        {
            SkipGeminiInApiMode();
            await RunLive(async () =>
            {
                var response = await geminiClient.Files.ListAsync(new ListFilesConfig { PageSize = 2 });
                Assert.IsNotNull(response);
            });
        }
    }
}
