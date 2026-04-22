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
  /// Supervised fine-tuning training dataset.
  /// </summary>

  public record TuningDataset {
    /// <summary>
    /// GCS URI of the file containing training dataset in JSONL format.
    /// </summary>
    [JsonPropertyName("gcsUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? GcsUri { get; set; }

    /// <summary>
    /// The resource name of the Gemini Enterprise Agent Platform (previously known as Vertex AI)
    /// Multimodal Dataset that is used as training dataset. Example:
    /// 'projects/my-project-id-or-number/locations/my-location/datasets/my-dataset-id'.
    /// </summary>
    [JsonPropertyName("vertexDatasetResource")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? VertexDatasetResource {
            get; set;
          }

    /// <summary>
    /// Inline examples with simple input/output text.
    /// </summary>
    [JsonPropertyName("examples")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<TuningExample>
        ? Examples {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a TuningDataset object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized TuningDataset object, or null if deserialization fails.</returns>
    public static TuningDataset
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<TuningDataset>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
