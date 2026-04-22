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
using System.Threading.Tasks;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Models.Interactions;

namespace Google.GenAI.Interactions.Tests.Services;

public class InteractionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var interaction = await this.client.Interactions.Create(
            new()
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
            },
            TestContext.Current.CancellationToken
        );
        interaction.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CreateStreaming_Works()
    {
        var stream = this.client.Interactions.CreateStreaming(
            new()
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
            },
            TestContext.Current.CancellationToken
        );

        await foreach (var interaction in stream)
        {
            interaction.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Interactions.Delete(
            "id",
            new() { ApiVersion = "api_version" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Cancel_Works()
    {
        var interaction = await this.client.Interactions.Cancel(
            "id",
            new() { ApiVersion = "api_version" },
            TestContext.Current.CancellationToken
        );
        interaction.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var interaction = await this.client.Interactions.Get(
            "id",
            new() { ApiVersion = "api_version" },
            TestContext.Current.CancellationToken
        );
        interaction.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetStreaming_Works()
    {
        var stream = this.client.Interactions.GetStreaming(
            "id",
            new() { ApiVersion = "api_version" },
            TestContext.Current.CancellationToken
        );

        await foreach (var interaction in stream)
        {
            interaction.Validate();
        }
    }
}
