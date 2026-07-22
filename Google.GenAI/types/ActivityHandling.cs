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
  /// Defines what effect activity has. This enum is not supported in Vertex AI.
  /// </summary>

  [JsonConverter(typeof(ActivityHandlingConverter))]
  public readonly record struct ActivityHandling : IEquatable<ActivityHandling> {
    public string Value { get; }

    private ActivityHandling(string value) {
      Value = value;
    }

    /// <summary>
    /// If unspecified, the default behavior is `START_OF_ACTIVITY_INTERRUPTS`.
    /// </summary>
    public static ActivityHandling ActivityHandlingUnspecified {
      get;
    } = new("ACTIVITY_HANDLING_UNSPECIFIED");

    /// <summary>
    /// If true, start of activity will interrupt the model's response (also called "barge in"). The
    /// model's current response will be cut-off in the moment of the interruption. This is the
    /// default behavior.
    /// </summary>
    public static ActivityHandling StartOfActivityInterrupts {
      get;
    } = new("START_OF_ACTIVITY_INTERRUPTS");

    /// <summary>
    /// The model's response will not be interrupted.
    /// </summary>
    public static ActivityHandling NoInterruption { get; } = new("NO_INTERRUPTION");

    public static IReadOnlyList<ActivityHandling> AllValues {
      get;
    } = new[] { ActivityHandlingUnspecified, StartOfActivityInterrupts, NoInterruption };

    public static ActivityHandling FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new ActivityHandling("ACTIVITY_HANDLING_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new ActivityHandling(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator ActivityHandling(string value) => FromString(value);

    public bool Equals(ActivityHandling other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class ActivityHandlingConverter : JsonConverter<ActivityHandling> {
    public override ActivityHandling Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                          JsonSerializerOptions options) {
      var value = reader.GetString();
      return ActivityHandling.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, ActivityHandling value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
