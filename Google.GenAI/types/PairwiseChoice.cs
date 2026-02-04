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
  /// Output only. Pairwise metric choice. This enum is not supported in Gemini API.
  /// </summary>

  [JsonConverter(typeof(PairwiseChoiceConverter))]
  public readonly record struct PairwiseChoice : IEquatable<PairwiseChoice> {
    public string Value { get; }

    private PairwiseChoice(string value) {
      Value = value;
    }

    /// <summary>
    /// Unspecified prediction choice.
    /// </summary>
    public static PairwiseChoice PairwiseChoiceUnspecified {
      get;
    } = new("PAIRWISE_CHOICE_UNSPECIFIED");

    /// <summary>
    /// Baseline prediction wins
    /// </summary>
    public static PairwiseChoice Baseline { get; } = new("BASELINE");

    /// <summary>
    /// Candidate prediction wins
    /// </summary>
    public static PairwiseChoice Candidate { get; } = new("CANDIDATE");

    /// <summary>
    /// Winner cannot be determined
    /// </summary>
    public static PairwiseChoice Tie { get; } = new("TIE");

    public static IReadOnlyList<PairwiseChoice> AllValues {
      get;
    } = new[] { PairwiseChoiceUnspecified, Baseline, Candidate, Tie };

    public static PairwiseChoice FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new PairwiseChoice("PAIRWISE_CHOICE_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new PairwiseChoice(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator PairwiseChoice(string value) => FromString(value);

    public bool Equals(PairwiseChoice other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class PairwiseChoiceConverter : JsonConverter<PairwiseChoice> {
    public override PairwiseChoice Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                        JsonSerializerOptions options) {
      var value = reader.GetString();
      return PairwiseChoice.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, PairwiseChoice value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
