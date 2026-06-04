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
  /// Parameters for the validate_reward method.  Validates a reinforcement tuning reward
  /// configuration against a sample response and example before creating a reinforcement tuning
  /// job.
  /// </summary>

  internal record ValidateRewardParameters {
    /// <summary>
    /// The resource name of the Location to validate the reward in, e.g.
    /// `projects/{project}/locations/{location}`.
    /// </summary>
    [JsonPropertyName("parent")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? Parent { get; set; }

    /// <summary>
    /// The sample response for validating the reward configuration.
    /// </summary>
    [JsonPropertyName("sampleResponse")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Content
        ? SampleResponse {
            get; set;
          }

    /// <summary>
    /// The example to validate the reward configuration.
    /// </summary>
    [JsonPropertyName("example")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ReinforcementTuningExample
        ? Example {
            get; set;
          }

    /// <summary>
    /// Single reward function configuration for reinforcement tuning. Mutually exclusive with
    /// composite_reward_config.
    /// </summary>
    [JsonPropertyName("singleRewardConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SingleReinforcementTuningRewardConfig
        ? SingleRewardConfig {
            get; set;
          }

    /// <summary>
    /// Composite reward function configuration for reinforcement tuning. Mutually exclusive with
    /// single_reward_config.
    /// </summary>
    [JsonPropertyName("compositeRewardConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CompositeReinforcementTuningRewardConfig
        ? CompositeRewardConfig {
            get; set;
          }

    /// <summary>
    /// Optional parameters for the request.
    /// </summary>
    [JsonPropertyName("config")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ValidateRewardConfig
        ? Config {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ValidateRewardParameters object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ValidateRewardParameters object, or null if deserialization
    /// fails.</returns>
    public static ValidateRewardParameters
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ValidateRewardParameters>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
