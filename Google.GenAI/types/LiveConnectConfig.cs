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
  /// Session config for the API connection.
  /// </summary>

  public record LiveConnectConfig {
    /// <summary>
    /// Used to override HTTP request options.
    /// </summary>
    [JsonPropertyName("httpOptions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HttpOptions ? HttpOptions { get; set; }

    /// <summary>
    /// The generation configuration for the session.
    /// </summary>
    [JsonPropertyName("generationConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GenerationConfig
        ? GenerationConfig {
            get; set;
          }

    /// <summary>
    /// The requested modalities of the response. Represents the set of       modalities that the
    /// model can return. Defaults to AUDIO if not specified.
    /// </summary>
    [JsonPropertyName("responseModalities")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Modality>
        ? ResponseModalities {
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
    /// Maximum number of tokens that can be generated in the response.
    /// </summary>
    [JsonPropertyName("maxOutputTokens")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? MaxOutputTokens {
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
    /// The speech generation configuration.
    /// </summary>
    [JsonPropertyName("speechConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpeechConfig
        ? SpeechConfig {
            get; set;
          }

    /// <summary>
    /// If enabled, the model will detect emotions and adapt its responses accordingly.
    /// </summary>
    [JsonPropertyName("enableAffectiveDialog")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? EnableAffectiveDialog {
            get; set;
          }

    /// <summary>
    /// The user provided system instructions for the model.       Note: only text should be used in
    /// parts and content in each part will be       in a separate paragraph.
    /// </summary>
    [JsonPropertyName("systemInstruction")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Content
        ? SystemInstruction {
            get; set;
          }

    /// <summary>
    /// A list of `Tools` the model may use to generate the next response.        A `Tool` is a
    /// piece of code that enables the system to interact with       external systems to perform an
    /// action, or set of actions, outside of       knowledge and scope of the model.
    /// </summary>
    [JsonPropertyName("tools")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Tool>
        ? Tools {
            get; set;
          }

    /// <summary>
    /// Configures session resumption mechanism.  If included the server will send
    /// SessionResumptionUpdate messages.
    /// </summary>
    [JsonPropertyName("sessionResumption")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SessionResumptionConfig
        ? SessionResumption {
            get; set;
          }

    /// <summary>
    /// The transcription of the input aligns with the input audio language.
    /// </summary>
    [JsonPropertyName("inputAudioTranscription")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AudioTranscriptionConfig
        ? InputAudioTranscription {
            get; set;
          }

    /// <summary>
    /// The transcription of the output aligns with the language code       specified for the output
    /// audio.
    /// </summary>
    [JsonPropertyName("outputAudioTranscription")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AudioTranscriptionConfig
        ? OutputAudioTranscription {
            get; set;
          }

    /// <summary>
    /// Configures the realtime input behavior in BidiGenerateContent.
    /// </summary>
    [JsonPropertyName("realtimeInputConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RealtimeInputConfig
        ? RealtimeInputConfig {
            get; set;
          }

    /// <summary>
    /// Configures context window compression mechanism.        If included, server will compress
    /// context window to fit into given length.
    /// </summary>
    [JsonPropertyName("contextWindowCompression")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ContextWindowCompressionConfig
        ? ContextWindowCompression {
            get; set;
          }

    /// <summary>
    /// Configures the proactivity of the model. This allows the model to respond proactively to the
    /// input and to ignore irrelevant input.
    /// </summary>
    [JsonPropertyName("proactivity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ProactivityConfig
        ? Proactivity {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a LiveConnectConfig object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized LiveConnectConfig object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static LiveConnectConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<LiveConnectConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
