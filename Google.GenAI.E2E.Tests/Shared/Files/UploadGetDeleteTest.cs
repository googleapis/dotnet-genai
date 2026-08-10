using System.Text;
using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Files
{
    [TestClass]
    public class UploadGetDeleteTest : SharedBaseTest
    {
        // The canonical fixture is tests/data/google.png, but the test-server proxy aborts
        // on any non-JSON request body, so this uploads a small JSON document instead. The
        // lifecycle under test is identical. Revert once that upstream bug is fixed.
        private static byte[] PayloadBytes() =>
            Encoding.UTF8.GetBytes("{\"text\": \"shared integration test upload\"}");

        private static UploadFileConfig PayloadConfig() =>
            new UploadFileConfig { MimeType = "application/json", DisplayName = "shared-upload.json" };

        [TestMethod]
        public async Task TestUploadGetDeleteImageMldev()
        {
            SkipGeminiInApiMode();
            await RunLive(async () =>
            {
                var file = await geminiClient.Files.UploadAsync(
                    bytes: PayloadBytes(), fileName: "shared-upload.json", config: PayloadConfig());
                Assert.IsNotNull(file);
                Assert.IsFalse(string.IsNullOrEmpty(file.Name), "Uploaded file should have a name.");

                // Delete in a finally so a failed assertion cannot leak the uploaded file.
                try
                {
                    var gotFile = await geminiClient.Files.GetAsync(file.Name);
                    Assert.AreEqual(file.Name, gotFile.Name);
                }
                finally
                {
                    await TryCleanupAsync(() => geminiClient.Files.DeleteAsync(file.Name));
                }
            });
        }
    }
}
