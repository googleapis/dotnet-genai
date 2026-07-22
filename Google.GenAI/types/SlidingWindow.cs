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
  /// The SlidingWindow method operates by discarding content at the beginning of the context
  /// window. The resulting context will always begin at the start of a USER role turn. System
  /// instructions and any `BidiGenerateContentSetup.prefix_turns` will always remain at the
  /// beginning of the result. This data type is not supported in Vertex AI.
  /// </summary>

  public record SlidingWindow {
    /// <summary>
    /// The target number of tokens to keep. The default value is trigger_tokens/2. Discarding parts
    /// of the context window causes a temporary latency increase so this value should be calibrated
    /// to avoid frequent compression operations.
    /// </summary>
    [JsonPropertyName("targetTokens")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long ? TargetTokens { get; set; }

    /// <summary>
    /// Deserializes a JSON string to a SlidingWindow object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized SlidingWindow object, or null if deserialization fails.</returns>
    public static SlidingWindow
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize(jsonString, JsonConfig.TypeInfo<SlidingWindow>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
