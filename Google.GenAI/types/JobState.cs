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
  /// Job state.
  /// </summary>

  [JsonConverter(typeof(JobStateConverter))]
  public readonly record struct JobState : IEquatable<JobState> {
    public string Value { get; }

    private JobState(string value) {
      Value = value;
    }

    /// <summary>
    /// The job state is unspecified.
    /// </summary>
    public static JobState JobStateUnspecified { get; } = new("JOB_STATE_UNSPECIFIED");

    /// <summary>
    /// The job has been just created or resumed and processing has not yet begun.
    /// </summary>
    public static JobState JobStateQueued { get; } = new("JOB_STATE_QUEUED");

    /// <summary>
    /// The service is preparing to run the job.
    /// </summary>
    public static JobState JobStatePending { get; } = new("JOB_STATE_PENDING");

    /// <summary>
    /// The job is in progress.
    /// </summary>
    public static JobState JobStateRunning { get; } = new("JOB_STATE_RUNNING");

    /// <summary>
    /// The job completed successfully.
    /// </summary>
    public static JobState JobStateSucceeded { get; } = new("JOB_STATE_SUCCEEDED");

    /// <summary>
    /// The job failed.
    /// </summary>
    public static JobState JobStateFailed { get; } = new("JOB_STATE_FAILED");

    /// <summary>
    /// The job is being cancelled. From this state the job may only go to either
    /// `JOB_STATE_SUCCEEDED`, `JOB_STATE_FAILED` or `JOB_STATE_CANCELLED`.
    /// </summary>
    public static JobState JobStateCancelling { get; } = new("JOB_STATE_CANCELLING");

    /// <summary>
    /// The job has been cancelled.
    /// </summary>
    public static JobState JobStateCancelled { get; } = new("JOB_STATE_CANCELLED");

    /// <summary>
    /// The job has been stopped, and can be resumed.
    /// </summary>
    public static JobState JobStatePaused { get; } = new("JOB_STATE_PAUSED");

    /// <summary>
    /// The job has expired.
    /// </summary>
    public static JobState JobStateExpired { get; } = new("JOB_STATE_EXPIRED");

    /// <summary>
    /// The job is being updated. Only jobs in the `RUNNING` state can be updated. After updating,
    /// the job goes back to the `RUNNING` state.
    /// </summary>
    public static JobState JobStateUpdating { get; } = new("JOB_STATE_UPDATING");

    /// <summary>
    /// The job is partially succeeded, some results may be missing due to errors.
    /// </summary>
    public static JobState JobStatePartiallySucceeded {
      get;
    } = new("JOB_STATE_PARTIALLY_SUCCEEDED");

    public static IReadOnlyList<JobState> AllValues {
      get;
    } = new[] { JobStateUnspecified, JobStateQueued,    JobStatePending,
                JobStateRunning,     JobStateSucceeded, JobStateFailed,
                JobStateCancelling,  JobStateCancelled, JobStatePaused,
                JobStateExpired,     JobStateUpdating,  JobStatePartiallySucceeded };

    public static JobState FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new JobState("JOB_STATE_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new JobState(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator JobState(string value) => FromString(value);

    public bool Equals(JobState other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class JobStateConverter : JsonConverter<JobState> {
    public override JobState Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                  JsonSerializerOptions options) {
      var value = reader.GetString();
      return JobState.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, JobState value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
