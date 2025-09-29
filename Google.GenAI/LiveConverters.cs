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
  class LiveConverters {
    private readonly ApiClient _apiClient;

    public LiveConverters(ApiClient apiClient) {
      _apiClient = apiClient;
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

    internal JsonNode GenerationConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "modelSelectionConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "modelConfig" },
            Common.GetValueByPath(fromObject, new string[] { "modelSelectionConfig" }));
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

      if (Common.GetValueByPath(fromObject, new string[] { "responseJsonSchema" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseJsonSchema" },
            Common.GetValueByPath(fromObject, new string[] { "responseJsonSchema" }));
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
        Common.SetValueByPath(
            toObject, new string[] { "speechConfig" },
            SpeechConfigToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                     fromObject, new string[] { "speechConfig" }))),
                                 toObject));
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

    internal JsonNode LiveClientContentToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "turns" }) != null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(fromObject, new string[] { "turns" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ContentToMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "turns" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "turnComplete" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "turnComplete" },
                              Common.GetValueByPath(fromObject, new string[] { "turnComplete" }));
      }

      return toObject;
    }

    internal JsonNode LiveClientMessageToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "setup" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "setup" },
            LiveClientSetupToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                       fromObject, new string[] { "setup" }))),
                                   toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "clientContent" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "clientContent" },
            LiveClientContentToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                         fromObject, new string[] { "clientContent" }))),
                                     toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "realtimeInput" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "realtimeInput" },
                              LiveClientRealtimeInputToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "realtimeInput" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "realtimeInputParameters" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "realtime_input" },
                              LiveSendRealtimeInputParametersToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "realtimeInputParameters" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "toolResponse" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "toolResponse" },
                              Common.GetValueByPath(fromObject, new string[] { "toolResponse" }));
      }

      return toObject;
    }

    internal JsonNode LiveClientMessageToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "setup" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "setup" },
            LiveClientSetupToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                        fromObject, new string[] { "setup" }))),
                                    toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "clientContent" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "clientContent" },
                              Common.GetValueByPath(fromObject, new string[] { "clientContent" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "realtimeInput" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "realtimeInput" },
                              LiveClientRealtimeInputToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "realtimeInput" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "realtimeInputParameters" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "realtime_input" },
                              LiveSendRealtimeInputParametersToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "realtimeInputParameters" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "toolResponse" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "toolResponse" },
                              Common.GetValueByPath(fromObject, new string[] { "toolResponse" }));
      }

      return toObject;
    }

    internal JsonNode LiveClientRealtimeInputToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "mediaChunks" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "mediaChunks" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(BlobToMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "mediaChunks" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "audio" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "audio" },
            BlobToMldev(JsonNode.Parse(JsonSerializer.Serialize(
                            Common.GetValueByPath(fromObject, new string[] { "audio" }))),
                        toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "audioStreamEnd" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "audioStreamEnd" },
                              Common.GetValueByPath(fromObject, new string[] { "audioStreamEnd" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "video" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "video" },
            BlobToMldev(JsonNode.Parse(JsonSerializer.Serialize(
                            Common.GetValueByPath(fromObject, new string[] { "video" }))),
                        toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "text" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "text" },
                              Common.GetValueByPath(fromObject, new string[] { "text" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "activityStart" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "activityStart" },
                              Common.GetValueByPath(fromObject, new string[] { "activityStart" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "activityEnd" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "activityEnd" },
                              Common.GetValueByPath(fromObject, new string[] { "activityEnd" }));
      }

      return toObject;
    }

    internal JsonNode LiveClientRealtimeInputToVertex(JsonNode fromObject,
                                                      JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "mediaChunks" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "mediaChunks" },
                              Common.GetValueByPath(fromObject, new string[] { "mediaChunks" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "audio" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "audio" },
                              Common.GetValueByPath(fromObject, new string[] { "audio" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "audioStreamEnd" }))) {
        throw new NotSupportedException("audioStreamEnd parameter is not supported in Vertex AI.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "video" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "video" },
                              Common.GetValueByPath(fromObject, new string[] { "video" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "text" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "text" },
                              Common.GetValueByPath(fromObject, new string[] { "text" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "activityStart" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "activityStart" },
                              Common.GetValueByPath(fromObject, new string[] { "activityStart" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "activityEnd" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "activityEnd" },
                              Common.GetValueByPath(fromObject, new string[] { "activityEnd" }));
      }

      return toObject;
    }

    internal JsonNode LiveClientSetupToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "model" },
                              Common.GetValueByPath(fromObject, new string[] { "model" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "generationConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "generationConfig" },
            Common.GetValueByPath(fromObject, new string[] { "generationConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "systemInstruction" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "systemInstruction" },
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
        Common.SetValueByPath(toObject, new string[] { "tools" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "realtimeInputConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "realtimeInputConfig" },
            Common.GetValueByPath(fromObject, new string[] { "realtimeInputConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "sessionResumption" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "sessionResumption" },
                              SessionResumptionConfigToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "sessionResumption" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "contextWindowCompression" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "contextWindowCompression" },
            Common.GetValueByPath(fromObject, new string[] { "contextWindowCompression" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "inputAudioTranscription" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "inputAudioTranscription" },
            Common.GetValueByPath(fromObject, new string[] { "inputAudioTranscription" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputAudioTranscription" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "outputAudioTranscription" },
            Common.GetValueByPath(fromObject, new string[] { "outputAudioTranscription" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "proactivity" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "proactivity" },
                              Common.GetValueByPath(fromObject, new string[] { "proactivity" }));
      }

      return toObject;
    }

    internal JsonNode LiveClientSetupToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "model" },
                              Common.GetValueByPath(fromObject, new string[] { "model" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "generationConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "generationConfig" },
            GenerationConfigToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                         fromObject, new string[] { "generationConfig" }))),
                                     toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "systemInstruction" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "systemInstruction" },
                              Transformers.TContent(Common.GetValueByPath(
                                  fromObject, new string[] { "systemInstruction" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tools" }) != null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(fromObject, new string[] { "tools" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ToolToVertex(
              JsonNode.Parse(JsonSerializer.Serialize(Transformers.TTool(record))), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "tools" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "realtimeInputConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "realtimeInputConfig" },
            Common.GetValueByPath(fromObject, new string[] { "realtimeInputConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "sessionResumption" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sessionResumption" },
            Common.GetValueByPath(fromObject, new string[] { "sessionResumption" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "contextWindowCompression" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "contextWindowCompression" },
            Common.GetValueByPath(fromObject, new string[] { "contextWindowCompression" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "inputAudioTranscription" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "inputAudioTranscription" },
            Common.GetValueByPath(fromObject, new string[] { "inputAudioTranscription" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputAudioTranscription" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "outputAudioTranscription" },
            Common.GetValueByPath(fromObject, new string[] { "outputAudioTranscription" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "proactivity" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "proactivity" },
                              Common.GetValueByPath(fromObject, new string[] { "proactivity" }));
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
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "inputAudioTranscription" },
            Common.GetValueByPath(fromObject, new string[] { "inputAudioTranscription" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputAudioTranscription" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "outputAudioTranscription" },
            Common.GetValueByPath(fromObject, new string[] { "outputAudioTranscription" }));
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

      return toObject;
    }

    internal JsonNode LiveConnectConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "generationConfig" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "generationConfig" },
            GenerationConfigToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                         fromObject, new string[] { "generationConfig" }))),
                                     toObject));
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
            SpeechConfigToVertex(
                JsonNode.Parse(JsonSerializer.Serialize(Transformers.TLiveSpeechConfig(
                    Common.GetValueByPath(fromObject, new string[] { "speechConfig" })))),
                toObject));
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
        Common.SetValueByPath(parentObject, new string[] { "setup", "systemInstruction" },
                              Transformers.TContent(Common.GetValueByPath(
                                  fromObject, new string[] { "systemInstruction" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tools" }) != null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(fromObject, new string[] { "tools" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ToolToVertex(
              JsonNode.Parse(JsonSerializer.Serialize(Transformers.TTool(record))), toObject));
        }
        Common.SetValueByPath(parentObject, new string[] { "setup", "tools" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "sessionResumption" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "sessionResumption" },
            Common.GetValueByPath(fromObject, new string[] { "sessionResumption" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "inputAudioTranscription" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "inputAudioTranscription" },
            Common.GetValueByPath(fromObject, new string[] { "inputAudioTranscription" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputAudioTranscription" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "outputAudioTranscription" },
            Common.GetValueByPath(fromObject, new string[] { "outputAudioTranscription" }));
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

      return toObject;
    }

    internal JsonNode LiveConnectParametersToMldev(ApiClient apiClient, JsonNode fromObject,
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

    internal JsonNode LiveConnectParametersToVertex(ApiClient apiClient, JsonNode fromObject,
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
            LiveConnectConfigToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                          fromObject, new string[] { "config" }))),
                                      toObject));
      }

      return toObject;
    }

    internal JsonNode LiveSendRealtimeInputParametersToMldev(JsonNode fromObject,
                                                             JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "media" }) != null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(fromObject, new string[] { "media" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(BlobToMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "mediaChunks" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "audio" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "audio" },
            BlobToMldev(JsonNode.Parse(JsonSerializer.Serialize(Transformers.TAudioBlob(
                            Common.GetValueByPath(fromObject, new string[] { "audio" })))),
                        toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "audioStreamEnd" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "audioStreamEnd" },
                              Common.GetValueByPath(fromObject, new string[] { "audioStreamEnd" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "video" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "video" },
            BlobToMldev(JsonNode.Parse(JsonSerializer.Serialize(Transformers.TImageBlob(
                            Common.GetValueByPath(fromObject, new string[] { "video" })))),
                        toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "text" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "text" },
                              Common.GetValueByPath(fromObject, new string[] { "text" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "activityStart" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "activityStart" },
                              Common.GetValueByPath(fromObject, new string[] { "activityStart" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "activityEnd" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "activityEnd" },
                              Common.GetValueByPath(fromObject, new string[] { "activityEnd" }));
      }

      return toObject;
    }

    internal JsonNode LiveSendRealtimeInputParametersToVertex(JsonNode fromObject,
                                                              JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "media" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "mediaChunks" },
            Transformers.TBlobs(Common.GetValueByPath(fromObject, new string[] { "media" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "audio" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "audio" },
            Transformers.TAudioBlob(Common.GetValueByPath(fromObject, new string[] { "audio" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "audioStreamEnd" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "audioStreamEnd" },
                              Common.GetValueByPath(fromObject, new string[] { "audioStreamEnd" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "video" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "video" },
            Transformers.TImageBlob(Common.GetValueByPath(fromObject, new string[] { "video" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "text" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "text" },
                              Common.GetValueByPath(fromObject, new string[] { "text" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "activityStart" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "activityStart" },
                              Common.GetValueByPath(fromObject, new string[] { "activityStart" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "activityEnd" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "activityEnd" },
                              Common.GetValueByPath(fromObject, new string[] { "activityEnd" }));
      }

      return toObject;
    }

    internal JsonNode LiveServerMessageFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "setupComplete" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "setupComplete" },
                              Common.GetValueByPath(fromObject, new string[] { "setupComplete" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "serverContent" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "serverContent" },
                              Common.GetValueByPath(fromObject, new string[] { "serverContent" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "toolCall" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "toolCall" },
                              Common.GetValueByPath(fromObject, new string[] { "toolCall" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "toolCallCancellation" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "toolCallCancellation" },
            Common.GetValueByPath(fromObject, new string[] { "toolCallCancellation" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "usageMetadata" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "usageMetadata" },
            UsageMetadataFromVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                        fromObject, new string[] { "usageMetadata" }))),
                                    toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "goAway" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "goAway" },
                              Common.GetValueByPath(fromObject, new string[] { "goAway" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "sessionResumptionUpdate" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sessionResumptionUpdate" },
            Common.GetValueByPath(fromObject, new string[] { "sessionResumptionUpdate" }));
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

    internal JsonNode UsageMetadataFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "promptTokenCount" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "promptTokenCount" },
            Common.GetValueByPath(fromObject, new string[] { "promptTokenCount" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "cachedContentTokenCount" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "cachedContentTokenCount" },
            Common.GetValueByPath(fromObject, new string[] { "cachedContentTokenCount" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "candidatesTokenCount" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseTokenCount" },
            Common.GetValueByPath(fromObject, new string[] { "candidatesTokenCount" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "toolUsePromptTokenCount" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "toolUsePromptTokenCount" },
            Common.GetValueByPath(fromObject, new string[] { "toolUsePromptTokenCount" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "thoughtsTokenCount" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "thoughtsTokenCount" },
            Common.GetValueByPath(fromObject, new string[] { "thoughtsTokenCount" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "totalTokenCount" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "totalTokenCount" },
            Common.GetValueByPath(fromObject, new string[] { "totalTokenCount" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "promptTokensDetails" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "promptTokensDetails" },
            Common.GetValueByPath(fromObject, new string[] { "promptTokensDetails" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "cacheTokensDetails" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "cacheTokensDetails" },
            Common.GetValueByPath(fromObject, new string[] { "cacheTokensDetails" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "candidatesTokensDetails" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseTokensDetails" },
            Common.GetValueByPath(fromObject, new string[] { "candidatesTokensDetails" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "toolUsePromptTokensDetails" }) !=
          null) {
        Common.SetValueByPath(
            toObject, new string[] { "toolUsePromptTokensDetails" },
            Common.GetValueByPath(fromObject, new string[] { "toolUsePromptTokensDetails" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "trafficType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "trafficType" },
                              Common.GetValueByPath(fromObject, new string[] { "trafficType" }));
      }

      return toObject;
    }
  }
}
