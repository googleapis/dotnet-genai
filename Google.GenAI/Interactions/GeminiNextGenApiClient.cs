// Copyright 2025 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Exceptions;
using Google.GenAI.Interactions.Services;

namespace Google.GenAI.Interactions;

/// <inheritdoc/>
public sealed class GeminiNextGenApiClient : IGeminiNextGenApiClient
{
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string? ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public string ApiVersion
    {
        get { return this._options.ApiVersion; }
        init { this._options.ApiVersion = value; }
    }

    readonly Lazy<IGeminiNextGenApiClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGeminiNextGenApiClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public IGeminiNextGenApiClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GeminiNextGenApiClient(modifier(this._options));
    }

    readonly Lazy<IInteractionService> _interactions;
    public IInteractionService Interactions
    {
        get { return _interactions.Value; }
    }

    public void Dispose() => this.HttpClient.Dispose();

    public GeminiNextGenApiClient()
    {
        _options = new();

        _withRawResponse = new(() => new GeminiNextGenApiClientWithRawResponse(this._options));
        _interactions = new(() => new InteractionService(this));
    }

    public GeminiNextGenApiClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}

/// <inheritdoc/>
public sealed class GeminiNextGenApiClientWithRawResponse : IGeminiNextGenApiClientWithRawResponse
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string? ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public string ApiVersion
    {
        get { return this._options.ApiVersion; }
        init { this._options.ApiVersion = value; }
    }

    /// <inheritdoc/>
    public IGeminiNextGenApiClientWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new GeminiNextGenApiClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<IInteractionServiceWithRawResponse> _interactions;
    public IInteractionServiceWithRawResponse Interactions
    {
        get { return _interactions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, retries, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw GeminiNextGenApiExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new GeminiNextGenApiIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        int retryCount,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var url = this.PrepareUrl(request.Params.Url(this._options));

        using HttpRequestMessage requestMessage = new(request.Method, url)
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);

        await this.PrepareRequestMessage(requestMessage, cancellationToken);

        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new GeminiNextGenApiIOException("I/O exception", e);
        }
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
    }

    // Vertex uses different URLs, so we need to adjust them when using it
    internal Uri PrepareUrl(Uri url)
    {
        if (this._options.VertexInfo is VertexInfo { Project: var project, Location: var location })
        {
            var segments = url.Segments;
            // segments 0 is just `/`, which we don't care about
            // segments 1 is our version
            // segments 2 and beyond is the rest of the endpoint
            // so we end up with `$version/projects/$project/locations/$location/$endpoint`
            url = new UriBuilder(url)
            {
                Path =
                    $"{segments[1]}projects/{project}/locations/{location}/{string.Concat(segments.Skip(2))}",
            }.Uri;
        }

        return url;
    }

    // add some Google-specific headers if needed (for example, for Vertex authentication)
    internal async Task PrepareRequestMessage(
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken = default
    )
    {
        if (requestMessage.Headers.Contains("x-goog-api-key"))
        {
            return;
        }

        if (!string.IsNullOrEmpty(ApiKey))
        {
            requestMessage.Headers.TryAddWithoutValidation("x-goog-api-key", ApiKey);
        }
        else if (
            !requestMessage.Headers.Contains("Authorization")
            && this._options.VertexInfo is VertexInfo { Credentials: var credentials }
        )
        {
            if (credentials == null)
            {
                throw new Exception("Credentials are required when API key is not provided.");
            }

            string accessToken = await credentials
                .GetAccessTokenForRequestAsync(cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new Exception("Failed to obtain access token from credentials.");
            }

            requestMessage.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            if (
                credentials is Google.Apis.Auth.OAuth2.GoogleCredential gc
                && !string.IsNullOrEmpty(gc.QuotaProject)
            )
            {
                requestMessage.Headers.TryAddWithoutValidation(
                    "x-goog-user-project",
                    gc.QuotaProject
                );
            }
        }
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (
            apiBackoff != null
            && apiBackoff > TimeSpan.Zero
            && apiBackoff < TimeSpan.FromMinutes(1)
        )
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is GeminiNextGenApiIOException;
    }

    public void Dispose() => this.HttpClient.Dispose();

    public GeminiNextGenApiClientWithRawResponse()
    {
        _options = new();

        _interactions = new(() => new InteractionServiceWithRawResponse(this));
    }

    public GeminiNextGenApiClientWithRawResponse(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
