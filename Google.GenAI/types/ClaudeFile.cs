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
  /// A file that can be referenced by ID from subsequent Claude model requests. The JSON
  /// representation of this message matches the Claude Files API File object field-for-field, so
  /// that code written against that API parses these responses unchanged. This data type is not
  /// supported in Gemini API.
  /// </summary>

  public record ClaudeFile {
    /// <summary>
    /// Output only. The time at which the file was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime ? CreatedAt { get; set; }

    /// <summary>
    /// Output only. Whether the contents of this file can be retrieved with `DownloadFile`. False
    /// for user-uploaded files, true for tool-generated ones.
    /// </summary>
    [JsonPropertyName("downloadable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? Downloadable {
            get; set;
          }

    /// <summary>
    /// Output only. The time at which the file expires and is deleted, set from the
    /// `expires_in_seconds` upload form field. Unset for files that do not expire, which is
    /// serialised as `null`.
    /// </summary>
    [JsonPropertyName("expiresAt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime
        ? ExpiresAt {
            get; set;
          }

    /// <summary>
    /// Output only. The original name of the uploaded file, taken from the `Content-Disposition`
    /// header on upload. Between 1 and 255 characters. Control characters and the characters
    /// `&lt;&gt;:"|?*\/` are not accepted.
    /// </summary>
    [JsonPropertyName("filename")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Filename {
            get; set;
          }

    /// <summary>
    /// Output only. The server-assigned identifier of the file, for example `file_abc123`. This is
    /// the ID to pass in subsequent model requests.
    /// </summary>
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Id {
            get; set;
          }

    /// <summary>
    /// Output only. The media type of the file, taken from the `Content-Type` header of the file
    /// part on upload.
    /// </summary>
    [JsonPropertyName("mimeType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? MimeType {
            get; set;
          }

    /// <summary>
    /// Output only. The size of the file in bytes.
    /// </summary>
    [JsonPropertyName("sizeBytes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? SizeBytes {
            get; set;
          }

    /// <summary>
    /// Output only. The object type. Always `file`.
    /// </summary>
    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Type {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ClaudeFile object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ClaudeFile object, or null if deserialization fails.</returns>
    public static ClaudeFile ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize(jsonString, JsonConfig.TypeInfo<ClaudeFile>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
