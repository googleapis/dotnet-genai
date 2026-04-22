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

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// The result of the Google Search.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<InteractionGoogleSearchResult, InteractionGoogleSearchResultFromRaw>)
)]
public sealed record class InteractionGoogleSearchResult : JsonModel
{
    /// <summary>
    /// Web content snippet that can be embedded in a web page or an app webview.
    /// </summary>
    public string? SearchSuggestions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("search_suggestions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("search_suggestions", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SearchSuggestions;
    }

    public InteractionGoogleSearchResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InteractionGoogleSearchResult(
        InteractionGoogleSearchResult interactionGoogleSearchResult
    )
        : base(interactionGoogleSearchResult) { }
#pragma warning restore CS8618

    public InteractionGoogleSearchResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InteractionGoogleSearchResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InteractionGoogleSearchResultFromRaw.FromRawUnchecked"/>
    public static InteractionGoogleSearchResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InteractionGoogleSearchResultFromRaw : IFromRawJson<InteractionGoogleSearchResult>
{
    /// <inheritdoc/>
    public InteractionGoogleSearchResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InteractionGoogleSearchResult.FromRawUnchecked(rawData);
}
