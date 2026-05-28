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
  class OperationsConverters {
    private readonly ApiClient _apiClient;

    public OperationsConverters(ApiClient apiClient) {
      _apiClient = apiClient;
    }

    internal JsonNode FetchPredictOperationParametersToMldev(JsonNode fromObject,
                                                             JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "operationName" }))) {
        throw new NotSupportedException(
            "operationName parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "resourceName" }))) {
        throw new NotSupportedException(
            "resourceName parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "config" }))) {
        throw new NotSupportedException(
            "config parameter is only supported in Gemini Enterprise Agent Platform mode, not in Gemini Developer API mode.");
      }

      return toObject;
    }

    internal JsonNode FetchPredictOperationParametersToVertex(JsonNode fromObject,
                                                              JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "operationName" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "operationName" },
                              Common.GetValueByPath(fromObject, new string[] { "operationName" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "resourceName" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "_url", "resourceName" },
                              Common.GetValueByPath(fromObject, new string[] { "resourceName" }));
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
                Common.ParseToJsonNode(Common.GetValueByPath(
                    fromObject, new string[] { "response", "generateVideoResponse" })),
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
        Common.SetValueByPath(
            toObject, new string[] { "response" },
            GenerateVideosResponseFromVertex(Common.ParseToJsonNode(Common.GetValueByPath(
                                                 fromObject, new string[] { "response" })),
                                             toObject));
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
          result.Add(GeneratedVideoFromMldev(Common.ParseToJsonNode(record), toObject));
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
          result.Add(GeneratedVideoFromVertex(Common.ParseToJsonNode(record), toObject));
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

    internal JsonNode GeneratedVideoFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "video" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "video" },
                              VideoFromMldev(Common.ParseToJsonNode(Common.GetValueByPath(
                                                 fromObject, new string[] { "video" })),
                                             toObject));
      }

      return toObject;
    }

    internal JsonNode GeneratedVideoFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "_self" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "video" },
                              VideoFromVertex(Common.ParseToJsonNode(Common.GetValueByPath(
                                                  fromObject, new string[] { "_self" })),
                                              toObject));
      }

      return toObject;
    }

    internal JsonNode GetOperationParametersToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "operationName" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "_url", "operationName" },
                              Common.GetValueByPath(fromObject, new string[] { "operationName" }));
      }

      return toObject;
    }

    internal JsonNode GetOperationParametersToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "operationName" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "_url", "operationName" },
                              Common.GetValueByPath(fromObject, new string[] { "operationName" }));
      }

      return toObject;
    }

    internal JsonNode ImportFileOperationFromMldev(JsonNode fromObject, JsonObject parentObject) {
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
        Common.SetValueByPath(
            toObject, new string[] { "response" },
            ImportFileResponseFromMldev(Common.ParseToJsonNode(Common.GetValueByPath(
                                            fromObject, new string[] { "response" })),
                                        toObject));
      }

      return toObject;
    }

    internal JsonNode ImportFileResponseFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "parent" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "parent" },
                              Common.GetValueByPath(fromObject, new string[] { "parent" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "documentName" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "documentName" },
                              Common.GetValueByPath(fromObject, new string[] { "documentName" }));
      }

      return toObject;
    }

    internal JsonNode UploadToFileSearchStoreOperationFromMldev(JsonNode fromObject,
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
        Common.SetValueByPath(
            toObject, new string[] { "response" },
            UploadToFileSearchStoreResponseFromMldev(Common.ParseToJsonNode(Common.GetValueByPath(
                                                         fromObject, new string[] { "response" })),
                                                     toObject));
      }

      return toObject;
    }

    internal JsonNode UploadToFileSearchStoreResponseFromMldev(JsonNode fromObject,
                                                               JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "parent" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "parent" },
                              Common.GetValueByPath(fromObject, new string[] { "parent" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "documentName" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "documentName" },
                              Common.GetValueByPath(fromObject, new string[] { "documentName" }));
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
  }
}
