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
  /// The tuning task for Veo. This enum is not supported in Gemini API.
  /// </summary>

  [JsonConverter(typeof(TuningTaskConverter))]
  public readonly record struct TuningTask : IEquatable<TuningTask> {
    public string Value { get; }

    private TuningTask(string value) {
      Value = value;
    }

    /// <summary>
    /// Default value. This value is unused.
    /// </summary>
    public static TuningTask TuningTaskUnspecified { get; } = new("TUNING_TASK_UNSPECIFIED");

    /// <summary>
    /// Tuning task for image to video.
    /// </summary>
    public static TuningTask TuningTaskI2v { get; } = new("TUNING_TASK_I2V");

    /// <summary>
    /// Tuning task for text to video.
    /// </summary>
    public static TuningTask TuningTaskT2v { get; } = new("TUNING_TASK_T2V");

    /// <summary>
    /// Tuning task for reference to video.
    /// </summary>
    public static TuningTask TuningTaskR2v { get; } = new("TUNING_TASK_R2V");

    public static IReadOnlyList<TuningTask> AllValues {
      get;
    } = new[] { TuningTaskUnspecified, TuningTaskI2v, TuningTaskT2v, TuningTaskR2v };

    public static TuningTask FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new TuningTask("TUNING_TASK_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new TuningTask(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator TuningTask(string value) => FromString(value);

    public bool Equals(TuningTask other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class TuningTaskConverter : JsonConverter<TuningTask> {
    public override TuningTask Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                    JsonSerializerOptions options) {
      var value = reader.GetString();
      return TuningTask.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, TuningTask value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
