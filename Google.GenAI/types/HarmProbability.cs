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
  /// Output only. The probability of harm for this category.
  /// </summary>

  [JsonConverter(typeof(HarmProbabilityConverter))]
  public readonly record struct HarmProbability : IEquatable<HarmProbability> {
    public string Value { get; }

    private HarmProbability(string value) {
      Value = value;
    }

    /// <summary>
    /// The harm probability is unspecified.
    /// </summary>
    public static HarmProbability HarmProbabilityUnspecified {
      get;
    } = new("HARM_PROBABILITY_UNSPECIFIED");

    /// <summary>
    /// The harm probability is negligible.
    /// </summary>
    public static HarmProbability Negligible { get; } = new("NEGLIGIBLE");

    /// <summary>
    /// The harm probability is low.
    /// </summary>
    public static HarmProbability Low { get; } = new("LOW");

    /// <summary>
    /// The harm probability is medium.
    /// </summary>
    public static HarmProbability Medium { get; } = new("MEDIUM");

    /// <summary>
    /// The harm probability is high.
    /// </summary>
    public static HarmProbability High { get; } = new("HIGH");

    public static IReadOnlyList<HarmProbability> AllValues {
      get;
    } = new[] { HarmProbabilityUnspecified, Negligible, Low, Medium, High };

    public static HarmProbability FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new HarmProbability("HARM_PROBABILITY_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new HarmProbability(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator HarmProbability(string value) => FromString(value);

    public bool Equals(HarmProbability other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class HarmProbabilityConverter : JsonConverter<HarmProbability> {
    public override HarmProbability Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                         JsonSerializerOptions options) {
      var value = reader.GetString();
      return HarmProbability.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, HarmProbability value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
