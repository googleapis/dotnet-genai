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
  /// The API response contains a response to a call to the GenAI APIs.
  /// This class is abstract and implements IDisposable for resource management.
  /// </summary>
  public abstract class ApiResponse : IDisposable, IAsyncDisposable
  {
    /// <summary>
    /// Gets the HTTP content of the response.
    /// </summary>
    public abstract HttpContent GetEntity();

    /// <summary>
    /// Gets the headers of the HTTP response.
    /// This uses the .NET standard HttpResponseHeaders collection.
    /// </summary>
    public abstract HttpResponseHeaders GetHeaders();

    private int _disposed = 0;

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="ApiResponse"/> and
    /// optionally releases the managed resources. Subclasses must override this method
    /// to provide their specific cleanup logic.
    /// </summary> /// <param name="disposing">true to release both managed and unmanaged
    /// resources; false to release only unmanaged resources.</param>
    protected void Dispose(bool disposing)
    {
        // This atomic check now happens FIRST, guaranteeing it runs only once.
        if (Interlocked.CompareExchange(ref _disposed, 1, 0) != 0)
        {
            return;
        }

        if (disposing)
        {
            // This is the new "hook" for derived classes.
            DisposeManagedResources();
        }
    }
    protected virtual void DisposeManagedResources() { }

    /// <summary>
    /// Asynchronously disposes the response.
    /// </summary>
    /// <returns>A <see cref="ValueTask"/> that represents the asynchronous dispose operation.</returns>
    public virtual ValueTask DisposeAsync()
    {
        Dispose();
        return ValueTask.CompletedTask;
    }
  }
}
