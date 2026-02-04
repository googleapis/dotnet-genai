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
  /// Output only. The detail state of the tuning job (while the overall `JobState` is running).
  /// This enum is not supported in Gemini API.
  /// </summary>

  [JsonConverter(typeof(TuningJobStateConverter))]
  public readonly record struct TuningJobState : IEquatable<TuningJobState> {
    public string Value { get; }

    private TuningJobState(string value) {
      Value = value;
    }

    /// <summary>
    /// Default tuning job state.
    /// </summary>
    public static TuningJobState TuningJobStateUnspecified {
      get;
    } = new("TUNING_JOB_STATE_UNSPECIFIED");

    /// <summary>
    /// Tuning job is waiting for job quota.
    /// </summary>
    public static TuningJobState TuningJobStateWaitingForQuota {
      get;
    } = new("TUNING_JOB_STATE_WAITING_FOR_QUOTA");

    /// <summary>
    /// Tuning job is validating the dataset.
    /// </summary>
    public static TuningJobState TuningJobStateProcessingDataset {
      get;
    } = new("TUNING_JOB_STATE_PROCESSING_DATASET");

    /// <summary>
    /// Tuning job is waiting for hardware capacity.
    /// </summary>
    public static TuningJobState TuningJobStateWaitingForCapacity {
      get;
    } = new("TUNING_JOB_STATE_WAITING_FOR_CAPACITY");

    /// <summary>
    /// Tuning job is running.
    /// </summary>
    public static TuningJobState TuningJobStateTuning { get; } = new("TUNING_JOB_STATE_TUNING");

    /// <summary>
    /// Tuning job is doing some post processing steps.
    /// </summary>
    public static TuningJobState TuningJobStatePostProcessing {
      get;
    } = new("TUNING_JOB_STATE_POST_PROCESSING");

    public static IReadOnlyList<TuningJobState> AllValues {
      get;
    } = new[] { TuningJobStateUnspecified,
                TuningJobStateWaitingForQuota,
                TuningJobStateProcessingDataset,
                TuningJobStateWaitingForCapacity,
                TuningJobStateTuning,
                TuningJobStatePostProcessing };

    public static TuningJobState FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new TuningJobState("TUNING_JOB_STATE_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new TuningJobState(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator TuningJobState(string value) => FromString(value);

    public bool Equals(TuningJobState other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class TuningJobStateConverter : JsonConverter<TuningJobState> {
    public override TuningJobState Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                        JsonSerializerOptions options) {
      var value = reader.GetString();
      return TuningJobState.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, TuningJobState value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
