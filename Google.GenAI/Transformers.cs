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

using System.Text.Json;
using System.Text.Json.Nodes;

using Google.GenAI.Types;


namespace Google.GenAI
{
  /// <summary>
  /// Transformers for GenAI SDK.
  /// </summary>
  internal static class Transformers
  {
    /// <summary>
    /// Transforms a model name to the correct format for the API.
    /// </summary>
    /// <param name="apiClient">The API client to use for transformation.</param>
    /// <param name="origin">The model name to transform, can only be a string.</param>
    /// <returns>The transformed model name.</returns>
    /// <exception cref="ArgumentException">If the object is not a supported type.</exception>
    internal static string? TModel(ApiClient apiClient, object origin)
    {
      string? model;
      if (origin == null)
      {
        return null;
      }
      else if (origin is string strModel)
      {
        model = strModel;
      }
      else if (origin is JsonNode jsonNode)
      {
        model = jsonNode.ToString();
        model = model.Replace("\"", "");
      }
      else
      {
        throw new ArgumentException($"Unsupported model type: {origin.GetType()}");
      }

      if (apiClient.VertexAI)
      {
        if (model.StartsWith("publishers/")
            || model.StartsWith("projects/")
            || model.StartsWith("models/"))
        {
          return model;
        }
        else if (model.Contains("/"))
        {
          string[] parts = model.Split('/', 2);
          return string.Format("publishers/{0}/models/{1}", parts[0], parts[1]);
        }
        else
        {
          return "publishers/google/models/" + model;
        }
      }
      else
      {
        if (model.StartsWith("models/") || model.StartsWith("tunedModels/"))
        {
          return model;
        }
        else
        {
          return "models/" + model;
        }
      }
    }

    /// <summary>
    /// Determines the appropriate models URL based on the API client type and whether base models are
    /// requested.
    /// </summary>
    /// <param name="apiClient">The API client to use for transformation.</param>
    /// <param name="baseModels">True if base models are requested, false otherwise.</param>
    /// <returns>The transformed model name</returns>
    internal static string TModelsUrl(ApiClient apiClient, object? baseModels)
    {
      if (apiClient.VertexAI)
      {
        if (baseModels == null)
        {
          return "publishers/google/models";
        }
        else
        {
          return "models";
        }
      }
      else
      {
        if (baseModels == null)
        {
          return "models";
        }
        else
        {
          return "tunedModels";
        }
      }
    }

    /// <summary>
    /// Transforms an object to a list of Content for the API.
    /// </summary>
    /// <param name="contents">The object to transform, can be a string, Content, or List&lt;Content&gt;</param>
    /// <returns>The transformed list of Content</returns>
    /// <exception cref="ArgumentException">If the object is not a supported type</exception>
    internal static List<Content>? TContents(object? contents)
    {
      if (contents == null)
      {
        return null;
      }
      if (contents is string contentString)
      {
        Content content = new Content();
        content.Role = "user";
        Part part = new Part();
        part.Text = contentString;
        content.Parts = new List<Part> { part };
        return new List<Content> { content };
      }
      else if (contents is Content singleContent)
      {
        return new List<Content> { singleContent };
      }
      else if (contents is List<Content> contentList)
      {
        return contentList;
      }
      else if (contents is JsonObject jsonObject)
      {
        return JsonSerializer.Deserialize<List<Content>>(jsonObject.ToString());
      }

      throw new ArgumentException($"Unsupported contents type: {contents.GetType()}");
    }

    /// <summary>
    /// Transforms an object to a Content for the API.
    /// </summary>
    /// <param name="content">The object to transform, can be a string or Content</param>
    /// <returns>The transformed Content</returns>
    /// <exception cref="ArgumentException">If the object is not a supported type</exception>
    internal static Content? TContent(object content)
    {
      if (content == null)
      {
        return null;
      }
      else if (content is string contentString)
      {
        Content contentObject = new Content();
        contentObject.Role = "user";
        Part part = new Part();
        part.Text = contentString;
        contentObject.Parts = new List<Part> { part };
        return contentObject;
      }
      else if (content is Content singleContent)
      {
        return singleContent;
      }
      else if (content is JsonObject jsonObject)
      {
        return JsonSerializer.Deserialize<Content>(jsonObject.ToString());
      }

      throw new ArgumentException($"Unsupported content type: {content.GetType()}");
    }

    /// <summary>Transforms an object to a Schema for the API.</summary>
    /// <exception cref="ArgumentException">If the object is not a supported type.</exception>
    internal static Schema? TSchema(object origin)
    {
      if (origin == null)
      {
        return null;
      }
      else if (origin is Schema schema)
      {
        return schema;
      }
      else if (origin is JsonObject jsonObject)
      {
        return JsonSerializer.Deserialize<Schema>(jsonObject.ToString());
      }
      throw new ArgumentException($"Unsupported schema type: {origin.GetType()}");
    }

    internal static SpeechConfig? TSpeechConfig(object speechConfig)
    {
      if (speechConfig == null)
      {
        return null;
      }
      else if (speechConfig is string speechConfigString)
      {
        return null;
      }
      else if (speechConfig is SpeechConfig config)
      {
        return config;
      }
      else if (speechConfig is JsonObject jsonObject)
      {
        return JsonSerializer.Deserialize<SpeechConfig>(jsonObject.ToString());
      }

      throw new ArgumentException($"Unsupported speechConfig type:{speechConfig.GetType()}");
    }

    /// <summary>Transforms an object to a list of Tools for the API.</summary>
    /// <exception cref="ArgumentException">If the object is not a supported type.</exception>
    internal static List<Tool>? TTools(object origin)
    {
      if (origin == null)
      {
        return null;
      }
      else if (origin is List<Tool> tools)
      {
        List<Tool> transformedTools = new List<Tool>();
        foreach (Tool tool in tools)
        {
          transformedTools.Add(TTool(tool)!);
        }
        return transformedTools;
      }
      else if (origin is JsonObject jsonObject)
      {
        return JsonSerializer.Deserialize<List<Tool>>(jsonObject.ToString());
      }

      throw new ArgumentException($"Unsupported tools type: {origin.GetType()}");
    }

    /// <summary>Transforms an object to a Tool for the API.</summary>
    /// <exception cref="ArgumentException">If the object is not a supported type.</exception>
    internal static Tool? TTool(object origin)
    {
      if (origin == null)
      {
        return null;
      }
      else if (origin is Tool tool)
      {
        // TODO(b/413510963): Complete tool converter.
        return JsonSerializer.Deserialize<Tool>(origin.ToString());
      }
      else if (origin is JsonObject jsonObject)
      {
        // In case reflectMethods is present in the json node, call TTool to parse it and remove it
        // from the json node.
        return JsonSerializer.Deserialize<Tool>(origin.ToString());
      }

      throw new ArgumentException($"Unsupported tool type: {origin.GetType()}");
    }

    /// <summary>Dummy Blobs transformer.</summary>
    internal static JsonArray TBlobs(object origin)
    {
      JsonNode inputNode;

      if (origin is not JsonNode)
      {
        inputNode = JsonNode.Parse(JsonSerializer.Serialize(origin, JsonConfig.JsonSerializerOptions))!;
      }
      else
      {
        inputNode = (JsonNode)origin;
      }

      if (inputNode is JsonArray existingArray)
      {
        return existingArray;
      }

      JsonArray arrayNode = new JsonArray();
      arrayNode.Add(JsonNode.Parse(JsonSerializer.Serialize(TBlob(origin), JsonConfig.JsonSerializerOptions)));
      return arrayNode;
    }

    internal static Blob TBlob(object blob)
    {
      if (blob is JsonObject jsonObject)
      {
        blob = JsonSerializer.Deserialize<Blob>(jsonObject.ToString());
      }

      if (blob is Blob b)
      {
        return b;
      }
      else
      {
        throw new ArgumentException($"Unsupported blob type: {blob.GetType()}");
      }
    }

    /// <summary>
    /// Transforms a blob to an image blob, validating its mime type.
    /// </summary>
    /// <param name="blob">The object to transform, can be a Blob or a dictionary.</param>
    /// <returns>The transformed Blob if it is an image.</returns>
    /// <exception cref="ArgumentException">If the blob is not an image.</exception>
    internal static Blob TImageBlob(object blob)
    {
      Blob transformedBlob = TBlob(blob);
      if (!string.IsNullOrEmpty(transformedBlob.MimeType)
          && transformedBlob.MimeType.StartsWith("image/"))
      {
        return transformedBlob;
      }
      throw new ArgumentException(
          $"Unsupported mime type for image blob: {transformedBlob.MimeType ?? "null"}");
    }

    /// <summary>
    /// Transforms a blob to an audio blob, validating its mime type.
    /// </summary>
    /// <param name="blob">The object to transform, can be a Blob or a dictionary.</param>
    /// <returns>The transformed Blob if it is an audio.</returns>
    /// <exception cref="ArgumentException">If the blob is not an audio.</exception>
    internal static Blob TAudioBlob(object blob)
    {
      Blob transformedBlob = TBlob(blob);
      if (!string.IsNullOrEmpty(transformedBlob.MimeType)
          && transformedBlob.MimeType.StartsWith("audio/"))
      {
        return transformedBlob;
      }
      throw new ArgumentException(
          $"Unsupported mime type for audio blob: {transformedBlob.MimeType ?? "null"}");
    }

    /// <summary>Dummy bytes transformer.</summary>
    internal static object TBytes(object origin)
    {
      // TODO(b/389133914): Remove dummy bytes converter.
      return origin;
    }

    /// <summary>Transforms an object to a cached content name for the API.</summary>
    internal static string? TCachedContentName(ApiClient apiClient, object origin)
    {
      if (origin == null)
      {
        return null;
      }
      else if (origin is string strOrigin)
      {
        return GetResourceName(apiClient, strOrigin, "cachedContents");
      }
      else if (origin is JsonNode jsonNode)
      {
        string cachedContentName = jsonNode.ToString();
        cachedContentName = cachedContentName.Replace("\"", "");
        return GetResourceName(apiClient, cachedContentName, "cachedContents");
      }

      throw new ArgumentException(
          $"Unsupported cached content name type: {origin.GetType()}");
    }

    /// <summary>Transforms an object to a list of Content for the embedding API.</summary>
    internal static List<object>? TContentsForEmbed(ApiClient apiClient, object origin)
    {
      if (origin == null)
      {
        return null;
      }

      List<Content>? contents;
      if (origin is List<Content> contentList)
      {
        contents = contentList;
      }
      /*else if (origin is JsonObject jsonObject)
      {
          contents = jsonObject.ToObject<List<Content>>();
      }*/
      else
      {
        throw new ArgumentException($"Unsupported contents type: {origin.GetType()}");
      }

      List<object> result = new List<object>();
      if (contents != null)
      {
        foreach (Content content in contents)
        {
          if (!apiClient.VertexAI)
          {
            result.Add(content);
          }
          else
          {
            if (content.Parts != null)
            {
              foreach (Part part in content.Parts)
              {
                if (part.Text != null)
                {
                  result.Add(part.Text);
                }
              }
            }
          }
        }
      }
      return result;
    }

    /// <summary>
    /// Transforms a model name to the correct format for the Caches API.
    /// </summary>
    /// <param name="apiClient">The API client to use for transformation</param>
    /// <param name="origin">The model name to transform, can be a string or JsonNode</param>
    /// <returns>The transformed model name, or null if the input is null</returns>
    /// <exception cref="ArgumentException">If the object is not a supported type</exception>
    internal static string? TCachesModel(ApiClient apiClient, object origin)
    {
      string? model = TModel(apiClient, origin);
      if (model == null)
      {
        return null;
      }

      if (apiClient.VertexAI)
      {
        if (model.StartsWith("publishers/"))
        {
          // Vertex caches only support model names starting with projects.
          return string.Format(
              "projects/{0}/locations/{1}/{2}", apiClient.Project, apiClient.Location, model);
        }
        else if (model.StartsWith("models/"))
        {
          return string.Format(
              "projects/{0}/locations/{1}/publishers/google/{2}",
              apiClient.Project, apiClient.Location, model);
        }
      }
      return model;
    }

    internal static string? TFileName(object? origin)
    {
      string? name = null;

      if (origin is string strName)
      {
        name = strName;
      }
      else if (origin == null)
      {
        return null;
      }
      else
      {
        throw new ArgumentException($"Unsupported file name type: {origin.GetType()}");
      }

      return name;
    }

    /// <summary>Formats a resource name given the resource name and resource prefix.</summary>
    private static string GetResourceName(
        ApiClient apiClient, string resourceName, string resourcePrefix)
    {
      if (apiClient.VertexAI)
      {
        if (resourceName.StartsWith("projects/"))
        {
          return resourceName;
        }
        else if (resourceName.StartsWith("locations/"))
        {
          return string.Format("projects/{0}/{1}", apiClient.Project, resourceName);
        }
        else if (resourceName.StartsWith(resourcePrefix + "/"))
        {
          return string.Format(
              "projects/{0}/locations/{1}/{2}", apiClient.Project, apiClient.Location, resourceName);
        }
        else
        {
          return string.Format(
              "projects/{0}/locations/{1}/{2}/{3}",
              apiClient.Project, apiClient.Location, resourcePrefix, resourceName);
        }
      }
      else
      {
        if (resourceName.StartsWith(resourcePrefix + "/"))
        {
          return resourceName;
        }
        else
        {
          return string.Format("{0}/{1}", resourcePrefix, resourceName);
        }
      }
    }

    internal static JsonNode TTuningJobStatus(JsonNode origin)
    {
      // TODO(b/413510963): Complete this converter, currently a placeholder.
      return origin;
    }

    internal static JsonNode TBatchJobName(ApiClient apiClient, JsonNode origin)
    {
      // TODO(b/413510963): Complete this converter, currently a placeholder.
      return origin;
    }

    internal static JsonNode TBatchJobSource(JsonNode origin)
    {
      // TODO(b/413510963): Complete this converter, currently a placeholder.
      return origin;
    }

    internal static JsonNode TBatchJobDestination(JsonNode origin)
    {
      // TODO(b/413510963): Complete this converter, currently a placeholder.
      return origin;
    }

    /// <summary>
    /// Transforms a SpeechConfig object for the live API, validating it.
    /// </summary>
    /// <param name="origin">The object to transform, can be a SpeechConfig or a JsonNode.</param>
    /// <returns>The transformed SpeechConfig.</returns>
    /// <exception cref="ArgumentException">If the object is not a supported type.</exception>
    /// <exception cref="NotSupportedException">If multiSpeakerVoiceConfig is present (as it's not supported in the live API).</exception>
    internal static SpeechConfig? TLiveSpeechConfig(object origin)
    {
      SpeechConfig? speechConfig;
      if (origin == null)
      {
        return null;
      }
      else if (origin is SpeechConfig config)
      {
        speechConfig = config;
      }
      else if (origin is JsonNode jsonNode)
      {
        speechConfig = JsonSerializer.Deserialize<SpeechConfig>(jsonNode.ToJsonString());
      }
      else
      {
        throw new ArgumentException($"Unsupported speechConfig type: {origin.GetType()}");
      }

      if (speechConfig?.MultiSpeakerVoiceConfig != null)
      {
        throw new NotSupportedException("multiSpeakerVoiceConfig parameter is not supported in the live API.");
      }

      return speechConfig;
    }
  }
}
