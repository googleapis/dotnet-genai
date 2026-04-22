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
/// Configuration parameters for model interactions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GenerationConfig, GenerationConfigFromRaw>))]
public sealed record class GenerationConfig : JsonModel
{
    /// <summary>
    /// Configuration for image interaction.
    /// </summary>
    public ImageConfig? ImageConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ImageConfig>("image_config");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("image_config", value);
        }
    }

    /// <summary>
    /// The maximum number of tokens to include in the response.
    /// </summary>
    public int? MaxOutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("max_output_tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("max_output_tokens", value);
        }
    }

    /// <summary>
    /// Seed used in decoding for reproducibility.
    /// </summary>
    public int? Seed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("seed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("seed", value);
        }
    }

    /// <summary>
    /// Configuration for speech interaction.
    /// </summary>
    public IReadOnlyList<SpeechConfig>? SpeechConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SpeechConfig>>("speech_config");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SpeechConfig>?>(
                "speech_config",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A list of character sequences that will stop output interaction.
    /// </summary>
    public IReadOnlyList<string>? StopSequences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("stop_sequences");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "stop_sequences",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Controls the randomness of the output.
    /// </summary>
    public float? Temperature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("temperature");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("temperature", value);
        }
    }

    /// <summary>
    /// The level of thought tokens that the model should generate.
    /// </summary>
    public ApiEnum<string, ThinkingLevel>? ThinkingLevel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ThinkingLevel>>("thinking_level");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("thinking_level", value);
        }
    }

    /// <summary>
    /// Whether to include thought summaries in the response.
    /// </summary>
    public ApiEnum<string, GenerationConfigThinkingSummaries>? ThinkingSummaries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, GenerationConfigThinkingSummaries>
            >("thinking_summaries");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("thinking_summaries", value);
        }
    }

    /// <summary>
    /// The tool choice configuration.
    /// </summary>
    public ToolChoice? ToolChoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ToolChoice>("tool_choice");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tool_choice", value);
        }
    }

    /// <summary>
    /// The maximum cumulative probability of tokens to consider when sampling.
    /// </summary>
    public float? TopP
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("top_p");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("top_p", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ImageConfig?.Validate();
        _ = this.MaxOutputTokens;
        _ = this.Seed;
        foreach (var item in this.SpeechConfig ?? Enumerable.Empty<SpeechConfig>())
        {
            item.Validate();
        }
        _ = this.StopSequences;
        _ = this.Temperature;
        this.ThinkingLevel?.Validate();
        this.ThinkingSummaries?.Validate();
        this.ToolChoice?.Validate();
        _ = this.TopP;
    }

    public GenerationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GenerationConfig(GenerationConfig generationConfig)
        : base(generationConfig) { }
#pragma warning restore CS8618

    public GenerationConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GenerationConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GenerationConfigFromRaw.FromRawUnchecked"/>
    public static GenerationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GenerationConfigFromRaw : IFromRawJson<GenerationConfig>
{
    /// <inheritdoc/>
    public GenerationConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GenerationConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether to include thought summaries in the response.
/// </summary>
[JsonConverter(typeof(GenerationConfigThinkingSummariesConverter))]
public enum GenerationConfigThinkingSummaries
{
    Auto,
    None,
}

sealed class GenerationConfigThinkingSummariesConverter
    : JsonConverter<GenerationConfigThinkingSummaries>
{
    public override GenerationConfigThinkingSummaries Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => GenerationConfigThinkingSummaries.Auto,
            "none" => GenerationConfigThinkingSummaries.None,
            _ => (GenerationConfigThinkingSummaries)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GenerationConfigThinkingSummaries value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GenerationConfigThinkingSummaries.Auto => "auto",
                GenerationConfigThinkingSummaries.None => "none",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The tool choice configuration.
/// </summary>
[JsonConverter(typeof(ToolChoiceConverter))]
public record class ToolChoice : ModelBase
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

    public ToolChoice(ApiEnum<string, ToolChoiceType> value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolChoice(ToolChoiceConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolChoice(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiEnum{TRaw, TEnum}"/> with a <c>TRaw</c> of <c>string</c> and a <c>TEnum</c> of ToolChoiceType>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickType(out var value)) {
    ///     // `value` is of type `ApiEnum&lt;string, ToolChoiceType&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickType([NotNullWhen(true)] out ApiEnum<string, ToolChoiceType>? value)
    {
        value = this.Value as ApiEnum<string, ToolChoiceType>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolChoiceConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickConfig(out var value)) {
    ///     // `value` is of type `ToolChoiceConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickConfig([NotNullWhen(true)] out ToolChoiceConfig? value)
    {
        value = this.Value as ToolChoiceConfig;
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
    ///     (ApiEnum&lt;string, ToolChoiceType&gt; value) =&gt; {...},
    ///     (ToolChoiceConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<ApiEnum<string, ToolChoiceType>> type,
        Action<ToolChoiceConfig> config
    )
    {
        switch (this.Value)
        {
            case ApiEnum<string, ToolChoiceType> value:
                type(value);
                break;
            case ToolChoiceConfig value:
                config(value);
                break;
            default:
                throw new GeminiNextGenApiInvalidDataException(
                    "Data did not match any variant of ToolChoice"
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
    ///     (ApiEnum&lt;string, ToolChoiceType&gt; value) =&gt; {...},
    ///     (ToolChoiceConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<ApiEnum<string, ToolChoiceType>, T> type,
        Func<ToolChoiceConfig, T> config
    )
    {
        return this.Value switch
        {
            ApiEnum<string, ToolChoiceType> value => type(value),
            ToolChoiceConfig value => config(value),
            _ => throw new GeminiNextGenApiInvalidDataException(
                "Data did not match any variant of ToolChoice"
            ),
        };
    }

    public static implicit operator ToolChoice(ApiEnum<string, ToolChoiceType> value) => new(value);

    public static implicit operator ToolChoice(ToolChoiceType value) => new(value);

    public static implicit operator ToolChoice(ToolChoiceConfig value) => new(value);

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
                "Data did not match any variant of ToolChoice"
            );
        }
        this.Switch((type) => type.Validate(), (config) => config.Validate());
    }

    public virtual bool Equals(ToolChoice? other) =>
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
            ApiEnum<string, ToolChoiceType> _ => 0,
            ToolChoiceConfig _ => 1,
            _ => -1,
        };
    }
}

sealed class ToolChoiceConverter : JsonConverter<ToolChoice>
{
    public override ToolChoice? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ToolChoiceType>>(
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
            var deserialized = JsonSerializer.Deserialize<ToolChoiceConfig>(element, options);
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

    public override void Write(
        Utf8JsonWriter writer,
        ToolChoice value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
