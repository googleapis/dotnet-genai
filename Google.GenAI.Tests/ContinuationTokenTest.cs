/*
 * Copyright 2026 Google LLC
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
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.Extensions.AI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.Tests
{
  [TestClass]
  public class ContinuationTokenTest
  {
    #region Activation & Configuration Tests

    [TestMethod]
    public void ShouldEnableAutomaticContinuation_Default_ReturnsTrue()
    {
      // Automatic continuation is enabled by default when unset.
      Assert.IsTrue(ContinuationHelper.ShouldEnableAutomaticContinuation(config: null));
      Assert.IsTrue(ContinuationHelper.ShouldEnableAutomaticContinuation(new GenerateContentConfig()));
      Assert.IsTrue(ContinuationHelper.ShouldEnableAutomaticContinuation(
          new GenerateContentConfig { AutomaticContinuation = null }));
      Assert.IsTrue(ContinuationHelper.ShouldEnableAutomaticContinuation(config: null, defaultEnabled: true));
      Assert.IsTrue(ContinuationHelper.ShouldEnableAutomaticContinuation(new GenerateContentConfig(), defaultEnabled: true));
      Assert.IsTrue(ContinuationHelper.ShouldEnableAutomaticContinuation(
          new GenerateContentConfig { AutomaticContinuation = null }, defaultEnabled: true));
    }

    [TestMethod]
    public void ShouldEnableAutomaticContinuation_WhenDefaultDisabled_ReturnsFalse()
    {
      Assert.IsFalse(ContinuationHelper.ShouldEnableAutomaticContinuation(config: null, defaultEnabled: false));
      Assert.IsFalse(ContinuationHelper.ShouldEnableAutomaticContinuation(new GenerateContentConfig(), defaultEnabled: false));
      Assert.IsFalse(ContinuationHelper.ShouldEnableAutomaticContinuation(
          new GenerateContentConfig { AutomaticContinuation = null }, defaultEnabled: false));
    }

    [TestMethod]
    public void ShouldEnableAutomaticContinuation_MaxOutputTokensDoesNotAffectContinuation()
    {
      // MaxOutputTokens does not affect whether automatic continuation is enabled.
      // Automatic continuation depends solely on AutomaticContinuation flag and defaultEnabled.
      Assert.IsTrue(ContinuationHelper.ShouldEnableAutomaticContinuation(
          new GenerateContentConfig { MaxOutputTokens = 100 }, defaultEnabled: true));
      Assert.IsTrue(ContinuationHelper.ShouldEnableAutomaticContinuation(
          new GenerateContentConfig { MaxOutputTokens = 100, AutomaticContinuation = true }, defaultEnabled: true));
      Assert.IsTrue(ContinuationHelper.ShouldEnableAutomaticContinuation(
          new GenerateContentConfig { MaxOutputTokens = 100, AutomaticContinuation = true }, defaultEnabled: false));
      Assert.IsFalse(ContinuationHelper.ShouldEnableAutomaticContinuation(
          new GenerateContentConfig { MaxOutputTokens = 100, AutomaticContinuation = false }, defaultEnabled: true));
      Assert.IsFalse(ContinuationHelper.ShouldEnableAutomaticContinuation(
          new GenerateContentConfig { MaxOutputTokens = 100 }, defaultEnabled: false));
    }

    [TestMethod]
    public void ShouldEnableAutomaticContinuation_ExplicitOptInEnablesContinuation()
    {
      // Explicit AutomaticContinuation = true enables continuation (in Models or Chat).
      Assert.IsTrue(ContinuationHelper.ShouldEnableAutomaticContinuation(
          new GenerateContentConfig { AutomaticContinuation = true }, defaultEnabled: false));
      Assert.IsTrue(ContinuationHelper.ShouldEnableAutomaticContinuation(
          new GenerateContentConfig { AutomaticContinuation = true }, defaultEnabled: true));
    }

    [TestMethod]
    public void ShouldEnableAutomaticContinuation_ExplicitOptOutDisablesContinuation()
    {
      // Explicit AutomaticContinuation = false disables continuation (even in Chat).
      Assert.IsFalse(ContinuationHelper.ShouldEnableAutomaticContinuation(
          new GenerateContentConfig { AutomaticContinuation = false }, defaultEnabled: true));
      Assert.IsFalse(ContinuationHelper.ShouldEnableAutomaticContinuation(
          new GenerateContentConfig { AutomaticContinuation = false }, defaultEnabled: false));
    }

    #endregion

    #region Resumable FinishReason & Continuation Detection Tests

    [TestMethod]
    public void IsResumableFinishReason_ValidatesCorrectly()
    {
      // Null (intermediate checkpoint chunk) and CONTINUATION are resumable.
      Assert.IsTrue(ContinuationHelper.IsResumableFinishReason(FinishReason.Continuation));
      Assert.IsTrue(ContinuationHelper.IsResumableFinishReason(null));

      // MAX_TOKENS and other terminal finish reasons are not resumable.
      Assert.IsFalse(ContinuationHelper.IsResumableFinishReason(FinishReason.MaxTokens));
      Assert.IsFalse(ContinuationHelper.IsResumableFinishReason(FinishReason.Stop));
      Assert.IsFalse(ContinuationHelper.IsResumableFinishReason(FinishReason.Safety));
      Assert.IsFalse(ContinuationHelper.IsResumableFinishReason(FinishReason.Recitation));
    }

    [TestMethod]
    public void ShouldContinueGeneration_ExtractsTokenWhenResumable()
    {
      byte[] tokenBytes = new byte[] { 1, 2, 3, 4 };
      var response = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            FinishReason = FinishReason.Continuation,
            ContinuationToken = tokenBytes
          }
        }
      };

      byte[]? extracted = ContinuationHelper.ShouldContinueGeneration(response);
      Assert.IsNotNull(extracted);
      CollectionAssert.AreEqual(tokenBytes, extracted);
    }

    [TestMethod]
    public void ShouldContinueGeneration_ReturnsNullWhenNotResumable()
    {
      byte[] tokenBytes = new byte[] { 1, 2, 3, 4 };

      // Null response
      Assert.IsNull(ContinuationHelper.ShouldContinueGeneration(null));

      // Empty candidates
      Assert.IsNull(ContinuationHelper.ShouldContinueGeneration(
          new GenerateContentResponse { Candidates = new List<Candidate>() }));

      // No continuation token
      var noTokenResponse = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate { FinishReason = FinishReason.Continuation, ContinuationToken = null }
        }
      };
      Assert.IsNull(ContinuationHelper.ShouldContinueGeneration(noTokenResponse));

      // FinishReason is STOP even if token is present
      var stopResponse = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate { FinishReason = FinishReason.Stop, ContinuationToken = tokenBytes }
        }
      };
      Assert.IsNull(ContinuationHelper.ShouldContinueGeneration(stopResponse));

      // FinishReason is MAX_TOKENS: not resumable even if token is present
      var maxTokensResponse = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate { FinishReason = FinishReason.MaxTokens, ContinuationToken = tokenBytes }
        }
      };
      Assert.IsNull(ContinuationHelper.ShouldContinueGeneration(maxTokensResponse));
    }

    [TestMethod]
    public void PrepareContinuationConfig_SetsTokenAndPreservesOtherFields()
    {
      byte[] tokenBytes = new byte[] { 10, 20, 30 };
      var baseConfig = new GenerateContentConfig
      {
        Temperature = 0.7f,
        TopK = 40f,
        AutomaticContinuation = true
      };

      var newConfig = ContinuationHelper.PrepareContinuationConfig(baseConfig, tokenBytes);
      Assert.IsNotNull(newConfig);
      CollectionAssert.AreEqual(tokenBytes, newConfig.ContinuationToken);
      Assert.AreEqual(0.7f, newConfig.Temperature);
      Assert.AreEqual(40f, newConfig.TopK);
      Assert.AreEqual(true, newConfig.AutomaticContinuation);

      // Verify null base config creates a new one
      var freshConfig = ContinuationHelper.PrepareContinuationConfig(null, tokenBytes);
      Assert.IsNotNull(freshConfig);
      CollectionAssert.AreEqual(tokenBytes, freshConfig.ContinuationToken);
    }

    #endregion

    #region Response Merging Tests

    [TestMethod]
    public void MergeContinuationResponses_ConcatenatesCandidatePartsInOrder()
    {
      var hop1 = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            Content = new Content
            {
              Role = "model",
              Parts = new List<Part> { new Part { Text = "Part 1: The story begins. " } }
            },
            FinishReason = FinishReason.Continuation,
            ContinuationToken = new byte[] { 1, 2, 3 }
          }
        }
      };

      var hop2 = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            Content = new Content
            {
              Role = "model",
              Parts = new List<Part> { new Part { Text = "Part 2: The story continues. " } }
            },
            FinishReason = FinishReason.Continuation,
            ContinuationToken = new byte[] { 4, 5, 6 }
          }
        }
      };

      var hop3 = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            Content = new Content
            {
              Role = "model",
              Parts = new List<Part> { new Part { Text = "Part 3: The end." } }
            },
            FinishReason = FinishReason.Stop,
            ContinuationToken = null
          }
        }
      };

      var merged = ContinuationHelper.MergeContinuationResponses(new[] { hop1, hop2, hop3 });

      Assert.IsNotNull(merged);
      Assert.IsNotNull(merged.Candidates);
      Assert.AreEqual(1, merged.Candidates.Count);
      var candidate = merged.Candidates[0];
      Assert.IsNotNull(candidate.Content);
      Assert.IsNotNull(candidate.Content.Parts);
      Assert.AreEqual(3, candidate.Content.Parts.Count);
      Assert.AreEqual("Part 1: The story begins. ", candidate.Content.Parts[0].Text);
      Assert.AreEqual("Part 2: The story continues. ", candidate.Content.Parts[1].Text);
      Assert.AreEqual("Part 3: The end.", candidate.Content.Parts[2].Text);
      Assert.AreEqual(FinishReason.Stop, candidate.FinishReason);
      Assert.IsNull(candidate.ContinuationToken);
    }

    [TestMethod]
    public void MergeContinuationResponses_PreservesEmptyTextPartPlaceholders()
    {
      // When a continuation hop consists entirely of hidden thoughts,
      // the backend emits a synthetic placeholder Part(text="") which must be preserved.
      var hop1 = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            Content = new Content
            {
              Role = "model",
              Parts = new List<Part> { new Part { Text = "" } }
            },
            FinishReason = FinishReason.Continuation,
            ContinuationToken = new byte[] { 1 }
          }
        }
      };

      var hop2 = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            Content = new Content
            {
              Role = "model",
              Parts = new List<Part> { new Part { Text = "Final answer after thinking." } }
            },
            FinishReason = FinishReason.Stop,
            ContinuationToken = null
          }
        }
      };

      var merged = ContinuationHelper.MergeContinuationResponses(new[] { hop1, hop2 });

      Assert.IsNotNull(merged.Candidates?[0].Content?.Parts);
      Assert.AreEqual(2, merged.Candidates[0].Content.Parts.Count);
      Assert.AreEqual("", merged.Candidates[0].Content.Parts[0].Text);
      Assert.AreEqual("Final answer after thinking.", merged.Candidates[0].Content.Parts[1].Text);
    }

    [TestMethod]
    public void MergeContinuationResponses_TerminalHopOverwritesFinishReasonAndClearsToken()
    {
      var hop1 = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            FinishReason = FinishReason.Continuation,
            FinishMessage = "Token limit reached",
            ContinuationToken = new byte[] { 1, 2, 3 }
          }
        }
      };

      var hop2 = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            FinishReason = FinishReason.Stop,
            FinishMessage = "Natural stop",
            ContinuationToken = null
          }
        }
      };

      var merged = ContinuationHelper.MergeContinuationResponses(new[] { hop1, hop2 });

      var candidate = merged.Candidates![0];
      Assert.AreEqual(FinishReason.Stop, candidate.FinishReason);
      Assert.AreEqual("Natural stop", candidate.FinishMessage);
      Assert.IsNull(candidate.ContinuationToken);
    }

    [TestMethod]
    public void MergeContinuationResponses_SumsUsageMetadataTokenCounts()
    {
      var hop1 = new GenerateContentResponse
      {
        UsageMetadata = new GenerateContentResponseUsageMetadata
        {
          PromptTokenCount = 10,
          CachedContentTokenCount = 4,
          PromptTokensDetails = new List<ModalityTokenCount>
          {
            new ModalityTokenCount { Modality = MediaModality.Text, TokenCount = 10 }
          },
          CacheTokensDetails = new List<ModalityTokenCount>
          {
            new ModalityTokenCount { Modality = MediaModality.Text, TokenCount = 4 }
          },
          CandidatesTokenCount = 20,
          ThoughtsTokenCount = 5,
          TotalTokenCount = 35
        },
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            TokenCount = 20,
            FinishReason = FinishReason.Continuation,
            ContinuationToken = new byte[] { 1 }
          }
        }
      };

      var hop2 = new GenerateContentResponse
      {
        UsageMetadata = new GenerateContentResponseUsageMetadata
        {
          PromptTokenCount = 35,
          CachedContentTokenCount = 30,
          PromptTokensDetails = new List<ModalityTokenCount>
          {
            new ModalityTokenCount { Modality = MediaModality.Text, TokenCount = 35 }
          },
          CacheTokensDetails = new List<ModalityTokenCount>
          {
            new ModalityTokenCount { Modality = MediaModality.Text, TokenCount = 30 }
          },
          CandidatesTokenCount = 30,
          ThoughtsTokenCount = 15,
          TotalTokenCount = 80
        },
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            TokenCount = 30,
            FinishReason = FinishReason.Stop,
            ContinuationToken = null
          }
        }
      };

      var merged = ContinuationHelper.MergeContinuationResponses(new[] { hop1, hop2 });

      Assert.IsNotNull(merged.UsageMetadata);
      // All token counts and modality details are summed across hops
      Assert.AreEqual(45, merged.UsageMetadata.PromptTokenCount);
      Assert.AreEqual(34, merged.UsageMetadata.CachedContentTokenCount);
      Assert.AreEqual(45, merged.UsageMetadata.PromptTokensDetails?[0].TokenCount);
      Assert.AreEqual(34, merged.UsageMetadata.CacheTokensDetails?[0].TokenCount);
      Assert.AreEqual(50, merged.UsageMetadata.CandidatesTokenCount);
      Assert.AreEqual(20, merged.UsageMetadata.ThoughtsTokenCount);
      Assert.AreEqual(115, merged.UsageMetadata.TotalTokenCount);
      Assert.AreEqual(50, merged.Candidates![0].TokenCount);
      // InitialPromptTokenCount preserves Hop 1's PromptTokenCount
      Assert.AreEqual(10, merged.UsageMetadata.InitialPromptTokenCount);
      Assert.AreEqual(10, merged.InitialPromptTokenCount);

      // Direct MergeUsageMetadata produces identical results
      var directMergedUsage = ContinuationHelper.MergeUsageMetadata(hop1.UsageMetadata, hop2.UsageMetadata);
      Assert.IsNotNull(directMergedUsage);
      Assert.AreEqual(45, directMergedUsage.PromptTokenCount);
      Assert.AreEqual(34, directMergedUsage.CachedContentTokenCount);
      Assert.AreEqual(45, directMergedUsage.PromptTokensDetails?[0].TokenCount);
      Assert.AreEqual(34, directMergedUsage.CacheTokensDetails?[0].TokenCount);
      Assert.AreEqual(50, directMergedUsage.CandidatesTokenCount);
      Assert.AreEqual(20, directMergedUsage.ThoughtsTokenCount);
      Assert.AreEqual(115, directMergedUsage.TotalTokenCount);
      Assert.AreEqual(10, directMergedUsage.InitialPromptTokenCount);
    }

    [TestMethod]
    public void MergeContinuationResponses_AggregatesModalityTokenCounts()
    {
      var hop1 = new GenerateContentResponse
      {
        UsageMetadata = new GenerateContentResponseUsageMetadata
        {
          CandidatesTokensDetails = new List<ModalityTokenCount>
          {
            new ModalityTokenCount { Modality = MediaModality.Text, TokenCount = 20 }
          }
        },
        Candidates = new List<Candidate>
        {
          new Candidate { FinishReason = FinishReason.Continuation, ContinuationToken = new byte[] { 1 } }
        }
      };

      var hop2 = new GenerateContentResponse
      {
        UsageMetadata = new GenerateContentResponseUsageMetadata
        {
          CandidatesTokensDetails = new List<ModalityTokenCount>
          {
            new ModalityTokenCount { Modality = MediaModality.Text, TokenCount = 30 },
            new ModalityTokenCount { Modality = MediaModality.Image, TokenCount = 100 }
          }
        },
        Candidates = new List<Candidate>
        {
          new Candidate { FinishReason = FinishReason.Stop }
        }
      };

      var merged = ContinuationHelper.MergeContinuationResponses(new[] { hop1, hop2 });

      Assert.IsNotNull(merged.UsageMetadata?.CandidatesTokensDetails);
      var details = merged.UsageMetadata.CandidatesTokensDetails;
      Assert.AreEqual(2, details.Count);
      var textDetail = details.First(d => d.Modality == MediaModality.Text);
      Assert.AreEqual(50, textDetail.TokenCount);
      var imageDetail = details.First(d => d.Modality == MediaModality.Image);
      Assert.AreEqual(100, imageDetail.TokenCount);
    }

    [TestMethod]
    public void MergeContinuationResponses_DeduplicatesSafetyRatingsKeepingLatest()
    {
      var hop1 = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            SafetyRatings = new List<SafetyRating>
            {
              new SafetyRating
              {
                Category = HarmCategory.HarmCategoryHateSpeech,
                Probability = HarmProbability.Low
              },
              new SafetyRating
              {
                Category = HarmCategory.HarmCategoryHarassment,
                Probability = HarmProbability.Negligible
              }
            },
            FinishReason = FinishReason.Continuation,
            ContinuationToken = new byte[] { 1 }
          }
        }
      };

      var hop2 = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            SafetyRatings = new List<SafetyRating>
            {
              new SafetyRating
              {
                Category = HarmCategory.HarmCategoryHateSpeech,
                Probability = HarmProbability.Medium // Updated in hop 2
              },
              new SafetyRating
              {
                Category = HarmCategory.HarmCategoryDangerousContent,
                Probability = HarmProbability.Low
              }
            },
            FinishReason = FinishReason.Stop
          }
        }
      };

      var merged = ContinuationHelper.MergeContinuationResponses(new[] { hop1, hop2 });

      var ratings = merged.Candidates![0].SafetyRatings;
      Assert.IsNotNull(ratings);
      Assert.AreEqual(3, ratings.Count); // HateSpeech, Harassment, DangerousContent
      var hateSpeech = ratings.First(r => r.Category == HarmCategory.HarmCategoryHateSpeech);
      Assert.AreEqual(HarmProbability.Medium, hateSpeech.Probability); // Latest hop wins
    }

    [TestMethod]
    public void MergeContinuationResponses_PreservesNonOverlappingMetadata()
    {
      // Grounding metadata emitted in Hop 1 should be preserved even if absent in Hop 2
      var hop1 = new GenerateContentResponse
      {
        ModelVersion = "gemini-2.5-pro",
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            GroundingMetadata = new GroundingMetadata
            {
              WebSearchQueries = new List<string> { "what is quantum computing" }
            },
            FinishReason = FinishReason.Continuation,
            ContinuationToken = new byte[] { 1 }
          }
        }
      };

      var hop2 = new GenerateContentResponse
      {
        ModelVersion = "gemini-2.5-pro",
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            GroundingMetadata = null,
            FinishReason = FinishReason.Stop
          }
        }
      };

      var merged = ContinuationHelper.MergeContinuationResponses(new[] { hop1, hop2 });

      var candidate = merged.Candidates![0];
      Assert.IsNotNull(candidate.GroundingMetadata);
      Assert.AreEqual(1, candidate.GroundingMetadata.WebSearchQueries?.Count);
      Assert.AreEqual("what is quantum computing", candidate.GroundingMetadata.WebSearchQueries?[0]);
    }

    [TestMethod]
    public void MergeContinuationResponses_EmptyCandidatesHop_ClearsFinishReasonAndPreservesPromptFeedback()
    {
      var hop1 = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            Content = new Content
            {
              Role = "model",
              Parts = new List<Part> { new Part { Text = "Partial output before block." } }
            },
            FinishReason = FinishReason.Continuation,
            ContinuationToken = new byte[] { 1, 2, 3 },
            FinishMessage = "Continuing"
          }
        },
        UsageMetadata = new GenerateContentResponseUsageMetadata
        {
          PromptTokenCount = 10,
          CandidatesTokenCount = 100,
          TotalTokenCount = 110
        }
      };

      foreach (var emptyCandidates in new List<Candidate>?[] { null, new List<Candidate>() })
      {
        var hop2 = new GenerateContentResponse
        {
          Candidates = emptyCandidates,
          PromptFeedback = new GenerateContentResponsePromptFeedback
          {
            BlockReason = BlockedReason.Other,
            BlockReasonMessage = "Blocked on continuation hop"
          },
          UsageMetadata = new GenerateContentResponseUsageMetadata
          {
            PromptTokenCount = 110,
            TotalTokenCount = 110
          }
        };

        var merged = ContinuationHelper.MergeContinuationResponses(new[] { hop1, hop2 });

        Assert.AreEqual("Partial output before block.", merged.Text);
        Assert.IsNotNull(merged.Candidates);
        Assert.AreEqual(1, merged.Candidates.Count);
        Assert.IsNull(merged.Candidates[0].FinishReason);
        Assert.IsNull(merged.Candidates[0].ContinuationToken);
        Assert.IsNull(merged.Candidates[0].FinishMessage);
        Assert.IsNotNull(merged.PromptFeedback);
        Assert.AreEqual(BlockedReason.Other, merged.PromptFeedback.BlockReason);
        Assert.AreEqual("Blocked on continuation hop", merged.PromptFeedback.BlockReasonMessage);
        Assert.IsNotNull(merged.UsageMetadata);
        Assert.AreEqual(120, merged.UsageMetadata.PromptTokenCount);
        Assert.AreEqual(10, merged.UsageMetadata.InitialPromptTokenCount);
      }
    }

    [TestMethod]
    public void MergeContinuationResponses_EmptyListAndSingleHop_HandledCorrectly()
    {
      var emptyResult = ContinuationHelper.MergeContinuationResponses(Array.Empty<GenerateContentResponse>());
      Assert.IsNotNull(emptyResult);
      Assert.IsNull(emptyResult.Candidates);

      var single = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate { FinishReason = FinishReason.Stop }
        }
      };
      var singleResult = ContinuationHelper.MergeContinuationResponses(new[] { single });
      Assert.AreSame(single, singleResult);
    }

    [TestMethod]
    public void MergeContinuationResponses_ModalityTokenCounts_EmptyHop1_PopulatedHop2()
    {
      var hop1 = new GenerateContentResponse
      {
        UsageMetadata = new GenerateContentResponseUsageMetadata
        {
          PromptTokensDetails = new List<ModalityTokenCount>()
        }
      };

      var hop2 = new GenerateContentResponse
      {
        UsageMetadata = new GenerateContentResponseUsageMetadata
        {
          PromptTokensDetails = new List<ModalityTokenCount>
          {
            new ModalityTokenCount { Modality = MediaModality.Text, TokenCount = 10 }
          }
        }
      };

      var merged = ContinuationHelper.MergeContinuationResponses(new[] { hop1, hop2 });
      Assert.IsNotNull(merged.UsageMetadata?.PromptTokensDetails);
      Assert.AreEqual(1, merged.UsageMetadata.PromptTokensDetails.Count);
      Assert.AreEqual(MediaModality.Text, merged.UsageMetadata.PromptTokensDetails[0].Modality);
      Assert.AreEqual(10, merged.UsageMetadata.PromptTokensDetails[0].TokenCount);
    }

    [TestMethod]
    public void MergeContinuationResponses_MultipleCandidates_MergedElementWise()
    {
      var hop1 = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            Index = 0,
            Content = new Content { Role = "model", Parts = new List<Part> { new Part { Text = "c0_1 " } } },
            FinishReason = FinishReason.Continuation,
            ContinuationToken = new byte[] { 1 }
          },
          new Candidate
          {
            Index = 1,
            Content = new Content { Role = "model", Parts = new List<Part> { new Part { Text = "c1_1 " } } },
            FinishReason = FinishReason.Continuation,
            ContinuationToken = new byte[] { 2 }
          }
        }
      };

      var hop2 = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            Index = 0,
            Content = new Content { Role = "model", Parts = new List<Part> { new Part { Text = "c0_2" } } },
            FinishReason = FinishReason.Stop,
            ContinuationToken = null
          },
          new Candidate
          {
            Index = 1,
            Content = new Content { Role = "model", Parts = new List<Part> { new Part { Text = "c1_2" } } },
            FinishReason = FinishReason.Stop,
            ContinuationToken = null
          },
          new Candidate
          {
            Index = 2,
            Content = new Content { Role = "model", Parts = new List<Part> { new Part { Text = "c2_2" } } },
            FinishReason = FinishReason.Stop,
            ContinuationToken = null
          }
        }
      };

      var merged = ContinuationHelper.MergeContinuationResponses(new[] { hop1, hop2 });
      Assert.IsNotNull(merged.Candidates);
      Assert.AreEqual(3, merged.Candidates.Count);

      // Candidate 0
      Assert.AreEqual("c0_1 ", merged.Candidates[0].Content?.Parts?[0].Text);
      Assert.AreEqual("c0_2", merged.Candidates[0].Content?.Parts?[1].Text);
      Assert.AreEqual(FinishReason.Stop, merged.Candidates[0].FinishReason);
      Assert.IsNull(merged.Candidates[0].ContinuationToken);

      // Candidate 1
      Assert.AreEqual("c1_1 ", merged.Candidates[1].Content?.Parts?[0].Text);
      Assert.AreEqual("c1_2", merged.Candidates[1].Content?.Parts?[1].Text);
      Assert.AreEqual(FinishReason.Stop, merged.Candidates[1].FinishReason);
      Assert.IsNull(merged.Candidates[1].ContinuationToken);

      // Candidate 2 (only in hop 2)
      Assert.AreEqual("c2_2", merged.Candidates[2].Content?.Parts?[0].Text);
      Assert.AreEqual(FinishReason.Stop, merged.Candidates[2].FinishReason);
    }

    [TestMethod]
    public void MergeContinuationResponses_RecursiveMetadataMerging_CombinesAllMetadata()
    {
      var hop1 = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            Content = new Content
            {
              Role = "model",
              Parts = new List<Part> { new Part { Text = "Part 1 " } }
            },
            FinishReason = FinishReason.Continuation,
            ContinuationToken = new byte[] { 1 },
            SafetyRatings = new List<SafetyRating>
            {
              new SafetyRating
              {
                Category = HarmCategory.HarmCategoryHateSpeech,
                Probability = HarmProbability.Negligible
              }
            },
            CitationMetadata = new CitationMetadata
            {
              Citations = new List<Citation>
              {
                new Citation { Title = "Source 1", StartIndex = 0 }
              }
            },
            GroundingMetadata = new GroundingMetadata
            {
              WebSearchQueries = new List<string> { "query 1" }
            },
            LogprobsResult = new LogprobsResult
            {
              LogProbabilitySum = -1.5f,
              ChosenCandidates = new List<LogprobsResultCandidate>
              {
                new LogprobsResultCandidate { Token = "tok1", LogProbability = -1.5f }
              }
            }
          }
        },
        UsageMetadata = new GenerateContentResponseUsageMetadata
        {
          PromptTokenCount = 20,
          CandidatesTokenCount = 100,
          TotalTokenCount = 120,
          PromptTokensDetails = new List<ModalityTokenCount>
          {
            new ModalityTokenCount { Modality = MediaModality.Text, TokenCount = 20 }
          }
        }
      };

      var hop2 = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            Content = new Content
            {
              Role = "model",
              Parts = new List<Part> { new Part { Text = "Part 2" } }
            },
            FinishReason = FinishReason.Stop,
            ContinuationToken = null,
            SafetyRatings = new List<SafetyRating>
            {
              new SafetyRating
              {
                Category = HarmCategory.HarmCategoryHateSpeech,
                Probability = HarmProbability.Low
              },
              new SafetyRating
              {
                Category = HarmCategory.HarmCategoryHarassment,
                Probability = HarmProbability.Negligible
              }
            },
            CitationMetadata = new CitationMetadata
            {
              Citations = new List<Citation>
              {
                new Citation { Title = "Source 2", StartIndex = 10 }
              }
            },
            GroundingMetadata = new GroundingMetadata
            {
              WebSearchQueries = new List<string> { "query 2" }
            },
            LogprobsResult = new LogprobsResult
            {
              LogProbabilitySum = -2.0f,
              ChosenCandidates = new List<LogprobsResultCandidate>
              {
                new LogprobsResultCandidate { Token = "tok2", LogProbability = -2.0f }
              }
            }
          }
        },
        UsageMetadata = new GenerateContentResponseUsageMetadata
        {
          PromptTokenCount = 120,
          CandidatesTokenCount = 50,
          TotalTokenCount = 170,
          PromptTokensDetails = new List<ModalityTokenCount>
          {
            new ModalityTokenCount { Modality = MediaModality.Text, TokenCount = 120 }
          }
        }
      };

      var merged = ContinuationHelper.MergeContinuationResponses(new[] { hop1, hop2 });

      Assert.IsNotNull(merged.Candidates?[0]);
      var cand = merged.Candidates[0];
      Assert.AreEqual(2, cand.SafetyRatings?.Count);
      var hateSpeech = cand.SafetyRatings?.First(r => r.Category == HarmCategory.HarmCategoryHateSpeech);
      Assert.AreEqual(HarmProbability.Low, hateSpeech?.Probability); // Latest wins
      Assert.AreEqual(2, cand.CitationMetadata?.Citations?.Count);
      CollectionAssert.AreEqual(new[] { "query 1", "query 2" }, cand.GroundingMetadata?.WebSearchQueries?.ToArray());
      Assert.AreEqual(-3.5f, cand.LogprobsResult?.LogProbabilitySum);
      Assert.AreEqual(2, cand.LogprobsResult?.ChosenCandidates?.Count);
      Assert.AreEqual(140, merged.UsageMetadata?.PromptTokenCount);
      Assert.AreEqual(150, merged.UsageMetadata?.CandidatesTokenCount);
      Assert.AreEqual(290, merged.UsageMetadata?.TotalTokenCount);
      Assert.AreEqual(140, merged.UsageMetadata?.PromptTokensDetails?[0].TokenCount);
      Assert.AreEqual(20, merged.UsageMetadata?.InitialPromptTokenCount);
      Assert.AreEqual(20, merged.InitialPromptTokenCount);
    }

    [TestMethod]
    public void MergeContinuationResponses_ShiftsGroundingSupportChunkAndPartIndices()
    {
      var hop1 = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            Index = 0,
            Content = new Content
            {
              Role = "model",
              Parts = new List<Part>
              {
                new Part { Text = "Thinking...", Thought = true },
                new Part { Text = "part 1 " }
              }
            },
            FinishReason = FinishReason.Continuation,
            ContinuationToken = new byte[] { 1 },
            GroundingMetadata = new GroundingMetadata
            {
              GroundingChunks = new List<GroundingChunk>
              {
                new GroundingChunk
                {
                  Image = new GroundingChunkImage
                  {
                    ImageUri = "https://img1.example/a.png",
                    SourceUri = "https://source1.example/img",
                    Title = "Image 1",
                    Domain = "source1.example"
                  }
                },
                new GroundingChunk
                {
                  Web = new GroundingChunkWeb
                  {
                    Uri = "https://source1.example",
                    Title = "Source 1"
                  }
                }
              },
              GroundingSupports = new List<GroundingSupport>
              {
                new GroundingSupport
                {
                  GroundingChunkIndices = new List<int> { 0, 1 },
                  ConfidenceScores = new List<double> { 0.9, 0.8 },
                  Segment = new Segment
                  {
                    PartIndex = 1,
                    StartIndex = 0,
                    EndIndex = 7,
                    Text = "part 1 "
                  }
                }
              }
            }
          }
        }
      };

      var hop2 = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            Index = 0,
            Content = new Content
            {
              Role = "model",
              Parts = new List<Part>
              {
                new Part { Text = "part 2 " }
              }
            },
            FinishReason = FinishReason.Stop,
            GroundingMetadata = new GroundingMetadata
            {
              GroundingChunks = new List<GroundingChunk>
              {
                new GroundingChunk
                {
                  Web = new GroundingChunkWeb
                  {
                    Uri = "https://source2.example",
                    Title = "Source 2"
                  }
                }
              },
              GroundingSupports = new List<GroundingSupport>
              {
                new GroundingSupport
                {
                  GroundingChunkIndices = new List<int> { 0 },
                  ConfidenceScores = new List<double> { 0.95 },
                  Segment = new Segment
                  {
                    PartIndex = 0,
                    StartIndex = 0,
                    EndIndex = 7,
                    Text = "part 2 "
                  }
                },
                new GroundingSupport
                {
                  GroundingChunkIndices = new List<int> { 0 },
                  Segment = new Segment
                  {
                    StartIndex = 0,
                    EndIndex = 7,
                    Text = "part 2 "
                  }
                }
              }
            }
          }
        }
      };

      var merged = ContinuationHelper.MergeContinuationResponses(new[] { hop1, hop2 });
      var cand = merged.Candidates?[0];
      Assert.IsNotNull(cand);
      var gm = cand.GroundingMetadata;
      Assert.IsNotNull(gm);
      Assert.AreEqual(3, gm.GroundingChunks?.Count);
      Assert.AreEqual(3, gm.GroundingSupports?.Count);

      var s0 = gm.GroundingSupports![0];
      CollectionAssert.AreEqual(new[] { 0, 1 }, s0.GroundingChunkIndices?.ToArray());
      Assert.AreEqual(1, s0.Segment?.PartIndex);

      var s1 = gm.GroundingSupports[1];
      CollectionAssert.AreEqual(new[] { 2 }, s1.GroundingChunkIndices?.ToArray());
      Assert.AreEqual(2, s1.Segment?.PartIndex);
      Assert.AreEqual("https://source2.example", gm.GroundingChunks![s1.GroundingChunkIndices![0]].Web?.Uri);
      Assert.AreEqual("part 2 ", cand.Content?.Parts?[s1.Segment!.PartIndex!.Value].Text);

      var s2 = gm.GroundingSupports[2];
      CollectionAssert.AreEqual(new[] { 2 }, s2.GroundingChunkIndices?.ToArray());
      Assert.AreEqual(2, s2.Segment?.PartIndex);
    }

    [TestMethod]
    public void MergeContinuationResponses_GroundingSupportsCornerCases()
    {
      var hop1 = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            Index = 0,
            Content = new Content
            {
              Role = "model",
              Parts = new List<Part> { new Part { Text = "c0-h1-p0 " }, new Part { Text = "c0-h1-p1 " } }
            },
            GroundingMetadata = null,
            FinishReason = FinishReason.Continuation,
            ContinuationToken = new byte[] { 1 }
          },
          new Candidate
          {
            Index = 1,
            Content = new Content
            {
              Role = "model",
              Parts = new List<Part> { new Part { Text = "c1-h1-p0 " } }
            },
            GroundingMetadata = new GroundingMetadata
            {
              GroundingChunks = new List<GroundingChunk>
              {
                new GroundingChunk { Web = new GroundingChunkWeb { Uri = "https://c1-s0.example" } }
              }
            },
            FinishReason = FinishReason.Continuation,
            ContinuationToken = new byte[] { 1 }
          }
        }
      };

      var hop2 = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            Index = 0,
            Content = new Content
            {
              Role = "model",
              Parts = new List<Part> { new Part { Text = "c0-h2-p0 " } }
            },
            GroundingMetadata = new GroundingMetadata
            {
              GroundingChunks = new List<GroundingChunk>
              {
                new GroundingChunk { Web = new GroundingChunkWeb { Uri = "https://c0-s0.example" } },
                new GroundingChunk { Web = new GroundingChunkWeb { Uri = "https://c0-s1.example" } }
              }
            },
            FinishReason = FinishReason.Continuation,
            ContinuationToken = new byte[] { 2 }
          },
          new Candidate
          {
            Index = 1,
            Content = new Content
            {
              Role = "model",
              Parts = new List<Part> { new Part { Text = "c1-h2-p0 " } }
            },
            GroundingMetadata = new GroundingMetadata
            {
              GroundingChunks = new List<GroundingChunk>
              {
                new GroundingChunk { Web = new GroundingChunkWeb { Uri = "https://c1-s1.example" } }
              },
              GroundingSupports = new List<GroundingSupport>
              {
                new GroundingSupport
                {
                  GroundingChunkIndices = new List<int> { 0 },
                  Segment = new Segment { PartIndex = 0, Text = "c1-h2-p0 " }
                }
              }
            },
            FinishReason = FinishReason.Stop
          }
        }
      };

      var hop3 = new GenerateContentResponse
      {
        Candidates = new List<Candidate>
        {
          new Candidate
          {
            Index = 0,
            Content = new Content
            {
              Role = "model",
              Parts = new List<Part> { new Part { Text = "c0-h3-p0." } }
            },
            GroundingMetadata = new GroundingMetadata
            {
              GroundingChunks = new List<GroundingChunk>
              {
                new GroundingChunk { Web = new GroundingChunkWeb { Uri = "https://c0-s2.example" } }
              },
              GroundingSupports = new List<GroundingSupport>
              {
                new GroundingSupport
                {
                  GroundingChunkIndices = new List<int> { 0 },
                  Segment = null
                },
                new GroundingSupport
                {
                  GroundingChunkIndices = new List<int>(),
                  Segment = new Segment { PartIndex = 0, Text = "c0-h3-p0." }
                },
                new GroundingSupport
                {
                  GroundingChunkIndices = new List<int> { 0 },
                  Segment = new Segment { PartIndex = 0, Text = "c0-h3-p0." }
                }
              }
            },
            FinishReason = FinishReason.Stop
          }
        }
      };

      var merged = ContinuationHelper.MergeContinuationResponses(new[] { hop1, hop2, hop3 });
      Assert.IsNotNull(merged);
      var cand0 = merged.Candidates![0];
      var gm0 = cand0.GroundingMetadata!;
      Assert.AreEqual(4, cand0.Content?.Parts?.Count);
      Assert.AreEqual(3, gm0.GroundingChunks?.Count);
      Assert.AreEqual(3, gm0.GroundingSupports?.Count);
      Assert.IsNull(gm0.GroundingSupports![0].Segment);
      CollectionAssert.AreEqual(new[] { 2 }, gm0.GroundingSupports[0].GroundingChunkIndices?.ToArray());
      Assert.AreEqual(0, gm0.GroundingSupports[1].GroundingChunkIndices?.Count ?? 0);
      Assert.AreEqual(3, gm0.GroundingSupports[1].Segment?.PartIndex);
      var s2 = gm0.GroundingSupports[2];
      Assert.AreEqual("https://c0-s2.example", gm0.GroundingChunks![s2.GroundingChunkIndices![0]].Web?.Uri);
      Assert.AreEqual("c0-h3-p0.", cand0.Content?.Parts?[s2.Segment!.PartIndex!.Value].Text);

      var cand1 = merged.Candidates[1];
      var gm1 = cand1.GroundingMetadata!;
      CollectionAssert.AreEqual(new[] { 1 }, gm1.GroundingSupports![0].GroundingChunkIndices?.ToArray());
      Assert.AreEqual(1, gm1.GroundingSupports[0].Segment?.PartIndex);
      Assert.AreEqual("https://c1-s1.example", gm1.GroundingChunks![gm1.GroundingSupports[0].GroundingChunkIndices![0]].Web?.Uri);
      Assert.AreEqual("c1-h2-p0 ", cand1.Content?.Parts?[gm1.GroundingSupports[0].Segment!.PartIndex!.Value].Text);
    }

    #endregion

    #region E2E Models Unary Continuation Tests

    [TestMethod]
    public async Task Models_GenerateContentAsync_MultiHopContinuation_UnaryMerged()
    {
      string hop1Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "First hop part. " }]
            },
            "finishReason": "CONTINUATION",
            "continuationToken": "AQID"
          }
        ],
        "usageMetadata": {
          "promptTokenCount": 5,
          "candidatesTokenCount": 10,
          "totalTokenCount": 15
        }
      }
      """;

      string hop2Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "Second hop part." }]
            },
            "finishReason": "STOP"
          }
        ],
        "usageMetadata": {
          "promptTokenCount": 5,
          "candidatesTokenCount": 12,
          "totalTokenCount": 17
        }
      }
      """;

      var apiClient = new MockContinuationApiClient(hop1Json, hop2Json);
      var models = new Models(apiClient);

      var config = new GenerateContentConfig { AutomaticContinuation = true };
      var response = await models.GenerateContentAsync("gemini-2.5-pro", "Tell me a long story", config);

      Assert.IsNotNull(response);
      Assert.AreEqual(2, apiClient.RequestsReceived.Count);

      // Verify hop 2 received the continuation token in its request payload
      string hop2Request = apiClient.RequestsReceived[1];
      Assert.IsTrue(hop2Request.Contains("continuationToken") || hop2Request.Contains("continuation_token"),
          $"Hop 2 request should include continuationToken. Actual: {hop2Request}");

      // Verify response is merged
      Assert.AreEqual(1, response.Candidates?.Count);
      var candidate = response.Candidates![0];
      Assert.AreEqual(2, candidate.Content?.Parts?.Count);
      Assert.AreEqual("First hop part. ", candidate.Content?.Parts?[0].Text);
      Assert.AreEqual("Second hop part.", candidate.Content?.Parts?[1].Text);
      Assert.AreEqual(FinishReason.Stop, candidate.FinishReason);
      Assert.IsNull(candidate.ContinuationToken);

      // Verify token counts summed and InitialPromptTokenCount preserved
      Assert.AreEqual(10, response.UsageMetadata?.PromptTokenCount);
      Assert.AreEqual(22, response.UsageMetadata?.CandidatesTokenCount);
      Assert.AreEqual(32, response.UsageMetadata?.TotalTokenCount);
      Assert.AreEqual(5, response.UsageMetadata?.InitialPromptTokenCount);
      Assert.AreEqual(5, response.InitialPromptTokenCount);
    }

    [TestMethod]
    public async Task Models_GenerateContentAsync_GroundingMetadataMergedAcrossHops()
    {
      string hop1Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "part 1 " }]
            },
            "finishReason": "CONTINUATION",
            "continuationToken": "AQID",
            "groundingMetadata": {
              "groundingChunks": [
                { "web": { "uri": "https://source1.example" } }
              ],
              "groundingSupports": [
                {
                  "groundingChunkIndices": [0],
                  "segment": { "partIndex": 0, "text": "part 1 " }
                }
              ]
            }
          }
        ]
      }
      """;

      string hop2Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "part 2 " }]
            },
            "finishReason": "STOP",
            "groundingMetadata": {
              "groundingChunks": [
                { "web": { "uri": "https://source2.example" } }
              ],
              "groundingSupports": [
                {
                  "groundingChunkIndices": [0],
                  "segment": { "partIndex": 0, "text": "part 2 " }
                }
              ]
            }
          }
        ]
      }
      """;

      var apiClient = new MockContinuationApiClient(hop1Json, hop2Json);
      var models = new Models(apiClient);
      var response = await models.GenerateContentAsync("gemini-2.5-pro", "hi");

      Assert.IsNotNull(response);
      var cand = response.Candidates![0];
      var gm = cand.GroundingMetadata!;
      Assert.AreEqual(2, gm.GroundingSupports?.Count);
      var s = gm.GroundingSupports![1];
      Assert.AreEqual("https://source2.example", gm.GroundingChunks![s.GroundingChunkIndices![0]].Web?.Uri);
      Assert.AreEqual("part 2 ", cand.Content?.Parts?[s.Segment!.PartIndex!.Value].Text);
    }

    [TestMethod]
    public async Task Models_GenerateContentAsync_ContinuationDisabled_SingleHop()
    {
      string hop1Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "First hop part. " }]
            },
            "finishReason": "CONTINUATION",
            "continuationToken": "AQID"
          }
        ]
      }
      """;

      var apiClient = new MockContinuationApiClient(hop1Json);
      var models = new Models(apiClient);

      // Explicit AutomaticContinuation = false disables continuation
      var response = await models.GenerateContentAsync(
          "gemini-2.5-pro",
          "Prompt",
          new GenerateContentConfig { AutomaticContinuation = false });

      Assert.IsNotNull(response);
      Assert.AreEqual(1, apiClient.RequestsReceived.Count);
      Assert.AreEqual(FinishReason.Continuation, response.Candidates?[0].FinishReason);
      CollectionAssert.AreEqual(Convert.FromBase64String("AQID"), response.Candidates?[0].ContinuationToken);
    }

    [TestMethod]
    public async Task Models_GenerateContentAsync_ContinuesByDefault()
    {
      string hop1Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "First hop part. " }]
            },
            "finishReason": "CONTINUATION",
            "continuationToken": "AQID"
          }
        ]
      }
      """;

      string hop2Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "Second hop part." }]
            },
            "finishReason": "STOP"
          }
        ]
      }
      """;

      var apiClient = new MockContinuationApiClient(hop1Json, hop2Json);
      var models = new Models(apiClient);

      // Default (unset) in Models: continuation is enabled
      var response = await models.GenerateContentAsync("gemini-2.5-pro", "Prompt");

      Assert.IsNotNull(response);
      Assert.AreEqual(2, apiClient.RequestsReceived.Count);
      Assert.AreEqual("First hop part. Second hop part.", response.Text);
      Assert.AreEqual(FinishReason.Stop, response.Candidates?[0].FinishReason);
    }

    [TestMethod]
    public async Task Models_GenerateContentAsync_MaxOutputTokensSet_PassesValueAndContinues()
    {
      string hop1Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "First hop part. " }]
            },
            "finishReason": "CONTINUATION",
            "continuationToken": "AQID"
          }
        ]
      }
      """;

      string hop2Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "Second hop part." }]
            },
            "finishReason": "MAX_TOKENS"
          }
        ]
      }
      """;

      var apiClient = new MockContinuationApiClient(hop1Json, hop2Json);
      var models = new Models(apiClient);

      // MaxOutputTokens is passed to the backend and does not disable continuation
      var config = new GenerateContentConfig
      {
        AutomaticContinuation = true,
        MaxOutputTokens = 100
      };
      var response = await models.GenerateContentAsync("gemini-2.5-pro", "Prompt", config);

      Assert.AreEqual("First hop part. Second hop part.", response.Text);
      Assert.AreEqual("First hop part. ", response.Candidates?[0].Content?.Parts?[0].Text);
      Assert.AreEqual("Second hop part.", response.Candidates?[0].Content?.Parts?[1].Text);
      // Loop stopped because hop 2 finishReason was MAX_TOKENS (!= CONTINUATION)
      Assert.AreEqual(FinishReason.MaxTokens, response.Candidates?[0].FinishReason);

      // Verify maxOutputTokens was passed in both requests
      Assert.IsTrue(apiClient.RequestsReceived[0].Contains("100"), "Hop 1 should include maxOutputTokens: 100");
      Assert.IsTrue(apiClient.RequestsReceived[1].Contains("100"), "Hop 2 should include maxOutputTokens: 100");
    }

    [TestMethod]
    public async Task Models_GenerateContentAsync_AutoResumesAcross4Hops_SumsAllUsageAndPreservesContents()
    {
      string hop1Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "Hop 1 part. " }]
            },
            "finishReason": "CONTINUATION",
            "continuationToken": "dG9rZW5faG9wXzE="
          }
        ],
        "usageMetadata": {
          "promptTokenCount": 10,
          "candidatesTokenCount": 32768,
          "thoughtsTokenCount": 500,
          "totalTokenCount": 33278
        }
      }
      """;

      string hop2Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "Hop 2 part. " }]
            },
            "finishReason": "CONTINUATION",
            "continuationToken": "dG9rZW5faG9wXzI="
          }
        ],
        "usageMetadata": {
          "promptTokenCount": 32778,
          "candidatesTokenCount": 32768,
          "thoughtsTokenCount": 300,
          "totalTokenCount": 65846
        }
      }
      """;

      string hop3Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "Hop 3 part. " }]
            },
            "finishReason": "CONTINUATION",
            "continuationToken": "dG9rZW5faG9wXzM="
          }
        ],
        "usageMetadata": {
          "promptTokenCount": 65546,
          "candidatesTokenCount": 32768,
          "thoughtsTokenCount": 200,
          "totalTokenCount": 98514
        }
      }
      """;

      string hop4Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "Hop 4 final part." }]
            },
            "finishReason": "STOP"
          }
        ],
        "usageMetadata": {
          "promptTokenCount": 98314,
          "candidatesTokenCount": 1024,
          "thoughtsTokenCount": 100,
          "totalTokenCount": 99438
        }
      }
      """;

      var apiClient = new MockContinuationApiClient(hop1Json, hop2Json, hop3Json, hop4Json);
      var models = new Models(apiClient);

      var userConfig = new GenerateContentConfig { AutomaticContinuation = true };
      var response = await models.GenerateContentAsync("gemini-2.5-pro", "Write a very long story", userConfig);

      Assert.IsNotNull(response);
      Assert.AreEqual(4, apiClient.RequestsReceived.Count);

      // Verify each hop received the continuation token from the prior hop
      Assert.IsFalse(apiClient.RequestsReceived[0].Contains("dG9rZW5faG9wXzE="));
      Assert.IsTrue(apiClient.RequestsReceived[1].Contains("dG9rZW5faG9wXzE="));
      Assert.IsTrue(apiClient.RequestsReceived[2].Contains("dG9rZW5faG9wXzI="));
      Assert.IsTrue(apiClient.RequestsReceived[3].Contains("dG9rZW5faG9wXzM="));

      // Verify contents in prompt are unchanged across all requests
      foreach (var req in apiClient.RequestsReceived)
      {
        Assert.IsTrue(req.Contains("Write a very long story"));
      }

      // Verify concatenated text across all 4 hops
      Assert.AreEqual("Hop 1 part. Hop 2 part. Hop 3 part. Hop 4 final part.", response.Text);

      // Verify candidates finishReason and token
      Assert.AreEqual(FinishReason.Stop, response.Candidates?[0].FinishReason);
      Assert.IsNull(response.Candidates?[0].ContinuationToken);

      // Verify parts
      Assert.AreEqual(4, response.Candidates?[0].Content?.Parts?.Count);

      // Verify summed usage metadata and preserved initial prompt token count
      Assert.IsNotNull(response.UsageMetadata);
      Assert.AreEqual(10 + 32778 + 65546 + 98314, response.UsageMetadata.PromptTokenCount);
      Assert.AreEqual(32768 * 3 + 1024, response.UsageMetadata.CandidatesTokenCount);
      Assert.AreEqual(500 + 300 + 200 + 100, response.UsageMetadata.ThoughtsTokenCount);
      Assert.AreEqual(33278 + 65846 + 98514 + 99438, response.UsageMetadata.TotalTokenCount);
      Assert.AreEqual(10, response.UsageMetadata.InitialPromptTokenCount);
      Assert.AreEqual(10, response.InitialPromptTokenCount);

      // Verify user config was not mutated
      Assert.IsNull(userConfig.ContinuationToken);
    }

    [TestMethod]
    public async Task Models_GenerateContentAsync_ThoughtOnlyHop_PreservesEmptyTextPart()
    {
      string hop1Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "" }]
            },
            "finishReason": "CONTINUATION",
            "continuationToken": "AQID"
          }
        ]
      }
      """;

      string hop2Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "Final answer after thinking." }]
            },
            "finishReason": "STOP"
          }
        ]
      }
      """;

      var apiClient = new MockContinuationApiClient(hop1Json, hop2Json);
      var models = new Models(apiClient);

      var response = await models.GenerateContentAsync("gemini-2.5-pro", "Solve hard problem");

      Assert.IsNotNull(response);
      Assert.AreEqual(2, apiClient.RequestsReceived.Count);
      Assert.AreEqual(2, response.Candidates?[0].Content?.Parts?.Count);
      Assert.AreEqual("", response.Candidates?[0].Content?.Parts?[0].Text);
      Assert.AreEqual("Final answer after thinking.", response.Candidates?[0].Content?.Parts?[1].Text);
    }

    [TestMethod]
    public async Task Models_GenerateContentAsync_MaxTokensFinishReason_StopsContinuation_EvenWhenAutoContinuationEnabled()
    {
      string hop1Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "Stopped at hop 1 due to max tokens." }]
            },
            "finishReason": "MAX_TOKENS",
            "continuationToken": "AQID"
          }
        ]
      }
      """;

      var apiClient = new MockContinuationApiClient(hop1Json);
      var models = new Models(apiClient);

      var config = new GenerateContentConfig
      {
        AutomaticContinuation = true,
        MaxOutputTokens = 50000
      };
      var response = await models.GenerateContentAsync("gemini-2.5-pro", "Prompt", config);

      Assert.IsNotNull(response);
      Assert.AreEqual(1, apiClient.RequestsReceived.Count);
      Assert.AreEqual("Stopped at hop 1 due to max tokens.", response.Text);
      Assert.AreEqual(FinishReason.MaxTokens, response.Candidates?[0].FinishReason);
      CollectionAssert.AreEqual(Convert.FromBase64String("AQID"), response.Candidates?[0].ContinuationToken);
    }

    [TestMethod]
    public async Task Models_GenerateContentAsync_Hop2ReturnsPromptFeedbackAndNullCandidates_ClearsStaleContinuationFields()
    {
      string hop1Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "First hop text." }]
            },
            "finishReason": "CONTINUATION",
            "finishMessage": "Token limit reached",
            "continuationToken": "AQID"
          }
        ]
      }
      """;

      string hop2Json = """
      {
        "promptFeedback": {
          "blockReason": "SAFETY"
        }
      }
      """;

      var apiClient = new MockContinuationApiClient(hop1Json, hop2Json);
      var models = new Models(apiClient);

      var response = await models.GenerateContentAsync("gemini-2.5-pro", "Prompt");

      Assert.IsNotNull(response);
      Assert.AreEqual(2, apiClient.RequestsReceived.Count);
      Assert.IsNotNull(response.Candidates);
      Assert.AreEqual(1, response.Candidates.Count);
      Assert.IsNull(response.Candidates[0].FinishReason);
      Assert.IsNull(response.Candidates[0].FinishMessage);
      Assert.IsNull(response.Candidates[0].ContinuationToken);
      Assert.AreEqual("First hop text.", response.Text);
      Assert.IsNotNull(response.PromptFeedback);
      Assert.AreEqual(BlockedReason.Safety, response.PromptFeedback.BlockReason);
    }

    #endregion

    #region E2E Models Streaming Continuation Tests

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_MultiHopContinuation_StreamsAllChunks()
    {
      string hop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Stream chunk 1"}]}}]}
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Stream chunk 2"}]},"finishReason":"CONTINUATION","continuationToken":"AQID"}]}
      """;

      string hop2Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Stream chunk 3"}]}}]}
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Stream chunk 4"}]},"finishReason":"STOP"}]}
      """;

      var apiClient = new MockContinuationApiClient(hop1Stream, hop2Stream);
      var models = new Models(apiClient);

      var config = new GenerateContentConfig { AutomaticContinuation = true };

      var chunks = new List<GenerateContentResponse>();
      await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt", config))
      {
        chunks.Add(chunk);
      }

      Assert.AreEqual(4, chunks.Count);
      Assert.AreEqual(2, apiClient.RequestsReceived.Count);

      // Verify hop 2 request contained continuation token
      string hop2Request = apiClient.RequestsReceived[1];
      Assert.IsTrue(hop2Request.Contains("continuationToken") || hop2Request.Contains("continuation_token"),
          $"Hop 2 request should include continuationToken. Actual: {hop2Request}");

      // Verify chunks content in order
      Assert.AreEqual("Stream chunk 1", chunks[0].Candidates?[0].Content?.Parts?[0].Text);
      Assert.AreEqual("Stream chunk 2", chunks[1].Candidates?[0].Content?.Parts?[0].Text);
      Assert.AreEqual("Stream chunk 3", chunks[2].Candidates?[0].Content?.Parts?[0].Text);
      Assert.AreEqual("Stream chunk 4", chunks[3].Candidates?[0].Content?.Parts?[0].Text);

      // Intermediate CONTINUATION FinishReason is cleared when resuming; final STOP is preserved
      Assert.IsNull(chunks[0].Candidates?[0].FinishReason);
      Assert.IsNull(chunks[1].Candidates?[0].FinishReason);
      Assert.IsNull(chunks[2].Candidates?[0].FinishReason);
      Assert.AreEqual(FinishReason.Stop, chunks[3].Candidates?[0].FinishReason);
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_ContinuationDisabled_SingleHop()
    {
      string hop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Stream chunk 1"}]}}]}
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Stream chunk 2"}]},"finishReason":"CONTINUATION","continuationToken":"AQID"}]}
      """;

      var apiClient = new MockContinuationApiClient(hop1Stream);
      var models = new Models(apiClient);

      var chunks = new List<GenerateContentResponse>();
      // Explicit AutomaticContinuation = false disables continuation
      await foreach (var chunk in models.GenerateContentStreamAsync(
          "gemini-2.5-pro",
          "Prompt",
          new GenerateContentConfig { AutomaticContinuation = false }))
      {
        chunks.Add(chunk);
      }

      Assert.AreEqual(2, chunks.Count);
      Assert.AreEqual(1, apiClient.RequestsReceived.Count);
      Assert.AreEqual(FinishReason.Continuation, chunks[1].Candidates?[0].FinishReason);
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_ContinuesByDefault()
    {
      string hop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Stream chunk 1"}]}}]}
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Stream chunk 2"}]},"finishReason":"CONTINUATION","continuationToken":"AQID"}]}
      """;

      string hop2Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Stream chunk 3"}]}}]}
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Stream chunk 4"}]},"finishReason":"STOP"}]}
      """;

      var apiClient = new MockContinuationApiClient(hop1Stream, hop2Stream);
      var models = new Models(apiClient);

      var chunks = new List<GenerateContentResponse>();
      // Streaming continues by default without explicit config
      await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
      {
        chunks.Add(chunk);
      }

      Assert.AreEqual(4, chunks.Count);
      Assert.AreEqual(2, apiClient.RequestsReceived.Count);
      Assert.AreEqual("Stream chunk 1", chunks[0].Candidates?[0].Content?.Parts?[0].Text);
      Assert.AreEqual("Stream chunk 2", chunks[1].Candidates?[0].Content?.Parts?[0].Text);
      Assert.AreEqual("Stream chunk 3", chunks[2].Candidates?[0].Content?.Parts?[0].Text);
      Assert.AreEqual("Stream chunk 4", chunks[3].Candidates?[0].Content?.Parts?[0].Text);
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_AutoResumesAcross4Hops_StreamsAllChunks()
    {
      string hop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"# CHAPTER 1: Lexical Analysis\n"}]}}]}
      {"candidates":[{"content":{"role":"model","parts":[{"text":""}]},"finishReason":"CONTINUATION","continuationToken":"dG9rZW5faG9wXzE="}]}
      """;

      string hop2Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"## CHAPTER 2: Optimization\n"}]}}]}
      {"candidates":[{"content":{"role":"model","parts":[{"text":""}]},"finishReason":"CONTINUATION","continuationToken":"dG9rZW5faG9wXzI="}]}
      """;

      string hop3Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"## CHAPTER 3: Register Allocation\n"}]}}]}
      {"candidates":[{"content":{"role":"model","parts":[{"text":""}]},"finishReason":"CONTINUATION","continuationToken":"dG9rZW5faG9wXzM="}]}
      """;

      string hop4Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"## CHAPTER 4: Code Generation\n"}]}}]}
      {"candidates":[{"content":{"role":"model","parts":[{"text":"End of compiler textbook."}]},"finishReason":"STOP"}]}
      """;

      var apiClient = new MockContinuationApiClient(hop1Stream, hop2Stream, hop3Stream, hop4Stream);
      var models = new Models(apiClient);

      var chunks = new List<GenerateContentResponse>();
      await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Write a textbook"))
      {
        chunks.Add(chunk);
      }

      Assert.AreEqual(8, chunks.Count);
      Assert.AreEqual(4, apiClient.RequestsReceived.Count);

      // Verify tokens sent across streams
      Assert.IsTrue(apiClient.RequestsReceived[1].Contains("dG9rZW5faG9wXzE="));
      Assert.IsTrue(apiClient.RequestsReceived[2].Contains("dG9rZW5faG9wXzI="));
      Assert.IsTrue(apiClient.RequestsReceived[3].Contains("dG9rZW5faG9wXzM="));

      // Intermediate hop end chunks have FinishReason cleared; final chunk has FinishReason STOP
      Assert.IsNull(chunks[1].Candidates?[0].FinishReason);
      Assert.IsNull(chunks[3].Candidates?[0].FinishReason);
      Assert.IsNull(chunks[5].Candidates?[0].FinishReason);
      Assert.AreEqual(FinishReason.Stop, chunks[7].Candidates?[0].FinishReason);
      Assert.IsNull(chunks[7].Candidates?[0].ContinuationToken);
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_MaxTokensFinishReason_StopsContinuation_EvenWhenAutoContinuationEnabled()
    {
      string hop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Stream chunk 1. "}]}}]}
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Stopped stream at max tokens."}]},"finishReason":"MAX_TOKENS","continuationToken":"AQID"}]}
      """;

      var apiClient = new MockContinuationApiClient(hop1Stream);
      var models = new Models(apiClient);

      var config = new GenerateContentConfig
      {
        AutomaticContinuation = true,
        MaxOutputTokens = 50000
      };

      var chunks = new List<GenerateContentResponse>();
      await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt", config))
      {
        chunks.Add(chunk);
      }

      Assert.AreEqual(2, chunks.Count);
      Assert.AreEqual(1, apiClient.RequestsReceived.Count);
      Assert.AreEqual(FinishReason.MaxTokens, chunks[1].Candidates?[0].FinishReason);
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_ResumesFromCheckpointTokenOnCutoffOrMidStreamError()
    {
      // Hop 1: intermediate checkpoint chunk (finishReason is null), then stream ends early (cutoff)
      string hop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Ckpt 1, "}]},"continuationToken":"dG9rX2NrcHRfMQ=="}]}
      """;

      // Hop 2: intermediate checkpoint chunk (finishReason is null), then invalid JSON triggers mid-stream exception
      string hop2Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Ckpt 2, "}]},"continuationToken":"dG9rX2NrcHRfMg=="}]}
      {invalid_json_mid_stream
      """;

      // Hop 3: earlier checkpoint chunk followed by terminal STOP without token (should clear stale token and stop)
      string hop3Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Ckpt 3, "}]},"continuationToken":"c3RhbGVfdG9r"}]}
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Done."}]},"finishReason":"STOP"}]}
      """;

      var apiClient = new MockContinuationApiClient(hop1Stream, hop2Stream, hop3Stream);
      var models = new Models(apiClient);

      var chunks = new List<GenerateContentResponse>();
      await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
      {
        chunks.Add(chunk);
      }

      Assert.AreEqual(4, chunks.Count);
      Assert.AreEqual(3, apiClient.RequestsReceived.Count);
      Assert.IsTrue(apiClient.RequestsReceived[1].Contains("dG9rX2NrcHRfMQ=="));
      Assert.IsTrue(apiClient.RequestsReceived[2].Contains("dG9rX2NrcHRfMg=="));
      Assert.AreEqual(
          "Ckpt 1, Ckpt 2, Ckpt 3, Done.",
          string.Concat(chunks.Select(c => c.Candidates?[0].Content?.Parts?[0].Text)));
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_BlockedChunkAfterCheckpoint_DoesNotResume()
    {
      // Hop 1: text chunk, checkpoint chunk (token, no finishReason), then a blocked chunk
      // with no candidates and only promptFeedback.blockReason.
      string hop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Partial "}]}}]}
      {"candidates":[{"content":{"role":"model","parts":[{"text":"output"}]},"continuationToken":"dG9rX2NrcHQ="}]}
      {"promptFeedback":{"blockReason":"SAFETY"}}
      """;

      var apiClient = new MockContinuationApiClient(hop1Stream);
      var models = new Models(apiClient);

      var chunks = new List<GenerateContentResponse>();
      await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
      {
        chunks.Add(chunk);
      }

      Assert.AreEqual(1, apiClient.RequestsReceived.Count);
      Assert.AreEqual(3, chunks.Count);
      Assert.AreEqual("Partial ", chunks[0].Candidates?[0].Content?.Parts?[0].Text);
      Assert.AreEqual("output", chunks[1].Candidates?[0].Content?.Parts?[0].Text);
      Assert.IsNull(chunks[2].Candidates);
      Assert.AreEqual(BlockedReason.Safety, chunks[2].PromptFeedback?.BlockReason);
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_AccumulatesUsageMetadataAcrossHops()
    {
      string hop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Hop 1 chunk 1. "}]}}],"usageMetadata":{"promptTokenCount":10,"cachedContentTokenCount":4,"promptTokensDetails":[{"modality":"TEXT","tokenCount":10}],"candidatesTokenCount":5,"thoughtsTokenCount":2,"totalTokenCount":17}}
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Hop 1 chunk 2. "}]},"finishReason":"CONTINUATION","continuationToken":"AQID"}],"usageMetadata":{"promptTokenCount":10,"cachedContentTokenCount":4,"promptTokensDetails":[{"modality":"TEXT","tokenCount":10}],"candidatesTokenCount":20,"thoughtsTokenCount":5,"candidatesTokensDetails":[{"modality":"TEXT","tokenCount":20}],"totalTokenCount":35}}
      """;

      string hop2Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Hop 2 chunk 1. "}]}}],"usageMetadata":{"promptTokenCount":35,"cachedContentTokenCount":30,"promptTokensDetails":[{"modality":"TEXT","tokenCount":35}],"candidatesTokenCount":12,"thoughtsTokenCount":3,"candidatesTokensDetails":[{"modality":"TEXT","tokenCount":12}],"totalTokenCount":50}}
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Hop 2 chunk 2."}]},"finishReason":"STOP"}],"usageMetadata":{"promptTokenCount":35,"cachedContentTokenCount":30,"promptTokensDetails":[{"modality":"TEXT","tokenCount":35}],"candidatesTokenCount":30,"thoughtsTokenCount":15,"candidatesTokensDetails":[{"modality":"TEXT","tokenCount":30}],"totalTokenCount":80}}
      """;

      var apiClient = new MockContinuationApiClient(hop1Stream, hop2Stream);
      var models = new Models(apiClient);

      var chunks = new List<GenerateContentResponse>();
      await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
      {
        chunks.Add(chunk);
      }

      Assert.AreEqual(4, chunks.Count);
      Assert.AreEqual(2, apiClient.RequestsReceived.Count);

      // Hop 1 chunks retain Hop 1 usage
      Assert.AreEqual(10, chunks[1].UsageMetadata?.PromptTokenCount);
      Assert.AreEqual(10, chunks[1].UsageMetadata?.InitialPromptTokenCount);
      Assert.AreEqual(10, chunks[1].InitialPromptTokenCount);
      Assert.AreEqual(20, chunks[1].UsageMetadata?.CandidatesTokenCount);
      Assert.AreEqual(5, chunks[1].UsageMetadata?.ThoughtsTokenCount);
      Assert.AreEqual(35, chunks[1].UsageMetadata?.TotalTokenCount);

      // Hop 2 chunk 1 accumulates onto Hop 1's final usage (without double-counting later chunks)
      Assert.AreEqual(45, chunks[2].UsageMetadata?.PromptTokenCount);
      Assert.AreEqual(34, chunks[2].UsageMetadata?.CachedContentTokenCount);
      Assert.AreEqual(45, chunks[2].UsageMetadata?.PromptTokensDetails?[0].TokenCount);
      Assert.AreEqual(32, chunks[2].UsageMetadata?.CandidatesTokenCount);
      Assert.AreEqual(8, chunks[2].UsageMetadata?.ThoughtsTokenCount);
      Assert.AreEqual(85, chunks[2].UsageMetadata?.TotalTokenCount);
      Assert.AreEqual(32, chunks[2].UsageMetadata?.CandidatesTokensDetails?[0].TokenCount);
      Assert.AreEqual(10, chunks[2].UsageMetadata?.InitialPromptTokenCount);
      Assert.AreEqual(10, chunks[2].InitialPromptTokenCount);

      // Hop 2 final chunk has total accumulated usage across both hops and preserves Hop 1's InitialPromptTokenCount
      Assert.AreEqual(45, chunks[3].UsageMetadata?.PromptTokenCount);
      Assert.AreEqual(34, chunks[3].UsageMetadata?.CachedContentTokenCount);
      Assert.AreEqual(45, chunks[3].UsageMetadata?.PromptTokensDetails?[0].TokenCount);
      Assert.AreEqual(50, chunks[3].UsageMetadata?.CandidatesTokenCount);
      Assert.AreEqual(20, chunks[3].UsageMetadata?.ThoughtsTokenCount);
      Assert.AreEqual(115, chunks[3].UsageMetadata?.TotalTokenCount);
      Assert.AreEqual(50, chunks[3].UsageMetadata?.CandidatesTokensDetails?[0].TokenCount);
      Assert.AreEqual(10, chunks[3].UsageMetadata?.InitialPromptTokenCount);
      Assert.AreEqual(10, chunks[3].InitialPromptTokenCount);
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_GroundingMetadataAcrossHopsAndMerged()
    {
      string hop1Stream = string.Join("\n", new[]
      {
        "data: {\"candidates\": [{\"content\": {\"role\": \"model\", \"parts\": [{\"text\": \"hop 1 intro, \"}]}}]}",
        "",
        "data: {\"candidates\": [{\"content\": {\"role\": \"model\", \"parts\": [{\"text\": \"hop 1 grounded. \"}]}, \"finishReason\": \"CONTINUATION\", \"continuationToken\": \"AQID\", \"groundingMetadata\": {\"groundingChunks\": [{\"web\": {\"uri\": \"https://source1.example\"}}], \"groundingSupports\": [{\"groundingChunkIndices\": [0], \"segment\": {\"partIndex\": 0, \"text\": \"hop 1 grounded. \"}}]}}]}",
        ""
      });

      string hop2Stream = string.Join("\n", new[]
      {
        "data: {\"candidates\": [{\"content\": {\"role\": \"model\", \"parts\": [{\"text\": \"hop 2 intro, \"}]}}]}",
        "",
        "data: {\"candidates\": [{\"content\": {\"role\": \"model\", \"parts\": [{\"text\": \"hop 2 grounded.\"}]}, \"finishReason\": \"STOP\", \"groundingMetadata\": {\"groundingChunks\": [{\"web\": {\"uri\": \"https://source2.example\"}}], \"groundingSupports\": [{\"groundingChunkIndices\": [0], \"segment\": {\"partIndex\": 0, \"text\": \"hop 2 grounded.\"}}]}}]}",
        ""
      });

      var apiClient = new MockContinuationApiClient(hop1Stream, hop2Stream);
      var models = new Models(apiClient);

      var chunks = new List<GenerateContentResponse>();
      await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
      {
        chunks.Add(chunk);
      }

      Assert.AreEqual(4, chunks.Count);
      var sHop1 = chunks[1].Candidates![0].GroundingMetadata!.GroundingSupports![0];
      Assert.AreEqual("https://source1.example", chunks[1].Candidates![0].GroundingMetadata!.GroundingChunks![sHop1.GroundingChunkIndices![0]].Web?.Uri);
      Assert.AreEqual("hop 1 grounded. ", chunks[1].Candidates![0].Content!.Parts![sHop1.Segment!.PartIndex!.Value].Text);
      Assert.IsNull(chunks[1].Candidates![0].FinishReason);

      var sHop2 = chunks[3].Candidates![0].GroundingMetadata!.GroundingSupports![0];
      Assert.AreEqual("https://source2.example", chunks[3].Candidates![0].GroundingMetadata!.GroundingChunks![sHop2.GroundingChunkIndices![0]].Web?.Uri);
      Assert.AreEqual("hop 2 grounded.", chunks[3].Candidates![0].Content!.Parts![sHop2.Segment!.PartIndex!.Value].Text);
      Assert.AreEqual(FinishReason.Stop, chunks[3].Candidates![0].FinishReason);

      var merged = ContinuationHelper.MergeContinuationResponses(chunks)!;
      var cand = merged.Candidates![0];
      var gm = cand.GroundingMetadata!;
      Assert.AreEqual(2, gm.GroundingSupports?.Count);
      Assert.AreEqual("https://source1.example", gm.GroundingChunks![gm.GroundingSupports![0].GroundingChunkIndices![0]].Web?.Uri);
      Assert.AreEqual("hop 1 grounded. ", cand.Content!.Parts![gm.GroundingSupports[0].Segment!.PartIndex!.Value].Text);
      Assert.AreEqual("https://source2.example", gm.GroundingChunks![gm.GroundingSupports[1].GroundingChunkIndices![0]].Web?.Uri);
      Assert.AreEqual("hop 2 grounded.", cand.Content!.Parts![gm.GroundingSupports[1].Segment!.PartIndex!.Value].Text);
    }

    private static (byte[]? ContinuationToken, int ReconnectsWithoutProgress) NextResumeToken(
        byte[]? hopStartToken,
        byte[]? hopToken,
        FinishReason? finishReason,
        int reconnectsWithoutProgress,
        bool hasPromptFeedback = false,
        bool hopHasYieldedContent = false)
    {
      var state = new StreamContinuation(config: null)
      {
        ReconnectsWithoutProgress = reconnectsWithoutProgress,
        CurrentHop = new StreamContinuation.Hop
        {
          StartToken = hopStartToken,
          Token = hopToken,
          FinishReason = finishReason,
          HasPromptFeedback = hasPromptFeedback,
          HasYieldedContent = hopHasYieldedContent,
        },
      };
      return state.NextResumeToken();
    }

    [TestMethod]
    public void NextStreamContinuationToken_ValidatesProgressAndRetryBudget()
    {
      byte[] tok1 = new byte[] { 1, 2, 3 };
      byte[] tok1Copy = new byte[] { 1, 2, 3 };
      byte[] tok2 = new byte[] { 4, 5, 6 };

      // 1. New checkpoint token resets reconnectsWithoutProgress to 0
      var (nextTok, reconnects) = NextResumeToken(
          hopStartToken: tok1,
          hopToken: tok2,
          finishReason: FinishReason.Continuation,
          reconnectsWithoutProgress: 2);
      CollectionAssert.AreEqual(tok2, nextTok);
      Assert.AreEqual(0, reconnects);

      // 2. Hop 1 failure before any checkpoint returns null token (cannot resume)
      (nextTok, reconnects) = NextResumeToken(
          hopStartToken: null,
          hopToken: null,
          finishReason: null,
          reconnectsWithoutProgress: 0);
      Assert.IsNull(nextTok);
      Assert.AreEqual(1, reconnects);

      // 3. Resumed hop drops before emitting its first checkpoint (and before yielding content) -> retries from hopStartToken
      (nextTok, reconnects) = NextResumeToken(
          hopStartToken: tok1,
          hopToken: null,
          finishReason: null,
          reconnectsWithoutProgress: 0,
          hopHasYieldedContent: false);
      CollectionAssert.AreEqual(tok1, nextTok);
      Assert.AreEqual(1, reconnects);

      // 4. Resumed hop echoes same hopStartToken without FinishReason (and before yielding content) -> counts as no progress
      (nextTok, reconnects) = NextResumeToken(
          hopStartToken: tok1,
          hopToken: tok1Copy,
          finishReason: null,
          reconnectsWithoutProgress: 1,
          hopHasYieldedContent: false);
      CollectionAssert.AreEqual(tok1, nextTok);
      Assert.AreEqual(2, reconnects);

      // 5. Resumed hop ends with FinishReason (e.g. CONTINUATION) but no new token -> stops
      (nextTok, reconnects) = NextResumeToken(
          hopStartToken: tok1,
          hopToken: null,
          finishReason: FinishReason.Continuation,
          reconnectsWithoutProgress: 0);
      Assert.IsNull(nextTok);
      Assert.AreEqual(0, reconnects);

      // 6. Resumed hop drops after yielding content parts but before a new checkpoint token -> stops to avoid duplicate chunks
      (nextTok, reconnects) = NextResumeToken(
          hopStartToken: tok1,
          hopToken: null,
          finishReason: null,
          reconnectsWithoutProgress: 0,
          hopHasYieldedContent: true);
      Assert.IsNull(nextTok);
      Assert.AreEqual(0, reconnects);

      // 7. Resumed hop with a new checkpoint token still resumes even if it yielded content parts
      (nextTok, reconnects) = NextResumeToken(
          hopStartToken: tok1,
          hopToken: tok2,
          finishReason: null,
          reconnectsWithoutProgress: 1,
          hopHasYieldedContent: true);
      CollectionAssert.AreEqual(tok2, nextTok);
      Assert.AreEqual(0, reconnects);

      // 8. Retry budget exhausted -> stops
      (nextTok, reconnects) = NextResumeToken(
          hopStartToken: tok1,
          hopToken: null,
          finishReason: null,
          reconnectsWithoutProgress: ContinuationHelper.MaxStreamReconnectsWithoutProgress);
      Assert.IsNull(nextTok);
      Assert.AreEqual(ContinuationHelper.MaxStreamReconnectsWithoutProgress, reconnects);
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_ResumedHopDropsBeforeFirstCheckpoint_RetriesFromHopStartToken()
    {
      // Hop 1 completes with CONTINUATION and token "dG9rX2hvcF8x"
      string hop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Hop 1. "}]},"finishReason":"CONTINUATION","continuationToken":"dG9rX2hvcF8x"}]}
      """;

      // Hop 2 attempt 1: drops during prefill (only metadata/empty candidate, no content parts) with mid-stream error
      string hop2Attempt1Stream = """
      {"candidates":[{"content":{"role":"model"}}]}
      {invalid_json_mid_stream
      """;

      // Hop 2 attempt 2: drops during prefill (zero chunks) without FinishReason
      string hop2Attempt2Stream = "";

      // Hop 2 attempt 3: succeeds and finishes with STOP
      string hop2Attempt3Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Hop 2 done."}]},"finishReason":"STOP"}]}
      """;

      var apiClient = new MockContinuationApiClient(
          hop1Stream, hop2Attempt1Stream, hop2Attempt2Stream, hop2Attempt3Stream);
      var models = new Models(apiClient);

      var chunks = new List<GenerateContentResponse>();
      await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
      {
        chunks.Add(chunk);
      }

      Assert.AreEqual(3, chunks.Count);
      Assert.AreEqual(4, apiClient.RequestsReceived.Count);
      Assert.IsTrue(apiClient.RequestsReceived[1].Contains("dG9rX2hvcF8x"));
      Assert.IsTrue(apiClient.RequestsReceived[2].Contains("dG9rX2hvcF8x"));
      Assert.IsTrue(apiClient.RequestsReceived[3].Contains("dG9rX2hvcF8x"));
      Assert.AreEqual(
          "Hop 1. Hop 2 done.",
          string.Concat(chunks.Select(c => c.Candidates?[0].Content?.Parts?[0].Text)));
      Assert.AreEqual(FinishReason.Stop, chunks[2].Candidates?[0].FinishReason);
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_ResumedHopDropsAfterYieldingContentBeforeCheckpoint_DoesNotRetryToAvoidDuplicateChunks()
    {
      // Hop 1 completes with CONTINUATION and token "dG9rX2hvcF8x"
      string hop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Hop 1. "}]},"finishReason":"CONTINUATION","continuationToken":"dG9rX2hvcF8x"}]}
      """;

      // Hop 2 yields candidate content parts without a new checkpoint token, then fails mid-stream
      string hop2FailingStream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Partial hop 2, "}]}}]}
      {invalid_json_mid_stream
      """;

      // Even if a subsequent response were queued, it must NOT be requested because retrying
      // from hopStartToken would replay Hop 2 from the beginning and emit duplicate chunks.
      string unexpectedRetryStream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Partial hop 2, done."}]},"finishReason":"STOP"}]}
      """;

      var apiClient = new MockContinuationApiClient(
          hop1Stream, hop2FailingStream, unexpectedRetryStream);
      var models = new Models(apiClient);

      var chunks = new List<GenerateContentResponse>();
      bool threwJsonException = false;
      try
      {
        await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
        {
          chunks.Add(chunk);
        }
      }
      catch (JsonException)
      {
        threwJsonException = true;
      }

      Assert.IsTrue(threwJsonException, "Expected JsonException immediately without retrying from hopStartToken.");
      Assert.AreEqual(2, chunks.Count);
      Assert.AreEqual(2, apiClient.RequestsReceived.Count);
      Assert.AreEqual(
          "Hop 1. Partial hop 2, ",
          string.Concat(chunks.Select(c => c.Candidates?[0].Content?.Parts?[0].Text)));

      // Also verify that an EOF without FinishReason after yielding candidate content parts ends
      // the stream normally (no SDK-invented error) without retrying.
      string hop2CutoffStream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Partial hop 2 cutoff"}]}}]}
      """;
      var cutoffClient = new MockContinuationApiClient(
          hop1Stream, hop2CutoffStream, unexpectedRetryStream);
      var cutoffModels = new Models(cutoffClient);

      var cutoffChunks = new List<GenerateContentResponse>();
      await foreach (var chunk in cutoffModels.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
      {
        cutoffChunks.Add(chunk);
      }

      Assert.AreEqual(2, cutoffChunks.Count);
      Assert.AreEqual(2, cutoffClient.RequestsReceived.Count);
      Assert.AreEqual(
          "Hop 1. Partial hop 2 cutoff",
          string.Concat(cutoffChunks.Select(c => c.Candidates?[0].Content?.Parts?[0].Text)));
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_ResumedHopExhaustsReconnectBudget_ThrowsError()
    {
      string hop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Hop 1. "}]},"finishReason":"CONTINUATION","continuationToken":"dG9rX2hvcF8x"}]}
      """;

      // Fails before yielding candidate content parts (e.g. during prefill)
      string failingHop2Stream = """
      {"candidates":[{"content":{"role":"model"}}]}
      {invalid_json_mid_stream
      """;

      var responses = new List<string> { hop1Stream };
      for (int i = 0; i < ContinuationHelper.MaxStreamReconnectsWithoutProgress + 1; i++)
      {
        responses.Add(failingHop2Stream);
      }

      var apiClient = new MockContinuationApiClient(responses.ToArray());
      var models = new Models(apiClient);

      var chunks = new List<GenerateContentResponse>();
      bool threwJsonException = false;
      try
      {
        await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
        {
          chunks.Add(chunk);
        }
      }
      catch (JsonException)
      {
        threwJsonException = true;
      }
      Assert.IsTrue(threwJsonException, "Expected JsonException after exhausting reconnect budget.");

      // 1 initial hop + 1 first Hop 2 attempt + MaxStreamReconnectsWithoutProgress retries
      Assert.AreEqual(
          ContinuationHelper.MaxStreamReconnectsWithoutProgress + 2,
          apiClient.RequestsReceived.Count);
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_ResumedHopEndsWithContinuationWithoutNewToken_StopsWithoutReplayingStartToken()
    {
      string hop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Hop 1. "}]},"finishReason":"CONTINUATION","continuationToken":"dG9rX2hvcF8x"}]}
      """;

      // Hop 2 ends with CONTINUATION but no continuationToken -> must not replay hop1's token
      string hop2Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Hop 2 no token."}]},"finishReason":"CONTINUATION"}]}
      """;

      var apiClient = new MockContinuationApiClient(hop1Stream, hop2Stream);
      var models = new Models(apiClient);

      var chunks = new List<GenerateContentResponse>();
      await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
      {
        chunks.Add(chunk);
      }

      Assert.AreEqual(2, chunks.Count);
      Assert.AreEqual(2, apiClient.RequestsReceived.Count);
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_Hop2ReturnsPromptFeedback_DoesNotRetryAndFinishesCleanly()
    {
      string hop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Hop 1. "}]},"finishReason":"CONTINUATION","continuationToken":"dG9rX2hvcF8x"}]}
      """;

      string hop2Stream = """
      {"promptFeedback":{"blockReason":"SAFETY"}}
      """;

      var apiClient = new MockContinuationApiClient(hop1Stream, hop2Stream);
      var models = new Models(apiClient);

      var chunks = new List<GenerateContentResponse>();
      await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
      {
        chunks.Add(chunk);
      }

      Assert.AreEqual(2, chunks.Count);
      Assert.AreEqual(2, apiClient.RequestsReceived.Count);
      Assert.AreEqual("Hop 1. ", chunks[0].Text);
      Assert.IsNull(chunks[1].Candidates);
      Assert.IsNotNull(chunks[1].PromptFeedback);
      Assert.AreEqual(BlockedReason.Safety, chunks[1].PromptFeedback.BlockReason);
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_Hop2EndsWithZeroChunks_RetriesThenEndsNormally()
    {
      string hop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Hop 1. "}]},"finishReason":"CONTINUATION","continuationToken":"dG9rX2hvcF8x"}]}
      """;

      var responses = new List<string> { hop1Stream };
      for (int i = 0; i < ContinuationHelper.MaxStreamReconnectsWithoutProgress + 1; i++)
      {
        responses.Add("");
      }

      var apiClient = new MockContinuationApiClient(responses.ToArray());
      var models = new Models(apiClient);

      // The API returned no error, so the SDK must not invent one: after the reconnect budget is
      // exhausted the stream ends normally and the caller keeps the chunks already yielded.
      var chunks = new List<GenerateContentResponse>();
      await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
      {
        chunks.Add(chunk);
      }

      Assert.AreEqual(1, chunks.Count);
      Assert.AreEqual("Hop 1. ", chunks[0].Text);
      // 1 initial hop + 1 first Hop 2 attempt + MaxStreamReconnectsWithoutProgress retries
      Assert.AreEqual(
          ContinuationHelper.MaxStreamReconnectsWithoutProgress + 2,
          apiClient.RequestsReceived.Count);
    }

    private const string ContinuationHop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Hop 1. "}]},"finishReason":"CONTINUATION","continuationToken":"dG9rX2hvcF8x"}]}
      """;

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_ResumedHopTransportDropBeforeAnyChunk_RetriesFromHopStartToken()
    {
      // A transport drop (not an API error) before the hop received anything is retried.
      string hop2Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Hop 2 done."}]},"finishReason":"STOP"}]}
      """;
      var apiClient = new MockContinuationApiClient(ContinuationHop1Stream, TransportDrop, hop2Stream);
      var models = new Models(apiClient);

      var chunks = new List<GenerateContentResponse>();
      await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
      {
        chunks.Add(chunk);
      }

      Assert.AreEqual(3, apiClient.RequestsReceived.Count);
      Assert.IsTrue(apiClient.RequestsReceived[1].Contains("dG9rX2hvcF8x"));
      Assert.IsTrue(apiClient.RequestsReceived[2].Contains("dG9rX2hvcF8x"));
      Assert.AreEqual("Hop 1. Hop 2 done.", string.Concat(chunks.Select(c => c.Text)));
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_ResumedHopTransportDropsExhaustReconnectBudget_ThrowsDrop()
    {
      var responses = new List<string> { ContinuationHop1Stream };
      for (int i = 0; i < ContinuationHelper.MaxStreamReconnectsWithoutProgress + 1; i++)
      {
        responses.Add(TransportDrop);
      }
      var apiClient = new MockContinuationApiClient(responses.ToArray());
      var models = new Models(apiClient);

      var chunks = new List<GenerateContentResponse>();
      var ex = await Assert.ThrowsExceptionAsync<HttpRequestException>(async () =>
      {
        await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
        {
          chunks.Add(chunk);
        }
      });
      Assert.IsNotInstanceOfType(ex, typeof(ApiException));
      Assert.AreEqual(1, chunks.Count);
      // 1 initial hop + 1 first Hop 2 attempt + MaxStreamReconnectsWithoutProgress retries
      Assert.AreEqual(
          ContinuationHelper.MaxStreamReconnectsWithoutProgress + 2,
          apiClient.RequestsReceived.Count);
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_TimeoutMidStreamAfterCheckpoint_ResumesFromCheckpoint()
    {
      // The HttpOptions.Timeout deadline firing while reading the body throws an
      // OperationCanceledException with the caller's token still live: that is a dropped hop.
      string hop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Ckpt 1, "}]},"continuationToken":"dG9rX2NrcHRfMQ=="}]}
      """ + "\n" + TimeoutDrop;
      string hop2Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Done."}]},"finishReason":"STOP"}]}
      """;
      var apiClient = new MockContinuationApiClient(hop1Stream, hop2Stream);
      var models = new Models(apiClient);

      var chunks = new List<GenerateContentResponse>();
      await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
      {
        chunks.Add(chunk);
      }

      Assert.AreEqual(2, apiClient.RequestsReceived.Count);
      Assert.IsTrue(apiClient.RequestsReceived[1].Contains("dG9rX2NrcHRfMQ=="));
      Assert.AreEqual("Ckpt 1, Done.", string.Concat(chunks.Select(c => c.Text)));
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_CallerCancellationMidStream_PropagatesWithoutResume()
    {
      string hop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Ckpt 1, "}]},"continuationToken":"dG9rX2NrcHRfMQ=="}]}
      {"candidates":[{"content":{"role":"model","parts":[{"text":"more"}]}}]}
      """;
      var apiClient = new MockContinuationApiClient(hop1Stream, hop1Stream);
      var models = new Models(apiClient);
      using var cts = new CancellationTokenSource();

      Exception? thrown = null;
      try
      {
        await foreach (var _ in models.GenerateContentStreamAsync(
            "gemini-2.5-pro", "Prompt", cancellationToken: cts.Token))
        {
          cts.Cancel();
        }
      }
      catch (Exception e)
      {
        thrown = e;
      }
      Assert.IsInstanceOfType(thrown, typeof(OperationCanceledException));
      Assert.AreEqual(1, apiClient.RequestsReceived.Count);
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_RequestRejectedBeforeAnyChunk_ThrowsWithoutRetry()
    {
      // Retrying a rejected request (HTTP error status / error event before any chunk) is left to
      // HttpOptions.RetryOptions, so the continuation loop must not retry it.
      string unexpectedRetryStream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Hop 2 done."}]},"finishReason":"STOP"}]}
      """;

      // Resumed hop rejected.
      var apiClient = new MockContinuationApiClient(
          ContinuationHop1Stream, ServerError503, unexpectedRetryStream);
      var models = new Models(apiClient);
      var chunks = new List<GenerateContentResponse>();
      var ex = await Assert.ThrowsExceptionAsync<ServerError>(async () =>
      {
        await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
        {
          chunks.Add(chunk);
        }
      });
      Assert.AreEqual(503, ex.StatusCode);
      Assert.AreEqual(1, chunks.Count);
      Assert.AreEqual(2, apiClient.RequestsReceived.Count);

      // Initial request rejected.
      var initialClient = new MockContinuationApiClient(ServerError503, unexpectedRetryStream);
      var initialModels = new Models(initialClient);
      await Assert.ThrowsExceptionAsync<ServerError>(async () =>
      {
        await foreach (var _ in initialModels.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
        {
        }
      });
      Assert.AreEqual(1, initialClient.RequestsReceived.Count);
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_ApiErrorAfterHopReceivedChunk_RetriesFromHopStartToken()
    {
      // An API error (error event) after the hop received a chunk is still handled by the
      // continuation loop: no content was yielded, so the hop is retried from its start token.
      string hop2Attempt1Stream = """
      {"candidates":[{"content":{"role":"model"}}]}
      """ + "\n" + ServerError503;
      string hop2Attempt2Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Hop 2 done."}]},"finishReason":"STOP"}]}
      """;
      var apiClient = new MockContinuationApiClient(
          ContinuationHop1Stream, hop2Attempt1Stream, hop2Attempt2Stream);
      var models = new Models(apiClient);

      var chunks = new List<GenerateContentResponse>();
      await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
      {
        chunks.Add(chunk);
      }

      Assert.AreEqual(3, apiClient.RequestsReceived.Count);
      Assert.IsTrue(apiClient.RequestsReceived[2].Contains("dG9rX2hvcF8x"));
      Assert.AreEqual("Hop 1. Hop 2 done.", string.Concat(chunks.Select(c => c.Text)));
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_DropThenCleanEmptyClosesExhaustBudget_ThrowsDrop()
    {
      // The drop must not be hidden by later retries that end cleanly without progress.
      var responses = new List<string> { ContinuationHop1Stream, TransportDrop };
      for (int i = 0; i < ContinuationHelper.MaxStreamReconnectsWithoutProgress; i++)
      {
        responses.Add("");
      }
      var apiClient = new MockContinuationApiClient(responses.ToArray());
      var models = new Models(apiClient);

      var chunks = new List<GenerateContentResponse>();
      var ex = await Assert.ThrowsExceptionAsync<HttpRequestException>(async () =>
      {
        await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
        {
          chunks.Add(chunk);
        }
      });
      Assert.AreEqual("Simulated connection reset.", ex.Message);
      Assert.AreEqual(1, chunks.Count);
      // 1 initial hop + 1 dropped Hop 2 attempt + MaxStreamReconnectsWithoutProgress retries
      Assert.AreEqual(
          ContinuationHelper.MaxStreamReconnectsWithoutProgress + 2,
          apiClient.RequestsReceived.Count);
    }

    [TestMethod]
    public async Task Models_GenerateContentStreamAsync_DropThenHopEndsWithFinishReason_EndsNormally()
    {
      // A stale error is never thrown when the API ended the hop with a finish reason.
      string hop2Stream = """
      {"candidates":[{"content":{"role":"model"},"finishReason":"CONTINUATION"}]}
      """;
      var apiClient = new MockContinuationApiClient(ContinuationHop1Stream, TransportDrop, hop2Stream);
      var models = new Models(apiClient);

      var chunks = new List<GenerateContentResponse>();
      await foreach (var chunk in models.GenerateContentStreamAsync("gemini-2.5-pro", "Prompt"))
      {
        chunks.Add(chunk);
      }

      Assert.AreEqual(3, apiClient.RequestsReceived.Count);
      Assert.AreEqual(2, chunks.Count);
    }

    #endregion

    #region ChatClient (IChatClient) Integration Tests

    [TestMethod]
    public async Task ChatClient_GetResponseAsync_MultiHopContinuation_Merged()
    {
      string hop1Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "Chat response part 1. " }]
            },
            "finishReason": "CONTINUATION",
            "continuationToken": "AQID"
          }
        ]
      }
      """;

      string hop2Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "Chat response part 2." }]
            },
            "finishReason": "STOP"
          }
        ]
      }
      """;

      var apiClient = new MockContinuationApiClient(hop1Json, hop2Json);
      var models = new Models(apiClient);
      var chatClient = models.AsIChatClient("gemini-2.5-pro");

      // Chat client automatically enables AutomaticContinuation by default
      var response = await chatClient.GetResponseAsync("Hello!");

      Assert.IsNotNull(response);
      Assert.AreEqual(2, apiClient.RequestsReceived.Count);
      Assert.AreEqual("Chat response part 1. Chat response part 2.", response.Text);
    }

    [TestMethod]
    public async Task ChatClient_MaxOutputTokens_PassesValueAndContinues()
    {
      string hop1Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "Chat response part 1. " }]
            },
            "finishReason": "CONTINUATION",
            "continuationToken": "AQID"
          }
        ]
      }
      """;

      string hop2Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "Chat response part 2." }]
            },
            "finishReason": "MAX_TOKENS"
          }
        ]
      }
      """;

      var apiClient = new MockContinuationApiClient(hop1Json, hop2Json);
      var models = new Models(apiClient);
      var chatClient = models.AsIChatClient("gemini-2.5-pro");

      // MaxOutputTokens is passed to the backend and does not disable continuation in Chat
      var options = new ChatOptions { MaxOutputTokens = 50 };
      var response = await chatClient.GetResponseAsync("Hello!", options);

      Assert.IsNotNull(response);
      Assert.AreEqual(2, apiClient.RequestsReceived.Count);
      Assert.AreEqual("Chat response part 1. Chat response part 2.", response.Text);
      Assert.IsTrue(apiClient.RequestsReceived[0].Contains("50"), "Hop 1 should include maxOutputTokens: 50");
      Assert.IsTrue(apiClient.RequestsReceived[1].Contains("50"), "Hop 2 should include maxOutputTokens: 50");
    }

    [TestMethod]
    public async Task ChatClient_ExplicitOptOut_DisablesContinuation()
    {
      string hop1Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "Chat response part 1." }]
            },
            "finishReason": "CONTINUATION",
            "continuationToken": "AQID"
          }
        ]
      }
      """;

      var apiClient = new MockContinuationApiClient(hop1Json);
      var models = new Models(apiClient);
      var chatClient = models.AsIChatClient("gemini-2.5-pro");

      var options = new ChatOptions
      {
        RawRepresentationFactory = _ => new GenerateContentConfig { AutomaticContinuation = false }
      };
      var response = await chatClient.GetResponseAsync("Hello!", options);

      Assert.IsNotNull(response);
      Assert.AreEqual(1, apiClient.RequestsReceived.Count);
    }

    [TestMethod]
    public async Task ChatClient_GetResponseAsync_AutoResumesAcross4Hops_Merged()
    {
      string hop1Json = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Chat hop 1. "}]},"finishReason":"CONTINUATION","continuationToken":"dG9rMQ=="}]}
      """;
      string hop2Json = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Chat hop 2. "}]},"finishReason":"CONTINUATION","continuationToken":"dG9rMg=="}]}
      """;
      string hop3Json = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Chat hop 3. "}]},"finishReason":"CONTINUATION","continuationToken":"dG9rMw=="}]}
      """;
      string hop4Json = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Chat hop 4."}]},"finishReason":"STOP"}]}
      """;

      var apiClient = new MockContinuationApiClient(hop1Json, hop2Json, hop3Json, hop4Json);
      var models = new Models(apiClient);
      var chatClient = models.AsIChatClient("gemini-2.5-pro");

      var response = await chatClient.GetResponseAsync("Tell me a story");

      Assert.IsNotNull(response);
      Assert.AreEqual(4, apiClient.RequestsReceived.Count);
      Assert.AreEqual("Chat hop 1. Chat hop 2. Chat hop 3. Chat hop 4.", response.Text);
      Assert.IsTrue(apiClient.RequestsReceived[1].Contains("dG9rMQ=="));
      Assert.IsTrue(apiClient.RequestsReceived[2].Contains("dG9rMg=="));
      Assert.IsTrue(apiClient.RequestsReceived[3].Contains("dG9rMw=="));
    }

    [TestMethod]
    public async Task ChatClient_GetStreamingResponseAsync_MultiHopContinuation_YieldsAllUpdates()
    {
      string hop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Chat stream chunk 1. "}]}}]}
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Chat stream chunk 2. "}]},"finishReason":"CONTINUATION","continuationToken":"AQID"}],"usageMetadata":{"promptTokenCount":10,"cachedContentTokenCount":4,"candidatesTokenCount":20,"thoughtsTokenCount":5,"totalTokenCount":35}}
      """;

      string hop2Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Chat stream chunk 3. "}]}}]}
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Chat stream chunk 4."}]},"finishReason":"STOP"}],"usageMetadata":{"promptTokenCount":35,"cachedContentTokenCount":30,"candidatesTokenCount":30,"thoughtsTokenCount":15,"totalTokenCount":80}}
      """;

      var apiClient = new MockContinuationApiClient(hop1Stream, hop2Stream);
      var models = new Models(apiClient);
      var chatClient = models.AsIChatClient("gemini-2.5-pro");

      var updates = new List<ChatResponseUpdate>();
      await foreach (var update in chatClient.GetStreamingResponseAsync("Hello!"))
      {
        updates.Add(update);
      }

      Assert.AreEqual(2, apiClient.RequestsReceived.Count);
      var fullText = string.Concat(updates.Select(u => u.Text));
      Assert.AreEqual("Chat stream chunk 1. Chat stream chunk 2. Chat stream chunk 3. Chat stream chunk 4.", fullText);

      // Intermediate hop FinishReason is cleared; only the final update carries a FinishReason
      Assert.AreEqual(1, updates.Count(u => u.FinishReason != null));
      Assert.AreEqual(ChatFinishReason.Stop, updates.Single(u => u.FinishReason != null).FinishReason);

      var usageContent = updates.SelectMany(u => u.Contents).OfType<UsageContent>().SingleOrDefault();
      Assert.IsNotNull(usageContent);
      Assert.AreEqual(45, usageContent.Details.InputTokenCount);
      Assert.AreEqual(34, usageContent.Details.CachedInputTokenCount);
      Assert.AreEqual(50, usageContent.Details.OutputTokenCount);
      Assert.AreEqual(20, usageContent.Details.ReasoningTokenCount);
      Assert.AreEqual(115, usageContent.Details.TotalTokenCount);
    }

    [TestMethod]
    public async Task ChatClient_GetStreamingResponseAsync_ExplicitOptOut_DisablesContinuation()
    {
      string hop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Chat stream chunk 1. "}]}}]}
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Chat stream chunk 2."}]},"finishReason":"CONTINUATION","continuationToken":"AQID"}]}
      """;

      var apiClient = new MockContinuationApiClient(hop1Stream);
      var models = new Models(apiClient);
      var chatClient = models.AsIChatClient("gemini-2.5-pro");

      var options = new ChatOptions
      {
        RawRepresentationFactory = _ => new GenerateContentConfig { AutomaticContinuation = false }
      };

      var updates = new List<ChatResponseUpdate>();
      await foreach (var update in chatClient.GetStreamingResponseAsync("Hello!", options))
      {
        updates.Add(update);
      }

      Assert.AreEqual(1, apiClient.RequestsReceived.Count);
      var fullText = string.Concat(updates.Select(u => u.Text));
      Assert.AreEqual("Chat stream chunk 1. Chat stream chunk 2.", fullText);
      Assert.IsNotNull(updates.Last(u => u.FinishReason != null).FinishReason);
    }

    [TestMethod]
    public async Task ChatClient_GetStreamingResponseAsync_MaxTokensFinishReason_StopsContinuation()
    {
      string hop1Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Chat stream chunk 1. "}]}}]}
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Stopped at max tokens."}]},"finishReason":"MAX_TOKENS","continuationToken":"AQID"}]}
      """;

      var apiClient = new MockContinuationApiClient(hop1Stream);
      var models = new Models(apiClient);
      var chatClient = models.AsIChatClient("gemini-2.5-pro");

      var options = new ChatOptions { MaxOutputTokens = 50 };

      var updates = new List<ChatResponseUpdate>();
      await foreach (var update in chatClient.GetStreamingResponseAsync("Hello!", options))
      {
        updates.Add(update);
      }

      Assert.AreEqual(1, apiClient.RequestsReceived.Count);
      var fullText = string.Concat(updates.Select(u => u.Text));
      Assert.AreEqual("Chat stream chunk 1. Stopped at max tokens.", fullText);
      Assert.AreEqual(ChatFinishReason.Length, updates.Last(u => u.FinishReason != null).FinishReason);
    }

    [TestMethod]
    public async Task ChatClient_GetResponseAsync_MaxTokensFinishReason_StopsContinuation()
    {
      string hop1Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "Chat stopped at max tokens." }]
            },
            "finishReason": "MAX_TOKENS",
            "continuationToken": "AQID"
          }
        ]
      }
      """;

      var apiClient = new MockContinuationApiClient(hop1Json);
      var models = new Models(apiClient);
      var chatClient = models.AsIChatClient("gemini-2.5-pro");

      var options = new ChatOptions { MaxOutputTokens = 50 };
      var response = await chatClient.GetResponseAsync("Hello!", options);

      Assert.IsNotNull(response);
      Assert.AreEqual(1, apiClient.RequestsReceived.Count);
      Assert.AreEqual("Chat stopped at max tokens.", response.Text);
      Assert.AreEqual(ChatFinishReason.Length, response.FinishReason);
    }

    [TestMethod]
    public async Task ChatClient_GetResponseAsync_ThoughtOnlyHop_PreservesEmptyTextPart()
    {
      string hop1Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "", "thoughtSignature": "c2lnX2hvcF8x" }]
            },
            "finishReason": "CONTINUATION",
            "continuationToken": "AQID"
          }
        ]
      }
      """;

      string hop2Json = """
      {
        "candidates": [
          {
            "content": {
              "role": "model",
              "parts": [{ "text": "Final answer after thinking." }]
            },
            "finishReason": "STOP"
          }
        ]
      }
      """;

      var apiClient = new MockContinuationApiClient(hop1Json, hop2Json);
      var models = new Models(apiClient);
      var chatClient = models.AsIChatClient("gemini-2.5-pro");

      var response = await chatClient.GetResponseAsync("Solve problem");

      Assert.IsNotNull(response);
      Assert.AreEqual(2, apiClient.RequestsReceived.Count);
      Assert.AreEqual("Final answer after thinking.", response.Text);
      var raw = response.RawRepresentation as GenerateContentResponse;
      Assert.IsNotNull(raw);
      var parts = raw.Candidates?[0].Content?.Parts;
      Assert.IsNotNull(parts);
      Assert.AreEqual(2, parts.Count);
      Assert.AreEqual("", parts[0].Text);
      Assert.AreEqual("Final answer after thinking.", parts[1].Text);
    }

    #endregion

    #region Mock ApiClient

    // Stream payload lines that make MockContinuationApiClient.RequestStreamAsync throw.
    private const string TransportDrop = "!transport_drop";
    private const string ServerError503 = "!server_error_503";
    private const string TimeoutDrop = "!timeout_drop";

    private sealed class MockContinuationApiClient : ApiClient
    {
      private readonly Queue<string> _responses;
      public List<string> RequestsReceived { get; } = new();

      public MockContinuationApiClient(params string[] responses)
          : base(apiKey: "fake_api_key", customHttpOptions: new() { BaseUrl = "http://localhost/" })
      {
        _responses = new Queue<string>(responses);
      }

      internal override Task<ApiResponse> RequestAsync(
          HttpMethod httpMethod, string path, byte[] requestBytes, HttpOptions? requestHttpOptions,
          CancellationToken cancellationToken = default) =>
          RequestAsync(httpMethod, path, Encoding.UTF8.GetString(requestBytes), requestHttpOptions, cancellationToken);

      public override Task<ApiResponse> RequestAsync(
          HttpMethod httpMethod, string path, string requestJson, HttpOptions? requestHttpOptions,
          CancellationToken cancellationToken = default)
      {
        RequestsReceived.Add(requestJson);
        string responseJson = _responses.Count > 0 ? _responses.Dequeue() : "{}";
        return Task.FromResult<ApiResponse>(new HttpApiResponse(new HttpResponseMessage()
        {
          Content = new StringContent(responseJson, Encoding.UTF8, "application/json")
        }));
      }

      public override async IAsyncEnumerable<ApiResponse> RequestStreamAsync(
          HttpMethod httpMethod, string path, string requestJson, HttpOptions? requestHttpOptions,
          [EnumeratorCancellation] CancellationToken cancellationToken = default)
      {
        cancellationToken.ThrowIfCancellationRequested();
        RequestsReceived.Add(requestJson);
        string responsePayload = _responses.Count > 0 ? _responses.Dequeue() : "{}";
        await Task.Yield();
        foreach (var chunk in responsePayload.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries))
        {
          cancellationToken.ThrowIfCancellationRequested();
          var trimmed = chunk.Trim();
          if (trimmed.StartsWith("data:", StringComparison.OrdinalIgnoreCase))
          {
            trimmed = trimmed.Substring(5).Trim();
          }
          if (!string.IsNullOrEmpty(trimmed))
          {
            // Simulated failures: a transport drop (connection reset, unexpected EOF), or an
            // API error (HTTP error status or error event; an ApiException) at this point.
            if (trimmed == TransportDrop)
            {
              throw new HttpRequestException("Simulated connection reset.");
            }
            if (trimmed == TimeoutDrop)
            {
              // What an HttpOptions.Timeout deadline looks like while reading the body.
              throw new TaskCanceledException("Simulated HttpOptions.Timeout.");
            }
            if (trimmed == ServerError503)
            {
              throw new ServerError("Simulated 503 Service Unavailable.", 503, "UNAVAILABLE");
            }
            yield return new StreamingApiResponse(trimmed, new HttpResponseMessage());
          }
        }
      }
    }

    #endregion
  }
}
