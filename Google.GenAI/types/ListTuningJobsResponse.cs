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
  /// Response for the list tuning jobs method.
  /// </summary>

  public record ListTuningJobsResponse {
    /// <summary>
    /// Used to retain the full HTTP response.
    /// </summary>
    [JsonPropertyName("sdkHttpResponse")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HttpResponse ? SdkHttpResponse { get; set; }

    /// <summary>
    /// A token to retrieve the next page of results. Pass this token in a subsequent
    /// [GenAiTuningService.ListTuningJobs] call to retrieve the next page of results.
    /// </summary>
    [JsonPropertyName("nextPageToken")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? NextPageToken {
            get; set;
          }

    /// <summary>
    /// The tuning jobs that match the request.
    /// </summary>
    [JsonPropertyName("tuningJobs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<TuningJob>
        ? TuningJobs {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ListTuningJobsResponse object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ListTuningJobsResponse object, or null if deserialization
    /// fails.</returns>
    public static ListTuningJobsResponse
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ListTuningJobsResponse>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
