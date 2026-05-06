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
  /// Enum representing the Gemini Enterprise Agent Platform embedding API to use.
  /// </summary>

  [JsonConverter(typeof(EmbeddingApiTypeConverter))]
  public readonly record struct EmbeddingApiType : IEquatable<EmbeddingApiType> {
    public string Value { get; }

    private EmbeddingApiType(string value) {
      Value = value;
    }

    /// <summary>
    /// predict API endpoint (default)
    /// </summary>
    public static EmbeddingApiType Predict { get; } = new("PREDICT");

    /// <summary>
    /// embedContent API Endpoint
    /// </summary>
    public static EmbeddingApiType EmbedContent { get; } = new("EMBED_CONTENT");

    public static IReadOnlyList<EmbeddingApiType> AllValues {
      get;
    } = new[] { Predict, EmbedContent };

    public static EmbeddingApiType FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new EmbeddingApiType("UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new EmbeddingApiType(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator EmbeddingApiType(string value) => FromString(value);

    public bool Equals(EmbeddingApiType other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class EmbeddingApiTypeConverter : JsonConverter<EmbeddingApiType> {
    public override EmbeddingApiType Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                          JsonSerializerOptions options) {
      var value = reader.GetString();
      return EmbeddingApiType.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, EmbeddingApiType value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
