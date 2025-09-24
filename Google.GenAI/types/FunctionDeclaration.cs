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
  /// Defines a function that the model can generate JSON inputs for.    The inputs are based on
  /// `OpenAPI 3.0 specifications   <https://spec.openapis.org/oas/v3.0.3>`_.
  /// </summary>

  public record FunctionDeclaration {
    /// <summary>
    /// Defines the function behavior.
    /// </summary>
    [JsonPropertyName("behavior")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Behavior ? Behavior { get; set; }

    /// <summary>
    /// Optional. Description and purpose of the function. Model uses it to decide how and whether
    /// to call the function.
    /// </summary>
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Description {
            get; set;
          }

    /// <summary>
    /// The name of the function to call. Must start with a letter or an underscore. Must be a-z,
    /// A-Z, 0-9, or contain underscores, dots and dashes, with a maximum length of 64.
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Name {
            get; set;
          }

    /// <summary>
    /// Optional. Describes the parameters to this function in JSON Schema Object format. Reflects
    /// the Open API 3.03 Parameter Object. string Key: the name of the parameter. Parameter names
    /// are case sensitive. Schema Value: the Schema defining the type used for the parameter. For
    /// function with no parameters, this can be left unset. Parameter names must start with a
    /// letter or an underscore and must only contain chars a-z, A-Z, 0-9, or underscores with a
    /// maximum length of 64. Example with 1 required and 1 optional parameter: type: OBJECT
    /// properties: param1: type: STRING param2: type: INTEGER required: - param1
    /// </summary>
    [JsonPropertyName("parameters")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Schema
        ? Parameters {
            get; set;
          }

    /// <summary>
    /// Optional. Describes the parameters to the function in JSON Schema format. The schema must
    /// describe an object where the properties are the parameters to the function. For example: ```
    /// { "type": "object", "properties": { "name": { "type": "string" }, "age": { "type": "integer"
    /// } }, "additionalProperties": false, "required": ["name", "age"], "propertyOrdering":
    /// ["name", "age"] } ``` This field is mutually exclusive with `parameters`.
    /// </summary>
    [JsonPropertyName("parametersJsonSchema")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object
        ? ParametersJsonSchema {
            get; set;
          }

    /// <summary>
    /// Optional. Describes the output from this function in JSON Schema format. Reflects the Open
    /// API 3.03 Response Object. The Schema defines the type used for the response value of the
    /// function.
    /// </summary>
    [JsonPropertyName("response")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Schema
        ? Response {
            get; set;
          }

    /// <summary>
    /// Optional. Describes the output from this function in JSON Schema format. The value specified
    /// by the schema is the response value of the function. This field is mutually exclusive with
    /// `response`.
    /// </summary>
    [JsonPropertyName("responseJsonSchema")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object
        ? ResponseJsonSchema {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a FunctionDeclaration object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized FunctionDeclaration object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static FunctionDeclaration
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<FunctionDeclaration>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
