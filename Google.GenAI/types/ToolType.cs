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
  /// The type of tool in the function call.
  /// </summary>

  [JsonConverter(typeof(ToolTypeConverter))]
  public readonly record struct ToolType : IEquatable<ToolType> {
    public string Value { get; }

    private ToolType(string value) {
      Value = value;
    }

    /// <summary>
    /// Unspecified tool type.
    /// </summary>
    public static ToolType ToolTypeUnspecified { get; } = new("TOOL_TYPE_UNSPECIFIED");

    /// <summary>
    /// Google search tool, maps to Tool.google_search.search_types.web_search.
    /// </summary>
    public static ToolType GoogleSearchWeb { get; } = new("GOOGLE_SEARCH_WEB");

    /// <summary>
    /// Image search tool, maps to Tool.google_search.search_types.image_search.
    /// </summary>
    public static ToolType GoogleSearchImage { get; } = new("GOOGLE_SEARCH_IMAGE");

    /// <summary>
    /// URL context tool, maps to Tool.url_context.
    /// </summary>
    public static ToolType UrlContext { get; } = new("URL_CONTEXT");

    /// <summary>
    /// Google maps tool, maps to Tool.google_maps.
    /// </summary>
    public static ToolType GoogleMaps { get; } = new("GOOGLE_MAPS");

    /// <summary>
    /// File search tool, maps to Tool.file_search.
    /// </summary>
    public static ToolType FileSearch { get; } = new("FILE_SEARCH");

    /// <summary>
    /// Media processing tool.
    /// </summary>
    public static ToolType MediaProcessing { get; } = new("MEDIA_PROCESSING");

    public static IReadOnlyList<ToolType> AllValues {
      get;
    } = new[] { ToolTypeUnspecified, GoogleSearchWeb, GoogleSearchImage, UrlContext,
                GoogleMaps,          FileSearch,      MediaProcessing };

    public static ToolType FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new ToolType("TOOL_TYPE_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new ToolType(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator ToolType(string value) => FromString(value);

    public bool Equals(ToolType other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class ToolTypeConverter : JsonConverter<ToolType> {
    public override ToolType Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                  JsonSerializerOptions options) {
      var value = reader.GetString();
      return ToolType.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, ToolType value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
