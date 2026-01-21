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

    internal JsonNode CancelTuningJobResponseFromMldev(JsonNode fromObject,
                                                       JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }) != null) {
        Common.SetValueByPath(
            toObject, new string[] { "sdkHttpResponse" },
            Common.GetValueByPath(fromObject, new string[] { "sdkHttpResponse" }));
      }

      return toObject;
    }

    internal JsonNode CancelTuningJobResponseFromVertex(JsonNode fromObject,
                                                        JsonObject parentObject) {
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
                                    JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                        fromObject, new string[] { "validationDataset" }))),
                                    toObject, rootObject));
        }
      } else if (discriminatorValueValidationDataset == "PREFERENCE_TUNING") {
        if (Common.GetValueByPath(fromObject, new string[] { "validationDataset" }) != null) {
          Common.SetValueByPath(parentObject, new string[] { "preferenceOptimizationSpec" },
                                TuningValidationDatasetToVertex(
                                    JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                        fromObject, new string[] { "validationDataset" }))),
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
      }
      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "batchSize" }))) {
        throw new NotSupportedException("batchSize parameter is not supported in Vertex AI.");
      }

      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "learningRate" }))) {
        throw new NotSupportedException("learningRate parameter is not supported in Vertex AI.");
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
        _ = TuningDatasetToMldev(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                     fromObject, new string[] { "trainingDataset" }))),
                                 toObject, rootObject);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = CreateTuningJobConfigToMldev(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
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
        _ = TuningDatasetToVertex(JsonNode.Parse(JsonSerializer.Serialize(Common.GetValueByPath(
                                      fromObject, new string[] { "trainingDataset" }))),
                                  toObject, rootObject);
      }

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = CreateTuningJobConfigToVertex(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject, rootObject);
      }

      return toObject;
    }

    internal JsonNode EvaluationConfigFromVertex(JsonNode fromObject, JsonObject parentObject) {
      JsonObject toObject = new JsonObject();

      return toObject;
    }

    internal JsonNode EvaluationConfigToVertex(JsonNode fromObject, JsonObject parentObject,
                                               JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

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
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject, rootObject);
      }

      return toObject;
    }

    internal JsonNode ListTuningJobsParametersToVertex(JsonNode fromObject, JsonObject parentObject,
                                                       JsonNode rootObject) {
      JsonObject toObject = new JsonObject();

      if (Common.GetValueByPath(fromObject, new string[] { "config" }) != null) {
        _ = ListTuningJobsConfigToVertex(
            JsonNode.Parse(JsonSerializer.Serialize(
                Common.GetValueByPath(fromObject, new string[] { "config" }))),
            toObject, rootObject);
      }

      return toObject;
    }

    internal JsonNode ListTuningJobsResponseFromMldev(JsonNode fromObject,
                                                      JsonObject parentObject) {
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
          result.Add(
              TuningJobFromMldev(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "tuningJobs" }, result);
      }

      return toObject;
    }

    internal JsonNode ListTuningJobsResponseFromVertex(JsonNode fromObject,
                                                       JsonObject parentObject) {
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
          result.Add(
              TuningJobFromVertex(JsonNode.Parse(JsonSerializer.Serialize(record)), toObject));
        }
        Common.SetValueByPath(toObject, new string[] { "tuningJobs" }, result);
      }

      return toObject;
    }

    internal JsonNode TunedModelFromMldev(JsonNode fromObject, JsonObject parentObject) {
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
      }
      if (!Common.IsZero(Common.GetValueByPath(fromObject, new string[] { "examples" }))) {
        throw new NotSupportedException("examples parameter is not supported in Vertex AI.");
      }

      return toObject;
    }

    internal JsonNode TuningJobFromMldev(JsonNode fromObject, JsonObject parentObject) {
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
        Common.SetValueByPath(
            toObject, new string[] { "tunedModel" },
            TunedModelFromMldev(JsonNode.Parse(JsonSerializer.Serialize(
                                    Common.GetValueByPath(fromObject, new string[] { "_self" }))),
                                toObject));
      }

      return toObject;
    }

    internal JsonNode TuningJobFromVertex(JsonNode fromObject, JsonObject parentObject) {
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

      return toObject;
    }

    internal JsonNode TuningOperationFromMldev(JsonNode fromObject, JsonObject parentObject) {
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

    public Tunings(ApiClient apiClient) {
      _apiClient = apiClient;
    }

    private async Task<TuningJob> PrivateGetAsync(string name, GetTuningJobConfig? config) {
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

      ApiResponse response = await this._apiClient.RequestAsync(
          HttpMethod.Get, path, JsonSerializer.Serialize(body), requestHttpOptions);
      HttpContent httpContent = response.GetEntity();
      string contentString = await httpContent.ReadAsStringAsync();
      JsonNode? httpContentNode = JsonNode.Parse(contentString);
      if (httpContentNode == null) {
        throw new NotSupportedException("Failed to parse response to JsonNode.");
      }
      JsonNode responseNode = httpContentNode;

      if (this._apiClient.VertexAI) {
        responseNode = TuningJobFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        responseNode = TuningJobFromMldev(httpContentNode, new JsonObject());
      }

      return JsonSerializer.Deserialize<TuningJob>(responseNode.ToString()) ??
             throw new InvalidOperationException("Failed to deserialize Task<TuningJob>.");
    }

    private async Task<ListTuningJobsResponse> PrivateListAsync(ListTuningJobsConfig? config) {
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

      ApiResponse response = await this._apiClient.RequestAsync(
          HttpMethod.Get, path, JsonSerializer.Serialize(body), requestHttpOptions);
      HttpContent httpContent = response.GetEntity();
      string contentString = await httpContent.ReadAsStringAsync();
      JsonNode? httpContentNode = JsonNode.Parse(contentString);
      if (httpContentNode == null) {
        throw new NotSupportedException("Failed to parse response to JsonNode.");
      }
      JsonNode responseNode = httpContentNode;

      if (this._apiClient.VertexAI) {
        responseNode = ListTuningJobsResponseFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        responseNode = ListTuningJobsResponseFromMldev(httpContentNode, new JsonObject());
      }

      return JsonSerializer.Deserialize<ListTuningJobsResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException(
                 "Failed to deserialize Task<ListTuningJobsResponse>.");
    }

    /// <summary>
    /// Cancels a tuning job resource.
    /// </summary>
    /// <param name="name">The resource name of the tuning job. For Vertex, this is the full
    /// resource name or `tuningJobs/{id}`.</param> <param name="config">A <see
    /// cref="CancelTuningJobConfig"/> for configuring the cancel request.</param>

    public async Task<CancelTuningJobResponse> CancelAsync(string name,
                                                           CancelTuningJobConfig? config = null) {
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

      ApiResponse response = await this._apiClient.RequestAsync(
          HttpMethod.Post, path, JsonSerializer.Serialize(body), requestHttpOptions);
      HttpContent httpContent = response.GetEntity();
      string contentString = await httpContent.ReadAsStringAsync();
      JsonNode? httpContentNode = JsonNode.Parse(contentString);
      if (httpContentNode == null) {
        throw new NotSupportedException("Failed to parse response to JsonNode.");
      }
      JsonNode responseNode = httpContentNode;

      if (this._apiClient.VertexAI) {
        responseNode = CancelTuningJobResponseFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        responseNode = CancelTuningJobResponseFromMldev(httpContentNode, new JsonObject());
      }

      return JsonSerializer.Deserialize<CancelTuningJobResponse>(responseNode.ToString()) ??
             throw new InvalidOperationException(
                 "Failed to deserialize Task<CancelTuningJobResponse>.");
    }

    private async Task<TuningJob> PrivateTuneAsync(string? baseModel, PreTunedModel? preTunedModel,
                                                   TuningDataset trainingDataset,
                                                   CreateTuningJobConfig? config) {
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

      ApiResponse response = await this._apiClient.RequestAsync(
          HttpMethod.Post, path, JsonSerializer.Serialize(body), requestHttpOptions);
      HttpContent httpContent = response.GetEntity();
      string contentString = await httpContent.ReadAsStringAsync();
      JsonNode? httpContentNode = JsonNode.Parse(contentString);
      if (httpContentNode == null) {
        throw new NotSupportedException("Failed to parse response to JsonNode.");
      }
      JsonNode responseNode = httpContentNode;

      if (this._apiClient.VertexAI) {
        responseNode = TuningJobFromVertex(httpContentNode, new JsonObject());
      }

      if (!this._apiClient.VertexAI) {
        throw new NotSupportedException("This method is only supported in the Vertex AI client.");
      }

      return JsonSerializer.Deserialize<TuningJob>(responseNode.ToString()) ??
             throw new InvalidOperationException("Failed to deserialize Task<TuningJob>.");
    }

    private async Task<TuningOperation> PrivateTuneMldevAsync(string? baseModel,
                                                              PreTunedModel? preTunedModel,
                                                              TuningDataset trainingDataset,
                                                              CreateTuningJobConfig? config) {
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

      ApiResponse response = await this._apiClient.RequestAsync(
          HttpMethod.Post, path, JsonSerializer.Serialize(body), requestHttpOptions);
      HttpContent httpContent = response.GetEntity();
      string contentString = await httpContent.ReadAsStringAsync();
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

      return JsonSerializer.Deserialize<TuningOperation>(responseNode.ToString()) ??
             throw new InvalidOperationException("Failed to deserialize Task<TuningOperation>.");
    }

    /// <summary>
    /// Lists tuning jobs.
    /// </summary>
    /// <param name="config">A <see cref="ListTuningJobsConfig"/> instance that specifies the
    /// optional configuration for the list request.</param> <returns>A Pager object that contains
    /// one page of tuning jobs. When iterating over the pager, it automatically fetches the next
    /// page if there are more.</returns>

    public async Task<Pager<TuningJob, ListTuningJobsConfig, ListTuningJobsResponse>> ListAsync(
        ListTuningJobsConfig? config = null) {
      config ??= new ListTuningJobsConfig();
      var initialResponse = await PrivateListAsync(config);

      return new Pager<TuningJob, ListTuningJobsConfig, ListTuningJobsResponse>(
          requestFunc: async cfg => await PrivateListAsync(cfg),
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
    /// request.</param> <returns>A <see cref="TuningJob"/> object.</returns>
    public async Task<TuningJob> GetAsync(string name, GetTuningJobConfig? config = null) {
      return await this.PrivateGetAsync(name, config);
    }

    /// <summary>
    /// Makes an API request to create a supervised fine-tuning job.
    /// </summary>
    /// <param name="baseModel">The base model to tune.</param>
    /// <param name="trainingDataset">The training dataset to use for tuning.</param>
    /// <param name="config">A <see cref="CreateTuningJobConfig"/> for configuring the create
    /// request.</param> <returns>A <see cref="TuningJob"/> object.</returns>
    public async Task<TuningJob> TuneAsync(string baseModel, TuningDataset trainingDataset,
                                           CreateTuningJobConfig? config = null) {
      if (this._apiClient.VertexAI) {
        if (baseModel.StartsWith("projects/")) {
          PreTunedModel preTunedModel = new PreTunedModel { TunedModelName = baseModel };
          if (config != null && config.PreTunedModelCheckpointId != null) {
            preTunedModel.CheckpointId = config.PreTunedModelCheckpointId;
          }
          return await this.PrivateTuneAsync(null, preTunedModel, trainingDataset, config);
        } else {
          return await this.PrivateTuneAsync(baseModel, null, trainingDataset, config);
        }
      } else {
        TuningOperation operation =
            await this.PrivateTuneMldevAsync(baseModel, null, trainingDataset, config);
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
        return new TuningJob { Name = tunedModelName, State = JobState.JOB_STATE_QUEUED };
      }
    }
  }
}
