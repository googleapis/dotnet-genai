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
  /// A transport that can stream HTTP requests and responses. Next ID: 6. This data type is not
  /// supported in Vertex AI.
  /// </summary>

  public record StreamableHttpTransport {
    /// <summary>
    /// Optional: Fields for authentication headers, timeouts, etc., if needed.
    /// </summary>
    [JsonPropertyName("headers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string> ? Headers { get; set; }

    /// <summary>
    /// Timeout for SSE read operations.
    /// </summary>
    [JsonPropertyName("sseReadTimeout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? SseReadTimeout {
            get; set;
          }

    /// <summary>
    /// Whether to close the client session when the transport closes.
    /// </summary>
    [JsonPropertyName("terminateOnClose")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? TerminateOnClose {
            get; set;
          }

    /// <summary>
    /// HTTP timeout for regular operations.
    /// </summary>
    [JsonPropertyName("timeout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Timeout {
            get; set;
          }

    /// <summary>
    /// The full URL for the MCPServer endpoint. Example: "https://api.example.com/mcp".
    /// </summary>
    [JsonPropertyName("url")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Url {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a StreamableHttpTransport object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized StreamableHttpTransport object, or null if deserialization
    /// fails.</returns>
    public static StreamableHttpTransport
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<StreamableHttpTransport>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
