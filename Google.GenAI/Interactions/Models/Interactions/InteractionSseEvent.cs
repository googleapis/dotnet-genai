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

[JsonConverter(typeof(InteractionSseEventConverter))]
public record class InteractionSseEvent : ModelBase
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

    public JsonElement EventType
    {
        get
        {
            return Match(
                start: (x) => x.EventType,
                complete: (x) => x.EventType,
                statusUpdate: (x) => x.EventType,
                contentStart: (x) => x.EventType,
                contentDelta: (x) => x.EventType,
                contentStop: (x) => x.EventType,
                error: (x) => x.EventType
            );
        }
    }

    public Interaction? Interaction
    {
        get
        {
            return Match<Interaction?>(
                start: (x) => x.Interaction,
                complete: (x) => x.Interaction,
                statusUpdate: (_) => null,
                contentStart: (_) => null,
                contentDelta: (_) => null,
                contentStop: (_) => null,
                error: (_) => null
            );
        }
    }

    public string? EventID
    {
        get
        {
            return Match<string?>(
                start: (x) => x.EventID,
                complete: (x) => x.EventID,
                statusUpdate: (x) => x.EventID,
                contentStart: (x) => x.EventID,
                contentDelta: (x) => x.EventID,
                contentStop: (x) => x.EventID,
                error: (x) => x.EventID
            );
        }
    }

    public int? Index
    {
        get
        {
            return Match<int?>(
                start: (_) => null,
                complete: (_) => null,
                statusUpdate: (_) => null,
                contentStart: (x) => x.Index,
                contentDelta: (x) => x.Index,
                contentStop: (x) => x.Index,
                error: (_) => null
            );
        }
    }

    public InteractionSseEvent(InteractionStartEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionSseEvent(InteractionCompleteEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionSseEvent(InteractionStatusUpdate value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionSseEvent(ContentStart value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionSseEvent(ContentDelta value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionSseEvent(ContentStop value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionSseEvent(ErrorEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InteractionSseEvent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="InteractionStartEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStart(out var value)) {
    ///     // `value` is of type `InteractionStartEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStart([NotNullWhen(true)] out InteractionStartEvent? value)
    {
        value = this.Value as InteractionStartEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="InteractionCompleteEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickComplete(out var value)) {
    ///     // `value` is of type `InteractionCompleteEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickComplete([NotNullWhen(true)] out InteractionCompleteEvent? value)
    {
        value = this.Value as InteractionCompleteEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="InteractionStatusUpdate"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStatusUpdate(out var value)) {
    ///     // `value` is of type `InteractionStatusUpdate`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStatusUpdate([NotNullWhen(true)] out InteractionStatusUpdate? value)
    {
        value = this.Value as InteractionStatusUpdate;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ContentStart"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickContentStart(out var value)) {
    ///     // `value` is of type `ContentStart`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickContentStart([NotNullWhen(true)] out ContentStart? value)
    {
        value = this.Value as ContentStart;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ContentDelta"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickContentDelta(out var value)) {
    ///     // `value` is of type `ContentDelta`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickContentDelta([NotNullWhen(true)] out ContentDelta? value)
    {
        value = this.Value as ContentDelta;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ContentStop"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickContentStop(out var value)) {
    ///     // `value` is of type `ContentStop`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickContentStop([NotNullWhen(true)] out ContentStop? value)
    {
        value = this.Value as ContentStop;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ErrorEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickError(out var value)) {
    ///     // `value` is of type `ErrorEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickError([NotNullWhen(true)] out ErrorEvent? value)
    {
        value = this.Value as ErrorEvent;
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
    ///     (InteractionStartEvent value) =&gt; {...},
    ///     (InteractionCompleteEvent value) =&gt; {...},
    ///     (InteractionStatusUpdate value) =&gt; {...},
    ///     (ContentStart value) =&gt; {...},
    ///     (ContentDelta value) =&gt; {...},
    ///     (ContentStop value) =&gt; {...},
    ///     (ErrorEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<InteractionStartEvent> start,
        Action<InteractionCompleteEvent> complete,
        Action<InteractionStatusUpdate> statusUpdate,
        Action<ContentStart> contentStart,
        Action<ContentDelta> contentDelta,
        Action<ContentStop> contentStop,
        Action<ErrorEvent> error
    )
    {
        switch (this.Value)
        {
            case InteractionStartEvent value:
                start(value);
                break;
            case InteractionCompleteEvent value:
                complete(value);
                break;
            case InteractionStatusUpdate value:
                statusUpdate(value);
                break;
            case ContentStart value:
                contentStart(value);
                break;
            case ContentDelta value:
                contentDelta(value);
                break;
            case ContentStop value:
                contentStop(value);
                break;
            case ErrorEvent value:
                error(value);
                break;
            default:
                throw new GeminiNextGenApiInvalidDataException(
                    "Data did not match any variant of InteractionSseEvent"
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
    ///     (InteractionStartEvent value) =&gt; {...},
    ///     (InteractionCompleteEvent value) =&gt; {...},
    ///     (InteractionStatusUpdate value) =&gt; {...},
    ///     (ContentStart value) =&gt; {...},
    ///     (ContentDelta value) =&gt; {...},
    ///     (ContentStop value) =&gt; {...},
    ///     (ErrorEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<InteractionStartEvent, T> start,
        Func<InteractionCompleteEvent, T> complete,
        Func<InteractionStatusUpdate, T> statusUpdate,
        Func<ContentStart, T> contentStart,
        Func<ContentDelta, T> contentDelta,
        Func<ContentStop, T> contentStop,
        Func<ErrorEvent, T> error
    )
    {
        return this.Value switch
        {
            InteractionStartEvent value => start(value),
            InteractionCompleteEvent value => complete(value),
            InteractionStatusUpdate value => statusUpdate(value),
            ContentStart value => contentStart(value),
            ContentDelta value => contentDelta(value),
            ContentStop value => contentStop(value),
            ErrorEvent value => error(value),
            _ => throw new GeminiNextGenApiInvalidDataException(
                "Data did not match any variant of InteractionSseEvent"
            ),
        };
    }

    public static implicit operator InteractionSseEvent(InteractionStartEvent value) => new(value);

    public static implicit operator InteractionSseEvent(InteractionCompleteEvent value) =>
        new(value);

    public static implicit operator InteractionSseEvent(InteractionStatusUpdate value) =>
        new(value);

    public static implicit operator InteractionSseEvent(ContentStart value) => new(value);

    public static implicit operator InteractionSseEvent(ContentDelta value) => new(value);

    public static implicit operator InteractionSseEvent(ContentStop value) => new(value);

    public static implicit operator InteractionSseEvent(ErrorEvent value) => new(value);

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
                "Data did not match any variant of InteractionSseEvent"
            );
        }
        this.Switch(
            (start) => start.Validate(),
            (complete) => complete.Validate(),
            (statusUpdate) => statusUpdate.Validate(),
            (contentStart) => contentStart.Validate(),
            (contentDelta) => contentDelta.Validate(),
            (contentStop) => contentStop.Validate(),
            (error) => error.Validate()
        );
    }

    public virtual bool Equals(InteractionSseEvent? other) =>
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
            InteractionStartEvent _ => 0,
            InteractionCompleteEvent _ => 1,
            InteractionStatusUpdate _ => 2,
            ContentStart _ => 3,
            ContentDelta _ => 4,
            ContentStop _ => 5,
            ErrorEvent _ => 6,
            _ => -1,
        };
    }
}

sealed class InteractionSseEventConverter : JsonConverter<InteractionSseEvent>
{
    public override InteractionSseEvent? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? eventType;
        try
        {
            eventType = element.GetProperty("event_type").GetString();
        }
        catch
        {
            eventType = null;
        }

        switch (eventType)
        {
            case "interaction.start":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<InteractionStartEvent>(
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
            case "interaction.complete":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<InteractionCompleteEvent>(
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
            case "interaction.status_update":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<InteractionStatusUpdate>(
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
            case "content.start":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ContentStart>(element, options);
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
            case "content.delta":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ContentDelta>(element, options);
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
            case "content.stop":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ContentStop>(element, options);
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
            case "error":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ErrorEvent>(element, options);
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
                return new InteractionSseEvent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        InteractionSseEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
