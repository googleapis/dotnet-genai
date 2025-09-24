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
using System.Text;

namespace Google.GenAI
{
  public class StreamingApiResponse : ApiResponse
  {
    private readonly string _jsonContent;
    private readonly HttpResponseMessage _originalResponse;

    public StreamingApiResponse(string jsonContent, HttpResponseMessage originalResponse)
    {
      _jsonContent = jsonContent ?? throw new ArgumentNullException(nameof(jsonContent));
      _originalResponse = originalResponse ?? throw new ArgumentNullException(nameof(originalResponse));
    }

    public override HttpContent GetEntity()
    {
      return new StringContent(_jsonContent, Encoding.UTF8, "application/json");
    }

    public string GetJsonContent() => _jsonContent;

    /// <summary>
    /// Gets the HTTP response headers from the original response.
    /// </summary>
    /// <returns>The HTTP response headers.</returns>
    public override HttpResponseHeaders GetHeaders()
    {
      return _originalResponse.Headers;
    }
  }
}
