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
  /// Author attribution for a photo or review.
  /// </summary>

  public record GroundingChunkMapsPlaceAnswerSourcesAuthorAttribution {
    /// <summary>
    /// Name of the author of the Photo or Review.
    /// </summary>
    [JsonPropertyName("displayName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? DisplayName { get; set; }

    /// <summary>
    /// Profile photo URI of the author of the Photo or Review.
    /// </summary>
    [JsonPropertyName("photoUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? PhotoUri {
            get; set;
          }

    /// <summary>
    /// URI of the author of the Photo or Review.
    /// </summary>
    [JsonPropertyName("uri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Uri {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GroundingChunkMapsPlaceAnswerSourcesAuthorAttribution
    /// object. <param name="jsonString">The JSON string to deserialize.</param> <param
    /// name="options">Optional JsonSerializerOptions.</param> <returns>The deserialized
    /// GroundingChunkMapsPlaceAnswerSourcesAuthorAttribution object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static GroundingChunkMapsPlaceAnswerSourcesAuthorAttribution
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GroundingChunkMapsPlaceAnswerSourcesAuthorAttribution>(
            jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
