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
  /// Message contains configuration that will apply for the duration of the streaming session.
  /// </summary>

  public record LiveClientSetup {
    /// <summary>
    /// The fully qualified name of the publisher model or tuned model endpoint to       use.
    /// </summary>
    [JsonPropertyName("model")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? Model { get; set; }

    /// <summary>
    /// The generation configuration for the session.       Note: only a subset of fields are
    /// supported.
    /// </summary>
    [JsonPropertyName("generationConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GenerationConfig
        ? GenerationConfig {
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
    /// Configures the realtime input behavior in BidiGenerateContent.
    /// </summary>
    [JsonPropertyName("realtimeInputConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RealtimeInputConfig
        ? RealtimeInputConfig {
            get; set;
          }

    /// <summary>
    /// Configures session resumption mechanism.            If included server will send
    /// SessionResumptionUpdate messages.
    /// </summary>
    [JsonPropertyName("sessionResumption")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SessionResumptionConfig
        ? SessionResumption {
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
    /// Deserializes a JSON string to a LiveClientSetup object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized LiveClientSetup object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static LiveClientSetup
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<LiveClientSetup>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
