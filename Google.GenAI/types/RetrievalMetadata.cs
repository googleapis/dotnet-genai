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
  /// Metadata related to the retrieval grounding source. This is part of the `GroundingMetadata`
  /// returned when grounding is enabled.
  /// </summary>

  public record RetrievalMetadata {
    /// <summary>
    /// Optional. A score indicating how likely it is that a Google Search query could help answer
    /// the prompt. The score is in the range of `[0, 1]`. A score of 1 means the model is confident
    /// that a search will be helpful, and 0 means it is not. This score is populated only when
    /// Google Search grounding and dynamic retrieval are enabled. The score is used to determine
    /// whether to trigger a search.
    /// </summary>
    [JsonPropertyName("googleSearchDynamicRetrievalScore")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double ? GoogleSearchDynamicRetrievalScore { get; set; }

    /// <summary>
    /// Deserializes a JSON string to a RetrievalMetadata object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized RetrievalMetadata object, or null if deserialization
    /// fails.</returns>
    public static RetrievalMetadata
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize(jsonString,
                                          JsonConfig.TypeInfo<RetrievalMetadata>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
