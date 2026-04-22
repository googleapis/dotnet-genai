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
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Core;

/// <summary>
/// A serializable and deserializable enum wrapper type that handles the possibility of values outside the
/// range of known enum members.
///
/// <para>In most cases you don't have to worry about this type and can rely on its implicit operators to
/// wrap and unwrap enum values.</para>
/// </summary>
public record class ApiEnum<TRaw, TEnum>
    where TEnum : struct, Enum
{
    /// <summary>
    /// Returns this instance's raw value.
    ///
    /// <para>This is usually only useful if this instance was deserialized from data that doesn't match the
    /// expected type (<typeparamref name="TRaw"/>), and you want to know that value. For example, if the
    /// SDK is on an older version than the API, then the API may respond with new data types that the SDK is
    /// unaware of.
    /// </para>
    /// </summary>
    public JsonElement Json;

    public ApiEnum(JsonElement json)
    {
        Json = json;
    }

    /// <summary>
    /// Returns this instance's raw <typeparamref name="TRaw"/> value.
    ///
    /// <para>This is usually only useful if this instance was deserialized from data that doesn't match
    /// any known enum member, and you want to know that value. For example, if the SDK is on an older
    /// version than the API, then the API may respond with new members that the SDK is unaware of.</para>
    ///
    /// <exception cref="GeminiNextGenApiInvalidDataException">
    /// Thrown when this instance's raw value isn't of type <typeparamref name="TRaw"/>. Use
    /// <see cref="Json"/> to access the raw value.
    /// </exception>
    /// </summary>
    public TRaw Raw()
    {
        try
        {
            return JsonSerializer.Deserialize<TRaw>(this.Json, ModelBase.SerializerOptions)
                ?? throw new GeminiNextGenApiInvalidDataException(
                    $"{nameof(this.Json)} cannot be null"
                );
        }
        catch (JsonException e)
        {
            throw new GeminiNextGenApiInvalidDataException(
                $"{this.Json} must be of type {typeof(TRaw).FullName}",
                e
            );
        }
    }

    /// <summary>
    /// Returns an enum member corresponding to this instance's value, or <c>(TEnum)(-1)</c> if the
    /// class was instantiated with an unknown value.
    ///
    /// <para>Use <see cref="Raw"/> to access the raw <typeparamref name="TRaw"/> value.</para>.
    /// </summary>
    public TEnum Value()
    {
        try
        {
            return JsonSerializer.Deserialize<TEnum?>(this.Json, ModelBase.SerializerOptions)
                ?? throw new GeminiNextGenApiInvalidDataException(
                    $"{nameof(this.Json)} cannot be null"
                );
        }
        catch (JsonException e)
        {
            throw new GeminiNextGenApiInvalidDataException(
                $"{this.Json} must be of type {typeof(TRaw).FullName}",
                e
            );
        }
    }

    /// <summary>
    /// Verifies that this instance's raw value is a member of <typeparamref name="TEnum"/>.
    ///
    /// <exception cref="GeminiNextGenApiInvalidDataException">
    /// Thrown when this instance's raw value isn't a member of <typeparamref name="TEnum"/>.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (!Enum.IsDefined(typeof(TEnum), Value()))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid enum value");
        }
    }

    public virtual bool Equals(ApiEnum<TRaw, TEnum>? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    public override int GetHashCode()
    {
        return 0;
    }

    public static implicit operator TRaw(ApiEnum<TRaw, TEnum> value) => value.Raw();

    public static implicit operator TEnum(ApiEnum<TRaw, TEnum> value) => value.Value();

    public static implicit operator ApiEnum<TRaw, TEnum>(TRaw value) =>
        new(JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions));

    public static implicit operator ApiEnum<TRaw, TEnum>(TEnum value) =>
        new(JsonSerializer.SerializeToElement(value, ModelBase.SerializerOptions));
}

sealed class ApiEnumConverter<TRaw, TEnum> : JsonConverter<ApiEnum<TRaw, TEnum>>
    where TEnum : struct, Enum
{
    public override ApiEnum<TRaw, TEnum> Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApiEnum<TRaw, TEnum> value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
