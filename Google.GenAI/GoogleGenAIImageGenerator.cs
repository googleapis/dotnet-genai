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

using System.Drawing;

using Google.Apis.Util;
using Google.GenAI;
using Google.GenAI.Types;

namespace Microsoft.Extensions.AI;

/// <summary>Provides an <see cref="IImageGenerator"/> implementation based on <see cref="Client"/>.</summary>
internal sealed class GoogleGenAIImageGenerator : IImageGenerator
{
  /// <summary>The wrapped <see cref="Client"/> instance (optional).</summary>
  private readonly Client? _client;

  /// <summary>The wrapped <see cref="Models"/> instance.</summary>
  private readonly Models _models;

  /// <summary>The default model that should be used when no override is specified.</summary>
  private readonly string? _defaultModelId;

  /// <summary>Lazily-initialized metadata describing the implementation.</summary>
  private ImageGeneratorMetadata? _metadata;

  /// <summary>Initializes a new <see cref="GoogleGenAIImageGenerator"/> instance.</summary>
  public GoogleGenAIImageGenerator(Client client, string? defaultModelId)
  {
    _client = client;
    _models = client.Models;
    _defaultModelId = defaultModelId;
  }

  /// <summary>Initializes a new <see cref="GoogleGenAIImageGenerator"/> instance.</summary>
  public GoogleGenAIImageGenerator(Models client, string? defaultModelId)
  {
    _models = client;
    _defaultModelId = defaultModelId;
  }

  /// <inheritdoc />
  public async Task<ImageGenerationResponse> GenerateAsync(ImageGenerationRequest request, ImageGenerationOptions? options = null, CancellationToken cancellationToken = default)
  {
    Utilities.ThrowIfNull(request, nameof(request));

    string modelId = options?.ModelId ?? _defaultModelId ?? "";
    string prompt = request.Prompt ?? "";

    GenerateImagesConfig config = options?.RawRepresentationFactory?.Invoke(this) as GenerateImagesConfig ?? new();
    config.NumberOfImages ??= options?.Count ?? 1;
    config.OutputMimeType ??= options?.MediaType;
    config.AspectRatio ??= options?.ImageSize is { } imageSize && imageSize.Width > 0 && imageSize.Height > 0 ? GetClosestRatio(imageSize) : null;

    var gir = await _models.GenerateImagesAsync(modelId, prompt, config).ConfigureAwait(false);

    ImageGenerationResponse response = new()
    {
      RawRepresentation = gir
    };

    if (gir.GeneratedImages is { } generatedImages)
    {
      foreach (var generatedImage in generatedImages)
      {
        if (generatedImage.Image is { } image)
        {
          if (!string.IsNullOrEmpty(image.GcsUri))
          {
            response.Contents.Add(new UriContent(image.GcsUri, image.MimeType ?? "image/*"));
          }
          else if (image.ImageBytes is { } bytes)
          {
            response.Contents.Add(new DataContent(bytes, image.MimeType ?? "image/*"));
          }
        }
      }
    }

    return response;
  }

  /// <inheritdoc />
  public object? GetService(System.Type serviceType, object? serviceKey = null)
  {
    Utilities.ThrowIfNull(serviceType, nameof(serviceType));

    if (serviceKey is null)
    {
      // If there's a request for metadata, lazily-initialize it and return it. We don't need to worry about race conditions,
      // as there's no requirement that the same instance be returned each time, and creation is idempotent.
      if (serviceType == typeof(ImageGeneratorMetadata))
      {
        return _metadata ??= new("gcp.gen_ai", new("https://generativelanguage.googleapis.com/"), defaultModelId: _defaultModelId);
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

  private static string GetClosestRatio(Size size)
  {
    float ratio = (float)size.Width / size.Height;

    float closestDifference = float.MaxValue;
    string result = s_knownRatios[0].Name;

    foreach ((string knownRatioName, float knownRatioValue) in s_knownRatios)
    {
      float difference = Math.Abs(knownRatioValue - ratio);
      if (difference < closestDifference)
      {
        closestDifference = difference;
        result = knownRatioName;
      }
    }

    return result;
  }

  private static readonly (string Name, float Ratio)[] s_knownRatios = new[]
  {
    ("1:1", 1f),
    ("3:4", 3f / 4f),
    ("4:3", 4f / 3f),
    ("16:9", 16f / 9f),
    ("9:16", 9f / 16f),
  };
}
