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
  /// Evaluate Dataset Run Result for Tuning Job. This data type is not supported in Gemini API.
  /// </summary>

  public record EvaluateDatasetRun {
    /// <summary>
    /// Output only. The checkpoint id used in the evaluation run. Only populated when evaluating
    /// checkpoints.
    /// </summary>
    [JsonPropertyName("checkpointId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? CheckpointId { get; set; }

    /// <summary>
    /// Output only. The error of the evaluation run if any.
    /// </summary>
    [JsonPropertyName("error")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GoogleRpcStatus
        ? Error {
            get; set;
          }

    /// <summary>
    /// Output only. Results for EvaluationService.EvaluateDataset.
    /// </summary>
    [JsonPropertyName("evaluateDatasetResponse")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public EvaluateDatasetResponse
        ? EvaluateDatasetResponse {
            get; set;
          }

    /// <summary>
    /// Output only. The operation ID of the evaluation run. Format:
    /// `projects/{project}/locations/{location}/operations/{operation_id}`.
    /// </summary>
    [JsonPropertyName("operationName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? OperationName {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a EvaluateDatasetRun object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized EvaluateDatasetRun object, or null if deserialization
    /// fails.</returns>
    public static EvaluateDatasetRun
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<EvaluateDatasetRun>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
