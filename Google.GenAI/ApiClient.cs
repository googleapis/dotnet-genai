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
using System.Reflection;
using System.Runtime.CompilerServices;

using Google.Apis.Auth.OAuth2;
using Google.GenAI.Types;

namespace Google.GenAI
{
  /// <summary>
  /// Abstract base class for an API client which issues HTTP requests to the GenAI APIs.
  /// </summary>
  public abstract class ApiClient : IDisposable, IAsyncDisposable
  {
    private static readonly string SdkVersion = GetSdkVersion();

    private static readonly HashSet<string> MultiRegionalLocations = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "us",
        "eu"
    };

    private HttpClient? _httpClient;
    private readonly object _httpClientLock = new object();

    protected HttpClient HttpClient
    {
        get
        {
            if (_httpClient == null)
            {
                lock (_httpClientLock)
                {
                    if (Interlocked.CompareExchange(ref _disposed, 0, 0) != 0)
                    {
                        throw new ObjectDisposedException(nameof(ApiClient));
                    }
                    _httpClient ??= CreateHttpClient(this.HttpOptions, this.ClientOptions);
                }
            }
            return _httpClient;
        }
    }

    public string? ApiKey { get; }

    public string? Project { get; }
    public string? Location { get; }
    public ICredential? Credentials { get; }

    public string? CustomBaseUrl { get; }

    public HttpOptions HttpOptions { get; protected set; }
    public Google.GenAI.Types.ClientOptions ClientOptions { get; protected set; }
    public bool VertexAI { get; }

    private int _disposed = 0;

    /// <summary>
    /// Constructs an ApiClient.
    /// </summary>
    protected ApiClient(
        bool? vertexAI = null,
        string? apiKey = null,
        string? project = null,
        string? location = null,
        ICredential? credentials = null,
        HttpOptions? customHttpOptions = null,
        Google.GenAI.Types.ClientOptions? clientOptions = null)
    {
      if (vertexAI.HasValue)
      {
        this.VertexAI = vertexAI.Value;
      }
      else
      {
        string? vertexAIEnv = System.Environment.GetEnvironmentVariable("GOOGLE_GENAI_USE_VERTEXAI");
        this.VertexAI = vertexAIEnv != null && vertexAIEnv.ToLower() == "true";
      }

      var envProject = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT");
      var envLocation = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_LOCATION");
      var envApiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");

      this.Project = project ?? envProject;
      this.Location = location ?? envLocation;
      this.ApiKey = apiKey ?? envApiKey;
      this.Credentials = credentials;
      this.CustomBaseUrl = customHttpOptions?.BaseUrl;

      // Validate explicitly set initializer values.
      if (customHttpOptions?.BaseUrlResourceScope != null && string.IsNullOrEmpty(customHttpOptions?.BaseUrl))
      {
        throw new ArgumentException(
            "base_url must be set when base_url_resource_scope is set.");
      }

      if ((project != null || location != null) && apiKey != null)
      {
        throw new ArgumentException(
            "Project/location and API key are mutually exclusive in the client initializer.");
      }
      else if (credentials != null && apiKey != null)
      {
        throw new ArgumentException(
            "Credentials and API key are mutually exclusive in the client initializer.");
      }

      if (this.VertexAI)
      {
        if (credentials != null && !string.IsNullOrEmpty(envApiKey))
        {
          this.ApiKey = null;
        }
        else if ((!string.IsNullOrEmpty(envLocation) || !string.IsNullOrEmpty(envProject)) && !string.IsNullOrEmpty(apiKey))
        {
          this.Project = null;
          this.Location = null;
        }
        else if ((!string.IsNullOrEmpty(project) || !string.IsNullOrEmpty(location)) && !string.IsNullOrEmpty(envApiKey))
        {
          this.ApiKey = null;
        }
        else if ((!string.IsNullOrEmpty(envLocation) || !string.IsNullOrEmpty(envProject)) && !string.IsNullOrEmpty(envApiKey))
        {
          this.ApiKey = null;
        }

        if (string.IsNullOrEmpty(this.Location) && string.IsNullOrEmpty(this.ApiKey))
        {
          if (this.CustomBaseUrl == null || this.CustomBaseUrl.EndsWith(".googleapis.com"))
          {
            this.Location = "global";
          }
        }

        bool hasSufficientAuth = (!string.IsNullOrEmpty(this.Project) && !string.IsNullOrEmpty(this.Location)) || !string.IsNullOrEmpty(this.ApiKey);

        if (!hasSufficientAuth && this.CustomBaseUrl == null)
        {
          throw new ArgumentException("Project or API key must be set when using the Vertex AI API.");
        }

        bool hasSufficientAuthParams = (project != null && location != null) || apiKey != null;
        if (this.CustomBaseUrl != null && !this.CustomBaseUrl.EndsWith(".googleapis.com") && !hasSufficientAuthParams)
        {
          this.Project = null;
          this.Location = null;
          this.ApiKey = null;
        }

        if (!string.IsNullOrEmpty(this.Project) && !string.IsNullOrEmpty(this.Location))
        {
          this.Credentials ??= GetDefaultCredentials();
        }
      }
      else
      {
        this.Project = null;
        this.Location = null;
        this.Credentials = null;

        if (string.IsNullOrEmpty(this.ApiKey))
        {
          throw new ArgumentException(
              "API key must either be provided or set in the environment variable GOOGLE_API_KEY.");
        }
      }

      this.HttpOptions = GetDefaultHttpOptions(this.VertexAI, this.Location);

      if (customHttpOptions != null)
      {
        this.HttpOptions = MergeHttpOptions(customHttpOptions);
      }

      this.ClientOptions = clientOptions ?? new Google.GenAI.Types.ClientOptions();
    }

    private static HttpClient CreateHttpClient(
        HttpOptions httpOptions, Google.GenAI.Types.ClientOptions? clientOptions = null
    )
    {
      HttpClient client = null;
      if (clientOptions != null)
      {
        client = clientOptions.HttpClientFactory?.Invoke();
      }
      // If no factory was provided, create a default client and apply SDK options
      if (client == null)
      {
        client = new HttpClient();
        if (httpOptions.Timeout != null)
        {
          client.Timeout = System.TimeSpan.FromMilliseconds(httpOptions.Timeout.Value);
        }
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
    /// Sends an HTTP request with binary content.
    /// </summary>
    internal abstract Task<ApiResponse> RequestAsync(
        HttpMethod httpMethod, string path, byte[] requestBytes, HttpOptions? requestHttpOptions,
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
      if (optionsToApply?.ApiVersion != null)
      {
        mergedOptions.ApiVersion = optionsToApply?.ApiVersion;
      }
      if (optionsToApply?.Timeout != null)
      {
        mergedOptions.Timeout = optionsToApply?.Timeout;
      }
      if (optionsToApply?.BaseUrlResourceScope != null)
      {
        mergedOptions.BaseUrlResourceScope = optionsToApply?.BaseUrlResourceScope;
      }

      var currentHeaders = this.HttpOptions.Headers ?? new Dictionary<string, string>();
      var newHeaders = optionsToApply?.Headers ?? new Dictionary<string, string>();

      var headersBuilder = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

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
      mergedOptions.Headers = headersBuilder;

      return mergedOptions;
    }

    internal static HttpOptions GetDefaultHttpOptions(bool vertexAI, string? location)
    {

      var defaultHttpOptions = new HttpOptions
      {
        Headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
          { "Content-Type", "application/json" },
          { "User-Agent", GetLibraryVersion() },
          { "x-goog-api-client", GetLibraryVersion() }
        },
      };

      if (vertexAI)
      {
        if (string.IsNullOrEmpty(location) || location!.Equals("global", StringComparison.OrdinalIgnoreCase))
        {
          defaultHttpOptions.BaseUrl = "https://aiplatform.googleapis.com";
        }
        else if (MultiRegionalLocations.Contains(location!))
        {
          defaultHttpOptions.BaseUrl = $"https://aiplatform.{location}.rep.googleapis.com";
        }
        else
        {
          defaultHttpOptions.BaseUrl = $"https://{location}-aiplatform.googleapis.com";
        }
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
        _httpClient?.Dispose();
      }
    }

    /// <summary>
    /// Asynchronously disposes the client and its underlying resources.
    /// </summary>
    /// <returns>A <see cref="ValueTask"/> that represents the asynchronous dispose operation.</returns>
    public virtual ValueTask DisposeAsync()
    {
        Dispose();
#if NETSTANDARD2_0_OR_GREATER
        return new ValueTask(Task.CompletedTask);
#else
        return ValueTask.CompletedTask;
#endif
    }

    private static string GetSdkVersion()
    {
        // This reads AssemblyInformationalVersionAttribute from the assembly,
        // which is generated during build from the <Version> property.
        // Google.GenAI.csproj imports ReleaseVersion.xml to set <Version>,
        // so this effectively reads the version from ReleaseVersion.xml.
        return typeof(ApiClient)
            .Assembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            ?.InformationalVersion ?? "";
    }
  }
}
