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
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Google.GenAI.Types;

namespace Google.GenAI
{
  /// <summary>
  /// Internal client for handling file uploads with chunked/resumable protocol.
  /// </summary>
  internal sealed class UploadClient
  {
    private readonly ApiClient _apiClient;
    private readonly int _chunkSize;

    public const int DEFAULT_CHUNK_SIZE = 8 * 1024 * 1024; // 8MB
    public const int MAX_RETRY_COUNT = 3;
    public const int INITIAL_RETRY_DELAY_MS = 1000;
    public const int DELAY_MULTIPLIER = 2;

    public UploadClient(ApiClient apiClient, int chunkSize = DEFAULT_CHUNK_SIZE)
    {
      _apiClient = apiClient;
      _chunkSize = chunkSize;
    }

    /// <summary>
    /// Builds HTTP options for resumable upload initialization.
    /// </summary>
    public static HttpOptions BuildResumableUploadHttpOptions(
        HttpOptions? userOptions,
        string? mimeType,
        string? fileName,
        long size)
    {
      if (string.IsNullOrEmpty(mimeType))
      {
        mimeType = "application/octet-stream";
      }

      var headers = new Dictionary<string, string>
      {
        ["Content-Type"] = "application/json",
        ["X-Goog-Upload-Protocol"] = "resumable",
        ["X-Goog-Upload-Command"] = "start",
        ["X-Goog-Upload-Header-Content-Length"] = size.ToString(),
        ["X-Goog-Upload-Header-Content-Type"] = mimeType
      };

      if (!string.IsNullOrEmpty(fileName))
      {
        headers["X-Goog-Upload-File-Name"] = fileName;
      }

      // Merge with user options if provided
      var mergedHeaders = userOptions?.Headers != null
          ? new Dictionary<string, string>(userOptions.Headers)
          : new Dictionary<string, string>();

      foreach (var header in headers)
      {
        mergedHeaders[header.Key] = header.Value;
      }

      return new HttpOptions
      {
        ApiVersion = "",
        Headers = mergedHeaders,
        BaseUrl = userOptions?.BaseUrl,
        Timeout = userOptions?.Timeout,
        HttpClientFactory = userOptions?.HttpClientFactory
      };
    }

    /// <summary>
    /// Uploads data from a byte array.
    /// </summary>
    public async Task<HttpContent> UploadAsync(
        string uploadUrl, byte[] bytes, CancellationToken cancellationToken = default)
    {
      using var stream = new MemoryStream(bytes);
      return await UploadAsync(uploadUrl, stream, bytes.Length, cancellationToken);
    }

    /// <summary>
    /// Uploads data from a stream using chunked resumable protocol.
    /// </summary>
    public async Task<HttpContent> UploadAsync(
        string uploadUrl, Stream inputStream, long size, CancellationToken cancellationToken = default)
    {
      string uploadCommand = "upload";
      byte[] buffer = new byte[_chunkSize];
      int bytesRead;
      long offset = 0;

      // Upload chunks
      while ((bytesRead = await inputStream.ReadAsync(buffer, 0, _chunkSize, cancellationToken)) == _chunkSize)
      {
        var uploadResponse = await UploadChunkAsync(uploadUrl, buffer, offset, uploadCommand, cancellationToken);

        if (uploadResponse.UploadStatus != "active")
        {
          throw new InvalidOperationException(
              $"Unexpected upload status: {uploadResponse.UploadStatus}. Expected 'active'.");
        }

        offset += bytesRead;
      }

      // Upload final chunk
      byte[] finalBuffer = new byte[bytesRead];
      Array.Copy(buffer, finalBuffer, bytesRead);
      uploadCommand = "upload, finalize";

      var finalResponse = await UploadChunkAsync(uploadUrl, finalBuffer, offset, uploadCommand, cancellationToken);

      if (finalResponse.UploadStatus != "final")
      {
        throw new InvalidOperationException(
            $"Unexpected final upload status: {finalResponse.UploadStatus}. Expected 'final'.");
      }

      return finalResponse.Entity;
    }

    private async Task<UploadChunkResponse> UploadChunkAsync(
        string uploadUrl,
        byte[] chunk,
        long offset,
        string uploadCommand,
        CancellationToken cancellationToken)
    {
      var headers = new Dictionary<string, string>
      {
        ["X-Goog-Upload-Command"] = uploadCommand,
        ["X-Goog-Upload-Offset"] = offset.ToString()
      };

      var httpOptions = new HttpOptions { Headers = headers };

      for (int retryCount = 0; retryCount < MAX_RETRY_COUNT; retryCount++)
      {
        var response = await _apiClient.RequestAsync(
            HttpMethod.Post,
            uploadUrl,
            chunk,
            httpOptions,
            cancellationToken);

        if (response.GetHeaders().TryGetValues("X-Goog-Upload-Status", out var values))
        {
          var uploadStatus = values.FirstOrDefault();
          if (!string.IsNullOrEmpty(uploadStatus))
          {
            return new UploadChunkResponse(uploadStatus, response.GetEntity());
          }
        }

        int delayMs = INITIAL_RETRY_DELAY_MS * (int)Math.Pow(DELAY_MULTIPLIER, retryCount);
        await Task.Delay(delayMs, cancellationToken);
      }

      throw new InvalidOperationException(
          $"Upload failed after {MAX_RETRY_COUNT} retries. No upload status header received.");
    }

    private sealed class UploadChunkResponse
    {
      public string UploadStatus { get; }
      public HttpContent Entity { get; }

      public UploadChunkResponse(string uploadStatus, HttpContent entity)
      {
        UploadStatus = uploadStatus;
        Entity = entity;
      }
    }
  }
}
