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
  /// Optional model configuration parameters.    For more information, see `Content generation
  /// parameters
  /// <https://cloud.google.com/vertex-ai/generative-ai/docs/multimodal/content-generation-parameters>`_.
  /// </summary>

  public record GenerateContentConfig {
    /// <summary>
    /// Used to override HTTP request options.
    /// </summary>
    [JsonPropertyName("httpOptions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HttpOptions ? HttpOptions { get; set; }

    /// <summary>
    /// Instructions for the model to steer it toward better performance.       For example, "Answer
    /// as concisely as possible" or "Don't use technical       terms in your response".
    /// </summary>
    [JsonPropertyName("systemInstruction")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Content
        ? SystemInstruction {
            get; set;
          }

    /// <summary>
    /// Value that controls the degree of randomness in token selection.       Lower temperatures
    /// are good for prompts that require a less open-ended or       creative response, while higher
    /// temperatures can lead to more diverse or       creative results.
    /// </summary>
    [JsonPropertyName("temperature")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? Temperature {
            get; set;
          }

    /// <summary>
    /// Tokens are selected from the most to least probable until the sum       of their
    /// probabilities equals this value. Use a lower value for less       random responses and a
    /// higher value for more random responses.
    /// </summary>
    [JsonPropertyName("topP")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? TopP {
            get; set;
          }

    /// <summary>
    /// For each token selection step, the ``top_k`` tokens with the       highest probabilities are
    /// sampled. Then tokens are further filtered based       on ``top_p`` with the final token
    /// selected using temperature sampling. Use       a lower number for less random responses and
    /// a higher number for more       random responses.
    /// </summary>
    [JsonPropertyName("topK")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? TopK {
            get; set;
          }

    /// <summary>
    /// Number of response variations to return.
    /// </summary>
    [JsonPropertyName("candidateCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? CandidateCount {
            get; set;
          }

    /// <summary>
    /// Maximum number of tokens that can be generated in the response.
    /// </summary>
    [JsonPropertyName("maxOutputTokens")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? MaxOutputTokens {
            get; set;
          }

    /// <summary>
    /// List of strings that tells the model to stop generating text if one       of the strings is
    /// encountered in the response.
    /// </summary>
    [JsonPropertyName("stopSequences")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? StopSequences {
            get; set;
          }

    /// <summary>
    /// Whether to return the log probabilities of the tokens that were       chosen by the model at
    /// each step.
    /// </summary>
    [JsonPropertyName("responseLogprobs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? ResponseLogprobs {
            get; set;
          }

    /// <summary>
    /// Number of top candidate tokens to return the log probabilities for       at each generation
    /// step.
    /// </summary>
    [JsonPropertyName("logprobs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? Logprobs {
            get; set;
          }

    /// <summary>
    /// Positive values penalize tokens that already appear in the       generated text, increasing
    /// the probability of generating more diverse       content.
    /// </summary>
    [JsonPropertyName("presencePenalty")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? PresencePenalty {
            get; set;
          }

    /// <summary>
    /// Positive values penalize tokens that repeatedly appear in the       generated text,
    /// increasing the probability of generating more diverse       content.
    /// </summary>
    [JsonPropertyName("frequencyPenalty")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? FrequencyPenalty {
            get; set;
          }

    /// <summary>
    /// When ``seed`` is fixed to a specific number, the model makes a best       effort to provide
    /// the same response for repeated requests. By default, a       random number is used.
    /// </summary>
    [JsonPropertyName("seed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? Seed {
            get; set;
          }

    /// <summary>
    /// Output response mimetype of the generated candidate text.       Supported mimetype: -
    /// `text/plain`: (default) Text output.         - `application/json`: JSON response in the
    /// candidates.       The model needs to be prompted to output the appropriate response type,
    /// otherwise the behavior is undefined.       This is a preview feature.
    /// </summary>
    [JsonPropertyName("responseMimeType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? ResponseMimeType {
            get; set;
          }

    /// <summary>
    /// The `Schema` object allows the definition of input and output data types.       These types
    /// can be objects, but also primitives and arrays.       Represents a select subset of an
    /// [OpenAPI 3.0 schema       object](https://spec.openapis.org/oas/v3.0.3#schema).       If
    /// set, a compatible response_mime_type must also be set.       Compatible mimetypes:
    /// `application/json`: Schema for JSON response.
    /// </summary>
    [JsonPropertyName("responseSchema")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Schema
        ? ResponseSchema {
            get; set;
          }

    /// <summary>
    /// Optional. Output schema of the generated response.       This is an alternative to
    /// `response_schema` that accepts [JSON       Schema](https://json-schema.org/). If set,
    /// `response_schema` must be       omitted, but `response_mime_type` is required. While the
    /// full JSON Schema       may be sent, not all features are supported. Specifically, only the
    /// following properties are supported: - `$id` - `$defs` - `$ref` - `$anchor`       - `type` -
    /// `format` - `title` - `description` - `enum` (for strings and       numbers) - `items` -
    /// `prefixItems` - `minItems` - `maxItems` - `minimum` -       `maximum` - `anyOf` - `oneOf`
    /// (interpreted the same as `anyOf`) -       `properties` - `additionalProperties` - `required`
    /// The non-standard       `propertyOrdering` property may also be set. Cyclic references are
    /// unrolled to a limited degree and, as such, may only be used within       non-required
    /// properties. (Nullable properties are not sufficient.) If       `$ref` is set on a
    /// sub-schema, no other properties, except for than those       starting as a `$`, may be set.
    /// </summary>
    [JsonPropertyName("responseJsonSchema")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object
        ? ResponseJsonSchema {
            get; set;
          }

    /// <summary>
    /// Configuration for model router requests.
    /// </summary>
    [JsonPropertyName("routingConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GenerationConfigRoutingConfig
        ? RoutingConfig {
            get; set;
          }

    /// <summary>
    /// Configuration for model selection.
    /// </summary>
    [JsonPropertyName("modelSelectionConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ModelSelectionConfig
        ? ModelSelectionConfig {
            get; set;
          }

    /// <summary>
    /// Safety settings in the request to block unsafe content in the       response.
    /// </summary>
    [JsonPropertyName("safetySettings")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<SafetySetting>
        ? SafetySettings {
            get; set;
          }

    /// <summary>
    /// Code that enables the system to interact with external systems to       perform an action
    /// outside of the knowledge and scope of the model.
    /// </summary>
    [JsonPropertyName("tools")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Tool>
        ? Tools {
            get; set;
          }

    /// <summary>
    /// Associates model output to a specific function call.
    /// </summary>
    [JsonPropertyName("toolConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ToolConfig
        ? ToolConfig {
            get; set;
          }

    /// <summary>
    /// Labels with user-defined metadata to break down billed charges.
    /// </summary>
    [JsonPropertyName("labels")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>
        ? Labels {
            get; set;
          }

    /// <summary>
    /// Resource name of a context cache that can be used in subsequent       requests.
    /// </summary>
    [JsonPropertyName("cachedContent")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? CachedContent {
            get; set;
          }

    /// <summary>
    /// The requested modalities of the response. Represents the set of       modalities that the
    /// model can return.
    /// </summary>
    [JsonPropertyName("responseModalities")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? ResponseModalities {
            get; set;
          }

    /// <summary>
    /// If specified, the media resolution specified will be used.
    /// </summary>
    [JsonPropertyName("mediaResolution")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MediaResolution
        ? MediaResolution {
            get; set;
          }

    /// <summary>
    /// The speech generation configuration.
    /// </summary>
    [JsonPropertyName("speechConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpeechConfig
        ? SpeechConfig {
            get; set;
          }

    /// <summary>
    /// If enabled, audio timestamp will be included in the request to the        model.
    /// </summary>
    [JsonPropertyName("audioTimestamp")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? AudioTimestamp {
            get; set;
          }

    /// <summary>
    /// The thinking features configuration.
    /// </summary>
    [JsonPropertyName("thinkingConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThinkingConfig
        ? ThinkingConfig {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GenerateContentConfig object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GenerateContentConfig object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static GenerateContentConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GenerateContentConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
