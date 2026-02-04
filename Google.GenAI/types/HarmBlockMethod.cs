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
  /// The method for blocking content. If not specified, the default behavior is to use the
  /// probability score. This enum is not supported in Gemini API.
  /// </summary>

  [JsonConverter(typeof(HarmBlockMethodConverter))]
  public readonly record struct HarmBlockMethod : IEquatable<HarmBlockMethod> {
    public string Value { get; }

    private HarmBlockMethod(string value) {
      Value = value;
    }

    /// <summary>
    /// The harm block method is unspecified.
    /// </summary>
    public static HarmBlockMethod HarmBlockMethodUnspecified {
      get;
    } = new("HARM_BLOCK_METHOD_UNSPECIFIED");

    /// <summary>
    /// The harm block method uses both probability and severity scores.
    /// </summary>
    public static HarmBlockMethod Severity { get; } = new("SEVERITY");

    /// <summary>
    /// The harm block method uses the probability score.
    /// </summary>
    public static HarmBlockMethod Probability { get; } = new("PROBABILITY");

    public static IReadOnlyList<HarmBlockMethod> AllValues {
      get;
    } = new[] { HarmBlockMethodUnspecified, Severity, Probability };

    public static HarmBlockMethod FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new HarmBlockMethod("HARM_BLOCK_METHOD_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new HarmBlockMethod(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator HarmBlockMethod(string value) => FromString(value);

    public bool Equals(HarmBlockMethod other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class HarmBlockMethodConverter : JsonConverter<HarmBlockMethod> {
    public override HarmBlockMethod Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                         JsonSerializerOptions options) {
      var value = reader.GetString();
      return HarmBlockMethod.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, HarmBlockMethod value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
