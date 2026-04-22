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

using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// A URL citation annotation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UrlCitation, UrlCitationFromRaw>))]
public sealed record class UrlCitation : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// End of the attributed segment, exclusive.
    /// </summary>
    public int? EndIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("end_index");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("end_index", value);
        }
    }

    /// <summary>
    /// Start of segment of the response that is attributed to this source.
    ///
    /// <para>Index indicates the start of the segment, measured in bytes.</para>
    /// </summary>
    public int? StartIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("start_index");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("start_index", value);
        }
    }

    /// <summary>
    /// The title of the URL.
    /// </summary>
    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("title", value);
        }
    }

    /// <summary>
    /// The URL.
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("url_citation")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.EndIndex;
        _ = this.StartIndex;
        _ = this.Title;
        _ = this.Url;
    }

    public UrlCitation()
    {
        this.Type = JsonSerializer.SerializeToElement("url_citation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UrlCitation(UrlCitation urlCitation)
        : base(urlCitation) { }
#pragma warning restore CS8618

    public UrlCitation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("url_citation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UrlCitation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UrlCitationFromRaw.FromRawUnchecked"/>
    public static UrlCitation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UrlCitationFromRaw : IFromRawJson<UrlCitation>
{
    /// <inheritdoc/>
    public UrlCitation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UrlCitation.FromRawUnchecked(rawData);
}
