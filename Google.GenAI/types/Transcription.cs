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
  /// Audio transcription in Server Content.
  /// </summary>

  public record Transcription {
    /// <summary>
    /// Optional. Transcription text.
    /// </summary>
    [JsonPropertyName("text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? Text { get; set; }

    /// <summary>
    /// Optional. The bool indicates the end of the transcription.
    /// </summary>
    [JsonPropertyName("finished")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? Finished {
            get; set;
          }

    /// <summary>
    /// The BCP-47 language code of the transcription.
    /// </summary>
    [JsonPropertyName("languageCode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? LanguageCode {
            get; set;
          }

    /// <summary>
    /// A label identifying the speaker of this audio segment (e.g. "spk_1", "spk_2").
    /// </summary>
    [JsonPropertyName("speakerLabel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? SpeakerLabel {
            get; set;
          }

    /// <summary>
    /// Detailed word-level transcriptions and timing details.
    /// </summary>
    [JsonPropertyName("words")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<WordInfo>
        ? Words {
            get; set;
          }

    /// <summary>
    /// Start offset in time of the transcription relative to the start of the audio.
    /// </summary>
    [JsonPropertyName("startOffset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? StartOffset {
            get; set;
          }

    /// <summary>
    /// End offset in time of the transcription relative to the start of the audio.
    /// </summary>
    [JsonPropertyName("endOffset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? EndOffset {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a Transcription object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized Transcription object, or null if deserialization fails.</returns>
    public static Transcription
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize(jsonString, JsonConfig.TypeInfo<Transcription>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
