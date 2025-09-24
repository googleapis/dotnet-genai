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
  /// A function response.
  /// </summary>

  public record FunctionResponse {
    /// <summary>
    /// Signals that function call continues, and more responses will be returned, turning the
    /// function call into a generator. Is only applicable to NON_BLOCKING function calls (see
    /// FunctionDeclaration.behavior for details), ignored otherwise. If false, the default, future
    /// responses will not be considered. Is only applicable to NON_BLOCKING function calls, is
    /// ignored otherwise. If set to false, future responses will not be considered. It is allowed
    /// to return empty `response` with `will_continue=False` to signal that the function call is
    /// finished.
    /// </summary>
    [JsonPropertyName("willContinue")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool ? WillContinue { get; set; }

    /// <summary>
    /// Specifies how the response should be scheduled in the conversation. Only applicable to
    /// NON_BLOCKING function calls, is ignored otherwise. Defaults to WHEN_IDLE.
    /// </summary>
    [JsonPropertyName("scheduling")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public FunctionResponseScheduling
        ? Scheduling {
            get; set;
          }

    /// <summary>
    /// Optional. The id of the function call this response is for. Populated by the client to match
    /// the corresponding function call `id`.
    /// </summary>
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Id {
            get; set;
          }

    /// <summary>
    /// The name of the function to call. Matches [FunctionDeclaration.name] and
    /// [FunctionCall.name].
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Name {
            get; set;
          }

    /// <summary>
    /// The function response in JSON object format. Use "output" key to specify function output and
    /// "error" key to specify error details (if any). If "output" and "error" keys are not
    /// specified, then whole "response" is treated as function output.
    /// </summary>
    [JsonPropertyName("response")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, object>
        ? Response {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a FunctionResponse object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized FunctionResponse object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static FunctionResponse
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<FunctionResponse>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
