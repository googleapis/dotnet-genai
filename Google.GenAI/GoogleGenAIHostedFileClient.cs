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

using System.Runtime.CompilerServices;

using Google.Apis.Util;
using Google.GenAI;
using Google.GenAI.Types;

namespace Microsoft.Extensions.AI;

/// <summary>Provides an <see cref="IHostedFileClient"/> implementation based on <see cref="Client"/>.</summary>
internal sealed class GoogleGenAIHostedFileClient : IHostedFileClient
{
  /// <summary>The wrapped <see cref="Client"/> instance (optional).</summary>
  private readonly Client? _client;

  /// <summary>The wrapped <see cref="Files"/> instance.</summary>
  private readonly Files _files;

  /// <summary>Lazily-initialized metadata describing the implementation.</summary>
  private HostedFileClientMetadata? _metadata;

  /// <summary>Initializes a new <see cref="GoogleGenAIHostedFileClient"/> instance.</summary>
  public GoogleGenAIHostedFileClient(Client client)
  {
    _client = client;
    _files = client.Files;
  }

  /// <summary>Initializes a new <see cref="GoogleGenAIHostedFileClient"/> instance.</summary>
  public GoogleGenAIHostedFileClient(Files files)
  {
    _files = files;
  }

  /// <inheritdoc />
  public async Task<HostedFileContent> UploadAsync(
    Stream content,
    string? mediaType = null,
    string? fileName = null,
    HostedFileClientOptions? options = null,
    CancellationToken cancellationToken = default)
  {
    Utilities.ThrowIfNull(content, nameof(content));

    UploadFileConfig? config = options?.RawRepresentationFactory?.Invoke(this) as UploadFileConfig ?? new();
    config.MimeType ??= mediaType;
    config.DisplayName ??= fileName;

    // The Gemini upload API requires an accurate size. If the stream isn't seekable,
    // buffer it so we can determine the length.
    Stream uploadStream = content;
    long size;
    if (content.CanSeek)
    {
      size = content.Length - content.Position;
    }
    else
    {
      var buffer = new MemoryStream();
      await content.CopyToAsync(buffer
#if !NETSTANDARD2_0
        , cancellationToken
#endif
        ).ConfigureAwait(false);
      buffer.Position = 0;
      size = buffer.Length;
      uploadStream = buffer;
    }

    Google.GenAI.Types.File file = await _files.UploadAsync(uploadStream, size, fileName, mediaType, config, cancellationToken).ConfigureAwait(false);
    return ToHostedFileContent(file);
  }

  /// <inheritdoc />
  public async Task<HostedFileDownloadStream> DownloadAsync(
    string fileId,
    HostedFileClientOptions? options = null,
    CancellationToken cancellationToken = default)
  {
    Utilities.ThrowIfNull(fileId, nameof(fileId));

    // Get file metadata so we can populate MediaType and FileName on the download stream.
    Google.GenAI.Types.File fileInfo = await _files.GetAsync(fileId, cancellationToken: cancellationToken).ConfigureAwait(false);

    Stream stream = await _files.DownloadAsync(fileId, cancellationToken: cancellationToken).ConfigureAwait(false);

    return new GoogleGenAIHostedFileDownloadStream(stream, fileInfo.MimeType, fileInfo.DisplayName);
  }

  /// <inheritdoc />
  public async Task<HostedFileContent?> GetFileInfoAsync(
    string fileId,
    HostedFileClientOptions? options = null,
    CancellationToken cancellationToken = default)
  {
    Utilities.ThrowIfNull(fileId, nameof(fileId));

    Google.GenAI.Types.File file = await _files.GetAsync(fileId, cancellationToken: cancellationToken).ConfigureAwait(false);

    return ToHostedFileContent(file);
  }

  /// <inheritdoc />
  public async IAsyncEnumerable<HostedFileContent> ListFilesAsync(
    HostedFileClientOptions? options = null,
    [EnumeratorCancellation] CancellationToken cancellationToken = default)
  {
    ListFilesConfig? config = options?.RawRepresentationFactory?.Invoke(this) as ListFilesConfig;
    if (options?.Limit is { } limit)
    {
      (config ??= new()).PageSize ??= limit;
    }

    var pager = await _files.ListAsync(config, cancellationToken).ConfigureAwait(false);

    await foreach (var file in pager.WithCancellation(cancellationToken).ConfigureAwait(false))
    {
      yield return ToHostedFileContent(file);
    }
  }

  /// <inheritdoc />
  public async Task<bool> DeleteAsync(
    string fileId,
    HostedFileClientOptions? options = null,
    CancellationToken cancellationToken = default)
  {
    Utilities.ThrowIfNull(fileId, nameof(fileId));

    await _files.DeleteAsync(fileId, cancellationToken: cancellationToken).ConfigureAwait(false);
    return true;
  }

  /// <inheritdoc />
  public object? GetService(System.Type serviceType, object? serviceKey = null)
  {
    Utilities.ThrowIfNull(serviceType, nameof(serviceType));

    if (serviceKey is null)
    {
      if (serviceType == typeof(HostedFileClientMetadata))
      {
        return _metadata ??= new("gcp.gen_ai", new("https://generativelanguage.googleapis.com/"));
      }

      if (serviceType.IsInstanceOfType(_files))
      {
        return _files;
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

  /// <summary>Converts a Google <see cref="Google.GenAI.Types.File"/> to a <see cref="HostedFileContent"/>.</summary>
  private static HostedFileContent ToHostedFileContent(Google.GenAI.Types.File file)
  {
    HostedFileContent content = new(file.Name ?? throw new InvalidOperationException("File.Name is required"))
    {
      MediaType = file.MimeType,
      Name = file.DisplayName,
      RawRepresentation = file,
    };

    content.SizeInBytes = file.SizeBytes;
    content.CreatedAt = file.CreateTime;

    return content;
  }

  /// <summary>A <see cref="HostedFileDownloadStream"/> that wraps a <see cref="Stream"/> from the Google GenAI download API.</summary>
  private sealed class GoogleGenAIHostedFileDownloadStream : HostedFileDownloadStream
  {
    private readonly Stream _inner;

    public GoogleGenAIHostedFileDownloadStream(Stream inner, string? mediaType, string? fileName)
    {
      _inner = inner;
      MediaType = mediaType;
      FileName = fileName;
    }

    public override string? MediaType { get; }
    public override string? FileName { get; }

    public override bool CanRead => _inner.CanRead;
    public override bool CanSeek => _inner.CanSeek;
    public override bool CanWrite => false;
    public override long Length => _inner.Length;
    public override long Position { get => _inner.Position; set => _inner.Position = value; }

    public override void Flush() => _inner.Flush();
    public override int Read(byte[] buffer, int offset, int count) => _inner.Read(buffer, offset, count);
    public override long Seek(long offset, SeekOrigin origin) => _inner.Seek(offset, origin);

    public override int ReadByte() =>
      _inner.ReadByte();

    public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken) =>
      _inner.ReadAsync(buffer, offset, count, cancellationToken);

    public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback? callback, object? state) =>
      _inner.BeginRead(buffer, offset, count, callback, state);

    public override int EndRead(IAsyncResult asyncResult) =>
      _inner.EndRead(asyncResult);

    public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken) =>
      _inner.CopyToAsync(destination, bufferSize, cancellationToken);

    public override Task FlushAsync(CancellationToken cancellationToken) =>
      _inner.FlushAsync(cancellationToken);

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        _inner.Dispose();
      }
      base.Dispose(disposing);
    }
    public override void SetLength(long value) => throw new NotSupportedException();
    public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

#if NET
    public override void CopyTo(Stream destination, int bufferSize) =>
      _inner.CopyTo(destination, bufferSize);

    public override int Read(Span<byte> buffer) =>
      _inner.Read(buffer);

    public override ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default) =>
      _inner.ReadAsync(buffer, cancellationToken);
#endif
  }
}
