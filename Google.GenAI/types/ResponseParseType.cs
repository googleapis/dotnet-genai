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
  /// Defines how to parse sample response.
  /// </summary>

  [JsonConverter(typeof(ResponseParseTypeConverter))]
  public readonly record struct ResponseParseType : IEquatable<ResponseParseType> {
    public string Value { get; }

    private ResponseParseType(string value) {
      Value = value;
    }

    /// <summary>
    /// Default value. This value is unused.
    /// </summary>
    public static ResponseParseType ResponseParseTypeUnspecified {
      get;
    } = new("RESPONSE_PARSE_TYPE_UNSPECIFIED");

    /// <summary>
    /// Use the sample response as is.
    /// </summary>
    public static ResponseParseType Identity { get; } = new("IDENTITY");

    /// <summary>
    /// Use regex to extract the important part of sample response.
    /// </summary>
    public static ResponseParseType RegexExtract { get; } = new("REGEX_EXTRACT");

    public static IReadOnlyList<ResponseParseType> AllValues {
      get;
    } = new[] { ResponseParseTypeUnspecified, Identity, RegexExtract };

    public static ResponseParseType FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new ResponseParseType("RESPONSE_PARSE_TYPE_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new ResponseParseType(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator ResponseParseType(string value) => FromString(value);

    public bool Equals(ResponseParseType other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class ResponseParseTypeConverter : JsonConverter<ResponseParseType> {
    public override ResponseParseType Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                           JsonSerializerOptions options) {
      var value = reader.GetString();
      return ResponseParseType.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, ResponseParseType value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
