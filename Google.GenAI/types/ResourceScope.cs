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
  /// Resource scope.
  /// </summary>

  [JsonConverter(typeof(ResourceScopeConverter))]
  public readonly record struct ResourceScope : IEquatable<ResourceScope> {
    public string Value { get; }

    private ResourceScope(string value) {
      Value = value;
    }

    /// <summary>
    /// When setting base_url, this value configures resource scope to be the collection. The
    /// resource name will not include api version, project, or location. For example, if base_url
    /// is set to "https://aiplatform.googleapis.com", then the resource name for a Model would be
    /// "https://aiplatform.googleapis.com/publishers/google/models/gemini-3-pro-preview
    /// </summary>
    public static ResourceScope Collection { get; } = new("COLLECTION");

    public static IReadOnlyList<ResourceScope> AllValues { get; } = new[] { Collection };

    public static ResourceScope FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new ResourceScope("UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new ResourceScope(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator ResourceScope(string value) => FromString(value);

    public bool Equals(ResourceScope other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class ResourceScopeConverter : JsonConverter<ResourceScope> {
    public override ResourceScope Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                       JsonSerializerOptions options) {
      var value = reader.GetString();
      return ResourceScope.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, ResourceScope value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
