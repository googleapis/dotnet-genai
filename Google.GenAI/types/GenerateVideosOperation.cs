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

using System.Text.Json.Nodes;
using Google.GenAI;

namespace Google.GenAI.Types {
  /// <summary>
  /// A video generation operation.
  /// </summary>

  public record GenerateVideosOperation : Operation<GenerateVideosOperation> {
    /// <summary>
    /// The generated videos.
    /// </summary>
    [JsonPropertyName("response")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GenerateVideosResponse ? Response { get; set; }

    /// <summary>
    /// Deserializes a JSON string to a GenerateVideosOperation object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GenerateVideosOperation object, or null if deserialization
    /// fails.</returns>
    public static GenerateVideosOperation
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GenerateVideosOperation>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }

    public override GenerateVideosOperation
        ? FromApiResponse(JsonNode apiResponse, bool isVertexAI) {
      var operationsConverters = new OperationsConverters(null);
      JsonNode response;
      if (isVertexAI) {
        response =
            operationsConverters.GenerateVideosOperationFromVertex(apiResponse, new JsonObject());
      } else {
        response =
            operationsConverters.GenerateVideosOperationFromMldev(apiResponse, new JsonObject());
      }
      return JsonSerializer.Deserialize<GenerateVideosOperation>(response.ToJsonString(),
                                                                 (JsonSerializerOptions?)null) ??
             throw new InvalidOperationException("Failed to deserialize GenerateVideosOperation.");
    }
  }
}
