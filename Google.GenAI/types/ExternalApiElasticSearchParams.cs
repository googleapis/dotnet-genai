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
  /// The search parameters to use for the ELASTIC_SEARCH spec.
  /// </summary>

  public record ExternalApiElasticSearchParams {
    /// <summary>
    /// The ElasticSearch index to use.
    /// </summary>
    [JsonPropertyName("index")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? Index { get; set; }

    /// <summary>
    /// Optional. Number of hits (chunks) to request. When specified, it is passed to Elasticsearch
    /// as the `num_hits` param.
    /// </summary>
    [JsonPropertyName("numHits")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? NumHits {
            get; set;
          }

    /// <summary>
    /// The ElasticSearch search template to use.
    /// </summary>
    [JsonPropertyName("searchTemplate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? SearchTemplate {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ExternalApiElasticSearchParams object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ExternalApiElasticSearchParams object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static ExternalApiElasticSearchParams
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ExternalApiElasticSearchParams>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
