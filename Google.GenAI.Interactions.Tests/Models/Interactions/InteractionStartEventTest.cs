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
using Google.GenAI.Interactions.Models.Interactions;

namespace Google.GenAI.Interactions.Tests.Models.Interactions;

public class InteractionStartEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InteractionStartEvent
        {
            Interaction = new()
            {
                ID = "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg",
                Created = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
                Status = InteractionStatus.Completed,
                Updated = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
                Agent = InteractionAgent.DeepResearchProPreview12_2025,
                AgentConfig = new DynamicAgentConfig(),
                GenerationConfig = new()
                {
                    ImageConfig = new()
                    {
                        AspectRatio = AspectRatio.V1_1,
                        ImageSize = ImageSize.V1K,
                    },
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
            },
            EventID = "event_id",
        };

        JsonElement expectedEventType = JsonSerializer.SerializeToElement("interaction.start");
        Interaction expectedInteraction = new()
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
        string expectedEventID = "event_id";

        Assert.True(JsonElement.DeepEquals(expectedEventType, model.EventType));
        Assert.Equal(expectedInteraction, model.Interaction);
        Assert.Equal(expectedEventID, model.EventID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InteractionStartEvent
        {
            Interaction = new()
            {
                ID = "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg",
                Created = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
                Status = InteractionStatus.Completed,
                Updated = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
                Agent = InteractionAgent.DeepResearchProPreview12_2025,
                AgentConfig = new DynamicAgentConfig(),
                GenerationConfig = new()
                {
                    ImageConfig = new()
                    {
                        AspectRatio = AspectRatio.V1_1,
                        ImageSize = ImageSize.V1K,
                    },
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
            },
            EventID = "event_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionStartEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InteractionStartEvent
        {
            Interaction = new()
            {
                ID = "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg",
                Created = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
                Status = InteractionStatus.Completed,
                Updated = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
                Agent = InteractionAgent.DeepResearchProPreview12_2025,
                AgentConfig = new DynamicAgentConfig(),
                GenerationConfig = new()
                {
                    ImageConfig = new()
                    {
                        AspectRatio = AspectRatio.V1_1,
                        ImageSize = ImageSize.V1K,
                    },
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
            },
            EventID = "event_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionStartEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedEventType = JsonSerializer.SerializeToElement("interaction.start");
        Interaction expectedInteraction = new()
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
        string expectedEventID = "event_id";

        Assert.True(JsonElement.DeepEquals(expectedEventType, deserialized.EventType));
        Assert.Equal(expectedInteraction, deserialized.Interaction);
        Assert.Equal(expectedEventID, deserialized.EventID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InteractionStartEvent
        {
            Interaction = new()
            {
                ID = "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg",
                Created = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
                Status = InteractionStatus.Completed,
                Updated = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
                Agent = InteractionAgent.DeepResearchProPreview12_2025,
                AgentConfig = new DynamicAgentConfig(),
                GenerationConfig = new()
                {
                    ImageConfig = new()
                    {
                        AspectRatio = AspectRatio.V1_1,
                        ImageSize = ImageSize.V1K,
                    },
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
            },
            EventID = "event_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InteractionStartEvent
        {
            Interaction = new()
            {
                ID = "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg",
                Created = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
                Status = InteractionStatus.Completed,
                Updated = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
                Agent = InteractionAgent.DeepResearchProPreview12_2025,
                AgentConfig = new DynamicAgentConfig(),
                GenerationConfig = new()
                {
                    ImageConfig = new()
                    {
                        AspectRatio = AspectRatio.V1_1,
                        ImageSize = ImageSize.V1K,
                    },
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
            },
        };

        Assert.Null(model.EventID);
        Assert.False(model.RawData.ContainsKey("event_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InteractionStartEvent
        {
            Interaction = new()
            {
                ID = "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg",
                Created = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
                Status = InteractionStatus.Completed,
                Updated = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
                Agent = InteractionAgent.DeepResearchProPreview12_2025,
                AgentConfig = new DynamicAgentConfig(),
                GenerationConfig = new()
                {
                    ImageConfig = new()
                    {
                        AspectRatio = AspectRatio.V1_1,
                        ImageSize = ImageSize.V1K,
                    },
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InteractionStartEvent
        {
            Interaction = new()
            {
                ID = "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg",
                Created = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
                Status = InteractionStatus.Completed,
                Updated = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
                Agent = InteractionAgent.DeepResearchProPreview12_2025,
                AgentConfig = new DynamicAgentConfig(),
                GenerationConfig = new()
                {
                    ImageConfig = new()
                    {
                        AspectRatio = AspectRatio.V1_1,
                        ImageSize = ImageSize.V1K,
                    },
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
            },

            // Null should be interpreted as omitted for these properties
            EventID = null,
        };

        Assert.Null(model.EventID);
        Assert.False(model.RawData.ContainsKey("event_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InteractionStartEvent
        {
            Interaction = new()
            {
                ID = "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg",
                Created = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
                Status = InteractionStatus.Completed,
                Updated = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
                Agent = InteractionAgent.DeepResearchProPreview12_2025,
                AgentConfig = new DynamicAgentConfig(),
                GenerationConfig = new()
                {
                    ImageConfig = new()
                    {
                        AspectRatio = AspectRatio.V1_1,
                        ImageSize = ImageSize.V1K,
                    },
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
            },

            // Null should be interpreted as omitted for these properties
            EventID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InteractionStartEvent
        {
            Interaction = new()
            {
                ID = "v1_ChdXS0l4YWZXTk9xbk0xZThQczhEcmlROBIXV0tJeGFmV05PcW5NMWU4UHM4RHJpUTg",
                Created = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
                Status = InteractionStatus.Completed,
                Updated = DateTimeOffset.Parse("2025-12-04T15:01:45Z"),
                Agent = InteractionAgent.DeepResearchProPreview12_2025,
                AgentConfig = new DynamicAgentConfig(),
                GenerationConfig = new()
                {
                    ImageConfig = new()
                    {
                        AspectRatio = AspectRatio.V1_1,
                        ImageSize = ImageSize.V1K,
                    },
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
            },
            EventID = "event_id",
        };

        InteractionStartEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}
