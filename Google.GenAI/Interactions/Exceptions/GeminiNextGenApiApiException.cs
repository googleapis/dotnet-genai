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
using System.Net;
using System.Net.Http;

namespace Google.GenAI.Interactions.Exceptions;

public class GeminiNextGenApiApiException : GeminiNextGenApiException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public GeminiNextGenApiApiException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }

    protected GeminiNextGenApiApiException(HttpRequestException? innerException)
        : base(innerException) { }

    public HttpStatusCode StatusCode { get; init; } = default;

    public string ResponseBody { get; init; } = null!;

    public override string Message
    {
        get { return string.Format("Status Code: {0}\n{1}", StatusCode, ResponseBody); }
    }
}
