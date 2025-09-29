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
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

using Google.GenAI.Types;

namespace Google.GenAI {

  /// <summary>
  /// Provides methods to interact with the Gen AI models. This class is not intended to be
  /// instantiated directly, instead it should be accessed through the <see cref="Client"/> class.
  /// </summary>

  public sealed class Models {
    private readonly ApiClient _apiClient;

    internal JsonNode BlobToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "displayName" }))) {
        throw new NotSupportedException("displayName parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "data" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "data" },
                              Common.GetValueByPath(fromObject, new string[] { "data" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "mimeType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "mimeType" },
                              Common.GetValueByPath(fromObject, new string[] { "mimeType" }));
      }

      return toObject;
    }

    internal JsonNode CandidateFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "content" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "content" },
                              Common.GetValueByPath(fromObject, new string[] { "content" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "citationMetadata" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "citationMetadata" },
            CitationMetadataFromMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                          fromObject, new string[] { "citationMetadata" }))),
                                      toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tokenCount" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "tokenCount" },
                              Common.GetValueByPath(fromObject, new string[] { "tokenCount" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "finishReason" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "finishReason" },
                              Common.GetValueByPath(fromObject, new string[] { "finishReason" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "urlContextMetadata" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "urlContextMetadata" },
            Common.GetValueByPath(fromObject, new string[] { "urlContextMetadata" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "avgLogprobs" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "avgLogprobs" },
                              Common.GetValueByPath(fromObject, new string[] { "avgLogprobs" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "groundingMetadata" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "groundingMetadata" },
            Common.GetValueByPath(fromObject, new string[] { "groundingMetadata" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "index" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "index" },
                              Common.GetValueByPath(fromObject, new string[] { "index" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "logprobsResult" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "logprobsResult" },
                              Common.GetValueByPath(fromObject, new string[] { "logprobsResult" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "safetyRatings" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "safetyRatings" },
                              Common.GetValueByPath(fromObject, new string[] { "safetyRatings" }));
      }

      return toObject;
    }

    internal JsonNode CitationMetadataFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "citationSources" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "citations" },
            Common.GetValueByPath(fromObject, new string[] { "citationSources" }));
      }

      return toObject;
    }

    internal JsonNode ContentToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "parts" }) != null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(fromObject, new string[] { "parts" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(PartToMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "parts" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "role" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "role" },
                              Common.GetValueByPath(fromObject, new string[] { "role" }));
      }

      return toObject;
    }

    internal JsonNode FileDataToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "displayName" }))) {
        throw new NotSupportedException("displayName parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "fileUri" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "fileUri" },
                              Common.GetValueByPath(fromObject, new string[] { "fileUri" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "mimeType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "mimeType" },
                              Common.GetValueByPath(fromObject, new string[] { "mimeType" }));
      }

      return toObject;
    }

    internal JsonNode FunctionDeclarationToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "behavior" }))) {
        throw new NotSupportedException("behavior parameter is not supported in Vertex AI.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "description" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "description" },
                              Common.GetValueByPath(fromObject, new string[] { "description" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "name" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "parameters" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "parameters" },
                              Common.GetValueByPath(fromObject, new string[] { "parameters" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "parametersJsonSchema" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "parametersJsonSchema" },
            Common.GetValueByPath(fromObject, new string[] { "parametersJsonSchema" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "response" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "response" },
                              Common.GetValueByPath(fromObject, new string[] { "response" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseJsonSchema" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseJsonSchema" },
            Common.GetValueByPath(fromObject, new string[] { "responseJsonSchema" }));
      }

      return toObject;
    }

    internal JsonNode GenerateContentConfigToMldev(ApiClient apiClient, JsonNode fromObject,
                                                   JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "systemInstruction" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "systemInstruction" },
            ContentToMldev(
                JsonNode.Parse(JsonSerializer.Serialize(Transformers.TContent(
                    Common.GetValueByPath(fromObject, new string[] { "systemInstruction" })))),
                toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "temperature" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "temperature" },
                              Common.GetValueByPath(fromObject, new string[] { "temperature" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "topP" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "topP" },
                              Common.GetValueByPath(fromObject, new string[] { "topP" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "topK" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "topK" },
                              Common.GetValueByPath(fromObject, new string[] { "topK" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "candidateCount" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "candidateCount" },
                              Common.GetValueByPath(fromObject, new string[] { "candidateCount" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "maxOutputTokens" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "maxOutputTokens" },
            Common.GetValueByPath(fromObject, new string[] { "maxOutputTokens" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "stopSequences" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "stopSequences" },
                              Common.GetValueByPath(fromObject, new string[] { "stopSequences" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseLogprobs" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseLogprobs" },
            Common.GetValueByPath(fromObject, new string[] { "responseLogprobs" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "logprobs" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "logprobs" },
                              Common.GetValueByPath(fromObject, new string[] { "logprobs" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "presencePenalty" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "presencePenalty" },
            Common.GetValueByPath(fromObject, new string[] { "presencePenalty" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "frequencyPenalty" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "frequencyPenalty" },
            Common.GetValueByPath(fromObject, new string[] { "frequencyPenalty" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "seed" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "seed" },
                              Common.GetValueByPath(fromObject, new string[] { "seed" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseMimeType" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseMimeType" },
            Common.GetValueByPath(fromObject, new string[] { "responseMimeType" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseSchema" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "responseSchema" },
                              Transformers.TSchema(Common.GetValueByPath(
                                  fromObject, new string[] { "responseSchema" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseJsonSchema" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseJsonSchema" },
            Common.GetValueByPath(fromObject, new string[] { "responseJsonSchema" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "routingConfig" }))) {
        throw new NotSupportedException("routingConfig parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "modelSelectionConfig" }))) {
        throw new NotSupportedException(
            "modelSelectionConfig parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "safetySettings" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "safetySettings" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(
              SafetySettingToMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(parentObject, new string[] { "safetySettings" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tools" }) != null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(fromObject, new string[] { "tools" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ToolToMldev(
              JsonNode.Parse(JsonSerializer.Serialize(Transformers.TTool(record))), toObject));
        }
        Common.SetValueByPath(parentObject, new string[] { "tools" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "toolConfig" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "toolConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "toolConfig" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "labels" }))) {
        throw new NotSupportedException("labels parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "cachedContent" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "cachedContent" },
            Transformers.TCachedContentName(
                this._apiClient,
                Common.GetValueByPath(fromObject, new string[] { "cachedContent" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseModalities" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseModalities" },
            Common.GetValueByPath(fromObject, new string[] { "responseModalities" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "mediaResolution" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "mediaResolution" },
            Common.GetValueByPath(fromObject, new string[] { "mediaResolution" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "speechConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "speechConfig" },
                              Transformers.TSpeechConfig(Common.GetValueByPath(
                                  fromObject, new string[] { "speechConfig" })));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "audioTimestamp" }))) {
        throw new NotSupportedException("audioTimestamp parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "thinkingConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "thinkingConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "thinkingConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "imageConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "imageConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "imageConfig" }));
      }

      return toObject;
    }

    internal JsonNode GenerateContentConfigToVertex(ApiClient apiClient, JsonNode fromObject,
                                                    JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "systemInstruction" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "systemInstruction" },
                              Transformers.TContent(Common.GetValueByPath(
                                  fromObject, new string[] { "systemInstruction" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "temperature" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "temperature" },
                              Common.GetValueByPath(fromObject, new string[] { "temperature" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "topP" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "topP" },
                              Common.GetValueByPath(fromObject, new string[] { "topP" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "topK" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "topK" },
                              Common.GetValueByPath(fromObject, new string[] { "topK" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "candidateCount" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "candidateCount" },
                              Common.GetValueByPath(fromObject, new string[] { "candidateCount" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "maxOutputTokens" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "maxOutputTokens" },
            Common.GetValueByPath(fromObject, new string[] { "maxOutputTokens" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "stopSequences" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "stopSequences" },
                              Common.GetValueByPath(fromObject, new string[] { "stopSequences" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseLogprobs" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseLogprobs" },
            Common.GetValueByPath(fromObject, new string[] { "responseLogprobs" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "logprobs" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "logprobs" },
                              Common.GetValueByPath(fromObject, new string[] { "logprobs" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "presencePenalty" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "presencePenalty" },
            Common.GetValueByPath(fromObject, new string[] { "presencePenalty" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "frequencyPenalty" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "frequencyPenalty" },
            Common.GetValueByPath(fromObject, new string[] { "frequencyPenalty" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "seed" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "seed" },
                              Common.GetValueByPath(fromObject, new string[] { "seed" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseMimeType" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseMimeType" },
            Common.GetValueByPath(fromObject, new string[] { "responseMimeType" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseSchema" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "responseSchema" },
                              Transformers.TSchema(Common.GetValueByPath(
                                  fromObject, new string[] { "responseSchema" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseJsonSchema" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseJsonSchema" },
            Common.GetValueByPath(fromObject, new string[] { "responseJsonSchema" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "routingConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "routingConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "routingConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "modelSelectionConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "modelConfig" },
            Common.GetValueByPath(fromObject, new string[] { "modelSelectionConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "safetySettings" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "safetySettings" },
                              Common.GetValueByPath(fromObject, new string[] { "safetySettings" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tools" }) != null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(fromObject, new string[] { "tools" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ToolToVertex(
              JsonNode.Parse(JsonSerializer.Serialize(Transformers.TTool(record))), toObject));
        }
        Common.SetValueByPath(parentObject, new string[] { "tools" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "toolConfig" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "toolConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "toolConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "labels" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "labels" },
                              Common.GetValueByPath(fromObject, new string[] { "labels" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "cachedContent" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "cachedContent" },
            Transformers.TCachedContentName(
                this._apiClient,
                Common.GetValueByPath(fromObject, new string[] { "cachedContent" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseModalities" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseModalities" },
            Common.GetValueByPath(fromObject, new string[] { "responseModalities" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "mediaResolution" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "mediaResolution" },
            Common.GetValueByPath(fromObject, new string[] { "mediaResolution" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "speechConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "speechConfig" },
            SpeechConfigToVertex(
                JsonNode.Parse(JsonSerializer.Serialize(Transformers.TSpeechConfig(
                    Common.GetValueByPath(fromObject, new string[] { "speechConfig" })))),
                toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "audioTimestamp" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "audioTimestamp" },
                              Common.GetValueByPath(fromObject, new string[] { "audioTimestamp" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "thinkingConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "thinkingConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "thinkingConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "imageConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "imageConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "imageConfig" }));
      }

      return toObject;
    }

    internal JsonNode GenerateContentParametersToMldev(ApiClient apiClient, JsonNode fromObject,
                                                       JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "model" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "contents" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "contents" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ContentToMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "contents" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "generationConfig" },
                              GenerateContentConfigToMldev(
                                  apiClient,
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "config" }))),
                                  toObject));
      }

      return toObject;
    }

    internal JsonNode GenerateContentParametersToVertex(ApiClient apiClient, JsonNode fromObject,
                                                        JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "model" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "contents" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "contents" },
            Transformers.TContents(Common.GetValueByPath(fromObject, new string[] { "contents" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "generationConfig" },
                              GenerateContentConfigToVertex(
                                  apiClient,
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "config" }))),
                                  toObject));
      }

      return toObject;
    }

    internal JsonNode GenerateContentResponseFromMldev(JsonNode fromObject,
                                                       JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "candidates" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "candidates" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(
              CandidateFromMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "candidates" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "modelVersion" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "modelVersion" },
                              Common.GetValueByPath(fromObject, new string[] { "modelVersion" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "promptFeedback" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "promptFeedback" },
                              Common.GetValueByPath(fromObject, new string[] { "promptFeedback" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseId" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "responseId" },
                              Common.GetValueByPath(fromObject, new string[] { "responseId" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "usageMetadata" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "usageMetadata" },
                              Common.GetValueByPath(fromObject, new string[] { "usageMetadata" }));
      }

      return toObject;
    }

    internal JsonNode GenerateContentResponseFromVertex(JsonNode fromObject,
                                                        JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "candidates" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "candidates" },
                              Common.GetValueByPath(fromObject, new string[] { "candidates" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "createTime" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "createTime" },
                              Common.GetValueByPath(fromObject, new string[] { "createTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "modelVersion" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "modelVersion" },
                              Common.GetValueByPath(fromObject, new string[] { "modelVersion" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "promptFeedback" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "promptFeedback" },
                              Common.GetValueByPath(fromObject, new string[] { "promptFeedback" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseId" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "responseId" },
                              Common.GetValueByPath(fromObject, new string[] { "responseId" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "usageMetadata" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "usageMetadata" },
                              Common.GetValueByPath(fromObject, new string[] { "usageMetadata" }));
      }

      return toObject;
    }

    internal JsonNode GenerateImagesConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "outputGcsUri" }))) {
        throw new NotSupportedException("outputGcsUri parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "negativePrompt" }))) {
        throw new NotSupportedException("negativePrompt parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "numberOfImages" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "sampleCount" },
                              Common.GetValueByPath(fromObject, new string[] { "numberOfImages" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "aspectRatio" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "aspectRatio" },
                              Common.GetValueByPath(fromObject, new string[] { "aspectRatio" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "guidanceScale" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "guidanceScale" },
                              Common.GetValueByPath(fromObject, new string[] { "guidanceScale" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "seed" }))) {
        throw new NotSupportedException("seed parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "safetyFilterLevel" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "safetySetting" },
            Common.GetValueByPath(fromObject, new string[] { "safetyFilterLevel" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "personGeneration" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "personGeneration" },
            Common.GetValueByPath(fromObject, new string[] { "personGeneration" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "includeSafetyAttributes" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "includeSafetyAttributes" },
            Common.GetValueByPath(fromObject, new string[] { "includeSafetyAttributes" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "includeRaiReason" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "includeRaiReason" },
            Common.GetValueByPath(fromObject, new string[] { "includeRaiReason" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "language" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "language" },
                              Common.GetValueByPath(fromObject, new string[] { "language" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputMimeType" }) != null) {
        Common.SetValueByPath(parentObject,
                              new string[] { "parameters", "outputOptions", "mimeType" },
                              Common.GetValueByPath(fromObject, new string[] { "outputMimeType" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputCompressionQuality" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "outputOptions", "compressionQuality" },
            Common.GetValueByPath(fromObject, new string[] { "outputCompressionQuality" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "addWatermark" }))) {
        throw new NotSupportedException("addWatermark parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "imageSize" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "sampleImageSize" },
                              Common.GetValueByPath(fromObject, new string[] { "imageSize" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "enhancePrompt" }))) {
        throw new NotSupportedException("enhancePrompt parameter is not supported in Gemini API.");
      }

      return toObject;
    }

    internal JsonNode GenerateImagesConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "outputGcsUri" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "storageUri" },
                              Common.GetValueByPath(fromObject, new string[] { "outputGcsUri" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "negativePrompt" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "negativePrompt" },
                              Common.GetValueByPath(fromObject, new string[] { "negativePrompt" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "numberOfImages" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "sampleCount" },
                              Common.GetValueByPath(fromObject, new string[] { "numberOfImages" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "aspectRatio" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "aspectRatio" },
                              Common.GetValueByPath(fromObject, new string[] { "aspectRatio" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "guidanceScale" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "guidanceScale" },
                              Common.GetValueByPath(fromObject, new string[] { "guidanceScale" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "seed" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "seed" },
                              Common.GetValueByPath(fromObject, new string[] { "seed" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "safetyFilterLevel" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "safetySetting" },
            Common.GetValueByPath(fromObject, new string[] { "safetyFilterLevel" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "personGeneration" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "personGeneration" },
            Common.GetValueByPath(fromObject, new string[] { "personGeneration" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "includeSafetyAttributes" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "includeSafetyAttributes" },
            Common.GetValueByPath(fromObject, new string[] { "includeSafetyAttributes" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "includeRaiReason" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "includeRaiReason" },
            Common.GetValueByPath(fromObject, new string[] { "includeRaiReason" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "language" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "language" },
                              Common.GetValueByPath(fromObject, new string[] { "language" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputMimeType" }) != null) {
        Common.SetValueByPath(parentObject,
                              new string[] { "parameters", "outputOptions", "mimeType" },
                              Common.GetValueByPath(fromObject, new string[] { "outputMimeType" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputCompressionQuality" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "outputOptions", "compressionQuality" },
            Common.GetValueByPath(fromObject, new string[] { "outputCompressionQuality" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "addWatermark" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "addWatermark" },
                              Common.GetValueByPath(fromObject, new string[] { "addWatermark" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "imageSize" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "sampleImageSize" },
                              Common.GetValueByPath(fromObject, new string[] { "imageSize" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "enhancePrompt" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "enhancePrompt" },
                              Common.GetValueByPath(fromObject, new string[] { "enhancePrompt" }));
      }

      return toObject;
    }

    internal JsonNode GenerateImagesParametersToMldev(ApiClient apiClient, JsonNode fromObject,
                                                      JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "model" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "prompt" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "instances[0]", "prompt" },
                              Common.GetValueByPath(fromObject, new string[] { "prompt" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = GenerateImagesConfigToMldev(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject);
      }

      return toObject;
    }

    internal JsonNode GenerateImagesParametersToVertex(ApiClient apiClient, JsonNode fromObject,
                                                       JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "model" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "prompt" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "instances[0]", "prompt" },
                              Common.GetValueByPath(fromObject, new string[] { "prompt" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = GenerateImagesConfigToVertex(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject);
      }

      return toObject;
    }

    internal JsonNode GenerateImagesResponseFromMldev(JsonNode fromObject,
                                                      JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "predictions" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "predictions" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(
              GeneratedImageFromMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "generatedImages" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "positivePromptSafetyAttributes" }) !=
          null) {
        Common.SetValueByPath(
            toObject, new string[] { "positivePromptSafetyAttributes" },
            SafetyAttributesFromMldev(
                JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                    fromObject, new string[] { "positivePromptSafetyAttributes" }))),
                toObject));
      }

      return toObject;
    }

    internal JsonNode GenerateImagesResponseFromVertex(JsonNode fromObject,
                                                       JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "predictions" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "predictions" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(
              GeneratedImageFromVertex(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "generatedImages" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "positivePromptSafetyAttributes" }) !=
          null) {
        Common.SetValueByPath(
            toObject, new string[] { "positivePromptSafetyAttributes" },
            SafetyAttributesFromVertex(
                JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                    fromObject, new string[] { "positivePromptSafetyAttributes" }))),
                toObject));
      }

      return toObject;
    }

    internal JsonNode GeneratedImageFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "_self" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "image" },
            ImageFromMldev(JsonNode.Parse(JsonSerializer.Serialize(
                               Common.GetValueByPath(fromObject, new string[] { "_self" }))),
                           toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "raiFilteredReason" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "raiFilteredReason" },
            Common.GetValueByPath(fromObject, new string[] { "raiFilteredReason" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "_self" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "safetyAttributes" },
            SafetyAttributesFromMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                          fromObject, new string[] { "_self" }))),
                                      toObject));
      }

      return toObject;
    }

    internal JsonNode GeneratedImageFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "_self" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "image" },
            ImageFromVertex(JsonNode.Parse(JsonSerializer.Serialize(
                                Common.GetValueByPath(fromObject, new string[] { "_self" }))),
                            toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "raiFilteredReason" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "raiFilteredReason" },
            Common.GetValueByPath(fromObject, new string[] { "raiFilteredReason" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "_self" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "safetyAttributes" },
                              SafetyAttributesFromVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(
                                      Common.GetValueByPath(fromObject, new string[] { "_self" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "prompt" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "enhancedPrompt" },
                              Common.GetValueByPath(fromObject, new string[] { "prompt" }));
      }

      return toObject;
    }

    internal JsonNode GoogleSearchToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "timeRangeFilter" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "timeRangeFilter" },
            Common.GetValueByPath(fromObject, new string[] { "timeRangeFilter" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "excludeDomains" }))) {
        throw new NotSupportedException("excludeDomains parameter is not supported in Gemini API.");
      }

      return toObject;
    }

    internal JsonNode ImageFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "bytesBase64Encoded" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "imageBytes" },
                              Transformers.TBytes(Common.GetValueByPath(
                                  fromObject, new string[] { "bytesBase64Encoded" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "mimeType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "mimeType" },
                              Common.GetValueByPath(fromObject, new string[] { "mimeType" }));
      }

      return toObject;
    }

    internal JsonNode ImageFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "gcsUri" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "gcsUri" },
                              Common.GetValueByPath(fromObject, new string[] { "gcsUri" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "bytesBase64Encoded" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "imageBytes" },
                              Transformers.TBytes(Common.GetValueByPath(
                                  fromObject, new string[] { "bytesBase64Encoded" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "mimeType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "mimeType" },
                              Common.GetValueByPath(fromObject, new string[] { "mimeType" }));
      }

      return toObject;
    }

    internal JsonNode ImageToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "gcsUri" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "gcsUri" },
                              Common.GetValueByPath(fromObject, new string[] { "gcsUri" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "imageBytes" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "bytesBase64Encoded" },
            Transformers.TBytes(Common.GetValueByPath(fromObject, new string[] { "imageBytes" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "mimeType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "mimeType" },
                              Common.GetValueByPath(fromObject, new string[] { "mimeType" }));
      }

      return toObject;
    }

    internal JsonNode PartToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "videoMetadata" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "videoMetadata" },
                              Common.GetValueByPath(fromObject, new string[] { "videoMetadata" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "thought" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "thought" },
                              Common.GetValueByPath(fromObject, new string[] { "thought" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "inlineData" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "inlineData" },
            BlobToMldev(JsonNode.Parse(JsonSerializer.Serialize(
                            Common.GetValueByPath(fromObject, new string[] { "inlineData" }))),
                        toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "fileData" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "fileData" },
            FileDataToMldev(JsonNode.Parse(JsonSerializer.Serialize(
                                Common.GetValueByPath(fromObject, new string[] { "fileData" }))),
                            toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "thoughtSignature" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "thoughtSignature" },
            Common.GetValueByPath(fromObject, new string[] { "thoughtSignature" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "functionCall" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "functionCall" },
                              Common.GetValueByPath(fromObject, new string[] { "functionCall" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "codeExecutionResult" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "codeExecutionResult" },
            Common.GetValueByPath(fromObject, new string[] { "codeExecutionResult" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "executableCode" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "executableCode" },
                              Common.GetValueByPath(fromObject, new string[] { "executableCode" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "functionResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "functionResponse" },
            Common.GetValueByPath(fromObject, new string[] { "functionResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "text" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "text" },
                              Common.GetValueByPath(fromObject, new string[] { "text" }));
      }

      return toObject;
    }

    internal JsonNode SafetyAttributesFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "safetyAttributes", "categories" }) !=
          null) {
        Common.SetValueByPath(
            toObject, new string[] { "categories" },
            Common.GetValueByPath(fromObject, new string[] { "safetyAttributes", "categories" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "safetyAttributes", "scores" }) !=
          null) {
        Common.SetValueByPath(
            toObject, new string[] { "scores" },
            Common.GetValueByPath(fromObject, new string[] { "safetyAttributes", "scores" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "contentType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "contentType" },
                              Common.GetValueByPath(fromObject, new string[] { "contentType" }));
      }

      return toObject;
    }

    internal JsonNode SafetyAttributesFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "safetyAttributes", "categories" }) !=
          null) {
        Common.SetValueByPath(
            toObject, new string[] { "categories" },
            Common.GetValueByPath(fromObject, new string[] { "safetyAttributes", "categories" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "safetyAttributes", "scores" }) !=
          null) {
        Common.SetValueByPath(
            toObject, new string[] { "scores" },
            Common.GetValueByPath(fromObject, new string[] { "safetyAttributes", "scores" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "contentType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "contentType" },
                              Common.GetValueByPath(fromObject, new string[] { "contentType" }));
      }

      return toObject;
    }

    internal JsonNode SafetySettingToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "method" }))) {
        throw new NotSupportedException("method parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "category" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "category" },
                              Common.GetValueByPath(fromObject, new string[] { "category" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "threshold" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "threshold" },
                              Common.GetValueByPath(fromObject, new string[] { "threshold" }));
      }

      return toObject;
    }

    internal JsonNode SpeechConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "voiceConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "voiceConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "voiceConfig" }));
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "multiSpeakerVoiceConfig" }))) {
        throw new NotSupportedException(
            "multiSpeakerVoiceConfig parameter is not supported in Vertex AI.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "languageCode" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "languageCode" },
                              Common.GetValueByPath(fromObject, new string[] { "languageCode" }));
      }

      return toObject;
    }

    internal JsonNode ToolToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "functionDeclarations" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "functionDeclarations" },
            Common.GetValueByPath(fromObject, new string[] { "functionDeclarations" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "retrieval" }))) {
        throw new NotSupportedException("retrieval parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "googleSearch" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "googleSearch" },
            GoogleSearchToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                    fromObject, new string[] { "googleSearch" }))),
                                toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "googleSearchRetrieval" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "googleSearchRetrieval" },
            Common.GetValueByPath(fromObject, new string[] { "googleSearchRetrieval" }));
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "enterpriseWebSearch" }))) {
        throw new NotSupportedException(
            "enterpriseWebSearch parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "googleMaps" }))) {
        throw new NotSupportedException("googleMaps parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "urlContext" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "urlContext" },
                              Common.GetValueByPath(fromObject, new string[] { "urlContext" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "computerUse" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "computerUse" },
                              Common.GetValueByPath(fromObject, new string[] { "computerUse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "codeExecution" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "codeExecution" },
                              Common.GetValueByPath(fromObject, new string[] { "codeExecution" }));
      }

      return toObject;
    }

    internal JsonNode ToolToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "functionDeclarations" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "functionDeclarations" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(FunctionDeclarationToVertex(JsonNode.Parse(JsonSerializer.Serialize(record)),
                                                 toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "functionDeclarations" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "retrieval" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "retrieval" },
                              Common.GetValueByPath(fromObject, new string[] { "retrieval" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "googleSearch" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "googleSearch" },
                              Common.GetValueByPath(fromObject, new string[] { "googleSearch" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "googleSearchRetrieval" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "googleSearchRetrieval" },
            Common.GetValueByPath(fromObject, new string[] { "googleSearchRetrieval" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "enterpriseWebSearch" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "enterpriseWebSearch" },
            Common.GetValueByPath(fromObject, new string[] { "enterpriseWebSearch" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "googleMaps" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "googleMaps" },
                              Common.GetValueByPath(fromObject, new string[] { "googleMaps" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "urlContext" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "urlContext" },
                              Common.GetValueByPath(fromObject, new string[] { "urlContext" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "computerUse" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "computerUse" },
                              Common.GetValueByPath(fromObject, new string[] { "computerUse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "codeExecution" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "codeExecution" },
                              Common.GetValueByPath(fromObject, new string[] { "codeExecution" }));
      }

      return toObject;
    }

    internal JsonNode UpscaleImageAPIConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "outputGcsUri" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "storageUri" },
                              Common.GetValueByPath(fromObject, new string[] { "outputGcsUri" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "includeRaiReason" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "includeRaiReason" },
            Common.GetValueByPath(fromObject, new string[] { "includeRaiReason" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputMimeType" }) != null) {
        Common.SetValueByPath(parentObject,
                              new string[] { "parameters", "outputOptions", "mimeType" },
                              Common.GetValueByPath(fromObject, new string[] { "outputMimeType" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputCompressionQuality" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "outputOptions", "compressionQuality" },
            Common.GetValueByPath(fromObject, new string[] { "outputCompressionQuality" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "enhanceInputImage" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "upscaleConfig", "enhanceInputImage" },
            Common.GetValueByPath(fromObject, new string[] { "enhanceInputImage" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "imagePreservationFactor" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "upscaleConfig", "imagePreservationFactor" },
            Common.GetValueByPath(fromObject, new string[] { "imagePreservationFactor" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "numberOfImages" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "sampleCount" },
                              Common.GetValueByPath(fromObject, new string[] { "numberOfImages" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "mode" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "mode" },
                              Common.GetValueByPath(fromObject, new string[] { "mode" }));
      }

      return toObject;
    }

    internal JsonNode UpscaleImageAPIParametersToVertex(ApiClient apiClient, JsonNode fromObject,
                                                        JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "model" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "image" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "instances[0]", "image" },
            ImageToVertex(JsonNode.Parse(JsonSerializer.Serialize(
                              Common.GetValueByPath(fromObject, new string[] { "image" }))),
                          toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "upscaleFactor" }) != null) {
        Common.SetValueByPath(toObject,
                              new string[] { "parameters", "upscaleConfig", "upscaleFactor" },
                              Common.GetValueByPath(fromObject, new string[] { "upscaleFactor" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = UpscaleImageAPIConfigToVertex(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject);
      }

      return toObject;
    }

    internal JsonNode UpscaleImageResponseFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "predictions" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "predictions" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(
              GeneratedImageFromVertex(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "generatedImages" }, result);
      }

      return toObject;
    }

    public Models(ApiClient apiClient) {
      _apiClient = apiClient;
    }

    private async Task<GenerateContentResponse> PrivateGenerateContentAsync(
        string model, List<Content> contents, GenerateContentConfig config) {
      GenerateContentParameters parameter = new GenerateContentParameters();

      if (!Common.IsZero(model)) {
        parameter.Model = model;
      }
      if (!Common.IsZero(contents)) {
        parameter.Contents = contents;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse GenerateContentParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = GenerateContentParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{model}:generateContent", body["_url"]);
      } else {
        body = GenerateContentParametersToMldev(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{model}:generateContent", body["_url"]);
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      // TODO: Handle "_query" in the body (for list support).
      bodyObj?.Remove("_query");
      HttpOptions? requestHttpOptions = config?.HttpOptions;

      ApiResponse response = await this._apiClient.RequestAsync(
          HttpMethod.Post, path, JsonSerializer.Serialize(body), requestHttpOptions);
      HttpContent httpContent = response.GetEntity();
      string contentString = await httpContent.ReadAsStringAsync();
      JsonNode? httpContentNode = JsonNode.Parse(contentString);
      if (httpContentNode == null) {
        throw new NotSupportedException("Failed to parse response to JsonNode.");
      }
      JsonNode responseNode = httpContentNode;

      if (this._apiClient.VertexAI) {
        responseNode = GenerateContentResponseFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        responseNode = GenerateContentResponseFromMldev(httpContentNode, new JsonObject());
      }

      return JsonSerializer.Deserialize<GenerateContentResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException(
                 "Failed to deserialize Task<GenerateContentResponse>.");
    }

    private async IAsyncEnumerable<GenerateContentResponse> PrivateGenerateContentStreamAsync(
        string model, List<Content> contents, GenerateContentConfig config) {
      GenerateContentParameters parameter = new GenerateContentParameters();

      if (!Common.IsZero(model)) {
        parameter.Model = model;
      }
      if (!Common.IsZero(contents)) {
        parameter.Contents = contents;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse GenerateContentParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = GenerateContentParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{model}:streamGenerateContent?alt=sse", body["_url"]);
      } else {
        body = GenerateContentParametersToMldev(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{model}:streamGenerateContent?alt=sse", body["_url"]);
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      // TODO: Handle "_query" in the body (for list support).
      bodyObj?.Remove("_query");
      HttpOptions? requestHttpOptions = config?.HttpOptions;

      await foreach (ApiResponse apiResponse in this._apiClient.RequestStreamAsync(
                         HttpMethod.Post, path, JsonSerializer.Serialize(body),
                         requestHttpOptions)) {
        string chunkJson = await apiResponse.GetEntity().ReadAsStringAsync();
        JsonNode? chunkNode = JsonNode.Parse(chunkJson);
        if (chunkNode == null)
          continue;
        JsonNode responseNode;
        if (this._apiClient.VertexAI) {
          responseNode = GenerateContentResponseFromVertex(chunkNode, new JsonObject());
        } else {
          responseNode = GenerateContentResponseFromMldev(chunkNode, new JsonObject());
        }
        var chunkResponse =
            JsonSerializer.Deserialize<GenerateContentResponse>(responseNode.ToString());
        yield return chunkResponse;
      }
    }

    private async Task<GenerateImagesResponse> PrivateGenerateImagesAsync(
        string model, string prompt, GenerateImagesConfig config) {
      GenerateImagesParameters parameter = new GenerateImagesParameters();

      if (!Common.IsZero(model)) {
        parameter.Model = model;
      }
      if (!Common.IsZero(prompt)) {
        parameter.Prompt = prompt;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse GenerateImagesParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = GenerateImagesParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{model}:predict", body["_url"]);
      } else {
        body = GenerateImagesParametersToMldev(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{model}:predict", body["_url"]);
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      // TODO: Handle "_query" in the body (for list support).
      bodyObj?.Remove("_query");
      HttpOptions? requestHttpOptions = config?.HttpOptions;

      ApiResponse response = await this._apiClient.RequestAsync(
          HttpMethod.Post, path, JsonSerializer.Serialize(body), requestHttpOptions);
      HttpContent httpContent = response.GetEntity();
      string contentString = await httpContent.ReadAsStringAsync();
      JsonNode? httpContentNode = JsonNode.Parse(contentString);
      if (httpContentNode == null) {
        throw new NotSupportedException("Failed to parse response to JsonNode.");
      }
      JsonNode responseNode = httpContentNode;

      if (this._apiClient.VertexAI) {
        responseNode = GenerateImagesResponseFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        responseNode = GenerateImagesResponseFromMldev(httpContentNode, new JsonObject());
      }

      return JsonSerializer.Deserialize<GenerateImagesResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException(
                 "Failed to deserialize Task<GenerateImagesResponse>.");
    }

    private async Task<UpscaleImageResponse> PrivateUpscaleImageAsync(
        string model, Image image, string upscaleFactor, UpscaleImageAPIConfig config) {
      UpscaleImageAPIParameters parameter = new UpscaleImageAPIParameters();

      if (!Common.IsZero(model)) {
        parameter.Model = model;
      }
      if (!Common.IsZero(image)) {
        parameter.Image = image;
      }
      if (!Common.IsZero(upscaleFactor)) {
        parameter.UpscaleFactor = upscaleFactor;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse UpscaleImageAPIParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = UpscaleImageAPIParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{model}:predict", body["_url"]);
      } else {
        throw new NotSupportedException("This method is only supported in the Vertex AI client.");
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      // TODO: Handle "_query" in the body (for list support).
      bodyObj?.Remove("_query");
      HttpOptions? requestHttpOptions = config?.HttpOptions;

      ApiResponse response = await this._apiClient.RequestAsync(
          HttpMethod.Post, path, JsonSerializer.Serialize(body), requestHttpOptions);
      HttpContent httpContent = response.GetEntity();
      string contentString = await httpContent.ReadAsStringAsync();
      JsonNode? httpContentNode = JsonNode.Parse(contentString);
      if (httpContentNode == null) {
        throw new NotSupportedException("Failed to parse response to JsonNode.");
      }
      JsonNode responseNode = httpContentNode;

      if (this._apiClient.VertexAI) {
        responseNode = UpscaleImageResponseFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        throw new NotSupportedException("This method is only supported in the Vertex AI client.");
      }

      return JsonSerializer.Deserialize<UpscaleImageResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException(
                 "Failed to deserialize Task<UpscaleImageResponse>.");
    }

    /// <summary>
    /// Generates content given a GenAI model and a list of content.
    /// </summary>
    /// <param name="model">The name of the GenAI model to use for generation.</param>
    /// <param name="contents">A <see cref="List{Content}"/> to send to the generative
    /// model.</param> <param name="config">A <see cref="GenerateContentConfig"/> instance that
    /// specifies the optional configurations.</param> <returns>A <see
    /// cref="Task{GenerateContentResponse}"/> that represents the asynchronous operation. The task
    /// result contains a <see cref="GenerateContentResponse"/> instance with response contents and
    /// other metadata.</returns>
    public async Task<GenerateContentResponse> GenerateContentAsync(
        string model, List<Content> contents, GenerateContentConfig? config = null) {
      return await PrivateGenerateContentAsync(model, contents, config);
    }

    /// <summary>
    /// Generates content given a GenAI model and a single content item.
    /// </summary>
    /// <param name="model">The name of the GenAI model to use for generation.</param>
    /// <param name="contents">A <see cref="Content"/> instance to send to the generative
    /// model.</param> <param name="config">A <see cref="GenerateContentConfig"/> instance that
    /// specifies the optional configurations.</param> <returns>A <see
    /// cref="Task{GenerateContentResponse}"/> that represents the asynchronous operation. The task
    /// result contains a <see cref="GenerateContentResponse"/> instance with response contents and
    /// other metadata.</returns>
    public async Task<GenerateContentResponse> GenerateContentAsync(
        string model, Content contents, GenerateContentConfig? config = null) {
      List<Content> contentList = Transformers.TContents(contents) ?? new List<Content>();
      return await GenerateContentAsync(model, contentList, config);
    }

    /// <summary>
    /// Generates content given a GenAI model and a text string.
    /// </summary>
    /// <param name="model">The name of the GenAI model to use for generation.</param>
    /// <param name="contents">A text string to send to the generative model.</param>
    /// <param name="config">A <see cref="GenerateContentConfig"/> instance that specifies the
    /// optional configurations.</param> <returns>A <see cref="Task{GenerateContentResponse}"/> that
    /// represents the asynchronous operation. The task result contains a <see
    /// cref="GenerateContentResponse"/> instance with response contents and other
    /// metadata.</returns>
    public async Task<GenerateContentResponse> GenerateContentAsync(
        string model, string contents, GenerateContentConfig? config = null) {
      List<Content> contentList = Transformers.TContents(contents) ?? new List<Content>();
      return await GenerateContentAsync(model, contentList, config);
    }

    /// <summary>
    /// Generates content with streaming responses given a GenAI model and a list of content.
    /// </summary>
    /// <param name="model">The name of the GenAI model to use for generation.</param>
    /// <param name="contents">A <see cref="List{Content}"/> to send to the generative
    /// model.</param> <param name="config">A <see cref="GenerateContentConfig"/> instance that
    /// specifies the optional configurations.</param> <returns>An async enumerable of <see
    /// cref="GenerateContentResponse"/> chunks.</returns>
    public async IAsyncEnumerable<GenerateContentResponse> GenerateContentStreamAsync(
        string model, List<Content> contents, GenerateContentConfig? config = null) {
      await foreach (var response in PrivateGenerateContentStreamAsync(model, contents, config)) {
        yield return response;
      }
    }

    /// <summary>
    /// Generates content with streaming responses given a GenAI model and a single content item.
    /// </summary>
    /// <param name="model">The name of the GenAI model to use for generation.</param>
    /// <param name="contents">A <see cref="Content"/> instance to send to the generative
    /// model.</param> <param name="config">A <see cref="GenerateContentConfig"/> instance that
    /// specifies the optional configurations.</param> <returns>An async enumerable of <see
    /// cref="GenerateContentResponse"/> chunks.</returns>
    public async IAsyncEnumerable<GenerateContentResponse> GenerateContentStreamAsync(
        string model, Content contents, GenerateContentConfig? config = null) {
      List<Content> contentList = Transformers.TContents(contents) ?? new List<Content>();
      await foreach (var response in GenerateContentStreamAsync(model, contentList, config)) {
        yield return response;
      }
    }

    /// <summary>
    /// Generates content with streaming responses given a GenAI model and a text string.
    /// </summary>
    /// <param name="model">The name of the GenAI model to use for generation.</param>
    /// <param name="contents">A text string to send to the generative model.</param>
    /// <param name="config">A <see cref="GenerateContentConfig"/> instance that specifies the
    /// optional configurations.</param> <returns>An async enumerable of <see
    /// cref="GenerateContentResponse"/> chunks.</returns>
    public async IAsyncEnumerable<GenerateContentResponse> GenerateContentStreamAsync(
        string model, string contents, GenerateContentConfig? config = null) {
      List<Content> contentList = Transformers.TContents(contents) ?? new List<Content>();
      await foreach (var response in GenerateContentStreamAsync(model, contentList, config)) {
        yield return response;
      }
    }

    /// <summary>
    /// Generates images given a GenAI model and a prompt.
    /// </summary>
    /// <param name="model">The name of the GenAI model to use for generation.</param>
    /// <param name="prompt">A text prompt string to send to the generative model.</param>
    /// <param name="config">A <see cref="GenerateImagesConfig"/> instance that specifies the
    /// optional configurations.</param> <returns>A <see cref="Task{GenerateImagesResponse}"/> that
    /// represents the asynchronous operation. The task result contains a <see
    /// cref="GenerateImagesResponse"/> instance with response contents and other
    /// metadata.</returns>
    public async Task<GenerateImagesResponse> GenerateImagesAsync(
        string model, string prompt, GenerateImagesConfig? config = null) {
      GenerateImagesResponse apiResponse = await PrivateGenerateImagesAsync(model, prompt, config);
      SafetyAttributes? positivePromptSafetyAttributes = null;
      List<GeneratedImage> generatedImages = new List<GeneratedImage>();

      if (apiResponse.GeneratedImages != null) {
        foreach (var generatedImage in apiResponse.GeneratedImages) {
          if (generatedImage.SafetyAttributes?.ContentType == "Positive Prompt") {
            positivePromptSafetyAttributes = generatedImage.SafetyAttributes;
          } else {
            generatedImages.Add(generatedImage);
          }
        }
      }

      var response = new GenerateImagesResponse { GeneratedImages = generatedImages };

      if (positivePromptSafetyAttributes != null) {
        response.PositivePromptSafetyAttributes = positivePromptSafetyAttributes;
      }

      return response;
    }

    public async Task<UpscaleImageResponse> UpscaleImageAsync(String model, Image image,
                                                              String upscaleFactor,
                                                              UpscaleImageConfig? config = null) {
      UpscaleImageAPIConfig apiConfig = new UpscaleImageAPIConfig {
        Mode = "upscale",
        NumberOfImages = 1,
      };

      if (config != null) {
        apiConfig.OutputGcsUri = config.OutputGcsUri;
        apiConfig.OutputMimeType = config.OutputMimeType;
        apiConfig.OutputCompressionQuality = config.OutputCompressionQuality;
        apiConfig.IncludeRaiReason = config.IncludeRaiReason;
        apiConfig.EnhanceInputImage = config.EnhanceInputImage;
        apiConfig.ImagePreservationFactor = config.ImagePreservationFactor;
      }

      return await PrivateUpscaleImageAsync(model, image, upscaleFactor, apiConfig);
    }
  }
}
