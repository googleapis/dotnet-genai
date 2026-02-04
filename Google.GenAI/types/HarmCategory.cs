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

using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Text.Json;

namespace Google.GenAI.Types {
  /// <summary>
  /// The harm category to be blocked.
  /// </summary>

  [JsonConverter(typeof(HarmCategoryConverter))]
  public readonly record struct HarmCategory : IEquatable<HarmCategory> {
    public string Value { get; }

    private HarmCategory(string value) {
      Value = value;
    }

    /// <summary>
    /// Default value. This value is unused.
    /// </summary>
    public static HarmCategory HarmCategoryUnspecified { get; } = new("HARM_CATEGORY_UNSPECIFIED");

    /// <summary>
    /// Abusive, threatening, or content intended to bully, torment, or ridicule.
    /// </summary>
    public static HarmCategory HarmCategoryHarassment { get; } = new("HARM_CATEGORY_HARASSMENT");

    /// <summary>
    /// Content that promotes violence or incites hatred against individuals or groups based on
    /// certain attributes.
    /// </summary>
    public static HarmCategory HarmCategoryHateSpeech { get; } = new("HARM_CATEGORY_HATE_SPEECH");

    /// <summary>
    /// Content that contains sexually explicit material.
    /// </summary>
    public static HarmCategory HarmCategorySexuallyExplicit {
      get;
    } = new("HARM_CATEGORY_SEXUALLY_EXPLICIT");

    /// <summary>
    /// Content that promotes, facilitates, or enables dangerous activities.
    /// </summary>
    public static HarmCategory HarmCategoryDangerousContent {
      get;
    } = new("HARM_CATEGORY_DANGEROUS_CONTENT");

    /// <summary>
    /// Deprecated: Election filter is not longer supported. The harm category is civic integrity.
    /// </summary>
    public static HarmCategory HarmCategoryCivicIntegrity {
      get;
    } = new("HARM_CATEGORY_CIVIC_INTEGRITY");

    /// <summary>
    /// Images that contain hate speech. This enum value is not supported in Gemini API.
    /// </summary>
    public static HarmCategory HarmCategoryImageHate { get; } = new("HARM_CATEGORY_IMAGE_HATE");

    /// <summary>
    /// Images that contain dangerous content. This enum value is not supported in Gemini API.
    /// </summary>
    public static HarmCategory HarmCategoryImageDangerousContent {
      get;
    } = new("HARM_CATEGORY_IMAGE_DANGEROUS_CONTENT");

    /// <summary>
    /// Images that contain harassment. This enum value is not supported in Gemini API.
    /// </summary>
    public static HarmCategory HarmCategoryImageHarassment {
      get;
    } = new("HARM_CATEGORY_IMAGE_HARASSMENT");

    /// <summary>
    /// Images that contain sexually explicit content. This enum value is not supported in Gemini
    /// API.
    /// </summary>
    public static HarmCategory HarmCategoryImageSexuallyExplicit {
      get;
    } = new("HARM_CATEGORY_IMAGE_SEXUALLY_EXPLICIT");

    /// <summary>
    /// Prompts designed to bypass safety filters. This enum value is not supported in Gemini API.
    /// </summary>
    public static HarmCategory HarmCategoryJailbreak { get; } = new("HARM_CATEGORY_JAILBREAK");

    public static IReadOnlyList<HarmCategory> AllValues {
      get;
    } = new[] { HarmCategoryUnspecified,      HarmCategoryHarassment,
                HarmCategoryHateSpeech,       HarmCategorySexuallyExplicit,
                HarmCategoryDangerousContent, HarmCategoryCivicIntegrity,
                HarmCategoryImageHate,        HarmCategoryImageDangerousContent,
                HarmCategoryImageHarassment,  HarmCategoryImageSexuallyExplicit,
                HarmCategoryJailbreak };

    public static HarmCategory FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new HarmCategory("HARM_CATEGORY_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new HarmCategory(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator HarmCategory(string value) => FromString(value);

    public bool Equals(HarmCategory other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class HarmCategoryConverter : JsonConverter<HarmCategory> {
    public override HarmCategory Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                      JsonSerializerOptions options) {
      var value = reader.GetString();
      return HarmCategory.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, HarmCategory value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
