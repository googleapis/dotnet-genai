/*
 * Copyright 2025 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json.Nodes;

namespace Google.GenAI.Tests
{
    [TestClass]
    public class TransformersTest
    {
        private ApiClient vertexClient = new HttpApiClient(vertexAI: true, project: "test-project", location: "test-location");
        private ApiClient geminiClient = new HttpApiClient(vertexAI: false, apiKey: "test-api-key");

        [TestMethod]
        public void GetResourceName_Vertex_FullResourceName()
        {
            string resourceName = "projects/test-project/locations/test-location/cachedContents/123";
            string result = Transformers.GetResourceName(vertexClient, resourceName, "cachedContents");
            Assert.AreEqual(resourceName, result);
        }

        [TestMethod]
        public void GetResourceName_Vertex_LocationsName()
        {
            string resourceName = "locations/test-location/cachedContents/123";
            string result = Transformers.GetResourceName(vertexClient, resourceName, "cachedContents");
            Assert.AreEqual("projects/test-project/locations/test-location/cachedContents/123", result);
        }

        [TestMethod]
        public void GetResourceName_Vertex_PrefixAndId()
        {
            string resourceName = "cachedContents/123";
            string result = Transformers.GetResourceName(vertexClient, resourceName, "cachedContents");
            Assert.AreEqual("projects/test-project/locations/test-location/cachedContents/123", result);
        }

        [TestMethod]
        public void GetResourceName_Vertex_IdOnly()
        {
            string resourceName = "123";
            string result = Transformers.GetResourceName(vertexClient, resourceName, "cachedContents");
            Assert.AreEqual("projects/test-project/locations/test-location/cachedContents/123", result);
        }

        [TestMethod]
        public void GetResourceName_Gemini_FullResourceName()
        {
            string resourceName = "cachedContents/123";
            string result = Transformers.GetResourceName(geminiClient, resourceName, "cachedContents");
            Assert.AreEqual(resourceName, result);
        }

        [TestMethod]
        public void GetResourceName_Gemini_IdOnly()
        {
            string resourceName = "123";
            string result = Transformers.GetResourceName(geminiClient, resourceName, "cachedContents");
            Assert.AreEqual("cachedContents/123", result);
        }

        [TestMethod]
        public void TModelsUrl_Vertex_BaseModelsNull()
        {
            var result = Transformers.TModelsUrl(vertexClient, null);
            Assert.AreEqual("publishers/google/models", result);
        }

        [TestMethod]
        public void TModelsUrl_Vertex_BaseModelsTrue()
        {
            var result = Transformers.TModelsUrl(vertexClient, JsonValue.Create(true));
            Assert.AreEqual("publishers/google/models", result);
        }

        [TestMethod]
        public void TModelsUrl_Vertex_BaseModelsFalse()
        {
            var result = Transformers.TModelsUrl(vertexClient, JsonValue.Create(false));
            Assert.AreEqual("models", result);
        }

        [TestMethod]
        public void TModelsUrl_Gemini_BaseModelsNull()
        {
            var result = Transformers.TModelsUrl(geminiClient, null);
            Assert.AreEqual("models", result);
        }

        [TestMethod]
        public void TModelsUrl_Gemini_BaseModelsTrue()
        {
            var result = Transformers.TModelsUrl(geminiClient, JsonValue.Create(true));
            Assert.AreEqual("models", result);
        }

        [TestMethod]
        public void TModelsUrl_Gemini_BaseModelsFalse()
        {
            var result = Transformers.TModelsUrl(geminiClient, JsonValue.Create(false));
            Assert.AreEqual("tunedModels", result);
        }

        [TestMethod]
        public void TSchema_PopulatesPropertyOrdering()
        {
            var schema = new Schema
            {
                Type = Google.GenAI.Types.Type.Object,
                Properties = new Dictionary<string, Schema>
                {
                    { "companyName", new Schema { Type = Google.GenAI.Types.Type.String } },
                    { "companyShortName", new Schema { Type = Google.GenAI.Types.Type.String } },
                    { "person", new Schema {
                        Type = Google.GenAI.Types.Type.Object,
                        Properties = new Dictionary<string, Schema>
                        {
                            { "firstName", new Schema { Type = Google.GenAI.Types.Type.String } },
                            { "lastName", new Schema { Type = Google.GenAI.Types.Type.String } },
                            { "gender", new Schema { Type = Google.GenAI.Types.Type.String } }
                        }
                    } }
                }
            };

            var processed = Transformers.TSchema(schema);
            Assert.IsNotNull(processed);
            Assert.IsNotNull(processed.PropertyOrdering);
            CollectionAssert.AreEqual(new List<string> { "companyName", "companyShortName", "person" }, processed.PropertyOrdering);

            Assert.IsNotNull(processed.Properties["person"].PropertyOrdering);
            CollectionAssert.AreEqual(new List<string> { "firstName", "lastName", "gender" }, processed.Properties["person"].PropertyOrdering);
        }

        [TestMethod]
        public void TJsonSchema_PopulatesPropertyOrdering()
        {
            string schemaString = @"
            {
                ""type"": ""object"",
                ""properties"": {
                    ""companyName"": { ""type"": ""string"" },
                    ""companyShortName"": { ""type"": ""string"" },
                    ""person"": {
                        ""type"": ""object"",
                        ""properties"": {
                            ""firstName"": { ""type"": ""string"" },
                            ""lastName"": { ""type"": ""string"" },
                            ""gender"": { ""type"": ""string"" }
                        }
                    }
                }
            }";

            var jsonNode = JsonNode.Parse(schemaString);
            var processed = Transformers.TJsonSchema(jsonNode) as JsonObject;

            Assert.IsNotNull(processed);
            Assert.IsNotNull(processed["propertyOrdering"]);
            var rootOrdering = processed["propertyOrdering"].AsArray();
            Assert.AreEqual(3, rootOrdering.Count);
            Assert.AreEqual("companyName", rootOrdering[0].ToString());
            Assert.AreEqual("companyShortName", rootOrdering[1].ToString());
            Assert.AreEqual("person", rootOrdering[2].ToString());

            var personObj = processed["properties"]["person"].AsObject();
            Assert.IsNotNull(personObj["propertyOrdering"]);
            var personOrdering = personObj["propertyOrdering"].AsArray();
            Assert.AreEqual(3, personOrdering.Count);
            Assert.AreEqual("firstName", personOrdering[0].ToString());
            Assert.AreEqual("lastName", personOrdering[1].ToString());
            Assert.AreEqual("gender", personOrdering[2].ToString());
        }

        [TestMethod]
        public void TSchema_PopulatesPropertyOrderingForJsonNode()
        {
            string schemaString = @"
            {
                ""type"": ""object"",
                ""properties"": {
                    ""companyName"": { ""type"": ""string"" },
                    ""companyShortName"": { ""type"": ""string"" },
                    ""person"": {
                        ""type"": ""object"",
                        ""properties"": {
                            ""firstName"": { ""type"": ""string"" },
                            ""lastName"": { ""type"": ""string"" },
                            ""gender"": { ""type"": ""string"" }
                        }
                    }
                }
            }";

            var jsonNode = JsonNode.Parse(schemaString);
            var processed = Transformers.TSchema(jsonNode);

            Assert.IsNotNull(processed);
            Assert.IsNotNull(processed.PropertyOrdering);
            CollectionAssert.AreEqual(new List<string> { "companyName", "companyShortName", "person" }, processed.PropertyOrdering);

            Assert.IsNotNull(processed.Properties["person"].PropertyOrdering);
            CollectionAssert.AreEqual(new List<string> { "firstName", "lastName", "gender" }, processed.Properties["person"].PropertyOrdering);
        }

        [TestMethod]
        public void TSchema_HandlesCircularReferences()
        {
            var schema = new Schema
            {
                Type = Google.GenAI.Types.Type.Object,
                Properties = new Dictionary<string, Schema>()
            };

            // Create a circular reference by assigning the schema as a property of itself
            schema.Properties.Add("self", schema);

            // This should safely process without throwing a StackOverflowException
            var processed = Transformers.TSchema(schema);

            Assert.IsNotNull(processed);
        }
    }
}
