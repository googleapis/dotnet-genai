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
  /// The dataset used for evaluation. This data type is not supported in Gemini API.
  /// </summary>

  public record EvaluationDataset {
    /// <summary>
    /// BigQuery source holds the dataset.
    /// </summary>
    [JsonPropertyName("bigquerySource")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BigQuerySource ? BigquerySource { get; set; }

    /// <summary>
    /// Cloud storage source holds the dataset. Currently only one Cloud Storage file path is
    /// supported.
    /// </summary>
    [JsonPropertyName("gcsSource")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GcsSource
        ? GcsSource {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a EvaluationDataset object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized EvaluationDataset object, or null if deserialization
    /// fails.</returns>
    public static EvaluationDataset
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<EvaluationDataset>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
