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
  /// Specifies how the response should be scheduled in the conversation. Only applicable to
  /// NON_BLOCKING function calls, is ignored otherwise. Defaults to WHEN_IDLE.
  /// </summary>

  [JsonConverter(typeof(FunctionResponseSchedulingConverter))]
  public readonly record struct FunctionResponseScheduling
      : IEquatable<FunctionResponseScheduling> {
    public string Value { get; }

    private FunctionResponseScheduling(string value) {
      Value = value;
    }

    /// <summary>
    /// This value is unused.
    /// </summary>
    public static FunctionResponseScheduling SchedulingUnspecified {
      get;
    } = new("SCHEDULING_UNSPECIFIED");

    /// <summary>
    /// Only add the result to the conversation context, do not interrupt or trigger generation.
    /// </summary>
    public static FunctionResponseScheduling Silent { get; } = new("SILENT");

    /// <summary>
    /// Add the result to the conversation context, and prompt to generate output without
    /// interrupting ongoing generation.
    /// </summary>
    public static FunctionResponseScheduling WhenIdle { get; } = new("WHEN_IDLE");

    /// <summary>
    /// Add the result to the conversation context, interrupt ongoing generation and prompt to
    /// generate output.
    /// </summary>
    public static FunctionResponseScheduling Interrupt { get; } = new("INTERRUPT");

    public static IReadOnlyList<FunctionResponseScheduling> AllValues {
      get;
    } = new[] { SchedulingUnspecified, Silent, WhenIdle, Interrupt };

    public static FunctionResponseScheduling FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new FunctionResponseScheduling("SCHEDULING_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new FunctionResponseScheduling(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator FunctionResponseScheduling(string value) => FromString(value);

    public bool Equals(FunctionResponseScheduling other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class FunctionResponseSchedulingConverter : JsonConverter<FunctionResponseScheduling> {
    public override FunctionResponseScheduling Read(ref Utf8JsonReader reader,
                                                    System.Type typeToConvert,
                                                    JsonSerializerOptions options) {
      var value = reader.GetString();
      return FunctionResponseScheduling.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, FunctionResponseScheduling value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
