using System.Collections.Generic;
using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Models
{
    [TestClass]
    public class RecontextImageTest : SharedBaseTest
    {
        // Canonical models/recontext_image test: test_virtual_try_on. Uses the shared
        // fixtures a person and a garment; passing the same logo as both (as the previous
        // version did) is not a meaningful virtual try-on.
        private const string RecontextModel = "virtual-try-on-001";
        private const string PersonImageUri = "gs://genai-sdk-tests/inputs/images/man.jpg";
        private const string ProductImageUri = "gs://genai-sdk-tests/inputs/images/pants.jpg";
        private static RecontextImageSource NewSource()
        {
            return new RecontextImageSource
            {
                PersonImage = new Image { GcsUri = PersonImageUri },
                ProductImages = new List<ProductImage>
                {
                    new ProductImage { ProductImageField = new Image { GcsUri = ProductImageUri } }
                }
            };
        }

        private static RecontextImageConfig NewConfig() =>
            new RecontextImageConfig { NumberOfImages = 1, OutputMimeType = "image/jpeg" };

        [TestMethod]
        public async Task TestVirtualTryOnVertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                var response = await vertexClient.Models.RecontextImageAsync(
                    RecontextModel, NewSource(), NewConfig());
                Assert.IsNotNull(response);
            });
        }
    }
}
