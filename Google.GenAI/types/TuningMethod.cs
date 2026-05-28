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
  /// Enum representing the tuning method.
  /// </summary>

  [JsonConverter(typeof(TuningMethodConverter))]
  public readonly record struct TuningMethod : IEquatable<TuningMethod> {
    public string Value { get; }

    private TuningMethod(string value) {
      Value = value;
    }

    /// <summary>
    /// Supervised fine tuning.
    /// </summary>
    public static TuningMethod SupervisedFineTuning { get; } = new("SUPERVISED_FINE_TUNING");

    /// <summary>
    /// Preference optimization tuning.
    /// </summary>
    public static TuningMethod PreferenceTuning { get; } = new("PREFERENCE_TUNING");

    /// <summary>
    /// Distillation tuning.
    /// </summary>
    public static TuningMethod Distillation { get; } = new("DISTILLATION");

    /// <summary>
    /// Reinforcement tuning.
    /// </summary>
    public static TuningMethod ReinforcementTuning { get; } = new("REINFORCEMENT_TUNING");

    public static IReadOnlyList<TuningMethod> AllValues {
      get;
    } = new[] { SupervisedFineTuning, PreferenceTuning, Distillation, ReinforcementTuning };

    public static TuningMethod FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new TuningMethod("UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new TuningMethod(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator TuningMethod(string value) => FromString(value);

    public bool Equals(TuningMethod other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class TuningMethodConverter : JsonConverter<TuningMethod> {
    public override TuningMethod Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                      JsonSerializerOptions options) {
      var value = reader.GetString();
      return TuningMethod.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, TuningMethod value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
