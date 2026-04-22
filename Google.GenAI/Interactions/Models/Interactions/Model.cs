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
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// The model that will complete your prompt.\n\nSee [models](https://ai.google.dev/gemini-api/docs/models)
/// for additional details.
/// </summary>
[JsonConverter(typeof(ModelConverter))]
public enum Model
{
    /// <summary>
    /// An agentic capability model designed for direct interface interaction, allowing
    /// Gemini to perceive and navigate digital environments.
    /// </summary>
    Gemini2_5ComputerUsePreview10_2025,

    /// <summary>
    /// Our first hybrid reasoning model which supports a 1M token context window
    /// and has thinking budgets.
    /// </summary>
    Gemini2_5Flash,

    /// <summary>
    /// Our native image generation model, optimized for speed, flexibility, and
    /// contextual understanding. Text input and output is priced the same as 2.5 Flash.
    /// </summary>
    Gemini2_5FlashImage,

    /// <summary>
    /// Our smallest and most cost effective model, built for at scale usage.
    /// </summary>
    Gemini2_5FlashLite,

    /// <summary>
    /// The latest model based on Gemini 2.5 Flash lite optimized for cost-efficiency,
    /// high throughput and high quality.
    /// </summary>
    Gemini2_5FlashLitePreview09_2025,

    /// <summary>
    /// Our native audio models optimized for higher quality audio outputs with better
    /// pacing, voice naturalness, verbosity, and mood.
    /// </summary>
    Gemini2_5FlashNativeAudioPreview12_2025,

    /// <summary>
    /// The latest model based on the 2.5 Flash model. 2.5 Flash Preview is best
    /// for large scale processing, low-latency, high volume tasks that require thinking,
    /// and agentic use cases.
    /// </summary>
    Gemini2_5FlashPreview09_2025,

    /// <summary>
    /// Our 2.5 Flash text-to-speech model optimized for powerful, low-latency controllable
    /// speech generation.
    /// </summary>
    Gemini2_5FlashPreviewTts,

    /// <summary>
    /// Our state-of-the-art multipurpose model, which excels at coding and complex
    /// reasoning tasks.
    /// </summary>
    Gemini2_5Pro,

    /// <summary>
    /// Our 2.5 Pro text-to-speech audio model optimized for powerful, low-latency
    /// speech generation for more natural outputs and easier to steer prompts.
    /// </summary>
    Gemini2_5ProPreviewTts,

    /// <summary>
    /// Our most intelligent model built for speed, combining frontier intelligence
    /// with superior search and grounding.
    /// </summary>
    Gemini3FlashPreview,

    /// <summary>
    /// State-of-the-art image generation and editing model.
    /// </summary>
    Gemini3ProImagePreview,

    /// <summary>
    /// Our most intelligent model with SOTA reasoning and multimodal understanding,
    /// and powerful agentic and vibe coding capabilities.
    /// </summary>
    Gemini3ProPreview,

    /// <summary>
    /// Our latest SOTA reasoning model with unprecedented depth and nuance, and powerful
    /// multimodal understanding and coding capabilities.
    /// </summary>
    Gemini3_1ProPreview,

    /// <summary>
    /// Pro-level visual intelligence with Flash-speed efficiency and reality-grounded
    /// generation capabilities.
    /// </summary>
    Gemini3_1FlashImagePreview,

    /// <summary>
    /// Our most cost-efficient model, optimized for high-volume agentic tasks, translation,
    /// and simple data processing.
    /// </summary>
    Gemini3_1FlashLitePreview,

    /// <summary>
    /// Gemini 3.1 Flash TTS: Powerful, low-latency speech generation. Enjoy natural
    /// outputs, steerable prompts, and new expressive audio tags for precise narration control.
    /// </summary>
    Gemini3_1FlashTtsPreview,

    /// <summary>
    /// Our low-latency, music generation model optimized for high-fidelity audio
    /// clips and precise rhythmic control.
    /// </summary>
    Lyria3ClipPreview,

    /// <summary>
    /// Our advanced, full-song generative model with deep compositional understanding,
    /// optimized for precise structural control and complex transitions across diverse
    /// musical styles.
    /// </summary>
    Lyria3ProPreview,
}

sealed class ModelConverter : JsonConverter<Model>
{
    public override Model Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "gemini-2.5-computer-use-preview-10-2025" => Model.Gemini2_5ComputerUsePreview10_2025,
            "gemini-2.5-flash" => Model.Gemini2_5Flash,
            "gemini-2.5-flash-image" => Model.Gemini2_5FlashImage,
            "gemini-2.5-flash-lite" => Model.Gemini2_5FlashLite,
            "gemini-2.5-flash-lite-preview-09-2025" => Model.Gemini2_5FlashLitePreview09_2025,
            "gemini-2.5-flash-native-audio-preview-12-2025" =>
                Model.Gemini2_5FlashNativeAudioPreview12_2025,
            "gemini-2.5-flash-preview-09-2025" => Model.Gemini2_5FlashPreview09_2025,
            "gemini-2.5-flash-preview-tts" => Model.Gemini2_5FlashPreviewTts,
            "gemini-2.5-pro" => Model.Gemini2_5Pro,
            "gemini-2.5-pro-preview-tts" => Model.Gemini2_5ProPreviewTts,
            "gemini-3-flash-preview" => Model.Gemini3FlashPreview,
            "gemini-3-pro-image-preview" => Model.Gemini3ProImagePreview,
            "gemini-3-pro-preview" => Model.Gemini3ProPreview,
            "gemini-3.1-pro-preview" => Model.Gemini3_1ProPreview,
            "gemini-3.1-flash-image-preview" => Model.Gemini3_1FlashImagePreview,
            "gemini-3.1-flash-lite-preview" => Model.Gemini3_1FlashLitePreview,
            "gemini-3.1-flash-tts-preview" => Model.Gemini3_1FlashTtsPreview,
            "lyria-3-clip-preview" => Model.Lyria3ClipPreview,
            "lyria-3-pro-preview" => Model.Lyria3ProPreview,
            _ => (Model)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Model value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Model.Gemini2_5ComputerUsePreview10_2025 =>
                    "gemini-2.5-computer-use-preview-10-2025",
                Model.Gemini2_5Flash => "gemini-2.5-flash",
                Model.Gemini2_5FlashImage => "gemini-2.5-flash-image",
                Model.Gemini2_5FlashLite => "gemini-2.5-flash-lite",
                Model.Gemini2_5FlashLitePreview09_2025 => "gemini-2.5-flash-lite-preview-09-2025",
                Model.Gemini2_5FlashNativeAudioPreview12_2025 =>
                    "gemini-2.5-flash-native-audio-preview-12-2025",
                Model.Gemini2_5FlashPreview09_2025 => "gemini-2.5-flash-preview-09-2025",
                Model.Gemini2_5FlashPreviewTts => "gemini-2.5-flash-preview-tts",
                Model.Gemini2_5Pro => "gemini-2.5-pro",
                Model.Gemini2_5ProPreviewTts => "gemini-2.5-pro-preview-tts",
                Model.Gemini3FlashPreview => "gemini-3-flash-preview",
                Model.Gemini3ProImagePreview => "gemini-3-pro-image-preview",
                Model.Gemini3ProPreview => "gemini-3-pro-preview",
                Model.Gemini3_1ProPreview => "gemini-3.1-pro-preview",
                Model.Gemini3_1FlashImagePreview => "gemini-3.1-flash-image-preview",
                Model.Gemini3_1FlashLitePreview => "gemini-3.1-flash-lite-preview",
                Model.Gemini3_1FlashTtsPreview => "gemini-3.1-flash-tts-preview",
                Model.Lyria3ClipPreview => "lyria-3-clip-preview",
                Model.Lyria3ProPreview => "lyria-3-pro-preview",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
