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
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Models.Interactions;

namespace Google.GenAI.Interactions.Services;

/// <summary>
/// The interactions service is experimental.
/// 
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInteractionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInteractionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInteractionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new interaction.
    /// </summary>
    Task<Interaction> Create(
        InteractionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new interaction.
    /// </summary>
    IAsyncEnumerable<InteractionSseEvent> CreateStreaming(
        InteractionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes the interaction by id.
    /// </summary>
    Task<JsonElement> Delete(
        InteractionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(InteractionDeleteParams, CancellationToken)"/>
    Task<JsonElement> Delete(
        string id,
        InteractionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels an interaction by id. This only applies to background interactions that
    /// are still running.
    /// </summary>
    Task<Interaction> Cancel(
        InteractionCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(InteractionCancelParams, CancellationToken)"/>
    Task<Interaction> Cancel(
        string id,
        InteractionCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the full details of a single interaction based on its
    /// `Interaction.id`.
    /// </summary>
    Task<Interaction> Get(
        InteractionGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(InteractionGetParams, CancellationToken)"/>
    Task<Interaction> Get(
        string id,
        InteractionGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves the full details of a single interaction based on its
    /// `Interaction.id`.
    /// </summary>
    IAsyncEnumerable<InteractionSseEvent> GetStreaming(
        InteractionGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStreaming(InteractionGetParams, CancellationToken)"/>
    IAsyncEnumerable<InteractionSseEvent> GetStreaming(
        string id,
        InteractionGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IInteractionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInteractionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInteractionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /{api_version}/interactions</c>, but is otherwise the
    /// same as <see cref="IInteractionService.Create(InteractionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Interaction>> Create(
        InteractionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /{api_version}/interactions</c>, but is otherwise the
    /// same as <see cref="IInteractionService.CreateStreaming(InteractionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<StreamingHttpResponse<InteractionSseEvent>> CreateStreaming(
        InteractionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /{api_version}/interactions/{id}</c>, but is otherwise the
    /// same as <see cref="IInteractionService.Delete(InteractionDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JsonElement>> Delete(
        InteractionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(InteractionDeleteParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> Delete(
        string id,
        InteractionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /{api_version}/interactions/{id}/cancel</c>, but is otherwise the
    /// same as <see cref="IInteractionService.Cancel(InteractionCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Interaction>> Cancel(
        InteractionCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(InteractionCancelParams, CancellationToken)"/>
    Task<HttpResponse<Interaction>> Cancel(
        string id,
        InteractionCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /{api_version}/interactions/{id}</c>, but is otherwise the
    /// same as <see cref="IInteractionService.Get(InteractionGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Interaction>> Get(
        InteractionGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(InteractionGetParams, CancellationToken)"/>
    Task<HttpResponse<Interaction>> Get(
        string id,
        InteractionGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /{api_version}/interactions/{id}</c>, but is otherwise the
    /// same as <see cref="IInteractionService.GetStreaming(InteractionGetParams, CancellationToken)"/>.
    /// </summary>
    Task<StreamingHttpResponse<InteractionSseEvent>> GetStreaming(
        InteractionGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStreaming(InteractionGetParams, CancellationToken)"/>
    Task<StreamingHttpResponse<InteractionSseEvent>> GetStreaming(
        string id,
        InteractionGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
