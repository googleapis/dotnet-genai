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

// Auto-generated code. Do not edit.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Serialization;

namespace Google.GenAI.Types {
  /// <summary>
  /// Configuration for generating videos.
  /// </summary>

  public record GenerateVideosConfig {
    /// <summary>
    /// Used to override HTTP request options.
    /// </summary>
    [JsonPropertyName("httpOptions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HttpOptions ? HttpOptions { get; set; }

    /// <summary>
    /// Number of output videos.
    /// </summary>
    [JsonPropertyName("numberOfVideos")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? NumberOfVideos {
            get; set;
          }

    /// <summary>
    /// The gcs bucket where to save the generated videos.
    /// </summary>
    [JsonPropertyName("outputGcsUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? OutputGcsUri {
            get; set;
          }

    /// <summary>
    /// Frames per second for video generation.
    /// </summary>
    [JsonPropertyName("fps")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? Fps {
            get; set;
          }

    /// <summary>
    /// Duration of the clip for video generation in seconds.
    /// </summary>
    [JsonPropertyName("durationSeconds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? DurationSeconds {
            get; set;
          }

    /// <summary>
    /// The RNG seed. If RNG seed is exactly same for each request with unchanged inputs, the
    /// prediction results will be consistent. Otherwise, a random RNG seed will be used each time
    /// to produce a different result.
    /// </summary>
    [JsonPropertyName("seed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? Seed {
            get; set;
          }

    /// <summary>
    /// The aspect ratio for the generated video. 16:9 (landscape) and 9:16 (portrait) are
    /// supported.
    /// </summary>
    [JsonPropertyName("aspectRatio")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? AspectRatio {
            get; set;
          }

    /// <summary>
    /// The resolution for the generated video. 720p and 1080p are supported.
    /// </summary>
    [JsonPropertyName("resolution")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Resolution {
            get; set;
          }

    /// <summary>
    /// Whether allow to generate person videos, and restrict to specific ages. Supported values
    /// are: dont_allow, allow_adult.
    /// </summary>
    [JsonPropertyName("personGeneration")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? PersonGeneration {
            get; set;
          }

    /// <summary>
    /// The pubsub topic where to publish the video generation progress.
    /// </summary>
    [JsonPropertyName("pubsubTopic")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? PubsubTopic {
            get; set;
          }

    /// <summary>
    /// Explicitly state what should not be included in the generated videos.
    /// </summary>
    [JsonPropertyName("negativePrompt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? NegativePrompt {
            get; set;
          }

    /// <summary>
    /// Whether to use the prompt rewriting logic.
    /// </summary>
    [JsonPropertyName("enhancePrompt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? EnhancePrompt {
            get; set;
          }

    /// <summary>
    /// Whether to generate audio along with the video.
    /// </summary>
    [JsonPropertyName("generateAudio")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? GenerateAudio {
            get; set;
          }

    /// <summary>
    /// Image to use as the last frame of generated videos. Only supported for image to video use
    /// cases.
    /// </summary>
    [JsonPropertyName("lastFrame")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Image
        ? LastFrame {
            get; set;
          }

    /// <summary>
    /// The images to use as the references to generate the videos. If this field is provided, the
    /// text prompt field must also be provided. The image, video, or last_frame field are not
    /// supported. Each image must be associated with a type. Veo 2 supports up to 3 asset images
    /// *or* 1 style image.
    /// </summary>
    [JsonPropertyName("referenceImages")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<VideoGenerationReferenceImage>
        ? ReferenceImages {
            get; set;
          }

    /// <summary>
    /// The mask to use for generating videos.
    /// </summary>
    [JsonPropertyName("mask")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VideoGenerationMask
        ? Mask {
            get; set;
          }

    /// <summary>
    /// Compression quality of the generated videos.
    /// </summary>
    [JsonPropertyName("compressionQuality")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VideoCompressionQuality
        ? CompressionQuality {
            get; set;
          }

    /// <summary>
    /// User specified labels to track billing usage.
    /// </summary>
    [JsonPropertyName("labels")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>
        ? Labels {
            get; set;
          }

    /// <summary>
    /// Webhook configuration for receiving notifications when the video generation operation
    /// completes.
    /// </summary>
    [JsonPropertyName("webhookConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public WebhookConfig
        ? WebhookConfig {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GenerateVideosConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GenerateVideosConfig object, or null if deserialization
    /// fails.</returns>
    public static GenerateVideosConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GenerateVideosConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
