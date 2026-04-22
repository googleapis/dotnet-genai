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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using Google.GenAI.Interactions.Exceptions;
using Threading = System.Threading;

namespace Google.GenAI.Interactions.Core;

public class HttpResponse : IDisposable
{
    public HttpResponseMessage RawMessage { get; init; } = null!;

    public IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers
    {
        get { return RawMessage.Headers; }
    }

    public bool IsSuccessStatusCode
    {
        get { return RawMessage.IsSuccessStatusCode; }
    }

    public HttpStatusCode StatusCode
    {
        get { return RawMessage.StatusCode; }
    }

    public Threading::CancellationToken CancellationToken { get; init; } = default;

    public IEnumerable<string> GetHeaderValues(string name) => RawMessage.Headers.GetValues(name);

    public bool TryGetHeaderValues(
        string name,
        [NotNullWhen(true)] out IEnumerable<string>? values
    ) => RawMessage.Headers.TryGetValues(name, out values);

    public sealed override string ToString() => this.RawMessage.ToString();

    public override bool Equals(object? obj)
    {
        if (obj is not HttpResponse other)
        {
            return false;
        }

        return this.RawMessage.Equals(other.RawMessage);
    }

    public override int GetHashCode() => this.RawMessage.GetHashCode();

    public async Task<T> Deserialize<T>(Threading::CancellationToken cancellationToken = default)
    {
        using var cts = Threading::CancellationTokenSource.CreateLinkedTokenSource(
            this.CancellationToken,
            cancellationToken
        );
        try
        {
            return await JsonSerializer
                    .DeserializeAsync<T>(
                        await this.ReadAsStream(cts.Token).ConfigureAwait(false),
                        ModelBase.SerializerOptions,
                        cts.Token
                    )
                    .ConfigureAwait(false)
                ?? throw new GeminiNextGenApiInvalidDataException("Response cannot be null");
        }
        catch (HttpRequestException e)
        {
            throw new GeminiNextGenApiIOException("I/O Exception", e);
        }
    }

    public async Task<Stream> ReadAsStream(Threading::CancellationToken cancellationToken = default)
    {
        using var cts = Threading::CancellationTokenSource.CreateLinkedTokenSource(
            this.CancellationToken,
            cancellationToken
        );
        return await RawMessage.Content.ReadAsStreamAsync(
#if NET
            cts.Token
#endif
        ).ConfigureAwait(false);
    }

    public async Task<string> ReadAsString(Threading::CancellationToken cancellationToken = default)
    {
        using var cts = Threading::CancellationTokenSource.CreateLinkedTokenSource(
            this.CancellationToken,
            cancellationToken
        );
        return await RawMessage.Content.ReadAsStringAsync(
#if NET
            cts.Token
#endif
        ).ConfigureAwait(false);
    }

    public void Dispose()
    {
        this.RawMessage.Dispose();
        GC.SuppressFinalize(this);
    }
}

public sealed class HttpResponse<T> : HttpResponse
{
    readonly Func<Threading::CancellationToken, Task<T>> _deserialize;

    internal HttpResponse(Func<Threading::CancellationToken, Task<T>> deserialize)
    {
        this._deserialize = deserialize;
    }

    [SetsRequiredMembers]
    internal HttpResponse(
        HttpResponse response,
        Func<Threading::CancellationToken, Task<T>> deserialize
    )
        : this(deserialize)
    {
        this.RawMessage = response.RawMessage;
        this.CancellationToken = response.CancellationToken;
    }

    public Task<T> Deserialize(Threading::CancellationToken cancellationToken = default)
    {
        using var cts = Threading::CancellationTokenSource.CreateLinkedTokenSource(
            this.CancellationToken,
            cancellationToken
        );
        return this._deserialize(cts.Token);
    }
}

public sealed class StreamingHttpResponse<T> : HttpResponse
{
    readonly Func<Threading::CancellationToken, IAsyncEnumerable<T>> _enumerate;

    internal StreamingHttpResponse(
        Func<Threading::CancellationToken, IAsyncEnumerable<T>> enumerate
    )
    {
        this._enumerate = enumerate;
    }

    [SetsRequiredMembers]
    internal StreamingHttpResponse(
        HttpResponse response,
        Func<Threading::CancellationToken, IAsyncEnumerable<T>> enumerate
    )
        : this(enumerate)
    {
        this.RawMessage = response.RawMessage;
        this.CancellationToken = response.CancellationToken;
    }

    public async IAsyncEnumerable<T> Enumerate(
        [EnumeratorCancellationAttribute] Threading::CancellationToken cancellationToken = default
    )
    {
        using var cts = Threading::CancellationTokenSource.CreateLinkedTokenSource(
            this.CancellationToken,
            cancellationToken
        );
        await foreach (var item in this._enumerate(cts.Token))
        {
            yield return item;
        }
    }
}
