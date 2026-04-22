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
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// Citation information for model-generated content.
/// </summary>
[JsonConverter(typeof(AnnotationConverter))]
public record class Annotation : ModelBase
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
        get
        {
            return Match(
                urlCitation: (x) => x.Type,
                fileCitation: (x) => x.Type,
                placeCitation: (x) => x.Type
            );
        }
    }

    public int? EndIndex
    {
        get
        {
            return Match<int?>(
                urlCitation: (x) => x.EndIndex,
                fileCitation: (x) => x.EndIndex,
                placeCitation: (x) => x.EndIndex
            );
        }
    }

    public int? StartIndex
    {
        get
        {
            return Match<int?>(
                urlCitation: (x) => x.StartIndex,
                fileCitation: (x) => x.StartIndex,
                placeCitation: (x) => x.StartIndex
            );
        }
    }

    public string? Url
    {
        get
        {
            return Match<string?>(
                urlCitation: (x) => x.Url,
                fileCitation: (_) => null,
                placeCitation: (x) => x.Url
            );
        }
    }

    public Annotation(UrlCitation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Annotation(FileCitation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Annotation(PlaceCitation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Annotation(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UrlCitation"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUrlCitation(out var value)) {
    ///     // `value` is of type `UrlCitation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUrlCitation([NotNullWhen(true)] out UrlCitation? value)
    {
        value = this.Value as UrlCitation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FileCitation"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFileCitation(out var value)) {
    ///     // `value` is of type `FileCitation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFileCitation([NotNullWhen(true)] out FileCitation? value)
    {
        value = this.Value as FileCitation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PlaceCitation"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPlaceCitation(out var value)) {
    ///     // `value` is of type `PlaceCitation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPlaceCitation([NotNullWhen(true)] out PlaceCitation? value)
    {
        value = this.Value as PlaceCitation;
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
    ///     (UrlCitation value) =&gt; {...},
    ///     (FileCitation value) =&gt; {...},
    ///     (PlaceCitation value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<UrlCitation> urlCitation,
        Action<FileCitation> fileCitation,
        Action<PlaceCitation> placeCitation
    )
    {
        switch (this.Value)
        {
            case UrlCitation value:
                urlCitation(value);
                break;
            case FileCitation value:
                fileCitation(value);
                break;
            case PlaceCitation value:
                placeCitation(value);
                break;
            default:
                throw new GeminiNextGenApiInvalidDataException(
                    "Data did not match any variant of Annotation"
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
    ///     (UrlCitation value) =&gt; {...},
    ///     (FileCitation value) =&gt; {...},
    ///     (PlaceCitation value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<UrlCitation, T> urlCitation,
        Func<FileCitation, T> fileCitation,
        Func<PlaceCitation, T> placeCitation
    )
    {
        return this.Value switch
        {
            UrlCitation value => urlCitation(value),
            FileCitation value => fileCitation(value),
            PlaceCitation value => placeCitation(value),
            _ => throw new GeminiNextGenApiInvalidDataException(
                "Data did not match any variant of Annotation"
            ),
        };
    }

    public static implicit operator Annotation(UrlCitation value) => new(value);

    public static implicit operator Annotation(FileCitation value) => new(value);

    public static implicit operator Annotation(PlaceCitation value) => new(value);

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
                "Data did not match any variant of Annotation"
            );
        }
        this.Switch(
            (urlCitation) => urlCitation.Validate(),
            (fileCitation) => fileCitation.Validate(),
            (placeCitation) => placeCitation.Validate()
        );
    }

    public virtual bool Equals(Annotation? other) =>
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
            UrlCitation _ => 0,
            FileCitation _ => 1,
            PlaceCitation _ => 2,
            _ => -1,
        };
    }
}

sealed class AnnotationConverter : JsonConverter<Annotation>
{
    public override Annotation? Read(
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
            case "url_citation":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<UrlCitation>(element, options);
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
            case "file_citation":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<FileCitation>(element, options);
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
            case "place_citation":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PlaceCitation>(element, options);
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
                return new Annotation(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        Annotation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
