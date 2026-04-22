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

using System.Net.Http;

namespace Google.GenAI.Interactions.Core;

public sealed class HttpRequest<P>
    where P : ParamsBase
{
    public HttpMethod Method { get; init; } = null!;

    public P Params { get; init; } = null!;

    public override string ToString() =>
        string.Format("Method: {0}\n{1}", this.Method.ToString(), this.Params.ToString());

    public override bool Equals(object? obj)
    {
        if (obj is not HttpRequest<P> other)
        {
            return false;
        }

        return this.Method.Equals(other.Method) && this.Params.Equals(other.Params);
    }

    public override int GetHashCode() => 0;
}
