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
  /// Config for batches.create return value.
  /// </summary>

  public record BatchJob {
    /// <summary>
    /// The resource name of the BatchJob. Output only.".
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? Name { get; set; }

    /// <summary>
    /// The display name of the BatchJob.
    /// </summary>
    [JsonPropertyName("displayName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? DisplayName {
            get; set;
          }

    /// <summary>
    /// The state of the BatchJob.
    /// </summary>
    [JsonPropertyName("state")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public JobState
        ? State {
            get; set;
          }

    /// <summary>
    /// Output only. Only populated when the job's state is JOB_STATE_FAILED or JOB_STATE_CANCELLED.
    /// </summary>
    [JsonPropertyName("error")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public JobError
        ? Error {
            get; set;
          }

    /// <summary>
    /// The time when the BatchJob was created.
    /// </summary>
    [JsonPropertyName("createTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime
        ? CreateTime {
            get; set;
          }

    /// <summary>
    /// Output only. Time when the Job for the first time entered the `JOB_STATE_RUNNING` state.
    /// </summary>
    [JsonPropertyName("startTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime
        ? StartTime {
            get; set;
          }

    /// <summary>
    /// The time when the BatchJob was completed. This field is for Gemini Enterprise Agent Platform
    /// only.
    /// </summary>
    [JsonPropertyName("endTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime
        ? EndTime {
            get; set;
          }

    /// <summary>
    /// The time when the BatchJob was last updated.
    /// </summary>
    [JsonPropertyName("updateTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime
        ? UpdateTime {
            get; set;
          }

    /// <summary>
    /// The name of the model that produces the predictions via the BatchJob.
    /// </summary>
    [JsonPropertyName("model")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Model {
            get; set;
          }

    /// <summary>
    /// Configuration for the input data. This field is for Gemini Enterprise Agent Platform only.
    /// </summary>
    [JsonPropertyName("src")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BatchJobSource
        ? Src {
            get; set;
          }

    /// <summary>
    /// Configuration for the output data.
    /// </summary>
    [JsonPropertyName("dest")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BatchJobDestination
        ? Dest {
            get; set;
          }

    /// <summary>
    /// Statistics on completed and failed prediction instances. This field is for Gemini Enterprise
    /// Agent Platform only.
    /// </summary>
    [JsonPropertyName("completionStats")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CompletionStats
        ? CompletionStats {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a BatchJob object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized BatchJob object, or null if deserialization fails.</returns>
    public static BatchJob ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<BatchJob>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
