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
    /// Verifies that values commonly placed in object-typed properties and Dictionary&lt;string, object&gt;
    /// values, such as FunctionResponse.Response, resolve without reflection.
    /// </summary>
    [TestMethod]
    public void GenAIJsonContext_ResolvesObjectValues()
    {
      var valueTypes = new[]
      {
        typeof(Dictionary<string, object>), typeof(List<object>), typeof(object[]),
        typeof(string), typeof(bool), typeof(byte), typeof(sbyte), typeof(short), typeof(ushort),
        typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(float), typeof(double),
        typeof(decimal), typeof(JsonElement), typeof(System.Text.Json.Nodes.JsonNode),
      };
      var missing = valueTypes.Where(t => GenAIJsonContext.Default.GetTypeInfo(t) == null).ToList();
      Assert.AreEqual(0, missing.Count, $"Missing from GenAIJsonContext: {string.Join(", ", missing.Select(t => t.Name))}");
    }

    /// <summary>
    /// Verifies that every serializable type in Google.GenAI.Types (any type with a FromJson method
    /// or JsonPropertyName-annotated properties) resolves through GenAIJsonContext. Under Native AOT
    /// a missing type throws NotSupportedException at runtime, and the AOT compiler can't warn about it.
    /// </summary>
    [TestMethod]
    public void GenAIJsonContext_ResolvesEveryTypesNamespaceType()
    {
      var serializableTypes = typeof(Client).Assembly.GetTypes()
          .Where(t => t.Namespace == "Google.GenAI.Types" && t.IsClass && !t.IsAbstract && !t.IsNested
                      && !t.IsGenericTypeDefinition && !t.Name.StartsWith("<"))
          .Where(t => t.GetMethod("FromJson", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static) != null
                      || t.GetProperties().Any(p => p.IsDefined(typeof(System.Text.Json.Serialization.JsonPropertyNameAttribute), true)))
          // Replay and test table records are only read by the test harness, not by the SDK, so they
          // are kept out of GenAIJsonContext to avoid shipping their serialization code to every app.
          .Where(t => !t.Name.StartsWith("Replay") && !t.Name.StartsWith("TestTable"))
          .ToList();
      Assert.IsTrue(serializableTypes.Count > 300, $"Expected to find the Types namespace, found {serializableTypes.Count} types");

      var missing = serializableTypes.Where(t => GenAIJsonContext.Default.GetTypeInfo(t) == null).Select(t => t.Name).OrderBy(n => n).ToList();
      Assert.AreEqual(0, missing.Count, $"Add [JsonSerializable] to GenAIJsonContext for: {string.Join(", ", missing)}");
    }

    /// <summary>
    /// Verifies that SDK types resolve through GenAIJsonContext when caller-supplied options
    /// carry a resolver that does not know them, without modifying the caller's options.
    /// </summary>
    [TestMethod]
    public void FromJson_ResolvesSdkTypesWithCallerOptionsThatLackThem()
    {
      var options = new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true,
        TypeInfoResolver = JsonTypeInfoResolver.Combine(),
      };
      options.MakeReadOnly();

      var content = Content.FromJson("{\"PARTS\":[{\"text\":\"Hello\"}]}", options);

      Assert.AreEqual("Hello", content?.Parts?[0].Text);
      Assert.AreEqual(0, options.TypeInfoResolverChain.Count);
      // Repeated calls with read-only options use the cached copy.
      Assert.AreEqual("Hello", Content.FromJson("{\"PARTS\":[{\"text\":\"Hello\"}]}", options)?.Parts?[0].Text);
    }

    /// <summary>
    /// Verifies that FromJson works with caller-supplied options that have no resolver at all.
    /// JsonSerializerOptions.GetTypeInfo doesn't fall back to reflection for such options, even when
    /// reflection-based serialization is enabled, so this used to throw outside Native AOT too.
    /// </summary>
    [TestMethod]
    public void FromJson_ResolvesSdkTypesWithCallerOptionsWithoutResolver()
    {
      var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

      var content = Content.FromJson("{\"PARTS\":[{\"text\":\"Hello\"}]}", options);

      Assert.AreEqual("Hello", content?.Parts?[0].Text);
      Assert.IsNull(options.TypeInfoResolver);
      Assert.IsFalse(options.IsReadOnly);
    }

    /// <summary>
    /// Verifies that mutable caller-supplied options with a resolver are locked on first use, as
    /// System.Text.Json does, so the copy extended with GenAIJsonContext can be cached.
    /// </summary>
    [TestMethod]
    public void FromJson_LocksMutableCallerOptionsWithResolver()
    {
      var options = new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true,
        TypeInfoResolver = JsonTypeInfoResolver.Combine(),
      };

      Assert.AreEqual("Hello", Content.FromJson("{\"PARTS\":[{\"text\":\"Hello\"}]}", options)?.Parts?[0].Text);

      Assert.IsTrue(options.IsReadOnly);
      Assert.AreEqual(0, options.TypeInfoResolverChain.Count);
      Assert.ThrowsException<InvalidOperationException>(() => options.PropertyNameCaseInsensitive = false);
    }

    /// <summary>
    /// Verifies that changes to mutable caller-supplied options without a resolver, made after a
    /// FromJson call, are honored rather than served from a stale cached copy.
    /// </summary>
    [TestMethod]
    public void FromJson_HonorsLaterChangesToMutableCallerOptions()
    {
      var options = new JsonSerializerOptions();
      Assert.IsNull(Content.FromJson("{\"PARTS\":[{\"text\":\"Hello\"}]}", options)?.Parts);

      options.PropertyNameCaseInsensitive = true;

      Assert.AreEqual("Hello", Content.FromJson("{\"PARTS\":[{\"text\":\"Hello\"}]}", options)?.Parts?[0].Text);
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
