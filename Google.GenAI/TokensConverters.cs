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
  class TokensConverters {
    private readonly ApiClient _apiClient;

    public TokensConverters(ApiClient apiClient) {
      _apiClient = apiClient;
    }

    internal JsonNode AudioTranscriptionConfigToMldev(JsonNode fromObject,
                                                      JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "languageCodes" }))) {
        throw new NotSupportedException(
            "languageCodes parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      return toObject;
    }

    internal JsonNode AuthConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "apiKey" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "apiKey" },
                              Common.GetValueByPath(fromObject, new string[] { "apiKey" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "apiKeyConfig" }))) {
        throw new NotSupportedException(
            "apiKeyConfig parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "authType" }))) {
        throw new NotSupportedException(
            "authType parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "googleServiceAccountConfig" }))) {
        throw new NotSupportedException(
            "googleServiceAccountConfig parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "httpBasicAuthConfig" }))) {
        throw new NotSupportedException(
            "httpBasicAuthConfig parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "oauthConfig" }))) {
        throw new NotSupportedException(
            "oauthConfig parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "oidcConfig" }))) {
        throw new NotSupportedException(
            "oidcConfig parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
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
        throw new NotSupportedException(
            "displayName parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "mimeType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "mimeType" },
                              Common.GetValueByPath(fromObject, new string[] { "mimeType" }));
      }

      return toObject;
    }

    internal JsonNode ContentToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "parts" }) != null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(fromObject, new string[] { "parts" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(PartToMldev(Common.ParseToJsonNode(record), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "parts" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "role" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "role" },
                              Common.GetValueByPath(fromObject, new string[] { "role" }));
      }

      return toObject;
    }

    internal JsonNode CreateAuthTokenConfigToMldev(ApiClient apiClient, JsonNode fromObject,
                                                   JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "expireTime" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "expireTime" },
                              Common.GetValueByPath(fromObject, new string[] { "expireTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "newSessionExpireTime" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "newSessionExpireTime" },
            Common.GetValueByPath(fromObject, new string[] { "newSessionExpireTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "uses" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "uses" },
                              Common.GetValueByPath(fromObject, new string[] { "uses" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "liveConnectConstraints" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "bidiGenerateContentSetup" },
                              LiveConnectConstraintsToMldev(
                                  apiClient,
                                  Common.ParseToJsonNode(Common.GetValueByPath(
                                      fromObject, new string[] { "liveConnectConstraints" })),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "lockAdditionalFields" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "fieldMask" },
            Common.GetValueByPath(fromObject, new string[] { "lockAdditionalFields" }));
      }

      return toObject;
    }

    internal JsonNode CreateAuthTokenParametersToMldev(ApiClient apiClient, JsonNode fromObject,
                                                       JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "config" },
            CreateAuthTokenConfigToMldev(apiClient,
                                         Common.ParseToJsonNode(Common.GetValueByPath(
                                             fromObject, new string[] { "config" })),
                                         toObject));
      }

      return toObject;
    }

    internal JsonNode CreateAuthTokenParametersToVertex(JsonNode fromObject,
                                                        JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "config" }))) {
        throw new NotSupportedException(
            "config parameter is only supported in Gemini Developer API mode, not in Gemini Enterprise Agent Platform mode.");
      }

      return toObject;
    }

    internal JsonNode FileDataToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "displayName" }))) {
        throw new NotSupportedException(
            "displayName parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
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
        throw new NotSupportedException(
            "partialArgs parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "willContinue" }))) {
        throw new NotSupportedException(
            "willContinue parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      return toObject;
    }

    internal JsonNode GoogleMapsToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "authConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "authConfig" },
                              AuthConfigToMldev(Common.ParseToJsonNode(Common.GetValueByPath(
                                                    fromObject, new string[] { "authConfig" })),
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

      if (Common.GetValueByPath(fromObject, new string[] { "searchTypes" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "searchTypes" },
                              Common.GetValueByPath(fromObject, new string[] { "searchTypes" }));
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "blockingConfidence" }))) {
        throw new NotSupportedException(
            "blockingConfidence parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "excludeDomains" }))) {
        throw new NotSupportedException(
            "excludeDomains parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "timeRangeFilter" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "timeRangeFilter" },
            Common.GetValueByPath(fromObject, new string[] { "timeRangeFilter" }));
      }

      return toObject;
    }

    internal JsonNode LiveConnectConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "generationConfig" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "generationConfig" },
            Common.GetValueByPath(fromObject, new string[] { "generationConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseModalities" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "generationConfig", "responseModalities" },
            Common.GetValueByPath(fromObject, new string[] { "responseModalities" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "temperature" }) != null) {
        Common.SetValueByPath(parentObject,
                              new string[] { "setup", "generationConfig", "temperature" },
                              Common.GetValueByPath(fromObject, new string[] { "temperature" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "topP" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "setup", "generationConfig", "topP" },
                              Common.GetValueByPath(fromObject, new string[] { "topP" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "topK" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "setup", "generationConfig", "topK" },
                              Common.GetValueByPath(fromObject, new string[] { "topK" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "maxOutputTokens" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "generationConfig", "maxOutputTokens" },
            Common.GetValueByPath(fromObject, new string[] { "maxOutputTokens" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "mediaResolution" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "generationConfig", "mediaResolution" },
            Common.GetValueByPath(fromObject, new string[] { "mediaResolution" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "seed" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "setup", "generationConfig", "seed" },
                              Common.GetValueByPath(fromObject, new string[] { "seed" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "speechConfig" }) != null) {
        Common.SetValueByPath(parentObject,
                              new string[] { "setup", "generationConfig", "speechConfig" },
                              Transformers.TLiveSpeechConfig(Common.GetValueByPath(
                                  fromObject, new string[] { "speechConfig" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "thinkingConfig" }) != null) {
        Common.SetValueByPath(parentObject,
                              new string[] { "setup", "generationConfig", "thinkingConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "thinkingConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "enableAffectiveDialog" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "generationConfig", "enableAffectiveDialog" },
            Common.GetValueByPath(fromObject, new string[] { "enableAffectiveDialog" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "systemInstruction" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "systemInstruction" },
            ContentToMldev(Common.ParseToJsonNode(Transformers.TContent(Common.GetValueByPath(
                               fromObject, new string[] { "systemInstruction" }))),
                           toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tools" }) != null) {
        var keyList =
            Transformers.TTools(Common.GetValueByPath(fromObject, new string[] { "tools" }));
        JsonArray result = new JsonArray();

        foreach (var record in keyList) {
          result.Add(ToolToMldev(Common.ParseToJsonNode(Transformers.TTool(record)), toObject));
        }
        Common.SetValueByPath(parentObject, new string[] { "setup", "tools" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "sessionResumption" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "sessionResumption" },
            SessionResumptionConfigToMldev(Common.ParseToJsonNode(Common.GetValueByPath(
                                               fromObject, new string[] { "sessionResumption" })),
                                           toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "inputAudioTranscription" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "setup", "inputAudioTranscription" },
                              AudioTranscriptionConfigToMldev(
                                  Common.ParseToJsonNode(Common.GetValueByPath(
                                      fromObject, new string[] { "inputAudioTranscription" })),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputAudioTranscription" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "setup", "outputAudioTranscription" },
                              AudioTranscriptionConfigToMldev(
                                  Common.ParseToJsonNode(Common.GetValueByPath(
                                      fromObject, new string[] { "outputAudioTranscription" })),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "realtimeInputConfig" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "realtimeInputConfig" },
            Common.GetValueByPath(fromObject, new string[] { "realtimeInputConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "contextWindowCompression" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "contextWindowCompression" },
            Common.GetValueByPath(fromObject, new string[] { "contextWindowCompression" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "proactivity" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "setup", "proactivity" },
                              Common.GetValueByPath(fromObject, new string[] { "proactivity" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "explicitVadSignal" }))) {
        throw new NotSupportedException(
            "explicitVadSignal parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "avatarConfig" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "setup", "avatarConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "avatarConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "safetySettings" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "safetySettings" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(SafetySettingToMldev(Common.ParseToJsonNode(record), toObject));
        }
        Common.SetValueByPath(parentObject, new string[] { "setup", "safetySettings" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "translationConfig" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "generationConfig", "translationConfig" },
            Common.GetValueByPath(fromObject, new string[] { "translationConfig" }));
      }

      return toObject;
    }

    internal JsonNode LiveConnectConstraintsToMldev(ApiClient apiClient, JsonNode fromObject,
                                                    JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "setup", "model" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "config" },
                              LiveConnectConfigToMldev(Common.ParseToJsonNode(Common.GetValueByPath(
                                                           fromObject, new string[] { "config" })),
                                                       toObject));
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
        Common.SetValueByPath(toObject, new string[] { "fileData" },
                              FileDataToMldev(Common.ParseToJsonNode(Common.GetValueByPath(
                                                  fromObject, new string[] { "fileData" })),
                                              toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "functionCall" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "functionCall" },
                              FunctionCallToMldev(Common.ParseToJsonNode(Common.GetValueByPath(
                                                      fromObject, new string[] { "functionCall" })),
                                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "functionResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "functionResponse" },
            Common.GetValueByPath(fromObject, new string[] { "functionResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "inlineData" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "inlineData" },
                              BlobToMldev(Common.ParseToJsonNode(Common.GetValueByPath(
                                              fromObject, new string[] { "inlineData" })),
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

      if (Common.GetValueByPath(fromObject, new string[] { "toolCall" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "toolCall" },
                              Common.GetValueByPath(fromObject, new string[] { "toolCall" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "toolResponse" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "toolResponse" },
                              Common.GetValueByPath(fromObject, new string[] { "toolResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "partMetadata" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "partMetadata" },
                              Common.GetValueByPath(fromObject, new string[] { "partMetadata" }));
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
        throw new NotSupportedException(
            "method parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "threshold" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "threshold" },
                              Common.GetValueByPath(fromObject, new string[] { "threshold" }));
      }

      return toObject;
    }

    internal JsonNode SessionResumptionConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "handle" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "handle" },
                              Common.GetValueByPath(fromObject, new string[] { "handle" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "transparent" }))) {
        throw new NotSupportedException(
            "transparent parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      return toObject;
    }

    internal JsonNode ToolToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "retrieval" }))) {
        throw new NotSupportedException(
            "retrieval parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "computerUse" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "computerUse" },
                              Common.GetValueByPath(fromObject, new string[] { "computerUse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "fileSearch" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "fileSearch" },
                              Common.GetValueByPath(fromObject, new string[] { "fileSearch" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "googleSearch" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "googleSearch" },
                              GoogleSearchToMldev(Common.ParseToJsonNode(Common.GetValueByPath(
                                                      fromObject, new string[] { "googleSearch" })),
                                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "googleMaps" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "googleMaps" },
                              GoogleMapsToMldev(Common.ParseToJsonNode(Common.GetValueByPath(
                                                    fromObject, new string[] { "googleMaps" })),
                                                toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "codeExecution" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "codeExecution" },
                              Common.GetValueByPath(fromObject, new string[] { "codeExecution" }));
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "enterpriseWebSearch" }))) {
        throw new NotSupportedException(
            "enterpriseWebSearch parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "functionDeclarations" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "functionDeclarations" },
            Common.GetValueByPath(fromObject, new string[] { "functionDeclarations" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "googleSearchRetrieval" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "googleSearchRetrieval" },
            Common.GetValueByPath(fromObject, new string[] { "googleSearchRetrieval" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "parallelAiSearch" }))) {
        throw new NotSupportedException(
            "parallelAiSearch parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "urlContext" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "urlContext" },
                              Common.GetValueByPath(fromObject, new string[] { "urlContext" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "mcpServers" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "mcpServers" },
                              Common.GetValueByPath(fromObject, new string[] { "mcpServers" }));
      }

      return toObject;
    }
  }
}
