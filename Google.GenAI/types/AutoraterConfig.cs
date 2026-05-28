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
  /// Autorater config used for evaluation.
  /// </summary>

  public record AutoraterConfig {
    /// <summary>
    /// Number of samples for each instance in the dataset. If not specified, the default is 4.
    /// Minimum value is 1, maximum value is 32.
    /// </summary>
    [JsonPropertyName("samplingCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int ? SamplingCount { get; set; }

    /// <summary>
    /// Optional. Default is true. Whether to flip the candidate and baseline responses. This is
    /// only applicable to the pairwise metric. If enabled, also provide
    /// PairwiseMetricSpec.candidate_response_field_name and
    /// PairwiseMetricSpec.baseline_response_field_name. When rendering
    /// PairwiseMetricSpec.metric_prompt_template, the candidate and baseline fields will be flipped
    /// for half of the samples to reduce bias.
    /// </summary>
    [JsonPropertyName("flipEnabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? FlipEnabled {
            get; set;
          }

    /// <summary>
    /// The fully qualified name of the publisher model or tuned autorater endpoint to use.
    /// Publisher model format:
    /// `projects/{project}/locations/{location}/publishers/{publisher}/models/{model}`  Tuned model
    /// endpoint format: `projects/{project}/locations/{location}/endpoints/{endpoint}`
    /// </summary>
    [JsonPropertyName("autoraterModel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? AutoraterModel {
            get; set;
          }

    /// <summary>
    /// Configuration options for model generation and outputs.
    /// </summary>
    [JsonPropertyName("generationConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GenerationConfig
        ? GenerationConfig {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a AutoraterConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized AutoraterConfig object, or null if deserialization
    /// fails.</returns>
    public static AutoraterConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<AutoraterConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
