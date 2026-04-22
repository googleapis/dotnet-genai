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

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// The result of the Google Maps.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<InteractionGoogleMapsResult, InteractionGoogleMapsResultFromRaw>)
)]
public sealed record class InteractionGoogleMapsResult : JsonModel
{
    /// <summary>
    /// The places that were found.
    /// </summary>
    public IReadOnlyList<Place>? Places
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Place>>("places");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Place>?>(
                "places",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Resource name of the Google Maps widget context token.
    /// </summary>
    public string? WidgetContextToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("widget_context_token");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("widget_context_token", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Places ?? Enumerable.Empty<Place>())
        {
            item.Validate();
        }
        _ = this.WidgetContextToken;
    }

    public InteractionGoogleMapsResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InteractionGoogleMapsResult(InteractionGoogleMapsResult interactionGoogleMapsResult)
        : base(interactionGoogleMapsResult) { }
#pragma warning restore CS8618

    public InteractionGoogleMapsResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InteractionGoogleMapsResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InteractionGoogleMapsResultFromRaw.FromRawUnchecked"/>
    public static InteractionGoogleMapsResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InteractionGoogleMapsResultFromRaw : IFromRawJson<InteractionGoogleMapsResult>
{
    /// <inheritdoc/>
    public InteractionGoogleMapsResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InteractionGoogleMapsResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Place, PlaceFromRaw>))]
public sealed record class Place : JsonModel
{
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
    public IReadOnlyList<ReviewSnippet>? ReviewSnippets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ReviewSnippet>>(
                "review_snippets"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ReviewSnippet>?>(
                "review_snippets",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
        _ = this.Name;
        _ = this.PlaceID;
        foreach (var item in this.ReviewSnippets ?? Enumerable.Empty<ReviewSnippet>())
        {
            item.Validate();
        }
        _ = this.Url;
    }

    public Place() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Place(Place place)
        : base(place) { }
#pragma warning restore CS8618

    public Place(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Place(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlaceFromRaw.FromRawUnchecked"/>
    public static Place FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlaceFromRaw : IFromRawJson<Place>
{
    /// <inheritdoc/>
    public Place FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Place.FromRawUnchecked(rawData);
}

/// <summary>
/// Encapsulates a snippet of a user review that answers a question about the features
/// of a specific place in Google Maps.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReviewSnippet, ReviewSnippetFromRaw>))]
public sealed record class ReviewSnippet : JsonModel
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

    public ReviewSnippet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReviewSnippet(ReviewSnippet reviewSnippet)
        : base(reviewSnippet) { }
#pragma warning restore CS8618

    public ReviewSnippet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReviewSnippet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReviewSnippetFromRaw.FromRawUnchecked"/>
    public static ReviewSnippet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReviewSnippetFromRaw : IFromRawJson<ReviewSnippet>
{
    /// <inheritdoc/>
    public ReviewSnippet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReviewSnippet.FromRawUnchecked(rawData);
}
