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

namespace Google.GenAI.Interactions.Core;

/// <summary>
/// The base class for all API objects that are serialized as a mix of JSON objects
/// and binary content.
///
/// <para>API objects such as enums and unions do not inherit from this class.</para>
/// </summary>
public abstract record class MultipartJsonModel : ModelBase
{
    private protected MultipartJsonDictionary _rawData = new();

    protected MultipartJsonModel(MultipartJsonModel jsonModel)
        : base(jsonModel)
    {
        this._rawData = new(jsonModel._rawData);
    }

    /// <summary>
    /// The backing mix of JSON and binary content properties of the instance.
    /// </summary>
    public IReadOnlyDictionary<string, MultipartJsonElement> RawData
    {
        get { return this._rawData.Freeze(); }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
///
/// <para>NOTE: This interface is in the style of a factory instance instead of using
/// abstract static methods because .NET Standard 2.0 doesn't support abstract static methods.</para>
/// </summary>
interface IFromRawMultipartJson<T>
{
    /// <summary>
    /// Returns an instance constructed from the given raw JSON properties.
    ///
    /// <para>Required field and type mismatches are not checked. In these cases accessing
    /// the relevant properties of the constructed instance may throw.</para>
    ///
    /// <para>This method is useful for constructing an instance from already serialized
    /// data or for sending arbitrary data to the API (e.g. for undocumented or not
    /// yet supported properties or values).</para>
    /// </summary>
    T FromRawUnchecked(IReadOnlyDictionary<string, MultipartJsonElement> rawData);
}
