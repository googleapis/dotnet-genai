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

namespace Google.GenAI {
  /// <summary>
  /// Client for making synchronous requests.
  /// Using this client to make a request to Gemini Developer API or Vertex AI API.
  /// </summary>
  public sealed class Client : IDisposable, IAsyncDisposable {
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

    private int _disposed = 0;

    /// <summary>
    /// Constructs a Client instance with the given parameters.
    /// </summary>
    /// <param name="vertexAI">Optional Boolean for whether to use Vertex AI APIs. If not specified
    /// here nor in the environment variable, defaults to false.</param> <param
    /// name="apiKey">Optional String for the <a
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
    public Client(bool? vertexAI = null, string? apiKey = null, ICredential? credential = null,
                  string? project = null, string? location = null,
                  Types.HttpOptions? httpOptions = null) {
      bool resolvedVertexAI;
      if (vertexAI.HasValue) {
        resolvedVertexAI = vertexAI.Value;
      } else {
        string? vertexAIEnv = Environment.GetEnvironmentVariable("GOOGLE_GENAI_USE_VERTEXAI");
        resolvedVertexAI = vertexAIEnv != null && vertexAIEnv.ToLower() == "true";
      }
      string projectEnv = Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT");
      string locationEnv = Environment.GetEnvironmentVariable("GOOGLE_CLOUD_LOCATION");
      string apiKeyEnv = Environment.GetEnvironmentVariable("GOOGLE_API_KEY");

      if ((project != null || location != null) && !resolvedVertexAI) {
        if (apiKeyEnv == null && apiKey == null)
        {
          throw new ArgumentException(
              "project/location is present, but vertexai is not set to true. project/location can only be used for Vertex AI. Please set vertexai to be true.");
        }
      }

      string? baseUrl = inferBaseUrl(resolvedVertexAI, httpOptions);
      if (baseUrl != null && httpOptions != null && httpOptions.BaseUrl == null) {
        httpOptions.BaseUrl = baseUrl;
      }

      _apiClient = new HttpApiClient(vertexAI, apiKey, project, location, credential, httpOptions);
      Live = new Live(_apiClient);
      Models = new Models(_apiClient);
      Tunings = new Tunings(_apiClient);
      Caches = new Caches(_apiClient);
      Batches = new Batches(_apiClient);
      Operations = new Operations(_apiClient);
      Files = new Files(_apiClient);
    }

    static string? inferBaseUrl(bool vertexAI, Types.HttpOptions? httpOptions) {
      if (httpOptions?.BaseUrl != null)
        return httpOptions.BaseUrl;
      if (vertexAI)
        return vertexBaseUrl ?? Environment.GetEnvironmentVariable("GOOGLE_VERTEX_BASE_URL");
      else
        return geminiBaseUrl ?? Environment.GetEnvironmentVariable("GOOGLE_GEMINI_BASE_URL");
    }

    public static void setDefaultBaseUrl(string? vertexBaseUrl, string? geminiBaseUrl) {
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
