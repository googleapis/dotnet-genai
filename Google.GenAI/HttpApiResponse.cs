
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

using System.Net.Http.Headers;

namespace Google.GenAI
{
  /// <summary>
  /// Wraps a real HTTP response (HttpResponseMessage) to expose the methods needed by the GenAI SDK.
  /// </summary>
  public sealed class HttpApiResponse : ApiResponse
  {
    private readonly HttpResponseMessage _response;

    /// <summary>
    /// Constructs a HttpApiResponse instance with the HttpResponseMessage.
    /// </summary>
    /// <param name="response">The HTTP response message.</param>
    public HttpApiResponse(HttpResponseMessage response)
    {
      _response = response;
    }

    /// <summary>
    /// Returns the HttpContent from the response.
    /// </summary>
    public override HttpContent GetEntity()
    {
      return _response.Content;
    }

    /// <summary>
    /// Returns all of the headers from the response.
    /// </summary>
    public override HttpResponseHeaders GetHeaders()
    {
      return _response.Headers;
    }

    /// <summary>
    /// Disposes the underlying <see cref="HttpResponseMessage"/>.
    /// </summary>
    protected override void DisposeManagedResources()
    {
        _response?.Dispose();
    }
  }
}
