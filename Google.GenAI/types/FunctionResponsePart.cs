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
  /// A datatype containing media that is part of a `FunctionResponse` message. A
  /// `FunctionResponsePart` consists of data which has an associated datatype. A
  /// `FunctionResponsePart` can only contain one of the accepted types in
  /// `FunctionResponsePart.data`. A `FunctionResponsePart` must have a fixed IANA MIME type
  /// identifying the type and subtype of the media if the `inline_data` field is filled with raw
  /// bytes.
  /// </summary>

  public record FunctionResponsePart {
    /// <summary>
    /// Inline media bytes.
    /// </summary>
    [JsonPropertyName("inlineData")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public FunctionResponseBlob ? InlineData { get; set; }

    /// <summary>
    /// URI based data. This field is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("fileData")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public FunctionResponseFileData
        ? FileData {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a FunctionResponsePart object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized FunctionResponsePart object, or null if deserialization
    /// fails.</returns>
    public static FunctionResponsePart
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<FunctionResponsePart>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
