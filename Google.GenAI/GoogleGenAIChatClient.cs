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
using System.Text;

using Google.Apis.Util;
using Google.GenAI;
using Google.GenAI.Types;

namespace Microsoft.Extensions.AI;

/// <summary>Provides an <see cref="IChatClient"/> implementation based on <see cref="Client"/>.</summary>
internal sealed class GoogleGenAIChatClient : IChatClient
{
  /// <summary>A thought signature that can be used to skip thought validation when sending foreign function calls.</summary>
  /// <remarks>
  /// See https://ai.google.dev/gemini-api/docs/thought-signatures#faqs.
  /// This is more common in agentic scenarios, where a chat history is built up across multiple providers/models.
  /// </remarks>
  private static readonly byte[] s_skipThoughtValidation = Encoding.UTF8.GetBytes("skip_thought_signature_validator");

  /// <summary>The wrapped <see cref="Client"/> instance (optional).</summary>
  private readonly Client? _client;

  /// <summary>The wrapped <see cref="Models"/> instance.</summary>
  private readonly Models _models;

  /// <summary>The default model that should be used when no override is specified.</summary>
  private readonly string? _defaultModelId;

  /// <summary>Lazily-initialized metadata describing the implementation.</summary>
  private ChatClientMetadata? _metadata;

  /// <summary>Initializes a new <see cref="GoogleGenAIChatClient"/> instance.</summary>
  public GoogleGenAIChatClient(Client client, string? defaultModelId)
  {
    _client = client;
    _models = client.Models;
    _defaultModelId = defaultModelId;
  }

  /// <summary>Initializes a new <see cref="GoogleGenAIChatClient"/> instance.</summary>
  public GoogleGenAIChatClient(Models client, string? defaultModelId)
  {
    _models = client;
    _defaultModelId = defaultModelId;
  }

  /// <inheritdoc />
  public async Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
  {
    Utilities.ThrowIfNull(messages, nameof(messages));

    // Create the request.
    (string? modelId, List<Content> contents, GenerateContentConfig config) = CreateRequest(messages, options);

    // Send it.
    GenerateContentResponse generateResult = await _models.GenerateContentAsync(modelId!, contents, config).ConfigureAwait(false);

    // Create the response.
    ChatResponse chatResponse = new(new ChatMessage(ChatRole.Assistant, new List<AIContent>()) { MessageId = generateResult.ResponseId })
    {
      CreatedAt = generateResult.CreateTime is { } dt ? new DateTimeOffset(dt) : null,
      ModelId = !string.IsNullOrWhiteSpace(generateResult.ModelVersion) ? generateResult.ModelVersion : modelId,
      RawRepresentation = generateResult,
      ResponseId = generateResult.ResponseId,
    };

    // Populate the response messages.
    chatResponse.FinishReason = PopulateResponseContents(generateResult, chatResponse.Messages[0].Contents);

    // Populate usage information if there is any.
    if (generateResult.UsageMetadata is { } usageMetadata)
    {
      chatResponse.Usage = ExtractUsageDetails(usageMetadata);
    }

    // Return the response.
    return chatResponse;
  }

  /// <inheritdoc />
  public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
  {
    Utilities.ThrowIfNull(messages, nameof(messages));

    // Create the request.
    (string? modelId, List<Content> contents, GenerateContentConfig config) = CreateRequest(messages, options);

    // Send it, and process the results.
    await foreach (GenerateContentResponse generateResult in _models.GenerateContentStreamAsync(modelId!, contents, config).WithCancellation(cancellationToken).ConfigureAwait(false))
    {
      // Create a response update for each result in the stream.
      ChatResponseUpdate responseUpdate = new(ChatRole.Assistant, new List<AIContent>())
      {
        CreatedAt = generateResult.CreateTime is { } dt ? new DateTimeOffset(dt) : null,
        MessageId = generateResult.ResponseId,
        ModelId = !string.IsNullOrWhiteSpace(generateResult.ModelVersion) ? generateResult.ModelVersion : modelId,
        RawRepresentation = generateResult,
        ResponseId = generateResult.ResponseId,
      };

      // Populate the response update contents.
      responseUpdate.FinishReason = PopulateResponseContents(generateResult, responseUpdate.Contents);

      // Populate usage information if there is any.
      if (generateResult.UsageMetadata is { } usageMetadata)
      {
        responseUpdate.Contents.Add(new UsageContent(ExtractUsageDetails(usageMetadata)));
      }

      // Yield the update.
      yield return responseUpdate;
    }
  }

  /// <inheritdoc />
  public object? GetService(System.Type serviceType, object? serviceKey = null)
  {
    Utilities.ThrowIfNull(serviceType, nameof(serviceType));

    if (serviceKey is null)
    {
      // If there's a request for metadata, lazily-initialize it and return it. We don't need to worry about race conditions,
      // as there's no requirement that the same instance be returned each time, and creation is idempotent.
      if (serviceType == typeof(ChatClientMetadata))
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

  /// <summary>Creates the message parameters for <see cref="Models.GenerateContentAsync(string, List{Content}, GenerateContentConfig, CancellationToken)"/> from <paramref name="messages"/> and <paramref name="options"/>.</summary>
  private (string? ModelId, List<Content> Contents, GenerateContentConfig Config) CreateRequest(IEnumerable<ChatMessage> messages, ChatOptions? options)
  {
    // Create the GenerateContentConfig object. If the options contains a RawRepresentationFactory, try to use it to
    // create the request instance, allowing the caller to populate it with GenAI-specific options. Otherwise, create
    // a new instance directly.
    string? model = _defaultModelId;
    List<Content> contents = new();
    GenerateContentConfig config = options?.RawRepresentationFactory?.Invoke(this) as GenerateContentConfig ?? new();

    if (options is not null)
    {
      if (options.FrequencyPenalty is { } frequencyPenalty)
      {
        config.FrequencyPenalty ??= frequencyPenalty;
      }

      if (options.Instructions is { } instructions)
      {
        ((config.SystemInstruction ??= new()).Parts ??= new()).Add(new() { Text = instructions });
      }

      if (options.MaxOutputTokens is { } maxOutputTokens)
      {
        config.MaxOutputTokens ??= maxOutputTokens;
      }

      if (!string.IsNullOrWhiteSpace(options.ModelId))
      {
        model = options.ModelId;
      }

      if (options.PresencePenalty is { } presencePenalty)
      {
        config.PresencePenalty ??= presencePenalty;
      }

      if (options.Seed is { } seed)
      {
        config.Seed ??= (int)seed;
      }

      if (options.StopSequences is { } stopSequences)
      {
        (config.StopSequences ??= new()).AddRange(stopSequences);
      }

      if (options.Temperature is { } temperature)
      {
        config.Temperature ??= temperature;
      }

      if (options.TopP is { } topP)
      {
        config.TopP ??= topP;
      }

      if (options.TopK is { } topK)
      {
        config.TopK ??= topK;
      }

      if (options.Reasoning is { } reasoning)
      {
        if (reasoning.Effort is { } effort)
        {
          config.ThinkingConfig ??= new();
          if (effort is ReasoningEffort.None)
          {
            config.ThinkingConfig.ThinkingBudget ??= 0;
          }
          else
          {
            config.ThinkingConfig.ThinkingLevel ??= effort switch
            {
              ReasoningEffort.Low => ThinkingLevel.Low,
              ReasoningEffort.Medium => ThinkingLevel.Medium,
              _ => ThinkingLevel.High,
            };
          }
        }

        if (reasoning.Output is { } output)
        {
          config.ThinkingConfig ??= new();
          config.ThinkingConfig.IncludeThoughts ??= output != ReasoningOutput.None;
        }
      }

      // Populate tools. Each kind of tool is added on its own, except for function declarations,
      // which are grouped into a single FunctionDeclaration.
      List<FunctionDeclaration>? functionDeclarations = null;
      if (options.Tools is { } tools)
      {
        foreach (var tool in tools)
        {
          switch (tool)
          {
            case AIFunctionDeclaration af:
              functionDeclarations ??= new();
              functionDeclarations.Add(new()
              {
                Name = af.Name,
                Description = af.Description ?? "",
                ParametersJsonSchema = af.JsonSchema,
              });
              break;

            case HostedCodeInterpreterTool:
              (config.Tools ??= new()).Add(new() { CodeExecution = new() });
              break;

            case HostedFileSearchTool:
              (config.Tools ??= new()).Add(new() { Retrieval = new() });
              break;

            case HostedWebSearchTool:
              (config.Tools ??= new()).Add(new() { GoogleSearch = new() });
              break;
          }
        }
      }

      if (functionDeclarations is { Count: > 0 })
      {
        Tool functionTools = new();
        (functionTools.FunctionDeclarations ??= new()).AddRange(functionDeclarations);
        (config.Tools ??= new()).Add(functionTools);
      }

      // Transfer over the tool mode if there are any tools.
      if (options.ToolMode is { } toolMode && config.Tools?.Count > 0)
      {
        switch (toolMode)
        {
          case NoneChatToolMode:
            config.ToolConfig = new() { FunctionCallingConfig = new() { Mode = FunctionCallingConfigMode.None } };
            break;

          case AutoChatToolMode:
            config.ToolConfig = new() { FunctionCallingConfig = new() { Mode = FunctionCallingConfigMode.Auto } };
            break;

          case RequiredChatToolMode required:
            config.ToolConfig = new() { FunctionCallingConfig = new() { Mode = FunctionCallingConfigMode.Any } };
            if (required.RequiredFunctionName is not null)
            {
              ((config.ToolConfig.FunctionCallingConfig ??= new()).AllowedFunctionNames ??= new()).Add(required.RequiredFunctionName);
            }
            break;
        }
      }

      // Set the response format if specified.
      if (options.ResponseFormat is ChatResponseFormatJson responseFormat)
      {
        config.ResponseMimeType = "application/json";
        if (responseFormat.Schema is { } schema)
        {
          config.ResponseJsonSchema = schema;
        }
      }
    }

    // Transfer messages to request, handling system messages specially
    Dictionary<string, string>? callIdToFunctionNames = null;
    foreach (var message in messages)
    {
      if (message.Role == ChatRole.System)
      {
        string instruction = message.Text;
        if (!string.IsNullOrWhiteSpace(instruction))
        {
          ((config.SystemInstruction ??= new()).Parts ??= new()).Add(new() { Text = instruction });
        }

        continue;
      }

      Content content = new() { Role = message.Role == ChatRole.Assistant ? "model" : "user" };
      content.Parts ??= new();
      AddPartsForAIContents(ref callIdToFunctionNames, message.Contents, content.Parts);

      contents.Add(content);
    }

    // Make sure the request contains at least one content part (the request would always fail if empty).
    if (!contents.SelectMany(c => c.Parts ?? Enumerable.Empty<Part>()).Any())
    {
      contents.Add(new() { Role = "user", Parts = new() { { new() { Text = "" } } } });
    }

    return (model, contents, config);
  }

  /// <summary>Creates <see cref="Part"/>s for <paramref name="contents"/> and adds them to <paramref name="parts"/>.</summary>
  private static void AddPartsForAIContents(ref Dictionary<string, string>? callIdToFunctionNames, IList<AIContent> contents, List<Part> parts)
  {
    for (int i = 0; i < contents.Count; i++)
    {
      var content = contents[i];

      byte[]? thoughtSignature = null;
      if (content is not TextReasoningContent { ProtectedData: not null } &&
          i + 1 < contents.Count &&
          contents[i + 1] is TextReasoningContent nextReasoning &&
          string.IsNullOrWhiteSpace(nextReasoning.Text) &&
          nextReasoning.ProtectedData is { } protectedData)
      {
        i++;
        thoughtSignature = Convert.FromBase64String(protectedData);
      }

      // Before the main switch, do any necessary state tracking. We want to do this
      // even if the AIContent includes a Part as its RawRepresentation.
      if (content is FunctionCallContent fcc)
      {
        (callIdToFunctionNames ??= new())[fcc.CallId] = fcc.Name;
        callIdToFunctionNames[""] = fcc.Name; // track last function name in case calls don't have IDs
      }

      Part? part = null;
      switch (content)
      {
        case AIContent aic when aic.RawRepresentation is Part rawPart:
          part = rawPart;
          break;

        case TextContent textContent:
          part = new() { Text = textContent.Text };
          break;

        case TextReasoningContent reasoningContent:
          part = new()
          {
            Thought = true,
            Text = !string.IsNullOrWhiteSpace(reasoningContent.Text) ? reasoningContent.Text : null,
            ThoughtSignature = reasoningContent.ProtectedData is not null ? Convert.FromBase64String(reasoningContent.ProtectedData) : null,
          };
          break;

        case DataContent dataContent:
          part = new()
          {
            InlineData = new()
            {
              MimeType = dataContent.MediaType,
              Data = dataContent.Data.ToArray(),
              DisplayName = dataContent.Name,
            }
          };
          break;

        case UriContent uriContent:
          part = new()
          {
            FileData = new()
            {
              FileUri = uriContent.Uri.AbsoluteUri,
              MimeType = uriContent.MediaType,
            }
          };
          break;

        case FunctionCallContent functionCallContent:
          part = new()
          {
            FunctionCall = new()
            {
              Id = functionCallContent.CallId,
              Name = functionCallContent.Name,
              Args = functionCallContent.Arguments is null ? null : functionCallContent.Arguments as Dictionary<string, object> ?? new(functionCallContent.Arguments!),              
            },
            ThoughtSignature = thoughtSignature ?? s_skipThoughtValidation,
          };
          break;

        case FunctionResultContent functionResultContent:
          FunctionResponse funcResponse = new()
          {
            Id = functionResultContent.CallId,
          };

          if (callIdToFunctionNames?.TryGetValue(functionResultContent.CallId, out string? functionName) is true ||
              callIdToFunctionNames?.TryGetValue("", out functionName) is true)
          {
            funcResponse.Name = functionName;
          }

          switch (functionResultContent.Result)
          {
            case null:
              break;

            case AIContent aic when ToFunctionResponsePart(aic) is { } singleContentBlob:
              funcResponse.Parts = new() { singleContentBlob };
              break;

            case IEnumerable<AIContent> aiContents:
              List<AIContent>? nonBlobContent = null;
              foreach (var aiContent in aiContents)
              {
                if (ToFunctionResponsePart(aiContent) is { } contentBlob)
                {
                  (funcResponse.Parts ??= new()).Add(contentBlob);
                }
                else
                {
                  (nonBlobContent ??= new()).Add(aiContent);
                }
              }

              if (nonBlobContent is not null)
              {
                funcResponse.Response = new() { ["result"] = nonBlobContent };
              }
              break;

            case TextContent textContent:
              funcResponse.Response = new() { ["result"] = textContent.Text };
              break;

            default:
              funcResponse.Response = new() { ["result"] = functionResultContent.Result };
              break;
          }

          part = new()
          {
            FunctionResponse = funcResponse,
          };

          static FunctionResponsePart? ToFunctionResponsePart(AIContent content)
          {
            switch (content)
            {
              case AIContent when content.RawRepresentation is FunctionResponsePart functionResponsePart:
                return functionResponsePart;

              case DataContent dc when IsSupportedMediaType(dc.MediaType):
                FunctionResponseBlob dataBlob = new()
                {
                  MimeType = dc.MediaType,
                  Data = dc.Data.Span.ToArray(),
                };

                if (!string.IsNullOrWhiteSpace(dc.Name))
                {
                  dataBlob.DisplayName = dc.Name;
                }

                return new() { InlineData = dataBlob };

              case UriContent uc when IsSupportedMediaType(uc.MediaType):
                return new()
                {
                  FileData = new()
                  {
                    MimeType = uc.MediaType,
                    FileUri = uc.Uri.AbsoluteUri,
                  }
                };

              default:
                return null;
            }

            // https://docs.cloud.google.com/vertex-ai/generative-ai/docs/multimodal/function-calling#mm-fr
            static bool IsSupportedMediaType(string mediaType) =>
              // images
              mediaType.Equals("image/png", StringComparison.OrdinalIgnoreCase) ||
              mediaType.Equals("image/jpeg", StringComparison.OrdinalIgnoreCase) ||
              mediaType.Equals("image/webp", StringComparison.OrdinalIgnoreCase) ||
              // documents
              mediaType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase) ||
              mediaType.Equals("text/plain", StringComparison.OrdinalIgnoreCase);
          }
          break;
      }

      if (part is not null)
      {
        part.ThoughtSignature ??= thoughtSignature;
        parts.Add(part);
      }

      thoughtSignature = null;
    }
  }

  /// <summary>Creates <see cref="AIContent"/>s for <paramref name="parts"/> and adds them to <paramref name="contents"/>.</summary>
  private static void AddAIContentsForParts(List<Part> parts, IList<AIContent> contents)
  {
    foreach (var part in parts)
    {
      AIContent content;

      if (!string.IsNullOrEmpty(part.Text))
      {
        content = part.Thought is true ?
          new TextReasoningContent(part.Text) :
          new TextContent(part.Text);
      }
      else if (part.InlineData is { } inlineData)
      {
        content = new DataContent(inlineData.Data, inlineData.MimeType ?? "application/octet-stream")
        {
          Name = inlineData.DisplayName,
        };
      }
      else if (part.FileData is { FileUri: not null } fileData)
      {
        content = new UriContent(new Uri(fileData.FileUri), fileData.MimeType ?? "application/octet-stream");
      }
      else if (part.FunctionCall is { Name: not null } functionCall)
      {
        content = new FunctionCallContent(functionCall.Id ?? "", functionCall.Name, functionCall.Args!);
      }
      else if (part.FunctionResponse is { } functionResponse)
      {
        content = new FunctionResultContent(
          functionResponse.Id ?? "",
          functionResponse.Response?.TryGetValue("output", out var output) is true ? output :
          functionResponse.Response?.TryGetValue("error", out var error) is true ? error :
          null);
      }
      else if (part.ExecutableCode is { Code: not null } executableCode)
      {
        content = new CodeInterpreterToolCallContent()
        {
          Inputs = new List<AIContent>()
          {
            new DataContent(Encoding.UTF8.GetBytes(executableCode.Code), executableCode.Language switch
            {
              var lang when lang == Language.Python => "text/x-python",
              _ => "text/x-source-code",
            })
          },
        };
      }
      else if (part.CodeExecutionResult is { Output: { } codeOutput } codeExecutionResult)
      {
        content = new CodeInterpreterToolResultContent()
        {
          Outputs = new List<AIContent>()
           {
             codeExecutionResult.Outcome == Outcome.OutcomeOk ?
              new TextContent(codeOutput) :
              new ErrorContent(codeOutput) { ErrorCode = codeExecutionResult.Outcome.ToString() }
           },
        };
      }
      else
      {
        content = new AIContent();
      }

      content.RawRepresentation = part;
      contents.Add(content);

      if (part.ThoughtSignature is { } thoughtSignature)
      {
        contents.Add(new TextReasoningContent(null)
        {
          ProtectedData = Convert.ToBase64String(thoughtSignature),
        });
      }
    }
  }

  private static ChatFinishReason? PopulateResponseContents(GenerateContentResponse generateResult, IList<AIContent> responseContents)
  {
    ChatFinishReason? finishReason = null;

    // Populate the response messages. There should only be at most one candidate, but if there are more, ignore all but the first.
    if (generateResult.Candidates is { Count: > 0 } &&
        generateResult.Candidates[0] is { Content: { } candidateContent } candidate)
    {
      // Grab the finish reason if one exists.
      finishReason = ConvertFinishReason(candidate.FinishReason);

      // Add all of the response content parts as AIContents.
      if (candidateContent.Parts is { } parts)
      {
        AddAIContentsForParts(parts, responseContents);
      }

      // Add any citation metadata.
      if (candidate.CitationMetadata is { Citations: { Count: > 0 } citations } &&
          responseContents.OfType<TextContent>().FirstOrDefault() is TextContent textContent)
      {
        foreach (var citation in citations)
        {
          textContent.Annotations = new List<AIAnnotation>()
          {
              new CitationAnnotation()
              {
                  Title = citation.Title,
                  Url = Uri.TryCreate(citation.Uri, UriKind.Absolute, out Uri? uri) ? uri : null,
                  AnnotatedRegions = new List<AnnotatedRegion>()
                  {
                      new TextSpanAnnotatedRegion()
                      {
                          StartIndex = citation.StartIndex,
                          EndIndex = citation.EndIndex,
                      }
                  },
              }
          };
        }
      }
    }

    // Populate error information if there is any.
    if (generateResult.PromptFeedback is { } promptFeedback)
    {
      responseContents.Add(new ErrorContent(promptFeedback.BlockReasonMessage));
    }

    return finishReason;
  }

  /// <summary>Creates an M.E.AI <see cref="ChatFinishReason"/> from a Google <see cref="FinishReason"/>.</summary>
  private static ChatFinishReason? ConvertFinishReason(FinishReason? finishReason)
  {
    return finishReason switch
    {
      null => null,

      var fr when fr == FinishReason.MaxTokens =>
            ChatFinishReason.Length,

      var fr when fr == FinishReason.MalformedFunctionCall ||
                  fr == FinishReason.UnexpectedToolCall =>
            ChatFinishReason.ToolCalls,

      var fr when fr == FinishReason.FinishReasonUnspecified ||
                  fr == FinishReason.Stop =>
            ChatFinishReason.Stop,

      _ => ChatFinishReason.ContentFilter,
    };
  }

  /// <summary>Creates a <see cref="UsageDetails"/> populated from the supplied <paramref name="usageMetadata"/>.</summary>
  private static UsageDetails ExtractUsageDetails(GenerateContentResponseUsageMetadata usageMetadata)
  {
    UsageDetails details = new()
    {
      InputTokenCount = usageMetadata.PromptTokenCount,
      CachedInputTokenCount = usageMetadata.CachedContentTokenCount,
      OutputTokenCount = usageMetadata.CandidatesTokenCount,
      ReasoningTokenCount = usageMetadata.ThoughtsTokenCount,
      TotalTokenCount = usageMetadata.TotalTokenCount,
    };

    AddIfPresent(nameof(usageMetadata.ToolUsePromptTokenCount), usageMetadata.ToolUsePromptTokenCount);

    return details;

    void AddIfPresent(string key, int? value)
    {
      if (value is int i)
      {
        (details.AdditionalCounts ??= new())[key] = i;
      }
    }
  }
}
