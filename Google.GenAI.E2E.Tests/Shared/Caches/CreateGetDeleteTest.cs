using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Caches
{
    [TestClass]
    public class CreateGetDeleteTest : SharedBaseTest
    {
        /// <summary>
        /// Document uploaded for the Gemini API half of the cache lifecycle. The canonical
        /// fixture is an image, but the test-server proxy aborts on any non-JSON request
        /// body; revert once that upstream bug is fixed. It must also be large enough to
        /// meet the caching minimum token count.
        /// </summary>
        internal static byte[] CacheDocumentBytes()
        {
            var sb = new StringBuilder();
            sb.Append("{\"text\": \"");
            for (int i = 0; i < 600; i++)
            {
                sb.Append("The quick brown fox jumps over the lazy dog. ");
            }
            sb.Append("\"}");
            return Encoding.UTF8.GetBytes(sb.ToString());
        }

        [TestMethod]
        public async Task TestCreateGetDeleteVertex()
        {
            SkipVertexInApiMode();
            if (TestServer.IsReplayMode)
            {
                Assert.Inconclusive("Vertex cache tests explicitly throw serialization timeouts locally in replay mode for .NET right now, test skipped");
            }
            await RunLive(async () =>
            {
                var config = new CreateCachedContentConfig
                {
                    Contents = new List<Content>
                    {
                        new Content
                        {
                            Role = "user",
                            // Repeated to clear the model's minimum token count for explicit caching.
                            Parts = Enumerable.Repeat(new Part { FileData = new FileData { FileUri = "gs://cloud-samples-data/generative-ai/image/a-man-and-a-dog.png", MimeType = "image/png" } }, 5).ToList()
                        }
                    },
                    Ttl = "7200s",
                    DisplayName = "test_cache"
                };

                var cache = await vertexClient.Caches.CreateAsync(modelName, config);
                Assert.IsNotNull(cache);
                Assert.IsFalse(string.IsNullOrEmpty(cache.Name), "Created cache should have a name.");

                // Delete in a finally: cached content is billed for its full 2h TTL.
                try
                {
                    var gotCache = await vertexClient.Caches.GetAsync(cache.Name);
                    Assert.IsNotNull(gotCache);
                    Assert.AreEqual(cache.Name, gotCache.Name);
                }
                finally
                {
                    await TryCleanupAsync(() => vertexClient.Caches.DeleteAsync(cache.Name));
                }
            });
        }

        [TestMethod]
        public async Task TestCreateGetDeleteMldev()
        {
            SkipGeminiInApiMode();
            await RunLive(async () =>
            {
                var file = await geminiClient.Files.UploadAsync(
                    bytes: CacheDocumentBytes(), fileName: "shared-cache-doc.json",
                    config: new UploadFileConfig { MimeType = "application/json" });
                Assert.IsNotNull(file);

                var config = new CreateCachedContentConfig
                {
                    Contents = new List<Content>
                    {
                        new Content
                        {
                            Role = "user",
                            Parts = Enumerable.Repeat(new Part { FileData = new FileData { FileUri = file.Uri, MimeType = file.MimeType } }, 5).ToList()
                        }
                    },
                    Ttl = "7200s",
                    DisplayName = "test_cache"
                };

                CachedContent cache = null;
                try
                {
                    cache = await geminiClient.Caches.CreateAsync(modelName, config);
                    Assert.IsNotNull(cache);
                    Assert.IsFalse(string.IsNullOrEmpty(cache.Name), "Created cache should have a name.");

                    var gotCache = await geminiClient.Caches.GetAsync(cache.Name);
                    Assert.IsNotNull(gotCache);
                    Assert.AreEqual(cache.Name, gotCache.Name);
                }
                finally
                {
                    if (cache != null)
                    {
                        await TryCleanupAsync(() => geminiClient.Caches.DeleteAsync(cache.Name));
                    }
                    await TryCleanupAsync(() => geminiClient.Files.DeleteAsync(file.Name));
                }
            });
        }
    }
}
