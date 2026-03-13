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

using System.IO;
using System.Collections.Generic;
using Google.Apis.Auth.OAuth2;

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

    internal JsonNode InternalRegisterFilesParametersToMldev(JsonNode fromObject,
                                                             JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "uris" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "uris" },
                              Common.GetValueByPath(fromObject, new string[] { "uris" }));
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

    internal JsonNode RegisterFilesResponseFromMldev(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
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

    private async Task<ListFilesResponse> PrivateListAsync(
        ListFilesConfig? config, CancellationToken cancellationToken = default) {
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

    private async Task<CreateFileResponse> PrivateCreateAsync(
        Google.GenAI.Types.File file, CreateFileConfig? config,
        CancellationToken cancellationToken = default) {
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

      ApiResponse response =
          await this._apiClient.RequestAsync(HttpMethod.Post, path, JsonSerializer.Serialize(body),
                                             requestHttpOptions, cancellationToken);
      HttpContent httpContent = response.GetEntity();
#if NETSTANDARD2_0
      string contentString = await httpContent.ReadAsStringAsync();
#else
      string contentString = await httpContent.ReadAsStringAsync(cancellationToken);
#endif

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

    public async Task<Google.GenAI.Types.File> GetAsync(
        string name, GetFileConfig? config = null, CancellationToken cancellationToken = default) {
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

    public async Task<DeleteFileResponse> DeleteAsync(
        string name, DeleteFileConfig? config = null,
        CancellationToken cancellationToken = default) {
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
          HttpMethod.Delete, path, JsonSerializer.Serialize(body), requestHttpOptions,
          cancellationToken);
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

    private async Task<RegisterFilesResponse> PrivateRegisterFilesAsync(
        List<string> uris, RegisterFilesConfig? config,
        CancellationToken cancellationToken = default) {
      InternalRegisterFilesParameters parameter = new InternalRegisterFilesParameters();

      if (!Common.IsZero(uris)) {
        parameter.Uris = uris;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException(
            "Failed to parse InternalRegisterFilesParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      } else {
        body = InternalRegisterFilesParametersToMldev(parameterNode, new JsonObject());
        path = Common.FormatMap("files:register", body["_url"]);
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

      if (config?.ShouldReturnHttpResponse == true) {
        var httpHeaders = response.GetHeaders();
        Dictionary<string, string>? headers = null;

        if (httpHeaders != null) {
          headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
          foreach (var header in httpHeaders) {
            headers[header.Key] = string.Join(", ", header.Value);
          }
        }

        return new RegisterFilesResponse {
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

      return JsonSerializer.Deserialize<RegisterFilesResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException(
                 "Failed to deserialize Task<RegisterFilesResponse>.");
    }

    public async Task<Pager<Google.GenAI.Types.File, ListFilesConfig, ListFilesResponse>> ListAsync(
        ListFilesConfig? config = null, CancellationToken cancellationToken = default) {
      config ??= new ListFilesConfig();
      var initialResponse = await PrivateListAsync(config, cancellationToken);

      return new Pager<Google.GenAI.Types.File, ListFilesConfig, ListFilesResponse>(
          requestFunc: async cfg => await PrivateListAsync(cfg, cancellationToken),
          extractItems: response => response.Files,
          extractNextPageToken: response => response.NextPageToken,
          extractHttpResponse: response => response.SdkHttpResponse,
          updateConfigPageToken: (cfg, token) => {
            cfg.PageToken = token;
            return cfg;
          }, initialConfig: config, initialResponse: initialResponse, requestedPageSize: config.PageSize ?? 0);
    }

    /// <summary>
    /// Registers Google Cloud Storage files for use with the API.
    /// </summary>
    /// <param name="uris">The list of GCS URIs to register.</param>
    /// <param name="credential">The <see cref="GoogleCredential"/> to use for
    /// authorization.</param> <param name="config">A <see cref="RegisterFilesConfig"/> instance
    /// that specifies the optional configurations.</param> <param name="cancellationToken">A <see
    /// cref="CancellationToken"/> to cancel the operation.</param> <returns>A <see
    /// cref="Task{RegisterFilesResponse}"/> that represents the asynchronous operation. The task
    /// result contains the <see cref="RegisterFilesResponse"/>.</returns>
    public async Task<RegisterFilesResponse> RegisterFilesAsync(
        IEnumerable<string> uris, GoogleCredential credential, RegisterFilesConfig? config = null,
        CancellationToken cancellationToken = default) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      if (uris == null)
        throw new ArgumentNullException(nameof(uris));
      if (credential == null)
        throw new ArgumentNullException(nameof(credential));

      ICredential cred = (ICredential)credential;
      string accessToken =
          await cred.GetAccessTokenForRequestAsync(cancellationToken: cancellationToken);
      if (string.IsNullOrEmpty(accessToken)) {
        throw new InvalidOperationException("Failed to obtain access token from credentials.");
      }

      var localConfig = config ?? new RegisterFilesConfig();
      var httpOptions = localConfig.HttpOptions ?? new HttpOptions();
      var headers = httpOptions.Headers != null
                        ? new Dictionary<string, string>(httpOptions.Headers,
                                                         StringComparer.OrdinalIgnoreCase)
                        : new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

      headers["Authorization"] = $"Bearer {accessToken}";
      if (!string.IsNullOrEmpty(credential.QuotaProject)) {
        headers["x-goog-user-project"] = credential.QuotaProject;
      }

      // Create an effective configuration with updated headers without mutating the input object.
      var effectiveConfig =
          localConfig with { HttpOptions = httpOptions with { Headers = headers } };

      return await PrivateRegisterFilesAsync(uris.ToList(), effectiveConfig, cancellationToken);
    }

    /// <summary>
    /// Uploads a file from a file path.
    /// </summary>
    /// <param name="filePath">The path to the file to upload.</param>
    /// <param name="config">A <see cref="UploadFileConfig"/> instance that specifies the optional
    /// configurations.</param> <param name="cancellationToken">A <see cref="CancellationToken"/> to
    /// cancel the operation.</param> <returns>A <see cref="Task{File}"/> that represents the
    /// asynchronous operation. The task result contains the uploaded <see cref="File"/>
    /// metadata.</returns>
    public async Task<Google.GenAI.Types.File> UploadAsync(
        string filePath, UploadFileConfig? config = null,
        CancellationToken cancellationToken = default) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      var fileInfo = new FileInfo(filePath);
      using var stream = fileInfo.OpenRead();
      string mimeType = MimeTypes.GetMimeType(Path.GetExtension(filePath));

      return await UploadAsync(stream, fileInfo.Length, fileInfo.Name, mimeType, config,
                               cancellationToken);
    }

    /// <summary>
    /// Uploads a file from a byte array.
    /// </summary>
    /// <param name="bytes">The file content as a byte array.</param>
    /// <param name="fileName">Optional file name to use.</param>
    /// <param name="config">A <see cref="UploadFileConfig"/> instance that specifies the optional
    /// configurations.</param> <param name="cancellationToken">A <see cref="CancellationToken"/> to
    /// cancel the operation.</param> <returns>A <see cref="Task{File}"/> that represents the
    /// asynchronous operation. The task result contains the uploaded <see cref="File"/>
    /// metadata.</returns>
    public async Task<Google.GenAI.Types.File> UploadAsync(
        byte[] bytes, string? fileName = null, UploadFileConfig? config = null,
        CancellationToken cancellationToken = default) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      using var stream = new MemoryStream(bytes);
      return await UploadAsync(stream, bytes.Length, fileName, null, config, cancellationToken);
    }

    /// <summary>
    /// Uploads a file from a stream.
    /// </summary>
    /// <param name="stream">The stream containing the file data.</param>
    /// <param name="size">The size of the file in bytes.</param>
    /// <param name="fileName">Optional file name to use.</param>
    /// <param name="mimeType">Optional MIME type. If not provided, defaults to
    /// application/octet-stream.</param> <param name="config">A <see cref="UploadFileConfig"/>
    /// instance that specifies the optional configurations.</param> <param
    /// name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>
    /// <returns>A <see cref="Task{File}"/> that represents the asynchronous operation. The task
    /// result contains the uploaded <see cref="File"/> metadata.</returns>
    public async Task<Google.GenAI.Types.File> UploadAsync(
        Stream stream, long size, string? fileName = null, string? mimeType = null,
        UploadFileConfig? config = null, CancellationToken cancellationToken = default) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      string uploadUrl =
          await CreateFileInApiAsync(config, mimeType, fileName, size, cancellationToken);
      HttpContent responseContent = await _uploadClient.UploadAsync(
          uploadUrl, stream, size, config?.HttpOptions, cancellationToken);
      return await FileFromUploadResponseBodyAsync(responseContent);
    }

    /// <summary>
    /// Downloads a file and returns it as a <see cref="Stream"/>. Caller is responsible for
    /// disposing the returned stream.
    /// </summary>
    /// <param name="fileName">The name of the file to download (e.g., "files/abc123" or
    /// "abc123").</param> <param name="config">A <see cref="DownloadFileConfig"/> instance that
    /// specifies the optional configurations.</param> <param name="cancellationToken">A <see
    /// cref="CancellationToken"/> to cancel the operation.</param> <returns>A <see
    /// cref="Task{Stream}"/> that represents the asynchronous operation. The task result contains a
    /// <see cref="Stream"/> with the file data.</returns>
    public async Task<Stream> DownloadAsync(string fileName, DownloadFileConfig? config = null,
                                            CancellationToken cancellationToken = default) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      string extractedFileName = Transformers.TFileName(fileName);
      return await DownloadStreamAsync(extractedFileName, config, cancellationToken);
    }

    /// <summary>
    /// Downloads a <see cref="File"/> object and returns it as a <see cref="Stream"/>. Caller is
    /// responsible for disposing the returned stream.
    /// </summary>
    /// <param name="file">The <see cref="File"/> object to download.</param>
    /// <param name="config">A <see cref="DownloadFileConfig"/> instance that specifies the optional
    /// configurations.</param> <param name="cancellationToken">A <see cref="CancellationToken"/> to
    /// cancel the operation.</param> <returns>A <see cref="Task{Stream}"/> that represents the
    /// asynchronous operation. The task result contains a <see cref="Stream"/> with the file
    /// data.</returns>
    public async Task<Stream> DownloadAsync(Google.GenAI.Types.File file,
                                            DownloadFileConfig? config = null,
                                            CancellationToken cancellationToken = default) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      if (string.IsNullOrEmpty(file.Name))
        throw new ArgumentException("File.Name is required", nameof(file));

      return await DownloadAsync(file.Name, config, cancellationToken);
    }

    /// <summary>
    /// Downloads a <see cref="Video"/> object and returns it as a <see cref="Stream"/>. Caller is
    /// responsible for disposing the returned stream.
    /// </summary>
    /// <param name="video">The <see cref="Video"/> object to download.</param>
    /// <param name="config">A <see cref="DownloadFileConfig"/> instance that specifies the optional
    /// configurations.</param> <param name="cancellationToken">A <see cref="CancellationToken"/> to
    /// cancel the operation.</param> <returns>A <see cref="Task{Stream}"/> that represents the
    /// asynchronous operation. The task result contains a <see cref="Stream"/> with the file
    /// data.</returns>
    public async Task<Stream> DownloadAsync(Video video, DownloadFileConfig? config = null,
                                            CancellationToken cancellationToken = default) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      if (string.IsNullOrEmpty(video.Uri))
        throw new ArgumentException("Video.Uri is required", nameof(video));

      return await DownloadAsync(video.Uri, config, cancellationToken);
    }

    /// <summary>
    /// Downloads a <see cref="GeneratedVideo"/> object and returns it as a <see cref="Stream"/>.
    /// Caller is responsible for disposing the returned stream.
    /// </summary>
    /// <param name="generatedVideo">The <see cref="GeneratedVideo"/> object to download.</param>
    /// <param name="config">A <see cref="DownloadFileConfig"/> instance that specifies the optional
    /// configurations.</param> <param name="cancellationToken">A <see cref="CancellationToken"/> to
    /// cancel the operation.</param> <returns>A <see cref="Task{Stream}"/> that represents the
    /// asynchronous operation. The task result contains a <see cref="Stream"/> with the file
    /// data.</returns>
    public async Task<Stream> DownloadAsync(GeneratedVideo generatedVideo,
                                            DownloadFileConfig? config = null,
                                            CancellationToken cancellationToken = default) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      if (generatedVideo.Video == null)
        throw new ArgumentException("Video is empty", nameof(generatedVideo));

      return await DownloadAsync(generatedVideo.Video, config, cancellationToken);
    }

    /// <summary>
    /// Downloads a file directly to a file path.
    /// </summary>
    /// <param name="fileName">The name of the file to download (e.g., "files/abc123" or
    /// "abc123").</param> <param name="outputPath">The path where the file should be saved.</param>
    /// <param name="config">A <see cref="DownloadFileConfig"/> instance that specifies the optional
    /// configurations.</param> <param name="cancellationToken">A <see cref="CancellationToken"/> to
    /// cancel the operation.</param> <returns>A <see cref="Task"/> that represents the asynchronous
    /// operation.</returns>
    public async Task DownloadToFileAsync(string fileName, string outputPath,
                                          DownloadFileConfig? config = null,
                                          CancellationToken cancellationToken = default) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      using var stream = await DownloadAsync(fileName, config, cancellationToken);
      using var fileStream =
          new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None,
                         bufferSize: UploadClient.DEFAULT_CHUNK_SIZE, useAsync: true);

#if NETSTANDARD2_0
      await stream.CopyToAsync(fileStream, bufferSize: 81920, cancellationToken);
#else
      await stream.CopyToAsync(fileStream, cancellationToken);
#endif
    }

    /// <summary>
    /// Downloads a <see cref="File"/> object directly to a file path.
    /// </summary>
    /// <param name="file">The <see cref="File"/> object to download.</param>
    /// <param name="outputPath">The path where the file should be saved.</param>
    /// <param name="config">A <see cref="DownloadFileConfig"/> instance that specifies the optional
    /// configurations.</param> <param name="cancellationToken">A <see cref="CancellationToken"/> to
    /// cancel the operation.</param> <returns>A <see cref="Task"/> that represents the asynchronous
    /// operation.</returns>
    public async Task DownloadToFileAsync(Google.GenAI.Types.File file, string outputPath,
                                          DownloadFileConfig? config = null,
                                          CancellationToken cancellationToken = default) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      if (string.IsNullOrEmpty(file.Name))
        throw new ArgumentException("Google.GenAI.Types.File.Name is required", nameof(file));

      await DownloadToFileAsync(file.Name, outputPath, config, cancellationToken);
    }

    /// <summary>
    /// Downloads a <see cref="GeneratedVideo"/> object directly to a file path.
    /// </summary>
    /// <param name="generatedVideo">The <see cref="GeneratedVideo"/> object to download.</param>
    /// <param name="outputPath">The path where the Video should be saved.</param>
    /// <param name="config">A <see cref="DownloadFileConfig"/> instance that specifies the optional
    /// configurations.</param> <param name="cancellationToken">A <see cref="CancellationToken"/> to
    /// cancel the operation.</param> <returns>A <see cref="Task"/> that represents the asynchronous
    /// operation.</returns>
    public async Task DownloadToFileAsync(GeneratedVideo generatedVideo, string outputPath,
                                          DownloadFileConfig? config = null,
                                          CancellationToken cancellationToken = default) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      if (generatedVideo.Video == null)
        throw new ArgumentException("Video is empty", nameof(generatedVideo));

      await DownloadToFileAsync(generatedVideo.Video, outputPath, config, cancellationToken);
    }

    /// <summary>
    /// Downloads a <see cref="Video"/> object directly to a file path.
    /// </summary>
    /// <param name="video">The <see cref="Video"/> object to download.</param>
    /// <param name="outputPath">The path where the Video should be saved.</param>
    /// <param name="config">A <see cref="DownloadFileConfig"/> instance that specifies the optional
    /// configurations.</param> <param name="cancellationToken">A <see cref="CancellationToken"/> to
    /// cancel the operation.</param> <returns>A <see cref="Task"/> that represents the asynchronous
    /// operation.</returns>
    public async Task DownloadToFileAsync(Video video, string outputPath,
                                          DownloadFileConfig? config = null,
                                          CancellationToken cancellationToken = default) {
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }
      if (string.IsNullOrEmpty(video.Uri))
        throw new ArgumentException("Video.Uri is required", nameof(video));

      await DownloadToFileAsync(video.Uri, outputPath, config, cancellationToken);
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
                                                    string? fileName, long size,
                                                    CancellationToken cancellationToken = default) {
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

      var createFileResponse =
          await PrivateCreateAsync(fileBuilder, createFileConfig, cancellationToken);

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

    private async Task<Stream> DownloadStreamAsync(string fileName, DownloadFileConfig? config,
                                                   CancellationToken cancellationToken = default) {
      string path = $"files/{fileName}:download?alt=media";
      var response = await _apiClient.RequestAsync(HttpMethod.Get, path, "", config?.HttpOptions,
                                                   cancellationToken);
#if NETSTANDARD2_0
      return await response.GetEntity().ReadAsStreamAsync();
#else
      return await response.GetEntity().ReadAsStreamAsync(cancellationToken);
#endif
    }
  }
}
