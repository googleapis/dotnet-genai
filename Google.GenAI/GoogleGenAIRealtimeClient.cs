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

using Google.GenAI;
using Google.GenAI.Types;

namespace Microsoft.Extensions.AI;

/// <summary>
/// Provides an <see cref="IRealtimeClient"/> implementation for Google GenAI's Live API.
/// </summary>
#if NET8_0_OR_GREATER
[System.Diagnostics.CodeAnalysis.Experimental("MEAI001")]
#endif
public sealed class GoogleGenAIRealtimeClient : IRealtimeClient
{
  private readonly Client _client;
  private readonly string? _defaultModelId;
  private ChatClientMetadata? _metadata;

  /// <summary>Initializes a new instance wrapping an existing <see cref="Client"/>.</summary>
  /// <param name="client">The Google GenAI client.</param>
  /// <param name="defaultModelId">The default model to use for realtime sessions (e.g. "gemini-2.5-flash-native-audio-preview-12-2025").</param>
  /// <exception cref="ArgumentNullException"><paramref name="client"/> is <see langword="null"/>.</exception>
  public GoogleGenAIRealtimeClient(Client client, string? defaultModelId = null)
  {
    _client = client ?? throw new ArgumentNullException(nameof(client));
    _defaultModelId = defaultModelId;
  }

  /// <summary>Initializes a new instance using an API key.</summary>
  /// <param name="apiKey">The Google GenAI API key.</param>
  /// <param name="defaultModelId">The default model to use for realtime sessions.</param>
  /// <exception cref="ArgumentNullException"><paramref name="apiKey"/> is <see langword="null"/> or empty.</exception>
  public GoogleGenAIRealtimeClient(string apiKey, string? defaultModelId = null)
  {
    if (string.IsNullOrEmpty(apiKey))
    {
      throw new ArgumentNullException(nameof(apiKey));
    }

    _client = new Client(apiKey: apiKey);
    _defaultModelId = defaultModelId;
  }

  /// <summary>Initializes a new instance using a Google Cloud project and location.</summary>
  /// <param name="project">The Google Cloud project ID.</param>
  /// <param name="location">The Google Cloud location (e.g. "us-central1").</param>
  /// <param name="defaultModelId">The default model to use for realtime sessions.</param>
  /// <exception cref="ArgumentNullException"><paramref name="project"/> or <paramref name="location"/> is <see langword="null"/> or empty.</exception>
  public GoogleGenAIRealtimeClient(string project, string location, string? defaultModelId = null)
  {
    if (string.IsNullOrEmpty(project))
    {
      throw new ArgumentNullException(nameof(project));
    }

    if (string.IsNullOrEmpty(location))
    {
      throw new ArgumentNullException(nameof(location));
    }

    _client = new Client(enterprise: true, project: project, location: location);
    _defaultModelId = defaultModelId;
  }

  /// <inheritdoc />
  public async Task<IRealtimeClientSession> CreateSessionAsync(
    RealtimeSessionOptions? options = null,
    CancellationToken cancellationToken = default)
  {
    string model = options?.Model ?? _defaultModelId
      ?? throw new InvalidOperationException(
        "No model specified. Provide a model via RealtimeSessionOptions.Model or the defaultModelId constructor parameter.");

    var config = BuildLiveConnectConfig(options);

    var asyncSession = await _client.Live.ConnectAsync(model, config, cancellationToken).ConfigureAwait(false);

    try
    {
      // The Google SDK's ConnectAsync sends the setup message but does NOT wait
      // for the server's SetupComplete acknowledgment. We must drain it here so
      // the session is fully ready (tools configured, modalities set) before the
      // caller starts sending audio or text.
      var setupResponse = await asyncSession.ReceiveAsync(cancellationToken).ConfigureAwait(false);
      if (setupResponse?.SetupComplete is null)
      {
        throw new InvalidOperationException(
          "Expected SetupComplete from Gemini server after connection, but received an unexpected message.");
      }

      return new GoogleGenAIRealtimeSession(asyncSession, model, options);
    }
    catch
    {
      await asyncSession.DisposeAsync().ConfigureAwait(false);
      throw;
    }
  }

  /// <inheritdoc />
  public object? GetService(System.Type serviceType, object? serviceKey = null)
  {
    if (serviceType is null)
    {
      throw new ArgumentNullException(nameof(serviceType));
    }

    if (serviceKey is not null)
    {
      return null;
    }

    if (serviceType == typeof(ChatClientMetadata))
    {
      return _metadata ??= new ChatClientMetadata("google-genai", defaultModelId: _defaultModelId);
    }

    if (serviceType.IsInstanceOfType(this))
    {
      return this;
    }

    if (serviceType.IsInstanceOfType(_client))
    {
      return _client;
    }

    return null;
  }

  /// <inheritdoc />
  public void Dispose()
  {
    // Client lifecycle is not owned by this wrapper.
  }

  /// <summary>Converts MEAI session options to a Google GenAI <see cref="LiveConnectConfig"/>.</summary>
  internal static LiveConnectConfig BuildLiveConnectConfig(RealtimeSessionOptions? options)
  {
    var config = new LiveConnectConfig();

    if (options is null)
    {
      config.ResponseModalities = new List<Modality> { Modality.Audio };
      config.RealtimeInputConfig = new RealtimeInputConfig
      {
        AutomaticActivityDetection = new AutomaticActivityDetection { Disabled = true }
      };
      return config;
    }

    // Transcription-only sessions use a minimal configuration with
    // only input audio transcription enabled (no audio output, no tools).
    if (options.SessionKind == RealtimeSessionKind.Transcription)
    {
      return BuildTranscriptionConnectConfig(options);
    }

    // System instructions
    if (!string.IsNullOrEmpty(options.Instructions))
    {
      config.SystemInstruction = new Content
      {
        Parts = new List<Part> { new Part { Text = options.Instructions } },
        Role = "user"
      };
    }

    // Output modalities
    if (options.OutputModalities is { Count: > 0 })
    {
      config.ResponseModalities = new List<Modality>();
      foreach (var modality in options.OutputModalities)
      {
        config.ResponseModalities.Add(modality.ToLowerInvariant() switch
        {
          "audio" => Modality.Audio,
          "text" => Modality.Text,
          _ => Modality.Text,
        });
      }
    }
    else
    {
      config.ResponseModalities = new List<Modality> { Modality.Audio };
    }

    // Voice / speech config
    if (!string.IsNullOrEmpty(options.Voice))
    {
      config.SpeechConfig = new SpeechConfig
      {
        VoiceConfig = new VoiceConfig
        {
          PrebuiltVoiceConfig = new PrebuiltVoiceConfig
          {
            VoiceName = options.Voice,
          }
        }
      };
    }

    // Generation config
    if (options.MaxOutputTokens.HasValue)
    {
      config.GenerationConfig ??= new GenerationConfig();
      config.GenerationConfig.MaxOutputTokens = options.MaxOutputTokens.Value;
    }

    // Tools (AIFunction → Google FunctionDeclaration)
    if (options.Tools is { Count: > 0 })
    {
      var functionDeclarations = new List<FunctionDeclaration>();
      foreach (var tool in options.Tools)
      {
        if (tool is AIFunction aiFunction)
        {
          functionDeclarations.Add(GoogleGenAIRealtimeSession.ToGoogleFunctionDeclaration(aiFunction));
        }
      }

      if (functionDeclarations.Count > 0)
      {
        config.Tools = new List<Tool>
        {
          new Tool { FunctionDeclarations = functionDeclarations }
        };
      }
    }

    // Transcription (both directions for conversation sessions)
    if (options.TranscriptionOptions is not null)
    {
      var inputTranscriptionConfig = new AudioTranscriptionConfig();
      if (!string.IsNullOrEmpty(options.TranscriptionOptions.SpeechLanguage))
      {
        inputTranscriptionConfig.LanguageCodes = new List<string> { options.TranscriptionOptions.SpeechLanguage };
      }

      config.InputAudioTranscription = inputTranscriptionConfig;
      config.OutputAudioTranscription = new AudioTranscriptionConfig();
    }

    // Configure VAD / activity detection based on MEAI options.
    config.RealtimeInputConfig = new RealtimeInputConfig();

    if (options.VoiceActivityDetection is { Enabled: true } vad)
    {
      // Automatic VAD enabled — the server detects speech boundaries.
      config.RealtimeInputConfig.AutomaticActivityDetection = new AutomaticActivityDetection { Disabled = false };
      config.RealtimeInputConfig.ActivityHandling = vad.AllowInterruption
        ? ActivityHandling.StartOfActivityInterrupts
        : ActivityHandling.NoInterruption;
    }
    else if (options.VoiceActivityDetection is { Enabled: false })
    {
      // VAD explicitly disabled — the client controls activity boundaries
      // via explicit ActivityStart/ActivityEnd signals.
      config.RealtimeInputConfig.AutomaticActivityDetection = new AutomaticActivityDetection { Disabled = true };
    }
    else
    {
      // No VAD options specified — disable automatic VAD by default when using
      // the MEAI audio buffering pattern (AudioBufferAppend → AudioBufferCommit).
      // The client controls activity boundaries via explicit ActivityEnd signals.
      config.RealtimeInputConfig.AutomaticActivityDetection = new AutomaticActivityDetection { Disabled = true };
    }

    return config;
  }

  /// <summary>
  /// Builds a minimal <see cref="LiveConnectConfig"/> for transcription-only sessions.
  /// Only input audio transcription is enabled; no audio output, tools, or voice config.
  /// </summary>
  private static LiveConnectConfig BuildTranscriptionConnectConfig(RealtimeSessionOptions options)
  {
    var config = new LiveConnectConfig
    {
      // No audio output for transcription-only sessions
      ResponseModalities = new List<Modality> { Modality.Text },
    };

    // Enable input transcription with optional language hint
    var transcriptionConfig = new AudioTranscriptionConfig();
    if (!string.IsNullOrEmpty(options.TranscriptionOptions?.SpeechLanguage))
    {
      transcriptionConfig.LanguageCodes = new List<string> { options.TranscriptionOptions.SpeechLanguage };
    }

    config.InputAudioTranscription = transcriptionConfig;

    // VAD configuration still applies for speech boundary detection
    config.RealtimeInputConfig = new RealtimeInputConfig();

    if (options.VoiceActivityDetection is { Enabled: true } vad)
    {
      config.RealtimeInputConfig.AutomaticActivityDetection = new AutomaticActivityDetection { Disabled = false };
      config.RealtimeInputConfig.ActivityHandling = vad.AllowInterruption
        ? ActivityHandling.StartOfActivityInterrupts
        : ActivityHandling.NoInterruption;
    }
    else
    {
      config.RealtimeInputConfig.AutomaticActivityDetection = new AutomaticActivityDetection { Disabled = true };
    }

    return config;
  }
}

