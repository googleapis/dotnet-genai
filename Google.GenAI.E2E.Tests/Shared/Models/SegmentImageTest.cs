using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Models
{
    [TestClass]
    public class SegmentImageTest : SharedBaseTest
    {
        // Canonical models/segment_image test: test_segment_background.
        private const string SegmentModel = "image-segmentation-001";
        private static SegmentImageSource NewSource() =>
            new SegmentImageSource { Image = Image.FromFile("TestAssets/google.png") };

        private static SegmentImageConfig NewConfig() =>
            new SegmentImageConfig { Mode = SegmentMode.Background };

        [TestMethod]
        public async Task TestSegmentBackgroundVertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                var response = await vertexClient.Models.SegmentImageAsync(
                    SegmentModel, NewSource(), NewConfig());
                Assert.IsNotNull(response);
            });
        }
    }
}
