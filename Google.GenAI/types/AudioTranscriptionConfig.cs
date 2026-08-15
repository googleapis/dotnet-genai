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
  /// The audio transcription configuration in Setup.
  /// </summary>

  public record AudioTranscriptionConfig {
    /// <summary>
    /// BCP-47 language codes providing hints about the languages present in the audio. If omitted
    /// or empty, defaults to automatic language detection.
    /// </summary>
    [JsonPropertyName("languageCodes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string> ? LanguageCodes { get; set; }

    /// <summary>
    /// Deprecated: Auto-detection is now the default when language_codes is omitted. This field
    /// will be removed in a future version.
    /// </summary>
    [JsonPropertyName("languageAuto")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LanguageAuto
        ? LanguageAuto {
            get; set;
          }

    /// <summary>
    /// Deprecated: Use top-level language_codes instead. This field will be removed in a future
    /// version.
    /// </summary>
    [JsonPropertyName("languageHints")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LanguageHints
        ? LanguageHints {
            get; set;
          }

    /// <summary>
    /// A list of custom vocabulary phrases, which biases the ASR model to improve recognition of
    /// these specific terms.
    /// </summary>
    [JsonPropertyName("customVocabulary")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? CustomVocabulary {
            get; set;
          }

    /// <summary>
    /// Deprecated. A list of phrases used for speech adaptation, which biases the ASR model to
    /// improve recognition of these specific terms.
    /// </summary>
    [JsonPropertyName("adaptationPhrases")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? AdaptationPhrases {
            get; set;
          }

    /// <summary>
    /// Configures speaker diarization.
    /// </summary>
    [JsonPropertyName("diarization")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? Diarization {
            get; set;
          }

    /// <summary>
    /// Configures word-level timestamp generation.
    /// </summary>
    [JsonPropertyName("wordTimestamp")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? WordTimestamp {
            get; set;
          }

    /// <summary>
    /// Optional. Transcription mode.  When set to `SMART`, the model performs disfluency removal
    /// (eliminating filler words, repetitions, and false starts), light grammatical cleanup,
    /// automatic formatting (paragraphs, bullet points, numbered lists), and minor user edits
    /// (inline self-corrections). Incompatible with `word_timestamp` and `diarization`.
    /// </summary>
    [JsonPropertyName("mode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AudioTranscriptionConfigMode
        ? Mode {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a AudioTranscriptionConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized AudioTranscriptionConfig object, or null if deserialization
    /// fails.</returns>
    public static AudioTranscriptionConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize(jsonString,
                                          JsonConfig.TypeInfo<AudioTranscriptionConfig>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
