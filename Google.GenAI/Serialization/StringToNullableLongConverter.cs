/*
 * Copyright 2025 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Google.GenAI.Serialization
{
  internal class StringToNullableLongConverter : JsonConverter<long?>
  {
    public override long? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
      if (reader.TokenType == JsonTokenType.Null)
      {
        return null;
      }
      if (reader.TokenType == JsonTokenType.String)
      {
        string? stringValue = reader.GetString();
        if (string.IsNullOrEmpty(stringValue))
        {
          return null;
        }
        if (long.TryParse(stringValue, out long longValue))
        {
          return longValue;
        }
        throw new JsonException($"Could not parse string '{stringValue}' to long?.");
      }
      if (reader.TokenType == JsonTokenType.Number)
      {
        return reader.GetInt64();
      }
      throw new JsonException($"Unexpected token type {reader.TokenType} when parsing long?. Expected String, Number, or Null.");
    }

    public override void Write(Utf8JsonWriter writer, long? value, JsonSerializerOptions options)
    {
      if (value.HasValue)
      {
        writer.WriteNumberValue(value.Value);
      }
      else
      {
        writer.WriteNullValue();
      }
    }
  }
}
