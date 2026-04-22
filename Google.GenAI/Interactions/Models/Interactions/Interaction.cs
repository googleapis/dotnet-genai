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
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// The Interaction resource.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Interaction, InteractionFromRaw>))]
public sealed record class Interaction : JsonModel
{
    /// <summary>
    /// Required. Output only. A unique identifier for the interaction completion.
    /// </summary>
    public string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Required. Output only. The time at which the response was created in ISO 8601
    /// format (YYYY-MM-DDThh:mm:ssZ).
    /// </summary>
    public DateTimeOffset Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    /// <summary>
    /// Required. Output only. The status of the interaction.
    /// </summary>
    public ApiEnum<string, InteractionStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InteractionStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Required. Output only. The time at which the response was last updated in
    /// ISO 8601 format (YYYY-MM-DDThh:mm:ssZ).
    /// </summary>
    public DateTimeOffset Updated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated");
        }
        init { this._rawData.Set("updated", value); }
    }

    /// <summary>
    /// The name of the `Agent` used for generating the interaction.
    /// </summary>
    public ApiEnum<string, InteractionAgent>? Agent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InteractionAgent>>("agent");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("agent", value);
        }
    }

    /// <summary>
    /// Configuration parameters for the agent interaction.
    /// </summary>
    public InteractionAgentConfig? AgentConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InteractionAgentConfig>("agent_config");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("agent_config", value);
        }
    }

    /// <summary>
    /// Input only. Configuration parameters for the model interaction.
    /// </summary>
    public GenerationConfig? GenerationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GenerationConfig>("generation_config");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("generation_config", value);
        }
    }

    /// <summary>
    /// The input for the interaction.
    /// </summary>
    public InteractionInput? Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InteractionInput>("input");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("input", value);
        }
    }

    /// <summary>
    /// The name of the `Model` used for generating the interaction.
    /// </summary>
    public ApiEnum<string, Model>? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Model>>("model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    /// <summary>
    /// Output only. Responses from the model.
    /// </summary>
    public IReadOnlyList<Content>? Outputs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Content>>("outputs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Content>?>(
                "outputs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The ID of the previous interaction, if any.
    /// </summary>
    public string? PreviousInteractionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("previous_interaction_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("previous_interaction_id", value);
        }
    }

    /// <summary>
    /// Enforces that the generated response is a JSON object that complies with
    /// the JSON schema specified in this field.
    /// </summary>
    public JsonElement? ResponseFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("response_format");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("response_format", value);
        }
    }

    /// <summary>
    /// The mime type of the response. This is required if response_format is set.
    /// </summary>
    public string? ResponseMimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("response_mime_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("response_mime_type", value);
        }
    }

    /// <summary>
    /// The requested modalities of the response (TEXT, IMAGE, AUDIO).
    /// </summary>
    public IReadOnlyList<ApiEnum<string, InteractionResponseModality>>? ResponseModalities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, InteractionResponseModality>>
            >("response_modalities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, InteractionResponseModality>>?>(
                "response_modalities",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Output only. The role of the interaction.
    /// </summary>
    public string? Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("role");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("role", value);
        }
    }

    /// <summary>
    /// The service tier for the interaction.
    /// </summary>
    public ApiEnum<string, InteractionServiceTier>? ServiceTier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InteractionServiceTier>>(
                "service_tier"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("service_tier", value);
        }
    }

    /// <summary>
    /// System instruction for the interaction.
    /// </summary>
    public string? SystemInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("system_instruction");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("system_instruction", value);
        }
    }

    /// <summary>
    /// A list of tool declarations the model may call during interaction.
    /// </summary>
    public IReadOnlyList<Tool>? Tools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Tool>>("tools");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Tool>?>(
                "tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Output only. Statistics on the interaction request's token usage.
    /// </summary>
    public Usage? Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Usage>("usage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("usage", value);
        }
    }

    /// <summary>
    /// Optional. Webhook configuration for receiving notifications when the interaction completes.
    /// </summary>
    public InteractionWebhookConfig? WebhookConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InteractionWebhookConfig>("webhook_config");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("webhook_config", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Created;
        this.Status.Validate();
        _ = this.Updated;
        this.Agent?.Raw();
        this.AgentConfig?.Validate();
        this.GenerationConfig?.Validate();
        this.Input?.Validate();
        this.Model?.Raw();
        foreach (var item in this.Outputs ?? Enumerable.Empty<Content>())
        {
            item.Validate();
        }
        _ = this.PreviousInteractionID;
        _ = this.ResponseFormat;
        _ = this.ResponseMimeType;
        foreach (
            var item in this.ResponseModalities
                ?? Enumerable.Empty<ApiEnum<string, InteractionResponseModality>>()
        )
        {
            item.Validate();
        }
        _ = this.Role;
        this.ServiceTier?.Validate();
        _ = this.SystemInstruction;
        foreach (var item in this.Tools ?? Enumerable.Empty<Tool>())
        {
            item.Validate();
        }
        this.Usage?.Validate();
        this.WebhookConfig?.Validate();
    }

    public Interaction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Interaction(Interaction interaction)
        : base(interaction) { }
#pragma warning restore CS8618

    public Interaction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Interaction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InteractionFromRaw.FromRawUnchecked"/>
    public static Interaction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InteractionFromRaw : IFromRawJson<Interaction>
{
    /// <inheritdoc/>
    public Interaction FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Interaction.FromRawUnchecked(rawData);
}

/// <summary>
/// Required. Output only. The status of the interaction.
/// </summary>
[JsonConverter(typeof(InteractionStatusConverter))]
public enum InteractionStatus
{
    InProgress,
    RequiresAction,
    Completed,
    Failed,
    Cancelled,
    Incomplete,
}

sealed class InteractionStatusConverter : JsonConverter<InteractionStatus>
{
    public override InteractionStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in_progress" => InteractionStatus.InProgress,
            "requires_action" => InteractionStatus.RequiresAction,
            "completed" => InteractionStatus.Completed,
            "failed" => InteractionStatus.Failed,
            "cancelled" => InteractionStatus.Cancelled,
            "incomplete" => InteractionStatus.Incomplete,
            _ => (InteractionStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InteractionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InteractionStatus.InProgress => "in_progress",
                InteractionStatus.RequiresAction => "requires_action",
                InteractionStatus.Completed => "completed",
                InteractionStatus.Failed => "failed",
                InteractionStatus.Cancelled => "cancelled",
                InteractionStatus.Incomplete => "incomplete",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The name of the `Agent` used for generating the interaction.
/// </summary>
[JsonConverter(typeof(InteractionAgentConverter))]
public enum InteractionAgent
{
    /// <summary>
    /// Gemini Deep Research Agent
    /// </summary>
    DeepResearchProPreview12_2025,

    /// <summary>
    /// Gemini Deep Research Agent
    /// </summary>
    DeepResearchPreview04_2026,

    /// <summary>
    /// Gemini Deep Research Max Agent
    /// </summary>
    DeepResearchMaxPreview04_2026,
}

sealed class InteractionAgentConverter : JsonConverter<InteractionAgent>
{
    public override InteractionAgent Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deep-research-pro-preview-12-2025" => InteractionAgent.DeepResearchProPreview12_2025,
            "deep-research-preview-04-2026" => InteractionAgent.DeepResearchPreview04_2026,
            "deep-research-max-preview-04-2026" => InteractionAgent.DeepResearchMaxPreview04_2026,
            _ => (InteractionAgent)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InteractionAgent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InteractionAgent.DeepResearchProPreview12_2025 =>
                    "deep-research-pro-preview-12-2025",
                InteractionAgent.DeepResearchPreview04_2026 => "deep-research-preview-04-2026",
                InteractionAgent.DeepResearchMaxPreview04_2026 =>
                    "deep-research-max-preview-04-2026",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration parameters for the agent interaction.
/// </summary>
[JsonConverter(typeof(InteractionAgentConfigConverter))]
public record class InteractionAgentConfig : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get { return Match(dynamic: (x) => x.Type, deepResearch: (x) => x.Type); }
    }

    public InteractionAgentConfig(DynamicAgentConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionAgentConfig(DeepResearchAgentConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionAgentConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DynamicAgentConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDynamic(out var value)) {
    ///     // `value` is of type `DynamicAgentConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDynamic([NotNullWhen(true)] out DynamicAgentConfig? value)
    {
        value = this.Value as DynamicAgentConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DeepResearchAgentConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDeepResearch(out var value)) {
    ///     // `value` is of type `DeepResearchAgentConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDeepResearch([NotNullWhen(true)] out DeepResearchAgentConfig? value)
    {
        value = this.Value as DeepResearchAgentConfig;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="GeminiNextGenApiInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (DynamicAgentConfig value) =&gt; {...},
    ///     (DeepResearchAgentConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<DynamicAgentConfig> dynamic,
        Action<DeepResearchAgentConfig> deepResearch
    )
    {
        switch (this.Value)
        {
            case DynamicAgentConfig value:
                dynamic(value);
                break;
            case DeepResearchAgentConfig value:
                deepResearch(value);
                break;
            default:
                throw new GeminiNextGenApiInvalidDataException(
                    "Data did not match any variant of InteractionAgentConfig"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="GeminiNextGenApiInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (DynamicAgentConfig value) =&gt; {...},
    ///     (DeepResearchAgentConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<DynamicAgentConfig, T> dynamic,
        Func<DeepResearchAgentConfig, T> deepResearch
    )
    {
        return this.Value switch
        {
            DynamicAgentConfig value => dynamic(value),
            DeepResearchAgentConfig value => deepResearch(value),
            _ => throw new GeminiNextGenApiInvalidDataException(
                "Data did not match any variant of InteractionAgentConfig"
            ),
        };
    }

    public static implicit operator InteractionAgentConfig(DynamicAgentConfig value) => new(value);

    public static implicit operator InteractionAgentConfig(DeepResearchAgentConfig value) =>
        new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="GeminiNextGenApiInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new GeminiNextGenApiInvalidDataException(
                "Data did not match any variant of InteractionAgentConfig"
            );
        }
        this.Switch((dynamic) => dynamic.Validate(), (deepResearch) => deepResearch.Validate());
    }

    public virtual bool Equals(InteractionAgentConfig? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            DynamicAgentConfig _ => 0,
            DeepResearchAgentConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class InteractionAgentConfigConverter : JsonConverter<InteractionAgentConfig>
{
    public override InteractionAgentConfig? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "dynamic":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DynamicAgentConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "deep-research":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DeepResearchAgentConfig>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new InteractionAgentConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        InteractionAgentConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// The input for the interaction.
/// </summary>
[JsonConverter(typeof(InteractionInputConverter))]
public record class InteractionInput : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement? Type
    {
        get
        {
            return Match<JsonElement?>(
                contentList: (_) => null,
                @string: (_) => null,
                turnList: (_) => null,
                textContent: (x) => x.Type,
                imageContent: (x) => x.Type,
                audioContent: (x) => x.Type,
                documentContent: (x) => x.Type,
                videoContent: (x) => x.Type,
                thoughtContent: (x) => x.Type,
                functionCallContent: (x) => x.Type,
                codeExecutionCallContent: (x) => x.Type,
                urlContextCallContent: (x) => x.Type,
                mcpServerToolCallContent: (x) => x.Type,
                googleSearchCallContent: (x) => x.Type,
                fileSearchCallContent: (x) => x.Type,
                googleMapsCallContent: (x) => x.Type,
                functionResultContent: (x) => x.Type,
                codeExecutionResultContent: (x) => x.Type,
                urlContextResultContent: (x) => x.Type,
                googleSearchResultContent: (x) => x.Type,
                mcpServerToolResultContent: (x) => x.Type,
                fileSearchResultContent: (x) => x.Type,
                googleMapsResultContent: (x) => x.Type
            );
        }
    }

    public string? Data
    {
        get
        {
            return Match<string?>(
                contentList: (_) => null,
                @string: (_) => null,
                turnList: (_) => null,
                textContent: (_) => null,
                imageContent: (x) => x.Data,
                audioContent: (x) => x.Data,
                documentContent: (x) => x.Data,
                videoContent: (x) => x.Data,
                thoughtContent: (_) => null,
                functionCallContent: (_) => null,
                codeExecutionCallContent: (_) => null,
                urlContextCallContent: (_) => null,
                mcpServerToolCallContent: (_) => null,
                googleSearchCallContent: (_) => null,
                fileSearchCallContent: (_) => null,
                googleMapsCallContent: (_) => null,
                functionResultContent: (_) => null,
                codeExecutionResultContent: (_) => null,
                urlContextResultContent: (_) => null,
                googleSearchResultContent: (_) => null,
                mcpServerToolResultContent: (_) => null,
                fileSearchResultContent: (_) => null,
                googleMapsResultContent: (_) => null
            );
        }
    }

    public string? Uri
    {
        get
        {
            return Match<string?>(
                contentList: (_) => null,
                @string: (_) => null,
                turnList: (_) => null,
                textContent: (_) => null,
                imageContent: (x) => x.Uri,
                audioContent: (x) => x.Uri,
                documentContent: (x) => x.Uri,
                videoContent: (x) => x.Uri,
                thoughtContent: (_) => null,
                functionCallContent: (_) => null,
                codeExecutionCallContent: (_) => null,
                urlContextCallContent: (_) => null,
                mcpServerToolCallContent: (_) => null,
                googleSearchCallContent: (_) => null,
                fileSearchCallContent: (_) => null,
                googleMapsCallContent: (_) => null,
                functionResultContent: (_) => null,
                codeExecutionResultContent: (_) => null,
                urlContextResultContent: (_) => null,
                googleSearchResultContent: (_) => null,
                mcpServerToolResultContent: (_) => null,
                fileSearchResultContent: (_) => null,
                googleMapsResultContent: (_) => null
            );
        }
    }

    public string? Signature
    {
        get
        {
            return Match<string?>(
                contentList: (_) => null,
                @string: (_) => null,
                turnList: (_) => null,
                textContent: (_) => null,
                imageContent: (_) => null,
                audioContent: (_) => null,
                documentContent: (_) => null,
                videoContent: (_) => null,
                thoughtContent: (x) => x.Signature,
                functionCallContent: (x) => x.Signature,
                codeExecutionCallContent: (x) => x.Signature,
                urlContextCallContent: (x) => x.Signature,
                mcpServerToolCallContent: (x) => x.Signature,
                googleSearchCallContent: (x) => x.Signature,
                fileSearchCallContent: (x) => x.Signature,
                googleMapsCallContent: (x) => x.Signature,
                functionResultContent: (x) => x.Signature,
                codeExecutionResultContent: (x) => x.Signature,
                urlContextResultContent: (x) => x.Signature,
                googleSearchResultContent: (x) => x.Signature,
                mcpServerToolResultContent: (x) => x.Signature,
                fileSearchResultContent: (x) => x.Signature,
                googleMapsResultContent: (x) => x.Signature
            );
        }
    }

    public string? ID
    {
        get
        {
            return Match<string?>(
                contentList: (_) => null,
                @string: (_) => null,
                turnList: (_) => null,
                textContent: (_) => null,
                imageContent: (_) => null,
                audioContent: (_) => null,
                documentContent: (_) => null,
                videoContent: (_) => null,
                thoughtContent: (_) => null,
                functionCallContent: (x) => x.ID,
                codeExecutionCallContent: (x) => x.ID,
                urlContextCallContent: (x) => x.ID,
                mcpServerToolCallContent: (x) => x.ID,
                googleSearchCallContent: (x) => x.ID,
                fileSearchCallContent: (x) => x.ID,
                googleMapsCallContent: (x) => x.ID,
                functionResultContent: (_) => null,
                codeExecutionResultContent: (_) => null,
                urlContextResultContent: (_) => null,
                googleSearchResultContent: (_) => null,
                mcpServerToolResultContent: (_) => null,
                fileSearchResultContent: (_) => null,
                googleMapsResultContent: (_) => null
            );
        }
    }

    public string? Name
    {
        get
        {
            return Match<string?>(
                contentList: (_) => null,
                @string: (_) => null,
                turnList: (_) => null,
                textContent: (_) => null,
                imageContent: (_) => null,
                audioContent: (_) => null,
                documentContent: (_) => null,
                videoContent: (_) => null,
                thoughtContent: (_) => null,
                functionCallContent: (x) => x.Name,
                codeExecutionCallContent: (_) => null,
                urlContextCallContent: (_) => null,
                mcpServerToolCallContent: (x) => x.Name,
                googleSearchCallContent: (_) => null,
                fileSearchCallContent: (_) => null,
                googleMapsCallContent: (_) => null,
                functionResultContent: (x) => x.Name,
                codeExecutionResultContent: (_) => null,
                urlContextResultContent: (_) => null,
                googleSearchResultContent: (_) => null,
                mcpServerToolResultContent: (x) => x.Name,
                fileSearchResultContent: (_) => null,
                googleMapsResultContent: (_) => null
            );
        }
    }

    public string? ServerName
    {
        get
        {
            return Match<string?>(
                contentList: (_) => null,
                @string: (_) => null,
                turnList: (_) => null,
                textContent: (_) => null,
                imageContent: (_) => null,
                audioContent: (_) => null,
                documentContent: (_) => null,
                videoContent: (_) => null,
                thoughtContent: (_) => null,
                functionCallContent: (_) => null,
                codeExecutionCallContent: (_) => null,
                urlContextCallContent: (_) => null,
                mcpServerToolCallContent: (x) => x.ServerName,
                googleSearchCallContent: (_) => null,
                fileSearchCallContent: (_) => null,
                googleMapsCallContent: (_) => null,
                functionResultContent: (_) => null,
                codeExecutionResultContent: (_) => null,
                urlContextResultContent: (_) => null,
                googleSearchResultContent: (_) => null,
                mcpServerToolResultContent: (x) => x.ServerName,
                fileSearchResultContent: (_) => null,
                googleMapsResultContent: (_) => null
            );
        }
    }

    public string? CallID
    {
        get
        {
            return Match<string?>(
                contentList: (_) => null,
                @string: (_) => null,
                turnList: (_) => null,
                textContent: (_) => null,
                imageContent: (_) => null,
                audioContent: (_) => null,
                documentContent: (_) => null,
                videoContent: (_) => null,
                thoughtContent: (_) => null,
                functionCallContent: (_) => null,
                codeExecutionCallContent: (_) => null,
                urlContextCallContent: (_) => null,
                mcpServerToolCallContent: (_) => null,
                googleSearchCallContent: (_) => null,
                fileSearchCallContent: (_) => null,
                googleMapsCallContent: (_) => null,
                functionResultContent: (x) => x.CallID,
                codeExecutionResultContent: (x) => x.CallID,
                urlContextResultContent: (x) => x.CallID,
                googleSearchResultContent: (x) => x.CallID,
                mcpServerToolResultContent: (x) => x.CallID,
                fileSearchResultContent: (x) => x.CallID,
                googleMapsResultContent: (x) => x.CallID
            );
        }
    }

    public bool? IsError
    {
        get
        {
            return Match<bool?>(
                contentList: (_) => null,
                @string: (_) => null,
                turnList: (_) => null,
                textContent: (_) => null,
                imageContent: (_) => null,
                audioContent: (_) => null,
                documentContent: (_) => null,
                videoContent: (_) => null,
                thoughtContent: (_) => null,
                functionCallContent: (_) => null,
                codeExecutionCallContent: (_) => null,
                urlContextCallContent: (_) => null,
                mcpServerToolCallContent: (_) => null,
                googleSearchCallContent: (_) => null,
                fileSearchCallContent: (_) => null,
                googleMapsCallContent: (_) => null,
                functionResultContent: (x) => x.IsError,
                codeExecutionResultContent: (x) => x.IsError,
                urlContextResultContent: (x) => x.IsError,
                googleSearchResultContent: (x) => x.IsError,
                mcpServerToolResultContent: (_) => null,
                fileSearchResultContent: (_) => null,
                googleMapsResultContent: (_) => null
            );
        }
    }

    public InteractionInput(IReadOnlyList<Content> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public InteractionInput(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(IReadOnlyList<Turn> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public InteractionInput(TextContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(ImageContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(AudioContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(DocumentContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(VideoContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(ThoughtContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(FunctionCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(CodeExecutionCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(UrlContextCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(McpServerToolCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(GoogleSearchCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(FileSearchCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(GoogleMapsCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(FunctionResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(CodeExecutionResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(UrlContextResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(GoogleSearchResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(McpServerToolResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(FileSearchResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(GoogleMapsResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionInput(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>Content</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickContentList(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;Content&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickContentList([NotNullWhen(true)] out IReadOnlyList<Content>? value)
    {
        value = this.Value as IReadOnlyList<Content>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>Turn</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTurnList(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;Turn&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTurnList([NotNullWhen(true)] out IReadOnlyList<Turn>? value)
    {
        value = this.Value as IReadOnlyList<Turn>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TextContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextContent(out var value)) {
    ///     // `value` is of type `TextContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextContent([NotNullWhen(true)] out TextContent? value)
    {
        value = this.Value as TextContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ImageContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickImageContent(out var value)) {
    ///     // `value` is of type `ImageContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickImageContent([NotNullWhen(true)] out ImageContent? value)
    {
        value = this.Value as ImageContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AudioContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAudioContent(out var value)) {
    ///     // `value` is of type `AudioContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAudioContent([NotNullWhen(true)] out AudioContent? value)
    {
        value = this.Value as AudioContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DocumentContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDocumentContent(out var value)) {
    ///     // `value` is of type `DocumentContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDocumentContent([NotNullWhen(true)] out DocumentContent? value)
    {
        value = this.Value as DocumentContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VideoContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVideoContent(out var value)) {
    ///     // `value` is of type `VideoContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVideoContent([NotNullWhen(true)] out VideoContent? value)
    {
        value = this.Value as VideoContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ThoughtContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThoughtContent(out var value)) {
    ///     // `value` is of type `ThoughtContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThoughtContent([NotNullWhen(true)] out ThoughtContent? value)
    {
        value = this.Value as ThoughtContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionCallContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFunctionCallContent(out var value)) {
    ///     // `value` is of type `FunctionCallContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFunctionCallContent([NotNullWhen(true)] out FunctionCallContent? value)
    {
        value = this.Value as FunctionCallContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CodeExecutionCallContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCodeExecutionCallContent(out var value)) {
    ///     // `value` is of type `CodeExecutionCallContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCodeExecutionCallContent(
        [NotNullWhen(true)] out CodeExecutionCallContent? value
    )
    {
        value = this.Value as CodeExecutionCallContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UrlContextCallContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUrlContextCallContent(out var value)) {
    ///     // `value` is of type `UrlContextCallContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUrlContextCallContent([NotNullWhen(true)] out UrlContextCallContent? value)
    {
        value = this.Value as UrlContextCallContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="McpServerToolCallContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMcpServerToolCallContent(out var value)) {
    ///     // `value` is of type `McpServerToolCallContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMcpServerToolCallContent(
        [NotNullWhen(true)] out McpServerToolCallContent? value
    )
    {
        value = this.Value as McpServerToolCallContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GoogleSearchCallContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGoogleSearchCallContent(out var value)) {
    ///     // `value` is of type `GoogleSearchCallContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGoogleSearchCallContent(
        [NotNullWhen(true)] out GoogleSearchCallContent? value
    )
    {
        value = this.Value as GoogleSearchCallContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FileSearchCallContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFileSearchCallContent(out var value)) {
    ///     // `value` is of type `FileSearchCallContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFileSearchCallContent([NotNullWhen(true)] out FileSearchCallContent? value)
    {
        value = this.Value as FileSearchCallContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GoogleMapsCallContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGoogleMapsCallContent(out var value)) {
    ///     // `value` is of type `GoogleMapsCallContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGoogleMapsCallContent([NotNullWhen(true)] out GoogleMapsCallContent? value)
    {
        value = this.Value as GoogleMapsCallContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionResultContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFunctionResultContent(out var value)) {
    ///     // `value` is of type `FunctionResultContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFunctionResultContent([NotNullWhen(true)] out FunctionResultContent? value)
    {
        value = this.Value as FunctionResultContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CodeExecutionResultContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCodeExecutionResultContent(out var value)) {
    ///     // `value` is of type `CodeExecutionResultContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCodeExecutionResultContent(
        [NotNullWhen(true)] out CodeExecutionResultContent? value
    )
    {
        value = this.Value as CodeExecutionResultContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UrlContextResultContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUrlContextResultContent(out var value)) {
    ///     // `value` is of type `UrlContextResultContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUrlContextResultContent(
        [NotNullWhen(true)] out UrlContextResultContent? value
    )
    {
        value = this.Value as UrlContextResultContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GoogleSearchResultContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGoogleSearchResultContent(out var value)) {
    ///     // `value` is of type `GoogleSearchResultContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGoogleSearchResultContent(
        [NotNullWhen(true)] out GoogleSearchResultContent? value
    )
    {
        value = this.Value as GoogleSearchResultContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="McpServerToolResultContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMcpServerToolResultContent(out var value)) {
    ///     // `value` is of type `McpServerToolResultContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMcpServerToolResultContent(
        [NotNullWhen(true)] out McpServerToolResultContent? value
    )
    {
        value = this.Value as McpServerToolResultContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FileSearchResultContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFileSearchResultContent(out var value)) {
    ///     // `value` is of type `FileSearchResultContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFileSearchResultContent(
        [NotNullWhen(true)] out FileSearchResultContent? value
    )
    {
        value = this.Value as FileSearchResultContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GoogleMapsResultContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGoogleMapsResultContent(out var value)) {
    ///     // `value` is of type `GoogleMapsResultContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGoogleMapsResultContent(
        [NotNullWhen(true)] out GoogleMapsResultContent? value
    )
    {
        value = this.Value as GoogleMapsResultContent;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="GeminiNextGenApiInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (IReadOnlyList&lt;Content&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (IReadOnlyList&lt;Turn&gt; value) =&gt; {...},
    ///     (TextContent value) =&gt; {...},
    ///     (ImageContent value) =&gt; {...},
    ///     (AudioContent value) =&gt; {...},
    ///     (DocumentContent value) =&gt; {...},
    ///     (VideoContent value) =&gt; {...},
    ///     (ThoughtContent value) =&gt; {...},
    ///     (FunctionCallContent value) =&gt; {...},
    ///     (CodeExecutionCallContent value) =&gt; {...},
    ///     (UrlContextCallContent value) =&gt; {...},
    ///     (McpServerToolCallContent value) =&gt; {...},
    ///     (GoogleSearchCallContent value) =&gt; {...},
    ///     (FileSearchCallContent value) =&gt; {...},
    ///     (GoogleMapsCallContent value) =&gt; {...},
    ///     (FunctionResultContent value) =&gt; {...},
    ///     (CodeExecutionResultContent value) =&gt; {...},
    ///     (UrlContextResultContent value) =&gt; {...},
    ///     (GoogleSearchResultContent value) =&gt; {...},
    ///     (McpServerToolResultContent value) =&gt; {...},
    ///     (FileSearchResultContent value) =&gt; {...},
    ///     (GoogleMapsResultContent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<IReadOnlyList<Content>> contentList,
        Action<string> @string,
        Action<IReadOnlyList<Turn>> turnList,
        Action<TextContent> textContent,
        Action<ImageContent> imageContent,
        Action<AudioContent> audioContent,
        Action<DocumentContent> documentContent,
        Action<VideoContent> videoContent,
        Action<ThoughtContent> thoughtContent,
        Action<FunctionCallContent> functionCallContent,
        Action<CodeExecutionCallContent> codeExecutionCallContent,
        Action<UrlContextCallContent> urlContextCallContent,
        Action<McpServerToolCallContent> mcpServerToolCallContent,
        Action<GoogleSearchCallContent> googleSearchCallContent,
        Action<FileSearchCallContent> fileSearchCallContent,
        Action<GoogleMapsCallContent> googleMapsCallContent,
        Action<FunctionResultContent> functionResultContent,
        Action<CodeExecutionResultContent> codeExecutionResultContent,
        Action<UrlContextResultContent> urlContextResultContent,
        Action<GoogleSearchResultContent> googleSearchResultContent,
        Action<McpServerToolResultContent> mcpServerToolResultContent,
        Action<FileSearchResultContent> fileSearchResultContent,
        Action<GoogleMapsResultContent> googleMapsResultContent
    )
    {
        switch (this.Value)
        {
            case IReadOnlyList<Content> value:
                contentList(value);
                break;
            case string value:
                @string(value);
                break;
            case IReadOnlyList<Turn> value:
                turnList(value);
                break;
            case TextContent value:
                textContent(value);
                break;
            case ImageContent value:
                imageContent(value);
                break;
            case AudioContent value:
                audioContent(value);
                break;
            case DocumentContent value:
                documentContent(value);
                break;
            case VideoContent value:
                videoContent(value);
                break;
            case ThoughtContent value:
                thoughtContent(value);
                break;
            case FunctionCallContent value:
                functionCallContent(value);
                break;
            case CodeExecutionCallContent value:
                codeExecutionCallContent(value);
                break;
            case UrlContextCallContent value:
                urlContextCallContent(value);
                break;
            case McpServerToolCallContent value:
                mcpServerToolCallContent(value);
                break;
            case GoogleSearchCallContent value:
                googleSearchCallContent(value);
                break;
            case FileSearchCallContent value:
                fileSearchCallContent(value);
                break;
            case GoogleMapsCallContent value:
                googleMapsCallContent(value);
                break;
            case FunctionResultContent value:
                functionResultContent(value);
                break;
            case CodeExecutionResultContent value:
                codeExecutionResultContent(value);
                break;
            case UrlContextResultContent value:
                urlContextResultContent(value);
                break;
            case GoogleSearchResultContent value:
                googleSearchResultContent(value);
                break;
            case McpServerToolResultContent value:
                mcpServerToolResultContent(value);
                break;
            case FileSearchResultContent value:
                fileSearchResultContent(value);
                break;
            case GoogleMapsResultContent value:
                googleMapsResultContent(value);
                break;
            default:
                throw new GeminiNextGenApiInvalidDataException(
                    "Data did not match any variant of InteractionInput"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="GeminiNextGenApiInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (IReadOnlyList&lt;Content&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (IReadOnlyList&lt;Turn&gt; value) =&gt; {...},
    ///     (TextContent value) =&gt; {...},
    ///     (ImageContent value) =&gt; {...},
    ///     (AudioContent value) =&gt; {...},
    ///     (DocumentContent value) =&gt; {...},
    ///     (VideoContent value) =&gt; {...},
    ///     (ThoughtContent value) =&gt; {...},
    ///     (FunctionCallContent value) =&gt; {...},
    ///     (CodeExecutionCallContent value) =&gt; {...},
    ///     (UrlContextCallContent value) =&gt; {...},
    ///     (McpServerToolCallContent value) =&gt; {...},
    ///     (GoogleSearchCallContent value) =&gt; {...},
    ///     (FileSearchCallContent value) =&gt; {...},
    ///     (GoogleMapsCallContent value) =&gt; {...},
    ///     (FunctionResultContent value) =&gt; {...},
    ///     (CodeExecutionResultContent value) =&gt; {...},
    ///     (UrlContextResultContent value) =&gt; {...},
    ///     (GoogleSearchResultContent value) =&gt; {...},
    ///     (McpServerToolResultContent value) =&gt; {...},
    ///     (FileSearchResultContent value) =&gt; {...},
    ///     (GoogleMapsResultContent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<IReadOnlyList<Content>, T> contentList,
        Func<string, T> @string,
        Func<IReadOnlyList<Turn>, T> turnList,
        Func<TextContent, T> textContent,
        Func<ImageContent, T> imageContent,
        Func<AudioContent, T> audioContent,
        Func<DocumentContent, T> documentContent,
        Func<VideoContent, T> videoContent,
        Func<ThoughtContent, T> thoughtContent,
        Func<FunctionCallContent, T> functionCallContent,
        Func<CodeExecutionCallContent, T> codeExecutionCallContent,
        Func<UrlContextCallContent, T> urlContextCallContent,
        Func<McpServerToolCallContent, T> mcpServerToolCallContent,
        Func<GoogleSearchCallContent, T> googleSearchCallContent,
        Func<FileSearchCallContent, T> fileSearchCallContent,
        Func<GoogleMapsCallContent, T> googleMapsCallContent,
        Func<FunctionResultContent, T> functionResultContent,
        Func<CodeExecutionResultContent, T> codeExecutionResultContent,
        Func<UrlContextResultContent, T> urlContextResultContent,
        Func<GoogleSearchResultContent, T> googleSearchResultContent,
        Func<McpServerToolResultContent, T> mcpServerToolResultContent,
        Func<FileSearchResultContent, T> fileSearchResultContent,
        Func<GoogleMapsResultContent, T> googleMapsResultContent
    )
    {
        return this.Value switch
        {
            IReadOnlyList<Content> value => contentList(value),
            string value => @string(value),
            IReadOnlyList<Turn> value => turnList(value),
            TextContent value => textContent(value),
            ImageContent value => imageContent(value),
            AudioContent value => audioContent(value),
            DocumentContent value => documentContent(value),
            VideoContent value => videoContent(value),
            ThoughtContent value => thoughtContent(value),
            FunctionCallContent value => functionCallContent(value),
            CodeExecutionCallContent value => codeExecutionCallContent(value),
            UrlContextCallContent value => urlContextCallContent(value),
            McpServerToolCallContent value => mcpServerToolCallContent(value),
            GoogleSearchCallContent value => googleSearchCallContent(value),
            FileSearchCallContent value => fileSearchCallContent(value),
            GoogleMapsCallContent value => googleMapsCallContent(value),
            FunctionResultContent value => functionResultContent(value),
            CodeExecutionResultContent value => codeExecutionResultContent(value),
            UrlContextResultContent value => urlContextResultContent(value),
            GoogleSearchResultContent value => googleSearchResultContent(value),
            McpServerToolResultContent value => mcpServerToolResultContent(value),
            FileSearchResultContent value => fileSearchResultContent(value),
            GoogleMapsResultContent value => googleMapsResultContent(value),
            _ => throw new GeminiNextGenApiInvalidDataException(
                "Data did not match any variant of InteractionInput"
            ),
        };
    }

    public static implicit operator InteractionInput(List<Content> value) =>
        new((IReadOnlyList<Content>)value);

    public static implicit operator InteractionInput(string value) => new(value);

    public static implicit operator InteractionInput(List<Turn> value) =>
        new((IReadOnlyList<Turn>)value);

    public static implicit operator InteractionInput(TextContent value) => new(value);

    public static implicit operator InteractionInput(ImageContent value) => new(value);

    public static implicit operator InteractionInput(AudioContent value) => new(value);

    public static implicit operator InteractionInput(DocumentContent value) => new(value);

    public static implicit operator InteractionInput(VideoContent value) => new(value);

    public static implicit operator InteractionInput(ThoughtContent value) => new(value);

    public static implicit operator InteractionInput(FunctionCallContent value) => new(value);

    public static implicit operator InteractionInput(CodeExecutionCallContent value) => new(value);

    public static implicit operator InteractionInput(UrlContextCallContent value) => new(value);

    public static implicit operator InteractionInput(McpServerToolCallContent value) => new(value);

    public static implicit operator InteractionInput(GoogleSearchCallContent value) => new(value);

    public static implicit operator InteractionInput(FileSearchCallContent value) => new(value);

    public static implicit operator InteractionInput(GoogleMapsCallContent value) => new(value);

    public static implicit operator InteractionInput(FunctionResultContent value) => new(value);

    public static implicit operator InteractionInput(CodeExecutionResultContent value) =>
        new(value);

    public static implicit operator InteractionInput(UrlContextResultContent value) => new(value);

    public static implicit operator InteractionInput(GoogleSearchResultContent value) => new(value);

    public static implicit operator InteractionInput(McpServerToolResultContent value) =>
        new(value);

    public static implicit operator InteractionInput(FileSearchResultContent value) => new(value);

    public static implicit operator InteractionInput(GoogleMapsResultContent value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="GeminiNextGenApiInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new GeminiNextGenApiInvalidDataException(
                "Data did not match any variant of InteractionInput"
            );
        }
        this.Switch(
            (contentList) =>
            {
                foreach (var item in contentList)
                {
                    item.Validate();
                }
            },
            (_) => { },
            (turnList) =>
            {
                foreach (var item in turnList)
                {
                    item.Validate();
                }
            },
            (textContent) => textContent.Validate(),
            (imageContent) => imageContent.Validate(),
            (audioContent) => audioContent.Validate(),
            (documentContent) => documentContent.Validate(),
            (videoContent) => videoContent.Validate(),
            (thoughtContent) => thoughtContent.Validate(),
            (functionCallContent) => functionCallContent.Validate(),
            (codeExecutionCallContent) => codeExecutionCallContent.Validate(),
            (urlContextCallContent) => urlContextCallContent.Validate(),
            (mcpServerToolCallContent) => mcpServerToolCallContent.Validate(),
            (googleSearchCallContent) => googleSearchCallContent.Validate(),
            (fileSearchCallContent) => fileSearchCallContent.Validate(),
            (googleMapsCallContent) => googleMapsCallContent.Validate(),
            (functionResultContent) => functionResultContent.Validate(),
            (codeExecutionResultContent) => codeExecutionResultContent.Validate(),
            (urlContextResultContent) => urlContextResultContent.Validate(),
            (googleSearchResultContent) => googleSearchResultContent.Validate(),
            (mcpServerToolResultContent) => mcpServerToolResultContent.Validate(),
            (fileSearchResultContent) => fileSearchResultContent.Validate(),
            (googleMapsResultContent) => googleMapsResultContent.Validate()
        );
    }

    public virtual bool Equals(InteractionInput? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            IReadOnlyList<Content> _ => 0,
            string _ => 1,
            IReadOnlyList<Turn> _ => 2,
            TextContent _ => 3,
            ImageContent _ => 4,
            AudioContent _ => 5,
            DocumentContent _ => 6,
            VideoContent _ => 7,
            ThoughtContent _ => 8,
            FunctionCallContent _ => 9,
            CodeExecutionCallContent _ => 10,
            UrlContextCallContent _ => 11,
            McpServerToolCallContent _ => 12,
            GoogleSearchCallContent _ => 13,
            FileSearchCallContent _ => 14,
            GoogleMapsCallContent _ => 15,
            FunctionResultContent _ => 16,
            CodeExecutionResultContent _ => 17,
            UrlContextResultContent _ => 18,
            GoogleSearchResultContent _ => 19,
            McpServerToolResultContent _ => 20,
            FileSearchResultContent _ => 21,
            GoogleMapsResultContent _ => 22,
            _ => -1,
        };
    }
}

sealed class InteractionInputConverter : JsonConverter<InteractionInput>
{
    public override InteractionInput? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<TextContent>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ImageContent>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AudioContent>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<DocumentContent>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<VideoContent>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ThoughtContent>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<FunctionCallContent>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CodeExecutionCallContent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UrlContextCallContent>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<McpServerToolCallContent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<GoogleSearchCallContent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<FileSearchCallContent>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<GoogleMapsCallContent>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<FunctionResultContent>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CodeExecutionResultContent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UrlContextResultContent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<GoogleSearchResultContent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<McpServerToolResultContent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<FileSearchResultContent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<GoogleMapsResultContent>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Content>>(element, options);
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Turn>>(element, options);
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        InteractionInput value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(InteractionResponseModalityConverter))]
public enum InteractionResponseModality
{
    Text,
    Image,
    Audio,
    Video,
    Document,
}

sealed class InteractionResponseModalityConverter : JsonConverter<InteractionResponseModality>
{
    public override InteractionResponseModality Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => InteractionResponseModality.Text,
            "image" => InteractionResponseModality.Image,
            "audio" => InteractionResponseModality.Audio,
            "video" => InteractionResponseModality.Video,
            "document" => InteractionResponseModality.Document,
            _ => (InteractionResponseModality)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InteractionResponseModality value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InteractionResponseModality.Text => "text",
                InteractionResponseModality.Image => "image",
                InteractionResponseModality.Audio => "audio",
                InteractionResponseModality.Video => "video",
                InteractionResponseModality.Document => "document",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The service tier for the interaction.
/// </summary>
[JsonConverter(typeof(InteractionServiceTierConverter))]
public enum InteractionServiceTier
{
    Flex,
    Standard,
    Priority,
}

sealed class InteractionServiceTierConverter : JsonConverter<InteractionServiceTier>
{
    public override InteractionServiceTier Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "flex" => InteractionServiceTier.Flex,
            "standard" => InteractionServiceTier.Standard,
            "priority" => InteractionServiceTier.Priority,
            _ => (InteractionServiceTier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InteractionServiceTier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InteractionServiceTier.Flex => "flex",
                InteractionServiceTier.Standard => "standard",
                InteractionServiceTier.Priority => "priority",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Message for configuring webhook events for a request.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<InteractionWebhookConfig, InteractionWebhookConfigFromRaw>)
)]
public sealed record class InteractionWebhookConfig : JsonModel
{
    /// <summary>
    /// Optional. If set, these webhook URIs will be used for webhook events instead
    /// of the registered webhooks.
    /// </summary>
    public IReadOnlyList<string>? Uris
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("uris");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "uris",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional. The user metadata that will be returned on each event emission
    /// to the webhooks.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? UserMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "user_metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "user_metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Uris;
        _ = this.UserMetadata;
    }

    public InteractionWebhookConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InteractionWebhookConfig(InteractionWebhookConfig interactionWebhookConfig)
        : base(interactionWebhookConfig) { }
#pragma warning restore CS8618

    public InteractionWebhookConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InteractionWebhookConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InteractionWebhookConfigFromRaw.FromRawUnchecked"/>
    public static InteractionWebhookConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InteractionWebhookConfigFromRaw : IFromRawJson<InteractionWebhookConfig>
{
    /// <inheritdoc/>
    public InteractionWebhookConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InteractionWebhookConfig.FromRawUnchecked(rawData);
}
