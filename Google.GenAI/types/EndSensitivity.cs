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
  /// Determines how likely detected speech is ended. This enum is not supported in Vertex AI.
  /// </summary>

  [JsonConverter(typeof(EndSensitivityConverter))]
  public readonly record struct EndSensitivity : IEquatable<EndSensitivity> {
    public string Value { get; }

    private EndSensitivity(string value) {
      Value = value;
    }

    /// <summary>
    /// The default is END_SENSITIVITY_HIGH.
    /// </summary>
    public static EndSensitivity EndSensitivityUnspecified {
      get;
    } = new("END_SENSITIVITY_UNSPECIFIED");

    /// <summary>
    /// Automatic detection ends speech more often.
    /// </summary>
    public static EndSensitivity EndSensitivityHigh { get; } = new("END_SENSITIVITY_HIGH");

    /// <summary>
    /// Automatic detection ends speech less often.
    /// </summary>
    public static EndSensitivity EndSensitivityLow { get; } = new("END_SENSITIVITY_LOW");

    public static IReadOnlyList<EndSensitivity> AllValues {
      get;
    } = new[] { EndSensitivityUnspecified, EndSensitivityHigh, EndSensitivityLow };

    public static EndSensitivity FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new EndSensitivity("END_SENSITIVITY_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new EndSensitivity(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator EndSensitivity(string value) => FromString(value);

    public bool Equals(EndSensitivity other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class EndSensitivityConverter : JsonConverter<EndSensitivity> {
    public override EndSensitivity Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                        JsonSerializerOptions options) {
      var value = reader.GetString();
      return EndSensitivity.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, EndSensitivity value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
