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
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// URL context result content.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UrlContextResultContent, UrlContextResultContentFromRaw>))]
public sealed record class UrlContextResultContent : JsonModel
{
    /// <summary>
    /// Required. ID to match the ID from the function call block.
    /// </summary>
    public string CallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("call_id");
        }
        init { this._rawData.Set("call_id", value); }
    }

    /// <summary>
    /// Required. The results of the URL context.
    /// </summary>
    public IReadOnlyList<InteractionUrlContextResult> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InteractionUrlContextResult>>(
                "result"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<InteractionUrlContextResult>>(
                "result",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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
    /// Whether the URL context resulted in an error.
    /// </summary>
    public bool? IsError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_error", value);
        }
    }

    /// <summary>
    /// A signature hash for backend validation.
    /// </summary>
    public string? Signature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("signature");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("signature", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallID;
        foreach (var item in this.Result)
        {
            item.Validate();
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("url_context_result")
            )
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.IsError;
        _ = this.Signature;
    }

    public UrlContextResultContent()
    {
        this.Type = JsonSerializer.SerializeToElement("url_context_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UrlContextResultContent(UrlContextResultContent urlContextResultContent)
        : base(urlContextResultContent) { }
#pragma warning restore CS8618

    public UrlContextResultContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("url_context_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UrlContextResultContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UrlContextResultContentFromRaw.FromRawUnchecked"/>
    public static UrlContextResultContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UrlContextResultContentFromRaw : IFromRawJson<UrlContextResultContent>
{
    /// <inheritdoc/>
    public UrlContextResultContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UrlContextResultContent.FromRawUnchecked(rawData);
}
