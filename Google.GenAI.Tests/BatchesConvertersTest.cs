/*
 * Copyright 2026 Google LLC
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
  public class BatchesConvertersTest {
    private static BatchJob? BatchJobFromMldev(string response) {
      using var apiClient = new HttpApiClient(apiKey: "test-api-key");
      var batches = new Batches(apiClient);
      JsonNode converted = batches.BatchJobFromMldev(JsonNode.Parse(response)!, new JsonObject());
      return BatchJob.FromJson(converted.ToJsonString());
    }

    /// <summary>
    /// The input file name in the Gemini API response metadata populates Src.FileName.
    /// </summary>
    [TestMethod]
    public void BatchJobFromMldev_SetsSrcFileName() {
      BatchJob? job = BatchJobFromMldev("""
          {"name": "batches/123",
           "metadata": {"state": "BATCH_STATE_PENDING",
                        "inputConfig": {"fileName": "files/abc"}}}
          """);

      Assert.IsNotNull(job?.Src);
      Assert.AreEqual("files/abc", job.Src.FileName);
      Assert.IsNull(job.Src.InlinedRequests);
    }

    /// <summary>
    /// Inline requests in the Gemini API response are not mapped to Src.
    /// </summary>
    [TestMethod]
    public void BatchJobFromMldev_InlinedRequests_LeavesSrcUnset() {
      BatchJob? job = BatchJobFromMldev("""
          {"name": "batches/123",
           "metadata": {"state": "BATCH_STATE_PENDING",
                        "inputConfig": {"requests": {"requests": [
                          {"request": {"contents": [{"parts": [{"text": "Hello"}]}]}}]}}}}
          """);

      Assert.IsNotNull(job);
      Assert.AreEqual("batches/123", job.Name);
      Assert.IsNull(job.Src);
    }
  }
}
