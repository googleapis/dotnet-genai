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
  /// Configuration for a voice.
  /// </summary>

  public record VoiceConfig {
    /// <summary>
    /// The configuration for a prebuilt voice.
    /// </summary>
    [JsonPropertyName("prebuiltVoiceConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PrebuiltVoiceConfig ? PrebuiltVoiceConfig { get; set; }

    /// <summary>
    /// Optional. The configuration for a replicated voice. This enables users to replicate a voice
    /// from an audio sample. This field is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("replicatedVoiceConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ReplicatedVoiceConfig
        ? ReplicatedVoiceConfig {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a VoiceConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized VoiceConfig object, or null if deserialization fails.</returns>
    public static VoiceConfig ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<VoiceConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
