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
  /// The threshold for blocking content. If the harm probability exceeds this threshold, the
  /// content will be blocked.
  /// </summary>

  [JsonConverter(typeof(HarmBlockThresholdConverter))]
  public readonly record struct HarmBlockThreshold : IEquatable<HarmBlockThreshold> {
    public string Value { get; }

    private HarmBlockThreshold(string value) {
      Value = value;
    }

    /// <summary>
    /// The harm block threshold is unspecified.
    /// </summary>
    public static HarmBlockThreshold HarmBlockThresholdUnspecified {
      get;
    } = new("HARM_BLOCK_THRESHOLD_UNSPECIFIED");

    /// <summary>
    /// Block content with a low harm probability or higher.
    /// </summary>
    public static HarmBlockThreshold BlockLowAndAbove { get; } = new("BLOCK_LOW_AND_ABOVE");

    /// <summary>
    /// Block content with a medium harm probability or higher.
    /// </summary>
    public static HarmBlockThreshold BlockMediumAndAbove { get; } = new("BLOCK_MEDIUM_AND_ABOVE");

    /// <summary>
    /// Block content with a high harm probability.
    /// </summary>
    public static HarmBlockThreshold BlockOnlyHigh { get; } = new("BLOCK_ONLY_HIGH");

    /// <summary>
    /// Do not block any content, regardless of its harm probability.
    /// </summary>
    public static HarmBlockThreshold BlockNone { get; } = new("BLOCK_NONE");

    /// <summary>
    /// Turn off the safety filter entirely.
    /// </summary>
    public static HarmBlockThreshold Off { get; } = new("OFF");

    public static IReadOnlyList<HarmBlockThreshold> AllValues {
      get;
    } = new[] { HarmBlockThresholdUnspecified,
                BlockLowAndAbove,
                BlockMediumAndAbove,
                BlockOnlyHigh,
                BlockNone,
                Off };

    public static HarmBlockThreshold FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new HarmBlockThreshold("HARM_BLOCK_THRESHOLD_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new HarmBlockThreshold(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator HarmBlockThreshold(string value) => FromString(value);

    public bool Equals(HarmBlockThreshold other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class HarmBlockThresholdConverter : JsonConverter<HarmBlockThreshold> {
    public override HarmBlockThreshold Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                            JsonSerializerOptions options) {
      var value = reader.GetString();
      return HarmBlockThreshold.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, HarmBlockThreshold value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
