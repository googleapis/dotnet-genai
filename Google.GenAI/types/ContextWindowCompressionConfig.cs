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
  /// Enables context window compression — a mechanism for managing the model's context window so
  /// that it does not exceed a given length. This data type is not supported in Vertex AI.
  /// </summary>

  public record ContextWindowCompressionConfig {
    /// <summary>
    /// The number of tokens (before running a turn) required to trigger a context window
    /// compression. This can be used to balance quality against latency as shorter context windows
    /// may result in faster model responses. However, any compression operation will cause a
    /// temporary latency increase, so they should not be triggered frequently. If not set, the
    /// default is 80% of the model's context window limit. This leaves 20% for the next user
    /// request/model response.
    /// </summary>
    [JsonPropertyName("triggerTokens")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long ? TriggerTokens { get; set; }

    /// <summary>
    /// A sliding-window mechanism.
    /// </summary>
    [JsonPropertyName("slidingWindow")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SlidingWindow
        ? SlidingWindow {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ContextWindowCompressionConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ContextWindowCompressionConfig object, or null if deserialization
    /// fails.</returns>
    public static ContextWindowCompressionConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize(
            jsonString, JsonConfig.TypeInfo<ContextWindowCompressionConfig>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
