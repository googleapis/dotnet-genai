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
  /// Tool details of a tool that the model may use to generate a response.
  /// </summary>

  public record Tool {
    /// <summary>
    /// List of function declarations that the tool supports.
    /// </summary>
    [JsonPropertyName("functionDeclarations")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<FunctionDeclaration> ? FunctionDeclarations { get; set; }

    /// <summary>
    /// Optional. Retrieval tool type. System will always execute the provided retrieval tool(s) to
    /// get external knowledge to answer the prompt. Retrieval results are presented to the model
    /// for generation.
    /// </summary>
    [JsonPropertyName("retrieval")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Retrieval
        ? Retrieval {
            get; set;
          }

    /// <summary>
    /// Optional. Google Search tool type. Specialized retrieval tool       that is powered by
    /// Google Search.
    /// </summary>
    [JsonPropertyName("googleSearch")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GoogleSearch
        ? GoogleSearch {
            get; set;
          }

    /// <summary>
    /// Optional. GoogleSearchRetrieval tool type. Specialized retrieval tool that is powered by
    /// Google search.
    /// </summary>
    [JsonPropertyName("googleSearchRetrieval")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GoogleSearchRetrieval
        ? GoogleSearchRetrieval {
            get; set;
          }

    /// <summary>
    /// Optional. Enterprise web search tool type. Specialized retrieval       tool that is powered
    /// by Vertex AI Search and Sec4 compliance.
    /// </summary>
    [JsonPropertyName("enterpriseWebSearch")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public EnterpriseWebSearch
        ? EnterpriseWebSearch {
            get; set;
          }

    /// <summary>
    /// Optional. Google Maps tool type. Specialized retrieval tool       that is powered by Google
    /// Maps.
    /// </summary>
    [JsonPropertyName("googleMaps")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GoogleMaps
        ? GoogleMaps {
            get; set;
          }

    /// <summary>
    /// Optional. Tool to support URL context retrieval.
    /// </summary>
    [JsonPropertyName("urlContext")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public UrlContext
        ? UrlContext {
            get; set;
          }

    /// <summary>
    /// Optional. Tool to support the model interacting directly with the       computer. If
    /// enabled, it automatically populates computer-use specific       Function Declarations.
    /// </summary>
    [JsonPropertyName("computerUse")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ToolComputerUse
        ? ComputerUse {
            get; set;
          }

    /// <summary>
    /// Optional. CodeExecution tool type. Enables the model to execute code as part of generation.
    /// </summary>
    [JsonPropertyName("codeExecution")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ToolCodeExecution
        ? CodeExecution {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a Tool object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized Tool object, or null if deserialization fails.</returns>
    /// </summary>
    public static Tool ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<Tool>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
