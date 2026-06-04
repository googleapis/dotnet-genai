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
  /// Represents how much to think for the tuning job.
  /// </summary>

  [JsonConverter(typeof(ReinforcementTuningThinkingLevelConverter))]
  public readonly record struct ReinforcementTuningThinkingLevel
      : IEquatable<ReinforcementTuningThinkingLevel> {
    public string Value { get; }

    private ReinforcementTuningThinkingLevel(string value) {
      Value = value;
    }

    /// <summary>
    /// Unspecified thinking level.
    /// </summary>
    public static ReinforcementTuningThinkingLevel ReinforcementTuningThinkingLevelUnspecified {
      get;
    } = new("REINFORCEMENT_TUNING_THINKING_LEVEL_UNSPECIFIED");

    /// <summary>
    /// Little to no thinking.
    /// </summary>
    public static ReinforcementTuningThinkingLevel Minimal { get; } = new("MINIMAL");

    /// <summary>
    /// High thinking level.
    /// </summary>
    public static ReinforcementTuningThinkingLevel High { get; } = new("HIGH");

    public static IReadOnlyList<ReinforcementTuningThinkingLevel> AllValues {
      get;
    } = new[] { ReinforcementTuningThinkingLevelUnspecified, Minimal, High };

    public static ReinforcementTuningThinkingLevel FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new ReinforcementTuningThinkingLevel(
            "REINFORCEMENT_TUNING_THINKING_LEVEL_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new ReinforcementTuningThinkingLevel(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator ReinforcementTuningThinkingLevel(string value) =>
        FromString(value);

    public bool Equals(ReinforcementTuningThinkingLevel other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class ReinforcementTuningThinkingLevelConverter
      : JsonConverter<ReinforcementTuningThinkingLevel> {
    public override ReinforcementTuningThinkingLevel Read(ref Utf8JsonReader reader,
                                                          System.Type typeToConvert,
                                                          JsonSerializerOptions options) {
      var value = reader.GetString();
      return ReinforcementTuningThinkingLevel.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, ReinforcementTuningThinkingLevel value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
