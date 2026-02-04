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
  /// URI-based data. A FileData message contains a URI pointing to data of a specific media type.
  /// It is used to represent images, audio, and video stored in Google Cloud Storage.
  /// </summary>

  public record FileData {
    /// <summary>
    /// Optional. The display name of the file. Used to provide a label or filename to distinguish
    /// files. This field is only returned in `PromptMessage` for prompt management. It is used in
    /// the Gemini calls only when server side tools (`code_execution`, `google_search`, and
    /// `url_context`) are enabled. This field is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("displayName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? DisplayName { get; set; }

    /// <summary>
    /// The URI of the file in Google Cloud Storage.
    /// </summary>
    [JsonPropertyName("fileUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? FileUri {
            get; set;
          }

    /// <summary>
    /// The IANA standard MIME type of the source data.
    /// </summary>
    [JsonPropertyName("mimeType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? MimeType {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a FileData object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized FileData object, or null if deserialization fails.</returns>
    public static FileData ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<FileData>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
