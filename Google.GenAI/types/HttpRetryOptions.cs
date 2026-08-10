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
  /// HTTP retry options to be used in each of the requests.
  /// </summary>

  public record HttpRetryOptions {
    /// <summary>
    /// Maximum number of attempts, including the original request. If 0 or 1, it means no retries.
    /// If not specified, default to 5.
    /// </summary>
    [JsonPropertyName("attempts")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int ? Attempts { get; set; }

    /// <summary>
    /// Initial delay before the first retry, in fractions of a second. If not specified, default
    /// to 1.0 second.
    /// </summary>
    [JsonPropertyName("initialDelay")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? InitialDelay {
            get; set;
          }

    /// <summary>
    /// Maximum delay between retries, in fractions of a second. If not specified, default to 60.0
    /// seconds.
    /// </summary>
    [JsonPropertyName("maxDelay")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? MaxDelay {
            get; set;
          }

    /// <summary>
    /// Multiplier by which the delay increases after each attempt. If not specified, default
    /// to 2.0.
    /// </summary>
    [JsonPropertyName("expBase")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? ExpBase {
            get; set;
          }

    /// <summary>
    /// Randomness factor for the delay. If not specified, default to 1.0.
    /// </summary>
    [JsonPropertyName("jitter")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? Jitter {
            get; set;
          }

    /// <summary>
    /// List of HTTP status codes that should trigger a retry. If not specified, a default set of
    /// retryable codes (408, 429, and 5xx) may be used.
    /// </summary>
    [JsonPropertyName("httpStatusCodes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<int>
        ? HttpStatusCodes {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a HttpRetryOptions object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized HttpRetryOptions object, or null if deserialization
    /// fails.</returns>
    public static HttpRetryOptions
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize(jsonString,
                                          JsonConfig.TypeInfo<HttpRetryOptions>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
