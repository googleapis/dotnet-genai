// Copyright 2025 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Exceptions;
using Google.GenAI.Interactions.Models.Interactions;

namespace Google.GenAI.Interactions.Tests.Models.Interactions;

public class InteractionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Interaction
        {
            ID = "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg",
            Created = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
            Status = InteractionStatus.Completed,
            Updated = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
            Agent = InteractionAgent.DeepResearchProPreview12_2025,
            AgentConfig = new DynamicAgentConfig(),
            GenerationConfig = new()
            {
                ImageConfig = new() { AspectRatio = AspectRatio.V1_1, ImageSize = ImageSize.V1K },
                MaxOutputTokens = 0,
                Seed = 0,
                SpeechConfig = new List<SpeechConfig>()
                {
                    new SpeechConfig()
                    {
                        Language = "language",
                        Speaker = "speaker",
                        Voice = "voice",
                    },
                },
                StopSequences = new List<string>() { "string" },
                Temperature = 0,
                ThinkingLevel = ThinkingLevel.Minimal,
                ThinkingSummaries = GenerationConfigThinkingSummaries.Auto,
                ToolChoice = ToolChoiceType.Auto,
                TopP = 0,
            },
            Input = new(
                new List<Content>()
                {
                    new Content(
                        new TextContent()
                        {
                            Text = "text",
                            Annotations = new List<Annotation>()
                            {
                                new Annotation(
                                    new UrlCitation()
                                    {
                                        EndIndex = 0,
                                        StartIndex = 0,
                                        Title = "title",
                                        Url = "url",
                                    }
                                ),
                            },
                        }
                    ),
                }
            ),
            Model = Model.Gemini3FlashPreview,
            Outputs = new List<Content>()
            {
                new Content(
                    new TextContent()
                    {
                        Text =
                            "Hello! I'm doing well, functioning as expected. Thank you for asking! How are you doing today?",
                        Annotations = new List<Annotation>()
                        {
                            new Annotation(
                                new UrlCitation()
                                {
                                    EndIndex = 0,
                                    StartIndex = 0,
                                    Title = "title",
                                    Url = "url",
                                }
                            ),
                        },
                    }
                ),
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<ApiEnum<string, InteractionResponseModality>>()
            {
                InteractionResponseModality.Text,
            },
            Role = "model",
            ServiceTier = InteractionServiceTier.Flex,
            SystemInstruction = "system_instruction",
            Tools = new List<Tool>()
            {
                new Tool(
                    new Function()
                    {
                        Description = "description",
                        Name = "name",
                        Parameters = JsonSerializer.Deserialize<JsonElement>("{}"),
                    }
                ),
            },
            Usage = new()
            {
                CachedTokensByModality = new List<CachedTokensByModality>()
                {
                    new CachedTokensByModality() { Modality = Modality.Text, Tokens = 0 },
                },
                InputTokensByModality = new List<InputTokensByModality>()
                {
                    new InputTokensByModality()
                    {
                        Modality = InputTokensByModalityModality.Text,
                        Tokens = 7,
                    },
                },
                OutputTokensByModality = new List<OutputTokensByModality>()
                {
                    new OutputTokensByModality()
                    {
                        Modality = OutputTokensByModalityModality.Text,
                        Tokens = 0,
                    },
                },
                ToolUseTokensByModality = new List<ToolUseTokensByModality>()
                {
                    new ToolUseTokensByModality()
                    {
                        Modality = ToolUseTokensByModalityModality.Text,
                        Tokens = 0,
                    },
                },
                TotalCachedTokens = 0,
                TotalInputTokens = 7,
                TotalOutputTokens = 23,
                TotalThoughtTokens = 49,
                TotalTokens = 79,
                TotalToolUseTokens = 0,
            },
        };

        string expectedID =
            "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg";
        DateTimeOffset expectedCreated = DateTimeOffset.Parse("2025-12-04T15:01:45Z");
        ApiEnum<string, InteractionStatus> expectedStatus = InteractionStatus.Completed;
        DateTimeOffset expectedUpdated = DateTimeOffset.Parse("2025-12-04T15:01:45Z");
        ApiEnum<string, InteractionAgent> expectedAgent =
            InteractionAgent.DeepResearchProPreview12_2025;
        InteractionAgentConfig expectedAgentConfig = new DynamicAgentConfig();
        GenerationConfig expectedGenerationConfig = new()
        {
            ImageConfig = new() { AspectRatio = AspectRatio.V1_1, ImageSize = ImageSize.V1K },
            MaxOutputTokens = 0,
            Seed = 0,
            SpeechConfig = new List<SpeechConfig>()
            {
                new SpeechConfig()
                {
                    Language = "language",
                    Speaker = "speaker",
                    Voice = "voice",
                },
            },
            StopSequences = new List<string>() { "string" },
            Temperature = 0,
            ThinkingLevel = ThinkingLevel.Minimal,
            ThinkingSummaries = GenerationConfigThinkingSummaries.Auto,
            ToolChoice = ToolChoiceType.Auto,
            TopP = 0,
        };
        InteractionInput expectedInput = new(
            new List<Content>()
            {
                new Content(
                    new TextContent()
                    {
                        Text = "text",
                        Annotations = new List<Annotation>()
                        {
                            new Annotation(
                                new UrlCitation()
                                {
                                    EndIndex = 0,
                                    StartIndex = 0,
                                    Title = "title",
                                    Url = "url",
                                }
                            ),
                        },
                    }
                ),
            }
        );
        ApiEnum<string, Model> expectedModel = Model.Gemini3FlashPreview;
        List<Content> expectedOutputs = new List<Content>()
        {
            new Content(
                new TextContent()
                {
                    Text =
                        "Hello! I'm doing well, functioning as expected. Thank you for asking! How are you doing today?",
                    Annotations = new List<Annotation>()
                    {
                        new Annotation(
                            new UrlCitation()
                            {
                                EndIndex = 0,
                                StartIndex = 0,
                                Title = "title",
                                Url = "url",
                            }
                        ),
                    },
                }
            ),
        };
        string expectedPreviousInteractionID = "previous_interaction_id";
        JsonElement expectedResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedResponseMimeType = "response_mime_type";
        List<ApiEnum<string, InteractionResponseModality>> expectedResponseModalities = new List<
            ApiEnum<string, InteractionResponseModality>
        >()
        {
            InteractionResponseModality.Text,
        };
        string expectedRole = "model";
        ApiEnum<string, InteractionServiceTier> expectedServiceTier = InteractionServiceTier.Flex;
        string expectedSystemInstruction = "system_instruction";
        List<Tool> expectedTools = new List<Tool>()
        {
            new Tool(
                new Function()
                {
                    Description = "description",
                    Name = "name",
                    Parameters = JsonSerializer.Deserialize<JsonElement>("{}"),
                }
            ),
        };
        Usage expectedUsage = new()
        {
            CachedTokensByModality = new List<CachedTokensByModality>()
            {
                new CachedTokensByModality() { Modality = Modality.Text, Tokens = 0 },
            },
            InputTokensByModality = new List<InputTokensByModality>()
            {
                new InputTokensByModality()
                {
                    Modality = InputTokensByModalityModality.Text,
                    Tokens = 7,
                },
            },
            OutputTokensByModality = new List<OutputTokensByModality>()
            {
                new OutputTokensByModality()
                {
                    Modality = OutputTokensByModalityModality.Text,
                    Tokens = 0,
                },
            },
            ToolUseTokensByModality = new List<ToolUseTokensByModality>()
            {
                new ToolUseTokensByModality()
                {
                    Modality = ToolUseTokensByModalityModality.Text,
                    Tokens = 0,
                },
            },
            TotalCachedTokens = 0,
            TotalInputTokens = 7,
            TotalOutputTokens = 23,
            TotalThoughtTokens = 49,
            TotalTokens = 79,
            TotalToolUseTokens = 0,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdated, model.Updated);
        Assert.Equal(expectedAgent, model.Agent);
        Assert.Equal(expectedAgentConfig, model.AgentConfig);
        Assert.Equal(expectedGenerationConfig, model.GenerationConfig);
        Assert.Equal(expectedInput, model.Input);
        Assert.Equal(expectedModel, model.Model);
        Assert.NotNull(model.Outputs);
        Assert.Equal(expectedOutputs.Count, model.Outputs.Count);
        for (int i = 0; i < expectedOutputs.Count; i++)
        {
            Assert.Equal(expectedOutputs[i], model.Outputs[i]);
        }
        Assert.Equal(expectedPreviousInteractionID, model.PreviousInteractionID);
        Assert.NotNull(model.ResponseFormat);
        Assert.True(JsonElement.DeepEquals(expectedResponseFormat, model.ResponseFormat.Value));
        Assert.Equal(expectedResponseMimeType, model.ResponseMimeType);
        Assert.NotNull(model.ResponseModalities);
        Assert.Equal(expectedResponseModalities.Count, model.ResponseModalities.Count);
        for (int i = 0; i < expectedResponseModalities.Count; i++)
        {
            Assert.Equal(expectedResponseModalities[i], model.ResponseModalities[i]);
        }
        Assert.Equal(expectedRole, model.Role);
        Assert.Equal(expectedServiceTier, model.ServiceTier);
        Assert.Equal(expectedSystemInstruction, model.SystemInstruction);
        Assert.NotNull(model.Tools);
        Assert.Equal(expectedTools.Count, model.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], model.Tools[i]);
        }
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Interaction
        {
            ID = "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg",
            Created = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
            Status = InteractionStatus.Completed,
            Updated = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
            Agent = InteractionAgent.DeepResearchProPreview12_2025,
            AgentConfig = new DynamicAgentConfig(),
            GenerationConfig = new()
            {
                ImageConfig = new() { AspectRatio = AspectRatio.V1_1, ImageSize = ImageSize.V1K },
                MaxOutputTokens = 0,
                Seed = 0,
                SpeechConfig = new List<SpeechConfig>()
                {
                    new SpeechConfig()
                    {
                        Language = "language",
                        Speaker = "speaker",
                        Voice = "voice",
                    },
                },
                StopSequences = new List<string>() { "string" },
                Temperature = 0,
                ThinkingLevel = ThinkingLevel.Minimal,
                ThinkingSummaries = GenerationConfigThinkingSummaries.Auto,
                ToolChoice = ToolChoiceType.Auto,
                TopP = 0,
            },
            Input = new(
                new List<Content>()
                {
                    new Content(
                        new TextContent()
                        {
                            Text = "text",
                            Annotations = new List<Annotation>()
                            {
                                new Annotation(
                                    new UrlCitation()
                                    {
                                        EndIndex = 0,
                                        StartIndex = 0,
                                        Title = "title",
                                        Url = "url",
                                    }
                                ),
                            },
                        }
                    ),
                }
            ),
            Model = Model.Gemini3FlashPreview,
            Outputs = new List<Content>()
            {
                new Content(
                    new TextContent()
                    {
                        Text =
                            "Hello! I'm doing well, functioning as expected. Thank you for asking! How are you doing today?",
                        Annotations = new List<Annotation>()
                        {
                            new Annotation(
                                new UrlCitation()
                                {
                                    EndIndex = 0,
                                    StartIndex = 0,
                                    Title = "title",
                                    Url = "url",
                                }
                            ),
                        },
                    }
                ),
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<ApiEnum<string, InteractionResponseModality>>()
            {
                InteractionResponseModality.Text,
            },
            Role = "model",
            ServiceTier = InteractionServiceTier.Flex,
            SystemInstruction = "system_instruction",
            Tools = new List<Tool>()
            {
                new Tool(
                    new Function()
                    {
                        Description = "description",
                        Name = "name",
                        Parameters = JsonSerializer.Deserialize<JsonElement>("{}"),
                    }
                ),
            },
            Usage = new()
            {
                CachedTokensByModality = new List<CachedTokensByModality>()
                {
                    new CachedTokensByModality() { Modality = Modality.Text, Tokens = 0 },
                },
                InputTokensByModality = new List<InputTokensByModality>()
                {
                    new InputTokensByModality()
                    {
                        Modality = InputTokensByModalityModality.Text,
                        Tokens = 7,
                    },
                },
                OutputTokensByModality = new List<OutputTokensByModality>()
                {
                    new OutputTokensByModality()
                    {
                        Modality = OutputTokensByModalityModality.Text,
                        Tokens = 0,
                    },
                },
                ToolUseTokensByModality = new List<ToolUseTokensByModality>()
                {
                    new ToolUseTokensByModality()
                    {
                        Modality = ToolUseTokensByModalityModality.Text,
                        Tokens = 0,
                    },
                },
                TotalCachedTokens = 0,
                TotalInputTokens = 7,
                TotalOutputTokens = 23,
                TotalThoughtTokens = 49,
                TotalTokens = 79,
                TotalToolUseTokens = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Interaction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Interaction
        {
            ID = "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg",
            Created = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
            Status = InteractionStatus.Completed,
            Updated = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
            Agent = InteractionAgent.DeepResearchProPreview12_2025,
            AgentConfig = new DynamicAgentConfig(),
            GenerationConfig = new()
            {
                ImageConfig = new() { AspectRatio = AspectRatio.V1_1, ImageSize = ImageSize.V1K },
                MaxOutputTokens = 0,
                Seed = 0,
                SpeechConfig = new List<SpeechConfig>()
                {
                    new SpeechConfig()
                    {
                        Language = "language",
                        Speaker = "speaker",
                        Voice = "voice",
                    },
                },
                StopSequences = new List<string>() { "string" },
                Temperature = 0,
                ThinkingLevel = ThinkingLevel.Minimal,
                ThinkingSummaries = GenerationConfigThinkingSummaries.Auto,
                ToolChoice = ToolChoiceType.Auto,
                TopP = 0,
            },
            Input = new(
                new List<Content>()
                {
                    new Content(
                        new TextContent()
                        {
                            Text = "text",
                            Annotations = new List<Annotation>()
                            {
                                new Annotation(
                                    new UrlCitation()
                                    {
                                        EndIndex = 0,
                                        StartIndex = 0,
                                        Title = "title",
                                        Url = "url",
                                    }
                                ),
                            },
                        }
                    ),
                }
            ),
            Model = Model.Gemini3FlashPreview,
            Outputs = new List<Content>()
            {
                new Content(
                    new TextContent()
                    {
                        Text =
                            "Hello! I'm doing well, functioning as expected. Thank you for asking! How are you doing today?",
                        Annotations = new List<Annotation>()
                        {
                            new Annotation(
                                new UrlCitation()
                                {
                                    EndIndex = 0,
                                    StartIndex = 0,
                                    Title = "title",
                                    Url = "url",
                                }
                            ),
                        },
                    }
                ),
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<ApiEnum<string, InteractionResponseModality>>()
            {
                InteractionResponseModality.Text,
            },
            Role = "model",
            ServiceTier = InteractionServiceTier.Flex,
            SystemInstruction = "system_instruction",
            Tools = new List<Tool>()
            {
                new Tool(
                    new Function()
                    {
                        Description = "description",
                        Name = "name",
                        Parameters = JsonSerializer.Deserialize<JsonElement>("{}"),
                    }
                ),
            },
            Usage = new()
            {
                CachedTokensByModality = new List<CachedTokensByModality>()
                {
                    new CachedTokensByModality() { Modality = Modality.Text, Tokens = 0 },
                },
                InputTokensByModality = new List<InputTokensByModality>()
                {
                    new InputTokensByModality()
                    {
                        Modality = InputTokensByModalityModality.Text,
                        Tokens = 7,
                    },
                },
                OutputTokensByModality = new List<OutputTokensByModality>()
                {
                    new OutputTokensByModality()
                    {
                        Modality = OutputTokensByModalityModality.Text,
                        Tokens = 0,
                    },
                },
                ToolUseTokensByModality = new List<ToolUseTokensByModality>()
                {
                    new ToolUseTokensByModality()
                    {
                        Modality = ToolUseTokensByModalityModality.Text,
                        Tokens = 0,
                    },
                },
                TotalCachedTokens = 0,
                TotalInputTokens = 7,
                TotalOutputTokens = 23,
                TotalThoughtTokens = 49,
                TotalTokens = 79,
                TotalToolUseTokens = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Interaction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID =
            "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg";
        DateTimeOffset expectedCreated = DateTimeOffset.Parse("2025-12-04T15:01:45Z");
        ApiEnum<string, InteractionStatus> expectedStatus = InteractionStatus.Completed;
        DateTimeOffset expectedUpdated = DateTimeOffset.Parse("2025-12-04T15:01:45Z");
        ApiEnum<string, InteractionAgent> expectedAgent =
            InteractionAgent.DeepResearchProPreview12_2025;
        InteractionAgentConfig expectedAgentConfig = new DynamicAgentConfig();
        GenerationConfig expectedGenerationConfig = new()
        {
            ImageConfig = new() { AspectRatio = AspectRatio.V1_1, ImageSize = ImageSize.V1K },
            MaxOutputTokens = 0,
            Seed = 0,
            SpeechConfig = new List<SpeechConfig>()
            {
                new SpeechConfig()
                {
                    Language = "language",
                    Speaker = "speaker",
                    Voice = "voice",
                },
            },
            StopSequences = new List<string>() { "string" },
            Temperature = 0,
            ThinkingLevel = ThinkingLevel.Minimal,
            ThinkingSummaries = GenerationConfigThinkingSummaries.Auto,
            ToolChoice = ToolChoiceType.Auto,
            TopP = 0,
        };
        InteractionInput expectedInput = new(
            new List<Content>()
            {
                new Content(
                    new TextContent()
                    {
                        Text = "text",
                        Annotations = new List<Annotation>()
                        {
                            new Annotation(
                                new UrlCitation()
                                {
                                    EndIndex = 0,
                                    StartIndex = 0,
                                    Title = "title",
                                    Url = "url",
                                }
                            ),
                        },
                    }
                ),
            }
        );
        ApiEnum<string, Model> expectedModel = Model.Gemini3FlashPreview;
        List<Content> expectedOutputs = new List<Content>()
        {
            new Content(
                new TextContent()
                {
                    Text =
                        "Hello! I'm doing well, functioning as expected. Thank you for asking! How are you doing today?",
                    Annotations = new List<Annotation>()
                    {
                        new Annotation(
                            new UrlCitation()
                            {
                                EndIndex = 0,
                                StartIndex = 0,
                                Title = "title",
                                Url = "url",
                            }
                        ),
                    },
                }
            ),
        };
        string expectedPreviousInteractionID = "previous_interaction_id";
        JsonElement expectedResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedResponseMimeType = "response_mime_type";
        List<ApiEnum<string, InteractionResponseModality>> expectedResponseModalities = new List<
            ApiEnum<string, InteractionResponseModality>
        >()
        {
            InteractionResponseModality.Text,
        };
        string expectedRole = "model";
        ApiEnum<string, InteractionServiceTier> expectedServiceTier = InteractionServiceTier.Flex;
        string expectedSystemInstruction = "system_instruction";
        List<Tool> expectedTools = new List<Tool>()
        {
            new Tool(
                new Function()
                {
                    Description = "description",
                    Name = "name",
                    Parameters = JsonSerializer.Deserialize<JsonElement>("{}"),
                }
            ),
        };
        Usage expectedUsage = new()
        {
            CachedTokensByModality = new List<CachedTokensByModality>()
            {
                new CachedTokensByModality() { Modality = Modality.Text, Tokens = 0 },
            },
            InputTokensByModality = new List<InputTokensByModality>()
            {
                new InputTokensByModality()
                {
                    Modality = InputTokensByModalityModality.Text,
                    Tokens = 7,
                },
            },
            OutputTokensByModality = new List<OutputTokensByModality>()
            {
                new OutputTokensByModality()
                {
                    Modality = OutputTokensByModalityModality.Text,
                    Tokens = 0,
                },
            },
            ToolUseTokensByModality = new List<ToolUseTokensByModality>()
            {
                new ToolUseTokensByModality()
                {
                    Modality = ToolUseTokensByModalityModality.Text,
                    Tokens = 0,
                },
            },
            TotalCachedTokens = 0,
            TotalInputTokens = 7,
            TotalOutputTokens = 23,
            TotalThoughtTokens = 49,
            TotalTokens = 79,
            TotalToolUseTokens = 0,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdated, deserialized.Updated);
        Assert.Equal(expectedAgent, deserialized.Agent);
        Assert.Equal(expectedAgentConfig, deserialized.AgentConfig);
        Assert.Equal(expectedGenerationConfig, deserialized.GenerationConfig);
        Assert.Equal(expectedInput, deserialized.Input);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.NotNull(deserialized.Outputs);
        Assert.Equal(expectedOutputs.Count, deserialized.Outputs.Count);
        for (int i = 0; i < expectedOutputs.Count; i++)
        {
            Assert.Equal(expectedOutputs[i], deserialized.Outputs[i]);
        }
        Assert.Equal(expectedPreviousInteractionID, deserialized.PreviousInteractionID);
        Assert.NotNull(deserialized.ResponseFormat);
        Assert.True(
            JsonElement.DeepEquals(expectedResponseFormat, deserialized.ResponseFormat.Value)
        );
        Assert.Equal(expectedResponseMimeType, deserialized.ResponseMimeType);
        Assert.NotNull(deserialized.ResponseModalities);
        Assert.Equal(expectedResponseModalities.Count, deserialized.ResponseModalities.Count);
        for (int i = 0; i < expectedResponseModalities.Count; i++)
        {
            Assert.Equal(expectedResponseModalities[i], deserialized.ResponseModalities[i]);
        }
        Assert.Equal(expectedRole, deserialized.Role);
        Assert.Equal(expectedServiceTier, deserialized.ServiceTier);
        Assert.Equal(expectedSystemInstruction, deserialized.SystemInstruction);
        Assert.NotNull(deserialized.Tools);
        Assert.Equal(expectedTools.Count, deserialized.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], deserialized.Tools[i]);
        }
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Interaction
        {
            ID = "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg",
            Created = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
            Status = InteractionStatus.Completed,
            Updated = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
            Agent = InteractionAgent.DeepResearchProPreview12_2025,
            AgentConfig = new DynamicAgentConfig(),
            GenerationConfig = new()
            {
                ImageConfig = new() { AspectRatio = AspectRatio.V1_1, ImageSize = ImageSize.V1K },
                MaxOutputTokens = 0,
                Seed = 0,
                SpeechConfig = new List<SpeechConfig>()
                {
                    new SpeechConfig()
                    {
                        Language = "language",
                        Speaker = "speaker",
                        Voice = "voice",
                    },
                },
                StopSequences = new List<string>() { "string" },
                Temperature = 0,
                ThinkingLevel = ThinkingLevel.Minimal,
                ThinkingSummaries = GenerationConfigThinkingSummaries.Auto,
                ToolChoice = ToolChoiceType.Auto,
                TopP = 0,
            },
            Input = new(
                new List<Content>()
                {
                    new Content(
                        new TextContent()
                        {
                            Text = "text",
                            Annotations = new List<Annotation>()
                            {
                                new Annotation(
                                    new UrlCitation()
                                    {
                                        EndIndex = 0,
                                        StartIndex = 0,
                                        Title = "title",
                                        Url = "url",
                                    }
                                ),
                            },
                        }
                    ),
                }
            ),
            Model = Model.Gemini3FlashPreview,
            Outputs = new List<Content>()
            {
                new Content(
                    new TextContent()
                    {
                        Text =
                            "Hello! I'm doing well, functioning as expected. Thank you for asking! How are you doing today?",
                        Annotations = new List<Annotation>()
                        {
                            new Annotation(
                                new UrlCitation()
                                {
                                    EndIndex = 0,
                                    StartIndex = 0,
                                    Title = "title",
                                    Url = "url",
                                }
                            ),
                        },
                    }
                ),
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<ApiEnum<string, InteractionResponseModality>>()
            {
                InteractionResponseModality.Text,
            },
            Role = "model",
            ServiceTier = InteractionServiceTier.Flex,
            SystemInstruction = "system_instruction",
            Tools = new List<Tool>()
            {
                new Tool(
                    new Function()
                    {
                        Description = "description",
                        Name = "name",
                        Parameters = JsonSerializer.Deserialize<JsonElement>("{}"),
                    }
                ),
            },
            Usage = new()
            {
                CachedTokensByModality = new List<CachedTokensByModality>()
                {
                    new CachedTokensByModality() { Modality = Modality.Text, Tokens = 0 },
                },
                InputTokensByModality = new List<InputTokensByModality>()
                {
                    new InputTokensByModality()
                    {
                        Modality = InputTokensByModalityModality.Text,
                        Tokens = 7,
                    },
                },
                OutputTokensByModality = new List<OutputTokensByModality>()
                {
                    new OutputTokensByModality()
                    {
                        Modality = OutputTokensByModalityModality.Text,
                        Tokens = 0,
                    },
                },
                ToolUseTokensByModality = new List<ToolUseTokensByModality>()
                {
                    new ToolUseTokensByModality()
                    {
                        Modality = ToolUseTokensByModalityModality.Text,
                        Tokens = 0,
                    },
                },
                TotalCachedTokens = 0,
                TotalInputTokens = 7,
                TotalOutputTokens = 23,
                TotalThoughtTokens = 49,
                TotalTokens = 79,
                TotalToolUseTokens = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Interaction
        {
            ID = "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg",
            Created = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
            Status = InteractionStatus.Completed,
            Updated = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
        };

        Assert.Null(model.Agent);
        Assert.False(model.RawData.ContainsKey("agent"));
        Assert.Null(model.AgentConfig);
        Assert.False(model.RawData.ContainsKey("agent_config"));
        Assert.Null(model.GenerationConfig);
        Assert.False(model.RawData.ContainsKey("generation_config"));
        Assert.Null(model.Input);
        Assert.False(model.RawData.ContainsKey("input"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Outputs);
        Assert.False(model.RawData.ContainsKey("outputs"));
        Assert.Null(model.PreviousInteractionID);
        Assert.False(model.RawData.ContainsKey("previous_interaction_id"));
        Assert.Null(model.ResponseFormat);
        Assert.False(model.RawData.ContainsKey("response_format"));
        Assert.Null(model.ResponseMimeType);
        Assert.False(model.RawData.ContainsKey("response_mime_type"));
        Assert.Null(model.ResponseModalities);
        Assert.False(model.RawData.ContainsKey("response_modalities"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
        Assert.Null(model.ServiceTier);
        Assert.False(model.RawData.ContainsKey("service_tier"));
        Assert.Null(model.SystemInstruction);
        Assert.False(model.RawData.ContainsKey("system_instruction"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Interaction
        {
            ID = "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg",
            Created = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
            Status = InteractionStatus.Completed,
            Updated = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Interaction
        {
            ID = "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg",
            Created = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
            Status = InteractionStatus.Completed,
            Updated = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),

            // Null should be interpreted as omitted for these properties
            Agent = null,
            AgentConfig = null,
            GenerationConfig = null,
            Input = null,
            Model = null,
            Outputs = null,
            PreviousInteractionID = null,
            ResponseFormat = null,
            ResponseMimeType = null,
            ResponseModalities = null,
            Role = null,
            ServiceTier = null,
            SystemInstruction = null,
            Tools = null,
            Usage = null,
        };

        Assert.Null(model.Agent);
        Assert.False(model.RawData.ContainsKey("agent"));
        Assert.Null(model.AgentConfig);
        Assert.False(model.RawData.ContainsKey("agent_config"));
        Assert.Null(model.GenerationConfig);
        Assert.False(model.RawData.ContainsKey("generation_config"));
        Assert.Null(model.Input);
        Assert.False(model.RawData.ContainsKey("input"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.Outputs);
        Assert.False(model.RawData.ContainsKey("outputs"));
        Assert.Null(model.PreviousInteractionID);
        Assert.False(model.RawData.ContainsKey("previous_interaction_id"));
        Assert.Null(model.ResponseFormat);
        Assert.False(model.RawData.ContainsKey("response_format"));
        Assert.Null(model.ResponseMimeType);
        Assert.False(model.RawData.ContainsKey("response_mime_type"));
        Assert.Null(model.ResponseModalities);
        Assert.False(model.RawData.ContainsKey("response_modalities"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
        Assert.Null(model.ServiceTier);
        Assert.False(model.RawData.ContainsKey("service_tier"));
        Assert.Null(model.SystemInstruction);
        Assert.False(model.RawData.ContainsKey("system_instruction"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Interaction
        {
            ID = "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg",
            Created = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
            Status = InteractionStatus.Completed,
            Updated = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),

            // Null should be interpreted as omitted for these properties
            Agent = null,
            AgentConfig = null,
            GenerationConfig = null,
            Input = null,
            Model = null,
            Outputs = null,
            PreviousInteractionID = null,
            ResponseFormat = null,
            ResponseMimeType = null,
            ResponseModalities = null,
            Role = null,
            ServiceTier = null,
            SystemInstruction = null,
            Tools = null,
            Usage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Interaction
        {
            ID = "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg",
            Created = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
            Status = InteractionStatus.Completed,
            Updated = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
            Agent = InteractionAgent.DeepResearchProPreview12_2025,
            AgentConfig = new DynamicAgentConfig(),
            GenerationConfig = new()
            {
                ImageConfig = new() { AspectRatio = AspectRatio.V1_1, ImageSize = ImageSize.V1K },
                MaxOutputTokens = 0,
                Seed = 0,
                SpeechConfig = new List<SpeechConfig>()
                {
                    new SpeechConfig()
                    {
                        Language = "language",
                        Speaker = "speaker",
                        Voice = "voice",
                    },
                },
                StopSequences = new List<string>() { "string" },
                Temperature = 0,
                ThinkingLevel = ThinkingLevel.Minimal,
                ThinkingSummaries = GenerationConfigThinkingSummaries.Auto,
                ToolChoice = ToolChoiceType.Auto,
                TopP = 0,
            },
            Input = new(
                new List<Content>()
                {
                    new Content(
                        new TextContent()
                        {
                            Text = "text",
                            Annotations = new List<Annotation>()
                            {
                                new Annotation(
                                    new UrlCitation()
                                    {
                                        EndIndex = 0,
                                        StartIndex = 0,
                                        Title = "title",
                                        Url = "url",
                                    }
                                ),
                            },
                        }
                    ),
                }
            ),
            Model = Model.Gemini3FlashPreview,
            Outputs = new List<Content>()
            {
                new Content(
                    new TextContent()
                    {
                        Text =
                            "Hello! I'm doing well, functioning as expected. Thank you for asking! How are you doing today?",
                        Annotations = new List<Annotation>()
                        {
                            new Annotation(
                                new UrlCitation()
                                {
                                    EndIndex = 0,
                                    StartIndex = 0,
                                    Title = "title",
                                    Url = "url",
                                }
                            ),
                        },
                    }
                ),
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<ApiEnum<string, InteractionResponseModality>>()
            {
                InteractionResponseModality.Text,
            },
            Role = "model",
            ServiceTier = InteractionServiceTier.Flex,
            SystemInstruction = "system_instruction",
            Tools = new List<Tool>()
            {
                new Tool(
                    new Function()
                    {
                        Description = "description",
                        Name = "name",
                        Parameters = JsonSerializer.Deserialize<JsonElement>("{}"),
                    }
                ),
            },
            Usage = new()
            {
                CachedTokensByModality = new List<CachedTokensByModality>()
                {
                    new CachedTokensByModality() { Modality = Modality.Text, Tokens = 0 },
                },
                InputTokensByModality = new List<InputTokensByModality>()
                {
                    new InputTokensByModality()
                    {
                        Modality = InputTokensByModalityModality.Text,
                        Tokens = 7,
                    },
                },
                OutputTokensByModality = new List<OutputTokensByModality>()
                {
                    new OutputTokensByModality()
                    {
                        Modality = OutputTokensByModalityModality.Text,
                        Tokens = 0,
                    },
                },
                ToolUseTokensByModality = new List<ToolUseTokensByModality>()
                {
                    new ToolUseTokensByModality()
                    {
                        Modality = ToolUseTokensByModalityModality.Text,
                        Tokens = 0,
                    },
                },
                TotalCachedTokens = 0,
                TotalInputTokens = 7,
                TotalOutputTokens = 23,
                TotalThoughtTokens = 49,
                TotalTokens = 79,
                TotalToolUseTokens = 0,
            },
        };

        Interaction copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InteractionStatusTest : TestBase
{
    [Theory]
    [InlineData(InteractionStatus.InProgress)]
    [InlineData(InteractionStatus.RequiresAction)]
    [InlineData(InteractionStatus.Completed)]
    [InlineData(InteractionStatus.Failed)]
    [InlineData(InteractionStatus.Cancelled)]
    [InlineData(InteractionStatus.Incomplete)]
    public void Validation_Works(InteractionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InteractionStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InteractionStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InteractionStatus.InProgress)]
    [InlineData(InteractionStatus.RequiresAction)]
    [InlineData(InteractionStatus.Completed)]
    [InlineData(InteractionStatus.Failed)]
    [InlineData(InteractionStatus.Cancelled)]
    [InlineData(InteractionStatus.Incomplete)]
    public void SerializationRoundtrip_Works(InteractionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InteractionStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InteractionStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InteractionStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InteractionStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InteractionAgentTest : TestBase
{
    [Theory]
    [InlineData(InteractionAgent.DeepResearchProPreview12_2025)]
    public void Validation_Works(InteractionAgent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InteractionAgent> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InteractionAgent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InteractionAgent.DeepResearchProPreview12_2025)]
    public void SerializationRoundtrip_Works(InteractionAgent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InteractionAgent> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InteractionAgent>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InteractionAgent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InteractionAgent>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InteractionAgentConfigTest : TestBase
{
    [Fact]
    public void DynamicValidationWorks()
    {
        InteractionAgentConfig value = new DynamicAgentConfig();
        value.Validate();
    }

    [Fact]
    public void DeepResearchValidationWorks()
    {
        InteractionAgentConfig value = new DeepResearchAgentConfig()
        {
            ThinkingSummaries = ThinkingSummaries.Auto,
        };
        value.Validate();
    }

    [Fact]
    public void DynamicSerializationRoundtripWorks()
    {
        InteractionAgentConfig value = new DynamicAgentConfig();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionAgentConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DeepResearchSerializationRoundtripWorks()
    {
        InteractionAgentConfig value = new DeepResearchAgentConfig()
        {
            ThinkingSummaries = ThinkingSummaries.Auto,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionAgentConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InteractionInputTest : TestBase
{
    [Fact]
    public void ContentListValidationWorks()
    {
        InteractionInput value = new(
            new List<Content>()
            {
                new Content(
                    new TextContent()
                    {
                        Text = "text",
                        Annotations = new List<Annotation>()
                        {
                            new Annotation(
                                new UrlCitation()
                                {
                                    EndIndex = 0,
                                    StartIndex = 0,
                                    Title = "title",
                                    Url = "url",
                                }
                            ),
                        },
                    }
                ),
            }
        );
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        InteractionInput value = "string";
        value.Validate();
    }

    [Fact]
    public void TurnListValidationWorks()
    {
        InteractionInput value = new(
            new List<Turn>()
            {
                new Turn()
                {
                    Content = new(
                        new List<Content>()
                        {
                            new Content(
                                new TextContent()
                                {
                                    Text = "text",
                                    Annotations = new List<Annotation>()
                                    {
                                        new Annotation(
                                            new UrlCitation()
                                            {
                                                EndIndex = 0,
                                                StartIndex = 0,
                                                Title = "title",
                                                Url = "url",
                                            }
                                        ),
                                    },
                                }
                            ),
                        }
                    ),
                    Role = "role",
                },
            }
        );
        value.Validate();
    }

    [Fact]
    public void TextContentValidationWorks()
    {
        InteractionInput value = new TextContent()
        {
            Text = "text",
            Annotations = new List<Annotation>()
            {
                new Annotation(
                    new UrlCitation()
                    {
                        EndIndex = 0,
                        StartIndex = 0,
                        Title = "title",
                        Url = "url",
                    }
                ),
            },
        };
        value.Validate();
    }

    [Fact]
    public void ImageContentValidationWorks()
    {
        InteractionInput value = new ImageContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageContentMimeType.ImagePng,
            Resolution = ImageContentResolution.Low,
            Uri = "uri",
        };
        value.Validate();
    }

    [Fact]
    public void AudioContentValidationWorks()
    {
        InteractionInput value = new AudioContent()
        {
            Channels = 0,
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = MimeType.AudioWav,
            Rate = 0,
            Uri = "uri",
        };
        value.Validate();
    }

    [Fact]
    public void DocumentContentValidationWorks()
    {
        InteractionInput value = new DocumentContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = DocumentContentMimeType.ApplicationPdf,
            Uri = "uri",
        };
        value.Validate();
    }

    [Fact]
    public void VideoContentValidationWorks()
    {
        InteractionInput value = new VideoContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = VideoContentMimeType.VideoMp4,
            Resolution = VideoContentResolution.Low,
            Uri = "uri",
        };
        value.Validate();
    }

    [Fact]
    public void ThoughtContentValidationWorks()
    {
        InteractionInput value = new ThoughtContent()
        {
            Signature = "U3RhaW5sZXNzIHJvY2tz",
            Summary = new List<Summary>()
            {
                new Summary(
                    new TextContent()
                    {
                        Text = "text",
                        Annotations = new List<Annotation>()
                        {
                            new Annotation(
                                new UrlCitation()
                                {
                                    EndIndex = 0,
                                    StartIndex = 0,
                                    Title = "title",
                                    Url = "url",
                                }
                            ),
                        },
                    }
                ),
            },
        };
        value.Validate();
    }

    [Fact]
    public void FunctionCallContentValidationWorks()
    {
        InteractionInput value = new FunctionCallContent()
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void CodeExecutionCallContentValidationWorks()
    {
        InteractionInput value = new CodeExecutionCallContent()
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void UrlContextCallContentValidationWorks()
    {
        InteractionInput value = new UrlContextCallContent()
        {
            ID = "id",
            Arguments = new() { Urls = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void McpServerToolCallContentValidationWorks()
    {
        InteractionInput value = new McpServerToolCallContent()
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void GoogleSearchCallContentValidationWorks()
    {
        InteractionInput value = new GoogleSearchCallContent()
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            SearchType = SearchType.WebSearch,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void FileSearchCallContentValidationWorks()
    {
        InteractionInput value = new FileSearchCallContent()
        {
            ID = "id",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void GoogleMapsCallContentValidationWorks()
    {
        InteractionInput value = new GoogleMapsCallContent()
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void FunctionResultContentValidationWorks()
    {
        InteractionInput value = new FunctionResultContent()
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsError = true,
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void CodeExecutionResultContentValidationWorks()
    {
        InteractionInput value = new CodeExecutionResultContent()
        {
            CallID = "call_id",
            Result = "result",
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void UrlContextResultContentValidationWorks()
    {
        InteractionInput value = new UrlContextResultContent()
        {
            CallID = "call_id",
            Result = new List<InteractionUrlContextResult>()
            {
                new InteractionUrlContextResult()
                {
                    Status = InteractionUrlContextResultStatus.Success,
                    Url = "url",
                },
            },
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void GoogleSearchResultContentValidationWorks()
    {
        InteractionInput value = new GoogleSearchResultContent()
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleSearchResult>()
            {
                new InteractionGoogleSearchResult() { SearchSuggestions = "search_suggestions" },
            },
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void McpServerToolResultContentValidationWorks()
    {
        InteractionInput value = new McpServerToolResultContent()
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void FileSearchResultContentValidationWorks()
    {
        InteractionInput value = new FileSearchResultContent()
        {
            CallID = "call_id",
            Result = new List<FileSearchResultContentResult>()
            {
                new FileSearchResultContentResult()
                {
                    CustomMetadata = new List<JsonElement>()
                    {
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
                },
            },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void GoogleMapsResultContentValidationWorks()
    {
        InteractionInput value = new GoogleMapsResultContent()
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleMapsResult>()
            {
                new InteractionGoogleMapsResult()
                {
                    Places = new List<Place>()
                    {
                        new Place()
                        {
                            Name = "name",
                            PlaceID = "place_id",
                            ReviewSnippets = new List<ReviewSnippet>()
                            {
                                new ReviewSnippet()
                                {
                                    ReviewID = "review_id",
                                    Title = "title",
                                    Url = "url",
                                },
                            },
                            Url = "url",
                        },
                    },
                    WidgetContextToken = "widget_context_token",
                },
            },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void ContentListSerializationRoundtripWorks()
    {
        InteractionInput value = new(
            new List<Content>()
            {
                new Content(
                    new TextContent()
                    {
                        Text = "text",
                        Annotations = new List<Annotation>()
                        {
                            new Annotation(
                                new UrlCitation()
                                {
                                    EndIndex = 0,
                                    StartIndex = 0,
                                    Title = "title",
                                    Url = "url",
                                }
                            ),
                        },
                    }
                ),
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        InteractionInput value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TurnListSerializationRoundtripWorks()
    {
        InteractionInput value = new(
            new List<Turn>()
            {
                new Turn()
                {
                    Content = new(
                        new List<Content>()
                        {
                            new Content(
                                new TextContent()
                                {
                                    Text = "text",
                                    Annotations = new List<Annotation>()
                                    {
                                        new Annotation(
                                            new UrlCitation()
                                            {
                                                EndIndex = 0,
                                                StartIndex = 0,
                                                Title = "title",
                                                Url = "url",
                                            }
                                        ),
                                    },
                                }
                            ),
                        }
                    ),
                    Role = "role",
                },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextContentSerializationRoundtripWorks()
    {
        InteractionInput value = new TextContent()
        {
            Text = "text",
            Annotations = new List<Annotation>()
            {
                new Annotation(
                    new UrlCitation()
                    {
                        EndIndex = 0,
                        StartIndex = 0,
                        Title = "title",
                        Url = "url",
                    }
                ),
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageContentSerializationRoundtripWorks()
    {
        InteractionInput value = new ImageContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageContentMimeType.ImagePng,
            Resolution = ImageContentResolution.Low,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AudioContentSerializationRoundtripWorks()
    {
        InteractionInput value = new AudioContent()
        {
            Channels = 0,
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = MimeType.AudioWav,
            Rate = 0,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DocumentContentSerializationRoundtripWorks()
    {
        InteractionInput value = new DocumentContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = DocumentContentMimeType.ApplicationPdf,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VideoContentSerializationRoundtripWorks()
    {
        InteractionInput value = new VideoContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = VideoContentMimeType.VideoMp4,
            Resolution = VideoContentResolution.Low,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThoughtContentSerializationRoundtripWorks()
    {
        InteractionInput value = new ThoughtContent()
        {
            Signature = "U3RhaW5sZXNzIHJvY2tz",
            Summary = new List<Summary>()
            {
                new Summary(
                    new TextContent()
                    {
                        Text = "text",
                        Annotations = new List<Annotation>()
                        {
                            new Annotation(
                                new UrlCitation()
                                {
                                    EndIndex = 0,
                                    StartIndex = 0,
                                    Title = "title",
                                    Url = "url",
                                }
                            ),
                        },
                    }
                ),
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FunctionCallContentSerializationRoundtripWorks()
    {
        InteractionInput value = new FunctionCallContent()
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionCallContentSerializationRoundtripWorks()
    {
        InteractionInput value = new CodeExecutionCallContent()
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UrlContextCallContentSerializationRoundtripWorks()
    {
        InteractionInput value = new UrlContextCallContent()
        {
            ID = "id",
            Arguments = new() { Urls = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpServerToolCallContentSerializationRoundtripWorks()
    {
        InteractionInput value = new McpServerToolCallContent()
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleSearchCallContentSerializationRoundtripWorks()
    {
        InteractionInput value = new GoogleSearchCallContent()
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            SearchType = SearchType.WebSearch,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileSearchCallContentSerializationRoundtripWorks()
    {
        InteractionInput value = new FileSearchCallContent()
        {
            ID = "id",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleMapsCallContentSerializationRoundtripWorks()
    {
        InteractionInput value = new GoogleMapsCallContent()
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FunctionResultContentSerializationRoundtripWorks()
    {
        InteractionInput value = new FunctionResultContent()
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsError = true,
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionResultContentSerializationRoundtripWorks()
    {
        InteractionInput value = new CodeExecutionResultContent()
        {
            CallID = "call_id",
            Result = "result",
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UrlContextResultContentSerializationRoundtripWorks()
    {
        InteractionInput value = new UrlContextResultContent()
        {
            CallID = "call_id",
            Result = new List<InteractionUrlContextResult>()
            {
                new InteractionUrlContextResult()
                {
                    Status = InteractionUrlContextResultStatus.Success,
                    Url = "url",
                },
            },
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleSearchResultContentSerializationRoundtripWorks()
    {
        InteractionInput value = new GoogleSearchResultContent()
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleSearchResult>()
            {
                new InteractionGoogleSearchResult() { SearchSuggestions = "search_suggestions" },
            },
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpServerToolResultContentSerializationRoundtripWorks()
    {
        InteractionInput value = new McpServerToolResultContent()
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileSearchResultContentSerializationRoundtripWorks()
    {
        InteractionInput value = new FileSearchResultContent()
        {
            CallID = "call_id",
            Result = new List<FileSearchResultContentResult>()
            {
                new FileSearchResultContentResult()
                {
                    CustomMetadata = new List<JsonElement>()
                    {
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
                },
            },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleMapsResultContentSerializationRoundtripWorks()
    {
        InteractionInput value = new GoogleMapsResultContent()
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleMapsResult>()
            {
                new InteractionGoogleMapsResult()
                {
                    Places = new List<Place>()
                    {
                        new Place()
                        {
                            Name = "name",
                            PlaceID = "place_id",
                            ReviewSnippets = new List<ReviewSnippet>()
                            {
                                new ReviewSnippet()
                                {
                                    ReviewID = "review_id",
                                    Title = "title",
                                    Url = "url",
                                },
                            },
                            Url = "url",
                        },
                    },
                    WidgetContextToken = "widget_context_token",
                },
            },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InteractionResponseModalityTest : TestBase
{
    [Theory]
    [InlineData(InteractionResponseModality.Text)]
    [InlineData(InteractionResponseModality.Image)]
    [InlineData(InteractionResponseModality.Audio)]
    [InlineData(InteractionResponseModality.Video)]
    [InlineData(InteractionResponseModality.Document)]
    public void Validation_Works(InteractionResponseModality rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InteractionResponseModality> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InteractionResponseModality>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InteractionResponseModality.Text)]
    [InlineData(InteractionResponseModality.Image)]
    [InlineData(InteractionResponseModality.Audio)]
    [InlineData(InteractionResponseModality.Video)]
    [InlineData(InteractionResponseModality.Document)]
    public void SerializationRoundtrip_Works(InteractionResponseModality rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InteractionResponseModality> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InteractionResponseModality>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InteractionResponseModality>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InteractionResponseModality>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InteractionServiceTierTest : TestBase
{
    [Theory]
    [InlineData(InteractionServiceTier.Flex)]
    [InlineData(InteractionServiceTier.Standard)]
    [InlineData(InteractionServiceTier.Priority)]
    public void Validation_Works(InteractionServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InteractionServiceTier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InteractionServiceTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InteractionServiceTier.Flex)]
    [InlineData(InteractionServiceTier.Standard)]
    [InlineData(InteractionServiceTier.Priority)]
    public void SerializationRoundtrip_Works(InteractionServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InteractionServiceTier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InteractionServiceTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InteractionServiceTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InteractionServiceTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
