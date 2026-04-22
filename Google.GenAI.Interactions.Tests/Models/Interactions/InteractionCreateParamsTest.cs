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

public class InteractionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InteractionCreateParams
        {
            ApiVersion = "api_version",
            Body = new CreateModelInteractionParams()
            {
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
                Model = Model.Gemini2_5ComputerUsePreview10_2025,
                ID = "id",
                Background = true,
                Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                Outputs = new List<Content>()
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
                },
                PreviousInteractionID = "previous_interaction_id",
                ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
                ResponseMimeType = "response_mime_type",
                ResponseModalities = new List<ApiEnum<string, ResponseModality>>()
                {
                    ResponseModality.Text,
                },
                Role = "role",
                ServiceTier = ServiceTier.Flex,
                Status = Status.InProgress,
                Store = true,
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
                Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                            Tokens = 0,
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
                    TotalInputTokens = 0,
                    TotalOutputTokens = 0,
                    TotalThoughtTokens = 0,
                    TotalTokens = 0,
                    TotalToolUseTokens = 0,
                },
            },
        };

        string expectedApiVersion = "api_version";
        Body expectedBody = new CreateModelInteractionParams()
        {
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
            Model = Model.Gemini2_5ComputerUsePreview10_2025,
            ID = "id",
            Background = true,
            Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Outputs = new List<Content>()
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
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<ApiEnum<string, ResponseModality>>()
            {
                ResponseModality.Text,
            },
            Role = "role",
            ServiceTier = ServiceTier.Flex,
            Status = Status.InProgress,
            Store = true,
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
            Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                        Tokens = 0,
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
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalThoughtTokens = 0,
                TotalTokens = 0,
                TotalToolUseTokens = 0,
            },
        };

        Assert.Equal(expectedApiVersion, parameters.ApiVersion);
        Assert.Equal(expectedBody, parameters.Body);
    }

    [Fact]
    public void Url_Works()
    {
        InteractionCreateParams parameters = new()
        {
            ApiVersion = "api_version",
            Body = new CreateModelInteractionParams()
            {
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
                Model = Model.Gemini2_5ComputerUsePreview10_2025,
                ID = "id",
                Background = true,
                Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                Outputs = new List<Content>()
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
                },
                PreviousInteractionID = "previous_interaction_id",
                ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
                ResponseMimeType = "response_mime_type",
                ResponseModalities = new List<ApiEnum<string, ResponseModality>>()
                {
                    ResponseModality.Text,
                },
                Role = "role",
                ServiceTier = ServiceTier.Flex,
                Status = Status.InProgress,
                Store = true,
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
                Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                            Tokens = 0,
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
                    TotalInputTokens = 0,
                    TotalOutputTokens = 0,
                    TotalThoughtTokens = 0,
                    TotalTokens = 0,
                    TotalToolUseTokens = 0,
                },
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://generativelanguage.googleapis.com/api_version/interactions"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InteractionCreateParams
        {
            ApiVersion = "api_version",
            Body = new CreateModelInteractionParams()
            {
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
                Model = Model.Gemini2_5ComputerUsePreview10_2025,
                ID = "id",
                Background = true,
                Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                Outputs = new List<Content>()
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
                },
                PreviousInteractionID = "previous_interaction_id",
                ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
                ResponseMimeType = "response_mime_type",
                ResponseModalities = new List<ApiEnum<string, ResponseModality>>()
                {
                    ResponseModality.Text,
                },
                Role = "role",
                ServiceTier = ServiceTier.Flex,
                Status = Status.InProgress,
                Store = true,
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
                Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                            Tokens = 0,
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
                    TotalInputTokens = 0,
                    TotalOutputTokens = 0,
                    TotalThoughtTokens = 0,
                    TotalTokens = 0,
                    TotalToolUseTokens = 0,
                },
            },
        };

        InteractionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BodyTest : TestBase
{
    [Fact]
    public void CreateModelInteractionParamsValidationWorks()
    {
        Body value = new CreateModelInteractionParams()
        {
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
            Model = Model.Gemini2_5ComputerUsePreview10_2025,
            ID = "id",
            Background = true,
            Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Outputs = new List<Content>()
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
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<ApiEnum<string, ResponseModality>>()
            {
                ResponseModality.Text,
            },
            Role = "role",
            ServiceTier = ServiceTier.Flex,
            Status = Status.InProgress,
            Store = true,
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
            Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                        Tokens = 0,
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
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalThoughtTokens = 0,
                TotalTokens = 0,
                TotalToolUseTokens = 0,
            },
        };
        value.Validate();
    }

    [Fact]
    public void CreateAgentInteractionParamsValidationWorks()
    {
        Body value = new CreateAgentInteractionParams()
        {
            Agent = Agent.DeepResearchProPreview12_2025,
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
            ID = "id",
            AgentConfig = new DynamicAgentConfig(),
            Background = true,
            Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Outputs = new List<Content>()
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
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<
                ApiEnum<string, CreateAgentInteractionParamsResponseModality>
            >()
            {
                CreateAgentInteractionParamsResponseModality.Text,
            },
            Role = "role",
            ServiceTier = CreateAgentInteractionParamsServiceTier.Flex,
            Status = CreateAgentInteractionParamsStatus.InProgress,
            Store = true,
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
            Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                        Tokens = 0,
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
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalThoughtTokens = 0,
                TotalTokens = 0,
                TotalToolUseTokens = 0,
            },
        };
        value.Validate();
    }

    [Fact]
    public void CreateModelInteractionParamsSerializationRoundtripWorks()
    {
        Body value = new CreateModelInteractionParams()
        {
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
            Model = Model.Gemini2_5ComputerUsePreview10_2025,
            ID = "id",
            Background = true,
            Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Outputs = new List<Content>()
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
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<ApiEnum<string, ResponseModality>>()
            {
                ResponseModality.Text,
            },
            Role = "role",
            ServiceTier = ServiceTier.Flex,
            Status = Status.InProgress,
            Store = true,
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
            Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                        Tokens = 0,
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
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalThoughtTokens = 0,
                TotalTokens = 0,
                TotalToolUseTokens = 0,
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CreateAgentInteractionParamsSerializationRoundtripWorks()
    {
        Body value = new CreateAgentInteractionParams()
        {
            Agent = Agent.DeepResearchProPreview12_2025,
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
            ID = "id",
            AgentConfig = new DynamicAgentConfig(),
            Background = true,
            Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Outputs = new List<Content>()
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
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<
                ApiEnum<string, CreateAgentInteractionParamsResponseModality>
            >()
            {
                CreateAgentInteractionParamsResponseModality.Text,
            },
            Role = "role",
            ServiceTier = CreateAgentInteractionParamsServiceTier.Flex,
            Status = CreateAgentInteractionParamsStatus.InProgress,
            Store = true,
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
            Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                        Tokens = 0,
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
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalThoughtTokens = 0,
                TotalTokens = 0,
                TotalToolUseTokens = 0,
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreateModelInteractionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreateModelInteractionParams
        {
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
            Model = Model.Gemini2_5ComputerUsePreview10_2025,
            ID = "id",
            Background = true,
            Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Outputs = new List<Content>()
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
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<ApiEnum<string, ResponseModality>>()
            {
                ResponseModality.Text,
            },
            Role = "role",
            ServiceTier = ServiceTier.Flex,
            Status = Status.InProgress,
            Store = true,
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
            Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                        Tokens = 0,
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
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalThoughtTokens = 0,
                TotalTokens = 0,
                TotalToolUseTokens = 0,
            },
        };

        Input expectedInput = new(
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
        ApiEnum<string, Model> expectedModel = Model.Gemini2_5ComputerUsePreview10_2025;
        string expectedID = "id";
        bool expectedBackground = true;
        DateTimeOffset expectedCreated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
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
        List<Content> expectedOutputs = new List<Content>()
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
        };
        string expectedPreviousInteractionID = "previous_interaction_id";
        JsonElement expectedResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedResponseMimeType = "response_mime_type";
        List<ApiEnum<string, ResponseModality>> expectedResponseModalities = new List<
            ApiEnum<string, ResponseModality>
        >()
        {
            ResponseModality.Text,
        };
        string expectedRole = "role";
        ApiEnum<string, ServiceTier> expectedServiceTier = ServiceTier.Flex;
        ApiEnum<string, Status> expectedStatus = Status.InProgress;
        bool expectedStore = true;
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
        DateTimeOffset expectedUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
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
                    Tokens = 0,
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
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            TotalThoughtTokens = 0,
            TotalTokens = 0,
            TotalToolUseTokens = 0,
        };

        Assert.Equal(expectedInput, model.Input);
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBackground, model.Background);
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedGenerationConfig, model.GenerationConfig);
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
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStore, model.Store);
        Assert.Equal(expectedSystemInstruction, model.SystemInstruction);
        Assert.NotNull(model.Tools);
        Assert.Equal(expectedTools.Count, model.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], model.Tools[i]);
        }
        Assert.Equal(expectedUpdated, model.Updated);
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreateModelInteractionParams
        {
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
            Model = Model.Gemini2_5ComputerUsePreview10_2025,
            ID = "id",
            Background = true,
            Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Outputs = new List<Content>()
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
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<ApiEnum<string, ResponseModality>>()
            {
                ResponseModality.Text,
            },
            Role = "role",
            ServiceTier = ServiceTier.Flex,
            Status = Status.InProgress,
            Store = true,
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
            Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                        Tokens = 0,
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
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalThoughtTokens = 0,
                TotalTokens = 0,
                TotalToolUseTokens = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateModelInteractionParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreateModelInteractionParams
        {
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
            Model = Model.Gemini2_5ComputerUsePreview10_2025,
            ID = "id",
            Background = true,
            Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Outputs = new List<Content>()
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
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<ApiEnum<string, ResponseModality>>()
            {
                ResponseModality.Text,
            },
            Role = "role",
            ServiceTier = ServiceTier.Flex,
            Status = Status.InProgress,
            Store = true,
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
            Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                        Tokens = 0,
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
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalThoughtTokens = 0,
                TotalTokens = 0,
                TotalToolUseTokens = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateModelInteractionParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Input expectedInput = new(
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
        ApiEnum<string, Model> expectedModel = Model.Gemini2_5ComputerUsePreview10_2025;
        string expectedID = "id";
        bool expectedBackground = true;
        DateTimeOffset expectedCreated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
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
        List<Content> expectedOutputs = new List<Content>()
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
        };
        string expectedPreviousInteractionID = "previous_interaction_id";
        JsonElement expectedResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedResponseMimeType = "response_mime_type";
        List<ApiEnum<string, ResponseModality>> expectedResponseModalities = new List<
            ApiEnum<string, ResponseModality>
        >()
        {
            ResponseModality.Text,
        };
        string expectedRole = "role";
        ApiEnum<string, ServiceTier> expectedServiceTier = ServiceTier.Flex;
        ApiEnum<string, Status> expectedStatus = Status.InProgress;
        bool expectedStore = true;
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
        DateTimeOffset expectedUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
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
                    Tokens = 0,
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
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            TotalThoughtTokens = 0,
            TotalTokens = 0,
            TotalToolUseTokens = 0,
        };

        Assert.Equal(expectedInput, deserialized.Input);
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBackground, deserialized.Background);
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedGenerationConfig, deserialized.GenerationConfig);
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
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedStore, deserialized.Store);
        Assert.Equal(expectedSystemInstruction, deserialized.SystemInstruction);
        Assert.NotNull(deserialized.Tools);
        Assert.Equal(expectedTools.Count, deserialized.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], deserialized.Tools[i]);
        }
        Assert.Equal(expectedUpdated, deserialized.Updated);
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreateModelInteractionParams
        {
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
            Model = Model.Gemini2_5ComputerUsePreview10_2025,
            ID = "id",
            Background = true,
            Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Outputs = new List<Content>()
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
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<ApiEnum<string, ResponseModality>>()
            {
                ResponseModality.Text,
            },
            Role = "role",
            ServiceTier = ServiceTier.Flex,
            Status = Status.InProgress,
            Store = true,
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
            Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                        Tokens = 0,
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
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalThoughtTokens = 0,
                TotalTokens = 0,
                TotalToolUseTokens = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreateModelInteractionParams
        {
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
            Model = Model.Gemini2_5ComputerUsePreview10_2025,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Background);
        Assert.False(model.RawData.ContainsKey("background"));
        Assert.Null(model.Created);
        Assert.False(model.RawData.ContainsKey("created"));
        Assert.Null(model.GenerationConfig);
        Assert.False(model.RawData.ContainsKey("generation_config"));
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
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Store);
        Assert.False(model.RawData.ContainsKey("store"));
        Assert.Null(model.SystemInstruction);
        Assert.False(model.RawData.ContainsKey("system_instruction"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreateModelInteractionParams
        {
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
            Model = Model.Gemini2_5ComputerUsePreview10_2025,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreateModelInteractionParams
        {
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
            Model = Model.Gemini2_5ComputerUsePreview10_2025,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Background = null,
            Created = null,
            GenerationConfig = null,
            Outputs = null,
            PreviousInteractionID = null,
            ResponseFormat = null,
            ResponseMimeType = null,
            ResponseModalities = null,
            Role = null,
            ServiceTier = null,
            Status = null,
            Store = null,
            SystemInstruction = null,
            Tools = null,
            Updated = null,
            Usage = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Background);
        Assert.False(model.RawData.ContainsKey("background"));
        Assert.Null(model.Created);
        Assert.False(model.RawData.ContainsKey("created"));
        Assert.Null(model.GenerationConfig);
        Assert.False(model.RawData.ContainsKey("generation_config"));
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
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Store);
        Assert.False(model.RawData.ContainsKey("store"));
        Assert.Null(model.SystemInstruction);
        Assert.False(model.RawData.ContainsKey("system_instruction"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreateModelInteractionParams
        {
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
            Model = Model.Gemini2_5ComputerUsePreview10_2025,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Background = null,
            Created = null,
            GenerationConfig = null,
            Outputs = null,
            PreviousInteractionID = null,
            ResponseFormat = null,
            ResponseMimeType = null,
            ResponseModalities = null,
            Role = null,
            ServiceTier = null,
            Status = null,
            Store = null,
            SystemInstruction = null,
            Tools = null,
            Updated = null,
            Usage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreateModelInteractionParams
        {
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
            Model = Model.Gemini2_5ComputerUsePreview10_2025,
            ID = "id",
            Background = true,
            Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Outputs = new List<Content>()
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
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<ApiEnum<string, ResponseModality>>()
            {
                ResponseModality.Text,
            },
            Role = "role",
            ServiceTier = ServiceTier.Flex,
            Status = Status.InProgress,
            Store = true,
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
            Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                        Tokens = 0,
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
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalThoughtTokens = 0,
                TotalTokens = 0,
                TotalToolUseTokens = 0,
            },
        };

        CreateModelInteractionParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InputTest : TestBase
{
    [Fact]
    public void ContentListValidationWorks()
    {
        Input value = new(
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
        Input value = "string";
        value.Validate();
    }

    [Fact]
    public void TurnListValidationWorks()
    {
        Input value = new(
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
        Input value = new TextContent()
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
        Input value = new ImageContent()
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
        Input value = new AudioContent()
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
        Input value = new DocumentContent()
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
        Input value = new VideoContent()
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
        Input value = new ThoughtContent()
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
        Input value = new FunctionCallContent()
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
        Input value = new CodeExecutionCallContent()
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
        Input value = new UrlContextCallContent()
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
        Input value = new McpServerToolCallContent()
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
        Input value = new GoogleSearchCallContent()
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
        Input value = new FileSearchCallContent() { ID = "id", Signature = "U3RhaW5sZXNzIHJvY2tz" };
        value.Validate();
    }

    [Fact]
    public void GoogleMapsCallContentValidationWorks()
    {
        Input value = new GoogleMapsCallContent()
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
        Input value = new FunctionResultContent()
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
        Input value = new CodeExecutionResultContent()
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
        Input value = new UrlContextResultContent()
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
        Input value = new GoogleSearchResultContent()
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
        Input value = new McpServerToolResultContent()
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
        Input value = new FileSearchResultContent()
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
        Input value = new GoogleMapsResultContent()
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
        Input value = new(
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
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Input value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TurnListSerializationRoundtripWorks()
    {
        Input value = new(
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
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextContentSerializationRoundtripWorks()
    {
        Input value = new TextContent()
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
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageContentSerializationRoundtripWorks()
    {
        Input value = new ImageContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageContentMimeType.ImagePng,
            Resolution = ImageContentResolution.Low,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AudioContentSerializationRoundtripWorks()
    {
        Input value = new AudioContent()
        {
            Channels = 0,
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = MimeType.AudioWav,
            Rate = 0,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DocumentContentSerializationRoundtripWorks()
    {
        Input value = new DocumentContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = DocumentContentMimeType.ApplicationPdf,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VideoContentSerializationRoundtripWorks()
    {
        Input value = new VideoContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = VideoContentMimeType.VideoMp4,
            Resolution = VideoContentResolution.Low,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThoughtContentSerializationRoundtripWorks()
    {
        Input value = new ThoughtContent()
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
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FunctionCallContentSerializationRoundtripWorks()
    {
        Input value = new FunctionCallContent()
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
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionCallContentSerializationRoundtripWorks()
    {
        Input value = new CodeExecutionCallContent()
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UrlContextCallContentSerializationRoundtripWorks()
    {
        Input value = new UrlContextCallContent()
        {
            ID = "id",
            Arguments = new() { Urls = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpServerToolCallContentSerializationRoundtripWorks()
    {
        Input value = new McpServerToolCallContent()
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
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleSearchCallContentSerializationRoundtripWorks()
    {
        Input value = new GoogleSearchCallContent()
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            SearchType = SearchType.WebSearch,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileSearchCallContentSerializationRoundtripWorks()
    {
        Input value = new FileSearchCallContent() { ID = "id", Signature = "U3RhaW5sZXNzIHJvY2tz" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleMapsCallContentSerializationRoundtripWorks()
    {
        Input value = new GoogleMapsCallContent()
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FunctionResultContentSerializationRoundtripWorks()
    {
        Input value = new FunctionResultContent()
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsError = true,
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionResultContentSerializationRoundtripWorks()
    {
        Input value = new CodeExecutionResultContent()
        {
            CallID = "call_id",
            Result = "result",
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UrlContextResultContentSerializationRoundtripWorks()
    {
        Input value = new UrlContextResultContent()
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
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleSearchResultContentSerializationRoundtripWorks()
    {
        Input value = new GoogleSearchResultContent()
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
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpServerToolResultContentSerializationRoundtripWorks()
    {
        Input value = new McpServerToolResultContent()
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileSearchResultContentSerializationRoundtripWorks()
    {
        Input value = new FileSearchResultContent()
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
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleMapsResultContentSerializationRoundtripWorks()
    {
        Input value = new GoogleMapsResultContent()
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
        var deserialized = JsonSerializer.Deserialize<Input>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ResponseModalityTest : TestBase
{
    [Theory]
    [InlineData(ResponseModality.Text)]
    [InlineData(ResponseModality.Image)]
    [InlineData(ResponseModality.Audio)]
    [InlineData(ResponseModality.Video)]
    [InlineData(ResponseModality.Document)]
    public void Validation_Works(ResponseModality rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResponseModality> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResponseModality>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ResponseModality.Text)]
    [InlineData(ResponseModality.Image)]
    [InlineData(ResponseModality.Audio)]
    [InlineData(ResponseModality.Video)]
    [InlineData(ResponseModality.Document)]
    public void SerializationRoundtrip_Works(ResponseModality rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResponseModality> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ResponseModality>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResponseModality>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ResponseModality>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ServiceTierTest : TestBase
{
    [Theory]
    [InlineData(ServiceTier.Flex)]
    [InlineData(ServiceTier.Standard)]
    [InlineData(ServiceTier.Priority)]
    public void Validation_Works(ServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ServiceTier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ServiceTier.Flex)]
    [InlineData(ServiceTier.Standard)]
    [InlineData(ServiceTier.Priority)]
    public void SerializationRoundtrip_Works(ServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ServiceTier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.InProgress)]
    [InlineData(Status.RequiresAction)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Cancelled)]
    [InlineData(Status.Incomplete)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.InProgress)]
    [InlineData(Status.RequiresAction)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Cancelled)]
    [InlineData(Status.Incomplete)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CreateAgentInteractionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreateAgentInteractionParams
        {
            Agent = Agent.DeepResearchProPreview12_2025,
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
            ID = "id",
            AgentConfig = new DynamicAgentConfig(),
            Background = true,
            Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Outputs = new List<Content>()
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
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<
                ApiEnum<string, CreateAgentInteractionParamsResponseModality>
            >()
            {
                CreateAgentInteractionParamsResponseModality.Text,
            },
            Role = "role",
            ServiceTier = CreateAgentInteractionParamsServiceTier.Flex,
            Status = CreateAgentInteractionParamsStatus.InProgress,
            Store = true,
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
            Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                        Tokens = 0,
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
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalThoughtTokens = 0,
                TotalTokens = 0,
                TotalToolUseTokens = 0,
            },
        };

        ApiEnum<string, Agent> expectedAgent = Agent.DeepResearchProPreview12_2025;
        CreateAgentInteractionParamsInput expectedInput = new(
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
        string expectedID = "id";
        AgentConfig expectedAgentConfig = new DynamicAgentConfig();
        bool expectedBackground = true;
        DateTimeOffset expectedCreated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Content> expectedOutputs = new List<Content>()
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
        };
        string expectedPreviousInteractionID = "previous_interaction_id";
        JsonElement expectedResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedResponseMimeType = "response_mime_type";
        List<
            ApiEnum<string, CreateAgentInteractionParamsResponseModality>
        > expectedResponseModalities = new List<
            ApiEnum<string, CreateAgentInteractionParamsResponseModality>
        >()
        {
            CreateAgentInteractionParamsResponseModality.Text,
        };
        string expectedRole = "role";
        ApiEnum<string, CreateAgentInteractionParamsServiceTier> expectedServiceTier =
            CreateAgentInteractionParamsServiceTier.Flex;
        ApiEnum<string, CreateAgentInteractionParamsStatus> expectedStatus =
            CreateAgentInteractionParamsStatus.InProgress;
        bool expectedStore = true;
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
        DateTimeOffset expectedUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
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
                    Tokens = 0,
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
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            TotalThoughtTokens = 0,
            TotalTokens = 0,
            TotalToolUseTokens = 0,
        };

        Assert.Equal(expectedAgent, model.Agent);
        Assert.Equal(expectedInput, model.Input);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAgentConfig, model.AgentConfig);
        Assert.Equal(expectedBackground, model.Background);
        Assert.Equal(expectedCreated, model.Created);
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
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStore, model.Store);
        Assert.Equal(expectedSystemInstruction, model.SystemInstruction);
        Assert.NotNull(model.Tools);
        Assert.Equal(expectedTools.Count, model.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], model.Tools[i]);
        }
        Assert.Equal(expectedUpdated, model.Updated);
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreateAgentInteractionParams
        {
            Agent = Agent.DeepResearchProPreview12_2025,
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
            ID = "id",
            AgentConfig = new DynamicAgentConfig(),
            Background = true,
            Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Outputs = new List<Content>()
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
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<
                ApiEnum<string, CreateAgentInteractionParamsResponseModality>
            >()
            {
                CreateAgentInteractionParamsResponseModality.Text,
            },
            Role = "role",
            ServiceTier = CreateAgentInteractionParamsServiceTier.Flex,
            Status = CreateAgentInteractionParamsStatus.InProgress,
            Store = true,
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
            Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                        Tokens = 0,
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
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalThoughtTokens = 0,
                TotalTokens = 0,
                TotalToolUseTokens = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreateAgentInteractionParams
        {
            Agent = Agent.DeepResearchProPreview12_2025,
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
            ID = "id",
            AgentConfig = new DynamicAgentConfig(),
            Background = true,
            Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Outputs = new List<Content>()
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
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<
                ApiEnum<string, CreateAgentInteractionParamsResponseModality>
            >()
            {
                CreateAgentInteractionParamsResponseModality.Text,
            },
            Role = "role",
            ServiceTier = CreateAgentInteractionParamsServiceTier.Flex,
            Status = CreateAgentInteractionParamsStatus.InProgress,
            Store = true,
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
            Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                        Tokens = 0,
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
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalThoughtTokens = 0,
                TotalTokens = 0,
                TotalToolUseTokens = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Agent> expectedAgent = Agent.DeepResearchProPreview12_2025;
        CreateAgentInteractionParamsInput expectedInput = new(
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
        string expectedID = "id";
        AgentConfig expectedAgentConfig = new DynamicAgentConfig();
        bool expectedBackground = true;
        DateTimeOffset expectedCreated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Content> expectedOutputs = new List<Content>()
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
        };
        string expectedPreviousInteractionID = "previous_interaction_id";
        JsonElement expectedResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedResponseMimeType = "response_mime_type";
        List<
            ApiEnum<string, CreateAgentInteractionParamsResponseModality>
        > expectedResponseModalities = new List<
            ApiEnum<string, CreateAgentInteractionParamsResponseModality>
        >()
        {
            CreateAgentInteractionParamsResponseModality.Text,
        };
        string expectedRole = "role";
        ApiEnum<string, CreateAgentInteractionParamsServiceTier> expectedServiceTier =
            CreateAgentInteractionParamsServiceTier.Flex;
        ApiEnum<string, CreateAgentInteractionParamsStatus> expectedStatus =
            CreateAgentInteractionParamsStatus.InProgress;
        bool expectedStore = true;
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
        DateTimeOffset expectedUpdated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
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
                    Tokens = 0,
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
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            TotalThoughtTokens = 0,
            TotalTokens = 0,
            TotalToolUseTokens = 0,
        };

        Assert.Equal(expectedAgent, deserialized.Agent);
        Assert.Equal(expectedInput, deserialized.Input);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAgentConfig, deserialized.AgentConfig);
        Assert.Equal(expectedBackground, deserialized.Background);
        Assert.Equal(expectedCreated, deserialized.Created);
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
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedStore, deserialized.Store);
        Assert.Equal(expectedSystemInstruction, deserialized.SystemInstruction);
        Assert.NotNull(deserialized.Tools);
        Assert.Equal(expectedTools.Count, deserialized.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], deserialized.Tools[i]);
        }
        Assert.Equal(expectedUpdated, deserialized.Updated);
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreateAgentInteractionParams
        {
            Agent = Agent.DeepResearchProPreview12_2025,
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
            ID = "id",
            AgentConfig = new DynamicAgentConfig(),
            Background = true,
            Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Outputs = new List<Content>()
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
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<
                ApiEnum<string, CreateAgentInteractionParamsResponseModality>
            >()
            {
                CreateAgentInteractionParamsResponseModality.Text,
            },
            Role = "role",
            ServiceTier = CreateAgentInteractionParamsServiceTier.Flex,
            Status = CreateAgentInteractionParamsStatus.InProgress,
            Store = true,
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
            Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                        Tokens = 0,
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
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalThoughtTokens = 0,
                TotalTokens = 0,
                TotalToolUseTokens = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreateAgentInteractionParams
        {
            Agent = Agent.DeepResearchProPreview12_2025,
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
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AgentConfig);
        Assert.False(model.RawData.ContainsKey("agent_config"));
        Assert.Null(model.Background);
        Assert.False(model.RawData.ContainsKey("background"));
        Assert.Null(model.Created);
        Assert.False(model.RawData.ContainsKey("created"));
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
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Store);
        Assert.False(model.RawData.ContainsKey("store"));
        Assert.Null(model.SystemInstruction);
        Assert.False(model.RawData.ContainsKey("system_instruction"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreateAgentInteractionParams
        {
            Agent = Agent.DeepResearchProPreview12_2025,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreateAgentInteractionParams
        {
            Agent = Agent.DeepResearchProPreview12_2025,
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

            // Null should be interpreted as omitted for these properties
            ID = null,
            AgentConfig = null,
            Background = null,
            Created = null,
            Outputs = null,
            PreviousInteractionID = null,
            ResponseFormat = null,
            ResponseMimeType = null,
            ResponseModalities = null,
            Role = null,
            ServiceTier = null,
            Status = null,
            Store = null,
            SystemInstruction = null,
            Tools = null,
            Updated = null,
            Usage = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AgentConfig);
        Assert.False(model.RawData.ContainsKey("agent_config"));
        Assert.Null(model.Background);
        Assert.False(model.RawData.ContainsKey("background"));
        Assert.Null(model.Created);
        Assert.False(model.RawData.ContainsKey("created"));
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
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Store);
        Assert.False(model.RawData.ContainsKey("store"));
        Assert.Null(model.SystemInstruction);
        Assert.False(model.RawData.ContainsKey("system_instruction"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreateAgentInteractionParams
        {
            Agent = Agent.DeepResearchProPreview12_2025,
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

            // Null should be interpreted as omitted for these properties
            ID = null,
            AgentConfig = null,
            Background = null,
            Created = null,
            Outputs = null,
            PreviousInteractionID = null,
            ResponseFormat = null,
            ResponseMimeType = null,
            ResponseModalities = null,
            Role = null,
            ServiceTier = null,
            Status = null,
            Store = null,
            SystemInstruction = null,
            Tools = null,
            Updated = null,
            Usage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreateAgentInteractionParams
        {
            Agent = Agent.DeepResearchProPreview12_2025,
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
            ID = "id",
            AgentConfig = new DynamicAgentConfig(),
            Background = true,
            Created = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Outputs = new List<Content>()
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
            },
            PreviousInteractionID = "previous_interaction_id",
            ResponseFormat = JsonSerializer.Deserialize<JsonElement>("{}"),
            ResponseMimeType = "response_mime_type",
            ResponseModalities = new List<
                ApiEnum<string, CreateAgentInteractionParamsResponseModality>
            >()
            {
                CreateAgentInteractionParamsResponseModality.Text,
            },
            Role = "role",
            ServiceTier = CreateAgentInteractionParamsServiceTier.Flex,
            Status = CreateAgentInteractionParamsStatus.InProgress,
            Store = true,
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
            Updated = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
                        Tokens = 0,
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
                TotalInputTokens = 0,
                TotalOutputTokens = 0,
                TotalThoughtTokens = 0,
                TotalTokens = 0,
                TotalToolUseTokens = 0,
            },
        };

        CreateAgentInteractionParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentTest : TestBase
{
    [Theory]
    [InlineData(Agent.DeepResearchProPreview12_2025)]
    public void Validation_Works(Agent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Agent> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Agent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Agent.DeepResearchProPreview12_2025)]
    public void SerializationRoundtrip_Works(Agent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Agent> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Agent>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Agent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Agent>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CreateAgentInteractionParamsInputTest : TestBase
{
    [Fact]
    public void ContentListValidationWorks()
    {
        CreateAgentInteractionParamsInput value = new(
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
        CreateAgentInteractionParamsInput value = "string";
        value.Validate();
    }

    [Fact]
    public void TurnListValidationWorks()
    {
        CreateAgentInteractionParamsInput value = new(
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
        CreateAgentInteractionParamsInput value = new TextContent()
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
        CreateAgentInteractionParamsInput value = new ImageContent()
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
        CreateAgentInteractionParamsInput value = new AudioContent()
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
        CreateAgentInteractionParamsInput value = new DocumentContent()
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
        CreateAgentInteractionParamsInput value = new VideoContent()
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
        CreateAgentInteractionParamsInput value = new ThoughtContent()
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
        CreateAgentInteractionParamsInput value = new FunctionCallContent()
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
        CreateAgentInteractionParamsInput value = new CodeExecutionCallContent()
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
        CreateAgentInteractionParamsInput value = new UrlContextCallContent()
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
        CreateAgentInteractionParamsInput value = new McpServerToolCallContent()
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
        CreateAgentInteractionParamsInput value = new GoogleSearchCallContent()
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
        CreateAgentInteractionParamsInput value = new FileSearchCallContent()
        {
            ID = "id",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void GoogleMapsCallContentValidationWorks()
    {
        CreateAgentInteractionParamsInput value = new GoogleMapsCallContent()
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
        CreateAgentInteractionParamsInput value = new FunctionResultContent()
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
        CreateAgentInteractionParamsInput value = new CodeExecutionResultContent()
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
        CreateAgentInteractionParamsInput value = new UrlContextResultContent()
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
        CreateAgentInteractionParamsInput value = new GoogleSearchResultContent()
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
        CreateAgentInteractionParamsInput value = new McpServerToolResultContent()
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
        CreateAgentInteractionParamsInput value = new FileSearchResultContent()
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
        CreateAgentInteractionParamsInput value = new GoogleMapsResultContent()
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
        CreateAgentInteractionParamsInput value = new(
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
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TurnListSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new(
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
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new TextContent()
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
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new ImageContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageContentMimeType.ImagePng,
            Resolution = ImageContentResolution.Low,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AudioContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new AudioContent()
        {
            Channels = 0,
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = MimeType.AudioWav,
            Rate = 0,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DocumentContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new DocumentContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = DocumentContentMimeType.ApplicationPdf,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VideoContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new VideoContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = VideoContentMimeType.VideoMp4,
            Resolution = VideoContentResolution.Low,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThoughtContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new ThoughtContent()
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
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FunctionCallContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new FunctionCallContent()
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
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionCallContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new CodeExecutionCallContent()
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UrlContextCallContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new UrlContextCallContent()
        {
            ID = "id",
            Arguments = new() { Urls = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpServerToolCallContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new McpServerToolCallContent()
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
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleSearchCallContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new GoogleSearchCallContent()
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            SearchType = SearchType.WebSearch,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileSearchCallContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new FileSearchCallContent()
        {
            ID = "id",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleMapsCallContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new GoogleMapsCallContent()
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FunctionResultContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new FunctionResultContent()
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsError = true,
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionResultContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new CodeExecutionResultContent()
        {
            CallID = "call_id",
            Result = "result",
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UrlContextResultContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new UrlContextResultContent()
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
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleSearchResultContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new GoogleSearchResultContent()
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
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpServerToolResultContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new McpServerToolResultContent()
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileSearchResultContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new FileSearchResultContent()
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
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleMapsResultContentSerializationRoundtripWorks()
    {
        CreateAgentInteractionParamsInput value = new GoogleMapsResultContent()
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
        var deserialized = JsonSerializer.Deserialize<CreateAgentInteractionParamsInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AgentConfigTest : TestBase
{
    [Fact]
    public void DynamicValidationWorks()
    {
        AgentConfig value = new DynamicAgentConfig();
        value.Validate();
    }

    [Fact]
    public void DeepResearchValidationWorks()
    {
        AgentConfig value = new DeepResearchAgentConfig()
        {
            ThinkingSummaries = ThinkingSummaries.Auto,
        };
        value.Validate();
    }

    [Fact]
    public void DynamicSerializationRoundtripWorks()
    {
        AgentConfig value = new DynamicAgentConfig();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DeepResearchSerializationRoundtripWorks()
    {
        AgentConfig value = new DeepResearchAgentConfig()
        {
            ThinkingSummaries = ThinkingSummaries.Auto,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CreateAgentInteractionParamsResponseModalityTest : TestBase
{
    [Theory]
    [InlineData(CreateAgentInteractionParamsResponseModality.Text)]
    [InlineData(CreateAgentInteractionParamsResponseModality.Image)]
    [InlineData(CreateAgentInteractionParamsResponseModality.Audio)]
    [InlineData(CreateAgentInteractionParamsResponseModality.Video)]
    [InlineData(CreateAgentInteractionParamsResponseModality.Document)]
    public void Validation_Works(CreateAgentInteractionParamsResponseModality rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateAgentInteractionParamsResponseModality> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreateAgentInteractionParamsResponseModality>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreateAgentInteractionParamsResponseModality.Text)]
    [InlineData(CreateAgentInteractionParamsResponseModality.Image)]
    [InlineData(CreateAgentInteractionParamsResponseModality.Audio)]
    [InlineData(CreateAgentInteractionParamsResponseModality.Video)]
    [InlineData(CreateAgentInteractionParamsResponseModality.Document)]
    public void SerializationRoundtrip_Works(CreateAgentInteractionParamsResponseModality rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateAgentInteractionParamsResponseModality> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreateAgentInteractionParamsResponseModality>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreateAgentInteractionParamsResponseModality>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreateAgentInteractionParamsResponseModality>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreateAgentInteractionParamsServiceTierTest : TestBase
{
    [Theory]
    [InlineData(CreateAgentInteractionParamsServiceTier.Flex)]
    [InlineData(CreateAgentInteractionParamsServiceTier.Standard)]
    [InlineData(CreateAgentInteractionParamsServiceTier.Priority)]
    public void Validation_Works(CreateAgentInteractionParamsServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateAgentInteractionParamsServiceTier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreateAgentInteractionParamsServiceTier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreateAgentInteractionParamsServiceTier.Flex)]
    [InlineData(CreateAgentInteractionParamsServiceTier.Standard)]
    [InlineData(CreateAgentInteractionParamsServiceTier.Priority)]
    public void SerializationRoundtrip_Works(CreateAgentInteractionParamsServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateAgentInteractionParamsServiceTier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreateAgentInteractionParamsServiceTier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CreateAgentInteractionParamsServiceTier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreateAgentInteractionParamsServiceTier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CreateAgentInteractionParamsStatusTest : TestBase
{
    [Theory]
    [InlineData(CreateAgentInteractionParamsStatus.InProgress)]
    [InlineData(CreateAgentInteractionParamsStatus.RequiresAction)]
    [InlineData(CreateAgentInteractionParamsStatus.Completed)]
    [InlineData(CreateAgentInteractionParamsStatus.Failed)]
    [InlineData(CreateAgentInteractionParamsStatus.Cancelled)]
    [InlineData(CreateAgentInteractionParamsStatus.Incomplete)]
    public void Validation_Works(CreateAgentInteractionParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateAgentInteractionParamsStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateAgentInteractionParamsStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CreateAgentInteractionParamsStatus.InProgress)]
    [InlineData(CreateAgentInteractionParamsStatus.RequiresAction)]
    [InlineData(CreateAgentInteractionParamsStatus.Completed)]
    [InlineData(CreateAgentInteractionParamsStatus.Failed)]
    [InlineData(CreateAgentInteractionParamsStatus.Cancelled)]
    [InlineData(CreateAgentInteractionParamsStatus.Incomplete)]
    public void SerializationRoundtrip_Works(CreateAgentInteractionParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CreateAgentInteractionParamsStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreateAgentInteractionParamsStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CreateAgentInteractionParamsStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CreateAgentInteractionParamsStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
