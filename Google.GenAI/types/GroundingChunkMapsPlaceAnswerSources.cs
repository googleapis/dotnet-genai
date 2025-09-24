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
  /// Sources used to generate the place answer.
  /// </summary>

  public record GroundingChunkMapsPlaceAnswerSources {
    /// <summary>
    /// A link where users can flag a problem with the generated answer.
    /// </summary>
    [JsonPropertyName("flagContentUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? FlagContentUri { get; set; }

    /// <summary>
    /// Snippets of reviews that are used to generate the answer.
    /// </summary>
    [JsonPropertyName("reviewSnippets")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<GroundingChunkMapsPlaceAnswerSourcesReviewSnippet>
        ? ReviewSnippets {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GroundingChunkMapsPlaceAnswerSources object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GroundingChunkMapsPlaceAnswerSources object, or null if
    /// deserialization fails.</returns>
    /// </summary>
    public static GroundingChunkMapsPlaceAnswerSources
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GroundingChunkMapsPlaceAnswerSources>(jsonString,
                                                                                options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
