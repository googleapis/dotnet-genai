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
  /// Update of the session resumption state.    Only sent if `session_resumption` was set in the
  /// connection config.
  /// </summary>

  public record LiveServerSessionResumptionUpdate {
    /// <summary>
    /// New handle that represents state that can be resumed. Empty if `resumable`=false.
    /// </summary>
    [JsonPropertyName("newHandle")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? NewHandle { get; set; }

    /// <summary>
    /// True if session can be resumed at this point. It might be not possible to resume session at
    /// some points. In that case we send update empty new_handle and resumable=false. Example of
    /// such case could be model executing function calls or just generating. Resuming session
    /// (using previous session token) in such state will result in some data loss.
    /// </summary>
    [JsonPropertyName("resumable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? Resumable {
            get; set;
          }

    /// <summary>
    /// Index of last message sent by client that is included in state represented by this
    /// SessionResumptionToken. Only sent when `SessionResumptionConfig.transparent` is set.
    /// Presence of this index allows users to transparently reconnect and avoid issue of losing
    /// some part of realtime audio input/video. If client wishes to temporarily disconnect (for
    /// example as result of receiving GoAway) they can do it without losing state by buffering
    /// messages sent since last `SessionResmumptionTokenUpdate`. This field will enable them to
    /// limit buffering (avoid keeping all requests in RAM).  Note: This should not be used for when
    /// resuming a session at some time later -- in those cases partial audio and video frames
    /// arelikely not needed.
    /// </summary>
    [JsonPropertyName("lastConsumedClientMessageIndex")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long
        ? LastConsumedClientMessageIndex {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a LiveServerSessionResumptionUpdate object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized LiveServerSessionResumptionUpdate object, or null if
    /// deserialization fails.</returns>
    /// </summary>
    public static LiveServerSessionResumptionUpdate
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<LiveServerSessionResumptionUpdate>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
