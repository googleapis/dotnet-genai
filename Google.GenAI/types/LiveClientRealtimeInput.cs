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
  /// User input that is sent in real time.    This is different from `LiveClientContent` in a few
  /// ways:      - Can be sent continuously without interruption to model generation.     - If there
  /// is a need to mix data interleaved across the       `LiveClientContent` and the
  /// `LiveClientRealtimeInput`, server attempts to       optimize for best response, but there are
  /// no guarantees.     - End of turn is not explicitly specified, but is rather derived from user
  /// activity (for example, end of speech).     - Even before the end of turn, the data is
  /// processed incrementally       to optimize for a fast start of the response from the model. -
  /// Is always assumed to be the user's input (cannot be used to populate       conversation
  /// history).
  /// </summary>

  public record LiveClientRealtimeInput {
    /// <summary>
    /// Inlined bytes data for media input.
    /// </summary>
    [JsonPropertyName("mediaChunks")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Blob> ? MediaChunks { get; set; }

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
    /// Deserializes a JSON string to a LiveClientRealtimeInput object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized LiveClientRealtimeInput object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static LiveClientRealtimeInput
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<LiveClientRealtimeInput>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
