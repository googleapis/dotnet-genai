// Copyright 2026 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#if !NETSTANDARD2_0

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Google.GenAI
{
    internal sealed class GaosHttpClient : Google.GenAI.Gaos.Utils.IGenAIHttpClient
    {
        private readonly HttpClient _httpClient;

        public GaosHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null)
        {
            if (request.RequestUri != null)
            {
                var uriBuilder = new UriBuilder(request.RequestUri);
                uriBuilder.Path = Uri.UnescapeDataString(uriBuilder.Path);
                request.RequestUri = uriBuilder.Uri;
            }
            return _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken ?? CancellationToken.None);
        }

        public async Task<HttpRequestMessage> CloneAsync(HttpRequestMessage request)
        {
            HttpRequestMessage clone = new HttpRequestMessage(request.Method, request.RequestUri);

            if (request.Content != null)
            {
                clone.Content = new ByteArrayContent(await request.Content.ReadAsByteArrayAsync());
                if (request.Content.Headers != null)
                {
                    foreach (var h in request.Content.Headers)
                    {
                        clone.Content.Headers.Add(h.Key, h.Value);
                    }
                }
            }

            foreach (KeyValuePair<string, IEnumerable<string>> header in request.Headers)
            {
                clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            foreach (KeyValuePair<string, object?> prop in request.Options)
            {
                clone.Options.TryAdd(prop.Key, prop.Value);
            }

            return clone;
        }
    }
}

#endif
