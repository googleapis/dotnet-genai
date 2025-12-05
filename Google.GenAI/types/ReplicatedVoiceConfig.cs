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
  /// The configuration for the replicated voice to use. This data type is not supported in Gemini
  /// API.
  /// </summary>

  public record ReplicatedVoiceConfig {
    /// <summary>
    /// Optional. The mimetype of the voice sample. Currently only mime_type=audio/pcm is supported,
    /// which is raw mono 16-bit signed little-endian pcm data, with 24k sampling rate.
    /// </summary>
    [JsonPropertyName("mimeType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? MimeType { get; set; }

    /// <summary>
    /// Optional. The sample of the custom voice.
    /// </summary>
    [JsonPropertyName("voiceSampleAudio")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public byte[]
        ? VoiceSampleAudio {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ReplicatedVoiceConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ReplicatedVoiceConfig object, or null if deserialization
    /// fails.</returns>
    public static ReplicatedVoiceConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ReplicatedVoiceConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
