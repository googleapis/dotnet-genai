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
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// Creates a new interaction.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InteractionCreateParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    public string? ApiVersion { get; init; }

    /// <summary>
    /// Parameters for creating model interactions
    /// </summary>
    public Body Body
    {
        get { return WrappedJsonSerializer.GetNotNullClass<Body>(this.RawBodyData, "RawBodyData"); }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    public InteractionCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InteractionCreateParams(InteractionCreateParams interactionCreateParams)
        : base(interactionCreateParams)
    {
        this.ApiVersion = interactionCreateParams.ApiVersion;

        this.RawBodyData = interactionCreateParams.RawBodyData;
    }
#pragma warning restore CS8618

    public InteractionCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InteractionCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string apiVersion
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
        this.ApiVersion = apiVersion;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static InteractionCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string apiVersion
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData,
            apiVersion
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ApiVersion"] = JsonSerializer.SerializeToElement(this.ApiVersion),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(InteractionCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ApiVersion?.Equals(other.ApiVersion) ?? other.ApiVersion == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this.RawBodyData.Equals(other.RawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/{0}/interactions", this.ApiVersion)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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

/// <summary>
/// Parameters for creating model interactions
/// </summary>
[JsonConverter(typeof(BodyConverter))]
public record class Body : ModelBase
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

    public string? ID
    {
        get
        {
            return Match<string?>(
                createModelInteractionParams: (x) => x.ID,
                createAgentInteractionParams: (x) => x.ID
            );
        }
    }

    public bool? Background
    {
        get
        {
            return Match<bool?>(
                createModelInteractionParams: (x) => x.Background,
                createAgentInteractionParams: (x) => x.Background
            );
        }
    }

    public DateTimeOffset? Created
    {
        get
        {
            return Match<DateTimeOffset?>(
                createModelInteractionParams: (x) => x.Created,
                createAgentInteractionParams: (x) => x.Created
            );
        }
    }

    public string? PreviousInteractionID
    {
        get
        {
            return Match<string?>(
                createModelInteractionParams: (x) => x.PreviousInteractionID,
                createAgentInteractionParams: (x) => x.PreviousInteractionID
            );
        }
    }

    public JsonElement? ResponseFormat
    {
        get
        {
            return Match<JsonElement?>(
                createModelInteractionParams: (x) => x.ResponseFormat,
                createAgentInteractionParams: (x) => x.ResponseFormat
            );
        }
    }

    public string? ResponseMimeType
    {
        get
        {
            return Match<string?>(
                createModelInteractionParams: (x) => x.ResponseMimeType,
                createAgentInteractionParams: (x) => x.ResponseMimeType
            );
        }
    }

    public string? Role
    {
        get
        {
            return Match<string?>(
                createModelInteractionParams: (x) => x.Role,
                createAgentInteractionParams: (x) => x.Role
            );
        }
    }

    public bool? Store
    {
        get
        {
            return Match<bool?>(
                createModelInteractionParams: (x) => x.Store,
                createAgentInteractionParams: (x) => x.Store
            );
        }
    }

    public string? SystemInstruction
    {
        get
        {
            return Match<string?>(
                createModelInteractionParams: (x) => x.SystemInstruction,
                createAgentInteractionParams: (x) => x.SystemInstruction
            );
        }
    }

    public DateTimeOffset? Updated
    {
        get
        {
            return Match<DateTimeOffset?>(
                createModelInteractionParams: (x) => x.Updated,
                createAgentInteractionParams: (x) => x.Updated
            );
        }
    }

    public Usage? Usage
    {
        get
        {
            return Match<Usage?>(
                createModelInteractionParams: (x) => x.Usage,
                createAgentInteractionParams: (x) => x.Usage
            );
        }
    }

    public Body(CreateModelInteractionParams value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body(CreateAgentInteractionParams value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CreateModelInteractionParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreateModelInteractionParams(out var value)) {
    ///     // `value` is of type `CreateModelInteractionParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreateModelInteractionParams(
        [NotNullWhen(true)] out CreateModelInteractionParams? value
    )
    {
        value = this.Value as CreateModelInteractionParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CreateAgentInteractionParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCreateAgentInteractionParams(out var value)) {
    ///     // `value` is of type `CreateAgentInteractionParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCreateAgentInteractionParams(
        [NotNullWhen(true)] out CreateAgentInteractionParams? value
    )
    {
        value = this.Value as CreateAgentInteractionParams;
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
    ///     (CreateModelInteractionParams value) =&gt; {...},
    ///     (CreateAgentInteractionParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<CreateModelInteractionParams> createModelInteractionParams,
        Action<CreateAgentInteractionParams> createAgentInteractionParams
    )
    {
        switch (this.Value)
        {
            case CreateModelInteractionParams value:
                createModelInteractionParams(value);
                break;
            case CreateAgentInteractionParams value:
                createAgentInteractionParams(value);
                break;
            default:
                throw new GeminiNextGenApiInvalidDataException(
                    "Data did not match any variant of Body"
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
    ///     (CreateModelInteractionParams value) =&gt; {...},
    ///     (CreateAgentInteractionParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<CreateModelInteractionParams, T> createModelInteractionParams,
        Func<CreateAgentInteractionParams, T> createAgentInteractionParams
    )
    {
        return this.Value switch
        {
            CreateModelInteractionParams value => createModelInteractionParams(value),
            CreateAgentInteractionParams value => createAgentInteractionParams(value),
            _ => throw new GeminiNextGenApiInvalidDataException(
                "Data did not match any variant of Body"
            ),
        };
    }

    public static implicit operator Body(CreateModelInteractionParams value) => new(value);

    public static implicit operator Body(CreateAgentInteractionParams value) => new(value);

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
                "Data did not match any variant of Body"
            );
        }
        this.Switch(
            (createModelInteractionParams) => createModelInteractionParams.Validate(),
            (createAgentInteractionParams) => createAgentInteractionParams.Validate()
        );
    }

    public virtual bool Equals(Body? other) =>
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
            CreateModelInteractionParams _ => 0,
            CreateAgentInteractionParams _ => 1,
            _ => -1,
        };
    }
}

sealed class BodyConverter : JsonConverter<Body>
{
    public override Body? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<CreateModelInteractionParams>(
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
            var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParams>(
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

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Body value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Parameters for creating model interactions
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CreateModelInteractionParams, CreateModelInteractionParamsFromRaw>)
)]
public sealed record class CreateModelInteractionParams : JsonModel
{
    /// <summary>
    /// The input for the interaction.
    /// </summary>
    public Input Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Input>("input");
        }
        init { this._rawData.Set("input", value); }
    }

    /// <summary>
    /// The name of the `Model` used for generating the interaction.
    /// </summary>
    public ApiEnum<string, Model> Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Model>>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    /// <summary>
    /// Required. Output only. A unique identifier for the interaction completion.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Input only. Whether to run the model interaction in the background.
    /// </summary>
    public bool? Background
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("background");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("background", value);
        }
    }

    /// <summary>
    /// Required. Output only. The time at which the response was created in ISO 8601
    /// format (YYYY-MM-DDThh:mm:ssZ).
    /// </summary>
    public DateTimeOffset? Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created", value);
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
    public IReadOnlyList<ApiEnum<string, ResponseModality>>? ResponseModalities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, ResponseModality>>
            >("response_modalities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, ResponseModality>>?>(
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
    public ApiEnum<string, ServiceTier>? ServiceTier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ServiceTier>>("service_tier");
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
    /// Required. Output only. The status of the interaction.
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>("status");
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
    /// Input only. Whether to store the response and request for later retrieval.
    /// </summary>
    public bool? Store
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("store");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("store", value);
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
    /// Required. Output only. The time at which the response was last updated in
    /// ISO 8601 format (YYYY-MM-DDThh:mm:ssZ).
    /// </summary>
    public DateTimeOffset? Updated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated", value);
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
    public WebhookConfig? WebhookConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebhookConfig>("webhook_config");
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
        this.Input.Validate();
        this.Model.Raw();
        _ = this.ID;
        _ = this.Background;
        _ = this.Created;
        this.GenerationConfig?.Validate();
        foreach (var item in this.Outputs ?? Enumerable.Empty<Content>())
        {
            item.Validate();
        }
        _ = this.PreviousInteractionID;
        _ = this.ResponseFormat;
        _ = this.ResponseMimeType;
        foreach (
            var item in this.ResponseModalities
                ?? Enumerable.Empty<ApiEnum<string, ResponseModality>>()
        )
        {
            item.Validate();
        }
        _ = this.Role;
        this.ServiceTier?.Validate();
        this.Status?.Validate();
        _ = this.Store;
        _ = this.SystemInstruction;
        foreach (var item in this.Tools ?? Enumerable.Empty<Tool>())
        {
            item.Validate();
        }
        _ = this.Updated;
        this.Usage?.Validate();
        this.WebhookConfig?.Validate();
    }

    public CreateModelInteractionParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreateModelInteractionParams(CreateModelInteractionParams createModelInteractionParams)
        : base(createModelInteractionParams) { }
#pragma warning restore CS8618

    public CreateModelInteractionParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreateModelInteractionParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreateModelInteractionParamsFromRaw.FromRawUnchecked"/>
    public static CreateModelInteractionParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreateModelInteractionParamsFromRaw : IFromRawJson<CreateModelInteractionParams>
{
    /// <inheritdoc/>
    public CreateModelInteractionParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreateModelInteractionParams.FromRawUnchecked(rawData);
}

/// <summary>
/// The input for the interaction.
/// </summary>
[JsonConverter(typeof(InputConverter))]
public record class Input : ModelBase
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

    public Input(IReadOnlyList<Content> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Input(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(IReadOnlyList<Turn> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Input(TextContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(ImageContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(AudioContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(DocumentContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(VideoContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(ThoughtContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(FunctionCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(CodeExecutionCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(UrlContextCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(McpServerToolCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(GoogleSearchCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(FileSearchCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(GoogleMapsCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(FunctionResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(CodeExecutionResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(UrlContextResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(GoogleSearchResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(McpServerToolResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(FileSearchResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(GoogleMapsResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Input(JsonElement element)
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
                    "Data did not match any variant of Input"
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
                "Data did not match any variant of Input"
            ),
        };
    }

    public static implicit operator Input(List<Content> value) =>
        new((IReadOnlyList<Content>)value);

    public static implicit operator Input(string value) => new(value);

    public static implicit operator Input(List<Turn> value) => new((IReadOnlyList<Turn>)value);

    public static implicit operator Input(TextContent value) => new(value);

    public static implicit operator Input(ImageContent value) => new(value);

    public static implicit operator Input(AudioContent value) => new(value);

    public static implicit operator Input(DocumentContent value) => new(value);

    public static implicit operator Input(VideoContent value) => new(value);

    public static implicit operator Input(ThoughtContent value) => new(value);

    public static implicit operator Input(FunctionCallContent value) => new(value);

    public static implicit operator Input(CodeExecutionCallContent value) => new(value);

    public static implicit operator Input(UrlContextCallContent value) => new(value);

    public static implicit operator Input(McpServerToolCallContent value) => new(value);

    public static implicit operator Input(GoogleSearchCallContent value) => new(value);

    public static implicit operator Input(FileSearchCallContent value) => new(value);

    public static implicit operator Input(GoogleMapsCallContent value) => new(value);

    public static implicit operator Input(FunctionResultContent value) => new(value);

    public static implicit operator Input(CodeExecutionResultContent value) => new(value);

    public static implicit operator Input(UrlContextResultContent value) => new(value);

    public static implicit operator Input(GoogleSearchResultContent value) => new(value);

    public static implicit operator Input(McpServerToolResultContent value) => new(value);

    public static implicit operator Input(FileSearchResultContent value) => new(value);

    public static implicit operator Input(GoogleMapsResultContent value) => new(value);

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
                "Data did not match any variant of Input"
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

    public virtual bool Equals(Input? other) =>
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

sealed class InputConverter : JsonConverter<Input>
{
    public override Input? Read(
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

    public override void Write(Utf8JsonWriter writer, Input value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ResponseModalityConverter))]
public enum ResponseModality
{
    Text,
    Image,
    Audio,
    Video,
    Document,
}

sealed class ResponseModalityConverter : JsonConverter<ResponseModality>
{
    public override ResponseModality Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => ResponseModality.Text,
            "image" => ResponseModality.Image,
            "audio" => ResponseModality.Audio,
            "video" => ResponseModality.Video,
            "document" => ResponseModality.Document,
            _ => (ResponseModality)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResponseModality value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ResponseModality.Text => "text",
                ResponseModality.Image => "image",
                ResponseModality.Audio => "audio",
                ResponseModality.Video => "video",
                ResponseModality.Document => "document",
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
[JsonConverter(typeof(ServiceTierConverter))]
public enum ServiceTier
{
    Flex,
    Standard,
    Priority,
}

sealed class ServiceTierConverter : JsonConverter<ServiceTier>
{
    public override ServiceTier Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "flex" => ServiceTier.Flex,
            "standard" => ServiceTier.Standard,
            "priority" => ServiceTier.Priority,
            _ => (ServiceTier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ServiceTier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ServiceTier.Flex => "flex",
                ServiceTier.Standard => "standard",
                ServiceTier.Priority => "priority",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Required. Output only. The status of the interaction.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    InProgress,
    RequiresAction,
    Completed,
    Failed,
    Cancelled,
    Incomplete,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in_progress" => Status.InProgress,
            "requires_action" => Status.RequiresAction,
            "completed" => Status.Completed,
            "failed" => Status.Failed,
            "cancelled" => Status.Cancelled,
            "incomplete" => Status.Incomplete,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.InProgress => "in_progress",
                Status.RequiresAction => "requires_action",
                Status.Completed => "completed",
                Status.Failed => "failed",
                Status.Cancelled => "cancelled",
                Status.Incomplete => "incomplete",
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
[JsonConverter(typeof(JsonModelConverter<WebhookConfig, WebhookConfigFromRaw>))]
public sealed record class WebhookConfig : JsonModel
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

    public WebhookConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookConfig(WebhookConfig webhookConfig)
        : base(webhookConfig) { }
#pragma warning restore CS8618

    public WebhookConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookConfigFromRaw.FromRawUnchecked"/>
    public static WebhookConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookConfigFromRaw : IFromRawJson<WebhookConfig>
{
    /// <inheritdoc/>
    public WebhookConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhookConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Parameters for creating agent interactions
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CreateAgentInteractionParams, CreateAgentInteractionParamsFromRaw>)
)]
public sealed record class CreateAgentInteractionParams : JsonModel
{
    /// <summary>
    /// The name of the `Agent` used for generating the interaction.
    /// </summary>
    public ApiEnum<string, Agent> Agent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Agent>>("agent");
        }
        init { this._rawData.Set("agent", value); }
    }

    /// <summary>
    /// The input for the interaction.
    /// </summary>
    public CreateAgentInteractionParamsInput Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CreateAgentInteractionParamsInput>("input");
        }
        init { this._rawData.Set("input", value); }
    }

    /// <summary>
    /// Required. Output only. A unique identifier for the interaction completion.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Configuration parameters for the agent interaction.
    /// </summary>
    public AgentConfig? AgentConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentConfig>("agent_config");
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
    /// Input only. Whether to run the model interaction in the background.
    /// </summary>
    public bool? Background
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("background");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("background", value);
        }
    }

    /// <summary>
    /// Required. Output only. The time at which the response was created in ISO 8601
    /// format (YYYY-MM-DDThh:mm:ssZ).
    /// </summary>
    public DateTimeOffset? Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created", value);
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
    public IReadOnlyList<
        ApiEnum<string, CreateAgentInteractionParamsResponseModality>
    >? ResponseModalities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, CreateAgentInteractionParamsResponseModality>>
            >("response_modalities");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<
                ApiEnum<string, CreateAgentInteractionParamsResponseModality>
            >?>(
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
    public ApiEnum<string, CreateAgentInteractionParamsServiceTier>? ServiceTier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CreateAgentInteractionParamsServiceTier>
            >("service_tier");
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
    /// Required. Output only. The status of the interaction.
    /// </summary>
    public ApiEnum<string, CreateAgentInteractionParamsStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, CreateAgentInteractionParamsStatus>
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
    /// Input only. Whether to store the response and request for later retrieval.
    /// </summary>
    public bool? Store
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("store");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("store", value);
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
    /// Required. Output only. The time at which the response was last updated in
    /// ISO 8601 format (YYYY-MM-DDThh:mm:ssZ).
    /// </summary>
    public DateTimeOffset? Updated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated", value);
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
    public CreateAgentInteractionParamsWebhookConfig? WebhookConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreateAgentInteractionParamsWebhookConfig>(
                "webhook_config"
            );
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
        this.Agent.Raw();
        this.Input.Validate();
        _ = this.ID;
        this.AgentConfig?.Validate();
        _ = this.Background;
        _ = this.Created;
        foreach (var item in this.Outputs ?? Enumerable.Empty<Content>())
        {
            item.Validate();
        }
        _ = this.PreviousInteractionID;
        _ = this.ResponseFormat;
        _ = this.ResponseMimeType;
        foreach (
            var item in this.ResponseModalities
                ?? Enumerable.Empty<ApiEnum<string, CreateAgentInteractionParamsResponseModality>>()
        )
        {
            item.Validate();
        }
        _ = this.Role;
        this.ServiceTier?.Validate();
        this.Status?.Validate();
        _ = this.Store;
        _ = this.SystemInstruction;
        foreach (var item in this.Tools ?? Enumerable.Empty<Tool>())
        {
            item.Validate();
        }
        _ = this.Updated;
        this.Usage?.Validate();
        this.WebhookConfig?.Validate();
    }

    public CreateAgentInteractionParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreateAgentInteractionParams(CreateAgentInteractionParams createAgentInteractionParams)
        : base(createAgentInteractionParams) { }
#pragma warning restore CS8618

    public CreateAgentInteractionParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreateAgentInteractionParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreateAgentInteractionParamsFromRaw.FromRawUnchecked"/>
    public static CreateAgentInteractionParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreateAgentInteractionParamsFromRaw : IFromRawJson<CreateAgentInteractionParams>
{
    /// <inheritdoc/>
    public CreateAgentInteractionParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreateAgentInteractionParams.FromRawUnchecked(rawData);
}

/// <summary>
/// The name of the `Agent` used for generating the interaction.
/// </summary>
[JsonConverter(typeof(AgentConverter))]
public enum Agent
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

sealed class AgentConverter : JsonConverter<Agent>
{
    public override Agent Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deep-research-pro-preview-12-2025" => Agent.DeepResearchProPreview12_2025,
            "deep-research-preview-04-2026" => Agent.DeepResearchPreview04_2026,
            "deep-research-max-preview-04-2026" => Agent.DeepResearchMaxPreview04_2026,
            _ => (Agent)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Agent value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Agent.DeepResearchProPreview12_2025 => "deep-research-pro-preview-12-2025",
                Agent.DeepResearchPreview04_2026 => "deep-research-preview-04-2026",
                Agent.DeepResearchMaxPreview04_2026 => "deep-research-max-preview-04-2026",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The input for the interaction.
/// </summary>
[JsonConverter(typeof(CreateAgentInteractionParamsInputConverter))]
public record class CreateAgentInteractionParamsInput : ModelBase
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

    public CreateAgentInteractionParamsInput(
        IReadOnlyList<Content> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(IReadOnlyList<Turn> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(TextContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(ImageContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(AudioContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(DocumentContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(VideoContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(ThoughtContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(FunctionCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(
        CodeExecutionCallContent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(
        UrlContextCallContent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(
        McpServerToolCallContent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(
        GoogleSearchCallContent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(
        FileSearchCallContent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(
        GoogleMapsCallContent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(
        FunctionResultContent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(
        CodeExecutionResultContent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(
        UrlContextResultContent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(
        GoogleSearchResultContent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(
        McpServerToolResultContent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(
        FileSearchResultContent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(
        GoogleMapsResultContent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CreateAgentInteractionParamsInput(JsonElement element)
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
                    "Data did not match any variant of CreateAgentInteractionParamsInput"
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
                "Data did not match any variant of CreateAgentInteractionParamsInput"
            ),
        };
    }

    public static implicit operator CreateAgentInteractionParamsInput(List<Content> value) =>
        new((IReadOnlyList<Content>)value);

    public static implicit operator CreateAgentInteractionParamsInput(string value) => new(value);

    public static implicit operator CreateAgentInteractionParamsInput(List<Turn> value) =>
        new((IReadOnlyList<Turn>)value);

    public static implicit operator CreateAgentInteractionParamsInput(TextContent value) =>
        new(value);

    public static implicit operator CreateAgentInteractionParamsInput(ImageContent value) =>
        new(value);

    public static implicit operator CreateAgentInteractionParamsInput(AudioContent value) =>
        new(value);

    public static implicit operator CreateAgentInteractionParamsInput(DocumentContent value) =>
        new(value);

    public static implicit operator CreateAgentInteractionParamsInput(VideoContent value) =>
        new(value);

    public static implicit operator CreateAgentInteractionParamsInput(ThoughtContent value) =>
        new(value);

    public static implicit operator CreateAgentInteractionParamsInput(FunctionCallContent value) =>
        new(value);

    public static implicit operator CreateAgentInteractionParamsInput(
        CodeExecutionCallContent value
    ) => new(value);

    public static implicit operator CreateAgentInteractionParamsInput(
        UrlContextCallContent value
    ) => new(value);

    public static implicit operator CreateAgentInteractionParamsInput(
        McpServerToolCallContent value
    ) => new(value);

    public static implicit operator CreateAgentInteractionParamsInput(
        GoogleSearchCallContent value
    ) => new(value);

    public static implicit operator CreateAgentInteractionParamsInput(
        FileSearchCallContent value
    ) => new(value);

    public static implicit operator CreateAgentInteractionParamsInput(
        GoogleMapsCallContent value
    ) => new(value);

    public static implicit operator CreateAgentInteractionParamsInput(
        FunctionResultContent value
    ) => new(value);

    public static implicit operator CreateAgentInteractionParamsInput(
        CodeExecutionResultContent value
    ) => new(value);

    public static implicit operator CreateAgentInteractionParamsInput(
        UrlContextResultContent value
    ) => new(value);

    public static implicit operator CreateAgentInteractionParamsInput(
        GoogleSearchResultContent value
    ) => new(value);

    public static implicit operator CreateAgentInteractionParamsInput(
        McpServerToolResultContent value
    ) => new(value);

    public static implicit operator CreateAgentInteractionParamsInput(
        FileSearchResultContent value
    ) => new(value);

    public static implicit operator CreateAgentInteractionParamsInput(
        GoogleMapsResultContent value
    ) => new(value);

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
                "Data did not match any variant of CreateAgentInteractionParamsInput"
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

    public virtual bool Equals(CreateAgentInteractionParamsInput? other) =>
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

sealed class CreateAgentInteractionParamsInputConverter
    : JsonConverter<CreateAgentInteractionParamsInput>
{
    public override CreateAgentInteractionParamsInput? Read(
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
        CreateAgentInteractionParamsInput value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Configuration parameters for the agent interaction.
/// </summary>
[JsonConverter(typeof(AgentConfigConverter))]
public record class AgentConfig : ModelBase
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

    public AgentConfig(DynamicAgentConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentConfig(DeepResearchAgentConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentConfig(JsonElement element)
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
                    "Data did not match any variant of AgentConfig"
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
                "Data did not match any variant of AgentConfig"
            ),
        };
    }

    public static implicit operator AgentConfig(DynamicAgentConfig value) => new(value);

    public static implicit operator AgentConfig(DeepResearchAgentConfig value) => new(value);

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
                "Data did not match any variant of AgentConfig"
            );
        }
        this.Switch((dynamic) => dynamic.Validate(), (deepResearch) => deepResearch.Validate());
    }

    public virtual bool Equals(AgentConfig? other) =>
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

sealed class AgentConfigConverter : JsonConverter<AgentConfig>
{
    public override AgentConfig? Read(
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
                return new AgentConfig(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(CreateAgentInteractionParamsResponseModalityConverter))]
public enum CreateAgentInteractionParamsResponseModality
{
    Text,
    Image,
    Audio,
    Video,
    Document,
}

sealed class CreateAgentInteractionParamsResponseModalityConverter
    : JsonConverter<CreateAgentInteractionParamsResponseModality>
{
    public override CreateAgentInteractionParamsResponseModality Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => CreateAgentInteractionParamsResponseModality.Text,
            "image" => CreateAgentInteractionParamsResponseModality.Image,
            "audio" => CreateAgentInteractionParamsResponseModality.Audio,
            "video" => CreateAgentInteractionParamsResponseModality.Video,
            "document" => CreateAgentInteractionParamsResponseModality.Document,
            _ => (CreateAgentInteractionParamsResponseModality)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreateAgentInteractionParamsResponseModality value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreateAgentInteractionParamsResponseModality.Text => "text",
                CreateAgentInteractionParamsResponseModality.Image => "image",
                CreateAgentInteractionParamsResponseModality.Audio => "audio",
                CreateAgentInteractionParamsResponseModality.Video => "video",
                CreateAgentInteractionParamsResponseModality.Document => "document",
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
[JsonConverter(typeof(CreateAgentInteractionParamsServiceTierConverter))]
public enum CreateAgentInteractionParamsServiceTier
{
    Flex,
    Standard,
    Priority,
}

sealed class CreateAgentInteractionParamsServiceTierConverter
    : JsonConverter<CreateAgentInteractionParamsServiceTier>
{
    public override CreateAgentInteractionParamsServiceTier Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "flex" => CreateAgentInteractionParamsServiceTier.Flex,
            "standard" => CreateAgentInteractionParamsServiceTier.Standard,
            "priority" => CreateAgentInteractionParamsServiceTier.Priority,
            _ => (CreateAgentInteractionParamsServiceTier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreateAgentInteractionParamsServiceTier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreateAgentInteractionParamsServiceTier.Flex => "flex",
                CreateAgentInteractionParamsServiceTier.Standard => "standard",
                CreateAgentInteractionParamsServiceTier.Priority => "priority",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Required. Output only. The status of the interaction.
/// </summary>
[JsonConverter(typeof(CreateAgentInteractionParamsStatusConverter))]
public enum CreateAgentInteractionParamsStatus
{
    InProgress,
    RequiresAction,
    Completed,
    Failed,
    Cancelled,
    Incomplete,
}

sealed class CreateAgentInteractionParamsStatusConverter
    : JsonConverter<CreateAgentInteractionParamsStatus>
{
    public override CreateAgentInteractionParamsStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in_progress" => CreateAgentInteractionParamsStatus.InProgress,
            "requires_action" => CreateAgentInteractionParamsStatus.RequiresAction,
            "completed" => CreateAgentInteractionParamsStatus.Completed,
            "failed" => CreateAgentInteractionParamsStatus.Failed,
            "cancelled" => CreateAgentInteractionParamsStatus.Cancelled,
            "incomplete" => CreateAgentInteractionParamsStatus.Incomplete,
            _ => (CreateAgentInteractionParamsStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CreateAgentInteractionParamsStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CreateAgentInteractionParamsStatus.InProgress => "in_progress",
                CreateAgentInteractionParamsStatus.RequiresAction => "requires_action",
                CreateAgentInteractionParamsStatus.Completed => "completed",
                CreateAgentInteractionParamsStatus.Failed => "failed",
                CreateAgentInteractionParamsStatus.Cancelled => "cancelled",
                CreateAgentInteractionParamsStatus.Incomplete => "incomplete",
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
    typeof(JsonModelConverter<
        CreateAgentInteractionParamsWebhookConfig,
        CreateAgentInteractionParamsWebhookConfigFromRaw
    >)
)]
public sealed record class CreateAgentInteractionParamsWebhookConfig : JsonModel
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

    public CreateAgentInteractionParamsWebhookConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreateAgentInteractionParamsWebhookConfig(
        CreateAgentInteractionParamsWebhookConfig createAgentInteractionParamsWebhookConfig
    )
        : base(createAgentInteractionParamsWebhookConfig) { }
#pragma warning restore CS8618

    public CreateAgentInteractionParamsWebhookConfig(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreateAgentInteractionParamsWebhookConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreateAgentInteractionParamsWebhookConfigFromRaw.FromRawUnchecked"/>
    public static CreateAgentInteractionParamsWebhookConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreateAgentInteractionParamsWebhookConfigFromRaw
    : IFromRawJson<CreateAgentInteractionParamsWebhookConfig>
{
    /// <inheritdoc/>
    public CreateAgentInteractionParamsWebhookConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreateAgentInteractionParamsWebhookConfig.FromRawUnchecked(rawData);
}
