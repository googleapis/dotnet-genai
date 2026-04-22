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

[JsonConverter(
    typeof(JsonModelConverter<InteractionCompleteEvent, InteractionCompleteEventFromRaw>)
)]
public sealed record class InteractionCompleteEvent : JsonModel
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

    /// <summary>
    /// Required. The completed interaction with empty outputs to reduce the payload
    /// size. Use the preceding ContentDelta events for the actual output.
    /// </summary>
    public Interaction Interaction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Interaction>("interaction");
        }
        init { this._rawData.Set("interaction", value); }
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
                JsonSerializer.SerializeToElement("interaction.complete")
            )
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        this.Interaction.Validate();
        _ = this.EventID;
    }

    public InteractionCompleteEvent()
    {
        this.EventType = JsonSerializer.SerializeToElement("interaction.complete");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InteractionCompleteEvent(InteractionCompleteEvent interactionCompleteEvent)
        : base(interactionCompleteEvent) { }
#pragma warning restore CS8618

    public InteractionCompleteEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.EventType = JsonSerializer.SerializeToElement("interaction.complete");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InteractionCompleteEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InteractionCompleteEventFromRaw.FromRawUnchecked"/>
    public static InteractionCompleteEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InteractionCompleteEvent(Interaction interaction)
        : this()
    {
        this.Interaction = interaction;
    }
}

class InteractionCompleteEventFromRaw : IFromRawJson<InteractionCompleteEvent>
{
    /// <inheritdoc/>
    public InteractionCompleteEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InteractionCompleteEvent.FromRawUnchecked(rawData);
}
