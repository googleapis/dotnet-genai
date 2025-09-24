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
  /// Content filter results for a prompt sent in the request.
  /// </summary>

  public record GenerateContentResponsePromptFeedback {
    /// <summary>
    /// Output only. Blocked reason.
    /// </summary>
    [JsonPropertyName("blockReason")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BlockedReason ? BlockReason { get; set; }

    /// <summary>
    /// Output only. A readable block reason message.
    /// </summary>
    [JsonPropertyName("blockReasonMessage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? BlockReasonMessage {
            get; set;
          }

    /// <summary>
    /// Output only. Safety ratings.
    /// </summary>
    [JsonPropertyName("safetyRatings")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<SafetyRating>
        ? SafetyRatings {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GenerateContentResponsePromptFeedback object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GenerateContentResponsePromptFeedback object, or null if
    /// deserialization fails.</returns>
    /// </summary>
    public static GenerateContentResponsePromptFeedback
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GenerateContentResponsePromptFeedback>(jsonString,
                                                                                 options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
