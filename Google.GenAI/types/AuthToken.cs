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
  /// Config for auth_tokens.create parameters.
  /// </summary>

  public record AuthToken {
    /// <summary>
    /// Output only. Identifier. The token itself.
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? Name { get; set; }

    /// <summary>
    /// Optional. Input only. Immutable. Configuration specific to `BidiGenerateContent`.
    /// </summary>
    [JsonPropertyName("bidiGenerateContentSetup")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BidiGenerateContentSetup
        ? BidiGenerateContentSetup {
            get; set;
          }

    /// <summary>
    /// Optional. Input only. Immutable. An optional time after which, when using the resulting
    /// token, messages in BidiGenerateContent sessions will be rejected. (Gemini may preemptively
    /// close the session after this time.) If not set then this defaults to 30 minutes in the
    /// future. If set, this value must be less than 20 hours in the future.
    /// </summary>
    [JsonPropertyName("expireTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime
        ? ExpireTime {
            get; set;
          }

    /// <summary>
    /// Optional. Input only. Immutable. If field_mask is empty, and `bidi_generate_content_setup`
    /// is not present, then the effective `BidiGenerateContentSetup` message is taken from the Live
    /// API connection. If field_mask is empty, and `bidi_generate_content_setup` _is_ present, then
    /// the effective `BidiGenerateContentSetup` message is taken entirely from
    /// `bidi_generate_content_setup` in this request. The setup message from the Live API
    /// connection is ignored. If field_mask is not empty, then the corresponding fields from
    /// `bidi_generate_content_setup` will overwrite the fields from the setup message in the Live
    /// API connection.
    /// </summary>
    [JsonPropertyName("fieldMask")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? FieldMask {
            get; set;
          }

    /// <summary>
    /// Optional. Input only. Immutable. The time after which new Live API sessions using the token
    /// resulting from this request will be rejected. If not set this defaults to 60 seconds in the
    /// future. If set, this value must be less than 20 hours in the future.
    /// </summary>
    [JsonPropertyName("newSessionExpireTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime
        ? NewSessionExpireTime {
            get; set;
          }

    /// <summary>
    /// Optional. Input only. Immutable. The number of times the token can be used. If this value is
    /// zero then no limit is applied. Resuming a Live API session does not count as a use. If
    /// unspecified, the default is 1.
    /// </summary>
    [JsonPropertyName("uses")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? Uses {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a AuthToken object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized AuthToken object, or null if deserialization fails.</returns>
    public static AuthToken ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize(jsonString, JsonConfig.TypeInfo<AuthToken>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
