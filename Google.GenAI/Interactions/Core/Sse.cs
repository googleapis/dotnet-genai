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

using System.Collections.Generic;
using System.Net.Http;
using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Core;

static class Sse
{
    internal static async IAsyncEnumerable<T> Enumerate<T>(
        HttpResponseMessage response,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        using var stream = await response
            .Content.ReadAsStreamAsync(
#if NET
                cancellationToken
#endif
            )
            .ConfigureAwait(false);

        var done = false;
        await foreach (var item in SseParser.Create(stream).EnumerateAsync(cancellationToken))
        {
            // Stop emitting messages, but iterate through the full stream.
            if (done)
            {
                continue;
            }

            if (item.Data.StartsWith("[DONE]"))
            {
                // In this case we don't break because we still want to iterate through the full stream.
                done = true;
                continue;
            }

            T? message;
            try
            {
                message = JsonSerializer.Deserialize<T>(item.Data, ModelBase.SerializerOptions);
            }
            catch (JsonException e)
            {
                throw new GeminiNextGenApiInvalidDataException(
                    $"Message must be of type {typeof(T).FullName}",
                    e
                );
            }
            yield return message
                ?? throw new GeminiNextGenApiInvalidDataException("Message cannot be null");
        }
    }
}
