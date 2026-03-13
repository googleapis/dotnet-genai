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
    }
}
