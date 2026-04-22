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
using System.Threading;
using System.Threading.Tasks;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Core;

/// <summary>
/// An interface representing a single page, with items of type <typeparamref name="T"/>, from a
/// paginated endpoint response.
/// </summary>
public interface IPage<T>
{
    /// <summary>
    /// The items in this page.
    /// </summary>
    IReadOnlyList<T> Items { get; }

    /// <summary>
    /// Returns whether there's another page after this one.
    ///
    /// <para>The method doesn't make requests so the result depends entirely on the
    /// data in this page. If a significant amount of time has passed between requesting
    /// this page and calling this method, then the result could be stale.</para>
    /// </summary>
    bool HasNext();

    /// <summary>
    /// Returns the page after this one by making another request.
    ///
    /// <exception cref="GeminiNextGenApiInvalidDataException">
    /// Thrown when it's impossible to get the next page. This exception is avoidable by calling
    /// <see cref="HasNext"/> first.
    /// </exception>
    /// </summary>
    Task<IPage<T>> Next(CancellationToken cancellationToken = default);

    /// <summary>
    /// Validates that the page was constructed with a valid response (based on its own
    /// <c>Validate</c> method).
    ///
    /// <exception cref="GeminiNextGenApiInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    void Validate();

#if NET
    /// <inheritdoc cref="IPageExtensions.Paginate"/>
    public IAsyncEnumerable<T> Paginate(CancellationToken cancellationToken = default) =>
        IPageExtensions.Paginate(this, cancellationToken);
#endif
}
