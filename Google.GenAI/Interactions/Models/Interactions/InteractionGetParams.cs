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

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Google.GenAI.Interactions.Core;

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// Retrieves the full details of a single interaction based on its `Interaction.id`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InteractionGetParams : ParamsBase
{
    public string? ApiVersion { get; init; }

    public string? ID { get; init; }

    /// <summary>
    /// If set to true, includes the input in the response.
    /// </summary>
    public bool? IncludeInput
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("include_input");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("include_input", value);
        }
    }

    /// <summary>
    /// Optional. If set, resumes the interaction stream from the next chunk after
    /// the event marked by the event id. Can only be used if `stream` is true.
    /// </summary>
    public string? LastEventID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("last_event_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("last_event_id", value);
        }
    }

    public InteractionGetParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InteractionGetParams(InteractionGetParams interactionGetParams)
        : base(interactionGetParams)
    {
        this.ApiVersion = interactionGetParams.ApiVersion;
        this.ID = interactionGetParams.ID;
    }
#pragma warning restore CS8618

    public InteractionGetParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InteractionGetParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string apiVersion,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ApiVersion = apiVersion;
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InteractionGetParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string apiVersion,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            apiVersion,
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ApiVersion"] = JsonSerializer.SerializeToElement(this.ApiVersion),
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(InteractionGetParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ApiVersion?.Equals(other.ApiVersion) ?? other.ApiVersion == null)
            && (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/{0}/interactions/{1}", this.ApiVersion, this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
