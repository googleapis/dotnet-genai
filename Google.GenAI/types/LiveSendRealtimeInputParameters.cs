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
  /// Parameters for sending realtime input to the live API.
  /// </summary>

  public record LiveSendRealtimeInputParameters {
    /// <summary>
    /// Realtime input to send to the session.
    /// </summary>
    [JsonPropertyName("media")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Blob ? Media { get; set; }

    /// <summary>
    /// The realtime audio input stream.
    /// </summary>
    [JsonPropertyName("audio")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Blob
        ? Audio {
            get; set;
          }

    /// <summary>
    /// Indicates that the audio stream has ended, e.g. because the microphone was turned off.  This
    /// should only be sent when automatic activity detection is enabled (which is the default). The
    /// client can reopen the stream by sending an audio message.
    /// </summary>
    [JsonPropertyName("audioStreamEnd")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? AudioStreamEnd {
            get; set;
          }

    /// <summary>
    /// The realtime video input stream.
    /// </summary>
    [JsonPropertyName("video")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Blob
        ? Video {
            get; set;
          }

    /// <summary>
    /// The realtime text input stream.
    /// </summary>
    [JsonPropertyName("text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Text {
            get; set;
          }

    /// <summary>
    /// Marks the start of user activity.
    /// </summary>
    [JsonPropertyName("activityStart")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ActivityStart
        ? ActivityStart {
            get; set;
          }

    /// <summary>
    /// Marks the end of user activity.
    /// </summary>
    [JsonPropertyName("activityEnd")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ActivityEnd
        ? ActivityEnd {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a LiveSendRealtimeInputParameters object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized LiveSendRealtimeInputParameters object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static LiveSendRealtimeInputParameters
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<LiveSendRealtimeInputParameters>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
