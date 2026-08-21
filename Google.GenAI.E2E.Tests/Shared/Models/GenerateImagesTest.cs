using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Models
{
    [TestClass]
    public class GenerateImagesTest : SharedBaseTest
    {
        private const string ImagenModel = "imagen-4.0-generate-001";

        private static GenerateImagesConfig NewConfig() =>
            new GenerateImagesConfig { NumberOfImages = 1, OutputMimeType = "image/jpeg" };

        [TestMethod]
        public async Task TestSimplePromptVertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                var response = await vertexClient.Models.GenerateImagesAsync(
                    ImagenModel, "Red skateboard", NewConfig());
                Assert.IsNotNull(response);
                Assert.IsNotNull(response.GeneratedImages);
            });
        }
    }
}
