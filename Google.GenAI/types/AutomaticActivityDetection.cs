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
  /// Configures automatic detection of activity.
  /// </summary>

  public record AutomaticActivityDetection {
    /// <summary>
    /// If enabled, detected voice and text input count as activity. If disabled, the client must
    /// send activity signals.
    /// </summary>
    [JsonPropertyName("disabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool ? Disabled { get; set; }

    /// <summary>
    /// Determines how likely speech is to be detected.
    /// </summary>
    [JsonPropertyName("startOfSpeechSensitivity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public StartSensitivity
        ? StartOfSpeechSensitivity {
            get; set;
          }

    /// <summary>
    /// Determines how likely detected speech is ended.
    /// </summary>
    [JsonPropertyName("endOfSpeechSensitivity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public EndSensitivity
        ? EndOfSpeechSensitivity {
            get; set;
          }

    /// <summary>
    /// The required duration of detected speech before start-of-speech is committed. The lower this
    /// value the more sensitive the start-of-speech detection is and the shorter speech can be
    /// recognized. However, this also increases the probability of false positives.
    /// </summary>
    [JsonPropertyName("prefixPaddingMs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? PrefixPaddingMs {
            get; set;
          }

    /// <summary>
    /// The required duration of detected non-speech (e.g. silence) before end-of-speech is
    /// committed. The larger this value, the longer speech gaps can be without interrupting the
    /// user's activity but this will increase the model's latency.
    /// </summary>
    [JsonPropertyName("silenceDurationMs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? SilenceDurationMs {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a AutomaticActivityDetection object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized AutomaticActivityDetection object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static AutomaticActivityDetection
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<AutomaticActivityDetection>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
