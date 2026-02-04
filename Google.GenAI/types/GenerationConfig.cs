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
    /// Output schema of the generated response. This is an alternative to `response_schema` that
    /// accepts JSON Schema (https://json-schema.org/).
    /// </summary>
    [JsonPropertyName("responseJsonSchema")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object
        ? ResponseJsonSchema {
            get; set;
          }

    /// <summary>
    /// Optional. If enabled, audio timestamps will be included in the request to the model. This
    /// can be useful for synchronizing audio with other modalities in the response. This field is
    /// not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("audioTimestamp")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? AudioTimestamp {
            get; set;
          }

    /// <summary>
    /// Optional. The number of candidate responses to generate. A higher `candidate_count` can
    /// provide more options to choose from, but it also consumes more resources. This can be useful
    /// for generating a variety of responses and selecting the best one.
    /// </summary>
    [JsonPropertyName("candidateCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? CandidateCount {
            get; set;
          }

    /// <summary>
    /// Optional. If enabled, the model will detect emotions and adapt its responses accordingly.
    /// For example, if the model detects that the user is frustrated, it may provide a more
    /// empathetic response. This field is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("enableAffectiveDialog")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? EnableAffectiveDialog {
            get; set;
          }

    /// <summary>
    /// Optional. Penalizes tokens based on their frequency in the generated text. A positive value
    /// helps to reduce the repetition of words and phrases. Valid values can range from
    /// [-2.0, 2.0].
    /// </summary>
    [JsonPropertyName("frequencyPenalty")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? FrequencyPenalty {
            get; set;
          }

    /// <summary>
    /// Optional. The number of top log probabilities to return for each token. This can be used to
    /// see which other tokens were considered likely candidates for a given position. A higher
    /// value will return more options, but it will also increase the size of the response.
    /// </summary>
    [JsonPropertyName("logprobs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? Logprobs {
            get; set;
          }

    /// <summary>
    /// Optional. The maximum number of tokens to generate in the response. A token is approximately
    /// four characters. The default value varies by model. This parameter can be used to control
    /// the length of the generated text and prevent overly long responses.
    /// </summary>
    [JsonPropertyName("maxOutputTokens")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? MaxOutputTokens {
            get; set;
          }

    /// <summary>
    /// Optional. The token resolution at which input media content is sampled. This is used to
    /// control the trade-off between the quality of the response and the number of tokens used to
    /// represent the media. A higher resolution allows the model to perceive more detail, which can
    /// lead to a more nuanced response, but it will also use more tokens. This does not affect the
    /// image dimensions sent to the model.
    /// </summary>
    [JsonPropertyName("mediaResolution")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MediaResolution
        ? MediaResolution {
            get; set;
          }

    /// <summary>
    /// Optional. Penalizes tokens that have already appeared in the generated text. A positive
    /// value encourages the model to generate more diverse and less repetitive text. Valid values
    /// can range from [-2.0, 2.0].
    /// </summary>
    [JsonPropertyName("presencePenalty")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? PresencePenalty {
            get; set;
          }

    /// <summary>
    /// Optional. If set to true, the log probabilities of the output tokens are returned. Log
    /// probabilities are the logarithm of the probability of a token appearing in the output. A
    /// higher log probability means the token is more likely to be generated. This can be useful
    /// for analyzing the model's confidence in its own output and for debugging.
    /// </summary>
    [JsonPropertyName("responseLogprobs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? ResponseLogprobs {
            get; set;
          }

    /// <summary>
    /// Optional. The IANA standard MIME type of the response. The model will generate output that
    /// conforms to this MIME type. Supported values include 'text/plain' (default) and
    /// 'application/json'. The model needs to be prompted to output the appropriate response type,
    /// otherwise the behavior is undefined. This is a preview feature.
    /// </summary>
    [JsonPropertyName("responseMimeType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? ResponseMimeType {
            get; set;
          }

    /// <summary>
    /// Optional. The modalities of the response. The model will generate a response that includes
    /// all the specified modalities. For example, if this is set to `[TEXT, IMAGE]`, the response
    /// will include both text and an image.
    /// </summary>
    [JsonPropertyName("responseModalities")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Modality>
        ? ResponseModalities {
            get; set;
          }

    /// <summary>
    /// Optional. Lets you to specify a schema for the model's response, ensuring that the output
    /// conforms to a particular structure. This is useful for generating structured data such as
    /// JSON. The schema is a subset of the OpenAPI 3.0 schema object
    /// (https://spec.openapis.org/oas/v3.0.3#schema) object. When this field is set, you must also
    /// set the `response_mime_type` to `application/json`.
    /// </summary>
    [JsonPropertyName("responseSchema")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Schema
        ? ResponseSchema {
            get; set;
          }

    /// <summary>
    /// Optional. Routing configuration. This field is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("routingConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GenerationConfigRoutingConfig
        ? RoutingConfig {
            get; set;
          }

    /// <summary>
    /// Optional. A seed for the random number generator. By setting a seed, you can make the
    /// model's output mostly deterministic. For a given prompt and parameters (like temperature,
    /// top_p, etc.), the model will produce the same response every time. However, it's not a
    /// guaranteed absolute deterministic behavior. This is different from parameters like
    /// `temperature`, which control the *level* of randomness. `seed` ensures that the "random"
    /// choices the model makes are the same on every run, making it essential for testing and
    /// ensuring reproducible results.
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
    /// Optional. A list of character sequences that will stop the model from generating further
    /// tokens. If a stop sequence is generated, the output will end at that point. This is useful
    /// for controlling the length and structure of the output. For example, you can use ["\n",
    /// "###"] to stop generation at a new line or a specific marker.
    /// </summary>
    [JsonPropertyName("stopSequences")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? StopSequences {
            get; set;
          }

    /// <summary>
    /// Optional. Controls the randomness of the output. A higher temperature results in more
    /// creative and diverse responses, while a lower temperature makes the output more predictable
    /// and focused. The valid range is (0.0, 2.0].
    /// </summary>
    [JsonPropertyName("temperature")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? Temperature {
            get; set;
          }

    /// <summary>
    /// Optional. Configuration for thinking features. An error will be returned if this field is
    /// set for models that don't support thinking.
    /// </summary>
    [JsonPropertyName("thinkingConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ThinkingConfig
        ? ThinkingConfig {
            get; set;
          }

    /// <summary>
    /// Optional. Specifies the top-k sampling threshold. The model considers only the top k most
    /// probable tokens for the next token. This can be useful for generating more coherent and less
    /// random text. For example, a `top_k` of 40 means the model will choose the next word from the
    /// 40 most likely words.
    /// </summary>
    [JsonPropertyName("topK")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? TopK {
            get; set;
          }

    /// <summary>
    /// Optional. Specifies the nucleus sampling threshold. The model considers only the smallest
    /// set of tokens whose cumulative probability is at least `top_p`. This helps generate more
    /// diverse and less repetitive responses. For example, a `top_p` of 0.9 means the model
    /// considers tokens until the cumulative probability of the tokens to select from reaches 0.9.
    /// It's recommended to adjust either temperature or `top_p`, but not both.
    /// </summary>
    [JsonPropertyName("topP")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? TopP {
            get; set;
          }

    /// <summary>
    /// Optional. Enables enhanced civic answers. It may not be available for all models. This field
    /// is not supported in Vertex AI.
    /// </summary>
    [JsonPropertyName("enableEnhancedCivicAnswers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? EnableEnhancedCivicAnswers {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GenerationConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GenerationConfig object, or null if deserialization
    /// fails.</returns>
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
