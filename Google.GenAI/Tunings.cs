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
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

using Google.GenAI.Types;

namespace Google.GenAI {

  public sealed class Tunings {
    private readonly ApiClient _apiClient;

    internal JsonNode CancelTuningJobParametersToMldev(JsonNode fromObject, JsonObject parentObject,
                                                       JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "_url", "name" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      return toObject;
    }

    internal JsonNode CancelTuningJobParametersToVertex(JsonNode fromObject,
                                                        JsonObject parentObject,
                                                        JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "_url", "name" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      return toObject;
    }

    internal JsonNode CancelTuningJobResponseFromMldev(JsonNode fromObject, JsonObject parentObject,
                                                       JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      return toObject;
    }

    internal JsonNode CancelTuningJobResponseFromVertex(JsonNode fromObject,
                                                        JsonObject parentObject,
                                                        JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      return toObject;
    }

    internal JsonNode CreateTuningJobConfigToMldev(JsonNode fromObject, JsonObject parentObject,
                                                   JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "validationDataset" }))) {
        throw new NotSupportedException(
            "validationDataset parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tunedModelDisplayName" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "displayName" },
            Common.GetValueByPath(fromObject, new string[] { "tunedModelDisplayName" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "description" }))) {
        throw new NotSupportedException("description parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "epochCount" }) != null) {
        Common.SetValueByPath(parentObject,
                              new string[] { "tuningTask", "hyperparameters", "epochCount" },
                              Common.GetValueByPath(fromObject, new string[] { "epochCount" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "learningRateMultiplier" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "tuningTask", "hyperparameters", "learningRateMultiplier" },
            Common.GetValueByPath(fromObject, new string[] { "learningRateMultiplier" }));
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "exportLastCheckpointOnly" }))) {
        throw new NotSupportedException(
            "exportLastCheckpointOnly parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "preTunedModelCheckpointId" }))) {
        throw new NotSupportedException(
            "preTunedModelCheckpointId parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "adapterSize" }))) {
        throw new NotSupportedException("adapterSize parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "tuningMode" }))) {
        throw new NotSupportedException("tuningMode parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "customBaseModel" }))) {
        throw new NotSupportedException(
            "customBaseModel parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "batchSize" }) != null) {
        Common.SetValueByPath(parentObject,
                              new string[] { "tuningTask", "hyperparameters", "batchSize" },
                              Common.GetValueByPath(fromObject, new string[] { "batchSize" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "learningRate" }) != null) {
        Common.SetValueByPath(parentObject,
                              new string[] { "tuningTask", "hyperparameters", "learningRate" },
                              Common.GetValueByPath(fromObject, new string[] { "learningRate" }));
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "labels" }))) {
        throw new NotSupportedException("labels parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "beta" }))) {
        throw new NotSupportedException("beta parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "baseTeacherModel" }))) {
        throw new NotSupportedException(
            "baseTeacherModel parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "tunedTeacherModelSource" }))) {
        throw new NotSupportedException(
            "tunedTeacherModelSource parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "sftLossWeightMultiplier" }))) {
        throw new NotSupportedException(
            "sftLossWeightMultiplier parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "outputUri" }))) {
        throw new NotSupportedException("outputUri parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "encryptionSpec" }))) {
        throw new NotSupportedException("encryptionSpec parameter is not supported in Gemini API.");
      }

      return toObject;
    }

    internal JsonNode CreateTuningJobConfigToVertex(JsonNode fromObject, JsonObject parentObject,
                                                    JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      JsonNode discriminatorValidationDataset =
          Common.GetValueByPath(rootObject, new string[] { "config", "method" });
      string discriminatorValueValidationDataset =
          discriminatorValidationDataset == null
              ? "SUPERVISED_FINE_TUNING"
              : discriminatorValidationDataset.GetValue<string>();
      if (discriminatorValueValidationDataset == "SUPERVISED_FINE_TUNING") {
        if (Common.GetValueByPath(fromObject, new string[] { "validationDataset" }) != null) {
          Common.SetValueByPath(parentObject, new string[] { "supervisedTuningSpec" },
                                TuningValidationDatasetToVertex(
                                    Common.ParseToJsonNode(Common.GetValueByPath(
                                        fromObject, new string[] { "validationDataset" })),
                                    toObject, rootObject));
        }
      } else if (discriminatorValueValidationDataset == "PREFERENCE_TUNING") {
        if (Common.GetValueByPath(fromObject, new string[] { "validationDataset" }) != null) {
          Common.SetValueByPath(parentObject, new string[] { "preferenceOptimizationSpec" },
                                TuningValidationDatasetToVertex(
                                    Common.ParseToJsonNode(Common.GetValueByPath(
                                        fromObject, new string[] { "validationDataset" })),
                                    toObject, rootObject));
        }
      } else if (discriminatorValueValidationDataset == "DISTILLATION") {
        if (Common.GetValueByPath(fromObject, new string[] { "validationDataset" }) != null) {
          Common.SetValueByPath(parentObject, new string[] { "distillationSpec" },
                                TuningValidationDatasetToVertex(
                                    Common.ParseToJsonNode(Common.GetValueByPath(
                                        fromObject, new string[] { "validationDataset" })),
                                    toObject, rootObject));
        }
      }
      if (Common.GetValueByPath(fromObject, new string[] { "tunedModelDisplayName" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "tunedModelDisplayName" },
            Common.GetValueByPath(fromObject, new string[] { "tunedModelDisplayName" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "description" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "description" },
                              Common.GetValueByPath(fromObject, new string[] { "description" }));
      }

      JsonNode discriminatorEpochCount =
          Common.GetValueByPath(rootObject, new string[] { "config", "method" });
      string discriminatorValueEpochCount = discriminatorEpochCount == null
                                                ? "SUPERVISED_FINE_TUNING"
                                                : discriminatorEpochCount.GetValue<string>();
      if (discriminatorValueEpochCount == "SUPERVISED_FINE_TUNING") {
        if (Common.GetValueByPath(fromObject, new string[] { "epochCount" }) != null) {
          Common.SetValueByPath(
              parentObject,
              new string[] { "supervisedTuningSpec", "hyperParameters", "epochCount" },
              Common.GetValueByPath(fromObject, new string[] { "epochCount" }));
        }
      } else if (discriminatorValueEpochCount == "PREFERENCE_TUNING") {
        if (Common.GetValueByPath(fromObject, new string[] { "epochCount" }) != null) {
          Common.SetValueByPath(
              parentObject,
              new string[] { "preferenceOptimizationSpec", "hyperParameters", "epochCount" },
              Common.GetValueByPath(fromObject, new string[] { "epochCount" }));
        }
      } else if (discriminatorValueEpochCount == "DISTILLATION") {
        if (Common.GetValueByPath(fromObject, new string[] { "epochCount" }) != null) {
          Common.SetValueByPath(
              parentObject, new string[] { "distillationSpec", "hyperParameters", "epochCount" },
              Common.GetValueByPath(fromObject, new string[] { "epochCount" }));
        }
      }

      JsonNode discriminatorLearningRateMultiplier =
          Common.GetValueByPath(rootObject, new string[] { "config", "method" });
      string discriminatorValueLearningRateMultiplier =
          discriminatorLearningRateMultiplier == null
              ? "SUPERVISED_FINE_TUNING"
              : discriminatorLearningRateMultiplier.GetValue<string>();
      if (discriminatorValueLearningRateMultiplier == "SUPERVISED_FINE_TUNING") {
        if (Common.GetValueByPath(fromObject, new string[] { "learningRateMultiplier" }) != null) {
          Common.SetValueByPath(
              parentObject,
              new string[] { "supervisedTuningSpec", "hyperParameters", "learningRateMultiplier" },
              Common.GetValueByPath(fromObject, new string[] { "learningRateMultiplier" }));
        }
      } else if (discriminatorValueLearningRateMultiplier == "PREFERENCE_TUNING") {
        if (Common.GetValueByPath(fromObject, new string[] { "learningRateMultiplier" }) != null) {
          Common.SetValueByPath(
              parentObject,
              new string[] { "preferenceOptimizationSpec", "hyperParameters",
                             "learningRateMultiplier" },
              Common.GetValueByPath(fromObject, new string[] { "learningRateMultiplier" }));
        }
      } else if (discriminatorValueLearningRateMultiplier == "DISTILLATION") {
        if (Common.GetValueByPath(fromObject, new string[] { "learningRateMultiplier" }) != null) {
          Common.SetValueByPath(
              parentObject,
              new string[] { "distillationSpec", "hyperParameters", "learningRateMultiplier" },
              Common.GetValueByPath(fromObject, new string[] { "learningRateMultiplier" }));
        }
      }

      JsonNode discriminatorExportLastCheckpointOnly =
          Common.GetValueByPath(rootObject, new string[] { "config", "method" });
      string discriminatorValueExportLastCheckpointOnly =
          discriminatorExportLastCheckpointOnly == null
              ? "SUPERVISED_FINE_TUNING"
              : discriminatorExportLastCheckpointOnly.GetValue<string>();
      if (discriminatorValueExportLastCheckpointOnly == "SUPERVISED_FINE_TUNING") {
        if (Common.GetValueByPath(fromObject, new string[] { "exportLastCheckpointOnly" }) !=
            null) {
          Common.SetValueByPath(
              parentObject, new string[] { "supervisedTuningSpec", "exportLastCheckpointOnly" },
              Common.GetValueByPath(fromObject, new string[] { "exportLastCheckpointOnly" }));
        }
      } else if (discriminatorValueExportLastCheckpointOnly == "PREFERENCE_TUNING") {
        if (Common.GetValueByPath(fromObject, new string[] { "exportLastCheckpointOnly" }) !=
            null) {
          Common.SetValueByPath(
              parentObject,
              new string[] { "preferenceOptimizationSpec", "exportLastCheckpointOnly" },
              Common.GetValueByPath(fromObject, new string[] { "exportLastCheckpointOnly" }));
        }
      } else if (discriminatorValueExportLastCheckpointOnly == "DISTILLATION") {
        if (Common.GetValueByPath(fromObject, new string[] { "exportLastCheckpointOnly" }) !=
            null) {
          Common.SetValueByPath(
              parentObject, new string[] { "distillationSpec", "exportLastCheckpointOnly" },
              Common.GetValueByPath(fromObject, new string[] { "exportLastCheckpointOnly" }));
        }
      }

      JsonNode discriminatorAdapterSize =
          Common.GetValueByPath(rootObject, new string[] { "config", "method" });
      string discriminatorValueAdapterSize = discriminatorAdapterSize == null
                                                 ? "SUPERVISED_FINE_TUNING"
                                                 : discriminatorAdapterSize.GetValue<string>();
      if (discriminatorValueAdapterSize == "SUPERVISED_FINE_TUNING") {
        if (Common.GetValueByPath(fromObject, new string[] { "adapterSize" }) != null) {
          Common.SetValueByPath(
              parentObject,
              new string[] { "supervisedTuningSpec", "hyperParameters", "adapterSize" },
              Common.GetValueByPath(fromObject, new string[] { "adapterSize" }));
        }
      } else if (discriminatorValueAdapterSize == "PREFERENCE_TUNING") {
        if (Common.GetValueByPath(fromObject, new string[] { "adapterSize" }) != null) {
          Common.SetValueByPath(
              parentObject,
              new string[] { "preferenceOptimizationSpec", "hyperParameters", "adapterSize" },
              Common.GetValueByPath(fromObject, new string[] { "adapterSize" }));
        }
      } else if (discriminatorValueAdapterSize == "DISTILLATION") {
        if (Common.GetValueByPath(fromObject, new string[] { "adapterSize" }) != null) {
          Common.SetValueByPath(
              parentObject, new string[] { "distillationSpec", "hyperParameters", "adapterSize" },
              Common.GetValueByPath(fromObject, new string[] { "adapterSize" }));
        }
      }

      JsonNode discriminatorTuningMode =
          Common.GetValueByPath(rootObject, new string[] { "config", "method" });
      string discriminatorValueTuningMode = discriminatorTuningMode == null
                                                ? "SUPERVISED_FINE_TUNING"
                                                : discriminatorTuningMode.GetValue<string>();
      if (discriminatorValueTuningMode == "SUPERVISED_FINE_TUNING") {
        if (Common.GetValueByPath(fromObject, new string[] { "tuningMode" }) != null) {
          Common.SetValueByPath(parentObject, new string[] { "supervisedTuningSpec", "tuningMode" },
                                Common.GetValueByPath(fromObject, new string[] { "tuningMode" }));
        }
      } else if (discriminatorValueTuningMode == "DISTILLATION") {
        if (Common.GetValueByPath(fromObject, new string[] { "tuningMode" }) != null) {
          Common.SetValueByPath(parentObject, new string[] { "distillationSpec", "tuningMode" },
                                Common.GetValueByPath(fromObject, new string[] { "tuningMode" }));
        }
      }
      if (Common.GetValueByPath(fromObject, new string[] { "customBaseModel" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "customBaseModel" },
            Common.GetValueByPath(fromObject, new string[] { "customBaseModel" }));
      }

      JsonNode discriminatorBatchSize =
          Common.GetValueByPath(rootObject, new string[] { "config", "method" });
      string discriminatorValueBatchSize = discriminatorBatchSize == null
                                               ? "SUPERVISED_FINE_TUNING"
                                               : discriminatorBatchSize.GetValue<string>();
      if (discriminatorValueBatchSize == "SUPERVISED_FINE_TUNING") {
        if (Common.GetValueByPath(fromObject, new string[] { "batchSize" }) != null) {
          Common.SetValueByPath(
              parentObject, new string[] { "supervisedTuningSpec", "hyperParameters", "batchSize" },
              Common.GetValueByPath(fromObject, new string[] { "batchSize" }));
        }
      } else if (discriminatorValueBatchSize == "DISTILLATION") {
        if (Common.GetValueByPath(fromObject, new string[] { "batchSize" }) != null) {
          Common.SetValueByPath(parentObject,
                                new string[] { "distillationSpec", "hyperParameters", "batchSize" },
                                Common.GetValueByPath(fromObject, new string[] { "batchSize" }));
        }
      }

      JsonNode discriminatorLearningRate =
          Common.GetValueByPath(rootObject, new string[] { "config", "method" });
      string discriminatorValueLearningRate = discriminatorLearningRate == null
                                                  ? "SUPERVISED_FINE_TUNING"
                                                  : discriminatorLearningRate.GetValue<string>();
      if (discriminatorValueLearningRate == "SUPERVISED_FINE_TUNING") {
        if (Common.GetValueByPath(fromObject, new string[] { "learningRate" }) != null) {
          Common.SetValueByPath(
              parentObject,
              new string[] { "supervisedTuningSpec", "hyperParameters", "learningRate" },
              Common.GetValueByPath(fromObject, new string[] { "learningRate" }));
        }
      } else if (discriminatorValueLearningRate == "DISTILLATION") {
        if (Common.GetValueByPath(fromObject, new string[] { "learningRate" }) != null) {
          Common.SetValueByPath(
              parentObject, new string[] { "distillationSpec", "hyperParameters", "learningRate" },
              Common.GetValueByPath(fromObject, new string[] { "learningRate" }));
        }
      }

      if (Common.GetValueByPath(fromObject, new string[] { "labels" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "labels" },
                              Common.GetValueByPath(fromObject, new string[] { "labels" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "beta" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "preferenceOptimizationSpec", "hyperParameters", "beta" },
            Common.GetValueByPath(fromObject, new string[] { "beta" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "baseTeacherModel" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "distillationSpec", "baseTeacherModel" },
            Common.GetValueByPath(fromObject, new string[] { "baseTeacherModel" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tunedTeacherModelSource" }) != null) {
        Common.SetValueByPath(
            parentObject, new string[] { "distillationSpec", "tunedTeacherModelSource" },
            Common.GetValueByPath(fromObject, new string[] { "tunedTeacherModelSource" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "sftLossWeightMultiplier" }) != null) {
        Common.SetValueByPath(
            parentObject,
            new string[] { "distillationSpec", "hyperParameters", "sftLossWeightMultiplier" },
            Common.GetValueByPath(fromObject, new string[] { "sftLossWeightMultiplier" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputUri" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "outputUri" },
                              Common.GetValueByPath(fromObject, new string[] { "outputUri" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "encryptionSpec" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "encryptionSpec" },
                              Common.GetValueByPath(fromObject, new string[] { "encryptionSpec" }));
      }

      return toObject;
    }

    internal JsonNode CreateTuningJobParametersPrivateToMldev(JsonNode fromObject,
                                                              JsonObject parentObject,
                                                              JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "baseModel" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "baseModel" },
                              Common.GetValueByPath(fromObject, new string[] { "baseModel" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "preTunedModel" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "preTunedModel" },
                              Common.GetValueByPath(fromObject, new string[] { "preTunedModel" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "trainingDataset" }) != null) {
        _ = TuningDatasetToMldev(Common.ParseToJsonNode(Common.GetValueByPath(
                                     fromObject, new string[] { "trainingDataset" })),
                                 toObject, rootObject);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = CreateTuningJobConfigToMldev(
            Common.ParseToJsonNode(Common.GetValueByPath(fromObject, new string[] { "config" })),
            toObject, rootObject);
      }

      return toObject;
    }

    internal JsonNode CreateTuningJobParametersPrivateToVertex(JsonNode fromObject,
                                                               JsonObject parentObject,
                                                               JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "baseModel" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "baseModel" },
                              Common.GetValueByPath(fromObject, new string[] { "baseModel" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "preTunedModel" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "preTunedModel" },
                              Common.GetValueByPath(fromObject, new string[] { "preTunedModel" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "trainingDataset" }) != null) {
        _ = TuningDatasetToVertex(Common.ParseToJsonNode(Common.GetValueByPath(
                                      fromObject, new string[] { "trainingDataset" })),
                                  toObject, rootObject);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = CreateTuningJobConfigToVertex(
            Common.ParseToJsonNode(Common.GetValueByPath(fromObject, new string[] { "config" })),
            toObject, rootObject);
      }

      return toObject;
    }

    internal JsonNode EvaluationConfigFromVertex(JsonNode fromObject, JsonObject parentObject,
                                                 JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode EvaluationConfigToVertex(JsonNode fromObject, JsonObject parentObject,
                                               JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode GenerationConfigFromVertex(JsonNode fromObject, JsonObject parentObject,
                                                 JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "modelConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "modelSelectionConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "modelConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseJsonSchema" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseJsonSchema" },
            Common.GetValueByPath(fromObject, new string[] { "responseJsonSchema" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "audioTimestamp" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "audioTimestamp" },
                              Common.GetValueByPath(fromObject, new string[] { "audioTimestamp" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "candidateCount" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "candidateCount" },
                              Common.GetValueByPath(fromObject, new string[] { "candidateCount" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "enableAffectiveDialog" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "enableAffectiveDialog" },
            Common.GetValueByPath(fromObject, new string[] { "enableAffectiveDialog" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "frequencyPenalty" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "frequencyPenalty" },
            Common.GetValueByPath(fromObject, new string[] { "frequencyPenalty" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "logprobs" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "logprobs" },
                              Common.GetValueByPath(fromObject, new string[] { "logprobs" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "maxOutputTokens" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "maxOutputTokens" },
            Common.GetValueByPath(fromObject, new string[] { "maxOutputTokens" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "mediaResolution" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "mediaResolution" },
            Common.GetValueByPath(fromObject, new string[] { "mediaResolution" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "presencePenalty" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "presencePenalty" },
            Common.GetValueByPath(fromObject, new string[] { "presencePenalty" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseLogprobs" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseLogprobs" },
            Common.GetValueByPath(fromObject, new string[] { "responseLogprobs" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseMimeType" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseMimeType" },
            Common.GetValueByPath(fromObject, new string[] { "responseMimeType" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseModalities" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseModalities" },
            Common.GetValueByPath(fromObject, new string[] { "responseModalities" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseSchema" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "responseSchema" },
                              Common.GetValueByPath(fromObject, new string[] { "responseSchema" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "routingConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "routingConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "routingConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "seed" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "seed" },
                              Common.GetValueByPath(fromObject, new string[] { "seed" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "speechConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "speechConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "speechConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "stopSequences" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "stopSequences" },
                              Common.GetValueByPath(fromObject, new string[] { "stopSequences" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "temperature" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "temperature" },
                              Common.GetValueByPath(fromObject, new string[] { "temperature" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "thinkingConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "thinkingConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "thinkingConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "topK" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "topK" },
                              Common.GetValueByPath(fromObject, new string[] { "topK" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "topP" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "topP" },
                              Common.GetValueByPath(fromObject, new string[] { "topP" }));
      }

      return toObject;
    }

    internal JsonNode GenerationConfigToVertex(JsonNode fromObject, JsonObject parentObject,
                                               JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "modelSelectionConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "modelConfig" },
            Common.GetValueByPath(fromObject, new string[] { "modelSelectionConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseJsonSchema" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseJsonSchema" },
            Common.GetValueByPath(fromObject, new string[] { "responseJsonSchema" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "audioTimestamp" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "audioTimestamp" },
                              Common.GetValueByPath(fromObject, new string[] { "audioTimestamp" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "candidateCount" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "candidateCount" },
                              Common.GetValueByPath(fromObject, new string[] { "candidateCount" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "enableAffectiveDialog" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "enableAffectiveDialog" },
            Common.GetValueByPath(fromObject, new string[] { "enableAffectiveDialog" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "frequencyPenalty" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "frequencyPenalty" },
            Common.GetValueByPath(fromObject, new string[] { "frequencyPenalty" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "logprobs" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "logprobs" },
                              Common.GetValueByPath(fromObject, new string[] { "logprobs" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "maxOutputTokens" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "maxOutputTokens" },
            Common.GetValueByPath(fromObject, new string[] { "maxOutputTokens" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "mediaResolution" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "mediaResolution" },
            Common.GetValueByPath(fromObject, new string[] { "mediaResolution" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "presencePenalty" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "presencePenalty" },
            Common.GetValueByPath(fromObject, new string[] { "presencePenalty" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseLogprobs" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseLogprobs" },
            Common.GetValueByPath(fromObject, new string[] { "responseLogprobs" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseMimeType" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseMimeType" },
            Common.GetValueByPath(fromObject, new string[] { "responseMimeType" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseModalities" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "responseModalities" },
            Common.GetValueByPath(fromObject, new string[] { "responseModalities" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "responseSchema" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "responseSchema" },
                              Common.GetValueByPath(fromObject, new string[] { "responseSchema" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "routingConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "routingConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "routingConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "seed" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "seed" },
                              Common.GetValueByPath(fromObject, new string[] { "seed" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "speechConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "speechConfig" },
            SpeechConfigToVertex(Common.ParseToJsonNode(Common.GetValueByPath(
                                     fromObject, new string[] { "speechConfig" })),
                                 toObject, rootObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "stopSequences" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "stopSequences" },
                              Common.GetValueByPath(fromObject, new string[] { "stopSequences" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "temperature" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "temperature" },
                              Common.GetValueByPath(fromObject, new string[] { "temperature" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "thinkingConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "thinkingConfig" },
                              Common.GetValueByPath(fromObject, new string[] { "thinkingConfig" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "topK" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "topK" },
                              Common.GetValueByPath(fromObject, new string[] { "topK" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "topP" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "topP" },
                              Common.GetValueByPath(fromObject, new string[] { "topP" }));
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "enableEnhancedCivicAnswers" }))) {
        throw new NotSupportedException(
            "enableEnhancedCivicAnswers parameter is not supported in Vertex AI.");
      }

      return toObject;
    }

    internal JsonNode GetTuningJobParametersToMldev(JsonNode fromObject, JsonObject parentObject,
                                                    JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "_url", "name" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      return toObject;
    }

    internal JsonNode GetTuningJobParametersToVertex(JsonNode fromObject, JsonObject parentObject,
                                                     JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "_url", "name" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      return toObject;
    }

    internal JsonNode ListTuningJobsConfigToMldev(JsonNode fromObject, JsonObject parentObject,
                                                  JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "pageSize" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "_query", "pageSize" },
                              Common.GetValueByPath(fromObject, new string[] { "pageSize" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "pageToken" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "_query", "pageToken" },
                              Common.GetValueByPath(fromObject, new string[] { "pageToken" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "filter" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "_query", "filter" },
                              Common.GetValueByPath(fromObject, new string[] { "filter" }));
      }

      return toObject;
    }

    internal JsonNode ListTuningJobsConfigToVertex(JsonNode fromObject, JsonObject parentObject,
                                                   JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "pageSize" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "_query", "pageSize" },
                              Common.GetValueByPath(fromObject, new string[] { "pageSize" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "pageToken" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "_query", "pageToken" },
                              Common.GetValueByPath(fromObject, new string[] { "pageToken" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "filter" }) != null) {
        Common.SetValueByPath(parentObject, new string[] { "_query", "filter" },
                              Common.GetValueByPath(fromObject, new string[] { "filter" }));
      }

      return toObject;
    }

    internal JsonNode ListTuningJobsParametersToMldev(JsonNode fromObject, JsonObject parentObject,
                                                      JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = ListTuningJobsConfigToMldev(
            Common.ParseToJsonNode(Common.GetValueByPath(fromObject, new string[] { "config" })),
            toObject, rootObject);
      }

      return toObject;
    }

    internal JsonNode ListTuningJobsParametersToVertex(JsonNode fromObject, JsonObject parentObject,
                                                       JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = ListTuningJobsConfigToVertex(
            Common.ParseToJsonNode(Common.GetValueByPath(fromObject, new string[] { "config" })),
            toObject, rootObject);
      }

      return toObject;
    }

    internal JsonNode ListTuningJobsResponseFromMldev(JsonNode fromObject, JsonObject parentObject,
                                                      JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "nextPageToken" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "nextPageToken" },
                              Common.GetValueByPath(fromObject, new string[] { "nextPageToken" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tunedModels" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "tunedModels" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(TuningJobFromMldev(Common.ParseToJsonNode(record), toObject, rootObject));
        }
        Common.SetValueByPath(toObject, new string[] { "tuningJobs" }, result);
      }

      return toObject;
    }

    internal JsonNode ListTuningJobsResponseFromVertex(JsonNode fromObject, JsonObject parentObject,
                                                       JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "nextPageToken" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "nextPageToken" },
                              Common.GetValueByPath(fromObject, new string[] { "nextPageToken" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tuningJobs" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "tuningJobs" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(TuningJobFromVertex(Common.ParseToJsonNode(record), toObject, rootObject));
        }
        Common.SetValueByPath(toObject, new string[] { "tuningJobs" }, result);
      }

      return toObject;
    }

    internal JsonNode MultiSpeakerVoiceConfigToVertex(JsonNode fromObject, JsonObject parentObject,
                                                      JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "speakerVoiceConfigs" }) != null) {
        JsonArray keyArray =
            (JsonArray)Common.GetValueByPath(fromObject, new string[] { "speakerVoiceConfigs" });
        JsonArray result = new JsonArray();

        foreach (var record in keyArray) {
          result.Add(
              SpeakerVoiceConfigToVertex(Common.ParseToJsonNode(record), toObject, rootObject));
        }
        Common.SetValueByPath(toObject, new string[] { "speakerVoiceConfigs" }, result);
      }

      return toObject;
    }

    internal JsonNode ReplicatedVoiceConfigToVertex(JsonNode fromObject, JsonObject parentObject,
                                                    JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "mimeType" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "mimeType" },
                              Common.GetValueByPath(fromObject, new string[] { "mimeType" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "voiceSampleAudio" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "voiceSampleAudio" },
            Common.GetValueByPath(fromObject, new string[] { "voiceSampleAudio" }));
      }

      return toObject;
    }

    internal JsonNode SpeakerVoiceConfigToVertex(JsonNode fromObject, JsonObject parentObject,
                                                 JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "speaker" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "speaker" },
                              Common.GetValueByPath(fromObject, new string[] { "speaker" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "voiceConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "voiceConfig" },
                              VoiceConfigToVertex(Common.ParseToJsonNode(Common.GetValueByPath(
                                                      fromObject, new string[] { "voiceConfig" })),
                                                  toObject, rootObject));
      }

      return toObject;
    }

    internal JsonNode SpeechConfigToVertex(JsonNode fromObject, JsonObject parentObject,
                                           JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "voiceConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "voiceConfig" },
                              VoiceConfigToVertex(Common.ParseToJsonNode(Common.GetValueByPath(
                                                      fromObject, new string[] { "voiceConfig" })),
                                                  toObject, rootObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "languageCode" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "languageCode" },
                              Common.GetValueByPath(fromObject, new string[] { "languageCode" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "multiSpeakerVoiceConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "multiSpeakerVoiceConfig" },
                              MultiSpeakerVoiceConfigToVertex(
                                  Common.ParseToJsonNode(Common.GetValueByPath(
                                      fromObject, new string[] { "multiSpeakerVoiceConfig" })),
                                  toObject, rootObject));
      }

      return toObject;
    }

    internal JsonNode TunedModelFromMldev(JsonNode fromObject, JsonObject parentObject,
                                          JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "model" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "endpoint" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      return toObject;
    }

    internal JsonNode TuningDatasetToMldev(JsonNode fromObject, JsonObject parentObject,
                                           JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "gcsUri" }))) {
        throw new NotSupportedException("gcsUri parameter is not supported in Gemini API.");
      }

      if (!Common.IsZero(
              Common.GetValueByPath(fromObject, new string[] { "vertexDatasetResource" }))) {
        throw new NotSupportedException(
            "vertexDatasetResource parameter is not supported in Gemini API.");
      }

      if (Common.GetValueByPath(fromObject, new string[] { "examples" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "examples", "examples" },
                              Common.GetValueByPath(fromObject, new string[] { "examples" }));
      }

      return toObject;
    }

    internal JsonNode TuningDatasetToVertex(JsonNode fromObject, JsonObject parentObject,
                                            JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      JsonNode discriminatorGcsUri =
          Common.GetValueByPath(rootObject, new string[] { "config", "method" });
      string discriminatorValueGcsUri = discriminatorGcsUri == null
                                            ? "SUPERVISED_FINE_TUNING"
                                            : discriminatorGcsUri.GetValue<string>();
      if (discriminatorValueGcsUri == "SUPERVISED_FINE_TUNING") {
        if (Common.GetValueByPath(fromObject, new string[] { "gcsUri" }) != null) {
          Common.SetValueByPath(parentObject,
                                new string[] { "supervisedTuningSpec", "trainingDatasetUri" },
                                Common.GetValueByPath(fromObject, new string[] { "gcsUri" }));
        }
      } else if (discriminatorValueGcsUri == "PREFERENCE_TUNING") {
        if (Common.GetValueByPath(fromObject, new string[] { "gcsUri" }) != null) {
          Common.SetValueByPath(parentObject,
                                new string[] { "preferenceOptimizationSpec", "trainingDatasetUri" },
                                Common.GetValueByPath(fromObject, new string[] { "gcsUri" }));
        }
      } else if (discriminatorValueGcsUri == "DISTILLATION") {
        if (Common.GetValueByPath(fromObject, new string[] { "gcsUri" }) != null) {
          Common.SetValueByPath(parentObject,
                                new string[] { "distillationSpec", "promptDatasetUri" },
                                Common.GetValueByPath(fromObject, new string[] { "gcsUri" }));
        }
      }

      JsonNode discriminatorVertexDatasetResource =
          Common.GetValueByPath(rootObject, new string[] { "config", "method" });
      string discriminatorValueVertexDatasetResource =
          discriminatorVertexDatasetResource == null
              ? "SUPERVISED_FINE_TUNING"
              : discriminatorVertexDatasetResource.GetValue<string>();
      if (discriminatorValueVertexDatasetResource == "SUPERVISED_FINE_TUNING") {
        if (Common.GetValueByPath(fromObject, new string[] { "vertexDatasetResource" }) != null) {
          Common.SetValueByPath(
              parentObject, new string[] { "supervisedTuningSpec", "trainingDatasetUri" },
              Common.GetValueByPath(fromObject, new string[] { "vertexDatasetResource" }));
        }
      } else if (discriminatorValueVertexDatasetResource == "PREFERENCE_TUNING") {
        if (Common.GetValueByPath(fromObject, new string[] { "vertexDatasetResource" }) != null) {
          Common.SetValueByPath(
              parentObject, new string[] { "preferenceOptimizationSpec", "trainingDatasetUri" },
              Common.GetValueByPath(fromObject, new string[] { "vertexDatasetResource" }));
        }
      } else if (discriminatorValueVertexDatasetResource == "DISTILLATION") {
        if (Common.GetValueByPath(fromObject, new string[] { "vertexDatasetResource" }) != null) {
          Common.SetValueByPath(
              parentObject, new string[] { "distillationSpec", "promptDatasetUri" },
              Common.GetValueByPath(fromObject, new string[] { "vertexDatasetResource" }));
        }
      }
      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "examples" }))) {
        throw new NotSupportedException("examples parameter is not supported in Vertex AI.");
      }

      return toObject;
    }

    internal JsonNode TuningJobFromMldev(JsonNode fromObject, JsonObject parentObject,
                                         JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "name" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "state" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "state" },
                              Transformers.TTuningJobStatus(
                                  Common.GetValueByPath(fromObject, new string[] { "state" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "createTime" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "createTime" },
                              Common.GetValueByPath(fromObject, new string[] { "createTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tuningTask", "startTime" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "startTime" },
            Common.GetValueByPath(fromObject, new string[] { "tuningTask", "startTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tuningTask", "completeTime" }) !=
          null) {
        Common.SetValueByPath(
            toObject, new string[] { "endTime" },
            Common.GetValueByPath(fromObject, new string[] { "tuningTask", "completeTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "updateTime" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "updateTime" },
                              Common.GetValueByPath(fromObject, new string[] { "updateTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "description" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "description" },
                              Common.GetValueByPath(fromObject, new string[] { "description" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "baseModel" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "baseModel" },
                              Common.GetValueByPath(fromObject, new string[] { "baseModel" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "_self" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "tunedModel" },
                              TunedModelFromMldev(Common.ParseToJsonNode(Common.GetValueByPath(
                                                      fromObject, new string[] { "_self" })),
                                                  toObject, rootObject));
      }

      return toObject;
    }

    internal JsonNode TuningJobFromVertex(JsonNode fromObject, JsonObject parentObject,
                                          JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "name" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "state" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "state" },
                              Transformers.TTuningJobStatus(
                                  Common.GetValueByPath(fromObject, new string[] { "state" })));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "createTime" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "createTime" },
                              Common.GetValueByPath(fromObject, new string[] { "createTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "startTime" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "startTime" },
                              Common.GetValueByPath(fromObject, new string[] { "startTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "endTime" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "endTime" },
                              Common.GetValueByPath(fromObject, new string[] { "endTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "updateTime" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "updateTime" },
                              Common.GetValueByPath(fromObject, new string[] { "updateTime" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "error" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "error" },
                              Common.GetValueByPath(fromObject, new string[] { "error" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "description" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "description" },
                              Common.GetValueByPath(fromObject, new string[] { "description" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "baseModel" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "baseModel" },
                              Common.GetValueByPath(fromObject, new string[] { "baseModel" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tunedModel" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "tunedModel" },
                              Common.GetValueByPath(fromObject, new string[] { "tunedModel" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "preTunedModel" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "preTunedModel" },
                              Common.GetValueByPath(fromObject, new string[] { "preTunedModel" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "supervisedTuningSpec" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "supervisedTuningSpec" },
            Common.GetValueByPath(fromObject, new string[] { "supervisedTuningSpec" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "preferenceOptimizationSpec" }) !=
          null) {
        Common.SetValueByPath(
            toObject, new string[] { "preferenceOptimizationSpec" },
            Common.GetValueByPath(fromObject, new string[] { "preferenceOptimizationSpec" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "distillationSpec" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "distillationSpec" },
            Common.GetValueByPath(fromObject, new string[] { "distillationSpec" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tuningDataStats" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "tuningDataStats" },
            Common.GetValueByPath(fromObject, new string[] { "tuningDataStats" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "encryptionSpec" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "encryptionSpec" },
                              Common.GetValueByPath(fromObject, new string[] { "encryptionSpec" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "partnerModelTuningSpec" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "partnerModelTuningSpec" },
            Common.GetValueByPath(fromObject, new string[] { "partnerModelTuningSpec" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "customBaseModel" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "customBaseModel" },
            Common.GetValueByPath(fromObject, new string[] { "customBaseModel" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "evaluateDatasetRuns" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "evaluateDatasetRuns" },
            Common.GetValueByPath(fromObject, new string[] { "evaluateDatasetRuns" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "experiment" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "experiment" },
                              Common.GetValueByPath(fromObject, new string[] { "experiment" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "fullFineTuningSpec" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "fullFineTuningSpec" },
            Common.GetValueByPath(fromObject, new string[] { "fullFineTuningSpec" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "labels" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "labels" },
                              Common.GetValueByPath(fromObject, new string[] { "labels" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "outputUri" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "outputUri" },
                              Common.GetValueByPath(fromObject, new string[] { "outputUri" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "pipelineJob" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "pipelineJob" },
                              Common.GetValueByPath(fromObject, new string[] { "pipelineJob" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "serviceAccount" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "serviceAccount" },
                              Common.GetValueByPath(fromObject, new string[] { "serviceAccount" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tunedModelDisplayName" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "tunedModelDisplayName" },
            Common.GetValueByPath(fromObject, new string[] { "tunedModelDisplayName" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tuningJobState" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "tuningJobState" },
                              Common.GetValueByPath(fromObject, new string[] { "tuningJobState" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "veoTuningSpec" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "veoTuningSpec" },
                              Common.GetValueByPath(fromObject, new string[] { "veoTuningSpec" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "distillationSamplingSpec" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "distillationSamplingSpec" },
            Common.GetValueByPath(fromObject, new string[] { "distillationSamplingSpec" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "tuningJobMetadata" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "tuningJobMetadata" },
            Common.GetValueByPath(fromObject, new string[] { "tuningJobMetadata" }));
      }

      return toObject;
    }

    internal JsonNode TuningOperationFromMldev(JsonNode fromObject, JsonObject parentObject,
                                               JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "name" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "name" },
                              Common.GetValueByPath(fromObject, new string[] { "name" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "metadata" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "metadata" },
                              Common.GetValueByPath(fromObject, new string[] { "metadata" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "done" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "done" },
                              Common.GetValueByPath(fromObject, new string[] { "done" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "error" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "error" },
                              Common.GetValueByPath(fromObject, new string[] { "error" }));
      }

      return toObject;
    }

    internal JsonNode TuningValidationDatasetToVertex(JsonNode fromObject, JsonObject parentObject,
                                                      JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "gcsUri" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "validationDatasetUri" },
                              Common.GetValueByPath(fromObject, new string[] { "gcsUri" }));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "vertexDatasetResource" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "validationDatasetUri" },
            Common.GetValueByPath(fromObject, new string[] { "vertexDatasetResource" }));
      }

      return toObject;
    }

    internal JsonNode VoiceConfigToVertex(JsonNode fromObject, JsonObject parentObject,
                                          JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "replicatedVoiceConfig" }) != null) {
        Common.SetValueByPath(toObject, new string[] { "replicatedVoiceConfig" },
                              ReplicatedVoiceConfigToVertex(
                                  Common.ParseToJsonNode(Common.GetValueByPath(
                                      fromObject, new string[] { "replicatedVoiceConfig" })),
                                  toObject, rootObject));
      }

      if (Common.GetValueByPath(fromObject, new string[] { "prebuiltVoiceConfig" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "prebuiltVoiceConfig" },
            Common.GetValueByPath(fromObject, new string[] { "prebuiltVoiceConfig" }));
      }

      return toObject;
    }

    public Tunings(ApiClient apiClient) {
      _apiClient = apiClient;
    }

    private async Task<TuningJob> PrivateGetAsync(string name, GetTuningJobConfig? config,
                                                  CancellationToken cancellationToken = default) {
      GetTuningJobParameters parameter = new GetTuningJobParameters();

      if (!Common.IsZero(name)) {
        parameter.Name = name;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse GetTuningJobParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = GetTuningJobParametersToVertex(parameterNode, new JsonObject(), parameterNode);
        path = Common.FormatMap("{name}", body["_url"]);
      } else {
        body = GetTuningJobParametersToMldev(parameterNode, new JsonObject(), parameterNode);
        path = Common.FormatMap("{name}", body["_url"]);
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
      HttpOptions? requestHttpOptions = config?.HttpOptions;

      ApiResponse response =
          await this._apiClient.RequestAsync(HttpMethod.Get, path, JsonSerializer.Serialize(body),
                                             requestHttpOptions, cancellationToken);
      HttpContent httpContent = response.GetEntity();
#if NETSTANDARD2_0
      string contentString = await httpContent.ReadAsStringAsync();
#else
      string contentString = await httpContent.ReadAsStringAsync(cancellationToken);
#endif
      JsonNode? httpContentNode = JsonNode.Parse(contentString);
      if (httpContentNode == null) {
        throw new NotSupportedException("Failed to parse response to JsonNode.");
      }
      JsonNode responseNode = httpContentNode;

      if (this._apiClient.VertexAI) {
        responseNode = TuningJobFromVertex(httpContentNode, new JsonObject(), parameterNode);
      }

      if (!this._apiClient.VertexAI) {
        responseNode = TuningJobFromMldev(httpContentNode, new JsonObject(), parameterNode);
      }

      return responseNode.Deserialize<TuningJob>() ??
             throw new InvalidOperationException("Failed to deserialize Task<TuningJob>.");
    }

    private async Task<ListTuningJobsResponse> PrivateListAsync(
        ListTuningJobsConfig? config, CancellationToken cancellationToken = default) {
      ListTuningJobsParameters parameter = new ListTuningJobsParameters();

      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse ListTuningJobsParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = ListTuningJobsParametersToVertex(parameterNode, new JsonObject(), parameterNode);
        path = Common.FormatMap("tuningJobs", body["_url"]);
      } else {
        body = ListTuningJobsParametersToMldev(parameterNode, new JsonObject(), parameterNode);
        path = Common.FormatMap("tunedModels", body["_url"]);
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
      HttpOptions? requestHttpOptions = config?.HttpOptions;

      ApiResponse response =
          await this._apiClient.RequestAsync(HttpMethod.Get, path, JsonSerializer.Serialize(body),
                                             requestHttpOptions, cancellationToken);
      HttpContent httpContent = response.GetEntity();
#if NETSTANDARD2_0
      string contentString = await httpContent.ReadAsStringAsync();
#else
      string contentString = await httpContent.ReadAsStringAsync(cancellationToken);
#endif
      JsonNode? httpContentNode = JsonNode.Parse(contentString);
      if (httpContentNode == null) {
        throw new NotSupportedException("Failed to parse response to JsonNode.");
      }
      JsonNode responseNode = httpContentNode;

      if (this._apiClient.VertexAI) {
        responseNode =
            ListTuningJobsResponseFromVertex(httpContentNode, new JsonObject(), parameterNode);
      }

      if (!this._apiClient.VertexAI) {
        responseNode =
            ListTuningJobsResponseFromMldev(httpContentNode, new JsonObject(), parameterNode);
      }

      return responseNode.Deserialize<ListTuningJobsResponse>() ??
             throw new InvalidOperationException(
                 "Failed to deserialize Task<ListTuningJobsResponse>.");
    }

    /// <summary>
    /// Cancels a tuning job resource.
    /// </summary>
    /// <param name="name">The resource name of the tuning job. For Vertex, this is the full
    /// resource name or `tuningJobs/{id}`.</param> <param name="config">A <see
    /// cref="CancelTuningJobConfig"/> for configuring the cancel request.</param> <param
    /// name="cancellationToken">A <see cref="CancellationToken"/> to cancel the operation.</param>

    public async Task<CancelTuningJobResponse> CancelAsync(
        string name, CancelTuningJobConfig? config = null,
        CancellationToken cancellationToken = default) {
      CancelTuningJobParameters parameter = new CancelTuningJobParameters();

      if (!Common.IsZero(name)) {
        parameter.Name = name;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException("Failed to parse CancelTuningJobParameters to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = CancelTuningJobParametersToVertex(parameterNode, new JsonObject(), parameterNode);
        path = Common.FormatMap("{name}:cancel", body["_url"]);
      } else {
        body = CancelTuningJobParametersToMldev(parameterNode, new JsonObject(), parameterNode);
        path = Common.FormatMap("{name}:cancel", body["_url"]);
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
      HttpOptions? requestHttpOptions = config?.HttpOptions;

      ApiResponse response =
          await this._apiClient.RequestAsync(HttpMethod.Post, path, JsonSerializer.Serialize(body),
                                             requestHttpOptions, cancellationToken);
      HttpContent httpContent = response.GetEntity();
#if NETSTANDARD2_0
      string contentString = await httpContent.ReadAsStringAsync();
#else
      string contentString = await httpContent.ReadAsStringAsync(cancellationToken);
#endif
      JsonNode? httpContentNode = JsonNode.Parse(contentString);
      if (httpContentNode == null) {
        throw new NotSupportedException("Failed to parse response to JsonNode.");
      }
      JsonNode responseNode = httpContentNode;

      if (this._apiClient.VertexAI) {
        responseNode =
            CancelTuningJobResponseFromVertex(httpContentNode, new JsonObject(), parameterNode);
      }

      if (!this._apiClient.VertexAI) {
        responseNode =
            CancelTuningJobResponseFromMldev(httpContentNode, new JsonObject(), parameterNode);
      }

      return responseNode.Deserialize<CancelTuningJobResponse>() ??
             throw new InvalidOperationException(
                 "Failed to deserialize Task<CancelTuningJobResponse>.");
    }

    private async Task<TuningJob> PrivateTuneAsync(string? baseModel, PreTunedModel? preTunedModel,
                                                   TuningDataset trainingDataset,
                                                   CreateTuningJobConfig? config,
                                                   CancellationToken cancellationToken = default) {
      CreateTuningJobParametersPrivate parameter = new CreateTuningJobParametersPrivate();

      if (!Common.IsZero(baseModel)) {
        parameter.BaseModel = baseModel;
      }
      if (!Common.IsZero(preTunedModel)) {
        parameter.PreTunedModel = preTunedModel;
      }
      if (!Common.IsZero(trainingDataset)) {
        parameter.TrainingDataset = trainingDataset;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException(
            "Failed to parse CreateTuningJobParametersPrivate to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        body = CreateTuningJobParametersPrivateToVertex(parameterNode, new JsonObject(),
                                                        parameterNode);
        path = Common.FormatMap("tuningJobs", body["_url"]);
      } else {
        throw new NotSupportedException("This method is only supported in the Vertex AI client.");
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
      HttpOptions? requestHttpOptions = config?.HttpOptions;

      ApiResponse response =
          await this._apiClient.RequestAsync(HttpMethod.Post, path, JsonSerializer.Serialize(body),
                                             requestHttpOptions, cancellationToken);
      HttpContent httpContent = response.GetEntity();
#if NETSTANDARD2_0
      string contentString = await httpContent.ReadAsStringAsync();
#else
      string contentString = await httpContent.ReadAsStringAsync(cancellationToken);
#endif
      JsonNode? httpContentNode = JsonNode.Parse(contentString);
      if (httpContentNode == null) {
        throw new NotSupportedException("Failed to parse response to JsonNode.");
      }
      JsonNode responseNode = httpContentNode;

      if (this._apiClient.VertexAI) {
        responseNode = TuningJobFromVertex(httpContentNode, new JsonObject(), parameterNode);
      }

      if (!this._apiClient.VertexAI) {
        throw new NotSupportedException("This method is only supported in the Vertex AI client.");
      }

      return responseNode.Deserialize<TuningJob>() ??
             throw new InvalidOperationException("Failed to deserialize Task<TuningJob>.");
    }

    private async Task<TuningOperation> PrivateTuneMldevAsync(
        string? baseModel, PreTunedModel? preTunedModel, TuningDataset trainingDataset,
        CreateTuningJobConfig? config, CancellationToken cancellationToken = default) {
      CreateTuningJobParametersPrivate parameter = new CreateTuningJobParametersPrivate();

      if (!Common.IsZero(baseModel)) {
        parameter.BaseModel = baseModel;
      }
      if (!Common.IsZero(preTunedModel)) {
        parameter.PreTunedModel = preTunedModel;
      }
      if (!Common.IsZero(trainingDataset)) {
        parameter.TrainingDataset = trainingDataset;
      }
      if (!Common.IsZero(config)) {
        parameter.Config = config;
      }
      string jsonString = JsonSerializer.Serialize(parameter);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null) {
        throw new NotSupportedException(
            "Failed to parse CreateTuningJobParametersPrivate to JsonNode.");
      }

      JsonNode body;
      string path;
      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      } else {
        body =
            CreateTuningJobParametersPrivateToMldev(parameterNode, new JsonObject(), parameterNode);
        path = Common.FormatMap("tunedModels", body["_url"]);
      }
      JsonObject? bodyObj = body?.AsObject();
      bodyObj?.Remove("_url");
      if (bodyObj != null && bodyObj.ContainsKey("_query")) {
        path = path + "?" + Common.FormatQuery((JsonObject)bodyObj["_query"]);
        bodyObj.Remove("_query");
      } else {
        bodyObj?.Remove("_query");
      }
      HttpOptions? requestHttpOptions = config?.HttpOptions;

      ApiResponse response =
          await this._apiClient.RequestAsync(HttpMethod.Post, path, JsonSerializer.Serialize(body),
                                             requestHttpOptions, cancellationToken);
      HttpContent httpContent = response.GetEntity();
#if NETSTANDARD2_0
      string contentString = await httpContent.ReadAsStringAsync();
#else
      string contentString = await httpContent.ReadAsStringAsync(cancellationToken);
#endif
      JsonNode? httpContentNode = JsonNode.Parse(contentString);
      if (httpContentNode == null) {
        throw new NotSupportedException("Failed to parse response to JsonNode.");
      }
      JsonNode responseNode = httpContentNode;

      if (this._apiClient.VertexAI) {
        throw new NotSupportedException(
            "This method is only supported in the Gemini Developer API client.");
      }

      if (!this._apiClient.VertexAI) {
        responseNode = httpContentNode;
      }

      return responseNode.Deserialize<TuningOperation>() ??
             throw new InvalidOperationException("Failed to deserialize Task<TuningOperation>.");
    }

    /// <summary>
    /// Lists tuning jobs.
    /// </summary>
    /// <param name="config">A <see cref="ListTuningJobsConfig"/> instance that specifies the
    /// optional configuration for the list request.</param> <param name="cancellationToken">A <see
    /// cref="CancellationToken"/> to cancel the operation.</param> <returns>A Pager object that
    /// contains one page of tuning jobs. When iterating over the pager, it automatically fetches
    /// the next page if there are more.</returns>

    public async Task<Pager<TuningJob, ListTuningJobsConfig, ListTuningJobsResponse>> ListAsync(
        ListTuningJobsConfig? config = null, CancellationToken cancellationToken = default) {
      config ??= new ListTuningJobsConfig();
      var initialResponse = await PrivateListAsync(config, cancellationToken);

      return new Pager<TuningJob, ListTuningJobsConfig, ListTuningJobsResponse>(
          requestFunc: async cfg => await PrivateListAsync(cfg, cancellationToken),
          extractItems: response => response.TuningJobs,
          extractNextPageToken: response => response.NextPageToken,
          extractHttpResponse: response => response.SdkHttpResponse,
          updateConfigPageToken: (cfg, token) => {
            cfg.PageToken = token;
            return cfg;
          }, initialConfig: config, initialResponse: initialResponse, requestedPageSize: config.PageSize ?? 0);
    }

    /// <summary>
    /// Makes an API request to get a tuning job.
    /// </summary>
    /// <param name="name">The resource name of the tuning job.</param>
    /// <param name="config">A <see cref="GetTuningJobConfig"/> for configuring the get
    /// request.</param> <param name="cancellationToken">The cancellation token for the
    /// request.</param> <returns>A <see cref="TuningJob"/> object.</returns>
    public async Task<TuningJob> GetAsync(string name, GetTuningJobConfig? config = null,
                                          CancellationToken cancellationToken = default) {
      return await this.PrivateGetAsync(name, config, cancellationToken);
    }

    /// <summary>
    /// Makes an API request to create a supervised fine-tuning job.
    /// </summary>
    /// <param name="baseModel">The base model to tune.</param>
    /// <param name="trainingDataset">The training dataset to use for tuning.</param>
    /// <param name="config">A <see cref="CreateTuningJobConfig"/> for configuring the create
    /// request.</param> <param name="cancellationToken">The cancellation token for the
    /// request.</param> <returns>A <see cref="TuningJob"/> object.</returns>
    public async Task<TuningJob> TuneAsync(string baseModel, TuningDataset trainingDataset,
                                           CreateTuningJobConfig? config = null,
                                           CancellationToken cancellationToken = default) {
      if (this._apiClient.VertexAI) {
        if (baseModel.StartsWith("projects/")) {
          PreTunedModel preTunedModel = new PreTunedModel { TunedModelName = baseModel };
          if (config != null && config.PreTunedModelCheckpointId != null) {
            preTunedModel.CheckpointId = config.PreTunedModelCheckpointId;
          }
          return await this.PrivateTuneAsync(null, preTunedModel, trainingDataset, config,
                                             cancellationToken);
        } else {
          return await this.PrivateTuneAsync(baseModel, null, trainingDataset, config,
                                             cancellationToken);
        }
      } else {
        TuningOperation operation = await this.PrivateTuneMldevAsync(
            baseModel, null, trainingDataset, config, cancellationToken);
        string tunedModelName = "";
        if (operation.Metadata != null && operation.Metadata.ContainsKey("tunedModel")) {
          tunedModelName = (string)operation.Metadata["tunedModel"];
        } else {
          if (operation.Name == null) {
            throw new ArgumentException("Operation name is required.");
          }
          tunedModelName =
              operation.Name.Split(new string[] { "/operations/" }, StringSplitOptions.None)[0];
        }
        return new TuningJob { Name = tunedModelName, State = JobState.JobStateQueued };
      }
    }
  }
}
