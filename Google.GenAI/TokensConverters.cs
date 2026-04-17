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

    internal JsonNode PrebuiltVoiceConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "voiceName" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "voiceName" },
                              Common.GetValueByPath(fromObject, new string[] { "voiceName" }));
      }

      return toObject;
    }

    internal JsonNode VoiceConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "prebuiltVoiceConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "prebuiltVoiceConfig" },
                              PrebuiltVoiceConfigToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "prebuiltVoiceConfig" }))),
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

    internal JsonNode SpeechConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "voiceConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "voiceConfig" },
            VoiceConfigToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                   fromObject, new string[] { "voiceConfig" }))),
                               toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "multiSpeakerVoiceConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "multiSpeakerVoiceConfig" },
                              MultiSpeakerVoiceConfigToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "multiSpeakerVoiceConfig" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "languageCode" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "languageCode" },
                              Common.GetValueByPath(fromObject, new string[] { "languageCode" }));
      }

      return toObject;
    }

    internal JsonNode VideoMetadataToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "fps" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "fps" },
                              Common.GetValueByPath(fromObject, new string[] { "fps" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "endOffset" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "endOffset" },
                              Common.GetValueByPath(fromObject, new string[] { "endOffset" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "startOffset" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "startOffset" },
                              Common.GetValueByPath(fromObject, new string[] { "startOffset" }));
      }

      return toObject;
    }

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

    internal JsonNode PartToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "videoMetadata" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "videoMetadata" },
            VideoMetadataToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                     fromObject, new string[] { "videoMetadata" }))),
                                 toObject));
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

      if (Common.GetValueByPath(fromObject, new string[] { "codeExecutionResult" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "codeExecutionResult" },
            Common.GetValueByPath(fromObject, new string[] { "codeExecutionResult" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "executableCode" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "executableCode" },
                              Common.GetValueByPath(fromObject, new string[] { "executableCode" }));
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

      if (Common.GetValueByPath(fromObject, new string[] { "text" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "text" },
                              Common.GetValueByPath(fromObject, new string[] { "text" }));
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

    internal JsonNode FunctionDeclarationToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "behavior" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "behavior" },
                              Common.GetValueByPath(fromObject, new string[] { "behavior" }));
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

    internal JsonNode IntervalToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "startTime" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "startTime" },
                              Common.GetValueByPath(fromObject, new string[] { "startTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "endTime" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "endTime" },
                              Common.GetValueByPath(fromObject, new string[] { "endTime" }));
      }

      return toObject;
    }

    internal JsonNode GoogleSearchToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "timeRangeFilter" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "timeRangeFilter" },
            IntervalToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                fromObject, new string[] { "timeRangeFilter" }))),
                            toObject));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "excludeDomains" }))) {
        throw new NotSupportedException("excludeDomains parameter is not supported in Gemini API.");
      }

      return toObject;
    }

    internal JsonNode DynamicRetrievalConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "mode" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "mode" },
                              Common.GetValueByPath(fromObject, new string[] { "mode" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "dynamicThreshold" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "dynamicThreshold" },
            Common.GetValueByPath(fromObject, new string[] { "dynamicThreshold" }));
      }

      return toObject;
    }

    internal JsonNode GoogleSearchRetrievalToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "dynamicRetrievalConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "dynamicRetrievalConfig" },
                              DynamicRetrievalConfigToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "dynamicRetrievalConfig" }))),
                                  toObject));
      }

      return toObject;
    }

    internal JsonNode UrlContextToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode ToolComputerUseToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "environment" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "environment" },
                              Common.GetValueByPath(fromObject, new string[] { "environment" }));
      }

      return toObject;
    }

    internal JsonNode ToolToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "functionDeclarations" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "functionDeclarations" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(FunctionDeclarationToMldev(JsonNode.Parse(JsonSerializer.Serialize(record)),
                                                toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "functionDeclarations" }, result);
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
        Common.SetValueByPath(toObject, new string[] { "googleSearchRetrieval" },
                              GoogleSearchRetrievalToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "googleSearchRetrieval" }))),
                                  toObject));
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
        Common.SetValueByPath(
            toObject, new string[] { "urlContext" },
            UrlContextToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                  fromObject, new string[] { "urlContext" }))),
                              toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "computerUse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "computerUse" },
            ToolComputerUseToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                       fromObject, new string[] { "computerUse" }))),
                                   toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "codeExecution" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "codeExecution" },
                              Common.GetValueByPath(fromObject, new string[] { "codeExecution" }));
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
        throw new NotSupportedException("transparent parameter is not supported in Gemini API.");
      }

      return toObject;
    }

    internal JsonNode AudioTranscriptionConfigToMldev(JsonNode fromObject,
                                                      JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode AutomaticActivityDetectionToMldev(JsonNode fromObject,
                                                        JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "disabled" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "disabled" },
                              Common.GetValueByPath(fromObject, new string[] { "disabled" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "startOfSpeechSensitivity" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "startOfSpeechSensitivity" },
            Common.GetValueByPath(fromObject, new string[] { "startOfSpeechSensitivity" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "endOfSpeechSensitivity" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "endOfSpeechSensitivity" },
            Common.GetValueByPath(fromObject, new string[] { "endOfSpeechSensitivity" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "prefixPaddingMs" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "prefixPaddingMs" },
            Common.GetValueByPath(fromObject, new string[] { "prefixPaddingMs" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "silenceDurationMs" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "silenceDurationMs" },
            Common.GetValueByPath(fromObject, new string[] { "silenceDurationMs" }));
      }

      return toObject;
    }

    internal JsonNode RealtimeInputConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "automaticActivityDetection" }) !=
          null) {
        Common.SetValueByPath(toObject, new string[] { "automaticActivityDetection" },
                              AutomaticActivityDetectionToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "automaticActivityDetection" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "activityHandling" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "activityHandling" },
            Common.GetValueByPath(fromObject, new string[] { "activityHandling" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "turnCoverage" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "turnCoverage" },
                              Common.GetValueByPath(fromObject, new string[] { "turnCoverage" }));
      }

      return toObject;
    }

    internal JsonNode SlidingWindowToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "targetTokens" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "targetTokens" },
                              Common.GetValueByPath(fromObject, new string[] { "targetTokens" }));
      }

      return toObject;
    }

    internal JsonNode ContextWindowCompressionConfigToMldev(JsonNode fromObject,
                                                            JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "triggerTokens" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "triggerTokens" },
                              Common.GetValueByPath(fromObject, new string[] { "triggerTokens" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "slidingWindow" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "slidingWindow" },
            SlidingWindowToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                     fromObject, new string[] { "slidingWindow" }))),
                                 toObject));
      }

      return toObject;
    }

    internal JsonNode ProactivityConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "proactiveAudio" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "proactiveAudio" },
                              Common.GetValueByPath(fromObject, new string[] { "proactiveAudio" }));
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
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "generationConfig", "speechConfig" },
            SpeechConfigToMldev(
                JsonNode.Parse(JsonSerializer.Serialize(Transformers.TLiveSpeechConfig(
                    Common.GetValueByPath(fromObject, new string[] { "speechConfig" })))),
                toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "enableAffectiveDialog" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "generationConfig", "enableAffectiveDialog" },
            Common.GetValueByPath(fromObject, new string[] { "enableAffectiveDialog" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "systemInstruction" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "systemInstruction" },
            ContentToMldev(
                JsonNode.Parse(JsonSerializer.Serialize(Transformers.TContent(
                    Common.GetValueByPath(fromObject, new string[] { "systemInstruction" })))),
                toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tools" }) != null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(fromObject, new string[] { "tools" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ToolToMldev(
              JsonNode.Parse(JsonSerializer.Serialize(Transformers.TTool(record))), toObject));
        }
        Common.SetValueByPath(parentObject, new string[] { "setup", "tools" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "sessionResumption" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "setup", "sessionResumption" },
                              SessionResumptionConfigToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "sessionResumption" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "inputAudioTranscription" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "setup", "inputAudioTranscription" },
                              AudioTranscriptionConfigToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "inputAudioTranscription" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputAudioTranscription" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "setup", "outputAudioTranscription" },
                              AudioTranscriptionConfigToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "outputAudioTranscription" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "realtimeInputConfig" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "setup", "realtimeInputConfig" },
                              RealtimeInputConfigToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "realtimeInputConfig" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "contextWindowCompression" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "setup", "contextWindowCompression" },
                              ContextWindowCompressionConfigToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "contextWindowCompression" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "proactivity" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "proactivity" },
            ProactivityConfigToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                         fromObject, new string[] { "proactivity" }))),
                                     toObject));
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
        Common.SetValueByPath(
            toObject, new string[] { "config" },
            LiveConnectConfigToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                         fromObject, new string[] { "config" }))),
                                     toObject));
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
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "liveConnectConstraints" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "lockAdditionalFields" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "fieldMask" },
            Common.GetValueByPath(fromObject, new string[] { "lockAdditionalFields" }));
      }

      return toObject;
    }

    internal JsonNode CreateAuthTokenParametersToMldev(JsonNode fromObject,
                                                       JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode CreateAuthTokenParametersToVertex(JsonNode fromObject,
                                                        JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode AuthTokenFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode AuthTokenFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }
  }
}
