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

using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

using Google.Apis.Auth.OAuth2;

namespace Google.GenAI
{
  /// <summary>
  /// Represents a client error (4xx HTTP status codes) from the API.
  /// </summary>
  public class ClientError : HttpRequestException
  {
    public int StatusCode { get; }
    public string? Status { get; }

    public ClientError(string message) : base(message)
    {
    }

    public ClientError(string message, int statusCode, string? status = null) : base(message)
    {
      StatusCode = statusCode;
      Status = status;
    }

    public ClientError(string message, Exception innerException) : base(message, innerException)
    {
    }

    public ClientError(string message, int statusCode, string? status, Exception innerException) : base(message, innerException)
    {
      StatusCode = statusCode;
      Status = status;
    }
  }
  /// <summary>
  /// Represents a server error (5xx HTTP status codes) from the API.
  /// </summary>
  public class ServerError : HttpRequestException
  {
    public int StatusCode { get; }
    public string? Status { get; }

    public ServerError(string message) : base(message)
    {
    }

    public ServerError(string message, int statusCode, string? status = null) : base(message)
    {
      StatusCode = statusCode;
      Status = status;
    }

    public ServerError(string message, Exception innerException) : base(message, innerException)
    {
    }

    public ServerError(string message, int statusCode, string? status, Exception innerException) : base(message, innerException)
    {
      StatusCode = statusCode;
      Status = status;
    }
  }
  public class HttpApiClient : ApiClient
  {
    public HttpApiClient(
      string? apiKey,
      Types.HttpOptions? httpOptions
    ) : base(apiKey, httpOptions) { }
    public HttpApiClient(
        string? project,
        string? location,
        ICredential? credentials,
        Types.HttpOptions? httpOptions
    ) : base(project, location, credentials, httpOptions) { }

    public override async Task<ApiResponse> RequestAsync(
        HttpMethod httpMethod,
        string path,
        string requestJson,
        Types.HttpOptions? requestHttpOptions,
        CancellationToken cancellationToken = default)
    {
      HttpRequestMessage request = await CreateHttpRequestAsync(httpMethod, path, requestJson, requestHttpOptions);
      HttpResponseMessage response = await HttpClient.SendAsync(request, cancellationToken);
      if (!response.IsSuccessStatusCode)
      {
        try
        {
          await ThrowFromErrorResponse(response);
        }
        finally
        {
          response.Dispose();
        }
      }

      return new HttpApiResponse(response);
    }

    public override async IAsyncEnumerable<ApiResponse> RequestStreamAsync(
        HttpMethod httpMethod,
        string path,
        string requestJson,
        Types.HttpOptions? requestHttpOptions,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
      HttpRequestMessage request =
          await CreateHttpRequestAsync(httpMethod, path, requestJson, requestHttpOptions);

      HttpResponseMessage response = await ((HttpClient)HttpClient).SendAsync(
        request,
        // Use ResponseHeadersRead to avoid buffering the entire response
        HttpCompletionOption.ResponseHeadersRead,
        cancellationToken);
      if (!response.IsSuccessStatusCode)
      {
        try
        {
          await ThrowFromErrorResponse(response);
        }
        finally
        {
          response.Dispose();
        }
      }

      using (response)
      using (var stream = await response.Content.ReadAsStreamAsync(cancellationToken))
      {
        await foreach (string chunk in ProcessStreamResponse(stream, cancellationToken))
        {
          yield return new StreamingApiResponse(chunk, response);
        }
      }
    }

    private async Task<HttpRequestMessage> CreateHttpRequestAsync(HttpMethod httpMethod, string path,
        string requestJson, Types.HttpOptions? requestHttpOptions)
    {
        bool queryBaseModel = httpMethod.Equals("GET") && path.StartsWith("publishers/google/models");
        if (this.VertexAI && !path.StartsWith("projects/") && !queryBaseModel)
        {
            path = $"projects/{Project}/locations/{Location}/{path}";
        }

        Types.HttpOptions mergedHttpOptions = MergeHttpOptions(requestHttpOptions);
        string requestUrl;
        if (string.IsNullOrEmpty(mergedHttpOptions.ApiVersion))
        {
            requestUrl = $"{mergedHttpOptions.BaseUrl}/{path}";
        }
        else
        {
            requestUrl = $"{mergedHttpOptions.BaseUrl}/{mergedHttpOptions.ApiVersion}/{path}";
        }

        var request = new HttpRequestMessage(httpMethod, requestUrl);
        await SetHeadersAsync(request, mergedHttpOptions);

        if (httpMethod.Method.Equals("POST", StringComparison.OrdinalIgnoreCase) ||
            httpMethod.Method.Equals("PATCH", StringComparison.OrdinalIgnoreCase))
        {
            request.Content = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");
        }
        return request;
    }

    private static async Task ThrowFromErrorResponse(HttpResponseMessage response)
    {
      var statusCode = (int)response.StatusCode;
      var reasonPhrase = response.ReasonPhrase;
      string responseBody = await response.Content.ReadAsStringAsync();
      string message = responseBody;

      if (!string.IsNullOrWhiteSpace(responseBody))
      {
        try
        {
          var json = JsonNode.Parse(responseBody);
          if (json?["error"] is JsonObject errorJson)
          {
            if (errorJson["message"] is JsonValue messageValue && messageValue.TryGetValue<string>(out var errorMessage) && !string.IsNullOrWhiteSpace(errorMessage))
            {
              message = errorMessage;
            }
            if (errorJson["status"] is JsonValue statusValue && statusValue.TryGetValue<string>(out var errorStatus))
            {
              reasonPhrase = errorStatus;
            }

            // Append any 'details' content to the surfaced message so callers get the full backend debug info.
            var detailsText = GetErrorDetailsText(errorJson);
            if (!string.IsNullOrWhiteSpace(detailsText))
            {
              // keep original message but append details in full
              message = $"{message}\nDetails: {detailsText}";
            }
          }
        }
        catch (JsonException)
        {
          // Not a JSON error, the body is the message.
        }
      }

      if (string.IsNullOrWhiteSpace(message))
      {
        message = $"Request failed with status code {statusCode}: {reasonPhrase}";
      }

      if (statusCode >= 400 && statusCode < 500) throw new ClientError(message, statusCode, reasonPhrase);
      if (statusCode >= 500 && statusCode < 600) throw new ServerError(message, statusCode, reasonPhrase);

      response.EnsureSuccessStatusCode();
    }

    private static readonly Regex ResponseLineRegex = new Regex(@"^data: (.*?)(?:\r\n\r\n|\n\n|\r\r)", RegexOptions.Singleline | RegexOptions.Compiled);

    private async IAsyncEnumerable<string> ProcessStreamResponse(Stream stream,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
      var decoder = Encoding.UTF8.GetDecoder();
      var buffer = new StringBuilder();
      var readBuffer = new byte[8 * 1024];

      try
      {
        while (true)
        {
          int bytesRead = await stream.ReadAsync(readBuffer, 0, readBuffer.Length, cancellationToken);
          if (bytesRead == 0)
          {
            if (buffer.Length > 0 && buffer.ToString().Trim().Length > 0)
            {
              throw new InvalidOperationException("Incomplete JSON segment at the end");
            }
            break;
          }

          char[] charBuffer = new char[decoder.GetCharCount(readBuffer, 0, bytesRead)];
          int charCount = decoder.GetChars(readBuffer, 0, bytesRead, charBuffer, 0);
          string chunkString = new string(charBuffer, 0, charCount);

          CheckForStreamErrors(chunkString);

          buffer.Append(chunkString);

          var bufferString = buffer.ToString();
          Match match = ResponseLineRegex.Match(bufferString);
          while (match.Success)
          {
            string processedChunkString = match.Groups[1].Value;

            string? validatedChunk = ValidateChunk(processedChunkString);
            if (validatedChunk != null)
            {
              yield return validatedChunk;
            }

            buffer.Remove(0, match.Length);
            bufferString = buffer.ToString();
            match = ResponseLineRegex.Match(bufferString);
          }
        }
      }
      finally
      {
        decoder.Reset();
      }
    }
    private static string? ValidateChunk(string processedChunkString)
    {
      try
      {
        if (!string.IsNullOrWhiteSpace(processedChunkString))
        {
          if (processedChunkString.Trim().ToUpper() == "[DONE]" || processedChunkString.Trim().ToUpper() == "DONE")
          {
            return null;
          }

          if (processedChunkString.Trim() == "null" || processedChunkString.Trim() == "")
          {
            return null;
          }

          JsonNode.Parse(processedChunkString);
          return processedChunkString;
        }
        return null;
      }
      catch (JsonException ex)
      {
        throw new InvalidOperationException(
            $"Exception parsing stream chunk {processedChunkString}. {ex.Message}", ex);
      }
    }
    private void CheckForStreamErrors(string chunkString)
    {
      try
      {
        var chunkJson = JsonNode.Parse(chunkString);
        if (chunkJson?["error"] != null)
        {
          var errorJson = chunkJson["error"];
          var status = errorJson?["status"]?.GetValue<string>();
          var code = errorJson?["code"]?.GetValue<int>() ?? 0;

          var baseChunk = chunkJson.ToJsonString();
          var detailsText = (errorJson as JsonObject) != null ? GetErrorDetailsText((JsonObject)errorJson!) : null;
          var errorMessage = !string.IsNullOrEmpty(detailsText)
            ? $"got status: {status}. {baseChunk}\nDetails: {detailsText}"
            : $"got status: {status}. {baseChunk}";

          if (code >= 400 && code < 500)
          {
            throw new ClientError(errorMessage, code, status);
          }
          else if (code >= 500 && code < 600)
          {
            throw new ServerError(errorMessage, code, status);
          }
        }
      }
      catch (JsonException)
      {
        // Ignore JSON parsing errors during error checking
        // The chunk might be incomplete or not JSON
      }
      catch (HttpRequestException)
      {
        throw;
      }
    }

    private async Task SetHeadersAsync(HttpRequestMessage request, Types.HttpOptions mergedHttpOptions)
    {
      if (mergedHttpOptions.Headers != null)
      {
        foreach (var header in mergedHttpOptions.Headers)
        {
          request.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }
      }

      if (!string.IsNullOrEmpty(ApiKey))
      {
        request.Headers.TryAddWithoutValidation("x-goog-api-key", ApiKey);
      }
      else
      {
        if (Credentials == null)
        {
          throw new InvalidOperationException("Credentials are required when API key is not provided.");
        }
        string accessToken = await Credentials.GetAccessTokenForRequestAsync();
        if (string.IsNullOrEmpty(accessToken))
        {
          throw new InvalidOperationException("Failed to obtain access token from credentials.");
        }
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
      }
    }

    /// <summary>
    /// Extracts and formats 'details' entries from an error JsonObject. Returns null if none found.
    /// This tries to surface the debug content (e.g. DebugInfo.detail) as a single string.
    /// </summary>
    private static string? GetErrorDetailsText(JsonObject errorJson)
    {
      try
      {
        if (errorJson == null) return null;
        if (errorJson["details"] is JsonArray detailsArray && detailsArray.Count > 0)
        {
          var sb = new StringBuilder();
          foreach (var item in detailsArray)
          {
            if (item == null) continue;
            if (item is JsonObject obj && obj["detail"] != null)
            {
              sb.AppendLine(obj["detail"]!.ToString());
            }
            else
            {
              sb.AppendLine(item.ToJsonString());
            }
          }
          return sb.ToString().Trim();
        }
      }
      catch
      {
        // Swallow any unexpected parsing errors here; we don't want to mask the original error handling.
      }
      return null;
    }
  }
}
