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
  /// Config for `des` parameter.
  /// </summary>

  public record BatchJobDestination {
    /// <summary>
    /// Storage format of the output files. Must be one of: 'jsonl', 'bigquery', 'vertex-dataset'.
    /// </summary>
    [JsonPropertyName("format")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? Format { get; set; }

    /// <summary>
    /// The Google Cloud Storage URI to the output file.
    /// </summary>
    [JsonPropertyName("gcsUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? GcsUri {
            get; set;
          }

    /// <summary>
    /// The BigQuery URI to the output table.
    /// </summary>
    [JsonPropertyName("bigqueryUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? BigqueryUri {
            get; set;
          }

    /// <summary>
    /// The Gemini Developer API's file resource name of the output data (e.g. "files/12345"). The
    /// file will be a JSONL file with a single response per line. The responses will be
    /// GenerateContentResponse messages formatted as JSON. The responses will be written in the
    /// same order as the input requests.
    /// </summary>
    [JsonPropertyName("fileName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? FileName {
            get; set;
          }

    /// <summary>
    /// The responses to the requests in the batch. Returned when the batch was built using inlined
    /// requests. The responses will be in the same order as the input requests.
    /// </summary>
    [JsonPropertyName("inlinedResponses")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<InlinedResponse>
        ? InlinedResponses {
            get; set;
          }

    /// <summary>
    /// The responses to the requests in the batch. Returned when the batch was built using inlined
    /// requests. The responses will be in the same order as the input requests.
    /// </summary>
    [JsonPropertyName("inlinedEmbedContentResponses")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<InlinedEmbedContentResponse>
        ? InlinedEmbedContentResponses {
            get; set;
          }

    /// <summary>
    /// This field is experimental and may change in future versions. The Vertex AI dataset
    /// destination.
    /// </summary>
    [JsonPropertyName("vertexDataset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VertexMultimodalDatasetDestination
        ? VertexDataset {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a BatchJobDestination object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized BatchJobDestination object, or null if deserialization
    /// fails.</returns>
    public static BatchJobDestination
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<BatchJobDestination>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
