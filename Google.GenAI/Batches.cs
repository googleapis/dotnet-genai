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

using System;
using Google.GenAI.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Google.GenAI {

  public sealed class Batches {
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

    internal JsonNode BatchJobDestinationFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "responsesFile" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "fileName" },
                              Common.GetValueByPath(fromObject, new string[] { "responsesFile" }));
      }

      if (Common.GetValueByPath(fromObject,
                                new string[] { "inlinedResponses", "inlinedResponses" }) != null) {
        JsonArray keyArray = (JsonArray)Common.GetValueByPath(
            fromObject, new string[] { "inlinedResponses", "inlinedResponses" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(
              InlinedResponseFromMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "inlinedResponses" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "inlinedEmbedContentResponses",
                                                           "inlinedResponses" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "inlinedEmbedContentResponses" },
            Common.GetValueByPath(
                fromObject, new string[] { "inlinedEmbedContentResponses", "inlinedResponses" }));
      }

      return toObject;
    }

    internal JsonNode BatchJobDestinationFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "predictionsFormat" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "format" },
            Common.GetValueByPath(fromObject, new string[] { "predictionsFormat" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "gcsDestination", "outputUriPrefix" }) !=
          null) {
        Common.SetValueByPath(
            toObject, new string[] { "gcsUri" },
            Common.GetValueByPath(fromObject,
                                  new string[] { "gcsDestination", "outputUriPrefix" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "bigqueryDestination", "outputUri" }) !=
          null) {
        Common.SetValueByPath(
            toObject, new string[] { "bigqueryUri" },
            Common.GetValueByPath(fromObject, new string[] { "bigqueryDestination", "outputUri" }));
      }

      return toObject;
    }

    internal JsonNode BatchJobDestinationToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "format" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "predictionsFormat" },
                              Common.GetValueByPath(fromObject, new string[] { "format" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "gcsUri" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "gcsDestination", "outputUriPrefix" },
                              Common.GetValueByPath(fromObject, new string[] { "gcsUri" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "bigqueryUri" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "bigqueryDestination", "outputUri" },
                              Common.GetValueByPath(fromObject, new string[] { "bigqueryUri" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "fileName" }))) {
        throw new NotSupportedException("fileName parameter is not supported in Vertex AI.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "inlinedResponses" }))) {
        throw new NotSupportedException(
            "inlinedResponses parameter is not supported in Vertex AI.");
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "inlinedEmbedContentResponses" }))) {
        throw new NotSupportedException(
            "inlinedEmbedContentResponses parameter is not supported in Vertex AI.");
      }

      return toObject;
    }

    internal JsonNode BatchJobFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "name" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "metadata", "displayName" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "displayName" },
            Common.GetValueByPath(fromObject, new string[] { "metadata", "displayName" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "metadata", "state" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "state" },
                              Transformers.TJobState(Common.GetValueByPath(
                                  fromObject, new string[] { "metadata", "state" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "metadata", "createTime" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "createTime" },
            Common.GetValueByPath(fromObject, new string[] { "metadata", "createTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "metadata", "endTime" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "endTime" },
            Common.GetValueByPath(fromObject, new string[] { "metadata", "endTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "metadata", "updateTime" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "updateTime" },
            Common.GetValueByPath(fromObject, new string[] { "metadata", "updateTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "metadata", "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "model" },
            Common.GetValueByPath(fromObject, new string[] { "metadata", "model" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "metadata", "output" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "dest" },
            BatchJobDestinationFromMldev(
                JsonNode.Parse(JsonSerializer.Serialize(Transformers.TRecvBatchJobDestination(
                    Common.GetValueByPath(fromObject, new string[] { "metadata", "output" })))),
                toObject));
      }

      return toObject;
    }

    internal JsonNode BatchJobFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "name" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "displayName" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "displayName" },
                              Common.GetValueByPath(fromObject, new string[] { "displayName" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "state" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "state" },
            Transformers.TJobState(Common.GetValueByPath(fromObject, new string[] { "state" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "error" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "error" },
                              Common.GetValueByPath(fromObject, new string[] { "error" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "createTime" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "createTime" },
                              Common.GetValueByPath(fromObject, new string[] { "createTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "startTime" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "startTime" },
                              Common.GetValueByPath(fromObject, new string[] { "startTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "endTime" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "endTime" },
                              Common.GetValueByPath(fromObject, new string[] { "endTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "updateTime" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "updateTime" },
                              Common.GetValueByPath(fromObject, new string[] { "updateTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "model" },
                              Common.GetValueByPath(fromObject, new string[] { "model" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "inputConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "src" },
            BatchJobSourceFromVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                         fromObject, new string[] { "inputConfig" }))),
                                     toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "dest" },
            BatchJobDestinationFromVertex(
                JsonNode.Parse(JsonSerializer.Serialize(Transformers.TRecvBatchJobDestination(
                    Common.GetValueByPath(fromObject, new string[] { "outputConfig" })))),
                toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "completionStats" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "completionStats" },
            Common.GetValueByPath(fromObject, new string[] { "completionStats" }));
      }

      return toObject;
    }

    internal JsonNode BatchJobSourceFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "instancesFormat" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "format" },
            Common.GetValueByPath(fromObject, new string[] { "instancesFormat" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "gcsSource", "uris" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "gcsUri" },
            Common.GetValueByPath(fromObject, new string[] { "gcsSource", "uris" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "bigquerySource", "inputUri" }) !=
          null) {
        Common.SetValueByPath(
            toObject, new string[] { "bigqueryUri" },
            Common.GetValueByPath(fromObject, new string[] { "bigquerySource", "inputUri" }));
      }

      return toObject;
    }

    internal JsonNode BatchJobSourceToMldev(ApiClient apiClient, JsonNode fromObject,
                                            JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "format" }))) {
        throw new NotSupportedException("format parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "gcsUri" }))) {
        throw new NotSupportedException("gcsUri parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "bigqueryUri" }))) {
        throw new NotSupportedException("bigqueryUri parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "fileName" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "fileName" },
                              Common.GetValueByPath(fromObject, new string[] { "fileName" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "inlinedRequests" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "inlinedRequests" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(InlinedRequestToMldev(
              apiClient, JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "requests", "requests" }, result);
      }

      return toObject;
    }

    internal JsonNode BatchJobSourceToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "format" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "instancesFormat" },
                              Common.GetValueByPath(fromObject, new string[] { "format" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "gcsUri" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "gcsSource", "uris" },
                              Common.GetValueByPath(fromObject, new string[] { "gcsUri" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "bigqueryUri" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "bigquerySource", "inputUri" },
                              Common.GetValueByPath(fromObject, new string[] { "bigqueryUri" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "fileName" }))) {
        throw new NotSupportedException("fileName parameter is not supported in Vertex AI.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "inlinedRequests" }))) {
        throw new NotSupportedException("inlinedRequests parameter is not supported in Vertex AI.");
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

    internal JsonNode CancelBatchJobParametersToMldev(ApiClient apiClient, JsonNode fromObject,
                                                      JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "name" },
            Transformers.TBatchJobName(this._apiClient,
                                       Common.GetValueByPath(fromObject, new string[] { "name" })));
      }

      return toObject;
    }

    internal JsonNode CancelBatchJobParametersToVertex(ApiClient apiClient, JsonNode fromObject,
                                                       JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "name" },
            Transformers.TBatchJobName(this._apiClient,
                                       Common.GetValueByPath(fromObject, new string[] { "name" })));
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

    internal JsonNode CreateBatchJobConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "displayName" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "batch", "displayName" },
                              Common.GetValueByPath(fromObject, new string[] { "displayName" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "dest" }))) {
        throw new NotSupportedException("dest parameter is not supported in Gemini API.");
      }

      return toObject;
    }

    internal JsonNode CreateBatchJobConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "displayName" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "displayName" },
                              Common.GetValueByPath(fromObject, new string[] { "displayName" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "dest" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "outputConfig" },
            BatchJobDestinationToVertex(
                JsonNode.Parse(JsonSerializer.Serialize(Transformers.TBatchJobDestination(
                    Common.GetValueByPath(fromObject, new string[] { "dest" })))),
                toObject));
      }

      return toObject;
    }

    internal JsonNode CreateBatchJobParametersToMldev(ApiClient apiClient, JsonNode fromObject,
                                                      JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "model" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "src" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "batch", "inputConfig" },
            BatchJobSourceToMldev(
                apiClient,
                JsonNode.Parse(JsonSerializer.Serialize(Transformers.TBatchJobSource(
                    Common.GetValueByPath(fromObject, new string[] { "src" })))),
                toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = CreateBatchJobConfigToMldev(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject);
      }

      return toObject;
    }

    internal JsonNode CreateBatchJobParametersToVertex(ApiClient apiClient, JsonNode fromObject,
                                                       JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "model" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "src" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "inputConfig" },
            BatchJobSourceToVertex(
                JsonNode.Parse(JsonSerializer.Serialize(Transformers.TBatchJobSource(
                    Common.GetValueByPath(fromObject, new string[] { "src" })))),
                toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = CreateBatchJobConfigToVertex(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject);
      }

      return toObject;
    }

    internal JsonNode CreateEmbeddingsBatchJobConfigToMldev(JsonNode fromObject,
                                                            JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "displayName" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "batch", "displayName" },
                              Common.GetValueByPath(fromObject, new string[] { "displayName" }));
      }

      return toObject;
    }

    internal JsonNode CreateEmbeddingsBatchJobParametersToMldev(ApiClient apiClient,
                                                                JsonNode fromObject,
                                                                JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "model" },
            Transformers.TModel(this._apiClient,
                                Common.GetValueByPath(fromObject, new string[] { "model" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "src" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "batch", "inputConfig" },
                              EmbeddingsBatchJobSourceToMldev(
                                  apiClient,
                                  JsonNode.Parse(JsonSerializer.Serialize(
                                      Common.GetValueByPath(fromObject, new string[] { "src" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = CreateEmbeddingsBatchJobConfigToMldev(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject);
      }

      return toObject;
    }

    internal JsonNode DeleteBatchJobParametersToMldev(ApiClient apiClient, JsonNode fromObject,
                                                      JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "name" },
            Transformers.TBatchJobName(this._apiClient,
                                       Common.GetValueByPath(fromObject, new string[] { "name" })));
      }

      return toObject;
    }

    internal JsonNode DeleteBatchJobParametersToVertex(ApiClient apiClient, JsonNode fromObject,
                                                       JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "name" },
            Transformers.TBatchJobName(this._apiClient,
                                       Common.GetValueByPath(fromObject, new string[] { "name" })));
      }

      return toObject;
    }

    internal JsonNode DeleteResourceJobFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "name" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "done" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "done" },
                              Common.GetValueByPath(fromObject, new string[] { "done" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "error" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "error" },
                              Common.GetValueByPath(fromObject, new string[] { "error" }));
      }

      return toObject;
    }

    internal JsonNode DeleteResourceJobFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "name" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "done" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "done" },
                              Common.GetValueByPath(fromObject, new string[] { "done" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "error" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "error" },
                              Common.GetValueByPath(fromObject, new string[] { "error" }));
      }

      return toObject;
    }

    internal JsonNode EmbedContentBatchToMldev(ApiClient apiClient, JsonNode fromObject,
                                               JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "contents" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "requests[]", "request", "content" },
            Transformers.TContentsForEmbed(
                this._apiClient, Common.GetValueByPath(fromObject, new string[] { "contents" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_self" },
            EmbedContentConfigToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                          fromObject, new string[] { "config" }))),
                                      toObject));
        Common.MoveValueByPath(
            toObject,
            new Dictionary<string, string> { { "requests[].*", "requests[].request.*" } });
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

    internal JsonNode EmbeddingsBatchJobSourceToMldev(ApiClient apiClient, JsonNode fromObject,
                                                      JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "fileName" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "file_name" },
                              Common.GetValueByPath(fromObject, new string[] { "fileName" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "inlinedRequests" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "requests" },
            EmbedContentBatchToMldev(apiClient,
                                     JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                         fromObject, new string[] { "inlinedRequests" }))),
                                     toObject));
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

    internal JsonNode GetBatchJobParametersToMldev(ApiClient apiClient, JsonNode fromObject,
                                                   JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "name" },
            Transformers.TBatchJobName(this._apiClient,
                                       Common.GetValueByPath(fromObject, new string[] { "name" })));
      }

      return toObject;
    }

    internal JsonNode GetBatchJobParametersToVertex(ApiClient apiClient, JsonNode fromObject,
                                                    JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "name" },
            Transformers.TBatchJobName(this._apiClient,
                                       Common.GetValueByPath(fromObject, new string[] { "name" })));
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

    internal JsonNode InlinedRequestToMldev(ApiClient apiClient, JsonNode fromObject,
                                            JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "model" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "request", "model" },
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
        Common.SetValueByPath(toObject, new string[] { "request", "contents" }, result);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "metadata" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "metadata" },
                              Common.GetValueByPath(fromObject, new string[] { "metadata" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "request", "generationConfig" },
            GenerateContentConfigToMldev(
                apiClient,
                JsonNode.Parse(JsonSerializer.Serialize(
                    Common.GetValueByPath(fromObject, new string[] { "config" }))),
                (JsonObject?)(Common.GetValueByPath(toObject, new string[] { "request" }) ??
                              new JsonObject())));
      }

      return toObject;
    }

    internal JsonNode InlinedResponseFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "response" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "response" },
                              GenerateContentResponseFromMldev(
                                  JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "response" }))),
                                  toObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "error" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "error" },
                              Common.GetValueByPath(fromObject, new string[] { "error" }));
      }

      return toObject;
    }

    internal JsonNode ListBatchJobsConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "pageSize" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "_query", "pageSize" },
                              Common.GetValueByPath(fromObject, new string[] { "pageSize" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "pageToken" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "_query", "pageToken" },
                              Common.GetValueByPath(fromObject, new string[] { "pageToken" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "filter" }))) {
        throw new NotSupportedException("filter parameter is not supported in Gemini API.");
      }

      return toObject;
    }

    internal JsonNode ListBatchJobsConfigToVertex(JsonNode fromObject, JsonObject parentObject) {
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

      return toObject;
    }

    internal JsonNode ListBatchJobsParametersToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = ListBatchJobsConfigToMldev(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject);
      }

      return toObject;
    }

    internal JsonNode ListBatchJobsParametersToVertex(JsonNode fromObject,
                                                      JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = ListBatchJobsConfigToVertex(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject);
      }

      return toObject;
    }

    internal JsonNode ListBatchJobsResponseFromMldev(JsonNode fromObject, JsonObject parentObject) {
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

      if (Common.GetValueByPath(fromObject, new string[] { "operations" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "operations" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(BatchJobFromMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "batchJobs" }, result);
      }

      return toObject;
    }

    internal JsonNode ListBatchJobsResponseFromVertex(JsonNode fromObject,
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

      if (Common.GetValueByPath(fromObject, new string[] { "batchPredictionJobs" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "batchPredictionJobs" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(
              BatchJobFromVertex(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "batchJobs" }, result);
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

    public Batches(ApiClient apiClient) {
      _apiClient = apiClient;
    }

    private async Task<BatchJob> PrivateCreateAsync(string? model, BatchJobSource src,
                                                    CreateBatchJobConfig? config) {
      CreateBatchJobParameters parameter = new CreateBatchJobParameters();

      if (!Common.IsZero(model)) {
        parameter.Model = model;
      }
      if (!Common.IsZero(src)) {
        parameter.Src = src;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse CreateBatchJobParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = CreateBatchJobParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("batchPredictionJobs", body["_url"]);
      } else {
        body = CreateBatchJobParametersToMldev(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("{model}:batchGenerateContent", body["_url"]);
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
        responseNode = BatchJobFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        responseNode = BatchJobFromMldev(httpContentNode, new JsonObject());
      }

      return JsonSerializer.Deserialize<BatchJob>(responseNode.ToString()) ??
             throw new InvalidOperationException("Failed to deserialize Task<BatchJob>.");
    }

    private async Task<BatchJob> PrivateCreateEmbeddingsAsync(
        string? model, EmbeddingsBatchJobSource src, CreateEmbeddingsBatchJobConfig? config) {
      CreateEmbeddingsBatchJobParameters parameter = new CreateEmbeddingsBatchJobParameters();

      if (!Common.IsZero(model)) {
        parameter.Model = model;
      }
      if (!Common.IsZero(src)) {
        parameter.Src = src;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException(
            "Failed to parse CreateEmbeddingsBatchJobParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      } else {
        body = CreateEmbeddingsBatchJobParametersToMldev(this._apiClient, parameterNode,
                                                         new JsonObject());
        path = Common.FormatMap("{model}:asyncBatchEmbedContent", body["_url"]);
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
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }

      if (!this._apiClient.VertexAI) {
        responseNode = BatchJobFromMldev(httpContentNode, new JsonObject());
      }

      return JsonSerializer.Deserialize<BatchJob>(responseNode.ToString()) ??
             throw new InvalidOperationException("Failed to deserialize Task<BatchJob>.");
    }

    /// <summary>
    /// Gets a batch job resource.
    /// </summary>
    /// <param name="name">A fully-qualified BatchJob resource name or ID.
    /// Example: "projects/.../locations/.../batchPredictionJobs/456"
    /// or "456" when project and location are initialized in the
    /// Vertex AI client. Or "batches/abc" using the Gemini Developer AI client.</param>
    /// <param name="config">A <see cref="GetBatchJobConfig"/> for configuring the get
    /// request.</param> <returns>A <see cref="BatchJob"/> object that contains the info of the
    /// batch job.</returns>

    public async Task<BatchJob> GetAsync(string name, GetBatchJobConfig? config = null) {
      GetBatchJobParameters parameter = new GetBatchJobParameters();

      if (!Common.IsZero(name)) {
        parameter.Name = name;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse GetBatchJobParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = GetBatchJobParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("batchPredictionJobs/{name}", body["_url"]);
      } else {
        body = GetBatchJobParametersToMldev(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("batches/{name}", body["_url"]);
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
        responseNode = BatchJobFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        responseNode = BatchJobFromMldev(httpContentNode, new JsonObject());
      }

      return JsonSerializer.Deserialize<BatchJob>(responseNode.ToString()) ??
             throw new InvalidOperationException("Failed to deserialize Task<BatchJob>.");
    }

    /// <summary>
    /// Cancels a batch job resource.
    /// </summary>
    /// <param name="name">A fully-qualified BatchJob resource name or ID.
    /// Example: "projects/.../locations/.../batchPredictionJobs/456"
    /// or "456" when project and location are initialized in the
    /// Vertex AI client. Or "batches/abc" using the Gemini Developer AI client.</param>
    /// <param name="config">A <see cref="CancelBatchJobConfig"/> for configuring the cancel
    /// request.</param> <returns>A <see cref="Task"/> that represents the asynchronous
    /// operation.</returns>

    public async Task CancelAsync(string name, CancelBatchJobConfig? config = null) {
      CancelBatchJobParameters parameter = new CancelBatchJobParameters();

      if (!Common.IsZero(name)) {
        parameter.Name = name;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse CancelBatchJobParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = CancelBatchJobParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("batchPredictionJobs/{name}:cancel", body["_url"]);
      } else {
        body = CancelBatchJobParametersToMldev(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("batches/{name}:cancel", body["_url"]);
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

      return;
    }

    private async Task<ListBatchJobsResponse> PrivateListAsync(ListBatchJobsConfig? config) {
      ListBatchJobsParameters parameter = new ListBatchJobsParameters();

      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse ListBatchJobsParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = ListBatchJobsParametersToVertex(parameterNode, new JsonObject());
        path = Common.FormatMap("batchPredictionJobs", body["_url"]);
      } else {
        body = ListBatchJobsParametersToMldev(parameterNode, new JsonObject());
        path = Common.FormatMap("batches", body["_url"]);
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
        responseNode = ListBatchJobsResponseFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        responseNode = ListBatchJobsResponseFromMldev(httpContentNode, new JsonObject());
      }

      return JsonSerializer.Deserialize<ListBatchJobsResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException(
                 "Failed to deserialize Task<ListBatchJobsResponse>.");
    }

    /// <summary>
    /// Deletes a batch job resource.
    /// </summary>
    /// <param name="name">A fully-qualified BatchJob resource name or ID.
    /// Example: "projects/.../locations/.../batchPredictionJobs/456"
    /// or "456" when project and location are initialized in the
    /// Vertex AI client. Or "batches/abc" using the Gemini Developer AI client.</param>
    /// <param name="config">A <see cref="DeleteBatchJobConfig"/> for configuring the delete
    /// request.</param> <returns>A <see cref="DeleteResourceJob"/> object that shows the status of
    /// the deletion.</returns>

    public async Task<DeleteResourceJob> DeleteAsync(string name,
                                                     DeleteBatchJobConfig? config = null) {
      DeleteBatchJobParameters parameter = new DeleteBatchJobParameters();

      if (!Common.IsZero(name)) {
        parameter.Name = name;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse DeleteBatchJobParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = DeleteBatchJobParametersToVertex(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("batchPredictionJobs/{name}", body["_url"]);
      } else {
        body = DeleteBatchJobParametersToMldev(this._apiClient, parameterNode, new JsonObject());
        path = Common.FormatMap("batches/{name}", body["_url"]);
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
        responseNode = DeleteResourceJobFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        responseNode = DeleteResourceJobFromMldev(httpContentNode, new JsonObject());
      }

      return JsonSerializer.Deserialize<DeleteResourceJob>(responseNode.ToString()) ??
             throw new InvalidOperationException("Failed to deserialize Task<DeleteResourceJob>.");
    }

    /// <summary>
    /// Makes an API request to list the available batch jobs.
    /// </summary>
    /// <param name="config">A <see cref="ListBatchJobsConfig"/> for configuring the list
    /// request.</param> <returns>A <see cref="Pager{BatchJob}"/> object that contains the list of
    /// batch jobs. The pager is an
    ///     iterable and automatically queries the next page once the current page is
    ///     exhausted.</returns>

    public async Task<Pager<BatchJob, ListBatchJobsConfig, ListBatchJobsResponse>> ListAsync(
        ListBatchJobsConfig? config = null) {
      config ??= new ListBatchJobsConfig();
      var initialResponse = await PrivateListAsync(config);

      return new Pager<BatchJob, ListBatchJobsConfig, ListBatchJobsResponse>(
          requestFunc: async cfg => await PrivateListAsync(cfg),
          extractItems: response => response.BatchJobs,
          extractNextPageToken: response => response.NextPageToken,
          extractHttpResponse: response => response.SdkHttpResponse,
          updateConfigPageToken: (cfg, token) => {
            cfg.PageToken = token;
            return cfg;
          }, initialConfig: config, initialResponse: initialResponse, requestedPageSize: config.PageSize ?? 0);
    }

    /// <summary>
    /// Creates a batch job.
    /// </summary>
    /// <param name="model">The model to use for the batch job.</param>
    /// <param name="src">The <see cref="BatchJobSource"/> of the batch job.
    /// Currently Vertex AI supports GCS URIs or BigQuery URI. Example: "gs://path/to/input/data" or
    /// "bq://projectId.bqDatasetId.bqTableId". Gemini Developer API supports List of
    /// inlined_request, or file name. Example: "files/file_name".</param> <param
    /// name="config">Optional <see cref="CreateBatchJobConfig"/> to configure the batch
    /// job.</param> <returns>A <see cref="Task{BatchJob}"/> that represents the asynchronous
    /// operation. The task result contains a <see cref="BatchJob"/> instance with batch job
    /// details.</returns>
    public async Task<BatchJob> CreateAsync(string model, BatchJobSource src,
                                            CreateBatchJobConfig config) {
      if (this._apiClient.VertexAI) {
        if (src.InlinedRequests != null) {
          throw new NotSupportedException("inlinedRequests is not supported for Vertex AI.");
        }
        if (src.FileName != null) {
          throw new NotSupportedException("fileName is not supported for Vertex AI.");
        }
        if (src.GcsUri != null && src.BigqueryUri != null) {
          throw new ArgumentException("Only one of gcsUri and bigqueryUri can be set.");
        }
        if (src.GcsUri == null && src.BigqueryUri == null) {
          throw new ArgumentException("One of gcsUri and bigqueryUri must be set.");
        }
      } else {
        if (src.FileName != null && src.InlinedRequests != null) {
          throw new ArgumentException("Only one of fileName and InlinedRequests can be set.");
        }
        if (src.FileName == null && src.InlinedRequests == null) {
          throw new ArgumentException("one of fileName and InlinedRequests must be set.");
        }
      }
      return await this.PrivateCreateAsync(model, src, config);
    }

    /// <summary>
    /// Makes an API request to create the batch embeddings job. This method is experimental.
    /// </summary>
    /// <param name="model">The model to use for the embeddings.</param>
    /// <param name="src">The <see cref="EmbeddingsBatchJobSource"/> of the batch job.
    /// Gemini Developer API supports List of inlined_request, or file name. Example:
    /// "files/file_name".</param> <param name="config">Optional <see
    /// cref="CreateEmbeddingsBatchJobConfig"/> to configure the batch job.</param> <returns>A <see
    /// cref="Task{BatchJob}"/> that represents the asynchronous operation. The task result contains
    /// a <see cref="BatchJob"/> instance with batch job details.</returns>
    public async Task<BatchJob> CreateEmbeddingsAsync(string model, EmbeddingsBatchJobSource src,
                                                      CreateEmbeddingsBatchJobConfig config) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException("Vertex AI does not support batches.createEmbeddings.");
      }
      return await this.PrivateCreateEmbeddingsAsync(model, src, config);
    }
  }
}
