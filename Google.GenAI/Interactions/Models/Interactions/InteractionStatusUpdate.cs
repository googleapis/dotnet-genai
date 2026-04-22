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

[JsonConverter(typeof(JsonModelConverter<InteractionStatusUpdate, InteractionStatusUpdateFromRaw>))]
public sealed record class InteractionStatusUpdate : JsonModel
{
    public JsonElement EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("event_type");
        }
        init { this._rawData.Set("event_type", value); }
    }

    public string InteractionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("interaction_id");
        }
        init { this._rawData.Set("interaction_id", value); }
    }

    public ApiEnum<string, InteractionStatusUpdateStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InteractionStatusUpdateStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The event_id token to be used to resume the interaction stream, from this event.
    /// </summary>
    public string? EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("event_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("event_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.EventType,
                JsonSerializer.SerializeToElement("interaction.status_update")
            )
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.InteractionID;
        this.Status.Validate();
        _ = this.EventID;
    }

    public InteractionStatusUpdate()
    {
        this.EventType = JsonSerializer.SerializeToElement("interaction.status_update");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InteractionStatusUpdate(InteractionStatusUpdate interactionStatusUpdate)
        : base(interactionStatusUpdate) { }
#pragma warning restore CS8618

    public InteractionStatusUpdate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.EventType = JsonSerializer.SerializeToElement("interaction.status_update");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InteractionStatusUpdate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InteractionStatusUpdateFromRaw.FromRawUnchecked"/>
    public static InteractionStatusUpdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InteractionStatusUpdateFromRaw : IFromRawJson<InteractionStatusUpdate>
{
    /// <inheritdoc/>
    public InteractionStatusUpdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InteractionStatusUpdate.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(InteractionStatusUpdateStatusConverter))]
public enum InteractionStatusUpdateStatus
{
    InProgress,
    RequiresAction,
    Completed,
    Failed,
    Cancelled,
    Incomplete,
}

sealed class InteractionStatusUpdateStatusConverter : JsonConverter<InteractionStatusUpdateStatus>
{
    public override InteractionStatusUpdateStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in_progress" => InteractionStatusUpdateStatus.InProgress,
            "requires_action" => InteractionStatusUpdateStatus.RequiresAction,
            "completed" => InteractionStatusUpdateStatus.Completed,
            "failed" => InteractionStatusUpdateStatus.Failed,
            "cancelled" => InteractionStatusUpdateStatus.Cancelled,
            "incomplete" => InteractionStatusUpdateStatus.Incomplete,
            _ => (InteractionStatusUpdateStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InteractionStatusUpdateStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InteractionStatusUpdateStatus.InProgress => "in_progress",
                InteractionStatusUpdateStatus.RequiresAction => "requires_action",
                InteractionStatusUpdateStatus.Completed => "completed",
                InteractionStatusUpdateStatus.Failed => "failed",
                InteractionStatusUpdateStatus.Cancelled => "cancelled",
                InteractionStatusUpdateStatus.Incomplete => "incomplete",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
