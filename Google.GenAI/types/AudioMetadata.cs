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
  /// Metadata describes the input audio content.  Set this in `Part.audio_metadata` or
  /// `FunctionResponsePart.audio_metadata` when `inline_data` or `file_data` contains audio to
  /// configure static audio preprocessing.
  /// </summary>

  public record AudioMetadata {
    /// <summary>
    /// The start offset of the audio, relative to the start of the audio stream.
    /// </summary>
    [JsonPropertyName("startOffset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? StartOffset { get; set; }

    /// <summary>
    /// The end offset of the audio, relative to the start of the audio stream.
    /// </summary>
    [JsonPropertyName("endOffset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? EndOffset {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a AudioMetadata object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized AudioMetadata object, or null if deserialization fails.</returns>
    public static AudioMetadata
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize(jsonString, JsonConfig.TypeInfo<AudioMetadata>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
