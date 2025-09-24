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
  /// Generation config.
  /// </summary>

  public record GenerationConfig {
    /// <summary>
    /// Optional. Config for model selection.
    /// </summary>
    [JsonPropertyName("modelSelectionConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ModelSelectionConfig ? ModelSelectionConfig { get; set; }

    /// <summary>
    /// Optional. If enabled, audio timestamp will be included in the request to the model.
    /// </summary>
    [JsonPropertyName("audioTimestamp")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? AudioTimestamp {
            get; set;
          }

    /// <summary>
    /// Optional. Number of candidates to generate.
    /// </summary>
    [JsonPropertyName("candidateCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? CandidateCount {
            get; set;
          }

    /// <summary>
    /// Optional. If enabled, the model will detect emotions and adapt its responses accordingly.
    /// </summary>
    [JsonPropertyName("enableAffectiveDialog")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? EnableAffectiveDialog {
            get; set;
          }

    /// <summary>
    /// Optional. Frequency penalties.
    /// </summary>
    [JsonPropertyName("frequencyPenalty")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? FrequencyPenalty {
            get; set;
          }

    /// <summary>
    /// Optional. Logit probabilities.
    /// </summary>
    [JsonPropertyName("logprobs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? Logprobs {
            get; set;
          }

    /// <summary>
    /// Optional. The maximum number of output tokens to generate per message.
    /// </summary>
    [JsonPropertyName("maxOutputTokens")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? MaxOutputTokens {
            get; set;
          }

    /// <summary>
    /// Optional. If specified, the media resolution specified will be used.
    /// </summary>
    [JsonPropertyName("mediaResolution")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MediaResolution
        ? MediaResolution {
            get; set;
          }

    /// <summary>
    /// Optional. Positive penalties.
    /// </summary>
    [JsonPropertyName("presencePenalty")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? PresencePenalty {
            get; set;
          }

    /// <summary>
    /// Optional. Output schema of the generated response. This is an alternative to
    /// `response_schema` that accepts [JSON Schema](https://json-schema.org/). If set,
    /// `response_schema` must be omitted, but `response_mime_type` is required. While the full JSON
    /// Schema may be sent, not all features are supported. Specifically, only the following
    /// properties are supported: - `$id` - `$defs` - `$ref` - `$anchor` - `type` - `format` -
    /// `title` - `description` - `enum` (for strings and numbers) - `items` - `prefixItems` -
    /// `minItems` - `maxItems` - `minimum` - `maximum` - `anyOf` - `oneOf` (interpreted the same as
    /// `anyOf`) - `properties` - `additionalProperties` - `required` The non-standard
    /// `propertyOrdering` property may also be set. Cyclic references are unrolled to a limited
    /// degree and, as such, may only be used within non-required properties. (Nullable properties
    /// are not sufficient.) If `$ref` is set on a sub-schema, no other properties, except for than
    /// those starting as a `$`, may be set.
    /// </summary>
    [JsonPropertyName("responseJsonSchema")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object
        ? ResponseJsonSchema {
            get; set;
          }

    /// <summary>
    /// Optional. If true, export the logprobs results in response.
    /// </summary>
    [JsonPropertyName("responseLogprobs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? ResponseLogprobs {
            get; set;
          }

    /// <summary>
    /// Optional. Output response mimetype of the generated candidate text. Supported mimetype: -
    /// `text/plain`: (default) Text output. - `application/json`: JSON response in the candidates.
    /// The model needs to be prompted to output the appropriate response type, otherwise the
    /// behavior is undefined. This is a preview feature.
    /// </summary>
    [JsonPropertyName("responseMimeType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? ResponseMimeType {
            get; set;
          }

    /// <summary>
    /// Optional. The modalities of the response.
    /// </summary>
    [JsonPropertyName("responseModalities")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Modality>
        ? ResponseModalities {
            get; set;
          }

    /// <summary>
    /// Optional. The `Schema` object allows the definition of input and output data types. These
    /// types can be objects, but also primitives and arrays. Represents a select subset of an
    /// [OpenAPI 3.0 schema object](https://spec.openapis.org/oas/v3.0.3#schema). If set, a
    /// compatible response_mime_type must also be set. Compatible mimetypes: `application/json`:
    /// Schema for JSON response.
    /// </summary>
    [JsonPropertyName("responseSchema")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Schema
        ? ResponseSchema {
            get; set;
          }

    /// <summary>
    /// Optional. Routing configuration.
    /// </summary>
    [JsonPropertyName("routingConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GenerationConfigRoutingConfig
        ? RoutingConfig {
            get; set;
          }

    /// <summary>
    /// Optional. Seed.
    /// </summary>
    [JsonPropertyName("seed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? Seed {
            get; set;
          }

    /// <summary>
    /// Optional. The speech generation config.
    /// </summary>
    [JsonPropertyName("speechConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpeechConfig
        ? SpeechConfig {
            get; set;
          }

    /// <summary>
    /// Optional. Stop sequences.
    /// </summary>
    [JsonPropertyName("stopSequences")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? StopSequences {
            get; set;
          }

    /// <summary>
    /// Optional. Controls the randomness of predictions.
    /// </summary>
    [JsonPropertyName("temperature")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? Temperature {
            get; set;
          }

    /// <summary>
    /// Optional. Config for thinking features. An error will be returned if this field is set for
    /// models that don't support thinking.
    /// </summary>
    [JsonPropertyName("thinkingConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GenerationConfigThinkingConfig
        ? ThinkingConfig {
            get; set;
          }

    /// <summary>
    /// Optional. If specified, top-k sampling will be used.
    /// </summary>
    [JsonPropertyName("topK")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? TopK {
            get; set;
          }

    /// <summary>
    /// Optional. If specified, nucleus sampling will be used.
    /// </summary>
    [JsonPropertyName("topP")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? TopP {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GenerationConfig object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GenerationConfig object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static GenerationConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GenerationConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
