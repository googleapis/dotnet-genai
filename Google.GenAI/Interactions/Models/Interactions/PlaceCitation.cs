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
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// A place citation annotation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PlaceCitation, PlaceCitationFromRaw>))]
public sealed record class PlaceCitation : JsonModel
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
    /// Title of the place.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// The ID of the place, in `places/{place_id}` format.
    /// </summary>
    public string? PlaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("place_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("place_id", value);
        }
    }

    /// <summary>
    /// Snippets of reviews that are used to generate answers about the features
    /// of a given place in Google Maps.
    /// </summary>
    public IReadOnlyList<PlaceCitationReviewSnippet>? ReviewSnippets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PlaceCitationReviewSnippet>>(
                "review_snippets"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<PlaceCitationReviewSnippet>?>(
                "review_snippets",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
    /// URI reference of the place.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("place_citation")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.EndIndex;
        _ = this.Name;
        _ = this.PlaceID;
        foreach (var item in this.ReviewSnippets ?? Enumerable.Empty<PlaceCitationReviewSnippet>())
        {
            item.Validate();
        }
        _ = this.StartIndex;
        _ = this.Url;
    }

    public PlaceCitation()
    {
        this.Type = JsonSerializer.SerializeToElement("place_citation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlaceCitation(PlaceCitation placeCitation)
        : base(placeCitation) { }
#pragma warning restore CS8618

    public PlaceCitation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("place_citation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlaceCitation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlaceCitationFromRaw.FromRawUnchecked"/>
    public static PlaceCitation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlaceCitationFromRaw : IFromRawJson<PlaceCitation>
{
    /// <inheritdoc/>
    public PlaceCitation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PlaceCitation.FromRawUnchecked(rawData);
}

/// <summary>
/// Encapsulates a snippet of a user review that answers a question about the features
/// of a specific place in Google Maps.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PlaceCitationReviewSnippet, PlaceCitationReviewSnippetFromRaw>)
)]
public sealed record class PlaceCitationReviewSnippet : JsonModel
{
    /// <summary>
    /// The ID of the review snippet.
    /// </summary>
    public string? ReviewID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("review_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("review_id", value);
        }
    }

    /// <summary>
    /// Title of the review.
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
    /// A link that corresponds to the user review on Google Maps.
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
        _ = this.ReviewID;
        _ = this.Title;
        _ = this.Url;
    }

    public PlaceCitationReviewSnippet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlaceCitationReviewSnippet(PlaceCitationReviewSnippet placeCitationReviewSnippet)
        : base(placeCitationReviewSnippet) { }
#pragma warning restore CS8618

    public PlaceCitationReviewSnippet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlaceCitationReviewSnippet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlaceCitationReviewSnippetFromRaw.FromRawUnchecked"/>
    public static PlaceCitationReviewSnippet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlaceCitationReviewSnippetFromRaw : IFromRawJson<PlaceCitationReviewSnippet>
{
    /// <inheritdoc/>
    public PlaceCitationReviewSnippet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlaceCitationReviewSnippet.FromRawUnchecked(rawData);
}
