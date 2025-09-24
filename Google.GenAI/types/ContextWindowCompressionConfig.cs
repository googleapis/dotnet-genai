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
  /// Enables context window compression -- mechanism managing model context window so it does not
  /// exceed given length.
  /// </summary>

  public record ContextWindowCompressionConfig {
    /// <summary>
    /// Number of tokens (before running turn) that triggers context window compression mechanism.
    /// </summary>
    [JsonPropertyName("triggerTokens")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long ? TriggerTokens { get; set; }

    /// <summary>
    /// Sliding window compression mechanism.
    /// </summary>
    [JsonPropertyName("slidingWindow")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SlidingWindow
        ? SlidingWindow {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ContextWindowCompressionConfig object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ContextWindowCompressionConfig object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static ContextWindowCompressionConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ContextWindowCompressionConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
