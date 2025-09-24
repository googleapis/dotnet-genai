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

using Google.GenAI.Serialization;

namespace Google.GenAI.Types
{
  /// <summary>
  /// Describes the machine learning model version checkpoint.
  /// </summary>

  public record Checkpoint
  {
    /// <summary>
    /// The ID of the checkpoint.
    /// </summary>
    [JsonPropertyName("checkpointId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CheckpointId { get; set; }

    /// <summary>
    /// The epoch of the checkpoint.
    /// </summary>
    [JsonPropertyName("epoch")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long? Epoch { get; set; }

    /// <summary>
    /// The step of the checkpoint.
    /// </summary>
    [JsonPropertyName("step")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long? Step { get; set; }

    /// <summary>
    /// Deserializes a JSON string to a Checkpoint object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized Checkpoint object, or null if deserialization fails.</returns>
    /// </summary>
    public static Checkpoint? FromJson(string jsonString, JsonSerializerOptions? options = null)
    {
      try
      {
        return JsonSerializer.Deserialize<Checkpoint>(jsonString, options);
      }
      catch (JsonException e)
      {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
