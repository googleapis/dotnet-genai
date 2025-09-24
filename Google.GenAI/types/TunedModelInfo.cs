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
  /// A tuned machine learning model.
  /// </summary>

  public record TunedModelInfo
  {
    /// <summary>
    /// ID of the base model that you want to tune.
    /// </summary>
    [JsonPropertyName("baseModel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BaseModel { get; set; }

    /// <summary>
    /// Date and time when the base model was created.
    /// </summary>
    [JsonPropertyName("createTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? CreateTime { get; set; }

    /// <summary>
    /// Date and time when the base model was last updated.
    /// </summary>
    [JsonPropertyName("updateTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? UpdateTime { get; set; }

    /// <summary>
    /// Deserializes a JSON string to a TunedModelInfo object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized TunedModelInfo object, or null if deserialization fails.</returns>
    /// </summary>
    public static TunedModelInfo? FromJson(string jsonString, JsonSerializerOptions? options = null)
    {
      try
      {
        return JsonSerializer.Deserialize<TunedModelInfo>(jsonString, options);
      }
      catch (JsonException e)
      {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
