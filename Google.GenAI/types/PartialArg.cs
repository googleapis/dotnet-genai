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
  /// Partial argument value of the function call. This data type is not supported in Gemini API.
  /// </summary>

  public record PartialArg {
    /// <summary>
    /// Optional. Represents a boolean value.
    /// </summary>
    [JsonPropertyName("boolValue")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool ? BoolValue { get; set; }

    /// <summary>
    /// A JSON Path (RFC 9535) to the argument being streamed.
    /// https://datatracker.ietf.org/doc/html/rfc9535. e.g. "$.foo.bar[0].data".
    /// </summary>
    [JsonPropertyName("jsonPath")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? JsonPath {
            get; set;
          }

    /// <summary>
    /// Optional. Represents a null value.
    /// </summary>
    [JsonPropertyName("nullValue")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? NullValue {
            get; set;
          }

    /// <summary>
    /// Optional. Represents a double value.
    /// </summary>
    [JsonPropertyName("numberValue")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? NumberValue {
            get; set;
          }

    /// <summary>
    /// Optional. Represents a string value.
    /// </summary>
    [JsonPropertyName("stringValue")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? StringValue {
            get; set;
          }

    /// <summary>
    /// Optional. Whether this is not the last part of the same json_path. If true, another
    /// PartialArg message for the current json_path is expected to follow.
    /// </summary>
    [JsonPropertyName("willContinue")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? WillContinue {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a PartialArg object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized PartialArg object, or null if deserialization fails.</returns>
    public static PartialArg ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<PartialArg>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
