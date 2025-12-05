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

    internal JsonNode AuthConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "apiKey" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "apiKey" },
                              Common.GetValueByPath(fromObject, new string[] { "apiKey" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "apiKeyConfig" }))) {
        throw new NotSupportedException("apiKeyConfig parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "authType" }))) {
        throw new NotSupportedException("authType parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "googleServiceAccountConfig" }))) {
        throw new NotSupportedException(
            "googleServiceAccountConfig parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "httpBasicAuthConfig" }))) {
        throw new NotSupportedException(
            "httpBasicAuthConfig parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "oauthConfig" }))) {
        throw new NotSupportedException("oauthConfig parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "oidcConfig" }))) {
        throw new NotSupportedException("oidcConfig parameter is not supported in Gemini API.");
      }

      return toObject;
    }

    internal JsonNode BlobToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "data" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "data" },
                              Common.GetValueByPath(fromObject, new string[] { "data" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "displayName" }))) {
        throw new NotSupportedException("displayName parameter is not supported in Gemini API.");
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

      if (Common.GetValueByPath(fromObject, new string[] { "groundingMetadata" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "groundingMetadata" },
            Common.GetValueByPath(fromObject, new string[] { "groundingMetadata" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "avgLogprobs" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "avgLogprobs" },
                              Common.GetValueByPath(fromObject, new string[] { "avgLogprobs" }));
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

      if (Common.GetValueByPath(fromObject, new string[] { "urlContextMetadata" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "urlContextMetadata" },
            Common.GetValueByPath(fromObject, new string[] { "urlContextMetadata" }));
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

    internal JsonNode ComputeTokensParametersToVertex(ApiClient apiClient, JsonNode fromObject,
                                                      JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "model" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "contents" }) != null) {
        var keyList =
            Transformers.TContents(Common.GetValueByPath(fromObject, new string[] { "contents" }));
        JsonArray result = new JsonArray();

        foreach (var record in keyList) {
          result.Add(ContentToVertex(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "contents" }, result);
      }

      return toObject;
    }

    internal JsonNode ComputeTokensResponseFromVertex(JsonNode fromObject,
                                                      JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tokensInfo" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "tokensInfo" },
                              Common.GetValueByPath(fromObject, new string[] { "tokensInfo" }));
      }

      return toObject;
    }

    internal JsonNode ContentEmbeddingFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "values" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "values" },
                              Common.GetValueByPath(fromObject, new string[] { "values" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "statistics" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "statistics" },
                              ContentEmbeddingStatisticsFromVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "statistics" }))),
                                  toObject));
      }

      return toObject;
    }

    internal JsonNode ContentEmbeddingStatisticsFromVertex(JsonNode fromObject,
                                                           JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "truncated" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "truncated" },
                              Common.GetValueByPath(fromObject, new string[] { "truncated" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "token_count" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "tokenCount" },
                              Common.GetValueByPath(fromObject, new string[] { "token_count" }));
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

    internal JsonNode ContentToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "parts" }) != null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(fromObject, new string[] { "parts" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(PartToVertex(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "parts" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "role" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "role" },
                              Common.GetValueByPath(fromObject, new string[] { "role" }));
      }

      return toObject;
    }

    internal JsonNode ControlReferenceConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "controlType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "controlType" },
                              Common.GetValueByPath(fromObject, new string[] { "controlType" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "enableControlImageComputation" }) !=
          null) {
        Common.SetValueByPath(
            toObject, new string[] { "computeControl" },
            Common.GetValueByPath(fromObject, new string[] { "enableControlImageComputation" }));
      }

      return toObject;
    }

    internal JsonNode CountTokensConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "systemInstruction" }))) {
        throw new NotSupportedException(
            "systemInstruction parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "tools" }))) {
        throw new NotSupportedException("tools parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "generationConfig" }))) {
        throw new NotSupportedException(
            "generationConfig parameter is not supported in Gemini API.");
      }

      return toObject;
    }

    internal JsonNode CountTokensConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "systemInstruction" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "systemInstruction" },
            ContentToVertex(
                JsonNode.Parse(JsonSerializer.Serialize(Transformers.TContent(
                    Common.GetValueByPath(fromObject, new string[] { "systemInstruction" })))),
                toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tools" }) != null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(fromObject, new string[] { "tools" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ToolToVertex(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(parentObject, new string[] { "tools" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "generationConfig" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "generationConfig" },
            GenerationConfigToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                         fromObject, new string[] { "generationConfig" }))),
                                     toObject));
      }

      return toObject;
    }

    internal JsonNode CountTokensParametersToMldev(ApiClient apiClient, JsonNode fromObject,
                                                   JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "model" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "contents" }) != null) {
        var keyList =
            Transformers.TContents(Common.GetValueByPath(fromObject, new string[] { "contents" }));
        JsonArray result = new JsonArray();

        foreach (var record in keyList) {
          result.Add(ContentToMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "contents" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = CountTokensConfigToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                         fromObject, new string[] { "config" }))),
                                     toObject);
      }

      return toObject;
    }

    internal JsonNode CountTokensParametersToVertex(ApiClient apiClient, JsonNode fromObject,
                                                    JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "model" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "contents" }) != null) {
        var keyList =
            Transformers.TContents(Common.GetValueByPath(fromObject, new string[] { "contents" }));
        JsonArray result = new JsonArray();

        foreach (var record in keyList) {
          result.Add(ContentToVertex(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "contents" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = CountTokensConfigToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                          fromObject, new string[] { "config" }))),
                                      toObject);
      }

      return toObject;
    }

    internal JsonNode CountTokensResponseFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "totalTokens" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "totalTokens" },
                              Common.GetValueByPath(fromObject, new string[] { "totalTokens" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "cachedContentTokenCount" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "cachedContentTokenCount" },
            Common.GetValueByPath(fromObject, new string[] { "cachedContentTokenCount" }));
      }

      return toObject;
    }

    internal JsonNode CountTokensResponseFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "totalTokens" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "totalTokens" },
                              Common.GetValueByPath(fromObject, new string[] { "totalTokens" }));
      }

      return toObject;
    }

    internal JsonNode DeleteModelParametersToMldev(ApiClient apiClient, JsonNode fromObject,
                                                   JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "name" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      return toObject;
    }

    internal JsonNode DeleteModelParametersToVertex(ApiClient apiClient, JsonNode fromObject,
                                                    JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "name" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      return toObject;
    }

    internal JsonNode DeleteModelResponseFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      return toObject;
    }

    internal JsonNode DeleteModelResponseFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      return toObject;
    }

    internal JsonNode EditImageConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
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

      if (Common.GetValueByPath(fromObject, new string[] { "labels" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "labels" },
                              Common.GetValueByPath(fromObject, new string[] { "labels" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "editMode" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "editMode" },
                              Common.GetValueByPath(fromObject, new string[] { "editMode" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "baseSteps" }) != null) {
        Common.SetValueByPath(parentObject,
                              new string[] { "parameters", "editConfig", "baseSteps" },
                              Common.GetValueByPath(fromObject, new string[] { "baseSteps" }));
      }

      return toObject;
    }

    internal JsonNode EditImageParametersToVertex(ApiClient apiClient, JsonNode fromObject,
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

      if (Common.GetValueByPath(fromObject, new string[] { "referenceImages" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "referenceImages" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ReferenceImageAPIToVertex(JsonNode.Parse(JsonSerializer.Serialize(record)),
                                               toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "instances[0]", "referenceImages" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = EditImageConfigToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                        fromObject, new string[] { "config" }))),
                                    toObject);
      }

      return toObject;
    }

    internal JsonNode EditImageResponseFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

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

    internal JsonNode EmbedContentConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "taskType" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "requests[]", "taskType" },
                              Common.GetValueByPath(fromObject, new string[] { "taskType" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "title" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "requests[]", "title" },
                              Common.GetValueByPath(fromObject, new string[] { "title" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputDimensionality" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "requests[]", "outputDimensionality" },
            Common.GetValueByPath(fromObject, new string[] { "outputDimensionality" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "mimeType" }))) {
        throw new NotSupportedException("mimeType parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "autoTruncate" }))) {
        throw new NotSupportedException("autoTruncate parameter is not supported in Gemini API.");
      }

      return toObject;
    }

    internal JsonNode EmbedContentConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "taskType" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "instances[]", "task_type" },
                              Common.GetValueByPath(fromObject, new string[] { "taskType" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "title" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "instances[]", "title" },
                              Common.GetValueByPath(fromObject, new string[] { "title" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputDimensionality" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "outputDimensionality" },
            Common.GetValueByPath(fromObject, new string[] { "outputDimensionality" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "mimeType" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "instances[]", "mimeType" },
                              Common.GetValueByPath(fromObject, new string[] { "mimeType" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "autoTruncate" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "autoTruncate" },
                              Common.GetValueByPath(fromObject, new string[] { "autoTruncate" }));
      }

      return toObject;
    }

    internal JsonNode EmbedContentParametersToMldev(ApiClient apiClient, JsonNode fromObject,
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
            toObject, new string[] { "requests[]", "content" },
            Transformers.TContentsForEmbed(
                this._apiClient, Common.GetValueByPath(fromObject, new string[] { "contents" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = EmbedContentConfigToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                          fromObject, new string[] { "config" }))),
                                      toObject);
      }

      Common.SetValueByPath(
          toObject, new string[] { "requests[]", "model" },
          Transformers.TModel(this._apiClient,
                              Common.GetValueByPath(fromObject, new string[] { "model" })));

      return toObject;
    }

    internal JsonNode EmbedContentParametersToVertex(ApiClient apiClient, JsonNode fromObject,
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
            toObject, new string[] { "instances[]", "content" },
            Transformers.TContentsForEmbed(
                this._apiClient, Common.GetValueByPath(fromObject, new string[] { "contents" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = EmbedContentConfigToVertex(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject);
      }

      return toObject;
    }

    internal JsonNode EmbedContentResponseFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "embeddings" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "embeddings" },
                              Common.GetValueByPath(fromObject, new string[] { "embeddings" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "metadata" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "metadata" },
                              Common.GetValueByPath(fromObject, new string[] { "metadata" }));
      }

      return toObject;
    }

    internal JsonNode EmbedContentResponseFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "predictions[]", "embeddings" }) !=
          null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(
            fromObject, new string[] { "predictions[]", "embeddings" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ContentEmbeddingFromVertex(JsonNode.Parse(JsonSerializer.Serialize(record)),
                                                toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "embeddings" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "metadata" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "metadata" },
                              Common.GetValueByPath(fromObject, new string[] { "metadata" }));
      }

      return toObject;
    }

    internal JsonNode EndpointFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "endpoint" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "name" },
                              Common.GetValueByPath(fromObject, new string[] { "endpoint" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "deployedModelId" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "deployedModelId" },
            Common.GetValueByPath(fromObject, new string[] { "deployedModelId" }));
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

    internal JsonNode FileSearchToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "" }))) {
        throw new NotSupportedException(" parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "" }))) {
        throw new NotSupportedException(" parameter is not supported in Gemini API.");
      }

      return toObject;
    }

    internal JsonNode FunctionCallToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "id" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "id" },
                              Common.GetValueByPath(fromObject, new string[] { "id" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "args" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "args" },
                              Common.GetValueByPath(fromObject, new string[] { "args" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "name" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "partialArgs" }))) {
        throw new NotSupportedException("partialArgs parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "willContinue" }))) {
        throw new NotSupportedException("willContinue parameter is not supported in Gemini API.");
      }

      return toObject;
    }

    internal JsonNode FunctionCallingConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "mode" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "mode" },
                              Common.GetValueByPath(fromObject, new string[] { "mode" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "allowedFunctionNames" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "allowedFunctionNames" },
            Common.GetValueByPath(fromObject, new string[] { "allowedFunctionNames" }));
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "streamFunctionCallArguments" }))) {
        throw new NotSupportedException(
            "streamFunctionCallArguments parameter is not supported in Gemini API.");
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
        var keyList =
            Transformers.TTools(Common.GetValueByPath(fromObject, new string[] { "tools" }));
        JsonArray result = new JsonArray();

        foreach (var record in keyList) {
          result.Add(ToolToMldev(
              JsonNode.Parse(JsonSerializer.Serialize(Transformers.TTool(record))), toObject));
        }
        Common.SetValueByPath(parentObject, new string[] { "tools" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "toolConfig" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "toolConfig" },
            ToolConfigToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                  fromObject, new string[] { "toolConfig" }))),
                              toObject));
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
        Common.SetValueByPath(
            toObject, new string[] { "speechConfig" },
            SpeechConfigToMldev(
                JsonNode.Parse(JsonSerializer.Serialize(Transformers.TSpeechConfig(
                    Common.GetValueByPath(fromObject, new string[] { "speechConfig" })))),
                toObject));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "audioTimestamp" }))) {
        throw new NotSupportedException("audioTimestamp parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "thinkingConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "thinkingConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "thinkingConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "imageConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "imageConfig" },
            ImageConfigToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                   fromObject, new string[] { "imageConfig" }))),
                               toObject));
      }

      return toObject;
    }

    internal JsonNode GenerateContentConfigToVertex(ApiClient apiClient, JsonNode fromObject,
                                                    JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "systemInstruction" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "systemInstruction" },
            ContentToVertex(
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
        var keyList =
            Transformers.TTools(Common.GetValueByPath(fromObject, new string[] { "tools" }));
        JsonArray result = new JsonArray();

        foreach (var record in keyList) {
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
        Common.SetValueByPath(toObject, new string[] { "speechConfig" },
                              Transformers.TSpeechConfig(Common.GetValueByPath(
                                  fromObject, new string[] { "speechConfig" })));
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
        Common.SetValueByPath(
            toObject, new string[] { "imageConfig" },
            ImageConfigToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                    fromObject, new string[] { "imageConfig" }))),
                                toObject));
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
        var keyList =
            Transformers.TContents(Common.GetValueByPath(fromObject, new string[] { "contents" }));
        JsonArray result = new JsonArray();

        foreach (var record in keyList) {
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
        var keyList =
            Transformers.TContents(Common.GetValueByPath(fromObject, new string[] { "contents" }));
        JsonArray result = new JsonArray();

        foreach (var record in keyList) {
          result.Add(ContentToVertex(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "contents" }, result);
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

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

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

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

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

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "labels" }))) {
        throw new NotSupportedException("labels parameter is not supported in Gemini API.");
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

      if (Common.GetValueByPath(fromObject, new string[] { "labels" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "labels" },
                              Common.GetValueByPath(fromObject, new string[] { "labels" }));
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

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

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

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

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

    internal JsonNode GenerateVideosConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "numberOfVideos" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "sampleCount" },
                              Common.GetValueByPath(fromObject, new string[] { "numberOfVideos" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "outputGcsUri" }))) {
        throw new NotSupportedException("outputGcsUri parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "fps" }))) {
        throw new NotSupportedException("fps parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "durationSeconds" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "durationSeconds" },
            Common.GetValueByPath(fromObject, new string[] { "durationSeconds" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "seed" }))) {
        throw new NotSupportedException("seed parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "aspectRatio" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "aspectRatio" },
                              Common.GetValueByPath(fromObject, new string[] { "aspectRatio" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "resolution" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "resolution" },
                              Common.GetValueByPath(fromObject, new string[] { "resolution" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "personGeneration" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "personGeneration" },
            Common.GetValueByPath(fromObject, new string[] { "personGeneration" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "pubsubTopic" }))) {
        throw new NotSupportedException("pubsubTopic parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "negativePrompt" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "negativePrompt" },
                              Common.GetValueByPath(fromObject, new string[] { "negativePrompt" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "enhancePrompt" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "enhancePrompt" },
                              Common.GetValueByPath(fromObject, new string[] { "enhancePrompt" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "generateAudio" }))) {
        throw new NotSupportedException("generateAudio parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "lastFrame" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "instances[0]", "lastFrame" },
            ImageToMldev(JsonNode.Parse(JsonSerializer.Serialize(
                             Common.GetValueByPath(fromObject, new string[] { "lastFrame" }))),
                         toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "referenceImages" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "referenceImages" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(VideoGenerationReferenceImageToMldev(
              JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(parentObject, new string[] { "instances[0]", "referenceImages" },
                              result);
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "mask" }))) {
        throw new NotSupportedException("mask parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "compressionQuality" }))) {
        throw new NotSupportedException(
            "compressionQuality parameter is not supported in Gemini API.");
      }

      return toObject;
    }

    internal JsonNode GenerateVideosConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "numberOfVideos" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "sampleCount" },
                              Common.GetValueByPath(fromObject, new string[] { "numberOfVideos" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputGcsUri" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "storageUri" },
                              Common.GetValueByPath(fromObject, new string[] { "outputGcsUri" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "fps" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "fps" },
                              Common.GetValueByPath(fromObject, new string[] { "fps" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "durationSeconds" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "durationSeconds" },
            Common.GetValueByPath(fromObject, new string[] { "durationSeconds" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "seed" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "seed" },
                              Common.GetValueByPath(fromObject, new string[] { "seed" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "aspectRatio" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "aspectRatio" },
                              Common.GetValueByPath(fromObject, new string[] { "aspectRatio" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "resolution" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "resolution" },
                              Common.GetValueByPath(fromObject, new string[] { "resolution" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "personGeneration" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "personGeneration" },
            Common.GetValueByPath(fromObject, new string[] { "personGeneration" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "pubsubTopic" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "pubsubTopic" },
                              Common.GetValueByPath(fromObject, new string[] { "pubsubTopic" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "negativePrompt" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "negativePrompt" },
                              Common.GetValueByPath(fromObject, new string[] { "negativePrompt" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "enhancePrompt" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "enhancePrompt" },
                              Common.GetValueByPath(fromObject, new string[] { "enhancePrompt" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "generateAudio" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "generateAudio" },
                              Common.GetValueByPath(fromObject, new string[] { "generateAudio" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "lastFrame" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "instances[0]", "lastFrame" },
            ImageToVertex(JsonNode.Parse(JsonSerializer.Serialize(
                              Common.GetValueByPath(fromObject, new string[] { "lastFrame" }))),
                          toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "referenceImages" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "referenceImages" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(VideoGenerationReferenceImageToVertex(
              JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(parentObject, new string[] { "instances[0]", "referenceImages" },
                              result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "mask" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "instances[0]", "mask" },
                              VideoGenerationMaskToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(
                                      Common.GetValueByPath(fromObject, new string[] { "mask" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "compressionQuality" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "compressionQuality" },
            Common.GetValueByPath(fromObject, new string[] { "compressionQuality" }));
      }

      return toObject;
    }

    internal JsonNode GenerateVideosOperationFromMldev(JsonNode fromObject,
                                                       JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "name" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "metadata" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "metadata" },
                              Common.GetValueByPath(fromObject, new string[] { "metadata" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "done" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "done" },
                              Common.GetValueByPath(fromObject, new string[] { "done" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "error" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "error" },
                              Common.GetValueByPath(fromObject, new string[] { "error" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "response", "generateVideoResponse" }) !=
          null) {
        Common.SetValueByPath(
            toObject, new string[] { "response" },
            GenerateVideosResponseFromMldev(
                JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                    fromObject, new string[] { "response", "generateVideoResponse" }))),
                toObject));
      }

      return toObject;
    }

    internal JsonNode GenerateVideosOperationFromVertex(JsonNode fromObject,
                                                        JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "name" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "metadata" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "metadata" },
                              Common.GetValueByPath(fromObject, new string[] { "metadata" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "done" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "done" },
                              Common.GetValueByPath(fromObject, new string[] { "done" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "error" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "error" },
                              Common.GetValueByPath(fromObject, new string[] { "error" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "response" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "response" },
                              GenerateVideosResponseFromVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "response" }))),
                                  toObject));
      }

      return toObject;
    }

    internal JsonNode GenerateVideosParametersToMldev(ApiClient apiClient, JsonNode fromObject,
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

      if (Common.GetValueByPath(fromObject, new string[] { "image" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "instances[0]", "image" },
            ImageToMldev(JsonNode.Parse(JsonSerializer.Serialize(
                             Common.GetValueByPath(fromObject, new string[] { "image" }))),
                         toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "video" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "instances[0]", "video" },
            VideoToMldev(JsonNode.Parse(JsonSerializer.Serialize(
                             Common.GetValueByPath(fromObject, new string[] { "video" }))),
                         toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "source" }) != null) {
        _ = GenerateVideosSourceToMldev(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "source" }))),
            toObject);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = GenerateVideosConfigToMldev(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject);
      }

      return toObject;
    }

    internal JsonNode GenerateVideosParametersToVertex(ApiClient apiClient, JsonNode fromObject,
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

      if (Common.GetValueByPath(fromObject, new string[] { "image" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "instances[0]", "image" },
            ImageToVertex(JsonNode.Parse(JsonSerializer.Serialize(
                              Common.GetValueByPath(fromObject, new string[] { "image" }))),
                          toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "video" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "instances[0]", "video" },
            VideoToVertex(JsonNode.Parse(JsonSerializer.Serialize(
                              Common.GetValueByPath(fromObject, new string[] { "video" }))),
                          toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "source" }) != null) {
        _ = GenerateVideosSourceToVertex(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "source" }))),
            toObject);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = GenerateVideosConfigToVertex(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject);
      }

      return toObject;
    }

    internal JsonNode GenerateVideosResponseFromMldev(JsonNode fromObject,
                                                      JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "generatedSamples" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "generatedSamples" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(
              GeneratedVideoFromMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "generatedVideos" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "raiMediaFilteredCount" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "raiMediaFilteredCount" },
            Common.GetValueByPath(fromObject, new string[] { "raiMediaFilteredCount" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "raiMediaFilteredReasons" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "raiMediaFilteredReasons" },
            Common.GetValueByPath(fromObject, new string[] { "raiMediaFilteredReasons" }));
      }

      return toObject;
    }

    internal JsonNode GenerateVideosResponseFromVertex(JsonNode fromObject,
                                                       JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "videos" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "videos" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(
              GeneratedVideoFromVertex(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "generatedVideos" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "raiMediaFilteredCount" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "raiMediaFilteredCount" },
            Common.GetValueByPath(fromObject, new string[] { "raiMediaFilteredCount" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "raiMediaFilteredReasons" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "raiMediaFilteredReasons" },
            Common.GetValueByPath(fromObject, new string[] { "raiMediaFilteredReasons" }));
      }

      return toObject;
    }

    internal JsonNode GenerateVideosSourceToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "prompt" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "instances[0]", "prompt" },
                              Common.GetValueByPath(fromObject, new string[] { "prompt" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "image" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "instances[0]", "image" },
            ImageToMldev(JsonNode.Parse(JsonSerializer.Serialize(
                             Common.GetValueByPath(fromObject, new string[] { "image" }))),
                         toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "video" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "instances[0]", "video" },
            VideoToMldev(JsonNode.Parse(JsonSerializer.Serialize(
                             Common.GetValueByPath(fromObject, new string[] { "video" }))),
                         toObject));
      }

      return toObject;
    }

    internal JsonNode GenerateVideosSourceToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "prompt" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "instances[0]", "prompt" },
                              Common.GetValueByPath(fromObject, new string[] { "prompt" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "image" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "instances[0]", "image" },
            ImageToVertex(JsonNode.Parse(JsonSerializer.Serialize(
                              Common.GetValueByPath(fromObject, new string[] { "image" }))),
                          toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "video" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "instances[0]", "video" },
            VideoToVertex(JsonNode.Parse(JsonSerializer.Serialize(
                              Common.GetValueByPath(fromObject, new string[] { "video" }))),
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

    internal JsonNode GeneratedImageMaskFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "_self" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "mask" },
            ImageFromVertex(JsonNode.Parse(JsonSerializer.Serialize(
                                Common.GetValueByPath(fromObject, new string[] { "_self" }))),
                            toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "labels" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "labels" },
                              Common.GetValueByPath(fromObject, new string[] { "labels" }));
      }

      return toObject;
    }

    internal JsonNode GeneratedVideoFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "video" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "video" },
            VideoFromMldev(JsonNode.Parse(JsonSerializer.Serialize(
                               Common.GetValueByPath(fromObject, new string[] { "video" }))),
                           toObject));
      }

      return toObject;
    }

    internal JsonNode GeneratedVideoFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "_self" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "video" },
            VideoFromVertex(JsonNode.Parse(JsonSerializer.Serialize(
                                Common.GetValueByPath(fromObject, new string[] { "_self" }))),
                            toObject));
      }

      return toObject;
    }

    internal JsonNode GenerationConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "modelSelectionConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "modelConfig" },
            Common.GetValueByPath(fromObject, new string[] { "modelSelectionConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseJsonSchema" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseJsonSchema" },
            Common.GetValueByPath(fromObject, new string[] { "responseJsonSchema" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "audioTimestamp" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "audioTimestamp" },
                              Common.GetValueByPath(fromObject, new string[] { "audioTimestamp" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "candidateCount" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "candidateCount" },
                              Common.GetValueByPath(fromObject, new string[] { "candidateCount" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "enableAffectiveDialog" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "enableAffectiveDialog" },
            Common.GetValueByPath(fromObject, new string[] { "enableAffectiveDialog" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "frequencyPenalty" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "frequencyPenalty" },
            Common.GetValueByPath(fromObject, new string[] { "frequencyPenalty" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "logprobs" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "logprobs" },
                              Common.GetValueByPath(fromObject, new string[] { "logprobs" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "maxOutputTokens" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "maxOutputTokens" },
            Common.GetValueByPath(fromObject, new string[] { "maxOutputTokens" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "mediaResolution" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "mediaResolution" },
            Common.GetValueByPath(fromObject, new string[] { "mediaResolution" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "presencePenalty" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "presencePenalty" },
            Common.GetValueByPath(fromObject, new string[] { "presencePenalty" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseLogprobs" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseLogprobs" },
            Common.GetValueByPath(fromObject, new string[] { "responseLogprobs" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseMimeType" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseMimeType" },
            Common.GetValueByPath(fromObject, new string[] { "responseMimeType" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseModalities" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseModalities" },
            Common.GetValueByPath(fromObject, new string[] { "responseModalities" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseSchema" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "responseSchema" },
                              Common.GetValueByPath(fromObject, new string[] { "responseSchema" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "routingConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "routingConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "routingConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "seed" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "seed" },
                              Common.GetValueByPath(fromObject, new string[] { "seed" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "speechConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "speechConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "speechConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "stopSequences" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "stopSequences" },
                              Common.GetValueByPath(fromObject, new string[] { "stopSequences" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "temperature" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "temperature" },
                              Common.GetValueByPath(fromObject, new string[] { "temperature" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "thinkingConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "thinkingConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "thinkingConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "topK" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "topK" },
                              Common.GetValueByPath(fromObject, new string[] { "topK" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "topP" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "topP" },
                              Common.GetValueByPath(fromObject, new string[] { "topP" }));
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "enableEnhancedCivicAnswers" }))) {
        throw new NotSupportedException(
            "enableEnhancedCivicAnswers parameter is not supported in Vertex AI.");
      }

      return toObject;
    }

    internal JsonNode GetModelParametersToMldev(ApiClient apiClient, JsonNode fromObject,
                                                JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "name" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      return toObject;
    }

    internal JsonNode GetModelParametersToVertex(ApiClient apiClient, JsonNode fromObject,
                                                 JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "name" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      return toObject;
    }

    internal JsonNode GoogleMapsToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "authConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "authConfig" },
            AuthConfigToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                  fromObject, new string[] { "authConfig" }))),
                              toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "enableWidget" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "enableWidget" },
                              Common.GetValueByPath(fromObject, new string[] { "enableWidget" }));
      }

      return toObject;
    }

    internal JsonNode GoogleSearchToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "blockingConfidence" }))) {
        throw new NotSupportedException(
            "blockingConfidence parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "excludeDomains" }))) {
        throw new NotSupportedException("excludeDomains parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "timeRangeFilter" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "timeRangeFilter" },
            Common.GetValueByPath(fromObject, new string[] { "timeRangeFilter" }));
      }

      return toObject;
    }

    internal JsonNode ImageConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "aspectRatio" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "aspectRatio" },
                              Common.GetValueByPath(fromObject, new string[] { "aspectRatio" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "imageSize" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "imageSize" },
                              Common.GetValueByPath(fromObject, new string[] { "imageSize" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "outputMimeType" }))) {
        throw new NotSupportedException("outputMimeType parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "outputCompressionQuality" }))) {
        throw new NotSupportedException(
            "outputCompressionQuality parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "imageOutputOptions" }))) {
        throw new NotSupportedException(
            "imageOutputOptions parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "personGeneration" }))) {
        throw new NotSupportedException(
            "personGeneration parameter is not supported in Gemini API.");
      }

      return toObject;
    }

    internal JsonNode ImageConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "aspectRatio" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "aspectRatio" },
                              Common.GetValueByPath(fromObject, new string[] { "aspectRatio" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "imageSize" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "imageSize" },
                              Common.GetValueByPath(fromObject, new string[] { "imageSize" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputMimeType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "imageOutputOptions", "mimeType" },
                              Common.GetValueByPath(fromObject, new string[] { "outputMimeType" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputCompressionQuality" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "imageOutputOptions", "compressionQuality" },
            Common.GetValueByPath(fromObject, new string[] { "outputCompressionQuality" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "imageOutputOptions" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "imageOutputOptions" },
            Common.GetValueByPath(fromObject, new string[] { "imageOutputOptions" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "personGeneration" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "personGeneration" },
            Common.GetValueByPath(fromObject, new string[] { "personGeneration" }));
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

    internal JsonNode ImageToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "gcsUri" }))) {
        throw new NotSupportedException("gcsUri parameter is not supported in Gemini API.");
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

    internal JsonNode ListModelsConfigToMldev(ApiClient apiClient, JsonNode fromObject,
                                              JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "pageSize" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "_query", "pageSize" },
                              Common.GetValueByPath(fromObject, new string[] { "pageSize" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "pageToken" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "_query", "pageToken" },
                              Common.GetValueByPath(fromObject, new string[] { "pageToken" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "filter" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "_query", "filter" },
                              Common.GetValueByPath(fromObject, new string[] { "filter" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "queryBase" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "_url", "models_url" },
            Transformers.TModelsUrl(
                this._apiClient, Common.GetValueByPath(fromObject, new string[] { "queryBase" })));
      }

      return toObject;
    }

    internal JsonNode ListModelsConfigToVertex(ApiClient apiClient, JsonNode fromObject,
                                               JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "pageSize" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "_query", "pageSize" },
                              Common.GetValueByPath(fromObject, new string[] { "pageSize" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "pageToken" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "_query", "pageToken" },
                              Common.GetValueByPath(fromObject, new string[] { "pageToken" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "filter" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "_query", "filter" },
                              Common.GetValueByPath(fromObject, new string[] { "filter" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "queryBase" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "_url", "models_url" },
            Transformers.TModelsUrl(
                this._apiClient, Common.GetValueByPath(fromObject, new string[] { "queryBase" })));
      }

      return toObject;
    }

    internal JsonNode ListModelsParametersToMldev(ApiClient apiClient, JsonNode fromObject,
                                                  JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = ListModelsConfigToMldev(apiClient,
                                    JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                        fromObject, new string[] { "config" }))),
                                    toObject);
      }

      return toObject;
    }

    internal JsonNode ListModelsParametersToVertex(ApiClient apiClient, JsonNode fromObject,
                                                   JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = ListModelsConfigToVertex(apiClient,
                                     JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                         fromObject, new string[] { "config" }))),
                                     toObject);
      }

      return toObject;
    }

    internal JsonNode ListModelsResponseFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "nextPageToken" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "nextPageToken" },
                              Common.GetValueByPath(fromObject, new string[] { "nextPageToken" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "_self" }) != null) {
        JsonArray keyArray = (JsonArray)Transformers.TExtractModels(
            Common.GetValueByPath(fromObject, new string[] { "_self" }));
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ModelFromMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "models" }, result);
      }

      return toObject;
    }

    internal JsonNode ListModelsResponseFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "nextPageToken" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "nextPageToken" },
                              Common.GetValueByPath(fromObject, new string[] { "nextPageToken" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "_self" }) != null) {
        JsonArray keyArray = (JsonArray)Transformers.TExtractModels(
            Common.GetValueByPath(fromObject, new string[] { "_self" }));
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ModelFromVertex(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "models" }, result);
      }

      return toObject;
    }

    internal JsonNode MaskReferenceConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "maskMode" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "maskMode" },
                              Common.GetValueByPath(fromObject, new string[] { "maskMode" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "segmentationClasses" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "maskClasses" },
            Common.GetValueByPath(fromObject, new string[] { "segmentationClasses" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "maskDilation" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "dilation" },
                              Common.GetValueByPath(fromObject, new string[] { "maskDilation" }));
      }

      return toObject;
    }

    internal JsonNode ModelFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "name" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "displayName" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "displayName" },
                              Common.GetValueByPath(fromObject, new string[] { "displayName" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "description" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "description" },
                              Common.GetValueByPath(fromObject, new string[] { "description" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "version" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "version" },
                              Common.GetValueByPath(fromObject, new string[] { "version" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "_self" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "tunedModelInfo" },
                              Common.GetValueByPath(fromObject, new string[] { "_self" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "inputTokenLimit" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "inputTokenLimit" },
            Common.GetValueByPath(fromObject, new string[] { "inputTokenLimit" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputTokenLimit" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "outputTokenLimit" },
            Common.GetValueByPath(fromObject, new string[] { "outputTokenLimit" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "supportedGenerationMethods" }) !=
          null) {
        Common.SetValueByPath(
            toObject, new string[] { "supportedActions" },
            Common.GetValueByPath(fromObject, new string[] { "supportedGenerationMethods" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "temperature" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "temperature" },
                              Common.GetValueByPath(fromObject, new string[] { "temperature" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "maxTemperature" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "maxTemperature" },
                              Common.GetValueByPath(fromObject, new string[] { "maxTemperature" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "topP" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "topP" },
                              Common.GetValueByPath(fromObject, new string[] { "topP" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "topK" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "topK" },
                              Common.GetValueByPath(fromObject, new string[] { "topK" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "thinking" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "thinking" },
                              Common.GetValueByPath(fromObject, new string[] { "thinking" }));
      }

      return toObject;
    }

    internal JsonNode ModelFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "name" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "displayName" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "displayName" },
                              Common.GetValueByPath(fromObject, new string[] { "displayName" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "description" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "description" },
                              Common.GetValueByPath(fromObject, new string[] { "description" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "versionId" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "version" },
                              Common.GetValueByPath(fromObject, new string[] { "versionId" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "deployedModels" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "deployedModels" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(
              EndpointFromVertex(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "endpoints" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "labels" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "labels" },
                              Common.GetValueByPath(fromObject, new string[] { "labels" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "_self" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "tunedModelInfo" },
            TunedModelInfoFromVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                         fromObject, new string[] { "_self" }))),
                                     toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "defaultCheckpointId" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "defaultCheckpointId" },
            Common.GetValueByPath(fromObject, new string[] { "defaultCheckpointId" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "checkpoints" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "checkpoints" },
                              Common.GetValueByPath(fromObject, new string[] { "checkpoints" }));
      }

      return toObject;
    }

    internal JsonNode MultiSpeakerVoiceConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "speakerVoiceConfigs" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "speakerVoiceConfigs" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(SpeakerVoiceConfigToMldev(JsonNode.Parse(JsonSerializer.Serialize(record)),
                                               toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "speakerVoiceConfigs" }, result);
      }

      return toObject;
    }

    internal JsonNode PartToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "mediaResolution" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "mediaResolution" },
            Common.GetValueByPath(fromObject, new string[] { "mediaResolution" }));
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

      if (Common.GetValueByPath(fromObject, new string[] { "fileData" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "fileData" },
            FileDataToMldev(JsonNode.Parse(JsonSerializer.Serialize(
                                Common.GetValueByPath(fromObject, new string[] { "fileData" }))),
                            toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "functionCall" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "functionCall" },
            FunctionCallToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                    fromObject, new string[] { "functionCall" }))),
                                toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "functionResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "functionResponse" },
            Common.GetValueByPath(fromObject, new string[] { "functionResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "inlineData" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "inlineData" },
            BlobToMldev(JsonNode.Parse(JsonSerializer.Serialize(
                            Common.GetValueByPath(fromObject, new string[] { "inlineData" }))),
                        toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "text" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "text" },
                              Common.GetValueByPath(fromObject, new string[] { "text" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "thought" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "thought" },
                              Common.GetValueByPath(fromObject, new string[] { "thought" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "thoughtSignature" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "thoughtSignature" },
            Common.GetValueByPath(fromObject, new string[] { "thoughtSignature" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "videoMetadata" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "videoMetadata" },
                              Common.GetValueByPath(fromObject, new string[] { "videoMetadata" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "partMetadata" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "partMetadata" },
                              Common.GetValueByPath(fromObject, new string[] { "partMetadata" }));
      }

      return toObject;
    }

    internal JsonNode PartToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "mediaResolution" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "mediaResolution" },
            Common.GetValueByPath(fromObject, new string[] { "mediaResolution" }));
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

      if (Common.GetValueByPath(fromObject, new string[] { "fileData" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "fileData" },
                              Common.GetValueByPath(fromObject, new string[] { "fileData" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "functionCall" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "functionCall" },
                              Common.GetValueByPath(fromObject, new string[] { "functionCall" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "functionResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "functionResponse" },
            Common.GetValueByPath(fromObject, new string[] { "functionResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "inlineData" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "inlineData" },
                              Common.GetValueByPath(fromObject, new string[] { "inlineData" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "text" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "text" },
                              Common.GetValueByPath(fromObject, new string[] { "text" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "thought" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "thought" },
                              Common.GetValueByPath(fromObject, new string[] { "thought" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "thoughtSignature" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "thoughtSignature" },
            Common.GetValueByPath(fromObject, new string[] { "thoughtSignature" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "videoMetadata" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "videoMetadata" },
                              Common.GetValueByPath(fromObject, new string[] { "videoMetadata" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "partMetadata" }))) {
        throw new NotSupportedException("partMetadata parameter is not supported in Vertex AI.");
      }

      return toObject;
    }

    internal JsonNode ProductImageToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "productImage" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "image" },
            ImageToVertex(JsonNode.Parse(JsonSerializer.Serialize(
                              Common.GetValueByPath(fromObject, new string[] { "productImage" }))),
                          toObject));
      }

      return toObject;
    }

    internal JsonNode RecontextImageConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "numberOfImages" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "sampleCount" },
                              Common.GetValueByPath(fromObject, new string[] { "numberOfImages" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "baseSteps" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "baseSteps" },
                              Common.GetValueByPath(fromObject, new string[] { "baseSteps" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputGcsUri" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "storageUri" },
                              Common.GetValueByPath(fromObject, new string[] { "outputGcsUri" }));
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

      if (Common.GetValueByPath(fromObject, new string[] { "addWatermark" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "addWatermark" },
                              Common.GetValueByPath(fromObject, new string[] { "addWatermark" }));
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

      if (Common.GetValueByPath(fromObject, new string[] { "enhancePrompt" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "enhancePrompt" },
                              Common.GetValueByPath(fromObject, new string[] { "enhancePrompt" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "labels" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "labels" },
                              Common.GetValueByPath(fromObject, new string[] { "labels" }));
      }

      return toObject;
    }

    internal JsonNode RecontextImageParametersToVertex(ApiClient apiClient, JsonNode fromObject,
                                                       JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "model" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "source" }) != null) {
        _ = RecontextImageSourceToVertex(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "source" }))),
            toObject);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = RecontextImageConfigToVertex(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject);
      }

      return toObject;
    }

    internal JsonNode RecontextImageResponseFromVertex(JsonNode fromObject,
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

      return toObject;
    }

    internal JsonNode RecontextImageSourceToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "prompt" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "instances[0]", "prompt" },
                              Common.GetValueByPath(fromObject, new string[] { "prompt" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "personImage" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "instances[0]", "personImage", "image" },
            ImageToVertex(JsonNode.Parse(JsonSerializer.Serialize(
                              Common.GetValueByPath(fromObject, new string[] { "personImage" }))),
                          toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "productImages" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "productImages" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(
              ProductImageToVertex(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(parentObject, new string[] { "instances[0]", "productImages" },
                              result);
      }

      return toObject;
    }

    internal JsonNode ReferenceImageAPIToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "referenceImage" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "referenceImage" },
            ImageToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                              fromObject, new string[] { "referenceImage" }))),
                          toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "referenceId" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "referenceId" },
                              Common.GetValueByPath(fromObject, new string[] { "referenceId" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "referenceType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "referenceType" },
                              Common.GetValueByPath(fromObject, new string[] { "referenceType" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "maskImageConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "maskImageConfig" },
                              MaskReferenceConfigToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "maskImageConfig" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "controlImageConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "controlImageConfig" },
                              ControlReferenceConfigToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "controlImageConfig" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "styleImageConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "styleImageConfig" },
            Common.GetValueByPath(fromObject, new string[] { "styleImageConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "subjectImageConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "subjectImageConfig" },
            Common.GetValueByPath(fromObject, new string[] { "subjectImageConfig" }));
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

      if (Common.GetValueByPath(fromObject, new string[] { "category" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "category" },
                              Common.GetValueByPath(fromObject, new string[] { "category" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "method" }))) {
        throw new NotSupportedException("method parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "threshold" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "threshold" },
                              Common.GetValueByPath(fromObject, new string[] { "threshold" }));
      }

      return toObject;
    }

    internal JsonNode ScribbleImageToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "image" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "image" },
            ImageToVertex(JsonNode.Parse(JsonSerializer.Serialize(
                              Common.GetValueByPath(fromObject, new string[] { "image" }))),
                          toObject));
      }

      return toObject;
    }

    internal JsonNode SegmentImageConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "mode" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "mode" },
                              Common.GetValueByPath(fromObject, new string[] { "mode" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "maxPredictions" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "maxPredictions" },
                              Common.GetValueByPath(fromObject, new string[] { "maxPredictions" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "confidenceThreshold" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "confidenceThreshold" },
            Common.GetValueByPath(fromObject, new string[] { "confidenceThreshold" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "maskDilation" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "maskDilation" },
                              Common.GetValueByPath(fromObject, new string[] { "maskDilation" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "binaryColorThreshold" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "parameters", "binaryColorThreshold" },
            Common.GetValueByPath(fromObject, new string[] { "binaryColorThreshold" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "labels" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "labels" },
                              Common.GetValueByPath(fromObject, new string[] { "labels" }));
      }

      return toObject;
    }

    internal JsonNode SegmentImageParametersToVertex(ApiClient apiClient, JsonNode fromObject,
                                                     JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "model" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "source" }) != null) {
        _ = SegmentImageSourceToVertex(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "source" }))),
            toObject);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = SegmentImageConfigToVertex(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject);
      }

      return toObject;
    }

    internal JsonNode SegmentImageResponseFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "predictions" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "predictions" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(GeneratedImageMaskFromVertex(JsonNode.Parse(JsonSerializer.Serialize(record)),
                                                  toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "generatedMasks" }, result);
      }

      return toObject;
    }

    internal JsonNode SegmentImageSourceToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "prompt" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "instances[0]", "prompt" },
                              Common.GetValueByPath(fromObject, new string[] { "prompt" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "image" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "instances[0]", "image" },
            ImageToVertex(JsonNode.Parse(JsonSerializer.Serialize(
                              Common.GetValueByPath(fromObject, new string[] { "image" }))),
                          toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "scribbleImage" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "instances[0]", "scribble" },
            ScribbleImageToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "scribbleImage" }))),
                                  toObject));
      }

      return toObject;
    }

    internal JsonNode SpeakerVoiceConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "speaker" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "speaker" },
                              Common.GetValueByPath(fromObject, new string[] { "speaker" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "voiceConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "voiceConfig" },
            VoiceConfigToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                   fromObject, new string[] { "voiceConfig" }))),
                               toObject));
      }

      return toObject;
    }

    internal JsonNode SpeechConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "languageCode" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "languageCode" },
                              Common.GetValueByPath(fromObject, new string[] { "languageCode" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "multiSpeakerVoiceConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "multiSpeakerVoiceConfig" },
                              MultiSpeakerVoiceConfigToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "multiSpeakerVoiceConfig" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "voiceConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "voiceConfig" },
            VoiceConfigToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                   fromObject, new string[] { "voiceConfig" }))),
                               toObject));
      }

      return toObject;
    }

    internal JsonNode ToolConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "functionCallingConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "functionCallingConfig" },
                              FunctionCallingConfigToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "functionCallingConfig" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "retrievalConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "retrievalConfig" },
            Common.GetValueByPath(fromObject, new string[] { "retrievalConfig" }));
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

      if (Common.GetValueByPath(fromObject, new string[] { "googleSearchRetrieval" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "googleSearchRetrieval" },
            Common.GetValueByPath(fromObject, new string[] { "googleSearchRetrieval" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "computerUse" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "computerUse" },
                              Common.GetValueByPath(fromObject, new string[] { "computerUse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "googleMaps" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "googleMaps" },
            GoogleMapsToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                  fromObject, new string[] { "googleMaps" }))),
                              toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "codeExecution" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "codeExecution" },
                              Common.GetValueByPath(fromObject, new string[] { "codeExecution" }));
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "enterpriseWebSearch" }))) {
        throw new NotSupportedException(
            "enterpriseWebSearch parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "googleSearch" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "googleSearch" },
            GoogleSearchToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                    fromObject, new string[] { "googleSearch" }))),
                                toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "urlContext" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "urlContext" },
                              Common.GetValueByPath(fromObject, new string[] { "urlContext" }));
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

      if (Common.GetValueByPath(fromObject, new string[] { "googleSearchRetrieval" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "googleSearchRetrieval" },
            Common.GetValueByPath(fromObject, new string[] { "googleSearchRetrieval" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "computerUse" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "computerUse" },
                              Common.GetValueByPath(fromObject, new string[] { "computerUse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "googleMaps" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "googleMaps" },
                              Common.GetValueByPath(fromObject, new string[] { "googleMaps" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "codeExecution" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "codeExecution" },
                              Common.GetValueByPath(fromObject, new string[] { "codeExecution" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "enterpriseWebSearch" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "enterpriseWebSearch" },
            Common.GetValueByPath(fromObject, new string[] { "enterpriseWebSearch" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "googleSearch" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "googleSearch" },
                              Common.GetValueByPath(fromObject, new string[] { "googleSearch" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "urlContext" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "urlContext" },
                              Common.GetValueByPath(fromObject, new string[] { "urlContext" }));
      }

      return toObject;
    }

    internal JsonNode TunedModelInfoFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(
              fromObject, new string[] { "labels", "google-vertex-llm-tuning-base-model-id" }) !=
          null) {
        Common.SetValueByPath(
            toObject, new string[] { "baseModel" },
            Common.GetValueByPath(
                fromObject, new string[] { "labels", "google-vertex-llm-tuning-base-model-id" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "createTime" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "createTime" },
                              Common.GetValueByPath(fromObject, new string[] { "createTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "updateTime" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "updateTime" },
                              Common.GetValueByPath(fromObject, new string[] { "updateTime" }));
      }

      return toObject;
    }

    internal JsonNode UpdateModelConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "displayName" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "displayName" },
                              Common.GetValueByPath(fromObject, new string[] { "displayName" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "description" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "description" },
                              Common.GetValueByPath(fromObject, new string[] { "description" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "defaultCheckpointId" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "defaultCheckpointId" },
            Common.GetValueByPath(fromObject, new string[] { "defaultCheckpointId" }));
      }

      return toObject;
    }

    internal JsonNode UpdateModelConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "displayName" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "displayName" },
                              Common.GetValueByPath(fromObject, new string[] { "displayName" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "description" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "description" },
                              Common.GetValueByPath(fromObject, new string[] { "description" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "defaultCheckpointId" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "defaultCheckpointId" },
            Common.GetValueByPath(fromObject, new string[] { "defaultCheckpointId" }));
      }

      return toObject;
    }

    internal JsonNode UpdateModelParametersToMldev(ApiClient apiClient, JsonNode fromObject,
                                                   JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "name" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = UpdateModelConfigToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                         fromObject, new string[] { "config" }))),
                                     toObject);
      }

      return toObject;
    }

    internal JsonNode UpdateModelParametersToVertex(ApiClient apiClient, JsonNode fromObject,
                                                    JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "model" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = UpdateModelConfigToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                          fromObject, new string[] { "config" }))),
                                      toObject);
      }

      return toObject;
    }

    internal JsonNode UpscaleImageAPIConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "outputGcsUri" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "parameters", "storageUri" },
                              Common.GetValueByPath(fromObject, new string[] { "outputGcsUri" }));
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

      if (Common.GetValueByPath(fromObject, new string[] { "labels" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "labels" },
                              Common.GetValueByPath(fromObject, new string[] { "labels" }));
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

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

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

    internal JsonNode VideoFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "uri" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "uri" },
                              Common.GetValueByPath(fromObject, new string[] { "uri" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "encodedVideo" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "videoBytes" },
                              Transformers.TBytes(Common.GetValueByPath(
                                  fromObject, new string[] { "encodedVideo" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "encoding" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "mimeType" },
                              Common.GetValueByPath(fromObject, new string[] { "encoding" }));
      }

      return toObject;
    }

    internal JsonNode VideoFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "gcsUri" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "uri" },
                              Common.GetValueByPath(fromObject, new string[] { "gcsUri" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "bytesBase64Encoded" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "videoBytes" },
                              Transformers.TBytes(Common.GetValueByPath(
                                  fromObject, new string[] { "bytesBase64Encoded" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "mimeType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "mimeType" },
                              Common.GetValueByPath(fromObject, new string[] { "mimeType" }));
      }

      return toObject;
    }

    internal JsonNode VideoGenerationMaskToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "image" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_self" },
            ImageToVertex(JsonNode.Parse(JsonSerializer.Serialize(
                              Common.GetValueByPath(fromObject, new string[] { "image" }))),
                          toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "maskMode" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "maskMode" },
                              Common.GetValueByPath(fromObject, new string[] { "maskMode" }));
      }

      return toObject;
    }

    internal JsonNode VideoGenerationReferenceImageToMldev(JsonNode fromObject,
                                                           JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "image" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "image" },
            ImageToMldev(JsonNode.Parse(JsonSerializer.Serialize(
                             Common.GetValueByPath(fromObject, new string[] { "image" }))),
                         toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "referenceType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "referenceType" },
                              Common.GetValueByPath(fromObject, new string[] { "referenceType" }));
      }

      return toObject;
    }

    internal JsonNode VideoGenerationReferenceImageToVertex(JsonNode fromObject,
                                                            JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "image" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "image" },
            ImageToVertex(JsonNode.Parse(JsonSerializer.Serialize(
                              Common.GetValueByPath(fromObject, new string[] { "image" }))),
                          toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "referenceType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "referenceType" },
                              Common.GetValueByPath(fromObject, new string[] { "referenceType" }));
      }

      return toObject;
    }

    internal JsonNode VideoToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "uri" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "uri" },
                              Common.GetValueByPath(fromObject, new string[] { "uri" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "videoBytes" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "encodedVideo" },
            Transformers.TBytes(Common.GetValueByPath(fromObject, new string[] { "videoBytes" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "mimeType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "encoding" },
                              Common.GetValueByPath(fromObject, new string[] { "mimeType" }));
      }

      return toObject;
    }

    internal JsonNode VideoToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "uri" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "gcsUri" },
                              Common.GetValueByPath(fromObject, new string[] { "uri" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "videoBytes" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "bytesBase64Encoded" },
            Transformers.TBytes(Common.GetValueByPath(fromObject, new string[] { "videoBytes" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "mimeType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "mimeType" },
                              Common.GetValueByPath(fromObject, new string[] { "mimeType" }));
      }

      return toObject;
    }

    internal JsonNode VoiceConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "prebuiltVoiceConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "prebuiltVoiceConfig" },
            Common.GetValueByPath(fromObject, new string[] { "prebuiltVoiceConfig" }));
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "replicatedVoiceConfig" }))) {
        throw new NotSupportedException(
            "replicatedVoiceConfig parameter is not supported in Gemini API.");
      }

      return toObject;
    }

    public Models(ApiClient apiClient) {
      _apiClient = apiClient;
    }

    private async Task<GenerateContentResponse> PrivateGenerateContentAsync(
        string model, List<Content> contents, GenerateContentConfig? config) {
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
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
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
        string model, List<Content> contents, GenerateContentConfig? config) {
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
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
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

    /// <summary>
    /// Calculates embeddings for the given contents.
    /// </summary>
    /// <param name="model">The model to use for embedding.</param>
    /// <param name="contents">A <see cref="List{Content}"/> to calculate embeddings for.</param>
    /// <param name="config">An <see cref="EmbedContentConfig"/> instance that specifies the
    /// optional configurations.</param>
    /// <returns>A <see cref="Task{EmbedContentResponse}"/> that represents the asynchronous
    /// operation. The task result contains a <see cref="EmbedContentResponse"/> instance with
    /// embeddings and other metadata.</returns>

    public async Task<EmbedContentResponse> EmbedContentAsync(string model, List<Content> contents,
                                                              EmbedContentConfig? config = null) {
      EmbedContentParameters parameter = new EmbedContentParameters();

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
        throw new NotSupportedException("Failed to parse EmbedContentParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = EmbedContentParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{model}:predict", body["_url"]);
      } else {
        body = EmbedContentParametersToMldev(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{model}:batchEmbedContents", body["_url"]);
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
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
        responseNode = EmbedContentResponseFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        responseNode = EmbedContentResponseFromMldev(httpContentNode, new JsonObject());
      }

      return JsonSerializer.Deserialize<EmbedContentResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException(
                 "Failed to deserialize Task<EmbedContentResponse>.");
    }

    private async Task<GenerateImagesResponse> PrivateGenerateImagesAsync(
        string model, string prompt, GenerateImagesConfig? config) {
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
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
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

    private async Task<EditImageResponse> PrivateEditImageAsync(
        string model, string prompt, List<ReferenceImageAPI> referenceImages,
        EditImageConfig? config) {
      EditImageParameters parameter = new EditImageParameters();

      if (!Common.IsZero(model)) {
        parameter.Model = model;
      }
      if (!Common.IsZero(prompt)) {
        parameter.Prompt = prompt;
      }
      if (!Common.IsZero(referenceImages)) {
        parameter.ReferenceImages = referenceImages;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse EditImageParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = EditImageParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{model}:predict", body["_url"]);
      } else {
        throw new NotSupportedException("This method is only supported in the Vertex AI client.");
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
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
        responseNode = EditImageResponseFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        throw new NotSupportedException("This method is only supported in the Vertex AI client.");
      }

      return JsonSerializer.Deserialize<EditImageResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException("Failed to deserialize Task<EditImageResponse>.");
    }

    private async Task<UpscaleImageResponse> PrivateUpscaleImageAsync(
        string model, Image image, string upscaleFactor, UpscaleImageAPIConfig? config) {
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
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
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

    public async Task<RecontextImageResponse> RecontextImageAsync(
        string model, RecontextImageSource source, RecontextImageConfig? config = null) {
      RecontextImageParameters parameter = new RecontextImageParameters();

      if (!Common.IsZero(model)) {
        parameter.Model = model;
      }
      if (!Common.IsZero(source)) {
        parameter.Source = source;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse RecontextImageParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = RecontextImageParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{model}:predict", body["_url"]);
      } else {
        throw new NotSupportedException("This method is only supported in the Vertex AI client.");
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
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
        responseNode = RecontextImageResponseFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        throw new NotSupportedException("This method is only supported in the Vertex AI client.");
      }

      return JsonSerializer.Deserialize<RecontextImageResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException(
                 "Failed to deserialize Task<RecontextImageResponse>.");
    }

    public async Task<SegmentImageResponse> SegmentImageAsync(string model,
                                                              SegmentImageSource source,
                                                              SegmentImageConfig? config = null) {
      SegmentImageParameters parameter = new SegmentImageParameters();

      if (!Common.IsZero(model)) {
        parameter.Model = model;
      }
      if (!Common.IsZero(source)) {
        parameter.Source = source;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse SegmentImageParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = SegmentImageParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{model}:predict", body["_url"]);
      } else {
        throw new NotSupportedException("This method is only supported in the Vertex AI client.");
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
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
        responseNode = SegmentImageResponseFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        throw new NotSupportedException("This method is only supported in the Vertex AI client.");
      }

      return JsonSerializer.Deserialize<SegmentImageResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException(
                 "Failed to deserialize Task<SegmentImageResponse>.");
    }

    /// <summary>
    /// Retrieves a specific model resource by its name.
    /// </summary>

    public async Task<Model> GetAsync(string model, GetModelConfig? config = null) {
      GetModelParameters parameter = new GetModelParameters();

      if (!Common.IsZero(model)) {
        parameter.Model = model;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse GetModelParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = GetModelParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{name}", body["_url"]);
      } else {
        body = GetModelParametersToMldev(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{name}", body["_url"]);
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
      HttpOptions? requestHttpOptions = config?.HttpOptions;

      ApiResponse response = await this._apiClient.RequestAsync(
          HttpMethod.Get, path, JsonSerializer.Serialize(body), requestHttpOptions);
      HttpContent httpContent = response.GetEntity();
      string contentString = await httpContent.ReadAsStringAsync();
      JsonNode? httpContentNode = JsonNode.Parse(contentString);
      if (httpContentNode == null) {
        throw new NotSupportedException("Failed to parse response to JsonNode.");
      }
      JsonNode responseNode = httpContentNode;

      if (this._apiClient.VertexAI) {
        responseNode = ModelFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        responseNode = ModelFromMldev(httpContentNode, new JsonObject());
      }

      return JsonSerializer.Deserialize<Model>(responseNode.ToString()) ??
             throw new InvalidOperationException("Failed to deserialize Task<Model>.");
    }

    private async Task<ListModelsResponse> PrivateListAsync(ListModelsConfig? config) {
      ListModelsParameters parameter = new ListModelsParameters();

      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse ListModelsParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = ListModelsParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{models_url}", body["_url"]);
      } else {
        body = ListModelsParametersToMldev(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{models_url}", body["_url"]);
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
      HttpOptions? requestHttpOptions = config?.HttpOptions;

      ApiResponse response = await this._apiClient.RequestAsync(
          HttpMethod.Get, path, JsonSerializer.Serialize(body), requestHttpOptions);
      HttpContent httpContent = response.GetEntity();
      string contentString = await httpContent.ReadAsStringAsync();
      JsonNode? httpContentNode = JsonNode.Parse(contentString);
      if (httpContentNode == null) {
        throw new NotSupportedException("Failed to parse response to JsonNode.");
      }
      JsonNode responseNode = httpContentNode;

      if (this._apiClient.VertexAI) {
        responseNode = ListModelsResponseFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        responseNode = ListModelsResponseFromMldev(httpContentNode, new JsonObject());
      }

      return JsonSerializer.Deserialize<ListModelsResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException("Failed to deserialize Task<ListModelsResponse>.");
    }

    /// <summary>
    /// Updates a specific model resource.
    /// </summary>
    /// <param name="model">The model to update.</param>
    /// <param name="config">An <see cref="UpdateModelConfig"/> instance that specifies parameters
    /// to update.</param> <returns>A <see cref="Task{Model}"/> that represents the asynchronous
    /// operation. The task result contains the updated <see cref="Model"/> instance.</returns>

    public async Task<Model> UpdateAsync(string model, UpdateModelConfig? config = null) {
      UpdateModelParameters parameter = new UpdateModelParameters();

      if (!Common.IsZero(model)) {
        parameter.Model = model;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse UpdateModelParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = UpdateModelParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{model}", body["_url"]);
      } else {
        body = UpdateModelParametersToMldev(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{name}", body["_url"]);
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
      HttpOptions? requestHttpOptions = config?.HttpOptions;

      ApiResponse response = await this._apiClient.RequestAsync(
          HttpMethod.Patch, path, JsonSerializer.Serialize(body), requestHttpOptions);
      HttpContent httpContent = response.GetEntity();
      string contentString = await httpContent.ReadAsStringAsync();
      JsonNode? httpContentNode = JsonNode.Parse(contentString);
      if (httpContentNode == null) {
        throw new NotSupportedException("Failed to parse response to JsonNode.");
      }
      JsonNode responseNode = httpContentNode;

      if (this._apiClient.VertexAI) {
        responseNode = ModelFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        responseNode = ModelFromMldev(httpContentNode, new JsonObject());
      }

      return JsonSerializer.Deserialize<Model>(responseNode.ToString()) ??
             throw new InvalidOperationException("Failed to deserialize Task<Model>.");
    }

    /// <summary>
    /// Deletes a specific model resource by its name.
    /// </summary>

    public async Task<DeleteModelResponse> DeleteAsync(string model,
                                                       DeleteModelConfig? config = null) {
      DeleteModelParameters parameter = new DeleteModelParameters();

      if (!Common.IsZero(model)) {
        parameter.Model = model;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse DeleteModelParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = DeleteModelParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{name}", body["_url"]);
      } else {
        body = DeleteModelParametersToMldev(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{name}", body["_url"]);
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
      HttpOptions? requestHttpOptions = config?.HttpOptions;

      ApiResponse response = await this._apiClient.RequestAsync(
          HttpMethod.Delete, path, JsonSerializer.Serialize(body), requestHttpOptions);
      HttpContent httpContent = response.GetEntity();
      string contentString = await httpContent.ReadAsStringAsync();
      JsonNode? httpContentNode = JsonNode.Parse(contentString);
      if (httpContentNode == null) {
        throw new NotSupportedException("Failed to parse response to JsonNode.");
      }
      JsonNode responseNode = httpContentNode;

      if (this._apiClient.VertexAI) {
        responseNode = DeleteModelResponseFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        responseNode = DeleteModelResponseFromMldev(httpContentNode, new JsonObject());
      }

      return JsonSerializer.Deserialize<DeleteModelResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException(
                 "Failed to deserialize Task<DeleteModelResponse>.");
    }

    /// <summary>
    /// Counts the number of tokens in the provided content.
    /// </summary>
    /// <param name="model">The name of the GenAI model to use for token counting.</param>
    /// <param name="contents">A <see cref="List{Content}"/> to count tokens for.</param>
    /// <param name="config">A <see cref="CountTokensConfig"/> instance that specifies the
    /// optional configurations.</param>
    /// <returns>A <see cref="Task{CountTokensResponse}"/> that represents the asynchronous
    /// operation. The task result contains a <see cref="CountTokensResponse"/> instance with
    /// the total token count and other metadata.</returns>

    public async Task<CountTokensResponse> CountTokensAsync(string model, List<Content> contents,
                                                            CountTokensConfig? config = null) {
      CountTokensParameters parameter = new CountTokensParameters();

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
        throw new NotSupportedException("Failed to parse CountTokensParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = CountTokensParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{model}:countTokens", body["_url"]);
      } else {
        body = CountTokensParametersToMldev(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{model}:countTokens", body["_url"]);
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
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
        responseNode = CountTokensResponseFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        responseNode = CountTokensResponseFromMldev(httpContentNode, new JsonObject());
      }

      return JsonSerializer.Deserialize<CountTokensResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException(
                 "Failed to deserialize Task<CountTokensResponse>.");
    }

    /// <summary>
    /// Computes the number of tokens for the given content.
    /// </summary>
    /// <param name="model">The name of the GenAI model to use for token computation.</param>
    /// <param name="contents">A <see cref="List{Content}"/> to compute tokens for.</param>
    /// <param name="config">A <see cref="ComputeTokensConfig"/> instance that specifies the
    /// optional configurations.</param> <returns>A <see cref="Task{ComputeTokensResponse}"/> that
    /// represents the asynchronous operation. The task result contains a <see
    /// cref="ComputeTokensResponse"/> instance with token information.</returns> <exception
    /// cref="NotSupportedException">Thrown when called with a non-Vertex AI client.</exception>

    public async Task<ComputeTokensResponse> ComputeTokensAsync(
        string model, List<Content> contents, ComputeTokensConfig? config = null) {
      ComputeTokensParameters parameter = new ComputeTokensParameters();

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
        throw new NotSupportedException("Failed to parse ComputeTokensParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = ComputeTokensParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{model}:computeTokens", body["_url"]);
      } else {
        throw new NotSupportedException("This method is only supported in the Vertex AI client.");
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
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
        responseNode = ComputeTokensResponseFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        throw new NotSupportedException("This method is only supported in the Vertex AI client.");
      }

      return JsonSerializer.Deserialize<ComputeTokensResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException(
                 "Failed to deserialize Task<ComputeTokensResponse>.");
    }

    private async Task<GenerateVideosOperation> PrivateGenerateVideosAsync(
        string model, string? prompt, Image? image, Video? video, GenerateVideosSource? source,
        GenerateVideosConfig? config) {
      GenerateVideosParameters parameter = new GenerateVideosParameters();

      if (!Common.IsZero(model)) {
        parameter.Model = model;
      }
      if (!Common.IsZero(prompt)) {
        parameter.Prompt = prompt;
      }
      if (!Common.IsZero(image)) {
        parameter.Image = image;
      }
      if (!Common.IsZero(video)) {
        parameter.Video = video;
      }
      if (!Common.IsZero(source)) {
        parameter.Source = source;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse GenerateVideosParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = GenerateVideosParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{model}:predictLongRunning", body["_url"]);
      } else {
        body = GenerateVideosParametersToMldev(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{model}:predictLongRunning", body["_url"]);
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
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
        responseNode = GenerateVideosOperationFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        responseNode = GenerateVideosOperationFromMldev(httpContentNode, new JsonObject());
      }

      return JsonSerializer.Deserialize<GenerateVideosOperation>(responseNode.ToString()) ??
             throw new InvalidOperationException(
                 "Failed to deserialize Task<GenerateVideosOperation>.");
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

    public async Task<EditImageResponse> EditImageAsync(String model, String prompt,
                                                        List<IReferenceImage> referenceImages,
                                                        EditImageConfig? config = null) {
      List<ReferenceImageAPI> referenceImagesAPI =
          referenceImages.Select(i => ((IReferenceImageInternal)i).ToReferenceImageAPI()).ToList();

      return await PrivateEditImageAsync(model, prompt, referenceImagesAPI, config);
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
        apiConfig.SafetyFilterLevel = config.SafetyFilterLevel;
        apiConfig.PersonGeneration = config.PersonGeneration;
        apiConfig.IncludeRaiReason = config.IncludeRaiReason;
        apiConfig.EnhanceInputImage = config.EnhanceInputImage;
        apiConfig.ImagePreservationFactor = config.ImagePreservationFactor;
        apiConfig.Labels = config.Labels;
      }

      return await PrivateUpscaleImageAsync(model, image, upscaleFactor, apiConfig);
    }

    /// <summary>
    /// Lists models asynchronously.
    /// </summary>
    /// <param name="config">A <see cref="ListModelsConfig"/> instance that specifies the
    /// optional configuration for the list request.</param>
    /// <returns>A Pager object that contains one page of models. When iterating over the pager,
    /// it automatically fetches the next page if there are more.</returns>
    public async Task<Pager<Model, ListModelsConfig, ListModelsResponse>> ListAsync(
        ListModelsConfig? config = null) {
      config ??= new ListModelsConfig();

      if (!config.QueryBase.HasValue) {
        config.QueryBase = true;
      }

      if (this._apiClient.VertexAI) {
        if (!config.QueryBase.Value) {
          if (!String.IsNullOrEmpty(config.Filter)) {
            throw new NotSupportedException(
                "Filtering tuned models list for Vertex AI is not currently supported");
          }
        }
      }

      var initialResponse = await PrivateListAsync(config);

      return new Pager<Model, ListModelsConfig, ListModelsResponse>(
          requestFunc: async cfg => await PrivateListAsync(cfg),
          extractItems: response => response.Models,
          extractNextPageToken: response => response.NextPageToken,
          extractHttpResponse: response => response.SdkHttpResponse,
          updateConfigPageToken: (cfg, token) => {
            cfg.PageToken = token;
            return cfg;
          }, initialConfig: config, initialResponse: initialResponse, requestedPageSize: config.PageSize ?? 0);
    }

    /// <summary>
    /// Counts the number of tokens in the provided content.
    /// </summary>
    /// <param name="model">The name of the GenAI model to use for token counting.</param>
    /// <param name="contents">A <see cref="Content"/> to count tokens for.</param>
    /// <param name="config">A <see cref="CountTokensConfig"/> instance that specifies the
    /// optional configurations.</param>
    /// <returns>A <see cref="Task{CountTokensResponse}"/> that represents the asynchronous
    /// operation. The task result contains a <see cref="CountTokensResponse"/> instance with
    /// the total token count and other metadata.</returns>
    public async Task<CountTokensResponse> CountTokensAsync(String model, Content contents,
                                                            CountTokensConfig? config = null) {
      List<Content> contentList = Transformers.TContents(contents) ?? new List<Content>();
      return await CountTokensAsync(model, contentList, config);
    }

    /// <summary>
    /// Counts the number of tokens in the provided content.
    /// </summary>
    /// <param name="model">The name of the GenAI model to use for token counting.</param>
    /// <param name="contents">A text string to send to count tokens for.</param>
    /// <param name="config">A <see cref="CountTokensConfig"/> instance that specifies the
    /// optional configurations.</param>
    /// <returns>A <see cref="Task{CountTokensResponse}"/> that represents the asynchronous
    /// operation. The task result contains a <see cref="CountTokensResponse"/> instance with
    /// the total token count and other metadata.</returns>
    public async Task<CountTokensResponse> CountTokensAsync(String model, String contents,
                                                            CountTokensConfig? config = null) {
      List<Content> contentList = Transformers.TContents(contents) ?? new List<Content>();
      return await CountTokensAsync(model, contentList, config);
    }

    /// <summary>
    /// Computes the number of tokens for a single content item.
    /// </summary>
    /// <param name="model">The name of the GenAI model to use for token computation.</param>
    /// <param name="contents">A <see cref="Content"/> instance to compute tokens for.</param>
    /// <param name="config">A <see cref="ComputeTokensConfig"/> instance that specifies the
    /// optional configurations.</param> <returns>A <see cref="Task{ComputeTokensResponse}"/> that
    /// represents the asynchronous operation. The task result contains a <see
    /// cref="ComputeTokensResponse"/> instance with token information.</returns> <exception
    /// cref="NotSupportedException">Thrown when called with a non-Vertex AI client.</exception>
    public async Task<ComputeTokensResponse> ComputeTokensAsync(
        String model, Content contents, ComputeTokensConfig? config = null) {
      List<Content> contentList = Transformers.TContents(contents) ?? new List<Content>();
      return await ComputeTokensAsync(model, contentList, config);
    }

    /// <summary>
    /// Computes the number of tokens for a text string.
    /// </summary>
    /// <param name="model">The name of the GenAI model to use for token computation.</param>
    /// <param name="contents">A string of text to compute tokens for.</param>
    /// <param name="config">A <see cref="ComputeTokensConfig"/> instance that specifies the
    /// optional configurations.</param> <returns>A <see cref="Task{ComputeTokensResponse}"/> that
    /// represents the asynchronous operation. The task result contains a <see
    /// cref="ComputeTokensResponse"/> instance with token information.</returns> <exception
    /// cref="NotSupportedException">Thrown when called with a non-Vertex AI client.</exception>
    public async Task<ComputeTokensResponse> ComputeTokensAsync(
        String model, String contents, ComputeTokensConfig? config = null) {
      List<Content> contentList = Transformers.TContents(contents) ?? new List<Content>();
      return await ComputeTokensAsync(model, contentList, config);
    }

    /// <summary>
    /// Calculates embeddings for the given content. Only text is supported.
    /// </summary>
    /// <param name="model">The model to use.</param>
    /// <param name="contents">The content to embed.</param>
    /// <param name="config">Optional configuration for embeddings.</param>
    /// <returns>A <see cref="Task{EmbedContentResponse}"/> that represents the asynchronous
    /// operation.</returns>
    public async Task<EmbedContentResponse> EmbedContentAsync(string model, Content contents,
                                                              EmbedContentConfig? config = null) {
      List<Content> contentList = Transformers.TContents(contents) ?? new List<Content>();
      return await EmbedContentAsync(model, contentList, config);
    }

    /// <summary>
    /// Calculates embeddings for the given text string.
    /// </summary>
    /// <param name="model">The model to use.</param>
    /// <param name="contents">The text string to embed.</param>
    /// <param name="config">Optional configuration for embeddings.</param>
    /// <returns>A <see cref="Task{EmbedContentResponse}"/> that represents the asynchronous
    /// operation.</returns>
    public async Task<EmbedContentResponse> EmbedContentAsync(string model, String contents,
                                                              EmbedContentConfig? config = null) {
      List<Content> contentList = Transformers.TContents(contents) ?? new List<Content>();
      return await EmbedContentAsync(model, contentList, config);
    }

    public async Task<GenerateVideosOperation> GenerateVideosAsync(
        String model, GenerateVideosSource source, GenerateVideosConfig? config = null) {
      return await PrivateGenerateVideosAsync(model, null, null, null, source, config);
    }
  }
}
