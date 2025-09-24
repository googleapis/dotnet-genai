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

namespace Google.GenAI.Types {
  /// <summary>
  /// Options about which input is included in the user's turn.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<TurnCoverage>))]
  public enum TurnCoverage {
    /// <summary>
    /// If unspecified, the default behavior is `TURN_INCLUDES_ONLY_ACTIVITY`.
    /// </summary>
    [JsonPropertyName("TURN_COVERAGE_UNSPECIFIED")] TURN_COVERAGE_UNSPECIFIED,

    /// <summary>
    /// The users turn only includes activity since the last turn, excluding inactivity (e.g.
    /// silence on the audio stream). This is the default behavior.
    /// </summary>
    [JsonPropertyName("TURN_INCLUDES_ONLY_ACTIVITY")] TURN_INCLUDES_ONLY_ACTIVITY,

    /// <summary>
    /// The users turn includes all realtime input since the last turn, including inactivity (e.g.
    /// silence on the audio stream).
    /// </summary>
    [JsonPropertyName("TURN_INCLUDES_ALL_INPUT")] TURN_INCLUDES_ALL_INPUT
  }
}
