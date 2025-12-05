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
  /// Configuration for speech generation.
  /// </summary>

  public record SpeechConfig {
    /// <summary>
    /// Optional. The language code (ISO 639-1) for the speech synthesis.
    /// </summary>
    [JsonPropertyName("languageCode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? LanguageCode { get; set; }

    /// <summary>
    /// The configuration for a multi-speaker text-to-speech request. This field is mutually
    /// exclusive with `voice_config`.
    /// </summary>
    [JsonPropertyName("multiSpeakerVoiceConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MultiSpeakerVoiceConfig
        ? MultiSpeakerVoiceConfig {
            get; set;
          }

    /// <summary>
    /// The configuration for the voice to use.
    /// </summary>
    [JsonPropertyName("voiceConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VoiceConfig
        ? VoiceConfig {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a SpeechConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized SpeechConfig object, or null if deserialization fails.</returns>
    public static SpeechConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<SpeechConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
