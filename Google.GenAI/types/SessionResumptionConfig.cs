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
  /// Configuration of session resumption mechanism.    Included in
  /// `LiveConnectConfig.session_resumption`. If included server   will send
  /// `LiveServerSessionResumptionUpdate` messages.
  /// </summary>

  public record SessionResumptionConfig {
    /// <summary>
    /// Session resumption handle of previous session (session to restore).  If not present new
    /// session will be started.
    /// </summary>
    [JsonPropertyName("handle")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? Handle { get; set; }

    /// <summary>
    /// If set the server will send `last_consumed_client_message_index` in the
    /// `session_resumption_update` messages to allow for transparent reconnections.
    /// </summary>
    [JsonPropertyName("transparent")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? Transparent {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a SessionResumptionConfig object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized SessionResumptionConfig object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static SessionResumptionConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<SessionResumptionConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
