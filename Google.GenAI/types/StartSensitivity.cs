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
  /// Determines how likely speech is to be detected. This enum is not supported in Vertex AI.
  /// </summary>

  [JsonConverter(typeof(StartSensitivityConverter))]
  public readonly record struct StartSensitivity : IEquatable<StartSensitivity> {
    public string Value { get; }

    private StartSensitivity(string value) {
      Value = value;
    }

    /// <summary>
    /// The default is START_SENSITIVITY_HIGH.
    /// </summary>
    public static StartSensitivity StartSensitivityUnspecified {
      get;
    } = new("START_SENSITIVITY_UNSPECIFIED");

    /// <summary>
    /// Automatic detection will detect the start of speech more often.
    /// </summary>
    public static StartSensitivity StartSensitivityHigh { get; } = new("START_SENSITIVITY_HIGH");

    /// <summary>
    /// Automatic detection will detect the start of speech less often.
    /// </summary>
    public static StartSensitivity StartSensitivityLow { get; } = new("START_SENSITIVITY_LOW");

    public static IReadOnlyList<StartSensitivity> AllValues {
      get;
    } = new[] { StartSensitivityUnspecified, StartSensitivityHigh, StartSensitivityLow };

    public static StartSensitivity FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new StartSensitivity("START_SENSITIVITY_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new StartSensitivity(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator StartSensitivity(string value) => FromString(value);

    public bool Equals(StartSensitivity other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class StartSensitivityConverter : JsonConverter<StartSensitivity> {
    public override StartSensitivity Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                          JsonSerializerOptions options) {
      var value = reader.GetString();
      return StartSensitivity.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, StartSensitivity value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
