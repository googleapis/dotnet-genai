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

using Google.Apis.Util;
using Google.GenAI;
using Google.GenAI.Types;

namespace Microsoft.Extensions.AI;

/// <summary>Provides an <see cref="IEmbeddingGenerator"/> implementation based on <see cref="Client"/>.</summary>
internal sealed class GoogleGenAIEmbeddingGenerator : IEmbeddingGenerator<string, Embedding<float>>
{
  /// <summary>The wrapped <see cref="Client"/> instance (optional).</summary>
  private readonly Client? _client;

  /// <summary>The wrapped <see cref="Models"/> instance.</summary>
  private readonly Models _models;

  /// <summary>The default model that should be used when no override is specified.</summary>
  private readonly string? _defaultModelId;

  /// <summary>The number of dimensions produced by the generator.</summary>
  private readonly int? _defaultModelDimensions;

  /// <summary>Lazily-initialized metadata describing the implementation.</summary>
  private EmbeddingGeneratorMetadata? _metadata;

  /// <summary>Initializes a new <see cref="GoogleGenAIEmbeddingGenerator"/> instance.</summary>
  public GoogleGenAIEmbeddingGenerator(
    Client client, string? defaultModelId, int? defaultModelDimensions)
  {
    _client = client;
    _models = client.Models;
    _defaultModelId = defaultModelId;
    _defaultModelDimensions = defaultModelDimensions;
  }

  /// <summary>Initializes a new <see cref="GoogleGenAIEmbeddingGenerator"/> instance.</summary>
  public GoogleGenAIEmbeddingGenerator(Models client, string? defaultModelId, int? defaultModelDimensions)
  {
    _models = client;
    _defaultModelId = defaultModelId;
    _defaultModelDimensions = defaultModelDimensions;
  }

  /// <inheritdoc />
  public async Task<GeneratedEmbeddings<Embedding<float>>> GenerateAsync(IEnumerable<string> values, EmbeddingGenerationOptions? options = null, CancellationToken cancellationToken = default)
  {
    Utilities.ThrowIfNull(values, nameof(values));

    string modelId = options?.ModelId ?? _defaultModelId ?? "";
    GeneratedEmbeddings<Embedding<float>> result = new();

    // Create the EmbedContentConfig object. If the options contains a RawRepresentationFactory, try to use it to
    // create the config instance, allowing the caller to populate it with Vertex-specific options. Otherwise, create
    // a new instance directly.
    EmbedContentConfig config = options?.RawRepresentationFactory?.Invoke(this) as EmbedContentConfig ?? new();
    config.OutputDimensionality ??= options?.Dimensions ?? _defaultModelDimensions;

    // Make the request.
    EmbedContentResponse response = await _models.EmbedContentAsync(
      modelId,
      values.Select(value => new Content() { Parts = new List<Part>() { new() { Text = value } } }).ToList(),
      config).ConfigureAwait(false);

    if (response.Embeddings is not null)
    {
      foreach (var embedding in response.Embeddings)
      {
        if (embedding.Statistics is { TokenCount: { } inputTokens } stats)
        {
          result.Usage ??= new();
          result.Usage.InputTokenCount = (result.Usage.InputTokenCount ?? 0) + (long)inputTokens;
        }

        if (embedding.Values is { } embeddingValues)
        {
          result.Add(new Embedding<float>(embeddingValues.Select(d => (float)d).ToArray())
          {
            CreatedAt = DateTimeOffset.UtcNow,
            ModelId = modelId,
          });
        }
      }
    }

    if (result.Usage is not null)
    {
      result.Usage.TotalTokenCount = result.Usage.InputTokenCount;
    }

    return result;
  }

  /// <inheritdoc />
  public object? GetService(System.Type serviceType, object? serviceKey = null)
  {
    Utilities.ThrowIfNull(serviceType, nameof(serviceType));

    if (serviceKey is null)
    {
      // If there's a request for metadata, lazily-initialize it and return it. We don't need to worry about race conditions,
      // as there's no requirement that the same instance be returned each time, and creation is idempotent.
      if (serviceType == typeof(EmbeddingGeneratorMetadata))
      {
        return _metadata ??= new(
          "gcp.gen_ai",
          new("https://generativelanguage.googleapis.com/"),
          _defaultModelId,
          _defaultModelDimensions);
      }

      // Allow a consumer to "break glass" and access the underlying client if they need it.
      if (serviceType.IsInstanceOfType(_models))
      {
        return _models;
      }

      if (_client is not null && serviceType.IsInstanceOfType(_client))
      {
        return _client;
      }

      if (serviceType.IsInstanceOfType(this))
      {
        return this;
      }
    }

    return null;
  }

  /// <inheritdoc />
  void IDisposable.Dispose() { /* nop */ }
}
