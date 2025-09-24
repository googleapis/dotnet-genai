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
  /// Messages sent by the client in the API call.
  /// </summary>

  public record LiveClientMessage {
    /// <summary>
    /// Message to be sent by the system when connecting to the API. SDK users should not send this
    /// message.
    /// </summary>
    [JsonPropertyName("setup")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LiveClientSetup ? Setup { get; set; }

    /// <summary>
    /// Incremental update of the current conversation delivered from the client.
    /// </summary>
    [JsonPropertyName("clientContent")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LiveClientContent
        ? ClientContent {
            get; set;
          }

    /// <summary>
    /// User input that is sent in real time.
    /// </summary>
    [JsonPropertyName("realtimeInput")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LiveClientRealtimeInput
        ? RealtimeInput {
            get; set;
          }

    /// <summary>
    /// This is an alias for `realtime_input` field. Allows the inputs to sendRealtimeInput to be
    /// transformed into `realtime_input` before being sent. Note: This will overwrite any
    /// `realtime_input` field.
    /// </summary>
    [JsonPropertyName("realtimeInputParameters")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LiveSendRealtimeInputParameters
        ? RealtimeInputParameters {
            get; set;
          }

    /// <summary>
    /// Response to a `ToolCallMessage` received from the server.
    /// </summary>
    [JsonPropertyName("toolResponse")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LiveClientToolResponse
        ? ToolResponse {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a LiveClientMessage object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized LiveClientMessage object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static LiveClientMessage
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<LiveClientMessage>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
