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
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// The result of the URL context.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<InteractionUrlContextResult, InteractionUrlContextResultFromRaw>)
)]
public sealed record class InteractionUrlContextResult : JsonModel
{
    /// <summary>
    /// The status of the URL retrieval.
    /// </summary>
    public ApiEnum<string, InteractionUrlContextResultStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, InteractionUrlContextResultStatus>
            >("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// The URL that was fetched.
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
        this.Status?.Validate();
        _ = this.Url;
    }

    public InteractionUrlContextResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InteractionUrlContextResult(InteractionUrlContextResult interactionUrlContextResult)
        : base(interactionUrlContextResult) { }
#pragma warning restore CS8618

    public InteractionUrlContextResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InteractionUrlContextResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InteractionUrlContextResultFromRaw.FromRawUnchecked"/>
    public static InteractionUrlContextResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InteractionUrlContextResultFromRaw : IFromRawJson<InteractionUrlContextResult>
{
    /// <inheritdoc/>
    public InteractionUrlContextResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InteractionUrlContextResult.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the URL retrieval.
/// </summary>
[JsonConverter(typeof(InteractionUrlContextResultStatusConverter))]
public enum InteractionUrlContextResultStatus
{
    Success,
    Error,
    Paywall,
    Unsafe,
}

sealed class InteractionUrlContextResultStatusConverter
    : JsonConverter<InteractionUrlContextResultStatus>
{
    public override InteractionUrlContextResultStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => InteractionUrlContextResultStatus.Success,
            "error" => InteractionUrlContextResultStatus.Error,
            "paywall" => InteractionUrlContextResultStatus.Paywall,
            "unsafe" => InteractionUrlContextResultStatus.Unsafe,
            _ => (InteractionUrlContextResultStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InteractionUrlContextResultStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InteractionUrlContextResultStatus.Success => "success",
                InteractionUrlContextResultStatus.Error => "error",
                InteractionUrlContextResultStatus.Paywall => "paywall",
                InteractionUrlContextResultStatus.Unsafe => "unsafe",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
