using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Caches
{
    [TestClass]
    public class CreateUpdateGetTest : SharedBaseTest
    {
        [TestMethod]
        public async Task TestCreateUpdateGetVertex()
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

                try
                {
                    var updatedCache = await vertexClient.Caches.UpdateAsync(
                        cache.Name, new UpdateCachedContentConfig { Ttl = "7200s" });
                    Assert.IsNotNull(updatedCache);
                    Assert.AreEqual(cache.Name, updatedCache.Name);

                    var gotCache = await vertexClient.Caches.GetAsync(updatedCache.Name);
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
        public async Task TestCreateUpdateGetMldev()
        {
            SkipGeminiInApiMode();
            await RunLive(async () =>
            {
                // See CreateGetDeleteTest.CacheDocumentBytes for why this is a JSON document
                // rather than the canonical image.
                var file = await geminiClient.Files.UploadAsync(
                    bytes: CreateGetDeleteTest.CacheDocumentBytes(),
                    fileName: "shared-cache-doc.json",
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

                    var updatedCache = await geminiClient.Caches.UpdateAsync(
                        cache.Name, new UpdateCachedContentConfig { Ttl = "7200s" });
                    Assert.IsNotNull(updatedCache);
                    Assert.AreEqual(cache.Name, updatedCache.Name);

                    var gotCache = await geminiClient.Caches.GetAsync(updatedCache.Name);
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
