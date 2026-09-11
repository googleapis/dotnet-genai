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

using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

using Google.GenAI.Serialization;

namespace Google.GenAI
{
  /// <summary>
  /// Configuration for JSON serialization.
  /// </summary>
  internal static class JsonConfig
  {
    /// <summary>
    /// Options for external API output (indented, camelCase, no nulls).
    /// </summary>
    public static readonly JsonSerializerOptions JsonSerializerOptions = CreateOptions(writeIndented: true);

    /// <summary>
    /// Options for internal serialization (compact, camelCase, no nulls).
    /// Used for intermediate serialize-then-parse round-trips where indentation is wasteful.
    /// </summary>
    internal static readonly JsonSerializerOptions InternalSerializerOptions = CreateOptions(writeIndented: false);

    private static JsonSerializerOptions CreateOptions(bool writeIndented)
    {
      var options = new JsonSerializerOptions
      {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = writeIndented,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters =
            {
              new StringToLongConverter(),
              new StringToNullableLongConverter(),
            }
      };
      options.TypeInfoResolverChain.Add(GenAIJsonContext.Default);
      options.TypeInfoResolverChain.Add(Microsoft.Extensions.AI.AIJsonUtilities.DefaultOptions.TypeInfoResolver);
      return options;
    }

    /// <summary>
    /// Gets the source-generated TypeInfo for a given type T to ensure AOT compliance.
    /// </summary>
    internal static JsonTypeInfo<T> TypeInfo<T>(JsonSerializerOptions? options = null)
        => (JsonTypeInfo<T>)EnsureResolver(options).GetTypeInfo(typeof(T));

    /// <summary>
    /// Gets the source-generated TypeInfo for a given Type to ensure AOT compliance.
    /// </summary>
    internal static JsonTypeInfo TypeInfo(Type type, JsonSerializerOptions? options = null)
        => EnsureResolver(options).GetTypeInfo(type);

    private static readonly ConditionalWeakTable<JsonSerializerOptions, JsonSerializerOptions> _resolverCache = new();

    private static JsonSerializerOptions EnsureResolver(JsonSerializerOptions? options)
    {
      if (options == null)
      {
        return InternalSerializerOptions;
      }
      if (!options.IsReadOnly)
      {
        lock (options)
        {
          if (!options.TypeInfoResolverChain.Contains(GenAIJsonContext.Default))
          {
            options.TypeInfoResolverChain.Add(GenAIJsonContext.Default);
          }
        }
        return options;
      }
      if (options.TypeInfoResolverChain.Contains(GenAIJsonContext.Default))
      {
        return options;
      }
      return _resolverCache.GetValue(options, opt =>
      {
        var copy = new JsonSerializerOptions(opt);
        copy.TypeInfoResolverChain.Add(GenAIJsonContext.Default);
        return copy;
      });
    }
  }
}
