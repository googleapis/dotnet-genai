using System.Collections.Generic;
using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Models
{
    [TestClass]
    public class GenerateContentTest : SharedBaseTest
    {
        /// <summary>
        /// Canonical test_generate_content_with_config_schema: responseSchema is the
        /// OpenAPI-style Schema object.
        /// </summary>
        private static GenerateContentConfig NewSchemaConfig()
        {
            return new GenerateContentConfig
            {
                ResponseMimeType = "application/json",
                ResponseSchema = new Schema
                {
                    Type = Google.GenAI.Types.Type.Object,
                    Properties = new Dictionary<string, Schema>
                    {
                        { "summary", new Schema { Type = Google.GenAI.Types.Type.String } }
                    }
                }
            };
        }

        /// <summary>
        /// Canonical test_generate_content_with_config_json_schema: responseJsonSchema takes
        /// a raw JSON Schema document rather than the OpenAPI Schema type.
        /// </summary>
        private static GenerateContentConfig NewJsonSchemaConfig()
        {
            return new GenerateContentConfig
            {
                ResponseMimeType = "application/json",
                ResponseJsonSchema = new Dictionary<string, object>
                {
                    { "type", "object" },
                    {
                        "properties",
                        new Dictionary<string, object>
                        {
                            { "summary", new Dictionary<string, object> { { "type", "string" } } }
                        }
                    }
                }
            };
        }

        [TestMethod]
        public async Task TestGenerateContentWithConfigSchemaMldev()
        {
            SkipGeminiInApiMode();
            await RunLive(async () =>
            {
                var response = await geminiClient.Models.GenerateContentAsync(
                    modelName, "Return a summary of the passage.", NewSchemaConfig());
                Assert.IsNotNull(response);
                Assert.IsFalse(string.IsNullOrWhiteSpace(response.Text),
                               "Expected non-empty structured output.");
            });
        }

        [TestMethod]
        public async Task TestGenerateContentWithConfigSchemaVertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                var response = await vertexClient.Models.GenerateContentAsync(
                    modelName, "Return a summary of the passage.", NewSchemaConfig());
                Assert.IsNotNull(response);
                Assert.IsFalse(string.IsNullOrWhiteSpace(response.Text),
                               "Expected non-empty structured output.");
            });
        }

        [TestMethod]
        public async Task TestGenerateContentWithConfigJsonSchemaMldev()
        {
            SkipGeminiInApiMode();
            await RunLive(async () =>
            {
                var response = await geminiClient.Models.GenerateContentAsync(
                    modelName, "Return a JSON summary.", NewJsonSchemaConfig());
                Assert.IsNotNull(response);
                Assert.IsFalse(string.IsNullOrWhiteSpace(response.Text),
                               "Expected non-empty structured output.");
            });
        }

        [TestMethod]
        public async Task TestGenerateContentWithConfigJsonSchemaVertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                var response = await vertexClient.Models.GenerateContentAsync(
                    modelName, "Return a JSON summary.", NewJsonSchemaConfig());
                Assert.IsNotNull(response);
                Assert.IsFalse(string.IsNullOrWhiteSpace(response.Text),
                               "Expected non-empty structured output.");
            });
        }
    }
}
