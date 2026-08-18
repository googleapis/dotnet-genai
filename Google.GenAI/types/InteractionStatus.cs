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
  /// The different activity states of the live session.
  /// </summary>

  [JsonConverter(typeof(InteractionStatusConverter))]
  public readonly record struct InteractionStatus : IEquatable<InteractionStatus> {
    public string Value { get; }

    private InteractionStatus(string value) {
      Value = value;
    }

    /// <summary>
    /// Unspecified interaction status.
    /// </summary>
    public static InteractionStatus InteractionStatusUnspecified {
      get;
    } = new("INTERACTION_STATUS_UNSPECIFIED");

    /// <summary>
    /// The server is still actively processing user input or running background reasoning. More
    /// model output may follow.
    /// </summary>
    public static InteractionStatus InProgress { get; } = new("IN_PROGRESS");

    /// <summary>
    /// Deprecated: Use IDLE instead.
    /// </summary>
    public static InteractionStatus RequiresAction { get; } = new("REQUIRES_ACTION");

    /// <summary>
    /// The server has completed all processing and background reasoning.
    /// </summary>
    public static InteractionStatus Idle { get; } = new("IDLE");

    public static IReadOnlyList<InteractionStatus> AllValues {
      get;
    } = new[] { InteractionStatusUnspecified, InProgress, RequiresAction, Idle };

    public static InteractionStatus FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new InteractionStatus("INTERACTION_STATUS_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new InteractionStatus(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator InteractionStatus(string value) => FromString(value);

    public bool Equals(InteractionStatus other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class InteractionStatusConverter : JsonConverter<InteractionStatus> {
    public override InteractionStatus Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                           JsonSerializerOptions options) {
      var value = reader.GetString();
      return InteractionStatus.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, InteractionStatus value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
