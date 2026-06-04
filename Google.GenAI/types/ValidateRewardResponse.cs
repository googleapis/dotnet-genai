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
  /// Response for the validate_reward method.  Contains the computed reward for a reinforcement
  /// tuning reward configuration.
  /// </summary>

  public record ValidateRewardResponse {
    /// <summary>
    /// Used to retain the full HTTP response.
    /// </summary>
    [JsonPropertyName("sdkHttpResponse")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HttpResponse ? SdkHttpResponse { get; set; }

    /// <summary>
    /// Output only. The overall weighted reward. For a `CompositeReinforcementTuningRewardConfig`,
    /// this is the weighted average of all rewards. For a `SingleReinforcementTuningRewardConfig`,
    /// this will be the value of the single reward.
    /// </summary>
    [JsonPropertyName("overallReward")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? OverallReward {
            get; set;
          }

    /// <summary>
    /// Output only. In case of an error, this field will be populated with a detailed error message
    /// to help with debugging.
    /// </summary>
    [JsonPropertyName("error")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Error {
            get; set;
          }

    /// <summary>
    /// A map from reward name to reward info.
    /// </summary>
    [JsonPropertyName("rewardInfoDetails")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, ReinforcementTuningRewardInfo>
        ? RewardInfoDetails {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ValidateRewardResponse object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ValidateRewardResponse object, or null if deserialization
    /// fails.</returns>
    public static ValidateRewardResponse
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ValidateRewardResponse>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
