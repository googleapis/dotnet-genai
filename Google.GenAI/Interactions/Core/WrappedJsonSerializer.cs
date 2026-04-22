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

using System.Text.Json;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Core;

/// <summary>
/// Helper class for deserializing &lt;c&gt;JsonElement&lt;/c&gt; objects. This handles
/// edge-cases around nullability and reference/value types.
/// </summary>
sealed class WrappedJsonSerializer
{
    public static T GetNotNullClass<T>(JsonElement element, string name)
        where T : class
    {
        T deserialized;
        try
        {
            deserialized =
                JsonSerializer.Deserialize<T>(element, ModelBase.SerializerOptions)
                ?? throw new GeminiNextGenApiInvalidDataException($"'{name}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new GeminiNextGenApiInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }

    public static T GetNotNullStruct<T>(JsonElement element, string name)
        where T : struct
    {
        T deserialized;
        try
        {
            deserialized =
                JsonSerializer.Deserialize<T?>(element, ModelBase.SerializerOptions)
                ?? throw new GeminiNextGenApiInvalidDataException($"'{name}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new GeminiNextGenApiInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }

    public static T? GetNullableClass<T>(JsonElement element, string name)
        where T : class
    {
        T? deserialized;
        try
        {
            deserialized = JsonSerializer.Deserialize<T?>(element, ModelBase.SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new GeminiNextGenApiInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }

    public static T? GetNullableStruct<T>(JsonElement element, string name)
        where T : struct
    {
        T? deserialized;
        try
        {
            deserialized = JsonSerializer.Deserialize<T?>(element, ModelBase.SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new GeminiNextGenApiInvalidDataException(
                $"'{name}' must be of type {typeof(T).FullName}",
                e
            );
        }
        return deserialized;
    }
}
