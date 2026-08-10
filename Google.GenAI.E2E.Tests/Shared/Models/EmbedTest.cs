using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Models
{
    [TestClass]
    public class EmbedTest : SharedBaseTest
    {
        // Canonical models/embed test table: test_embed and test_embed_gemini_embedding_2.
        private const string EmbeddingModel = "gemini-embedding-001";
        private const string EmbeddingModel2 = "gemini-embedding-2";

        private static EmbedContentConfig NewConfig() =>
            new EmbedContentConfig { OutputDimensionality = 10 };

        [TestMethod]
        public async Task TestEmbedContentGeminiEmbedding001Mldev()
        {
            SkipGeminiInApiMode();
            await RunLive(async () =>
            {
                var response = await geminiClient.Models.EmbedContentAsync(
                    EmbeddingModel, "Hello world!", NewConfig());
                Assert.IsNotNull(response);
                Assert.IsNotNull(response.Embeddings);
            });
        }

        [TestMethod]
        public async Task TestEmbedContentGeminiEmbedding001Vertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                var response = await vertexClient.Models.EmbedContentAsync(
                    EmbeddingModel, "Hello world!", NewConfig());
                Assert.IsNotNull(response);
                Assert.IsNotNull(response.Embeddings);
            });
        }

        [TestMethod]
        public async Task TestEmbedContentGeminiEmbedding2Mldev()
        {
            SkipGeminiInApiMode();
            await RunLive(async () =>
            {
                var response = await geminiClient.Models.EmbedContentAsync(
                    EmbeddingModel2, "Hello world!", NewConfig());
                Assert.IsNotNull(response);
                Assert.IsNotNull(response.Embeddings);
            });
        }

        [TestMethod]
        public async Task TestEmbedContentGeminiEmbedding2Vertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                var response = await vertexClient.Models.EmbedContentAsync(
                    EmbeddingModel2, "Hello world!", NewConfig());
                Assert.IsNotNull(response);
                Assert.IsNotNull(response.Embeddings);
            });
        }
    }
}
