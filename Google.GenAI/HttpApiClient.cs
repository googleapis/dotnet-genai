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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

using Google.Apis.Auth.OAuth2;

namespace Google.GenAI
{
  /// <summary>
  /// Represents a client error (4xx HTTP status codes) from the API.
  /// </summary>
  public class ClientError : ApiException
  {
    public ClientError(string message, Exception? innerException = null) : base(message, innerException)
    {
    }

    public ClientError(string message, int statusCode, string? status = null, Exception? innerException = null) : base(message, statusCode, status, innerException)
    {
    }
  }
  /// <summary>
  /// Represents a server error (5xx HTTP status codes) from the API.
  /// </summary>
  public class ServerError : ApiException
  {
    public ServerError(string message, Exception? innerException = null) : base(message, innerException)
    {
    }

    public ServerError(string message, int statusCode, string? status = null, Exception? innerException = null) : base(message, statusCode, status, innerException)
    {
    }
  }
  public class HttpApiClient : ApiClient
  {
    public HttpApiClient(
        bool? enterprise = null,
        bool? vertexAI = null,
        string? apiKey = null,
        string? project = null,
        string? location = null,
        ICredential? credentials = null,
        Types.HttpOptions? httpOptions = null,
        Types.ClientOptions? clientOptions = null
    ) : base(enterprise, vertexAI, apiKey, project, location, credentials, httpOptions, clientOptions) { }

    public override async Task<ApiResponse> RequestAsync(
        HttpMethod httpMethod,
        string path,
        string requestJson,
        Types.HttpOptions? requestHttpOptions,
        CancellationToken cancellationToken = default)
    {
      Types.HttpOptions mergedHttpOptions = MergeHttpOptions(requestHttpOptions);
      var (response, attemptTimeout) = await SendWithRetryAsync(
          () => CreateHttpRequestAsync(httpMethod, path, requestJson, requestHttpOptions),
          HttpCompletionOption.ResponseContentRead,
          mergedHttpOptions.RetryOptions,
          GetEffectiveTimeout(requestHttpOptions),
          cancellationToken);
      // ResponseContentRead has already buffered the body, so the deadline is no longer needed.
      attemptTimeout?.Dispose();
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

    internal override async Task<ApiResponse> RequestAsync(
        HttpMethod httpMethod,
        string url,
        byte[] requestBytes,
        Types.HttpOptions? requestHttpOptions,
        CancellationToken cancellationToken = default)
    {
      Types.HttpOptions mergedHttpOptions = MergeHttpOptions(requestHttpOptions);
      var (response, attemptTimeout) = await SendWithRetryAsync(
          () => CreateHttpRequestAsync(httpMethod, url, requestBytes, requestHttpOptions),
          HttpCompletionOption.ResponseContentRead,
          mergedHttpOptions.RetryOptions,
          GetEffectiveTimeout(requestHttpOptions),
          cancellationToken);
      // ResponseContentRead has already buffered the body, so the deadline is no longer needed.
      attemptTimeout?.Dispose();
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
      Types.HttpOptions mergedHttpOptions = MergeHttpOptions(requestHttpOptions);

      // Only the initial send is retried; a stream cannot be restarted mid-flight.
      var (response, attemptTimeout) = await SendWithRetryAsync(
        () => CreateHttpRequestAsync(httpMethod, path, requestJson, requestHttpOptions),
        // Use ResponseHeadersRead to avoid buffering the entire response
        HttpCompletionOption.ResponseHeadersRead,
        mergedHttpOptions.RetryOptions,
        GetEffectiveTimeout(requestHttpOptions),
        cancellationToken);
      // The successful attempt's deadline also covers reading the stream body, so it is a
      // total deadline for that attempt's whole stream, not just its headers.
      using var attemptTimeoutScope = attemptTimeout;
      CancellationToken effectiveToken = attemptTimeout?.Token ?? cancellationToken;
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
#if NETSTANDARD2_0_OR_GREATER
      using (var stream = await response.Content.ReadAsStreamAsync())
#else
      using (var stream = await response.Content.ReadAsStreamAsync(effectiveToken))
#endif
      {
        await foreach (string chunk in ProcessStreamResponse(stream, effectiveToken))
        {
          yield return new StreamingApiResponse(chunk, response);
        }
      }
    }

    private bool ShouldPrependVertexProjectPath(Types.HttpOptions mergedHttpOptions)
    {
      if (!this.VertexAI) return false;
      if (!string.IsNullOrEmpty(this.ApiKey) && (string.IsNullOrEmpty(this.Project) || string.IsNullOrEmpty(this.Location))) return false;
      if (string.IsNullOrEmpty(this.Project) && string.IsNullOrEmpty(this.Location)) return false;
      if (mergedHttpOptions.BaseUrlResourceScope == Types.ResourceScope.Collection && !string.IsNullOrEmpty(mergedHttpOptions.BaseUrl)) return false;
      return true;
    }

    private async Task<HttpRequestMessage> CreateHttpRequestAsync(HttpMethod httpMethod, string path,
        string requestJson, Types.HttpOptions? requestHttpOptions)
    {
        Types.HttpOptions mergedHttpOptions = MergeHttpOptions(requestHttpOptions);
        bool queryBaseModel = httpMethod == HttpMethod.Get && path.StartsWith("publishers/google/models");
        if (ShouldPrependVertexProjectPath(mergedHttpOptions) && !path.StartsWith("projects/") && !queryBaseModel)
        {
            path = $"projects/{Project}/locations/{Location}/{path}";
        }
        string requestUrl;
        if (path.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
              path.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            // If the path is an absolute URL (typical for resumable file upload sessions), 
            // ensure it is rewritten to use the custom BaseUrl if one is provided.
            requestUrl = RewriteIfAbsoluteUrl(path, mergedHttpOptions);
        }
        else if (path.Contains(ApiVersionPlaceholder))
        {
            string? effectiveApiVersion = mergedHttpOptions.BaseUrlResourceScope == Types.ResourceScope.Collection
                ? string.Empty
                : mergedHttpOptions.ApiVersion;
            requestUrl = $"{mergedHttpOptions.BaseUrl}/{ResolveApiVersionInPath(path, effectiveApiVersion)}";
        }
        else if (string.IsNullOrEmpty(mergedHttpOptions.ApiVersion) || mergedHttpOptions.BaseUrlResourceScope == Types.ResourceScope.Collection)
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

    private async Task<HttpRequestMessage> CreateHttpRequestAsync(HttpMethod httpMethod, string url,
        byte[] requestBytes, Types.HttpOptions? requestHttpOptions)
    {
        Types.HttpOptions mergedHttpOptions = MergeHttpOptions(requestHttpOptions);

        // If the URL is an absolute Google URL (standard for file upload chunk requests),
        // we must rewrite it to stay within the user's custom BaseUrl/Proxy.
        url = RewriteIfAbsoluteUrl(url, mergedHttpOptions);

        var request = new HttpRequestMessage(httpMethod, url);
        await SetHeadersAsync(request, mergedHttpOptions);

        if (httpMethod.Method.Equals("POST", StringComparison.OrdinalIgnoreCase) ||
            httpMethod.Method.Equals("PATCH", StringComparison.OrdinalIgnoreCase))
        {
            request.Content = new ByteArrayContent(requestBytes);
            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
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

    private static readonly Regex ResponseLineRegex = new Regex(@"^data: ?(.*?)(?:\r\n\r\n|\n\n|\r\r)", RegexOptions.Singleline | RegexOptions.Compiled);

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
            processedChunkString = Regex.Replace(processedChunkString, @"\r?\ndata: ?", "\n");

            JsonNode? validatedChunk = ValidateChunk(processedChunkString);
            if (validatedChunk != null)
            {
              CheckForStreamErrors(validatedChunk);
              yield return processedChunkString;
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
    private static JsonNode? ValidateChunk(string processedChunkString)
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

          return JsonNode.Parse(processedChunkString);
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
        CheckForStreamErrors(JsonNode.Parse(chunkString));
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
    private void CheckForStreamErrors(JsonNode? chunkJson)
    {
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
        if (Credentials is GoogleCredential gc && !string.IsNullOrEmpty(gc.QuotaProject))
        {
            request.Headers.TryAddWithoutValidation("x-goog-user-project", gc.QuotaProject);
        }
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

    /// <summary>
    /// Rewrites an absolute URL (e.g. from a resumable upload session) to use the
    /// custom BaseUrl if one is provided. This ensures custom proxies are honored for file uploads.
    /// </summary>
    private string RewriteIfAbsoluteUrl(string url, Types.HttpOptions mergedHttpOptions)
    {
        if (string.IsNullOrEmpty(mergedHttpOptions.BaseUrl) ||
            (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
             !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase)))
        {
            return url;
        }

        try
        {
            Uri originalUri = new Uri(url);
            Uri baseUri = new Uri(mergedHttpOptions.BaseUrl);
            var uriBuilder = new UriBuilder(originalUri)
            {
                Scheme = baseUri.Scheme,
                Host = baseUri.Host,
                Port = baseUri.Port
            };
            return uriBuilder.Uri.ToString();
        }
        catch (UriFormatException)
        {
            return url;
        }
    }

    private const string AgentMessageHeader = "agent-message";
    internal const string AgentMessageWarningPrefix = "Warning: [Gemini API] ";
    private static readonly Regex AgentMessageTokenRegex = new Regex(
        @"^[A-Za-z*][A-Za-z0-9!#$%&'*+.^_`|~:/-]*$",
        RegexOptions.Compiled);
    internal static readonly ConcurrentDictionary<string, byte> SeenAgentMessages =
        new ConcurrentDictionary<string, byte>(StringComparer.Ordinal);

    internal static void ClearSeenAgentMessages()
    {
      SeenAgentMessages.Clear();
    }

    private static List<string>? SplitUnquoted(string text, char delimiter)
    {
      var parts = new List<string>();
      int start = 0;
      bool inQuotes = false;
      bool isDisplayString = false;
      bool escaped = false;

      for (int i = 0; i < text.Length; i++)
      {
        char ch = text[i];
        if (inQuotes)
        {
          if (!isDisplayString)
          {
            if (escaped)
            {
              escaped = false;
              continue;
            }
            if (ch == '\\')
            {
              escaped = true;
              continue;
            }
          }
          if (ch == '"')
          {
            inQuotes = false;
            isDisplayString = false;
          }
        }
        else
        {
          if (ch == '"')
          {
            inQuotes = true;
            isDisplayString = i > 0 && text[i - 1] == '%';
          }
          else if (ch == delimiter)
          {
            parts.Add(text.Substring(start, i - start));
            start = i + 1;
          }
        }
      }

      if (inQuotes)
      {
        return null;
      }
      parts.Add(text.Substring(start));
      return parts;
    }

    private static string? UnescapeQuotedString(string inner)
    {
      var sb = new StringBuilder(inner.Length);
      bool escaped = false;
      foreach (char ch in inner)
      {
        if (escaped)
        {
          if (ch != '"' && ch != '\\')
          {
            return null;
          }
          sb.Append(ch);
          escaped = false;
        }
        else if (ch == '\\')
        {
          escaped = true;
        }
        else if (ch == '"')
        {
          return null;
        }
        else
        {
          sb.Append(ch);
        }
      }
      if (escaped)
      {
        return null;
      }
      return sb.ToString();
    }

    private static int HexDigitValue(char c)
    {
      if (c >= '0' && c <= '9') return c - '0';
      if (c >= 'a' && c <= 'f') return c - 'a' + 10;
      if (c >= 'A' && c <= 'F') return c - 'A' + 10;
      return -1;
    }

    private static string UnquoteDisplayString(string inner)
    {
      var bytes = new List<byte>(inner.Length);
      for (int i = 0; i < inner.Length; i++)
      {
        if (inner[i] == '%' && i + 2 < inner.Length)
        {
          int hi = HexDigitValue(inner[i + 1]);
          int lo = HexDigitValue(inner[i + 2]);
          if (hi >= 0 && lo >= 0)
          {
            bytes.Add((byte)((hi << 4) | lo));
            i += 2;
            continue;
          }
        }
        byte[] charBytes = Encoding.UTF8.GetBytes(new[] { inner[i] });
        bytes.AddRange(charBytes);
      }
      return Encoding.UTF8.GetString(bytes.ToArray());
    }

    private static string? ParseStructuredAgentMessageItem(string rawItem)
    {
      string item = rawItem.Trim();
      if (string.IsNullOrEmpty(item))
      {
        return null;
      }

      List<string>? parts = SplitUnquoted(item, ';');
      if (parts == null || parts.Count < 2)
      {
        return null;
      }

      string code = parts[0].Trim();
      if (!AgentMessageTokenRegex.IsMatch(code))
      {
        return null;
      }

      string? msgValue = null;
      for (int i = 1; i < parts.Count; i++)
      {
        string param = parts[i].Trim();
        if (string.IsNullOrEmpty(param))
        {
          return null;
        }
        int eqIndex = param.IndexOf('=');
        if (eqIndex < 0)
        {
          if (!AgentMessageTokenRegex.IsMatch(param))
          {
            return null;
          }
          continue;
        }

        string key = param.Substring(0, eqIndex).Trim();
        string val = param.Substring(eqIndex + 1).Trim();
        if (!AgentMessageTokenRegex.IsMatch(key) || string.IsNullOrEmpty(val))
        {
          return null;
        }

        if (key == "msg")
        {
          if (val.StartsWith("%\"", StringComparison.Ordinal) &&
              val.EndsWith("\"", StringComparison.Ordinal) &&
              val.Length >= 3)
          {
            string inner = val.Substring(2, val.Length - 3);
            if (inner.IndexOf('"') >= 0)
            {
              return null;
            }
            msgValue = UnquoteDisplayString(inner);
          }
          else if (val.StartsWith("\"", StringComparison.Ordinal) &&
                   val.EndsWith("\"", StringComparison.Ordinal) &&
                   val.Length >= 2)
          {
            msgValue = UnescapeQuotedString(val.Substring(1, val.Length - 2));
            if (msgValue == null)
            {
              return null;
            }
          }
          else
          {
            return null;
          }
        }
      }

      return !string.IsNullOrEmpty(msgValue) ? msgValue : null;
    }

    internal static IReadOnlyList<string> ParseAgentMessageHeader(string? headerValue)
    {
      if (string.IsNullOrWhiteSpace(headerValue))
      {
        return Array.Empty<string>();
      }
      string stripped = headerValue!.Trim();
      if (string.IsNullOrEmpty(stripped))
      {
        return Array.Empty<string>();
      }

      // Plain-text fallback for headers that aren't RFC 9651 structured items.
      if (!stripped.Contains(";") && !stripped.Contains("=") && stripped.Contains(" "))
      {
        if (!stripped.StartsWith("\"") && !stripped.EndsWith("\""))
        {
          return new List<string> { stripped };
        }
      }

      List<string>? items = SplitUnquoted(stripped, ',');
      if (items == null)
      {
        return Array.Empty<string>();
      }

      var messages = new List<string>();
      foreach (string rawItem in items)
      {
        string? msg = ParseStructuredAgentMessageItem(rawItem);
        if (!string.IsNullOrEmpty(msg))
        {
          messages.Add(msg!);
        }
      }
      return messages;
    }

    /// <summary>
    /// Writes each message in the response's <c>Agent-Message</c> header to
    /// <see cref="Console.Error"/> once per process, prefixed with
    /// <see cref="AgentMessageWarningPrefix"/>. Console output (rather than
    /// <see cref="Trace"/>) keeps the warning visible without a configured trace listener.
    /// Shared by the GenerateContent client and the Interactions (GAOS) after-success hook so
    /// both use one dedup set. Never throws.
    /// </summary>
    internal static void WarnFromAgentMessageHeaders(HttpResponseHeaders headers)
    {
      try
      {
        if (!headers.TryGetValues(AgentMessageHeader, out var values))
        {
          return;
        }
        foreach (string headerVal in values)
        {
          foreach (string msg in ParseAgentMessageHeader(headerVal))
          {
            if (SeenAgentMessages.TryAdd(msg, 0))
            {
              Console.Error.WriteLine(AgentMessageWarningPrefix + msg);
            }
          }
        }
      }
      catch
      {
        // Never fail a request due to a malformed Agent-Message header.
      }
    }
  }
}
