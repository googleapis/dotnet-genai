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
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

using Google.GenAI.Types;

namespace Google.GenAI {

  public sealed class Operations {
    private readonly ApiClient _apiClient;

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

    public Operations(ApiClient apiClient) {
      _apiClient = apiClient;
    }

    internal async Task<JsonNode> PrivateGetVideosOperationAsync(
        string operationName, GetOperationConfig? config,
        CancellationToken cancellationToken = default) {
      GetOperationParameters parameter = new GetOperationParameters();

      if (!Common.IsZero(operationName)) {
        parameter.OperationName = operationName;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse GetOperationParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = GetOperationParametersToVertex(parameterNode, new JsonObject());
        path = Common.FormatMap("{operationName}", body["_url"]);
      } else {
        body = GetOperationParametersToMldev(parameterNode, new JsonObject());
        path = Common.FormatMap("{operationName}", body["_url"]);
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

      ApiResponse response =
          await this._apiClient.RequestAsync(HttpMethod.Get, path, JsonSerializer.Serialize(body),
                                             requestHttpOptions, cancellationToken);
      HttpContent httpContent = response.GetEntity();
#if NETSTANDARD2_0
      string contentString = await httpContent.ReadAsStringAsync();
#else
      string contentString = await httpContent.ReadAsStringAsync(cancellationToken);
#endif
      JsonNode? httpContentNode = JsonNode.Parse(contentString);
      if (httpContentNode == null) {
        throw new NotSupportedException("Failed to parse response to JsonNode.");
      }
      JsonNode responseNode = httpContentNode;

      return responseNode;
    }

    internal async Task<JsonNode> PrivateFetchPredictVideosOperationAsync(
        string operationName, string resourceName, FetchPredictOperationConfig? config,
        CancellationToken cancellationToken = default) {
      FetchPredictOperationParameters parameter = new FetchPredictOperationParameters();

      if (!Common.IsZero(operationName)) {
        parameter.OperationName = operationName;
      }
      if (!Common.IsZero(resourceName)) {
        parameter.ResourceName = resourceName;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException(
            "Failed to parse FetchPredictOperationParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = FetchPredictOperationParametersToVertex(parameterNode, new JsonObject());
        path = Common.FormatMap("{resourceName}:fetchPredictOperation", body["_url"]);
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

      ApiResponse response =
          await this._apiClient.RequestAsync(HttpMethod.Post, path, JsonSerializer.Serialize(body),
                                             requestHttpOptions, cancellationToken);
      HttpContent httpContent = response.GetEntity();
#if NETSTANDARD2_0
      string contentString = await httpContent.ReadAsStringAsync();
#else
      string contentString = await httpContent.ReadAsStringAsync(cancellationToken);
#endif
      JsonNode? httpContentNode = JsonNode.Parse(contentString);
      if (httpContentNode == null) {
        throw new NotSupportedException("Failed to parse response to JsonNode.");
      }
      JsonNode responseNode = httpContentNode;

      return responseNode;
    }

    /// <summary>
    /// Gets the status of a long-running operation.
    /// </summary>
    /// <typeparam name="TOperation">The type of the operation.</typeparam>
    /// <param name="operation">An operation instance to get the status for.</param>
    /// <param name="config">A <see cref="GetOperationConfig"/> instance that specifies the optional
    /// configurations.</param> <param name="cancellationToken">A <see cref="CancellationToken"/>
    /// that can be used to cancel the operation.</param> <returns>A <see cref="Task{TOperation}"/>
    /// that represents the asynchronous operation. The task result contains the updated
    /// <typeparamref name="TOperation"/> instance with the latest status or result.</returns>
    public async Task<TOperation> GetAsync<TOperation>(
        TOperation operation, GetOperationConfig? config,
        CancellationToken cancellationToken = default)
        where TOperation : Operation<TOperation> {
      if (string.IsNullOrEmpty(operation.Name)) {
        throw new ArgumentException("Operation name is required.", nameof(operation));
      }

      string operationName = operation.Name;

      if (this._apiClient.VertexAI) {
        string resourceName =
            operationName.Split(new[] { "/operations/" }, StringSplitOptions.None)[0];
        FetchPredictOperationConfig fetchConfig = new FetchPredictOperationConfig {};
        if (config != null) {
          fetchConfig.HttpOptions = config.HttpOptions;
        }
        JsonNode response = await this.PrivateFetchPredictVideosOperationAsync(
            operationName, resourceName, fetchConfig, cancellationToken);

        return operation.FromApiResponse(response, true);
      } else {
        JsonNode response =
            await this.PrivateGetVideosOperationAsync(operationName, config, cancellationToken);
        return operation.FromApiResponse(response, false);
      }
    }
  }
}
