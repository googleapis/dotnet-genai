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

using Google.Apis.Auth.OAuth2;

#if !NETSTANDARD2_0
using Google.GenAI.Gaos;
#endif

namespace Google.GenAI
{
  /// <summary>
  /// Client for making synchronous requests.
  /// Using this client to make a request to Gemini Developer API or Vertex AI API.
  /// </summary>
  public sealed class Client : IDisposable, IAsyncDisposable
  {
    private static string? geminiBaseUrl = null;
    private static string? vertexBaseUrl = null;
    internal readonly ApiClient _apiClient;
    public Live Live { get; }
    public Models Models { get; }
    public Tunings Tunings { get; }
    public Caches Caches { get; }
    public Batches Batches { get; }
    public Operations Operations { get; }
    public Files Files { get; }
    public Tokens Tokens { get; }

#if !NETSTANDARD2_0
    /// <summary>
    /// EXPERIMENTAL: The interactions service is experimental.
    /// </summary>
    public IInteractions Interactions 
    {
      get {
        if (!_warnedInteractions) {
          lock (_warnLock) {
            if (!_warnedInteractions) {
              System.Diagnostics.Trace.TraceWarning(
                  "Warning: Interactions service is experimental and subject to change.");
              _warnedInteractions = true;
            }
          }
        }
        return _interactionsClient.Interactions;
      }
    }

    /// <summary>
    /// EXPERIMENTAL: The webhooks service is experimental.
    /// </summary>
    public IWebhooks Webhooks => _interactionsClient.Webhooks;

    /// <summary>
    /// EXPERIMENTAL: The agents service is experimental.
    /// </summary>
    public IAgents Agents => _interactionsClient.Agents;

    private readonly Google.GenAI.Gaos.GenAI _interactionsClient;
#endif

    private static volatile bool _warnedInteractions = false;
    private static readonly object _warnLock = new object();
    private int _disposed = 0;

    /// <summary>
    /// Constructs a Client instance with the given parameters.
    /// </summary>
    /// <param name="enterprise">Optional Boolean for whether to use Gemini Enterprise Agent Platform APIs.
    /// If neither is specified here nor in the environment variable, defaults to false.
    /// If both enterprise and vertexAI are set, and they have different values, an ArgumentException will be thrown.</param>
    /// <param name="vertexAI">Optional Boolean for whether to use Vertex AI APIs (now Gemini Enterprise Agent Platform). If not specified
    /// here nor in the environment variable, defaults to false.
    /// NOTE: Use enterprise parameter from now on. enterprise parameter takes precedence over this flag.
    /// If both enterprise and vertexAI are set, and they have different values, an ArgumentException will be thrown.</param>
    /// <param name="apiKey">Optional String for the <a
    /// href="https://ai.google.dev/gemini-api/docs/api-key">API key</a>. Gemini API only.</param>
    /// <param name="credential">Optional <see cref="Google.Apis.Auth.OAuth2.GoogleCredential"/>.
    /// Vertex AI only.</param> <param name="project">Optional String for the project ID. Vertex AI
    /// APIs only. Find your <a
    /// href="https://cloud.google.com/resource-manager/docs/creating-managing-projects#identifying_projects">project
    /// ID</a>.</param> <param name="location">Optional String for the <a
    /// href="https://cloud.google.com/vertex-ai/generative-ai/docs/learn/locations">location</a>.
    /// Vertex AI APIs only.</param>
    /// <param name="httpOptions">Optional <see cref="Google.GenAI.Types.HttpOptions"/> for sending
    /// HTTP requests.</param> <exception cref="System.ArgumentException">Thrown if the
    /// project/location and API key are set together.</exception>
    /// <param name="clientOptions">Optional <see cref="Google.GenAI.Types.ClientOptions"/> for
    /// configuring the client.</param>
    public Client(bool? enterprise = null, bool? vertexAI = null, string? apiKey = null, ICredential? credential = null,
                  string? project = null, string? location = null,
                  Types.HttpOptions? httpOptions = null,
                  Types.ClientOptions? clientOptions = null)
    {
      httpOptions ??= new();

      if (enterprise.HasValue && vertexAI.HasValue && enterprise.Value != vertexAI.Value)
      {
        throw new ArgumentException("enterprise and vertexAI flags have conflicting values, please set enterprise value only.");
      }

      bool? resolvedCloudFlag = null;

      if (enterprise.HasValue)
      {
        resolvedCloudFlag = enterprise.Value;
      }

      if (!resolvedCloudFlag.HasValue && vertexAI.HasValue)
      {
        resolvedCloudFlag = vertexAI.Value;
      }

      string? enterpriseEnv = System.Environment.GetEnvironmentVariable("GOOGLE_GENAI_USE_ENTERPRISE");
      string? vertexAIEnv = System.Environment.GetEnvironmentVariable("GOOGLE_GENAI_USE_VERTEXAI");

      if (!resolvedCloudFlag.HasValue && enterpriseEnv != null && vertexAIEnv != null)
      {
        System.Diagnostics.Trace.TraceWarning("Warning: Both GOOGLE_GENAI_USE_ENTERPRISE and GOOGLE_GENAI_USE_VERTEXAI are set. The value of GOOGLE_GENAI_USE_ENTERPRISE will be used.");
      }

      if (!resolvedCloudFlag.HasValue && enterpriseEnv != null)
      {
        resolvedCloudFlag = enterpriseEnv.ToLower() == "true";
      }

      if (!resolvedCloudFlag.HasValue && vertexAIEnv != null)
      {
        resolvedCloudFlag = vertexAIEnv.ToLower() == "true";
      }

      bool useCloudPlatform = resolvedCloudFlag ?? false;

      string projectEnv = Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT");
      string locationEnv = Environment.GetEnvironmentVariable("GOOGLE_CLOUD_LOCATION");

      string googleApiKeyEnv = Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
      string geminiApiKeyEnv = Environment.GetEnvironmentVariable("GEMINI_API_KEY");
      // Resolve silently here, ApiClient will warn if both are set.
      string? resolvedApiKeyEnv = googleApiKeyEnv ?? geminiApiKeyEnv;

      if ((project != null || location != null) && !useCloudPlatform)
      {
        if (string.IsNullOrEmpty(resolvedApiKeyEnv) && string.IsNullOrEmpty(apiKey)) {
          throw new ArgumentException(
              "project/location is present, but neither enterprise nor vertexAI is set to true. project/location can only be used for a cloud platform. Please set enterprise to be true.");
        }
      }

      httpOptions.BaseUrl ??= inferBaseUrl(useCloudPlatform);

      _apiClient = new HttpApiClient(enterprise, vertexAI, apiKey, project, location, credential, httpOptions, clientOptions);
      Live = new Live(_apiClient);
      Models = new Models(_apiClient);
      Tunings = new Tunings(_apiClient);
      Caches = new Caches(_apiClient);
      Batches = new Batches(_apiClient);
      Operations = new Operations(_apiClient);
      Files = new Files(_apiClient);
      Tokens = new Tokens(_apiClient);
#if !NETSTANDARD2_0
      string? apiVersion = _apiClient.HttpOptions.ApiVersion;
      if (_apiClient.VertexAI && !string.IsNullOrEmpty(_apiClient.Project) && !string.IsNullOrEmpty(_apiClient.Location))
      {
          apiVersion = $"{apiVersion}/projects/{_apiClient.Project}/locations/{_apiClient.Location}";
      }

      _interactionsClient = new Google.GenAI.Gaos.GenAI(
          securitySource: () =>
          {
              var security = new Google.GenAI.Gaos.Models.Components.Security();
              if (_apiClient.ApiKey != null)
              {
                  security.ApiKey = _apiClient.ApiKey;
              }
              else if (_apiClient.Credentials != null)
              {
                  security.AccessToken = _apiClient.Credentials.GetAccessTokenForRequestAsync()
                      .GetAwaiter().GetResult();
              }
              if (_apiClient.HttpOptions.Headers != null)
              {
                  security.DefaultHeaders = new Dictionary<string, string>();
                  foreach (var kvp in _apiClient.HttpOptions.Headers)
                  {
                      if (!kvp.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
                      {
                          security.DefaultHeaders[kvp.Key] = kvp.Value;
                      }
                  }
              }
              return security;
          },
          serverUrl: _apiClient.HttpOptions.BaseUrl,
          apiVersion: apiVersion,
          client: new GaosHttpClient(_apiClient.HttpClient)
      );
#endif
    }

    static string? inferBaseUrl(bool vertexAI)
    {
      if (vertexAI)
        return vertexBaseUrl ?? Environment.GetEnvironmentVariable("GOOGLE_VERTEX_BASE_URL");
      else
        return geminiBaseUrl ?? Environment.GetEnvironmentVariable("GOOGLE_GEMINI_BASE_URL");
    }

    public static void setDefaultBaseUrl(string? vertexBaseUrl, string? geminiBaseUrl)
    {
      Client.vertexBaseUrl = vertexBaseUrl;
      Client.geminiBaseUrl = geminiBaseUrl;
    }

    /// <summary>
    /// Disposes the client and its underlying resources.
    /// </summary>
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
      if (Interlocked.CompareExchange(ref _disposed, 1, 0) != 0)
      {
        return;
      }

      if (disposing)
      {
        _apiClient.Dispose();
      }
    }

    /// <summary>
    /// Asynchronously disposes the client and its underlying resources.
    /// </summary>
    /// <returns>A <see cref="ValueTask"/> that represents the asynchronous dispose operation.</returns>
    public async ValueTask DisposeAsync()
    {
      if (Interlocked.CompareExchange(ref _disposed, 1, 0) != 0)
      {
        return;
      }
      await _apiClient.DisposeAsync();
      GC.SuppressFinalize(this);
    }
  }
}
