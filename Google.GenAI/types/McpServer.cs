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
  /// A MCPServer is a server that can be called by the model to perform actions. It is a server
  /// that implements the MCP protocol. Next ID: 5. This data type is not supported in Vertex AI.
  /// </summary>

  public record McpServer {
    /// <summary>
    /// The name of the MCPServer.
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? Name { get; set; }

    /// <summary>
    /// A transport that can stream HTTP requests and responses.
    /// </summary>
    [JsonPropertyName("streamableHttpTransport")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public StreamableHttpTransport
        ? StreamableHttpTransport {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a McpServer object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized McpServer object, or null if deserialization fails.</returns>
    public static McpServer ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<McpServer>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
