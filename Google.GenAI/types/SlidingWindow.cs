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
  /// Context window will be truncated by keeping only suffix of it.    Context window will always
  /// be cut at start of USER role turn. System   instructions and
  /// `BidiGenerateContentSetup.prefix_turns` will not be   subject to the sliding window mechanism,
  /// they will always stay at the   beginning of context window.
  /// </summary>

  public record SlidingWindow {
    /// <summary>
    /// Session reduction target -- how many tokens we should keep. Window shortening operation has
    /// some latency costs, so we should avoid running it on every turn. Should be < trigger_tokens.
    /// If not set, trigger_tokens/2 is assumed.
    /// </summary>
    [JsonPropertyName("targetTokens")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long ? TargetTokens { get; set; }

    /// <summary>
    /// Deserializes a JSON string to a SlidingWindow object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized SlidingWindow object, or null if deserialization fails.</returns>
    /// </summary>
    public static SlidingWindow
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<SlidingWindow>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
