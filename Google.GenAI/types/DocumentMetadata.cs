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
  /// Metadata describes the input document content.  Set this in `Part.document_metadata` or
  /// `FunctionResponsePart.document_metadata` when `inline_data` or `file_data` contains a document
  /// to configure static document preprocessing.
  /// </summary>

  public record DocumentMetadata {
    /// <summary>
    /// 1-indexed inclusive start page.
    /// </summary>
    [JsonPropertyName("startPage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int ? StartPage { get; set; }

    /// <summary>
    /// 1-indexed inclusive end page.
    /// </summary>
    [JsonPropertyName("endPage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? EndPage {
            get; set;
          }

    /// <summary>
    /// Content layers to return. If empty, defaults to [PAGE_IMAGE] when DocumentMetadata is set.
    /// When DocumentMetadata is not set, default document processing is used (for example, page
    /// images for PDFs).
    /// </summary>
    [JsonPropertyName("contentLayers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<DocumentMetadataContentLayer>
        ? ContentLayers {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a DocumentMetadata object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized DocumentMetadata object, or null if deserialization
    /// fails.</returns>
    public static DocumentMetadata
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize(jsonString,
                                          JsonConfig.TypeInfo<DocumentMetadata>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
