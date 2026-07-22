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
  /// Message to be sent in the first (and only in the first) `BidiGenerateContentClientMessage`.
  /// Contains configuration that will apply for the duration of the streaming RPC. Clients should
  /// wait for a `BidiGenerateContentSetupComplete` message before sending any additional messages.
  /// This data type is not supported in Vertex AI.
  /// </summary>

  public record BidiGenerateContentSetup {
    /// <summary>
    /// Optional. Configures a context window compression mechanism. If included, the server will
    /// automatically reduce the size of the context when it exceeds the configured length.
    /// </summary>
    [JsonPropertyName("contextWindowCompression")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ContextWindowCompressionConfig ? ContextWindowCompression { get; set; }

    /// <summary>
    /// Optional. Generation config. The following fields are not supported: - `response_logprobs` -
    /// `response_mime_type` - `logprobs` - `response_schema` - `response_json_schema` -
    /// `stop_sequence` - `skip_response_cache` - `routing_config` - `audio_timestamp`
    /// </summary>
    [JsonPropertyName("generationConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GenerationConfig
        ? GenerationConfig {
            get; set;
          }

    /// <summary>
    /// Optional. Configures the exchange of history between the client and the server.
    /// </summary>
    [JsonPropertyName("historyConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HistoryConfig
        ? HistoryConfig {
            get; set;
          }

    /// <summary>
    /// Optional. If set, enables transcription of voice input. The transcription aligns with the
    /// input audio language, if configured.
    /// </summary>
    [JsonPropertyName("inputAudioTranscription")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AudioTranscriptionConfig
        ? InputAudioTranscription {
            get; set;
          }

    /// <summary>
    /// The model's resource name. This serves as an ID for the Model to use. Format:
    /// `models/{model}`
    /// </summary>
    [JsonPropertyName("model")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Model {
            get; set;
          }

    /// <summary>
    /// Optional. If set, enables transcription of the model's audio output. The transcription
    /// aligns with the language code specified for the output audio, if configured.
    /// </summary>
    [JsonPropertyName("outputAudioTranscription")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AudioTranscriptionConfig
        ? OutputAudioTranscription {
            get; set;
          }

    /// <summary>
    /// Optional. Configures the handling of realtime input.
    /// </summary>
    [JsonPropertyName("realtimeInputConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RealtimeInputConfig
        ? RealtimeInputConfig {
            get; set;
          }

    /// <summary>
    /// Optional. Configures session resumption mechanism. If included, the server will send
    /// `SessionResumptionUpdate` messages.
    /// </summary>
    [JsonPropertyName("sessionResumption")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SessionResumptionConfig
        ? SessionResumption {
            get; set;
          }

    /// <summary>
    /// Optional. The user provided system instructions for the model. Note: Only text should be
    /// used in parts and content in each part will be in a separate paragraph.
    /// </summary>
    [JsonPropertyName("systemInstruction")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Content
        ? SystemInstruction {
            get; set;
          }

    /// <summary>
    /// Optional. A list of `Tools` the model may use to generate the next response. A `Tool` is a
    /// piece of code that enables the system to interact with external systems to perform an
    /// action, or set of actions, outside of knowledge and scope of the model.
    /// </summary>
    [JsonPropertyName("tools")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Tool>
        ? Tools {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a BidiGenerateContentSetup object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized BidiGenerateContentSetup object, or null if deserialization
    /// fails.</returns>
    public static BidiGenerateContentSetup
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize(jsonString,
                                          JsonConfig.TypeInfo<BidiGenerateContentSetup>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
