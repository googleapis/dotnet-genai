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
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Google.GenAI.Interactions.Core;

sealed class FrozenDictionaryConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        if (!typeToConvert.IsGenericType)
        {
            return false;
        }

        var genericTypeDefinition = typeToConvert.GetGenericTypeDefinition();
        return genericTypeDefinition == typeof(FrozenDictionary<,>);
    }

    public override JsonConverter? CreateConverter(
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var keyType = typeToConvert.GetGenericArguments()[0];
        var valueType = typeToConvert.GetGenericArguments()[1];

        var converterType = typeof(FrozenDictionaryConverter<,>).MakeGenericType(
            keyType,
            valueType
        );
        return (JsonConverter?)Activator.CreateInstance(converterType);
    }
}

sealed class FrozenDictionaryConverter<TKey, TValue> : JsonConverter<FrozenDictionary<TKey, TValue>>
    where TKey : notnull
{
    public override FrozenDictionary<TKey, TValue>? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var dictionary = JsonSerializer.Deserialize<Dictionary<TKey, TValue>>(ref reader, options);
        if (dictionary == null)
        {
            return null;
        }

        return FrozenDictionary.ToFrozenDictionary(dictionary);
    }

    public override void Write(
        Utf8JsonWriter writer,
        FrozenDictionary<TKey, TValue> value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value, typeof(IReadOnlyDictionary<TKey, TValue>), options);
    }
}
