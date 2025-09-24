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
  /// Defines a retrieval tool that model can call to access external knowledge.
  /// </summary>

  public record Retrieval {
    /// <summary>
    /// Optional. Deprecated. This option is no longer supported.
    /// </summary>
    [JsonPropertyName("disableAttribution")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool ? DisableAttribution { get; set; }

    /// <summary>
    /// Use data source powered by external API for grounding.
    /// </summary>
    [JsonPropertyName("externalApi")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ExternalApi
        ? ExternalApi {
            get; set;
          }

    /// <summary>
    /// Set to use data source powered by Vertex AI Search.
    /// </summary>
    [JsonPropertyName("vertexAiSearch")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VertexAISearch
        ? VertexAiSearch {
            get; set;
          }

    /// <summary>
    /// Set to use data source powered by Vertex RAG store. User data is uploaded via the
    /// VertexRagDataService.
    /// </summary>
    [JsonPropertyName("vertexRagStore")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VertexRagStore
        ? VertexRagStore {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a Retrieval object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized Retrieval object, or null if deserialization fails.</returns>
    /// </summary>
    public static Retrieval ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<Retrieval>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
