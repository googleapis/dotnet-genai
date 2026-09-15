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

using System;

namespace Google.GenAI
{
  /// <summary>
  /// Base exception for API errors. Root of the unified error hierarchy: both the
  /// native <see cref="ClientError"/>/<see cref="ServerError"/> tree (model calls)
  /// and the embedded gaos error tree derive from it, so a single
  /// <c>catch (ApiException)</c> covers every API error.
  /// </summary>
  public class ApiException : System.Net.Http.HttpRequestException
  {
    public int StatusCode { get; }
    public string? Status { get; }

    public ApiException(string message, Exception? innerException = null) : base(message, innerException)
    {
    }

    public ApiException(string message, int statusCode, string? status = null, Exception? innerException = null) : base(message, innerException)
    {
      StatusCode = statusCode;
      Status = status;
    }
  }
}
