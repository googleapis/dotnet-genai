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

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Serialization;

namespace Google.GenAI.Types {
  /// <summary>
  /// Metadata describes the input spreadsheet content.  Set this in `Part.spreadsheet_metadata` or
  /// `FunctionResponsePart.spreadsheet_metadata` when `inline_data` or `file_data` contains a
  /// spreadsheet to configure static spreadsheet preprocessing.
  /// </summary>

  public record SpreadsheetMetadata {
    /// <summary>
    /// The range of cells to extract, in A1 notation (e.g. "A1:D10"). If not set, the full occupied
    /// area of the sheet is used.
    /// </summary>
    [JsonPropertyName("visibleCells")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? VisibleCells { get; set; }

    /// <summary>
    /// The 1-indexed index of the sheet to extract, in workbook order. If not set, the first sheet
    /// is used.
    /// </summary>
    [JsonPropertyName("sheetIndex")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? SheetIndex {
            get; set;
          }

    /// <summary>
    /// Content layers to return. If empty, defaults to [DATA, FORMULAS] when SpreadsheetMetadata is
    /// set.
    /// </summary>
    [JsonPropertyName("contentLayers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<SpreadsheetMetadataContentLayer>
        ? ContentLayers {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a SpreadsheetMetadata object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized SpreadsheetMetadata object, or null if deserialization
    /// fails.</returns>
    public static SpreadsheetMetadata
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize(jsonString,
                                          JsonConfig.TypeInfo<SpreadsheetMetadata>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
