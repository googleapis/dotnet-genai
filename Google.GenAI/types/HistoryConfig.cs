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
  /// Configuration for history exchange between client and server.
  /// </summary>

  public record HistoryConfig {
    /// <summary>
    /// If true, after sending `setup_complete`, the server will wait and at first process
    /// `client_content` messages until `turn_complete` is `true`. This initial history will not
    /// trigger a model call and may end with role `MODEL`. After `turn_complete` is `true`, the
    /// client can start the realtime conversation via `realtime_input`.
    /// </summary>
    [JsonPropertyName("initialHistoryInClientContent")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool ? InitialHistoryInClientContent { get; set; }

    /// <summary>
    /// Deserializes a JSON string to a HistoryConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized HistoryConfig object, or null if deserialization fails.</returns>
    public static HistoryConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<HistoryConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
