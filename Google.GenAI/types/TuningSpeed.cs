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
  /// The speed of the tuning job. Only supported for Veo 3.0 models. This enum is not supported in
  /// Gemini API.
  /// </summary>

  [JsonConverter(typeof(TuningSpeedConverter))]
  public readonly record struct TuningSpeed : IEquatable<TuningSpeed> {
    public string Value { get; }

    private TuningSpeed(string value) {
      Value = value;
    }

    /// <summary>
    /// The default / unset value. For Veo 3.0 models, this defaults to FAST.
    /// </summary>
    public static TuningSpeed TuningSpeedUnspecified { get; } = new("TUNING_SPEED_UNSPECIFIED");

    /// <summary>
    /// Regular tuning speed.
    /// </summary>
    public static TuningSpeed Regular { get; } = new("REGULAR");

    /// <summary>
    /// Fast tuning speed.
    /// </summary>
    public static TuningSpeed Fast { get; } = new("FAST");

    public static IReadOnlyList<TuningSpeed> AllValues {
      get;
    } = new[] { TuningSpeedUnspecified, Regular, Fast };

    public static TuningSpeed FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new TuningSpeed("TUNING_SPEED_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new TuningSpeed(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator TuningSpeed(string value) => FromString(value);

    public bool Equals(TuningSpeed other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class TuningSpeedConverter : JsonConverter<TuningSpeed> {
    public override TuningSpeed Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                     JsonSerializerOptions options) {
      var value = reader.GetString();
      return TuningSpeed.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, TuningSpeed value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
