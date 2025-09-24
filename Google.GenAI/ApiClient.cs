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

using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Threading;

using Google.Apis.Auth.OAuth2;
using Google.GenAI.Types;

namespace Google.GenAI
{
  /// <summary>
  /// Abstract base class for an API client which issues HTTP requests to the GenAI APIs.
  /// </summary>
  public abstract class ApiClient : IDisposable, IAsyncDisposable
  {
    private static readonly string SdkVersion = "0.1.0";

    protected HttpMessageInvoker HttpClient { get; }

    public string? ApiKey { get; }

    public string? Project { get; }
    public string? Location { get; }
    public ICredential? Credentials { get; }

    public HttpOptions HttpOptions { get; protected set; }
    public bool VertexAI { get; }

    private int _disposed = 0;

    /// <summary>
    /// Constructs an ApiClient for Gemini API.
    /// </summary>
    protected ApiClient(string? apiKey, HttpOptions? customHttpOptions)
    {
      this.ApiKey = apiKey ?? System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
      if (string.IsNullOrEmpty(this.ApiKey))
      {
        throw new ArgumentException(
            "API key must either be provided or set in the environment variable GOOGLE_API_KEY.");
      }

      this.Project = null;
      this.Location = null;
      this.Credentials = null;
      this.VertexAI = false;

      this.HttpOptions = GetDefaultHttpOptions(false, this.Location);

      if (customHttpOptions is not null)
      {
        this.HttpOptions = MergeHttpOptions(customHttpOptions);
      }

      this.HttpClient = CreateHttpClient(this.HttpOptions);
    }

    /// <summary>
    /// Constructs an ApiClient for Vertex AI APIs.
    /// </summary>
    protected ApiClient(
        string? project,
        string? location,
        ICredential? credentials,
        HttpOptions? customHttpOptions)
    {

      this.Project = project ?? System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT");
      if (string.IsNullOrEmpty(this.Project))
      {
        throw new ArgumentException(
            "Project must either be provided or set in the environment variable GOOGLE_CLOUD_PROJECT.");
      }

      this.Location = location ?? System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_LOCATION");
      if (string.IsNullOrEmpty(this.Location))
      {
        throw new ArgumentException(
            "Location must either be provided or set in the environment variable GOOGLE_CLOUD_LOCATION.");
      }

      this.Credentials = credentials ?? GetDefaultCredentials();

      this.HttpOptions = GetDefaultHttpOptions(true, this.Location);

      if (customHttpOptions is not null)
      {
        this.HttpOptions = MergeHttpOptions(customHttpOptions);
      }

      this.ApiKey = null;
      this.VertexAI = true;
      this.HttpClient = CreateHttpClient(this.HttpOptions);
    }

    private static HttpClient CreateHttpClient(HttpOptions httpOptions)
    {
      var client = new HttpClient();
      if (httpOptions.Timeout != null)
      {
        client.Timeout = System.TimeSpan.FromMilliseconds(httpOptions.Timeout.Value);
      }
      return client;
    }

    /// <summary>
    /// Sends an HTTP request given the HTTP method, path, and request JSON string.
    /// </summary>
    public abstract Task<ApiResponse> RequestAsync(
        HttpMethod httpMethod, string path, string requestJson, HttpOptions? requestHttpOptions,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends an HTTP request for streaming responses that return Server-Sent Events.
    /// </summary>
    /// <param name="httpMethod">The HTTP method to use.</param>
    /// <param name="path">The API path.</param>
    /// <param name="requestJson">The request body as JSON string.</param>
    /// <param name="requestHttpOptions">Optional HTTP options.</param>
    /// <param name="cancellationToken">The cancellation token to use.</param>
    /// <returns>An async enumerable of ApiResponse chunks.</returns>
    public abstract IAsyncEnumerable<ApiResponse> RequestStreamAsync(
        HttpMethod httpMethod,
        string path,
        string requestJson,
        HttpOptions? requestHttpOptions,
        [EnumeratorCancellation] CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the library version string.
    /// </summary>
    internal static string GetLibraryVersion()
    {
      string libraryLabel = $"google-genai-sdk/{SdkVersion}";
      // Using RuntimeInformation for .NET version
      string languageLabel = $"gl-dotnet/{8.0}";
      return $"{libraryLabel} {languageLabel}";
    }

    /// <summary>
    /// Merges the given HttpOptions with the client's current HttpOptions.
    /// </summary>
    /// <param name="optionsToApply">The HttpOptions to apply.</param>
    /// <returns>A new HttpOptions instance with merged values.</returns>
    protected HttpOptions MergeHttpOptions(HttpOptions? optionsToApply)
    {
      if (optionsToApply is null)
      {
        return this.HttpOptions with { };
      }

      var mergedOptions = this.HttpOptions with { };

      if (!string.IsNullOrEmpty(optionsToApply?.BaseUrl))
      {
        mergedOptions.BaseUrl = optionsToApply?.BaseUrl;
      }
      if (!string.IsNullOrEmpty(optionsToApply?.ApiVersion))
      {
        mergedOptions.ApiVersion = optionsToApply?.ApiVersion;
      }
      if (optionsToApply?.Timeout != null)
      {
        mergedOptions.Timeout = optionsToApply?.Timeout;
      }

      var currentHeaders = this.HttpOptions.Headers ?? new Dictionary<string, string>(ImmutableDictionary<string, string>.Empty);
      var newHeaders = optionsToApply.Headers ?? new Dictionary<string, string>(ImmutableDictionary<string, string>.Empty);

      var headersBuilder = ImmutableDictionary.CreateBuilder<string, string>(StringComparer.OrdinalIgnoreCase);

      foreach (var header in currentHeaders)
      {
        headersBuilder[header.Key] = header.Value;
      }
      foreach (var header in newHeaders)
      {
        if (string.Equals(header.Key, "User-Agent", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(header.Key, "x-goog-api-client", StringComparison.OrdinalIgnoreCase))
        {
          if (headersBuilder.TryGetValue(header.Key, out var existingValue))
          {
            headersBuilder[header.Key] = $"{existingValue} {header.Value}";
          }
          else
          {
            headersBuilder[header.Key] = header.Value;
          }
        }
        else
        {
          headersBuilder[header.Key] = header.Value;
        }
      }
      mergedOptions.Headers = new Dictionary<string, string>(headersBuilder.ToImmutable());

      return mergedOptions;
    }

    internal static HttpOptions GetDefaultHttpOptions(bool vertexAI, string? location)
    {
      var defaultHeadersBuilder = ImmutableDictionary.CreateBuilder<string, string>(StringComparer.OrdinalIgnoreCase);
      defaultHeadersBuilder.Add("Content-Type", "application/json");
      defaultHeadersBuilder.Add("User-Agent", GetLibraryVersion());
      defaultHeadersBuilder.Add("x-goog-api-client", GetLibraryVersion());

      var defaultHttpOptions = new HttpOptions
      {
        Headers = new Dictionary<string, string>(defaultHeadersBuilder.ToImmutable()),
      };

      if (vertexAI)
      {
        if (string.IsNullOrEmpty(location))
        {
          throw new ArgumentException("Location must be provided for Vertex AI APIs.");
        }
        defaultHttpOptions.BaseUrl = location.Equals("global", StringComparison.OrdinalIgnoreCase)
            ? "https://aiplatform.googleapis.com"
            : $"https://{location}-aiplatform.googleapis.com";
        defaultHttpOptions.ApiVersion = "v1beta1";
      }
      else
      {
        defaultHttpOptions.BaseUrl = "https://generativelanguage.googleapis.com";
        defaultHttpOptions.ApiVersion = "v1beta";
      }
      return defaultHttpOptions;
    }

    private GoogleCredential GetDefaultCredentials()
    {
      try
      {
        var credentialTask = GoogleCredential.GetApplicationDefaultAsync();
        GoogleCredential credential = credentialTask.GetAwaiter().GetResult();

        if (credential.IsCreateScopedRequired)
        {
          credential = credential.CreateScoped("https://www.googleapis.com/auth/cloud-platform");
        }
        return credential;
      }
      catch (Exception e)
      {
        throw new ArgumentException(
            "Failed to get application default credentials. Please ensure credentials are set up correctly (e.g., via gcloud auth application-default login) or provide them explicitly.",
            e);
      }
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (Interlocked.CompareExchange(ref _disposed, 1, 0) != 0)
      {
        return;
      }
      if (disposing)
      {
        HttpClient?.Dispose();
      }
    }

    /// <summary>
    /// Asynchronously disposes the client and its underlying resources.
    /// </summary>
    /// <returns>A <see cref="ValueTask"/> that represents the asynchronous dispose operation.</returns>
    public virtual ValueTask DisposeAsync()
    {
        Dispose();
        return ValueTask.CompletedTask;
    }
  }
}
