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
  /// Schema is used to define the format of input/output data.    Represents a select subset of an
  /// [OpenAPI 3.0 schema   object](https://spec.openapis.org/oas/v3.0.3#schema-object). More fields
  /// may   be added in the future as needed.
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
    /// Optional. The value should be validated against any (one or more) of the subschemas in the
    /// list.
    /// </summary>
    [JsonPropertyName("anyOf")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Schema>
        ? AnyOf {
            get; set;
          }

    /// <summary>
    /// Optional. Default value of the data.
    /// </summary>
    [JsonPropertyName("default")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object
        ? Default {
            get; set;
          }

    /// <summary>
    /// Optional. The description of the data.
    /// </summary>
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Description {
            get; set;
          }

    /// <summary>
    /// Optional. Possible values of the element of primitive type with enum format. Examples: 1. We
    /// can define direction as : {type:STRING, format:enum, enum:["EAST", NORTH", "SOUTH",
    /// "WEST"]} 2. We can define apartment number as : {type:INTEGER, format:enum, enum:["101",
    /// "201", "301"]}
    /// </summary>
    [JsonPropertyName("enum")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? Enum {
            get; set;
          }

    /// <summary>
    /// Optional. Example of the object. Will only populated when the object is the root.
    /// </summary>
    [JsonPropertyName("example")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object
        ? Example {
            get; set;
          }

    /// <summary>
    /// Optional. The format of the data. Supported formats: for NUMBER type: "float", "double" for
    /// INTEGER type: "int32", "int64" for STRING type: "email", "byte", etc
    /// </summary>
    [JsonPropertyName("format")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Format {
            get; set;
          }

    /// <summary>
    /// Optional. SCHEMA FIELDS FOR TYPE ARRAY Schema of the elements of Type.ARRAY.
    /// </summary>
    [JsonPropertyName("items")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Schema
        ? Items {
            get; set;
          }

    /// <summary>
    /// Optional. Maximum number of the elements for Type.ARRAY.
    /// </summary>
    [JsonPropertyName("maxItems")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long
        ? MaxItems {
            get; set;
          }

    /// <summary>
    /// Optional. Maximum length of the Type.STRING
    /// </summary>
    [JsonPropertyName("maxLength")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long
        ? MaxLength {
            get; set;
          }

    /// <summary>
    /// Optional. Maximum number of the properties for Type.OBJECT.
    /// </summary>
    [JsonPropertyName("maxProperties")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long
        ? MaxProperties {
            get; set;
          }

    /// <summary>
    /// Optional. Maximum value of the Type.INTEGER and Type.NUMBER
    /// </summary>
    [JsonPropertyName("maximum")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? Maximum {
            get; set;
          }

    /// <summary>
    /// Optional. Minimum number of the elements for Type.ARRAY.
    /// </summary>
    [JsonPropertyName("minItems")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long
        ? MinItems {
            get; set;
          }

    /// <summary>
    /// Optional. SCHEMA FIELDS FOR TYPE STRING Minimum length of the Type.STRING
    /// </summary>
    [JsonPropertyName("minLength")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long
        ? MinLength {
            get; set;
          }

    /// <summary>
    /// Optional. Minimum number of the properties for Type.OBJECT.
    /// </summary>
    [JsonPropertyName("minProperties")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long
        ? MinProperties {
            get; set;
          }

    /// <summary>
    /// Optional. SCHEMA FIELDS FOR TYPE INTEGER and NUMBER Minimum value of the Type.INTEGER and
    /// Type.NUMBER
    /// </summary>
    [JsonPropertyName("minimum")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? Minimum {
            get; set;
          }

    /// <summary>
    /// Optional. Indicates if the value may be null.
    /// </summary>
    [JsonPropertyName("nullable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? Nullable {
            get; set;
          }

    /// <summary>
    /// Optional. Pattern of the Type.STRING to restrict a string to a regular expression.
    /// </summary>
    [JsonPropertyName("pattern")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Pattern {
            get; set;
          }

    /// <summary>
    /// Optional. SCHEMA FIELDS FOR TYPE OBJECT Properties of Type.OBJECT.
    /// </summary>
    [JsonPropertyName("properties")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, Schema>
        ? Properties {
            get; set;
          }

    /// <summary>
    /// Optional. The order of the properties. Not a standard field in open api spec. Only used to
    /// support the order of the properties.
    /// </summary>
    [JsonPropertyName("propertyOrdering")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? PropertyOrdering {
            get; set;
          }

    /// <summary>
    /// Optional. Required properties of Type.OBJECT.
    /// </summary>
    [JsonPropertyName("required")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? Required {
            get; set;
          }

    /// <summary>
    /// Optional. The title of the Schema.
    /// </summary>
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Title {
            get; set;
          }

    /// <summary>
    /// Optional. The type of the data.
    /// </summary>
    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Type
        ? Type {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a Schema object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized Schema object, or null if deserialization fails.</returns>
    /// </summary>
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
