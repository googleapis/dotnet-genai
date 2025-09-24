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

  public record TestTableItem {
    /// <summary>
    /// The name of the test. This is used to derive the replay id.
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? Name { get; set; }

    /// <summary>
    /// The parameters to the test. Use pydantic models.
    /// </summary>
    [JsonPropertyName("parameters")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, object>
        ? Parameters {
            get; set;
          }

    /// <summary>
    /// Expects an exception for MLDev matching the string.
    /// </summary>
    [JsonPropertyName("exceptionIfMldev")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? ExceptionIfMldev {
            get; set;
          }

    /// <summary>
    /// Expects an exception for Vertex matching the string.
    /// </summary>
    [JsonPropertyName("exceptionIfVertex")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? ExceptionIfVertex {
            get; set;
          }

    /// <summary>
    /// Use if you don't want to use the default replay id which is derived from the test name.
    /// </summary>
    [JsonPropertyName("overrideReplayId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? OverrideReplayId {
            get; set;
          }

    /// <summary>
    /// True if the parameters contain an unsupported union type. This test  will be skipped for
    /// languages that do not support the union type.
    /// </summary>
    [JsonPropertyName("hasUnion")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? HasUnion {
            get; set;
          }

    /// <summary>
    /// When set to a reason string, this test will be skipped in the API mode. Use this flag for
    /// tests that can not be reproduced with the real API. E.g. a test that deletes a resource.
    /// </summary>
    [JsonPropertyName("skipInApiMode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? SkipInApiMode {
            get; set;
          }

    /// <summary>
    /// Keys to ignore when comparing the request and response. This is useful for tests that are
    /// not deterministic.
    /// </summary>
    [JsonPropertyName("ignoreKeys")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? IgnoreKeys {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a TestTableItem object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized TestTableItem object, or null if deserialization fails.</returns>
    /// </summary>
    public static TestTableItem
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<TestTableItem>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
