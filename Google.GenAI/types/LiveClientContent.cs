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
  /// Incremental update of the current conversation delivered from the client.    All the content
  /// here will unconditionally be appended to the conversation   history and used as part of the
  /// prompt to the model to generate content.    A message here will interrupt any current model
  /// generation.
  /// </summary>

  public record LiveClientContent {
    /// <summary>
    /// The content appended to the current conversation with the model.        For single-turn
    /// queries, this is a single instance. For multi-turn       queries, this is a repeated field
    /// that contains conversation history and       latest request.
    /// </summary>
    [JsonPropertyName("turns")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Content> ? Turns { get; set; }

    /// <summary>
    /// If true, indicates that the server content generation should start with   the currently
    /// accumulated prompt. Otherwise, the server will await   additional messages before starting
    /// generation.
    /// </summary>
    [JsonPropertyName("turnComplete")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? TurnComplete {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a LiveClientContent object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized LiveClientContent object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static LiveClientContent
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<LiveClientContent>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
