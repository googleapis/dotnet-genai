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

using System.Text.Json.Nodes;

using Google.GenAI.Types;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.Tests {
  [TestClass]
  public class GenerateContentParametersTest {
    [TestMethod]
    public void TestExerciseGenerateContentParameters() {
      ApiClient client = new HttpApiClient(project: "test-project-id", location: "us-central1",
                                           credentials: null, httpOptions: null);
      Models models = new Models(client);
      string body = "{\"contents\":[{\"parts\":[{\"text\":\"Explain how AI works\"}]}]}";
      GenerateContentParameters? contentParams = GenerateContentParameters.FromJson(body);
      Assert.IsNotNull(contentParams);

      var result = models.GenerateContentParametersToVertex(client, JsonObject.Parse(body), null);
      Assert.IsNotNull(result);
    }
  }
}
