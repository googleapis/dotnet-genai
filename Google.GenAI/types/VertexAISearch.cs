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
  /// Retrieve from Vertex AI Search datastore or engine for grounding. datastore and engine are
  /// mutually exclusive. See https://cloud.google.com/products/agent-builder
  /// </summary>

  public record VertexAISearch {
    /// <summary>
    /// Specifications that define the specific DataStores to be searched, along with configurations
    /// for those data stores. This is only considered for Engines with multiple data stores. It
    /// should only be set if engine is used.
    /// </summary>
    [JsonPropertyName("dataStoreSpecs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<VertexAISearchDataStoreSpec> ? DataStoreSpecs { get; set; }

    /// <summary>
    /// Optional. Fully-qualified Vertex AI Search data store resource ID. Format:
    /// `projects/{project}/locations/{location}/collections/{collection}/dataStores/{dataStore}`
    /// </summary>
    [JsonPropertyName("datastore")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Datastore {
            get; set;
          }

    /// <summary>
    /// Optional. Fully-qualified Vertex AI Search engine resource ID. Format:
    /// `projects/{project}/locations/{location}/collections/{collection}/engines/{engine}`
    /// </summary>
    [JsonPropertyName("engine")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Engine {
            get; set;
          }

    /// <summary>
    /// Optional. Filter strings to be passed to the search API.
    /// </summary>
    [JsonPropertyName("filter")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Filter {
            get; set;
          }

    /// <summary>
    /// Optional. Number of search results to return per query. The default value is 10. The
    /// maximumm allowed value is 10.
    /// </summary>
    [JsonPropertyName("maxResults")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? MaxResults {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a VertexAISearch object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized VertexAISearch object, or null if deserialization fails.</returns>
    /// </summary>
    public static VertexAISearch
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<VertexAISearch>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
