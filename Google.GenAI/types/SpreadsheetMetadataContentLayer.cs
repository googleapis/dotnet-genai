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
  /// Content layers to extract from a spreadsheet.
  /// </summary>

  [JsonConverter(typeof(SpreadsheetMetadataContentLayerConverter))]
  public readonly record struct SpreadsheetMetadataContentLayer
      : IEquatable<SpreadsheetMetadataContentLayer> {
    public string Value { get; }

    private SpreadsheetMetadataContentLayer(string value) {
      Value = value;
    }

    /// <summary>
    /// Default value.
    /// </summary>
    public static SpreadsheetMetadataContentLayer ContentLayerUnspecified {
      get;
    } = new("CONTENT_LAYER_UNSPECIFIED");

    /// <summary>
    /// Cell values, merges, and formats.
    /// </summary>
    public static SpreadsheetMetadataContentLayer Data { get; } = new("DATA");

    /// <summary>
    /// Formula expressions and their computed results.
    /// </summary>
    public static SpreadsheetMetadataContentLayer Formulas { get; } = new("FORMULAS");

    /// <summary>
    /// A rendered image of the sheet.
    /// </summary>
    public static SpreadsheetMetadataContentLayer Visual { get; } = new("VISUAL");

    public static IReadOnlyList<SpreadsheetMetadataContentLayer> AllValues {
      get;
    } = new[] { ContentLayerUnspecified, Data, Formulas, Visual };

    public static SpreadsheetMetadataContentLayer FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new SpreadsheetMetadataContentLayer("CONTENT_LAYER_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new SpreadsheetMetadataContentLayer(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator SpreadsheetMetadataContentLayer(string value) =>
        FromString(value);

    public bool Equals(SpreadsheetMetadataContentLayer other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class SpreadsheetMetadataContentLayerConverter
      : JsonConverter<SpreadsheetMetadataContentLayer> {
    public override SpreadsheetMetadataContentLayer Read(ref Utf8JsonReader reader,
                                                         System.Type typeToConvert,
                                                         JsonSerializerOptions options) {
      var value = reader.GetString();
      return SpreadsheetMetadataContentLayer.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, SpreadsheetMetadataContentLayer value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
