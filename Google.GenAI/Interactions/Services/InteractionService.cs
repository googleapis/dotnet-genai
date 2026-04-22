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
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Exceptions;
using Google.GenAI.Interactions.Models.Interactions;

namespace Google.GenAI.Interactions.Services;

/// <summary>
/// EXPERIMENTAL: The interactions service is experimental and subject to change.
/// </summary>
public sealed class InteractionService : IInteractionService
{
    readonly Lazy<IInteractionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInteractionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IGeminiNextGenApiClient _client;

    /// <inheritdoc/>
    public IInteractionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InteractionService(this._client.WithOptions(modifier));
    }

    public InteractionService(IGeminiNextGenApiClient client)
    {
        _client = client;

        _withRawResponse = new(() => new InteractionServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Interaction> Create(
        InteractionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<InteractionSseEvent> CreateStreaming(
        InteractionCreateParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateStreaming(parameters, cancellationToken)
            .ConfigureAwait(false);
        await foreach (var interaction in response.Enumerate(cancellationToken))
        {
            yield return interaction;
        }
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Delete(
        InteractionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JsonElement> Delete(
        string id,
        InteractionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Interaction> Cancel(
        InteractionCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Interaction> Cancel(
        string id,
        InteractionCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Interaction> Get(
        InteractionGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Interaction> Get(
        string id,
        InteractionGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<InteractionSseEvent> GetStreaming(
        InteractionGetParams parameters,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetStreaming(parameters, cancellationToken)
            .ConfigureAwait(false);
        await foreach (var interaction in response.Enumerate(cancellationToken))
        {
            yield return interaction;
        }
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<InteractionSseEvent> GetStreaming(
        string id,
        InteractionGetParams? parameters = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await foreach (
            var item in this.GetStreaming(parameters with { ID = id }, cancellationToken)
        )
        {
            yield return item;
        }
    }
}

/// <inheritdoc/>
public sealed class InteractionServiceWithRawResponse : IInteractionServiceWithRawResponse
{
    readonly IGeminiNextGenApiClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInteractionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InteractionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InteractionServiceWithRawResponse(IGeminiNextGenApiClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Interaction>> Create(
        InteractionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        parameters = parameters with
        {
            ApiVersion = parameters.ApiVersion ?? this._client.ApiVersion,
        };

        if (parameters.ApiVersion == null)
        {
            throw new GeminiNextGenApiInvalidDataException(
                "'parameters.ApiVersion' cannot be null"
            );
        }

        HttpRequest<InteractionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var interaction = await response
                    .Deserialize<Interaction>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    interaction.Validate();
                }
                return interaction;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<StreamingHttpResponse<InteractionSseEvent>> CreateStreaming(
        InteractionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        parameters = parameters with
        {
            ApiVersion = parameters.ApiVersion ?? this._client.ApiVersion,
        };

        if (parameters.ApiVersion == null)
        {
            throw new GeminiNextGenApiInvalidDataException(
                "'parameters.ApiVersion' cannot be null"
            );
        }

        Dictionary<string, object> rawBodyData;
        try
        {
            rawBodyData =
                JsonSerializer.Deserialize<Dictionary<string, object>>(parameters.RawBodyData)
                ?? throw new GeminiNextGenApiInvalidDataException(
                    "'RawBodyData' must be an object"
                );
        }
        catch (JsonException e)
        {
            throw new GeminiNextGenApiInvalidDataException("'RawBodyData' must be an object", e);
        }
        rawBodyData["stream"] = JsonSerializer.SerializeToElement(true);
        parameters = InteractionCreateParams.FromRawUnchecked(
            parameters.RawHeaderData,
            parameters.RawQueryData,
            JsonSerializer.SerializeToElement(rawBodyData),
            parameters.ApiVersion
        );

        HttpRequest<InteractionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);

        async IAsyncEnumerable<InteractionSseEvent> Enumerate(
            [EnumeratorCancellation] CancellationToken token
        )
        {
            await foreach (
                var interaction in Sse.Enumerate<InteractionSseEvent>(response.RawMessage, token)
            )
            {
                if (this._client.ResponseValidation)
                {
                    interaction.Validate();
                }
                yield return interaction;
            }
        }
        return new(response, Enumerate);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> Delete(
        InteractionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        parameters = parameters with
        {
            ApiVersion = parameters.ApiVersion ?? this._client.ApiVersion,
        };

        if (parameters.ApiVersion == null)
        {
            throw new GeminiNextGenApiInvalidDataException(
                "'parameters.ApiVersion' cannot be null"
            );
        }
        if (parameters.ID == null)
        {
            throw new GeminiNextGenApiInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<InteractionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> Delete(
        string id,
        InteractionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Interaction>> Cancel(
        InteractionCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        parameters = parameters with
        {
            ApiVersion = parameters.ApiVersion ?? this._client.ApiVersion,
        };

        if (parameters.ApiVersion == null)
        {
            throw new GeminiNextGenApiInvalidDataException(
                "'parameters.ApiVersion' cannot be null"
            );
        }
        if (parameters.ID == null)
        {
            throw new GeminiNextGenApiInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<InteractionCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var interaction = await response
                    .Deserialize<Interaction>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    interaction.Validate();
                }
                return interaction;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Interaction>> Cancel(
        string id,
        InteractionCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Interaction>> Get(
        InteractionGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        parameters = parameters with
        {
            ApiVersion = parameters.ApiVersion ?? this._client.ApiVersion,
        };

        if (parameters.ApiVersion == null)
        {
            throw new GeminiNextGenApiInvalidDataException(
                "'parameters.ApiVersion' cannot be null"
            );
        }
        if (parameters.ID == null)
        {
            throw new GeminiNextGenApiInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<InteractionGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var interaction = await response
                    .Deserialize<Interaction>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    interaction.Validate();
                }
                return interaction;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Interaction>> Get(
        string id,
        InteractionGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<StreamingHttpResponse<InteractionSseEvent>> GetStreaming(
        InteractionGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        parameters = parameters with
        {
            ApiVersion = parameters.ApiVersion ?? this._client.ApiVersion,
        };

        if (parameters.ApiVersion == null)
        {
            throw new GeminiNextGenApiInvalidDataException(
                "'parameters.ApiVersion' cannot be null"
            );
        }
        if (parameters.ID == null)
        {
            throw new GeminiNextGenApiInvalidDataException("'parameters.ID' cannot be null");
        }

        var rawQueryData = Enumerable.ToDictionary(
            parameters.RawQueryData,
            (e) => e.Key,
            (e) => e.Value
        );
        rawQueryData["stream"] = JsonSerializer.SerializeToElement(true);
        parameters = InteractionGetParams.FromRawUnchecked(
            parameters.RawHeaderData,
            rawQueryData,
            parameters.ApiVersion,
            parameters.ID
        );

        HttpRequest<InteractionGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);

        async IAsyncEnumerable<InteractionSseEvent> Enumerate(
            [EnumeratorCancellation] CancellationToken token
        )
        {
            await foreach (
                var interaction in Sse.Enumerate<InteractionSseEvent>(response.RawMessage, token)
            )
            {
                if (this._client.ResponseValidation)
                {
                    interaction.Validate();
                }
                yield return interaction;
            }
        }
        return new(response, Enumerate);
    }

    /// <inheritdoc/>
    public Task<StreamingHttpResponse<InteractionSseEvent>> GetStreaming(
        string id,
        InteractionGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetStreaming(parameters with { ID = id }, cancellationToken);
    }
}
