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
  /// Encapsulates a review snippet.
  /// </summary>

  public record GroundingChunkMapsPlaceAnswerSourcesReviewSnippet {
    /// <summary>
    /// This review's author.
    /// </summary>
    [JsonPropertyName("authorAttribution")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GroundingChunkMapsPlaceAnswerSourcesAuthorAttribution ? AuthorAttribution { get; set; }

    /// <summary>
    /// A link where users can flag a problem with the review.
    /// </summary>
    [JsonPropertyName("flagContentUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? FlagContentUri {
            get; set;
          }

    /// <summary>
    /// A link to show the review on Google Maps.
    /// </summary>
    [JsonPropertyName("googleMapsUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? GoogleMapsUri {
            get; set;
          }

    /// <summary>
    /// A string of formatted recent time, expressing the review time relative to the current time
    /// in a form appropriate for the language and country.
    /// </summary>
    [JsonPropertyName("relativePublishTimeDescription")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? RelativePublishTimeDescription {
            get; set;
          }

    /// <summary>
    /// A reference representing this place review which may be used to look up this place review
    /// again.
    /// </summary>
    [JsonPropertyName("review")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Review {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GroundingChunkMapsPlaceAnswerSourcesReviewSnippet object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GroundingChunkMapsPlaceAnswerSourcesReviewSnippet object, or null
    /// if deserialization fails.</returns>
    /// </summary>
    public static GroundingChunkMapsPlaceAnswerSourcesReviewSnippet
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GroundingChunkMapsPlaceAnswerSourcesReviewSnippet>(
            jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
