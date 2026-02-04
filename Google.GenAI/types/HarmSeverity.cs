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
  /// Output only. The severity of harm for this category. This enum is not supported in Gemini API.
  /// </summary>

  [JsonConverter(typeof(HarmSeverityConverter))]
  public readonly record struct HarmSeverity : IEquatable<HarmSeverity> {
    public string Value { get; }

    private HarmSeverity(string value) {
      Value = value;
    }

    /// <summary>
    /// The harm severity is unspecified.
    /// </summary>
    public static HarmSeverity HarmSeverityUnspecified { get; } = new("HARM_SEVERITY_UNSPECIFIED");

    /// <summary>
    /// The harm severity is negligible.
    /// </summary>
    public static HarmSeverity HarmSeverityNegligible { get; } = new("HARM_SEVERITY_NEGLIGIBLE");

    /// <summary>
    /// The harm severity is low.
    /// </summary>
    public static HarmSeverity HarmSeverityLow { get; } = new("HARM_SEVERITY_LOW");

    /// <summary>
    /// The harm severity is medium.
    /// </summary>
    public static HarmSeverity HarmSeverityMedium { get; } = new("HARM_SEVERITY_MEDIUM");

    /// <summary>
    /// The harm severity is high.
    /// </summary>
    public static HarmSeverity HarmSeverityHigh { get; } = new("HARM_SEVERITY_HIGH");

    public static IReadOnlyList<HarmSeverity> AllValues {
      get;
    } = new[] { HarmSeverityUnspecified, HarmSeverityNegligible, HarmSeverityLow,
                HarmSeverityMedium, HarmSeverityHigh };

    public static HarmSeverity FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new HarmSeverity("HARM_SEVERITY_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new HarmSeverity(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator HarmSeverity(string value) => FromString(value);

    public bool Equals(HarmSeverity other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class HarmSeverityConverter : JsonConverter<HarmSeverity> {
    public override HarmSeverity Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                      JsonSerializerOptions options) {
      var value = reader.GetString();
      return HarmSeverity.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, HarmSeverity value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
