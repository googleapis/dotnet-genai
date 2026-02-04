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
  /// The status of the URL retrieval.
  /// </summary>

  [JsonConverter(typeof(UrlRetrievalStatusConverter))]
  public readonly record struct UrlRetrievalStatus : IEquatable<UrlRetrievalStatus> {
    public string Value { get; }

    private UrlRetrievalStatus(string value) {
      Value = value;
    }

    /// <summary>
    /// Default value. This value is unused.
    /// </summary>
    public static UrlRetrievalStatus UrlRetrievalStatusUnspecified {
      get;
    } = new("URL_RETRIEVAL_STATUS_UNSPECIFIED");

    /// <summary>
    /// The URL was retrieved successfully.
    /// </summary>
    public static UrlRetrievalStatus UrlRetrievalStatusSuccess {
      get;
    } = new("URL_RETRIEVAL_STATUS_SUCCESS");

    /// <summary>
    /// The URL retrieval failed.
    /// </summary>
    public static UrlRetrievalStatus UrlRetrievalStatusError {
      get;
    } = new("URL_RETRIEVAL_STATUS_ERROR");

    /// <summary>
    /// Url retrieval is failed because the content is behind paywall. This enum value is not
    /// supported in Vertex AI.
    /// </summary>
    public static UrlRetrievalStatus UrlRetrievalStatusPaywall {
      get;
    } = new("URL_RETRIEVAL_STATUS_PAYWALL");

    /// <summary>
    /// Url retrieval is failed because the content is unsafe. This enum value is not supported in
    /// Vertex AI.
    /// </summary>
    public static UrlRetrievalStatus UrlRetrievalStatusUnsafe {
      get;
    } = new("URL_RETRIEVAL_STATUS_UNSAFE");

    public static IReadOnlyList<UrlRetrievalStatus> AllValues {
      get;
    } = new[] { UrlRetrievalStatusUnspecified, UrlRetrievalStatusSuccess, UrlRetrievalStatusError,
                UrlRetrievalStatusPaywall, UrlRetrievalStatusUnsafe };

    public static UrlRetrievalStatus FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new UrlRetrievalStatus("URL_RETRIEVAL_STATUS_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new UrlRetrievalStatus(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator UrlRetrievalStatus(string value) => FromString(value);

    public bool Equals(UrlRetrievalStatus other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class UrlRetrievalStatusConverter : JsonConverter<UrlRetrievalStatus> {
    public override UrlRetrievalStatus Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                            JsonSerializerOptions options) {
      var value = reader.GetString();
      return UrlRetrievalStatus.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, UrlRetrievalStatus value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
