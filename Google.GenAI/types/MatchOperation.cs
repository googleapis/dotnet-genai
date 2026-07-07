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
  /// Match operation to use for evaluation.
  /// </summary>

  [JsonConverter(typeof(MatchOperationConverter))]
  public readonly record struct MatchOperation : IEquatable<MatchOperation> {
    public string Value { get; }

    private MatchOperation(string value) {
      Value = value;
    }

    /// <summary>
    /// Default value. This value is unused.
    /// </summary>
    public static MatchOperation MatchOperationUnspecified {
      get;
    } = new("MATCH_OPERATION_UNSPECIFIED");

    /// <summary>
    /// Equivalent to GoogleSQL `REGEX_CONTAINS(target, expression)`.
    /// </summary>
    public static MatchOperation RegexContains { get; } = new("REGEX_CONTAINS");

    /// <summary>
    /// `expression` is a substring of target.
    /// </summary>
    public static MatchOperation PartialMatch { get; } = new("PARTIAL_MATCH");

    /// <summary>
    /// `expression` is an exact match of target.
    /// </summary>
    public static MatchOperation ExactMatch { get; } = new("EXACT_MATCH");

    public static IReadOnlyList<MatchOperation> AllValues {
      get;
    } = new[] { MatchOperationUnspecified, RegexContains, PartialMatch, ExactMatch };

    public static MatchOperation FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new MatchOperation("MATCH_OPERATION_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new MatchOperation(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator MatchOperation(string value) => FromString(value);

    public bool Equals(MatchOperation other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class MatchOperationConverter : JsonConverter<MatchOperation> {
    public override MatchOperation Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                        JsonSerializerOptions options) {
      var value = reader.GetString();
      return MatchOperation.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, MatchOperation value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
