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

    internal JsonNode ActivityEndToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode ActivityEndToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode ActivityStartToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode ActivityStartToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode ApiKeyConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "apiKeyString" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "apiKeyString" },
                              Common.GetValueByPath(fromObject, new string[] { "apiKeyString" }));
      }

      return toObject;
    }

    internal JsonNode AudioTranscriptionConfigToMldev(JsonNode fromObject,
                                                      JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode AudioTranscriptionConfigToVertex(JsonNode fromObject,
                                                       JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode AuthConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "apiKeyConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "apiKeyConfig" },
            ApiKeyConfigToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                     fromObject, new string[] { "apiKeyConfig" }))),
                                 toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "authType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "authType" },
                              Common.GetValueByPath(fromObject, new string[] { "authType" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "googleServiceAccountConfig" }) !=
          null) {
        Common.SetValueByPath(
            toObject, new string[] { "googleServiceAccountConfig" },
            Common.GetValueByPath(fromObject, new string[] { "googleServiceAccountConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "httpBasicAuthConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "httpBasicAuthConfig" },
            Common.GetValueByPath(fromObject, new string[] { "httpBasicAuthConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "oauthConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "oauthConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "oauthConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "oidcConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "oidcConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "oidcConfig" }));
      }

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

    internal JsonNode AutomaticActivityDetectionToVertex(JsonNode fromObject,
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

    internal JsonNode BlobFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

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

    internal JsonNode BlobFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "displayName" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "displayName" },
                              Common.GetValueByPath(fromObject, new string[] { "displayName" }));
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

    internal JsonNode BlobToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "displayName" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "displayName" },
                              Common.GetValueByPath(fromObject, new string[] { "displayName" }));
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

    internal JsonNode ContentFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "parts" }) != null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(fromObject, new string[] { "parts" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(PartFromMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "parts" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "role" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "role" },
                              Common.GetValueByPath(fromObject, new string[] { "role" }));
      }

      return toObject;
    }

    internal JsonNode ContentFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "parts" }) != null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(fromObject, new string[] { "parts" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(PartFromVertex(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "parts" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "role" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "role" },
                              Common.GetValueByPath(fromObject, new string[] { "role" }));
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

    internal JsonNode ContextWindowCompressionConfigToVertex(JsonNode fromObject,
                                                             JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "triggerTokens" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "triggerTokens" },
                              Common.GetValueByPath(fromObject, new string[] { "triggerTokens" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "slidingWindow" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "slidingWindow" },
            SlidingWindowToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "slidingWindow" }))),
                                  toObject));
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

    internal JsonNode DynamicRetrievalConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
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

    internal JsonNode EnterpriseWebSearchToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "excludeDomains" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "excludeDomains" },
                              Common.GetValueByPath(fromObject, new string[] { "excludeDomains" }));
      }

      return toObject;
    }

    internal JsonNode FileDataFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

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

    internal JsonNode FileDataFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "displayName" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "displayName" },
                              Common.GetValueByPath(fromObject, new string[] { "displayName" }));
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

    internal JsonNode FileDataToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "displayName" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "displayName" },
                              Common.GetValueByPath(fromObject, new string[] { "displayName" }));
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

    internal JsonNode FunctionCallFromMldev(JsonNode fromObject, JsonObject parentObject) {
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

      return toObject;
    }

    internal JsonNode FunctionCallFromVertex(JsonNode fromObject, JsonObject parentObject) {
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

      return toObject;
    }

    internal JsonNode FunctionCallToVertex(JsonNode fromObject, JsonObject parentObject) {
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

    internal JsonNode FunctionResponseToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "willContinue" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "willContinue" },
                              Common.GetValueByPath(fromObject, new string[] { "willContinue" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "scheduling" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "scheduling" },
                              Common.GetValueByPath(fromObject, new string[] { "scheduling" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "id" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "id" },
                              Common.GetValueByPath(fromObject, new string[] { "id" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "name" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "response" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "response" },
                              Common.GetValueByPath(fromObject, new string[] { "response" }));
      }

      return toObject;
    }

    internal JsonNode FunctionResponseToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "willContinue" }))) {
        throw new NotSupportedException("willContinue parameter is not supported in Vertex AI.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "scheduling" }))) {
        throw new NotSupportedException("scheduling parameter is not supported in Vertex AI.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "id" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "id" },
                              Common.GetValueByPath(fromObject, new string[] { "id" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "name" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "response" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "response" },
                              Common.GetValueByPath(fromObject, new string[] { "response" }));
      }

      return toObject;
    }

    internal JsonNode GoogleMapsToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "authConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "authConfig" },
            AuthConfigToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                   fromObject, new string[] { "authConfig" }))),
                               toObject));
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

    internal JsonNode GoogleSearchRetrievalToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "dynamicRetrievalConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "dynamicRetrievalConfig" },
                              DynamicRetrievalConfigToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "dynamicRetrievalConfig" }))),
                                  toObject));
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

    internal JsonNode GoogleSearchToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "timeRangeFilter" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "timeRangeFilter" },
            IntervalToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                 fromObject, new string[] { "timeRangeFilter" }))),
                             toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "excludeDomains" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "excludeDomains" },
                              Common.GetValueByPath(fromObject, new string[] { "excludeDomains" }));
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

    internal JsonNode IntervalToVertex(JsonNode fromObject, JsonObject parentObject) {
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

    internal JsonNode LiveClientContentToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "turns" }) != null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(fromObject, new string[] { "turns" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ContentToVertex(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
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
                              LiveClientToolResponseToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "toolResponse" }))),
                                  toObject));
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
        Common.SetValueByPath(
            toObject, new string[] { "clientContent" },
            LiveClientContentToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                          fromObject, new string[] { "clientContent" }))),
                                      toObject));
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
                              LiveClientToolResponseToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "toolResponse" }))),
                                  toObject));
      }

      return toObject;
    }

    internal JsonNode LiveClientRealtimeInputToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "mediaChunks" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "mediaChunks" },
                              Common.GetValueByPath(fromObject, new string[] { "mediaChunks" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "audio" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "audio" },
                              Common.GetValueByPath(fromObject, new string[] { "audio" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "audioStreamEnd" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "audioStreamEnd" },
                              Common.GetValueByPath(fromObject, new string[] { "audioStreamEnd" }));
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
        Common.SetValueByPath(
            toObject, new string[] { "activityStart" },
            ActivityStartToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                     fromObject, new string[] { "activityStart" }))),
                                 toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "activityEnd" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "activityEnd" },
            ActivityEndToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                   fromObject, new string[] { "activityEnd" }))),
                               toObject));
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
        Common.SetValueByPath(
            toObject, new string[] { "activityStart" },
            ActivityStartToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "activityStart" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "activityEnd" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "activityEnd" },
            ActivityEndToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                    fromObject, new string[] { "activityEnd" }))),
                                toObject));
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
        Common.SetValueByPath(toObject, new string[] { "realtimeInputConfig" },
                              RealtimeInputConfigToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "realtimeInputConfig" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "sessionResumption" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "sessionResumption" },
                              SessionResumptionConfigToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "sessionResumption" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "contextWindowCompression" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "contextWindowCompression" },
                              ContextWindowCompressionConfigToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "contextWindowCompression" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "inputAudioTranscription" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "inputAudioTranscription" },
                              AudioTranscriptionConfigToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "inputAudioTranscription" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputAudioTranscription" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "outputAudioTranscription" },
                              AudioTranscriptionConfigToMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "outputAudioTranscription" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "proactivity" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "proactivity" },
            ProactivityConfigToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                         fromObject, new string[] { "proactivity" }))),
                                     toObject));
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
            Common.GetValueByPath(fromObject, new string[] { "generationConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "systemInstruction" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "systemInstruction" },
            ContentToVertex(
                JsonNode.Parse(JsonSerializer.Serialize(Transformers.TContent(
                    Common.GetValueByPath(fromObject, new string[] { "systemInstruction" })))),
                toObject));
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
        Common.SetValueByPath(toObject, new string[] { "realtimeInputConfig" },
                              RealtimeInputConfigToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "realtimeInputConfig" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "sessionResumption" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "sessionResumption" },
                              SessionResumptionConfigToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "sessionResumption" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "contextWindowCompression" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "contextWindowCompression" },
                              ContextWindowCompressionConfigToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "contextWindowCompression" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "inputAudioTranscription" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "inputAudioTranscription" },
                              AudioTranscriptionConfigToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "inputAudioTranscription" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputAudioTranscription" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "outputAudioTranscription" },
                              AudioTranscriptionConfigToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "outputAudioTranscription" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "proactivity" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "proactivity" },
            ProactivityConfigToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                          fromObject, new string[] { "proactivity" }))),
                                      toObject));
      }

      return toObject;
    }

    internal JsonNode LiveClientToolResponseToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "functionResponses" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "functionResponses" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(
              FunctionResponseToMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "functionResponses" }, result);
      }

      return toObject;
    }

    internal JsonNode LiveClientToolResponseToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "functionResponses" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "functionResponses" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(
              FunctionResponseToVertex(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "functionResponses" }, result);
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

    internal JsonNode LiveConnectConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
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
            SpeechConfigToVertex(
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
            ContentToVertex(
                JsonNode.Parse(JsonSerializer.Serialize(Transformers.TContent(
                    Common.GetValueByPath(fromObject, new string[] { "systemInstruction" })))),
                toObject));
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
        Common.SetValueByPath(parentObject, new string[] { "setup", "sessionResumption" },
                              SessionResumptionConfigToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "sessionResumption" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "inputAudioTranscription" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "setup", "inputAudioTranscription" },
                              AudioTranscriptionConfigToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "inputAudioTranscription" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputAudioTranscription" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "setup", "outputAudioTranscription" },
                              AudioTranscriptionConfigToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "outputAudioTranscription" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "realtimeInputConfig" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "setup", "realtimeInputConfig" },
                              RealtimeInputConfigToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "realtimeInputConfig" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "contextWindowCompression" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "setup", "contextWindowCompression" },
                              ContextWindowCompressionConfigToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "contextWindowCompression" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "proactivity" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "setup", "proactivity" },
            ProactivityConfigToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                          fromObject, new string[] { "proactivity" }))),
                                      toObject));
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
          result.Add(record);
        }
        Common.SetValueByPath(toObject, new string[] { "mediaChunks" }, result);
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
        Common.SetValueByPath(
            toObject, new string[] { "activityStart" },
            ActivityStartToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                     fromObject, new string[] { "activityStart" }))),
                                 toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "activityEnd" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "activityEnd" },
            ActivityEndToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                   fromObject, new string[] { "activityEnd" }))),
                               toObject));
      }

      return toObject;
    }

    internal JsonNode LiveSendRealtimeInputParametersToVertex(JsonNode fromObject,
                                                              JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "media" }) != null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(fromObject, new string[] { "media" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(record);
        }
        Common.SetValueByPath(toObject, new string[] { "mediaChunks" }, result);
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
        Common.SetValueByPath(
            toObject, new string[] { "activityStart" },
            ActivityStartToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "activityStart" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "activityEnd" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "activityEnd" },
            ActivityEndToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                    fromObject, new string[] { "activityEnd" }))),
                                toObject));
      }

      return toObject;
    }

    internal JsonNode LiveServerContentFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "modelTurn" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "modelTurn" },
            ContentFromMldev(JsonNode.Parse(JsonSerializer.Serialize(
                                 Common.GetValueByPath(fromObject, new string[] { "modelTurn" }))),
                             toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "turnComplete" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "turnComplete" },
                              Common.GetValueByPath(fromObject, new string[] { "turnComplete" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "interrupted" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "interrupted" },
                              Common.GetValueByPath(fromObject, new string[] { "interrupted" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "groundingMetadata" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "groundingMetadata" },
            Common.GetValueByPath(fromObject, new string[] { "groundingMetadata" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "generationComplete" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "generationComplete" },
            Common.GetValueByPath(fromObject, new string[] { "generationComplete" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "inputTranscription" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "inputTranscription" },
            TranscriptionFromMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                       fromObject, new string[] { "inputTranscription" }))),
                                   toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputTranscription" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "outputTranscription" },
            TranscriptionFromMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                       fromObject, new string[] { "outputTranscription" }))),
                                   toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "urlContextMetadata" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "urlContextMetadata" },
                              UrlContextMetadataFromMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "urlContextMetadata" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "turnCompleteReason" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "turnCompleteReason" },
            Common.GetValueByPath(fromObject, new string[] { "turnCompleteReason" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "waitingForInput" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "waitingForInput" },
            Common.GetValueByPath(fromObject, new string[] { "waitingForInput" }));
      }

      return toObject;
    }

    internal JsonNode LiveServerContentFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "modelTurn" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "modelTurn" },
            ContentFromVertex(JsonNode.Parse(JsonSerializer.Serialize(
                                  Common.GetValueByPath(fromObject, new string[] { "modelTurn" }))),
                              toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "turnComplete" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "turnComplete" },
                              Common.GetValueByPath(fromObject, new string[] { "turnComplete" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "interrupted" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "interrupted" },
                              Common.GetValueByPath(fromObject, new string[] { "interrupted" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "groundingMetadata" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "groundingMetadata" },
            Common.GetValueByPath(fromObject, new string[] { "groundingMetadata" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "generationComplete" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "generationComplete" },
            Common.GetValueByPath(fromObject, new string[] { "generationComplete" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "inputTranscription" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "inputTranscription" },
            TranscriptionFromVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                        fromObject, new string[] { "inputTranscription" }))),
                                    toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputTranscription" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "outputTranscription" },
            TranscriptionFromVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                        fromObject, new string[] { "outputTranscription" }))),
                                    toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "turnCompleteReason" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "turnCompleteReason" },
            Common.GetValueByPath(fromObject, new string[] { "turnCompleteReason" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "waitingForInput" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "waitingForInput" },
            Common.GetValueByPath(fromObject, new string[] { "waitingForInput" }));
      }

      return toObject;
    }

    internal JsonNode LiveServerGoAwayFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "timeLeft" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "timeLeft" },
                              Common.GetValueByPath(fromObject, new string[] { "timeLeft" }));
      }

      return toObject;
    }

    internal JsonNode LiveServerGoAwayFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "timeLeft" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "timeLeft" },
                              Common.GetValueByPath(fromObject, new string[] { "timeLeft" }));
      }

      return toObject;
    }

    internal JsonNode LiveServerMessageFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "setupComplete" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "setupComplete" },
                              LiveServerSetupCompleteFromMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "setupComplete" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "serverContent" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "serverContent" },
                              LiveServerContentFromMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "serverContent" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "toolCall" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "toolCall" },
                              LiveServerToolCallFromMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "toolCall" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "toolCallCancellation" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "toolCallCancellation" },
                              LiveServerToolCallCancellationFromMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "toolCallCancellation" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "usageMetadata" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "usageMetadata" },
            UsageMetadataFromMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                       fromObject, new string[] { "usageMetadata" }))),
                                   toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "goAway" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "goAway" },
            LiveServerGoAwayFromMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                          fromObject, new string[] { "goAway" }))),
                                      toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "sessionResumptionUpdate" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "sessionResumptionUpdate" },
                              LiveServerSessionResumptionUpdateFromMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "sessionResumptionUpdate" }))),
                                  toObject));
      }

      return toObject;
    }

    internal JsonNode LiveServerMessageFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "setupComplete" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "setupComplete" },
                              LiveServerSetupCompleteFromVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "setupComplete" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "serverContent" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "serverContent" },
                              LiveServerContentFromVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "serverContent" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "toolCall" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "toolCall" },
                              LiveServerToolCallFromVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "toolCall" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "toolCallCancellation" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "toolCallCancellation" },
                              LiveServerToolCallCancellationFromVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "toolCallCancellation" }))),
                                  toObject));
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
                              LiveServerGoAwayFromVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "goAway" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "sessionResumptionUpdate" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "sessionResumptionUpdate" },
                              LiveServerSessionResumptionUpdateFromVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "sessionResumptionUpdate" }))),
                                  toObject));
      }

      return toObject;
    }

    internal JsonNode LiveServerSessionResumptionUpdateFromMldev(JsonNode fromObject,
                                                                 JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "newHandle" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "newHandle" },
                              Common.GetValueByPath(fromObject, new string[] { "newHandle" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "resumable" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "resumable" },
                              Common.GetValueByPath(fromObject, new string[] { "resumable" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "lastConsumedClientMessageIndex" }) !=
          null) {
        Common.SetValueByPath(
            toObject, new string[] { "lastConsumedClientMessageIndex" },
            Common.GetValueByPath(fromObject, new string[] { "lastConsumedClientMessageIndex" }));
      }

      return toObject;
    }

    internal JsonNode LiveServerSessionResumptionUpdateFromVertex(JsonNode fromObject,
                                                                  JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "newHandle" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "newHandle" },
                              Common.GetValueByPath(fromObject, new string[] { "newHandle" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "resumable" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "resumable" },
                              Common.GetValueByPath(fromObject, new string[] { "resumable" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "lastConsumedClientMessageIndex" }) !=
          null) {
        Common.SetValueByPath(
            toObject, new string[] { "lastConsumedClientMessageIndex" },
            Common.GetValueByPath(fromObject, new string[] { "lastConsumedClientMessageIndex" }));
      }

      return toObject;
    }

    internal JsonNode LiveServerSetupCompleteFromMldev(JsonNode fromObject,
                                                       JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode LiveServerSetupCompleteFromVertex(JsonNode fromObject,
                                                        JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sessionId" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "sessionId" },
                              Common.GetValueByPath(fromObject, new string[] { "sessionId" }));
      }

      return toObject;
    }

    internal JsonNode LiveServerToolCallCancellationFromMldev(JsonNode fromObject,
                                                              JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "ids" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "ids" },
                              Common.GetValueByPath(fromObject, new string[] { "ids" }));
      }

      return toObject;
    }

    internal JsonNode LiveServerToolCallCancellationFromVertex(JsonNode fromObject,
                                                               JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "ids" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "ids" },
                              Common.GetValueByPath(fromObject, new string[] { "ids" }));
      }

      return toObject;
    }

    internal JsonNode LiveServerToolCallFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "functionCalls" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "functionCalls" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(
              FunctionCallFromMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "functionCalls" }, result);
      }

      return toObject;
    }

    internal JsonNode LiveServerToolCallFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "functionCalls" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "functionCalls" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(
              FunctionCallFromVertex(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "functionCalls" }, result);
      }

      return toObject;
    }

    internal JsonNode ModalityTokenCountFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "modality" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "modality" },
                              Common.GetValueByPath(fromObject, new string[] { "modality" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tokenCount" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "tokenCount" },
                              Common.GetValueByPath(fromObject, new string[] { "tokenCount" }));
      }

      return toObject;
    }

    internal JsonNode ModalityTokenCountFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "modality" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "modality" },
                              Common.GetValueByPath(fromObject, new string[] { "modality" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tokenCount" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "tokenCount" },
                              Common.GetValueByPath(fromObject, new string[] { "tokenCount" }));
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

    internal JsonNode PartFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "videoMetadata" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "videoMetadata" },
            VideoMetadataFromMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
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
            BlobFromMldev(JsonNode.Parse(JsonSerializer.Serialize(
                              Common.GetValueByPath(fromObject, new string[] { "inlineData" }))),
                          toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "fileData" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "fileData" },
            FileDataFromMldev(JsonNode.Parse(JsonSerializer.Serialize(
                                  Common.GetValueByPath(fromObject, new string[] { "fileData" }))),
                              toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "thoughtSignature" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "thoughtSignature" },
            Common.GetValueByPath(fromObject, new string[] { "thoughtSignature" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "functionCall" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "functionCall" },
            FunctionCallFromMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "functionCall" }))),
                                  toObject));
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

    internal JsonNode PartFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "videoMetadata" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "videoMetadata" },
            VideoMetadataFromVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
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
            BlobFromVertex(JsonNode.Parse(JsonSerializer.Serialize(
                               Common.GetValueByPath(fromObject, new string[] { "inlineData" }))),
                           toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "fileData" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "fileData" },
            FileDataFromVertex(JsonNode.Parse(JsonSerializer.Serialize(
                                   Common.GetValueByPath(fromObject, new string[] { "fileData" }))),
                               toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "thoughtSignature" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "thoughtSignature" },
            Common.GetValueByPath(fromObject, new string[] { "thoughtSignature" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "functionCall" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "functionCall" },
            FunctionCallFromVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                       fromObject, new string[] { "functionCall" }))),
                                   toObject));
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

      if (Common.GetValueByPath(fromObject, new string[] { "functionCall" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "functionCall" },
            FunctionCallToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                    fromObject, new string[] { "functionCall" }))),
                                toObject));
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

    internal JsonNode PartToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "videoMetadata" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "videoMetadata" },
            VideoMetadataToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
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
            BlobToVertex(JsonNode.Parse(JsonSerializer.Serialize(
                             Common.GetValueByPath(fromObject, new string[] { "inlineData" }))),
                         toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "fileData" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "fileData" },
            FileDataToVertex(JsonNode.Parse(JsonSerializer.Serialize(
                                 Common.GetValueByPath(fromObject, new string[] { "fileData" }))),
                             toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "thoughtSignature" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "thoughtSignature" },
            Common.GetValueByPath(fromObject, new string[] { "thoughtSignature" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "functionCall" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "functionCall" },
            FunctionCallToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                     fromObject, new string[] { "functionCall" }))),
                                 toObject));
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

    internal JsonNode PrebuiltVoiceConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "voiceName" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "voiceName" },
                              Common.GetValueByPath(fromObject, new string[] { "voiceName" }));
      }

      return toObject;
    }

    internal JsonNode PrebuiltVoiceConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "voiceName" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "voiceName" },
                              Common.GetValueByPath(fromObject, new string[] { "voiceName" }));
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

    internal JsonNode ProactivityConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "proactiveAudio" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "proactiveAudio" },
                              Common.GetValueByPath(fromObject, new string[] { "proactiveAudio" }));
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

    internal JsonNode RealtimeInputConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "automaticActivityDetection" }) !=
          null) {
        Common.SetValueByPath(toObject, new string[] { "automaticActivityDetection" },
                              AutomaticActivityDetectionToVertex(
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

    internal JsonNode SessionResumptionConfigToVertex(JsonNode fromObject,
                                                      JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "handle" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "handle" },
                              Common.GetValueByPath(fromObject, new string[] { "handle" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "transparent" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "transparent" },
                              Common.GetValueByPath(fromObject, new string[] { "transparent" }));
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

    internal JsonNode SlidingWindowToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "targetTokens" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "targetTokens" },
                              Common.GetValueByPath(fromObject, new string[] { "targetTokens" }));
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

    internal JsonNode SpeechConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "voiceConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "voiceConfig" },
            VoiceConfigToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                    fromObject, new string[] { "voiceConfig" }))),
                                toObject));
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

    internal JsonNode ToolComputerUseToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "environment" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "environment" },
                              Common.GetValueByPath(fromObject, new string[] { "environment" }));
      }

      return toObject;
    }

    internal JsonNode ToolComputerUseToVertex(JsonNode fromObject, JsonObject parentObject) {
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
        Common.SetValueByPath(
            toObject, new string[] { "googleSearch" },
            GoogleSearchToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                     fromObject, new string[] { "googleSearch" }))),
                                 toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "googleSearchRetrieval" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "googleSearchRetrieval" },
                              GoogleSearchRetrievalToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "googleSearchRetrieval" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "enterpriseWebSearch" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "enterpriseWebSearch" },
                              EnterpriseWebSearchToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "enterpriseWebSearch" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "googleMaps" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "googleMaps" },
            GoogleMapsToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                   fromObject, new string[] { "googleMaps" }))),
                               toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "urlContext" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "urlContext" },
            UrlContextToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                   fromObject, new string[] { "urlContext" }))),
                               toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "computerUse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "computerUse" },
            ToolComputerUseToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                        fromObject, new string[] { "computerUse" }))),
                                    toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "codeExecution" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "codeExecution" },
                              Common.GetValueByPath(fromObject, new string[] { "codeExecution" }));
      }

      return toObject;
    }

    internal JsonNode TranscriptionFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "text" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "text" },
                              Common.GetValueByPath(fromObject, new string[] { "text" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "finished" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "finished" },
                              Common.GetValueByPath(fromObject, new string[] { "finished" }));
      }

      return toObject;
    }

    internal JsonNode TranscriptionFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "text" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "text" },
                              Common.GetValueByPath(fromObject, new string[] { "text" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "finished" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "finished" },
                              Common.GetValueByPath(fromObject, new string[] { "finished" }));
      }

      return toObject;
    }

    internal JsonNode UrlContextMetadataFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "urlMetadata" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "urlMetadata" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(
              UrlMetadataFromMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "urlMetadata" }, result);
      }

      return toObject;
    }

    internal JsonNode UrlContextToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode UrlContextToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode UrlMetadataFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "retrievedUrl" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "retrievedUrl" },
                              Common.GetValueByPath(fromObject, new string[] { "retrievedUrl" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "urlRetrievalStatus" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "urlRetrievalStatus" },
            Common.GetValueByPath(fromObject, new string[] { "urlRetrievalStatus" }));
      }

      return toObject;
    }

    internal JsonNode UsageMetadataFromMldev(JsonNode fromObject, JsonObject parentObject) {
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

      if (Common.GetValueByPath(fromObject, new string[] { "responseTokenCount" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseTokenCount" },
            Common.GetValueByPath(fromObject, new string[] { "responseTokenCount" }));
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
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "promptTokensDetails" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ModalityTokenCountFromMldev(JsonNode.Parse(JsonSerializer.Serialize(record)),
                                                 toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "promptTokensDetails" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "cacheTokensDetails" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "cacheTokensDetails" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ModalityTokenCountFromMldev(JsonNode.Parse(JsonSerializer.Serialize(record)),
                                                 toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "cacheTokensDetails" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseTokensDetails" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "responseTokensDetails" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ModalityTokenCountFromMldev(JsonNode.Parse(JsonSerializer.Serialize(record)),
                                                 toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "responseTokensDetails" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "toolUsePromptTokensDetails" }) !=
          null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(
            fromObject, new string[] { "toolUsePromptTokensDetails" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ModalityTokenCountFromMldev(JsonNode.Parse(JsonSerializer.Serialize(record)),
                                                 toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "toolUsePromptTokensDetails" }, result);
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
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "promptTokensDetails" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ModalityTokenCountFromVertex(JsonNode.Parse(JsonSerializer.Serialize(record)),
                                                  toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "promptTokensDetails" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "cacheTokensDetails" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "cacheTokensDetails" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ModalityTokenCountFromVertex(JsonNode.Parse(JsonSerializer.Serialize(record)),
                                                  toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "cacheTokensDetails" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "candidatesTokensDetails" }) != null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(
            fromObject, new string[] { "candidatesTokensDetails" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ModalityTokenCountFromVertex(JsonNode.Parse(JsonSerializer.Serialize(record)),
                                                  toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "responseTokensDetails" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "toolUsePromptTokensDetails" }) !=
          null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(
            fromObject, new string[] { "toolUsePromptTokensDetails" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ModalityTokenCountFromVertex(JsonNode.Parse(JsonSerializer.Serialize(record)),
                                                  toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "toolUsePromptTokensDetails" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "trafficType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "trafficType" },
                              Common.GetValueByPath(fromObject, new string[] { "trafficType" }));
      }

      return toObject;
    }

    internal JsonNode VideoMetadataFromMldev(JsonNode fromObject, JsonObject parentObject) {
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

    internal JsonNode VideoMetadataFromVertex(JsonNode fromObject, JsonObject parentObject) {
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

    internal JsonNode VideoMetadataToVertex(JsonNode fromObject, JsonObject parentObject) {
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

    internal JsonNode VoiceConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "prebuiltVoiceConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "prebuiltVoiceConfig" },
                              PrebuiltVoiceConfigToVertex(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "prebuiltVoiceConfig" }))),
                                  toObject));
      }

      return toObject;
    }
  }
}
