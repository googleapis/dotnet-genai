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

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "" }))) {
        throw new NotSupportedException(" parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "" }))) {
        throw new NotSupportedException(" parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "" }))) {
        throw new NotSupportedException(" parameter is not supported in Gemini API.");
      }

      return toObject;
    }

    internal JsonNode FetchPredictOperationParametersToVertex(JsonNode fromObject,
                                                              JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode GenerateVideosOperationFromMldev(JsonNode fromObject,
                                                       JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode GenerateVideosOperationFromVertex(JsonNode fromObject,
                                                        JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode GenerateVideosResponseFromMldev(JsonNode fromObject,
                                                      JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode GenerateVideosResponseFromVertex(JsonNode fromObject,
                                                       JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode GeneratedVideoFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode GeneratedVideoFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode GetOperationParametersToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "" }))) {
        throw new NotSupportedException(" parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "" }))) {
        throw new NotSupportedException(" parameter is not supported in Gemini API.");
      }

      return toObject;
    }

    internal JsonNode GetOperationParametersToVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "" }))) {
        throw new NotSupportedException(" parameter is not supported in Vertex AI.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "" }))) {
        throw new NotSupportedException(" parameter is not supported in Vertex AI.");
      }

      return toObject;
    }

    internal JsonNode VideoFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode VideoFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }
  }
}
