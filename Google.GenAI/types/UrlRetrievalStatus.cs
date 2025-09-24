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

// Auto-generated code. Do not edit.

using System.Text.Json.Serialization;

namespace Google.GenAI.Types {
  /// <summary>
  /// Status of the url retrieval.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<UrlRetrievalStatus>))]
  public enum UrlRetrievalStatus {
    /// <summary>
    /// Default value. This value is unused
    /// </summary>
    [JsonPropertyName("URL_RETRIEVAL_STATUS_UNSPECIFIED")] URL_RETRIEVAL_STATUS_UNSPECIFIED,

    /// <summary>
    /// Url retrieval is successful.
    /// </summary>
    [JsonPropertyName("URL_RETRIEVAL_STATUS_SUCCESS")] URL_RETRIEVAL_STATUS_SUCCESS,

    /// <summary>
    /// Url retrieval is failed due to error.
    /// </summary>
    [JsonPropertyName("URL_RETRIEVAL_STATUS_ERROR")] URL_RETRIEVAL_STATUS_ERROR,

    /// <summary>
    /// Url retrieval is failed because the content is behind paywall.
    /// </summary>
    [JsonPropertyName("URL_RETRIEVAL_STATUS_PAYWALL")] URL_RETRIEVAL_STATUS_PAYWALL,

    /// <summary>
    /// Url retrieval is failed because the content is unsafe.
    /// </summary>
    [JsonPropertyName("URL_RETRIEVAL_STATUS_UNSAFE")] URL_RETRIEVAL_STATUS_UNSAFE
  }
}
