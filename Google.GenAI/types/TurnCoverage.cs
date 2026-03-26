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
  /// Options about which input is included in the user's turn.
  /// </summary>

  [JsonConverter(typeof(TurnCoverageConverter))]
  public readonly record struct TurnCoverage : IEquatable<TurnCoverage> {
    public string Value { get; }

    private TurnCoverage(string value) {
      Value = value;
    }

    /// <summary>
    /// If unspecified, the default behavior is `TURN_INCLUDES_ONLY_ACTIVITY`.
    /// </summary>
    public static TurnCoverage TurnCoverageUnspecified { get; } = new("TURN_COVERAGE_UNSPECIFIED");

    /// <summary>
    /// The users turn only includes activity since the last turn, excluding inactivity (e.g.
    /// silence on the audio stream). This is the default behavior.
    /// </summary>
    public static TurnCoverage TurnIncludesOnlyActivity {
      get;
    } = new("TURN_INCLUDES_ONLY_ACTIVITY");

    /// <summary>
    /// The users turn includes all realtime input since the last turn, including inactivity (e.g.
    /// silence on the audio stream).
    /// </summary>
    public static TurnCoverage TurnIncludesAllInput { get; } = new("TURN_INCLUDES_ALL_INPUT");

    /// <summary>
    /// Includes audio activity and all video since the last turn. With automatic activity
    /// detection, audio activity means speech and excludes silence.
    /// </summary>
    public static TurnCoverage TurnIncludesAudioActivityAndAllVideo {
      get;
    } = new("TURN_INCLUDES_AUDIO_ACTIVITY_AND_ALL_VIDEO");

    public static IReadOnlyList<TurnCoverage> AllValues {
      get;
    } = new[] { TurnCoverageUnspecified, TurnIncludesOnlyActivity, TurnIncludesAllInput,
                TurnIncludesAudioActivityAndAllVideo };

    public static TurnCoverage FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new TurnCoverage("TURN_COVERAGE_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new TurnCoverage(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator TurnCoverage(string value) => FromString(value);

    public bool Equals(TurnCoverage other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class TurnCoverageConverter : JsonConverter<TurnCoverage> {
    public override TurnCoverage Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                      JsonSerializerOptions options) {
      var value = reader.GetString();
      return TurnCoverage.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, TurnCoverage value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
