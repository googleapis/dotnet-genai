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
  /// Raw media bytes for function response. Text should not be sent as raw bytes, use the 'text'
  /// field.
  /// </summary>

  public record FunctionResponseBlob {
    /// <summary>
    /// The IANA standard MIME type of the source data.
    /// </summary>
    [JsonPropertyName("mimeType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? MimeType { get; set; }

    /// <summary>
    /// Raw bytes.
    /// </summary>
    [JsonPropertyName("data")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public byte[]
        ? Data {
            get; set;
          }

    /// <summary>
    /// Optional. Display name of the blob. Used to provide a label or filename to distinguish
    /// blobs. This field is only returned in PromptMessage for prompt management. It is currently
    /// used in the Gemini GenerateContent calls only when server side tools (code_execution,
    /// google_search, and url_context) are enabled. This field is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("displayName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? DisplayName {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a FunctionResponseBlob object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized FunctionResponseBlob object, or null if deserialization
    /// fails.</returns>
    public static FunctionResponseBlob
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<FunctionResponseBlob>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
