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
    /// List of supporting references retrieved from specified grounding source.
    /// </summary>
    [JsonPropertyName("groundingChunks")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<GroundingChunk> ? GroundingChunks { get; set; }

    /// <summary>
    /// List of grounding support.
    /// </summary>
    [JsonPropertyName("groundingSupports")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<GroundingSupport>
        ? GroundingSupports {
            get; set;
          }

    /// <summary>
    /// Metadata related to retrieval in the grounding flow.
    /// </summary>
    [JsonPropertyName("retrievalMetadata")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RetrievalMetadata
        ? RetrievalMetadata {
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
    /// Web search queries for the following-up web search.
    /// </summary>
    [JsonPropertyName("webSearchQueries")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? WebSearchQueries {
            get; set;
          }

    /// <summary>
    /// Optional. Output only. A token that can be used to render a Google Maps widget with the
    /// contextual data. This field is populated only when the grounding source is Google Maps.
    /// </summary>
    [JsonPropertyName("googleMapsWidgetContextToken")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? GoogleMapsWidgetContextToken {
            get; set;
          }

    /// <summary>
    /// Optional. The queries that were executed by the retrieval tools. This field is populated
    /// only when the grounding source is a retrieval tool, such as Vertex AI Search. This field is
    /// not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("retrievalQueries")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? RetrievalQueries {
            get; set;
          }

    /// <summary>
    /// Optional. Output only. A list of URIs that can be used to flag a place or review for
    /// inappropriate content. This field is populated only when the grounding source is Google
    /// Maps. This field is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("sourceFlaggingUris")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<GroundingMetadataSourceFlaggingUri>
        ? SourceFlaggingUris {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GroundingMetadata object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GroundingMetadata object, or null if deserialization
    /// fails.</returns>
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
