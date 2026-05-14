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
  /// Configuration for webhook notifications.  Used to configure webhook endpoints that will
  /// receive notifications when long-running operations (e.g., batch jobs, video generation)
  /// complete.
  /// </summary>

  public record WebhookConfig {
    /// <summary>
    /// The webhook URIs to receive notifications. If set, these webhook URIs will be used instead
    /// of the registered webhooks.
    /// </summary>
    [JsonPropertyName("uris")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string> ? Uris { get; set; }

    /// <summary>
    /// User metadata that will be included in each webhook event notification. Use this to attach
    /// custom key-value data to correlate webhook events with your internal systems.
    /// </summary>
    [JsonPropertyName("userMetadata")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, object>
        ? UserMetadata {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a WebhookConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized WebhookConfig object, or null if deserialization fails.</returns>
    public static WebhookConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<WebhookConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
