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
      // Only CONTINUATION is resumable.
      Assert.IsTrue(ContinuationHelper.IsResumableFinishReason(FinishReason.Continuation));

      // MAX_TOKENS and other finish reasons are not resumable.
      Assert.IsFalse(ContinuationHelper.IsResumableFinishReason(FinishReason.MaxTokens));
      Assert.IsFalse(ContinuationHelper.IsResumableFinishReason(FinishReason.Stop));
      Assert.IsFalse(ContinuationHelper.IsResumableFinishReason(FinishReason.Safety));
      Assert.IsFalse(ContinuationHelper.IsResumableFinishReason(FinishReason.Recitation));
      Assert.IsFalse(ContinuationHelper.IsResumableFinishReason(null));
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
          PromptTokenCount = 10,
          CandidatesTokenCount = 30,
          ThoughtsTokenCount = 15,
          TotalTokenCount = 55
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
      // CandidatesTokenCount and ThoughtsTokenCount are summed across hops
      Assert.AreEqual(50, merged.UsageMetadata.CandidatesTokenCount);
      Assert.AreEqual(20, merged.UsageMetadata.ThoughtsTokenCount);
      Assert.AreEqual(90, merged.UsageMetadata.TotalTokenCount);
      Assert.AreEqual(50, merged.Candidates![0].TokenCount);
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
      Assert.AreEqual(140, merged.UsageMetadata?.PromptTokensDetails?[0].TokenCount);
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

      // Verify token counts summed
      Assert.AreEqual(22, response.UsageMetadata?.CandidatesTokenCount);
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

      // Verify summed usage metadata
      Assert.IsNotNull(response.UsageMetadata);
      Assert.AreEqual(10 + 32778 + 65546 + 98314, response.UsageMetadata.PromptTokenCount);
      Assert.AreEqual(32768 * 3 + 1024, response.UsageMetadata.CandidatesTokenCount);
      Assert.AreEqual(500 + 300 + 200 + 100, response.UsageMetadata.ThoughtsTokenCount);
      Assert.AreEqual(33278 + 65846 + 98514 + 99438, response.UsageMetadata.TotalTokenCount);

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

      // Final chunk has finishReason STOP and null continuationToken
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
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Chat stream chunk 2. "}]},"finishReason":"CONTINUATION","continuationToken":"AQID"}]}
      """;

      string hop2Stream = """
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Chat stream chunk 3. "}]}}]}
      {"candidates":[{"content":{"role":"model","parts":[{"text":"Chat stream chunk 4."}]},"finishReason":"STOP"}]}
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
        RequestsReceived.Add(requestJson);
        string responsePayload = _responses.Count > 0 ? _responses.Dequeue() : "{}";
        await Task.Yield();
        foreach (var chunk in responsePayload.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries))
        {
          var trimmed = chunk.Trim();
          if (trimmed.StartsWith("data:", StringComparison.OrdinalIgnoreCase))
          {
            trimmed = trimmed.Substring(5).Trim();
          }
          if (!string.IsNullOrEmpty(trimmed))
          {
            yield return new StreamingApiResponse(trimmed, new HttpResponseMessage());
          }
        }
      }
    }

    #endregion
  }
}
