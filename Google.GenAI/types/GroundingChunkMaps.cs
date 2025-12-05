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
  /// A `Maps` chunk is a piece of evidence that comes from Google Maps.  It contains information
  /// about a place, such as its name, address, and reviews. This is used to provide the user with
  /// rich, location-based information.
  /// </summary>

  public record GroundingChunkMaps {
    /// <summary>
    /// The sources that were used to generate the place answer.  This includes review snippets and
    /// photos that were used to generate the answer, as well as URIs to flag content.
    /// </summary>
    [JsonPropertyName("placeAnswerSources")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GroundingChunkMapsPlaceAnswerSources ? PlaceAnswerSources { get; set; }

    /// <summary>
    /// This Place's resource name, in `places/{place_id}` format.  This can be used to look up the
    /// place in the Google Maps API.
    /// </summary>
    [JsonPropertyName("placeId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? PlaceId {
            get; set;
          }

    /// <summary>
    /// The text of the place answer.
    /// </summary>
    [JsonPropertyName("text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Text {
            get; set;
          }

    /// <summary>
    /// The title of the place.
    /// </summary>
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Title {
            get; set;
          }

    /// <summary>
    /// The URI of the place.
    /// </summary>
    [JsonPropertyName("uri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Uri {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GroundingChunkMaps object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GroundingChunkMaps object, or null if deserialization
    /// fails.</returns>
    public static GroundingChunkMaps
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GroundingChunkMaps>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
