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

  public sealed class Caches {
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

    internal JsonNode CreateCachedContentConfigToMldev(JsonNode fromObject,
                                                       JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "ttl" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "ttl" },
                              Common.GetValueByPath(fromObject, new string[] { "ttl" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "expireTime" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "expireTime" },
                              Common.GetValueByPath(fromObject, new string[] { "expireTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "displayName" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "displayName" },
                              Common.GetValueByPath(fromObject, new string[] { "displayName" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "contents" }) != null) {
        var keyList =
            Transformers.TContents(Common.GetValueByPath(fromObject, new string[] { "contents" }));
        JsonArray result = new JsonArray();

        foreach (var record in keyList) {
          result.Add(ContentToMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(parentObject, new string[] { "contents" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "systemInstruction" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "systemInstruction" },
            ContentToMldev(
                JsonNode.Parse(JsonSerializer.Serialize(Transformers.TContent(
                    Common.GetValueByPath(fromObject, new string[] { "systemInstruction" })))),
                toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tools" }) != null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(fromObject, new string[] { "tools" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(ToolToMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
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

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "kmsKeyName" }))) {
        throw new NotSupportedException("kmsKeyName parameter is not supported in Gemini API.");
      }

      return toObject;
    }

    internal JsonNode CreateCachedContentConfigToVertex(JsonNode fromObject,
                                                        JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "ttl" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "ttl" },
                              Common.GetValueByPath(fromObject, new string[] { "ttl" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "expireTime" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "expireTime" },
                              Common.GetValueByPath(fromObject, new string[] { "expireTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "displayName" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "displayName" },
                              Common.GetValueByPath(fromObject, new string[] { "displayName" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "contents" }) != null) {
        var keyList =
            Transformers.TContents(Common.GetValueByPath(fromObject, new string[] { "contents" }));
        JsonArray result = new JsonArray();

        foreach (var record in keyList) {
          result.Add(ContentToVertex(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(parentObject, new string[] { "contents" }, result);
      }

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

      if (Common.GetValueByPath(fromObject, new string[] { "toolConfig" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "toolConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "toolConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "kmsKeyName" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "encryption_spec", "kmsKeyName" },
                              Common.GetValueByPath(fromObject, new string[] { "kmsKeyName" }));
      }

      return toObject;
    }

    internal JsonNode CreateCachedContentParametersToMldev(ApiClient apiClient, JsonNode fromObject,
                                                           JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "model" },
            Transformers.TCachesModel(this._apiClient,
                                      Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = CreateCachedContentConfigToMldev(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject);
      }

      return toObject;
    }

    internal JsonNode CreateCachedContentParametersToVertex(ApiClient apiClient,
                                                            JsonNode fromObject,
                                                            JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "model" },
            Transformers.TCachesModel(this._apiClient,
                                      Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = CreateCachedContentConfigToVertex(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject);
      }

      return toObject;
    }

    internal JsonNode DeleteCachedContentParametersToMldev(ApiClient apiClient, JsonNode fromObject,
                                                           JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "name" },
            Transformers.TCachedContentName(
                this._apiClient, Common.GetValueByPath(fromObject, new string[] { "name" })));
      }

      return toObject;
    }

    internal JsonNode DeleteCachedContentParametersToVertex(ApiClient apiClient,
                                                            JsonNode fromObject,
                                                            JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "name" },
            Transformers.TCachedContentName(
                this._apiClient, Common.GetValueByPath(fromObject, new string[] { "name" })));
      }

      return toObject;
    }

    internal JsonNode DeleteCachedContentResponseFromMldev(JsonNode fromObject,
                                                           JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      return toObject;
    }

    internal JsonNode DeleteCachedContentResponseFromVertex(JsonNode fromObject,
                                                            JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
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

    internal JsonNode GetCachedContentParametersToMldev(ApiClient apiClient, JsonNode fromObject,
                                                        JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "name" },
            Transformers.TCachedContentName(
                this._apiClient, Common.GetValueByPath(fromObject, new string[] { "name" })));
      }

      return toObject;
    }

    internal JsonNode GetCachedContentParametersToVertex(ApiClient apiClient, JsonNode fromObject,
                                                         JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "name" },
            Transformers.TCachedContentName(
                this._apiClient, Common.GetValueByPath(fromObject, new string[] { "name" })));
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

    internal JsonNode ListCachedContentsConfigToMldev(JsonNode fromObject,
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

      return toObject;
    }

    internal JsonNode ListCachedContentsConfigToVertex(JsonNode fromObject,
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

      return toObject;
    }

    internal JsonNode ListCachedContentsParametersToMldev(JsonNode fromObject,
                                                          JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = ListCachedContentsConfigToMldev(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject);
      }

      return toObject;
    }

    internal JsonNode ListCachedContentsParametersToVertex(JsonNode fromObject,
                                                           JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = ListCachedContentsConfigToVertex(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject);
      }

      return toObject;
    }

    internal JsonNode ListCachedContentsResponseFromMldev(JsonNode fromObject,
                                                          JsonObject parentObject) {
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

      if (Common.GetValueByPath(fromObject, new string[] { "cachedContents" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "cachedContents" },
                              Common.GetValueByPath(fromObject, new string[] { "cachedContents" }));
      }

      return toObject;
    }

    internal JsonNode ListCachedContentsResponseFromVertex(JsonNode fromObject,
                                                           JsonObject parentObject) {
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

      if (Common.GetValueByPath(fromObject, new string[] { "cachedContents" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "cachedContents" },
                              Common.GetValueByPath(fromObject, new string[] { "cachedContents" }));
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

    internal JsonNode UpdateCachedContentConfigToMldev(JsonNode fromObject,
                                                       JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "ttl" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "ttl" },
                              Common.GetValueByPath(fromObject, new string[] { "ttl" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "expireTime" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "expireTime" },
                              Common.GetValueByPath(fromObject, new string[] { "expireTime" }));
      }

      return toObject;
    }

    internal JsonNode UpdateCachedContentConfigToVertex(JsonNode fromObject,
                                                        JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "ttl" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "ttl" },
                              Common.GetValueByPath(fromObject, new string[] { "ttl" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "expireTime" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "expireTime" },
                              Common.GetValueByPath(fromObject, new string[] { "expireTime" }));
      }

      return toObject;
    }

    internal JsonNode UpdateCachedContentParametersToMldev(ApiClient apiClient, JsonNode fromObject,
                                                           JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "name" },
            Transformers.TCachedContentName(
                this._apiClient, Common.GetValueByPath(fromObject, new string[] { "name" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = UpdateCachedContentConfigToMldev(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject);
      }

      return toObject;
    }

    internal JsonNode UpdateCachedContentParametersToVertex(ApiClient apiClient,
                                                            JsonNode fromObject,
                                                            JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "name" },
            Transformers.TCachedContentName(
                this._apiClient, Common.GetValueByPath(fromObject, new string[] { "name" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = UpdateCachedContentConfigToVertex(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject);
      }

      return toObject;
    }

    public Caches(ApiClient apiClient) {
      _apiClient = apiClient;
    }

    public async Task<CachedContent> CreateAsync(string model,
                                                 CreateCachedContentConfig? config = null) {
      CreateCachedContentParameters parameter = new CreateCachedContentParameters();

      if (!Common.IsZero(model)) {
        parameter.Model = model;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException(
            "Failed to parse CreateCachedContentParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body =
            CreateCachedContentParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("cachedContents", body["_url"]);
      } else {
        body =
            CreateCachedContentParametersToMldev(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("cachedContents", body["_url"]);
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
        responseNode = httpContentNode;
      }

      if (!this._apiClient.VertexAI) {
        responseNode = httpContentNode;
      }

      return JsonSerializer.Deserialize<CachedContent>(responseNode.ToString()) ??
             throw new InvalidOperationException("Failed to deserialize Task<CachedContent>.");
    }

    public async Task<CachedContent> GetAsync(string name, GetCachedContentConfig? config = null) {
      GetCachedContentParameters parameter = new GetCachedContentParameters();

      if (!Common.IsZero(name)) {
        parameter.Name = name;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse GetCachedContentParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = GetCachedContentParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{name}", body["_url"]);
      } else {
        body = GetCachedContentParametersToMldev(this._apiClient, parameterNode, new JsonObject());
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
        responseNode = httpContentNode;
      }

      if (!this._apiClient.VertexAI) {
        responseNode = httpContentNode;
      }

      return JsonSerializer.Deserialize<CachedContent>(responseNode.ToString()) ??
             throw new InvalidOperationException("Failed to deserialize Task<CachedContent>.");
    }

    public async Task<DeleteCachedContentResponse> DeleteAsync(
        string name, DeleteCachedContentConfig? config = null) {
      DeleteCachedContentParameters parameter = new DeleteCachedContentParameters();

      if (!Common.IsZero(name)) {
        parameter.Name = name;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException(
            "Failed to parse DeleteCachedContentParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body =
            DeleteCachedContentParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{name}", body["_url"]);
      } else {
        body =
            DeleteCachedContentParametersToMldev(this._apiClient, parameterNode, new JsonObject());
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
        responseNode = DeleteCachedContentResponseFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        responseNode = DeleteCachedContentResponseFromMldev(httpContentNode, new JsonObject());
      }

      return JsonSerializer.Deserialize<DeleteCachedContentResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException(
                 "Failed to deserialize Task<DeleteCachedContentResponse>.");
    }

    public async Task<CachedContent> UpdateAsync(string name,
                                                 UpdateCachedContentConfig? config = null) {
      UpdateCachedContentParameters parameter = new UpdateCachedContentParameters();

      if (!Common.IsZero(name)) {
        parameter.Name = name;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException(
            "Failed to parse UpdateCachedContentParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body =
            UpdateCachedContentParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{name}", body["_url"]);
      } else {
        body =
            UpdateCachedContentParametersToMldev(this._apiClient, parameterNode, new JsonObject());
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
        responseNode = httpContentNode;
      }

      if (!this._apiClient.VertexAI) {
        responseNode = httpContentNode;
      }

      return JsonSerializer.Deserialize<CachedContent>(responseNode.ToString()) ??
             throw new InvalidOperationException("Failed to deserialize Task<CachedContent>.");
    }

    private async Task<ListCachedContentsResponse> PrivateListAsync(
        ListCachedContentsConfig? config) {
      ListCachedContentsParameters parameter = new ListCachedContentsParameters();

      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException(
            "Failed to parse ListCachedContentsParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = ListCachedContentsParametersToVertex(parameterNode, new JsonObject());
        path = Common.FormatMap("cachedContents", body["_url"]);
      } else {
        body = ListCachedContentsParametersToMldev(parameterNode, new JsonObject());
        path = Common.FormatMap("cachedContents", body["_url"]);
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
        responseNode = ListCachedContentsResponseFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        responseNode = ListCachedContentsResponseFromMldev(httpContentNode, new JsonObject());
      }

      return JsonSerializer.Deserialize<ListCachedContentsResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException(
                 "Failed to deserialize Task<ListCachedContentsResponse>.");
    }

    /// <summary>
    /// Lists cached contents asynchronously.
    /// </summary>
    /// <param name="config">A <see cref="ListCachedContentsConfig"/> instance that specifies the
    /// optional configuration for the list request.</param> <returns>A Pager object that contains
    /// one page of cached contents. When iterating over the pager, it automatically fetches the
    /// next page if there are more.</returns>

    public async Task<Pager<CachedContent, ListCachedContentsConfig, ListCachedContentsResponse>>
    ListAsync(ListCachedContentsConfig? config = null) {
      config ??= new ListCachedContentsConfig();
      var initialResponse = await PrivateListAsync(config);

      return new Pager<CachedContent, ListCachedContentsConfig, ListCachedContentsResponse>(
          requestFunc: async cfg => await PrivateListAsync(cfg),
          extractItems: response => response.CachedContents,
          extractNextPageToken: response => response.NextPageToken,
          extractHttpResponse: response => response.SdkHttpResponse,
          updateConfigPageToken: (cfg, token) => {
            cfg.PageToken = token;
            return cfg;
          }, initialConfig: config, initialResponse: initialResponse, requestedPageSize: config.PageSize ?? 0);
    }
  }
}
