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
  /// The number of thoughts tokens that the model should generate.
  /// </summary>

  [JsonConverter(typeof(ThinkingLevelConverter))]
  public readonly record struct ThinkingLevel : IEquatable<ThinkingLevel> {
    public string Value { get; }

    private ThinkingLevel(string value) {
      Value = value;
    }

    /// <summary>
    /// Unspecified thinking level.
    /// </summary>
    public static ThinkingLevel ThinkingLevelUnspecified {
      get;
    } = new("THINKING_LEVEL_UNSPECIFIED");

    /// <summary>
    /// MINIMAL thinking level.
    /// </summary>
    public static ThinkingLevel Minimal { get; } = new("MINIMAL");

    /// <summary>
    /// Low thinking level.
    /// </summary>
    public static ThinkingLevel Low { get; } = new("LOW");

    /// <summary>
    /// Medium thinking level.
    /// </summary>
    public static ThinkingLevel Medium { get; } = new("MEDIUM");

    /// <summary>
    /// High thinking level.
    /// </summary>
    public static ThinkingLevel High { get; } = new("HIGH");

    public static IReadOnlyList<ThinkingLevel> AllValues {
      get;
    } = new[] { ThinkingLevelUnspecified, Minimal, Low, Medium, High };

    public static ThinkingLevel FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new ThinkingLevel("THINKING_LEVEL_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new ThinkingLevel(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator ThinkingLevel(string value) => FromString(value);

    public bool Equals(ThinkingLevel other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class ThinkingLevelConverter : JsonConverter<ThinkingLevel> {
    public override ThinkingLevel Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                       JsonSerializerOptions options) {
      var value = reader.GetString();
      return ThinkingLevel.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, ThinkingLevel value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
