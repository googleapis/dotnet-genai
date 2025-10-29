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

namespace Microsoft.Extensions.AI;

/// <summary>Provides implementations of Microsoft.Extensions.AI abstractions based on <see cref="Client"/>.</summary>
public static class GoogleGenAIExtensions
{
  /// <summary>
  /// Creates an <see cref="IChatClient"/> wrapper around the specified <see cref="Client"/>.
  /// </summary>
  /// <param name="client">The <see cref="Client"/> to wrap.</param>
  /// <param name="defaultModelId">The default model ID to use for chat requests if not specified in <see cref="ChatOptions.ModelId"/>.</param>
  /// <returns>An <see cref="IChatClient"/> that wraps the specified client.</returns>
  /// <exception cref="ArgumentNullException"><paramref name="client"/> is <see langword="null"/>.</exception>
  public static IChatClient AsIChatClient(this Client client, string? defaultModelId = null)
  {
    Utilities.ThrowIfNull(client, nameof(client));
    return new GoogleGenAIChatClient(client, defaultModelId);
  }

  /// <summary>
  /// Creates an <see cref="IChatClient"/> wrapper around the specified <see cref="Models"/>.
  /// </summary>
  /// <param name="models">The <see cref="Models"/> client to wrap.</param>
  /// <param name="defaultModelId">The default model ID to use for chat requests if not specified in <see cref="ChatOptions.ModelId"/>.</param>
  /// <returns>An <see cref="IChatClient"/> that wraps the specified <see cref="Models"/> client.</returns>
  /// <exception cref="ArgumentNullException"><paramref name="models"/> is <see langword="null"/>.</exception>
  public static IChatClient AsIChatClient(this Models models, string? defaultModelId = null)
  {
    Utilities.ThrowIfNull(models, nameof(models));
    return new GoogleGenAIChatClient(models, defaultModelId);
  }

  /// <summary>
  /// Creates an <see cref="IImageGenerator"/> wrapper around the specified <see cref="Client"/>.
  /// </summary>
  /// <param name="client">The <see cref="Client"/> to wrap.</param>
  /// <param name="defaultModelId">The default model ID to use for image generation requests if not specified in <see cref="ImageGenerationOptions.ModelId"/>.</param>
  /// <returns>An <see cref="IImageGenerator"/> that wraps the specified client.</returns>
  /// <exception cref="ArgumentNullException"><paramref name="client"/> is <see langword="null"/>.</exception>
  public static IImageGenerator AsIImageGenerator(this Client client, string? defaultModelId = null)
  {
    Utilities.ThrowIfNull(client, nameof(client));
    return new GoogleGenAIImageGenerator(client, defaultModelId);
  }

  /// <summary>
  /// Creates an <see cref="IImageGenerator"/> wrapper around the specified <see cref="Models"/>.
  /// </summary>
  /// <param name="models">The <see cref="Models"/> client to wrap.</param>
  /// <param name="defaultModelId">The default model ID to use for image generation requests if not specified in <see cref="ImageGenerationOptions.ModelId"/>.</param>
  /// <returns>An <see cref="IImageGenerator"/> that wraps the specified <see cref="Models"/> client.</returns>
  /// <exception cref="ArgumentNullException"><paramref name="models"/> is <see langword="null"/>.</exception>
  public static IImageGenerator AsIImageGenerator(this Models models, string? defaultModelId = null)
  {
    Utilities.ThrowIfNull(models, nameof(models));
    return new GoogleGenAIImageGenerator(models, defaultModelId);
  }

  /// <summary>
  /// Creates an <see cref="IEmbeddingGenerator"/> wrapper around the specified <see cref="Client"/>.
  /// </summary>
  /// <param name="client">The <see cref="Client"/> to wrap.</param>
  /// <param name="defaultModelId">The default model ID to use for image generation requests if not specified in <see cref="ImageGenerationOptions.ModelId"/>.</param>
  /// <param name="defaultModelDimensions">The number of dimensions to generate in each embedding.</param>
  /// <returns>An <see cref="IEmbeddingGenerator"/> that wraps the specified client.</returns>
  /// <exception cref="ArgumentNullException"><paramref name="client"/> is <see langword="null"/>.</exception>
  public static IEmbeddingGenerator<string, Embedding<float>> AsIEmbeddingGenerator(
    this Client client, string? defaultModelId = null, int? defaultModelDimensions = null)
  {
    Utilities.ThrowIfNull(client, nameof(client));
    return new GoogleGenAIEmbeddingGenerator(client, defaultModelId, defaultModelDimensions);
  }

  /// <summary>
  /// Creates an <see cref="IEmbeddingGenerator"/> wrapper around the specified <see cref="Models"/>.
  /// </summary>
  /// <param name="models">The <see cref="Models"/> client to wrap.</param>
  /// <param name="defaultModelId">The default model ID to use for image generation requests if not specified in <see cref="ImageGenerationOptions.ModelId"/>.</param>
  /// <param name="defaultModelDimensions">The number of dimensions to generate in each embedding.</param>
  /// <returns>An <see cref="IEmbeddingGenerator"/> that wraps the specified <see cref="Models"/> client.</returns>
  /// <exception cref="ArgumentNullException"><paramref name="models"/> is <see langword="null"/>.</exception>
  public static IEmbeddingGenerator<string, Embedding<float>> AsIEmbeddingGenerator(
    this Models models, string? defaultModelId = null, int? defaultModelDimensions = null)
  {
    Utilities.ThrowIfNull(models, nameof(models));
    return new GoogleGenAIEmbeddingGenerator(models, defaultModelId, defaultModelDimensions);
  }
}
