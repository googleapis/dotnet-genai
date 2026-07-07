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
  /// Config for stream translation.
  /// </summary>

  public record TranslationConfig {
    /// <summary>
    /// If true, the model will generate audio when the target language is spoken, essentially it
    /// will parrot the input. If false, we will not produce audio for the target language.
    /// </summary>
    [JsonPropertyName("echoTargetLanguage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool ? EchoTargetLanguage { get; set; }

    /// <summary>
    /// The target language for translation. Supported values are BCP-47 language codes (e.g. "en",
    /// "es", "fr").
    /// </summary>
    [JsonPropertyName("targetLanguageCode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? TargetLanguageCode {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a TranslationConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized TranslationConfig object, or null if deserialization
    /// fails.</returns>
    public static TranslationConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<TranslationConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
