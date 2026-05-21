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
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using Google.GenAI;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Type = System.Type;

namespace Google.GenAI.Tests
{
  /// <summary>
  /// Tests that the source-generated JSON context covers all types used in serialization.
  /// This ensures AOT compatibility by verifying type metadata is available without reflection.
  /// </summary>
  [TestClass]
  public class AotJsonContextTest
  {
    /// <summary>
    /// Verifies that all types directly used in JsonSerializer.Serialize/Deserialize calls
    /// are resolvable via the GenAIJsonContext source-generated context (without reflection fallback).
    /// </summary>
    [TestMethod]
    public void GenAIJsonContext_CoversAllDirectlySerializedTypes()
    {
      var requiredTypes = new[]
      {
        // Service parameter/response types
        typeof(BatchJob),
        typeof(CreateBatchJobParameters),
        typeof(CreateEmbeddingsBatchJobParameters),
        typeof(GetBatchJobParameters),
        typeof(CancelBatchJobParameters),
        typeof(ListBatchJobsResponse),
        typeof(DeleteBatchJobParameters),
        typeof(DeleteResourceJob),
        typeof(CachedContent),
        typeof(CreateCachedContentParameters),
        typeof(GetCachedContentParameters),
        typeof(DeleteCachedContentParameters),
        typeof(DeleteCachedContentResponse),
        typeof(UpdateCachedContentParameters),
        typeof(ListCachedContentsParameters),
        typeof(ListCachedContentsResponse),
        typeof(Google.GenAI.Types.File),
        typeof(ListFilesParameters),
        typeof(ListFilesResponse),
        typeof(CreateFileParameters),
        typeof(CreateFileResponse),
        typeof(GetFileParameters),
        typeof(DeleteFileParameters),
        typeof(DeleteFileResponse),
        typeof(InternalRegisterFilesParameters),
        typeof(RegisterFilesResponse),
        typeof(GenerateContentParameters),
        typeof(GenerateContentResponse),
        typeof(EmbedContentParametersPrivate),
        typeof(EmbedContentResponse),
        typeof(GenerateImagesParameters),
        typeof(GenerateImagesResponse),
        typeof(EditImageParameters),
        typeof(EditImageResponse),
        typeof(UpscaleImageAPIParameters),
        typeof(UpscaleImageResponse),
        typeof(RecontextImageParameters),
        typeof(RecontextImageResponse),
        typeof(SegmentImageParameters),
        typeof(SegmentImageResponse),
        typeof(Model),
        typeof(GetModelParameters),
        typeof(ListModelsParameters),
        typeof(ListModelsResponse),
        typeof(UpdateModelParameters),
        typeof(DeleteModelParameters),
        typeof(DeleteModelResponse),
        typeof(CountTokensParameters),
        typeof(CountTokensResponse),
        typeof(ComputeTokensParameters),
        typeof(ComputeTokensResponse),
        typeof(GenerateVideosParameters),
        typeof(GenerateVideosOperation),
        typeof(GenerateVideosResponse),
        typeof(GetOperationParameters),
        typeof(FetchPredictOperationParameters),
        typeof(TuningJob),
        typeof(GetTuningJobParameters),
        typeof(ListTuningJobsParameters),
        typeof(ListTuningJobsResponse),
        typeof(CancelTuningJobParameters),
        typeof(CancelTuningJobResponse),
        typeof(CreateTuningJobParametersPrivate),
        typeof(TuningOperation),
        // Live/Realtime types
        typeof(LiveConnectParameters),
        typeof(LiveServerMessage),
        typeof(LiveClientMessage),
        typeof(LiveClientRealtimeInput),
        typeof(LiveClientSetup),
        typeof(LiveClientContent),
        typeof(LiveClientToolResponse),
        typeof(LiveConnectConfig),
        typeof(LiveSendClientContentParameters),
        typeof(LiveSendRealtimeInputParameters),
        typeof(LiveSendToolResponseParameters),
        typeof(LiveServerContent),
        typeof(LiveServerGoAway),
        typeof(LiveServerSetupComplete),
        typeof(LiveServerToolCall),
        typeof(LiveServerToolCallCancellation),
        typeof(LiveServerSessionResumptionUpdate),
        typeof(RealtimeInputConfig),
        // Transformer types
        typeof(Content),
        typeof(Schema),
        typeof(SpeechConfig),
        typeof(Tool),
        typeof(Blob),
        // Collection types
        typeof(List<Content>),
        typeof(List<Tool>),
      };

      var missingTypes = new List<Type>();

      foreach (var type in requiredTypes)
      {
        var typeInfo = GenAIJsonContext.Default.GetTypeInfo(type);
        if (typeInfo == null)
        {
          missingTypes.Add(type);
        }
      }

      Assert.AreEqual(0, missingTypes.Count,
        $"The following types are missing from GenAIJsonContext and will fail in AOT: " +
        $"{string.Join(", ", missingTypes.Select(t => t.Name))}");
    }

    /// <summary>
    /// Verifies that key nested types (transitively reachable from root types)
    /// are auto-discovered by the source generator.
    /// </summary>
    [TestMethod]
    public void GenAIJsonContext_AutoDiscoversNestedTypes()
    {
      // These types are NOT explicitly registered but should be auto-discovered
      // as properties of registered root types
      var nestedTypes = new[]
      {
        typeof(Part),
        typeof(Candidate),
        typeof(SafetyRating),
        typeof(FunctionDeclaration),
        typeof(GenerationConfig),
        typeof(ToolConfig),
        typeof(FunctionCall),
        typeof(FunctionResponse),
        typeof(CitationMetadata),
        typeof(GenerateContentResponseUsageMetadata),
      };

      var missingTypes = new List<Type>();

      foreach (var type in nestedTypes)
      {
        var typeInfo = GenAIJsonContext.Default.GetTypeInfo(type);
        if (typeInfo == null)
        {
          missingTypes.Add(type);
        }
      }

      Assert.AreEqual(0, missingTypes.Count,
        $"The following nested types are NOT auto-discovered by the source generator. " +
        $"Add [JsonSerializable(typeof(X))] to GenAIJsonContext: " +
        $"{string.Join(", ", missingTypes.Select(t => t.Name))}");
    }

    /// <summary>
    /// Verifies that serializing and deserializing a realtime message round-trips correctly
    /// using only the source-generated context (no reflection fallback).
    /// </summary>
    [TestMethod]
    public void GenAIJsonContext_RoundTripsLiveServerMessage()
    {
      var message = new LiveServerMessage
      {
        ServerContent = new LiveServerContent
        {
          ModelTurn = new Content
          {
            Role = "model",
            Parts = new List<Part>
            {
              new Part { Text = "Hello from the model" }
            }
          }
        }
      };

      // Serialize using source-gen context only (no reflection)
      var json = JsonSerializer.Serialize(message, GenAIJsonContext.Default.LiveServerMessage);
      Assert.IsFalse(string.IsNullOrEmpty(json));

      // Deserialize using source-gen context
      var deserialized = JsonSerializer.Deserialize(json, GenAIJsonContext.Default.LiveServerMessage);
      Assert.IsNotNull(deserialized);
      Assert.IsNotNull(deserialized.ServerContent);
      Assert.AreEqual("model", deserialized.ServerContent.ModelTurn?.Role);
      Assert.AreEqual("Hello from the model", deserialized.ServerContent.ModelTurn?.Parts?[0]?.Text);
    }

    /// <summary>
    /// Verifies that serializing a GenerateContentParameters type round-trips correctly,
    /// exercising a deep type graph (Content, Part, Tool, FunctionDeclaration, Schema, etc).
    /// </summary>
    [TestMethod]
    public void GenAIJsonContext_RoundTripsGenerateContentParameters()
    {
      var parameters = new GenerateContentParameters
      {
        Model = "gemini-2.0-flash",
        Contents = new List<Content>
        {
          new Content
          {
            Role = "user",
            Parts = new List<Part> { new Part { Text = "Hello" } }
          }
        },
        Config = new GenerateContentConfig
        {
          MaxOutputTokens = 100,
          Temperature = 0.7f,
        }
      };

      var json = JsonSerializer.Serialize(parameters, GenAIJsonContext.Default.GenerateContentParameters);
      Assert.IsFalse(string.IsNullOrEmpty(json));
      Assert.IsTrue(json.Contains("gemini-2.0-flash"));

      var deserialized = JsonSerializer.Deserialize(json, GenAIJsonContext.Default.GenerateContentParameters);
      Assert.IsNotNull(deserialized);
      Assert.AreEqual("gemini-2.0-flash", deserialized.Model);
      Assert.AreEqual(1, deserialized.Contents?.Count);
    }
  }
}
