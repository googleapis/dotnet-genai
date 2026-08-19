// Copyright 2026 Google LLC
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

#nullable enable
namespace Google.GenAI.Gaos.Hooks
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Google.GenAI.Gaos.Models.Components;

    public class GoogleGenAIAuthHook : IBeforeRequestHook
    {
        private const string GOOGLE_GENAI_API_REVISION = "2026-05-20";

        public Task<HttpRequestMessage> BeforeRequestAsync(BeforeRequestContext hookCtx, HttpRequestMessage request)
        {
            Security? security = null;
            if (hookCtx.SecuritySource != null)
            {
                var secObj = hookCtx.SecuritySource();
                if (secObj is Security s)
                {
                    security = s;
                }
            }

            if (security != null)
            {
                ApplyDefaultHeaders(request, security.DefaultHeaders);
            }

            ApplyApiRevision(hookCtx, request);
            ApplyUserProject(hookCtx, request);

            if (HasAuthHeaders(request))
            {
                return Task.FromResult(request);
            }

            if (security != null)
            {
                ApplyAuth(request, security);
            }

            return Task.FromResult(request);
        }

        private void ApplyDefaultHeaders(HttpRequestMessage request, Dictionary<string, string>? defaultHeaders)
        {
            if (defaultHeaders == null) return;
            foreach (var kvp in defaultHeaders)
            {
                if (!request.Headers.Contains(kvp.Key))
                {
                    request.Headers.TryAddWithoutValidation(kvp.Key, kvp.Value);
                }
            }
        }

        private void ApplyApiRevision(BeforeRequestContext hookCtx, HttpRequestMessage request)
        {
            if (!request.Headers.Contains("Api-Revision"))
            {
                var apiRevision = GOOGLE_GENAI_API_REVISION;
                request.Headers.TryAddWithoutValidation("Api-Revision", apiRevision);
            }
        }

        private void ApplyUserProject(BeforeRequestContext hookCtx, HttpRequestMessage request)
        {
            if (!request.Headers.Contains("x-goog-user-project") && !string.IsNullOrEmpty(hookCtx.SDKConfiguration.UserProject))
            {
                request.Headers.TryAddWithoutValidation("x-goog-user-project", hookCtx.SDKConfiguration.UserProject);
            }
        }

        private bool HasAuthHeaders(HttpRequestMessage request)
        {
            return request.Headers.Contains("Authorization") || request.Headers.Contains("x-goog-api-key");
        }

        private void ApplyAuth(HttpRequestMessage request, Security security)
        {
            if (!string.IsNullOrEmpty(security.ApiKey))
            {
                request.Headers.TryAddWithoutValidation("x-goog-api-key", security.ApiKey);
                return;
            }

            if (!string.IsNullOrEmpty(security.AccessToken))
            {
                var token = security.AccessToken;
                if (!token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    token = "Bearer " + token;
                }
                request.Headers.TryAddWithoutValidation("Authorization", token);
            }
        }
    }
}
