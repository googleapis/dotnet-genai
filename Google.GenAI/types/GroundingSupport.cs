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
  /// Grounding support.
  /// </summary>

  public record GroundingSupport {
    /// <summary>
    /// Confidence score of the support references. Ranges from 0 to 1. 1 is the most confident. For
    /// Gemini 2.0 and before, this list must have the same size as the grounding_chunk_indices. For
    /// Gemini 2.5 and after, this list will be empty and should be ignored.
    /// </summary>
    [JsonPropertyName("confidenceScores")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<double> ? ConfidenceScores { get; set; }

    /// <summary>
    /// A list of indices (into 'grounding_chunk') specifying the citations associated with the
    /// claim. For instance [1,3,4] means that grounding_chunk[1], grounding_chunk[3],
    /// grounding_chunk[4] are the retrieved content attributed to the claim.
    /// </summary>
    [JsonPropertyName("groundingChunkIndices")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<int>
        ? GroundingChunkIndices {
            get; set;
          }

    /// <summary>
    /// Segment of the content this support belongs to.
    /// </summary>
    [JsonPropertyName("segment")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Segment
        ? Segment {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GroundingSupport object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GroundingSupport object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static GroundingSupport
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GroundingSupport>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
