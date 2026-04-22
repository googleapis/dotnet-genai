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

using System.Text.Json;
using Google.GenAI.Interactions.Exceptions;
using Google.GenAI.Interactions.Models.Interactions;
using Interactions = Google.GenAI.Interactions.Models.Interactions;

namespace Google.GenAI.Interactions.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, MimeType>(),
            new ApiEnumConverter<string, Language>(),
            new ApiEnumConverter<string, ImageMimeType>(),
            new ApiEnumConverter<string, Resolution>(),
            new ApiEnumConverter<string, AudioMimeType>(),
            new ApiEnumConverter<string, DocumentMimeType>(),
            new ApiEnumConverter<string, VideoMimeType>(),
            new ApiEnumConverter<string, VideoResolution>(),
            new ApiEnumConverter<string, ThinkingSummaries>(),
            new ApiEnumConverter<string, Visualization>(),
            new ApiEnumConverter<string, DocumentContentMimeType>(),
            new ApiEnumConverter<string, GenerationConfigThinkingSummaries>(),
            new ApiEnumConverter<string, SearchType>(),
            new ApiEnumConverter<string, AspectRatio>(),
            new ApiEnumConverter<string, ImageSize>(),
            new ApiEnumConverter<string, ImageContentMimeType>(),
            new ApiEnumConverter<string, ImageContentResolution>(),
            new ApiEnumConverter<string, InteractionStatus>(),
            new ApiEnumConverter<string, InteractionAgent>(),
            new ApiEnumConverter<string, InteractionResponseModality>(),
            new ApiEnumConverter<string, InteractionServiceTier>(),
            new ApiEnumConverter<string, InteractionStatusUpdateStatus>(),
            new ApiEnumConverter<string, Model>(),
            new ApiEnumConverter<string, ThinkingLevel>(),
            new ApiEnumConverter<string, GoogleSearchSearchType>(),
            new ApiEnumConverter<string, RetrievalType>(),
            new ApiEnumConverter<string, Interactions::Environment>(),
            new ApiEnumConverter<string, ToolChoiceType>(),
            new ApiEnumConverter<string, InteractionUrlContextResultStatus>(),
            new ApiEnumConverter<string, Modality>(),
            new ApiEnumConverter<string, InputTokensByModalityModality>(),
            new ApiEnumConverter<string, OutputTokensByModalityModality>(),
            new ApiEnumConverter<string, ToolUseTokensByModalityModality>(),
            new ApiEnumConverter<string, VideoContentMimeType>(),
            new ApiEnumConverter<string, VideoContentResolution>(),
            new ApiEnumConverter<string, ResponseModality>(),
            new ApiEnumConverter<string, ServiceTier>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Agent>(),
            new ApiEnumConverter<string, CreateAgentInteractionParamsResponseModality>(),
            new ApiEnumConverter<string, CreateAgentInteractionParamsServiceTier>(),
            new ApiEnumConverter<string, CreateAgentInteractionParamsStatus>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="GeminiNextGenApiInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
