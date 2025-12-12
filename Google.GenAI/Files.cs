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

using System.IO;

namespace Google.GenAI {

  public sealed class Files {
    private readonly UploadClient _uploadClient;
    private readonly ApiClient _apiClient;

    internal JsonNode CreateFileParametersToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "file" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "file" },
                              Common.GetValueByPath(fromObject, new string[] { "file" }));
      }

      return toObject;
    }

    internal JsonNode CreateFileResponseFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      return toObject;
    }

    internal JsonNode DeleteFileParametersToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "file" },
            Transformers.TFileName(Common.GetValueByPath(fromObject, new string[] { "name" })));
      }

      return toObject;
    }

    internal JsonNode DeleteFileResponseFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      return toObject;
    }

    internal JsonNode GetFileParametersToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "_url", "file" },
            Transformers.TFileName(Common.GetValueByPath(fromObject, new string[] { "name" })));
      }

      return toObject;
    }

    internal JsonNode ListFilesConfigToMldev(JsonNode fromObject, JsonObject parentObject) {
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

    internal JsonNode ListFilesParametersToMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = ListFilesConfigToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                       fromObject, new string[] { "config" }))),
                                   toObject);
      }

      return toObject;
    }

    internal JsonNode ListFilesResponseFromMldev(JsonNode fromObject, JsonObject parentObject) {
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

      if (Common.GetValueByPath(fromObject, new string[] { "files" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "files" },
                              Common.GetValueByPath(fromObject, new string[] { "files" }));
      }

      return toObject;
    }

    public Files(ApiClient apiClient) {
      {
        _apiClient = apiClient;
        _uploadClient = new UploadClient(_apiClient);
      }
    }

    private async Task<ListFilesResponse> PrivateListAsync(ListFilesConfig? config) {
      ListFilesParameters parameter = new ListFilesParameters();

      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse ListFilesParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      } else {
        body = ListFilesParametersToMldev(parameterNode, new JsonObject());
        path = Common.FormatMap("files", body["_url"]);
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
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }

      if (!this._apiClient.VertexAI) {
        responseNode = httpContentNode;
      }

      return JsonSerializer.Deserialize<ListFilesResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException("Failed to deserialize Task<ListFilesResponse>.");
    }

    private async Task<CreateFileResponse> PrivateCreateAsync(Google.GenAI.Types.File file,
                                                              CreateFileConfig? config) {
      CreateFileParameters parameter = new CreateFileParameters();

      if (!Common.IsZero(file)) {
        parameter.File = file;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse CreateFileParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      } else {
        body = CreateFileParametersToMldev(parameterNode, new JsonObject());
        path = Common.FormatMap("upload/v1beta/files", body["_url"]);
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

      if (config?.ShouldReturnHttpResponse == true) {
        var httpHeaders = response.GetHeaders();
        Dictionary<string, string>? headers = null;

        if (httpHeaders != null) {
          headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
          foreach (var header in httpHeaders) {
            headers[header.Key] = string.Join(", ", header.Value);
          }
        }

        return new CreateFileResponse {
          SdkHttpResponse = new HttpResponse { Headers = headers, Body = contentString }
        };
      }

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
        responseNode = httpContentNode;
      }

      return JsonSerializer.Deserialize<CreateFileResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException("Failed to deserialize Task<CreateFileResponse>.");
    }

    public async Task<Google.GenAI.Types.File> GetAsync(string name, GetFileConfig? config = null) {
      GetFileParameters parameter = new GetFileParameters();

      if (!Common.IsZero(name)) {
        parameter.Name = name;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse GetFileParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      } else {
        body = GetFileParametersToMldev(parameterNode, new JsonObject());
        path = Common.FormatMap("files/{file}", body["_url"]);
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
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }

      if (!this._apiClient.VertexAI) {
        responseNode = httpContentNode;
      }

      return JsonSerializer.Deserialize<Google.GenAI.Types.File>(responseNode.ToString()) ??
             throw new InvalidOperationException(
                 "Failed to deserialize Task<Google.GenAI.Types.File>.");
    }

    public async Task<DeleteFileResponse> DeleteAsync(string name,
                                                      DeleteFileConfig? config = null) {
      DeleteFileParameters parameter = new DeleteFileParameters();

      if (!Common.IsZero(name)) {
        parameter.Name = name;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse DeleteFileParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      } else {
        body = DeleteFileParametersToMldev(parameterNode, new JsonObject());
        path = Common.FormatMap("files/{file}", body["_url"]);
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
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }

      if (!this._apiClient.VertexAI) {
        responseNode = httpContentNode;
      }

      return JsonSerializer.Deserialize<DeleteFileResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException("Failed to deserialize Task<DeleteFileResponse>.");
    }

    public async Task<Pager<Google.GenAI.Types.File, ListFilesConfig, ListFilesResponse>> ListAsync(
        ListFilesConfig? config = null) {
      config ??= new ListFilesConfig();
      var initialResponse = await PrivateListAsync(config);

      return new Pager<Google.GenAI.Types.File, ListFilesConfig, ListFilesResponse>(
          requestFunc: async cfg => await PrivateListAsync(cfg),
          extractItems: response => response.Files,
          extractNextPageToken: response => response.NextPageToken,
          extractHttpResponse: response => response.SdkHttpResponse,
          updateConfigPageToken: (cfg, token) => {
            cfg.PageToken = token;
            return cfg;
          }, initialConfig: config, initialResponse: initialResponse, requestedPageSize: config.PageSize ?? 0);
    }

    /// <summary>
    /// Uploads a file from a file path.
    /// </summary>
    /// <param name="filePath">The path to the file to upload.</param>
    /// <param name="config">A <see cref="UploadFileConfig"/> instance that specifies the optional
    /// configurations.</param> <returns>A <see cref="Task{Google.GenAI.Types.File}"/> that
    /// represents the asynchronous operation. The task result contains the uploaded <see
    /// cref="Google.GenAI.Types.File"/> metadata.</returns>
    public async Task<Google.GenAI.Types.File> UploadAsync(string filePath,
                                                           UploadFileConfig? config = null) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      var fileInfo = new FileInfo(filePath);
      using var stream = fileInfo.OpenRead();
      string mimeType = MimeTypes.GetMimeType(Path.GetExtension(filePath));

      return await UploadAsync(stream, fileInfo.Length, fileInfo.Name, mimeType, config);
    }

    /// <summary>
    /// Uploads a file from a byte array.
    /// </summary>
    /// <param name="bytes">The file content as a byte array.</param>
    /// <param name="fileName">Optional file name to use.</param>
    /// <param name="config">A <see cref="UploadFileConfig"/> instance that specifies the optional
    /// configurations.</param> <returns>A <see cref="Task{Google.GenAI.Types.File}"/> that
    /// represents the asynchronous operation. The task result contains the uploaded <see
    /// cref="Google.GenAI.Types.File"/> metadata.</returns>
    public async Task<Google.GenAI.Types.File> UploadAsync(byte[] bytes, string? fileName = null,
                                                           UploadFileConfig? config = null) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      using var stream = new MemoryStream(bytes);
      return await UploadAsync(stream, bytes.Length, fileName, null, config);
    }

    /// <summary>
    /// Uploads a file from a stream.
    /// </summary>
    /// <param name="stream">The stream containing the file data.</param>
    /// <param name="size">The size of the file in bytes.</param>
    /// <param name="fileName">Optional file name to use.</param>
    /// <param name="mimeType">Optional MIME type. If not provided, defaults to
    /// application/octet-stream.</param> <param name="config">A <see cref="UploadFileConfig"/>
    /// instance that specifies the optional configurations.</param> <returns>A <see
    /// cref="Task{Google.GenAI.Types.File}"/> that represents the asynchronous operation. The task
    /// result contains the uploaded <see cref="Google.GenAI.Types.File"/> metadata.</returns>
    public async Task<Google.GenAI.Types.File> UploadAsync(Stream stream, long size,
                                                           string? fileName = null,
                                                           string? mimeType = null,
                                                           UploadFileConfig? config = null) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      string uploadUrl = await CreateFileInApiAsync(config, mimeType, fileName, size);
      HttpContent responseContent = await _uploadClient.UploadAsync(uploadUrl, stream, size);
      return await FileFromUploadResponseBodyAsync(responseContent);
    }

    /// <summary>
    /// Downloads a file and returns it as a <see cref="Stream"/>. Caller is responsible for
    /// disposing the returned stream.
    /// </summary>
    /// <param name="fileName">The name of the file to download (e.g., "files/abc123" or
    /// "abc123").</param> <param name="config">A <see cref="DownloadFileConfig"/> instance that
    /// specifies the optional configurations.</param> <returns>A <see cref="Task{Stream}"/> that
    /// represents the asynchronous operation. The task result contains a <see cref="Stream"/> with
    /// the file data.</returns>
    public async Task<Stream> DownloadAsync(string fileName, DownloadFileConfig? config = null) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      string extractedFileName = Transformers.TFileName(fileName);
      return await DownloadStreamAsync(extractedFileName, config);
    }

    /// <summary>
    /// Downloads a <see cref="Google.GenAI.Types.File"/> object and returns it as a <see
    /// cref="Stream"/>. Caller is responsible for disposing the returned stream.
    /// </summary>
    /// <param name="file">The <see cref="Google.GenAI.Types.File"/> object to download.</param>
    /// <param name="config">A <see cref="DownloadFileConfig"/> instance that specifies the optional
    /// configurations.</param> <returns>A <see cref="Task{Stream}"/> that represents the
    /// asynchronous operation. The task result contains a <see cref="Stream"/> with the file
    /// data.</returns>
    public async Task<Stream> DownloadAsync(Google.GenAI.Types.File file,
                                            DownloadFileConfig? config = null) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      if (string.IsNullOrEmpty(file.Name))
        throw new ArgumentException("Google.GenAI.Types.File.Name is required", nameof(file));

      return await DownloadAsync(file.Name, config);
    }

    /// <summary>
    /// Downloads a <see cref="Google.GenAI.Types.Video"/> object and returns it as a <see
    /// cref="Stream"/>. Caller is responsible for disposing the returned stream.
    /// </summary>
    /// <param name="file">The <see cref="Google.GenAI.Types.Video"/> object to download.</param>
    /// <param name="config">A <see cref="DownloadFileConfig"/> instance that specifies the optional
    /// configurations.</param> <returns>A <see cref="Task{Stream}"/> that represents the
    /// asynchronous operation. The task result contains a <see cref="Stream"/> with the file
    /// data.</returns>
    public async Task<Stream> DownloadAsync(Google.GenAI.Types.Video video,
                                            DownloadFileConfig? config = null) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      if (string.IsNullOrEmpty(video.Uri))
        throw new ArgumentException("Google.GenAI.Types.Video.Uri is required", nameof(video));

      return await DownloadAsync(video.Uri, config);
    }

    /// <summary>
    /// Downloads a <see cref="Google.GenAI.Types.GeneratedVideo"/> object and returns it as a <see
    /// cref="Stream"/>. Caller is responsible for disposing the returned stream.
    /// </summary>
    /// <param name="file">The <see cref="Google.GenAI.Types.GeneratedVideo"/> object to
    /// download.</param> <param name="config">A <see cref="DownloadFileConfig"/> instance that
    /// specifies the optional configurations.</param> <returns>A <see cref="Task{Stream}"/> that
    /// represents the asynchronous operation. The task result contains a <see cref="Stream"/> with
    /// the file data.</returns>
    public async Task<Stream> DownloadAsync(Google.GenAI.Types.GeneratedVideo generatedVideo,
                                            DownloadFileConfig? config = null) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      if (generatedVideo.Video == null)
        throw new ArgumentException("Google.GenAI.Types.Video is empty", nameof(generatedVideo));

      return await DownloadAsync(generatedVideo.Video, config);
    }

    /// <summary>
    /// Downloads a file directly to a file path.
    /// </summary>
    /// <param name="fileName">The name of the file to download (e.g., "files/abc123" or
    /// "abc123").</param> <param name="outputPath">The path where the file should be saved.</param>
    /// <param name="config">A <see cref="DownloadFileConfig"/> instance that specifies the optional
    /// configurations.</param> <returns>A <see cref="Task"/> that represents the asynchronous
    /// operation.</returns>
    public async Task DownloadToFileAsync(string fileName, string outputPath,
                                          DownloadFileConfig? config = null) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      using var stream = await DownloadAsync(fileName, config);
      using var fileStream =
          new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None,
                         bufferSize: UploadClient.DEFAULT_CHUNK_SIZE, useAsync: true);

      await stream.CopyToAsync(fileStream);
    }

    /// <summary>
    /// Downloads a <see cref="Google.GenAI.Types.File"/> object directly to a file path.
    /// </summary>
    /// <param name="file">The <see cref="File"/> object to download.</param>
    /// <param name="outputPath">The path where the file should be saved.</param>
    /// <param name="config">A <see cref="DownloadFileConfig"/> instance that specifies the optional
    /// configurations.</param> <returns>A <see cref="Task"/> that represents the asynchronous
    /// operation.</returns>
    public async Task DownloadToFileAsync(Google.GenAI.Types.File file, string outputPath,
                                          DownloadFileConfig? config = null) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      if (string.IsNullOrEmpty(file.Name))
        throw new ArgumentException("Google.GenAI.Types.File.Name is required", nameof(file));

      await DownloadToFileAsync(file.Name, outputPath, config);
    }

    /// <summary>
    /// Downloads a <see cref="Google.GenAI.Types.GeneratedVideo"/> object directly to a file path.
    /// </summary>
    /// <param name="file">The <see cref="GeneratedVideo"/> object to download.</param>
    /// <param name="outputPath">The path where the Video should be saved.</param>
    /// <param name="config">A <see cref="DownloadFileConfig"/> instance that specifies the optional
    /// configurations.</param> <returns>A <see cref="Task"/> that represents the asynchronous
    /// operation.</returns>
    public async Task DownloadToFileAsync(Google.GenAI.Types.GeneratedVideo generatedVideo,
                                          string outputPath, DownloadFileConfig? config = null) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      if (generatedVideo.Video == null)
        throw new ArgumentException("Google.GenAI.Types.Video is empty", nameof(generatedVideo));

      await DownloadToFileAsync(generatedVideo.Video, outputPath, config);
    }

    /// <summary>
    /// Downloads a <see cref="Google.GenAI.Types.Video"/> object directly to a file path.
    /// </summary>
    /// <param name="file">The <see cref="Video"/> object to download.</param>
    /// <param name="outputPath">The path where the Video should be saved.</param>
    /// <param name="config">A <see cref="DownloadFileConfig"/> instance that specifies the optional
    /// configurations.</param> <returns>A <see cref="Task"/> that represents the asynchronous
    /// operation.</returns>
    public async Task DownloadToFileAsync(Google.GenAI.Types.Video video, string outputPath,
                                          DownloadFileConfig? config = null) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      if (string.IsNullOrEmpty(video.Uri))
        throw new ArgumentException("Google.GenAI.Types.Video.Uri is required", nameof(video));

      await DownloadToFileAsync(video.Uri, outputPath, config);
    }

    private async Task<Google.GenAI.Types.File> FileFromUploadResponseBodyAsync(
        HttpContent responseContent) {
      string responseString = await responseContent.ReadAsStringAsync();
      JsonNode? responseNode = JsonNode.Parse(responseString);

      if (responseNode?["file"] is not JsonNode fileNode) {
        throw new InvalidOperationException("Upload response does not contain file object");
      }

      return JsonSerializer.Deserialize<Google.GenAI.Types.File>(fileNode.ToString()) ??
             throw new InvalidOperationException("Failed to deserialize File");
    }

    private async Task<string> CreateFileInApiAsync(UploadFileConfig? config, string? mimeType,
                                                    string? fileName, long size) {
      var fileBuilder = new Google.GenAI.Types.File();

      if (config != null) {
        if (!string.IsNullOrEmpty(config.Name)) {
          fileBuilder.Name =
              config.Name.StartsWith("files/") ? config.Name : $"files/{config.Name}";
        }

        mimeType = config.MimeType ?? mimeType;

        if (!string.IsNullOrEmpty(config.DisplayName)) {
          fileBuilder.DisplayName = config.DisplayName;
        }
      }

      var createFileHttpOptions = UploadClient.BuildResumableUploadHttpOptions(
          config?.HttpOptions, mimeType, fileName, size);

      var createFileConfig = new CreateFileConfig { HttpOptions = createFileHttpOptions,
                                                    ShouldReturnHttpResponse = true };

      var createFileResponse = await PrivateCreateAsync(fileBuilder, createFileConfig);

      string errorMessage = "Upload URL not found in create file response";
      if (createFileResponse.SdkHttpResponse?.Headers == null) {
        throw new InvalidOperationException(errorMessage);
      }
      var headers = new Dictionary<string, string>(createFileResponse.SdkHttpResponse.Headers,
                                                   StringComparer.OrdinalIgnoreCase);
    if (!headers.TryGetValue("x-goog-upload-url", out string? uploadUrl)) {
      throw new InvalidOperationException(errorMessage);
    }
    return uploadUrl;
    }

    private async Task<Stream> DownloadStreamAsync(string fileName, DownloadFileConfig? config) {
      string path = $"files/{fileName}:download?alt=media";
      var response = await _apiClient.RequestAsync(HttpMethod.Get, path, "", config?.HttpOptions);
      return await response.GetEntity().ReadAsStreamAsync();
    }
  }
}
