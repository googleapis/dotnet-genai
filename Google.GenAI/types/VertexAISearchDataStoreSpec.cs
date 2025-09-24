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
  /// Define data stores within engine to filter on in a search call and configurations for those
  /// data stores. For more information, see
  /// https://cloud.google.com/generative-ai-app-builder/docs/reference/rpc/google.cloud.discoveryengine.v1#datastorespec
  /// </summary>

  public record VertexAISearchDataStoreSpec {
    /// <summary>
    /// Full resource name of DataStore, such as Format:
    /// `projects/{project}/locations/{location}/collections/{collection}/dataStores/{dataStore}`
    /// </summary>
    [JsonPropertyName("dataStore")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? DataStore { get; set; }

    /// <summary>
    /// Optional. Filter specification to filter documents in the data store specified by data_store
    /// field. For more information on filtering, see
    /// [Filtering](https://cloud.google.com/generative-ai-app-builder/docs/filter-search-metadata)
    /// </summary>
    [JsonPropertyName("filter")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Filter {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a VertexAISearchDataStoreSpec object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized VertexAISearchDataStoreSpec object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static VertexAISearchDataStoreSpec
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<VertexAISearchDataStoreSpec>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
