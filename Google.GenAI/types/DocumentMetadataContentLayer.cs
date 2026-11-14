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
  /// Content layers to extract from a document.
  /// </summary>

  [JsonConverter(typeof(DocumentMetadataContentLayerConverter))]
  public readonly record struct DocumentMetadataContentLayer
      : IEquatable<DocumentMetadataContentLayer> {
    public string Value { get; }

    private DocumentMetadataContentLayer(string value) {
      Value = value;
    }

    /// <summary>
    /// Default value.
    /// </summary>
    public static DocumentMetadataContentLayer ContentLayerUnspecified {
      get;
    } = new("CONTENT_LAYER_UNSPECIFIED");

    /// <summary>
    /// Rendered page images.
    /// </summary>
    public static DocumentMetadataContentLayer PageImage { get; } = new("PAGE_IMAGE");

    /// <summary>
    /// Extracted page text.
    /// </summary>
    public static DocumentMetadataContentLayer PageText { get; } = new("PAGE_TEXT");

    public static IReadOnlyList<DocumentMetadataContentLayer> AllValues {
      get;
    } = new[] { ContentLayerUnspecified, PageImage, PageText };

    public static DocumentMetadataContentLayer FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new DocumentMetadataContentLayer("CONTENT_LAYER_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new DocumentMetadataContentLayer(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator DocumentMetadataContentLayer(string value) => FromString(value);

    public bool Equals(DocumentMetadataContentLayer other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class DocumentMetadataContentLayerConverter : JsonConverter<DocumentMetadataContentLayer> {
    public override DocumentMetadataContentLayer Read(ref Utf8JsonReader reader,
                                                      System.Type typeToConvert,
                                                      JsonSerializerOptions options) {
      var value = reader.GetString();
      return DocumentMetadataContentLayer.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, DocumentMetadataContentLayer value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
