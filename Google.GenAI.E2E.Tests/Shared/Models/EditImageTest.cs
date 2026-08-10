using System.Collections.Generic;
using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Models
{
    [TestClass]
    public class EditImageTest : SharedBaseTest
    {
        // Canonical models/edit_image test: test_edit_mask_inpaint_insert.
        private const string EditModel = "imagen-3.0-capability-001";
        private const string Prompt = "Sunlight and clear weather";
        /// <summary>
        /// A raw reference plus a background mask, which is what EDIT_MODE_INPAINT_INSERTION
        /// requires. (The previous version sent a style reference and no mask, which is
        /// semantically incoherent for inpainting.)
        /// </summary>
        private static List<IReferenceImage> NewReferenceImages()
        {
            return new List<IReferenceImage>
            {
                new RawReferenceImage
                {
                    ReferenceImage = Image.FromFile("TestAssets/google.png"),
                    ReferenceId = 1
                },
                new MaskReferenceImage
                {
                    ReferenceId = 2,
                    Config = new MaskReferenceConfig
                    {
                        MaskMode = MaskReferenceMode.MaskModeBackground
                    }
                }
            };
        }

        private static EditImageConfig NewConfig() =>
            new EditImageConfig { EditMode = "EDIT_MODE_INPAINT_INSERTION" };

        [TestMethod]
        public async Task TestEditMaskInpaintInsertVertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                var response = await vertexClient.Models.EditImageAsync(
                    EditModel, Prompt, NewReferenceImages(), NewConfig());
                Assert.IsNotNull(response);
            });
        }
    }
}
