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
  /// Config for `src` parameter.
  /// </summary>

  public record BatchJobSource {
    /// <summary>
    /// Storage format of the input files. Must be one of: 'jsonl', 'bigquery', 'vertex-dataset'.
    /// </summary>
    [JsonPropertyName("format")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? Format { get; set; }

    /// <summary>
    /// The Google Cloud Storage URIs to input files.
    /// </summary>
    [JsonPropertyName("gcsUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? GcsUri {
            get; set;
          }

    /// <summary>
    /// The BigQuery URI to input table.
    /// </summary>
    [JsonPropertyName("bigqueryUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? BigqueryUri {
            get; set;
          }

    /// <summary>
    /// The Gemini Developer API's file resource name of the input data (e.g. "files/12345").
    /// </summary>
    [JsonPropertyName("fileName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? FileName {
            get; set;
          }

    /// <summary>
    /// The Gemini Developer API's inlined input data to run batch job.
    /// </summary>
    [JsonPropertyName("inlinedRequests")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<InlinedRequest>
        ? InlinedRequests {
            get; set;
          }

    /// <summary>
    /// This field is experimental and may change in future versions. The Vertex AI dataset resource
    /// name to use as input. Must be of type multimodal.
    /// </summary>
    [JsonPropertyName("vertexDatasetName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? VertexDatasetName {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a BatchJobSource object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized BatchJobSource object, or null if deserialization fails.</returns>
    public static BatchJobSource
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<BatchJobSource>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
