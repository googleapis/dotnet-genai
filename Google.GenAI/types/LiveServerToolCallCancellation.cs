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
  /// Notification for the client that a previously issued `ToolCallMessage` with the specified
  /// `id`s should have been not executed and should be cancelled.    If there were side-effects to
  /// those tool calls, clients may attempt to undo   the tool calls. This message occurs only in
  /// cases where the clients interrupt   server turns.
  /// </summary>

  public record LiveServerToolCallCancellation {
    /// <summary>
    /// The ids of the tool calls to be cancelled.
    /// </summary>
    [JsonPropertyName("ids")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string> ? Ids { get; set; }

    /// <summary>
    /// Deserializes a JSON string to a LiveServerToolCallCancellation object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized LiveServerToolCallCancellation object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static LiveServerToolCallCancellation
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<LiveServerToolCallCancellation>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
