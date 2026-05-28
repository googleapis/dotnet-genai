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
  /// Outcome of the code execution.
  /// </summary>

  [JsonConverter(typeof(OutcomeConverter))]
  public readonly record struct Outcome : IEquatable<Outcome> {
    public string Value { get; }

    private Outcome(string value) {
      Value = value;
    }

    /// <summary>
    /// Unspecified status. This value should not be used.
    /// </summary>
    public static Outcome OutcomeUnspecified { get; } = new("OUTCOME_UNSPECIFIED");

    /// <summary>
    /// Code execution completed successfully. `output` contains the stdout, if any.
    /// </summary>
    public static Outcome OutcomeOk { get; } = new("OUTCOME_OK");

    /// <summary>
    /// Code execution failed. `output` contains the stderr and stdout, if any.
    /// </summary>
    public static Outcome OutcomeFailed { get; } = new("OUTCOME_FAILED");

    /// <summary>
    /// Code execution ran for too long, and was cancelled. There may or may not be a partial
    /// `output` present.
    /// </summary>
    public static Outcome OutcomeDeadlineExceeded { get; } = new("OUTCOME_DEADLINE_EXCEEDED");

    public static IReadOnlyList<Outcome> AllValues {
      get;
    } = new[] { OutcomeUnspecified, OutcomeOk, OutcomeFailed, OutcomeDeadlineExceeded };

    public static Outcome FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new Outcome("OUTCOME_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new Outcome(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator Outcome(string value) => FromString(value);

    public bool Equals(Outcome other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class OutcomeConverter : JsonConverter<Outcome> {
    public override Outcome Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                 JsonSerializerOptions options) {
      var value = reader.GetString();
      return Outcome.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, Outcome value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
