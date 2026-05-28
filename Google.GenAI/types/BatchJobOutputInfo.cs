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
  /// Represents the `output_info` field in batch jobs.
  /// </summary>

  public record BatchJobOutputInfo {
    /// <summary>
    /// This field is experimental and may change in future versions. The Vertex AI dataset name
    /// containing the output data.
    /// </summary>
    [JsonPropertyName("vertexMultimodalDatasetName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? VertexMultimodalDatasetName { get; set; }

    /// <summary>
    /// The full path of the Cloud Storage directory created, into which the prediction output is
    /// written.
    /// </summary>
    [JsonPropertyName("gcsOutputDirectory")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? GcsOutputDirectory {
            get; set;
          }

    /// <summary>
    /// The name of the BigQuery table created, in `predictions_TIMESTAMP` format, into which the
    /// prediction output is written.
    /// </summary>
    [JsonPropertyName("bigqueryOutputTable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? BigqueryOutputTable {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a BatchJobOutputInfo object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized BatchJobOutputInfo object, or null if deserialization
    /// fails.</returns>
    public static BatchJobOutputInfo
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<BatchJobOutputInfo>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
