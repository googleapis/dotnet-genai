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

// Auto-generated code. Do not edit.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Serialization;

namespace Google.GenAI.Types {
  /// <summary>
  /// Scores parsed responses by calling a Cloud Run service.
  /// </summary>

  public record ReinforcementTuningCloudRunRewardScorer {
    /// <summary>
    /// URI of the Cloud Run service that will be used to compute the reward. The Vertex AI Secure
    /// Fine Tuning Service Agent
    /// (`service-PROJECT_NUMBER@gcp-sa-vertex-tune.iam.gserviceaccount.com`, where `PROJECT_NUMBER`
    /// is the numeric project number) must be granted the permission (e.g. by granting
    /// `roles/run.invoker` in IAM) to invoke the Cloud Run service.
    /// </summary>
    [JsonPropertyName("cloudRunUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? CloudRunUri { get; set; }

    /// <summary>
    /// Deserializes a JSON string to a ReinforcementTuningCloudRunRewardScorer object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ReinforcementTuningCloudRunRewardScorer object, or null if
    /// deserialization fails.</returns>
    public static ReinforcementTuningCloudRunRewardScorer
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ReinforcementTuningCloudRunRewardScorer>(jsonString,
                                                                                   options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
