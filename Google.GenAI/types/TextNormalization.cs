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

using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Text.Json;

namespace Google.GenAI.Types {
  /// <summary>
  /// Text normalization mode for speech synthesis.
  /// </summary>

  [JsonConverter(typeof(TextNormalizationConverter))]
  public readonly record struct TextNormalization : IEquatable<TextNormalization> {
    public string Value { get; }

    private TextNormalization(string value) {
      Value = value;
    }

    /// <summary>
    /// Unspecified text normalization mode. Defaults to `AUTO`.
    /// </summary>
    public static TextNormalization TextNormalizationUnspecified {
      get;
    } = new("TEXT_NORMALIZATION_UNSPECIFIED");

    /// <summary>
    /// Automatically determines whether to apply text normalization based on the model and speech
    /// mode.
    /// </summary>
    public static TextNormalization Auto { get; } = new("AUTO");

    /// <summary>
    /// Enables text normalization for numbers, currencies, dates, and units.
    /// </summary>
    public static TextNormalization Enabled { get; } = new("ENABLED");

    /// <summary>
    /// Disables text normalization for pre-normalized or phonetic inputs.
    /// </summary>
    public static TextNormalization Disabled { get; } = new("DISABLED");

    public static IReadOnlyList<TextNormalization> AllValues {
      get;
    } = new[] { TextNormalizationUnspecified, Auto, Enabled, Disabled };

    public static TextNormalization FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new TextNormalization("TEXT_NORMALIZATION_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new TextNormalization(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator TextNormalization(string value) => FromString(value);

    public bool Equals(TextNormalization other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class TextNormalizationConverter : JsonConverter<TextNormalization> {
    public override TextNormalization Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                           JsonSerializerOptions options) {
      var value = reader.GetString();
      return TextNormalization.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, TextNormalization value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
