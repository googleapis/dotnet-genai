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
  /// Optional parameters.
  /// </summary>

  public record CreateAuthTokenConfig {
    /// <summary>
    /// Used to override HTTP request options.
    /// </summary>
    [JsonPropertyName("httpOptions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HttpOptions ? HttpOptions { get; set; }

    /// <summary>
    /// An optional time after which, when using the resulting token,       messages in Live API
    /// sessions will be rejected. (Gemini may       preemptively close the session after this
    /// time.)        If not set then this defaults to 30 minutes in the future. If set, this value
    /// must be less than 20 hours in the future.
    /// </summary>
    [JsonPropertyName("expireTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime
        ? ExpireTime {
            get; set;
          }

    /// <summary>
    /// The time after which new Live API sessions using the token       resulting from this request
    /// will be rejected.        If not set this defaults to 60 seconds in the future. If set, this
    /// value       must be less than 20 hours in the future.
    /// </summary>
    [JsonPropertyName("newSessionExpireTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime
        ? NewSessionExpireTime {
            get; set;
          }

    /// <summary>
    /// The number of times the token can be used. If this value is zero       then no limit is
    /// applied. Default is 1. Resuming a Live API session does       not count as a use.
    /// </summary>
    [JsonPropertyName("uses")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? Uses {
            get; set;
          }

    /// <summary>
    /// Configuration specific to Live API connections created using this token.
    /// </summary>
    [JsonPropertyName("liveConnectConstraints")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LiveConnectConstraints
        ? LiveConnectConstraints {
            get; set;
          }

    /// <summary>
    /// Additional fields to lock in the effective LiveConnectParameters.
    /// </summary>
    [JsonPropertyName("lockAdditionalFields")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? LockAdditionalFields {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a CreateAuthTokenConfig object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized CreateAuthTokenConfig object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static CreateAuthTokenConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<CreateAuthTokenConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
