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
  /// A chunk of evidence that was used to generate the response.
  /// </summary>

  public record GroundingChunk {
    /// <summary>
    /// A `Maps` chunk is a piece of evidence that comes from Google Maps.  It contains information
    /// about a place, such as its name, address, and reviews. This is used to provide the user with
    /// rich, location-based information.
    /// </summary>
    [JsonPropertyName("maps")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GroundingChunkMaps ? Maps { get; set; }

    /// <summary>
    /// A grounding chunk from a data source retrieved by a retrieval tool, such as Vertex AI
    /// Search. See the `RetrievedContext` message for details
    /// </summary>
    [JsonPropertyName("retrievedContext")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GroundingChunkRetrievedContext
        ? RetrievedContext {
            get; set;
          }

    /// <summary>
    /// A grounding chunk from a web page, typically from Google Search. See the `Web` message for
    /// details.
    /// </summary>
    [JsonPropertyName("web")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GroundingChunkWeb
        ? Web {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GroundingChunk object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GroundingChunk object, or null if deserialization fails.</returns>
    public static GroundingChunk
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GroundingChunk>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
