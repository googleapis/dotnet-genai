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
  /// Schema is used to define the format of input/output data.  Represents a select subset of an
  /// OpenAPI 3.0 schema object (https://spec.openapis.org/oas/v3.0.3#schema-object). More fields
  /// may be added in the future as needed.
  /// </summary>

  public record Schema {
    /// <summary>
    /// Optional. Can either be a boolean or an object; controls the presence of additional
    /// properties.
    /// </summary>
    [JsonPropertyName("additionalProperties")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object ? AdditionalProperties { get; set; }

    /// <summary>
    /// Optional. A map of definitions for use by `ref` Only allowed at the root of the schema.
    /// </summary>
    [JsonPropertyName("defs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, Schema>
        ? Defs {
            get; set;
          }

    /// <summary>
    /// Optional. Allows indirect references between schema nodes. The value should be a valid
    /// reference to a child of the root `defs`. For example, the following schema defines a
    /// reference to a schema node named "Pet": type: object properties: pet: ref: #/defs/Pet defs:
    /// Pet: type: object properties: name: type: string The value of the "pet" property is a
    /// reference to the schema node named "Pet". See details in
    /// https://json-schema.org/understanding-json-schema/structuring
    /// </summary>
    [JsonPropertyName("ref")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Ref {
            get; set;
          }

    /// <summary>
    /// Optional. The instance must be valid against any (one or more) of the subschemas listed in
    /// `any_of`.
    /// </summary>
    [JsonPropertyName("anyOf")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Schema>
        ? AnyOf {
            get; set;
          }

    /// <summary>
    /// Optional. Default value to use if the field is not specified.
    /// </summary>
    [JsonPropertyName("default")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object
        ? Default {
            get; set;
          }

    /// <summary>
    /// Optional. Description of the schema.
    /// </summary>
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Description {
            get; set;
          }

    /// <summary>
    /// Optional. Possible values of the field. This field can be used to restrict a value to a
    /// fixed set of values. To mark a field as an enum, set `format` to `enum` and provide the list
    /// of possible values in `enum`. For example: 1. To define directions: `{type:STRING,
    /// format:enum, enum:["EAST", "NORTH", "SOUTH", "WEST"]}` 2. To define apartment numbers:
    /// `{type:INTEGER, format:enum, enum:["101", "201", "301"]}`
    /// </summary>
    [JsonPropertyName("enum")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? Enum {
            get; set;
          }

    /// <summary>
    /// Optional. Example of an instance of this schema.
    /// </summary>
    [JsonPropertyName("example")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object
        ? Example {
            get; set;
          }

    /// <summary>
    /// Optional. The format of the data. For `NUMBER` type, format can be `float` or `double`. For
    /// `INTEGER` type, format can be `int32` or `int64`. For `STRING` type, format can be `email`,
    /// `byte`, `date`, `date-time`, `password`, and other formats to further refine the data type.
    /// </summary>
    [JsonPropertyName("format")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Format {
            get; set;
          }

    /// <summary>
    /// Optional. If type is `ARRAY`, `items` specifies the schema of elements in the array.
    /// </summary>
    [JsonPropertyName("items")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Schema
        ? Items {
            get; set;
          }

    /// <summary>
    /// Optional. If type is `ARRAY`, `max_items` specifies the maximum number of items in an array.
    /// </summary>
    [JsonPropertyName("maxItems")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long
        ? MaxItems {
            get; set;
          }

    /// <summary>
    /// Optional. If type is `STRING`, `max_length` specifies the maximum length of the string.
    /// </summary>
    [JsonPropertyName("maxLength")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long
        ? MaxLength {
            get; set;
          }

    /// <summary>
    /// Optional. If type is `OBJECT`, `max_properties` specifies the maximum number of properties
    /// that can be provided.
    /// </summary>
    [JsonPropertyName("maxProperties")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long
        ? MaxProperties {
            get; set;
          }

    /// <summary>
    /// Optional. If type is `INTEGER` or `NUMBER`, `maximum` specifies the maximum allowed value.
    /// </summary>
    [JsonPropertyName("maximum")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? Maximum {
            get; set;
          }

    /// <summary>
    /// Optional. If type is `ARRAY`, `min_items` specifies the minimum number of items in an array.
    /// </summary>
    [JsonPropertyName("minItems")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long
        ? MinItems {
            get; set;
          }

    /// <summary>
    /// Optional. If type is `STRING`, `min_length` specifies the minimum length of the string.
    /// </summary>
    [JsonPropertyName("minLength")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long
        ? MinLength {
            get; set;
          }

    /// <summary>
    /// Optional. If type is `OBJECT`, `min_properties` specifies the minimum number of properties
    /// that can be provided.
    /// </summary>
    [JsonPropertyName("minProperties")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long
        ? MinProperties {
            get; set;
          }

    /// <summary>
    /// Optional. If type is `INTEGER` or `NUMBER`, `minimum` specifies the minimum allowed value.
    /// </summary>
    [JsonPropertyName("minimum")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? Minimum {
            get; set;
          }

    /// <summary>
    /// Optional. Indicates if the value of this field can be null.
    /// </summary>
    [JsonPropertyName("nullable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? Nullable {
            get; set;
          }

    /// <summary>
    /// Optional. If type is `STRING`, `pattern` specifies a regular expression that the string must
    /// match.
    /// </summary>
    [JsonPropertyName("pattern")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Pattern {
            get; set;
          }

    /// <summary>
    /// Optional. If type is `OBJECT`, `properties` is a map of property names to schema definitions
    /// for each property of the object.
    /// </summary>
    [JsonPropertyName("properties")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, Schema>
        ? Properties {
            get; set;
          }

    /// <summary>
    /// Optional. Order of properties displayed or used where order matters. This is not a standard
    /// field in OpenAPI specification, but can be used to control the order of properties.
    /// </summary>
    [JsonPropertyName("propertyOrdering")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? PropertyOrdering {
            get; set;
          }

    /// <summary>
    /// Optional. If type is `OBJECT`, `required` lists the names of properties that must be
    /// present.
    /// </summary>
    [JsonPropertyName("required")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? Required {
            get; set;
          }

    /// <summary>
    /// Optional. Title for the schema.
    /// </summary>
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Title {
            get; set;
          }

    /// <summary>
    /// Optional. Data type of the schema field.
    /// </summary>
    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Type
        ? Type {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a Schema object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized Schema object, or null if deserialization fails.</returns>
    public static Schema ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<Schema>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
