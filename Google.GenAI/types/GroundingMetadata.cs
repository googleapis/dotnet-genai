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
  /// Metadata returned to client when grounding is enabled.
  /// </summary>

  public record GroundingMetadata {
    /// <summary>
    /// Optional. Output only. Resource name of the Google Maps widget context token to be used with
    /// the PlacesContextElement widget to render contextual data. This is populated only for Google
    /// Maps grounding.
    /// </summary>
    [JsonPropertyName("googleMapsWidgetContextToken")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? GoogleMapsWidgetContextToken { get; set; }

    /// <summary>
    /// List of supporting references retrieved from specified grounding source.
    /// </summary>
    [JsonPropertyName("groundingChunks")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<GroundingChunk>
        ? GroundingChunks {
            get; set;
          }

    /// <summary>
    /// Optional. List of grounding support.
    /// </summary>
    [JsonPropertyName("groundingSupports")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<GroundingSupport>
        ? GroundingSupports {
            get; set;
          }

    /// <summary>
    /// Optional. Output only. Retrieval metadata.
    /// </summary>
    [JsonPropertyName("retrievalMetadata")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RetrievalMetadata
        ? RetrievalMetadata {
            get; set;
          }

    /// <summary>
    /// Optional. Queries executed by the retrieval tools.
    /// </summary>
    [JsonPropertyName("retrievalQueries")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? RetrievalQueries {
            get; set;
          }

    /// <summary>
    /// Optional. Google search entry for the following-up web searches.
    /// </summary>
    [JsonPropertyName("searchEntryPoint")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SearchEntryPoint
        ? SearchEntryPoint {
            get; set;
          }

    /// <summary>
    /// Optional. Web search queries for the following-up web search.
    /// </summary>
    [JsonPropertyName("webSearchQueries")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? WebSearchQueries {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GroundingMetadata object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GroundingMetadata object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static GroundingMetadata
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GroundingMetadata>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
