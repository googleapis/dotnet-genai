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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Google.GenAI.Types;

namespace Google.GenAI
{
  /// <summary>
  /// Provides methods for managing the ephemeral auth tokens. The tokens module is experimental.
  /// </summary>
  public sealed class Tokens
  {
    private readonly ApiClient _apiClient;

    internal Tokens(ApiClient apiClient)
    {
      _apiClient = apiClient;
    }

    /// <summary>
    /// Returns a comma-separated list of field masks from a given object.
    /// </summary>
    internal static string GetFieldMasks(JsonObject setup)
    {
      List<string> fields = new List<string>();

      foreach (var entry in setup)
      {
        string key = entry.Key;
        JsonNode? value = entry.Value;

        // 2nd layer, recursively get field masks
        if (value is JsonObject obj && obj.Count > 0)
        {
          foreach (var subEntry in obj)
          {
            fields.Add(key + "." + subEntry.Key);
          }
        }
        else
        {
          fields.Add(key); // 1st layer
        }
      }
      return string.Join(",", fields);
    }

    /// <summary>
    /// Converts the bidi setup in the config to the token setup.
    /// </summary>
    internal JsonObject ConvertBidiSetupToTokenSetup(JsonObject body, CreateAuthTokenConfig? config)
    {
      string json = body.ToJsonString();
      JsonObject transformedBody = JsonNode.Parse(json)!.AsObject();

      if (transformedBody.TryGetPropertyValue("bidiGenerateContentSetup", out JsonNode? bidiVal))
      {
        if (bidiVal is JsonObject bidiObj && bidiObj.TryGetPropertyValue("setup", out JsonNode? innerSetup))
        {
          transformedBody["bidiGenerateContentSetup"] = innerSetup?.DeepClone();
        }
        else
        {
          transformedBody.Remove("bidiGenerateContentSetup");
        }
      }
      else
      {
        transformedBody.Remove("bidiGenerateContentSetup");
      }

      // Extract Pre-existing field mask
      List<string> preExistingFieldMaskList = new List<string>();
      if (body.TryGetPropertyValue("fieldMask", out JsonNode? preExistingFieldMask) && preExistingFieldMask is JsonArray arr)
      {
        foreach (var element in arr)
        {
          if (element != null)
          {
             preExistingFieldMaskList.Add(element.ToString());
          }
        }
      }

      // Handle mask generation setup.
      if (transformedBody.TryGetPropertyValue("bidiGenerateContentSetup", out JsonNode? setupForMaskGenNode) && setupForMaskGenNode is JsonObject setupForMaskGeneration)
      {
        string generatedMaskFromBidi = GetFieldMasks(setupForMaskGeneration);

        bool configLockExists = config != null && config.LockAdditionalFields != null;
        bool preExistingValid = preExistingFieldMaskList.Count > 0;

        if (configLockExists && config.LockAdditionalFields.Count == 0)
        {
          // Case 1: lockAdditionalFields is an empty array. Lock only fields from bidi setup.
          if (!string.IsNullOrEmpty(generatedMaskFromBidi))
          {
            transformedBody["fieldMask"] = generatedMaskFromBidi;
          }
          else
          {
            transformedBody.Remove("fieldMask");
          }
        }
        else if (configLockExists && config.LockAdditionalFields.Count > 0 && preExistingValid)
        {
          // Case 2: Lock fields from bidi setup + additional fields.
          List<string> generationConfigFields = new List<string> {
            "temperature", "topK", "top_k", "topP", "top_p",
            "maxOutputTokens", "max_output_tokens",
            "responseModalities", "response_modalities",
            "seed", "speechConfig", "speech_config"
          };

          List<string> mappedFieldsFromPreExisting = new List<string>();
          foreach (string field in preExistingFieldMaskList)
          {
            if (generationConfigFields.Contains(field))
            {
              mappedFieldsFromPreExisting.Add("generationConfig." + field);
            }
            else
            {
              mappedFieldsFromPreExisting.Add(field);
            }
          }

          List<string> finalMaskParts = new List<string>();
          if (!string.IsNullOrEmpty(generatedMaskFromBidi))
          {
            finalMaskParts.Add(generatedMaskFromBidi);
          }
          finalMaskParts.AddRange(mappedFieldsFromPreExisting);

          if (finalMaskParts.Count > 0)
          {
            transformedBody["fieldMask"] = string.Join(",", finalMaskParts);
          }
          else
          {
            transformedBody.Remove("fieldMask");
          }
        }
        else
        {
          // Case 3: "Lock all fields"
          transformedBody.Remove("fieldMask");
        }
      }
      else
      {
        // No valid `bidiGenerateContentSetup` found.
        if (preExistingFieldMaskList.Count > 0)
        {
          transformedBody["fieldMask"] = string.Join(",", preExistingFieldMaskList);
        }
        else
        {
          transformedBody.Remove("fieldMask");
        }
      }

      return transformedBody;
    }

    /// <summary>
    /// Creates an ephemeral auth token resource.
    /// </summary>
    public async Task<AuthToken> CreateAsync(CreateAuthTokenConfig? config = null, CancellationToken cancellationToken = default)
    {
      if (_apiClient.VertexAI)
      {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }

      var parameterNode = new JsonObject();
      if (config != null)
      {
          parameterNode["config"] = JsonSerializer.SerializeToNode(config);
      }

      var converters = new TokensConverters(_apiClient);
      var bodyNode = converters.CreateAuthTokenParametersToMldev(_apiClient, parameterNode, new JsonObject());
      JsonObject body = bodyNode.AsObject();

      string path = "auth_tokens";
      if (body.TryGetPropertyValue("_url", out JsonNode? urlNode))
      {
          path = urlNode.ToString();
          body.Remove("_url");
      }

      if (body.TryGetPropertyValue("_query", out JsonNode? queryNode))
      {
        string queryString = queryNode.ToString();
        body.Remove("_query");
        if (!string.IsNullOrEmpty(queryString)) {
          path = $"{path}?{queryString}";
        }
      }

      JsonObject transformedBody = ConvertBidiSetupToTokenSetup(body, config);
      transformedBody.Remove("config");

      // Send request
      var response = await _apiClient.RequestAsync(
          HttpMethod.Post,
          path,
          transformedBody.ToJsonString(),
          null,
          cancellationToken);
#if NETSTANDARD2_0
      string responseString = await response.GetEntity().ReadAsStringAsync();
#else
      string responseString = await response.GetEntity().ReadAsStringAsync(cancellationToken);
#endif
      var authToken = JsonSerializer.Deserialize<AuthToken>(responseString, JsonConfig.JsonSerializerOptions);
      return authToken;
    }
  }
}
