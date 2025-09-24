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

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Google.GenAI.Types
{
  /// <summary>
  /// Configuration for updating a tuned model.
  /// </summary>

  public record UpdateModelConfig
  {
    /// <summary>
    /// Used to override HTTP request options.
    /// </summary>
    [JsonPropertyName("httpOptions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HttpOptions? HttpOptions { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("displayName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DisplayName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("defaultCheckpointId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DefaultCheckpointId { get; set; }

    /// <summary>
    /// Deserializes a JSON string to a UpdateModelConfig object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized UpdateModelConfig object, or null if deserialization fails.</returns>
    /// </summary>
    public static UpdateModelConfig? FromJson(string jsonString, JsonSerializerOptions? options = null)
    {
      try
      {
        return JsonSerializer.Deserialize<UpdateModelConfig>(jsonString, options);
      }
      catch (JsonException e)
      {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
