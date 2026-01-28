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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Google.GenAI;
using Google.GenAI.Types;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestServerSdk;

[TestClass]
public class TuneTest {
  private static TestServerProcess? _server;
  private Client vertexClient;
  private Client geminiClient;
  private string modelName;
  private string mode;
  public TestContext TestContext { get; set; }

  [ClassInitialize]
  public static void ClassInit(TestContext _) {
    _server = TestServer.StartTestServer();
  }

  [ClassCleanup]
  public static void ClassCleanup() {
    TestServer.StopTestServer(_server);
  }

  [TestInitialize]
  public void TestInit() {
    // Test server specific setup.
    if (_server == null) {
      throw new InvalidOperationException("Test server is not initialized.");
    }
    var geminiClientHttpOptions = new HttpOptions { Headers = new Dictionary<string, string> {
      { "Test-Name", $"{GetType().Name}.{TestContext.TestName}" }
    } };
    var vertexClientHttpOptions = new HttpOptions { Headers = new Dictionary<string, string> {
      { "Test-Name", $"{GetType().Name}.{TestContext.TestName}" }
    } };

    // Common setup for both clients.
    string project = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT");
    string location =
        System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_LOCATION") ?? "us-central1";
    string apiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
    mode = System.Environment.GetEnvironmentVariable("TEST_MODE") ?? "replay";
    Client.setDefaultBaseUrl(vertexBaseUrl: "http://localhost:1454",
                             geminiBaseUrl: "http://localhost:1453");
    vertexClient = new Client(project: project, location: location, vertexAI: true,
                              credential: TestServer.GetCredentialForTestMode(),
                              httpOptions: vertexClientHttpOptions);
    geminiClient =
        new Client(apiKey: apiKey, vertexAI: false, httpOptions: geminiClientHttpOptions);


    // Specific setup for this test class
    modelName = "gemini-2.5-flash";
  }

  [TestMethod]
  public async Task TuneSimpleVertexTest() {
    var trainingDataset = new TuningDataset {
      GcsUri = "gs://cloud-samples-data/ai-platform/generative_ai/gemini-1_5/text/sft_train_data.jsonl"
    };
    var config = new CreateTuningJobConfig {
      EpochCount = 1
    };
    var tuningJob = await vertexClient.Tunings.TuneAsync(modelName, trainingDataset, config);

    Assert.IsNotNull(tuningJob);
  }

  [TestMethod]
  public async Task TunePreferenceTuningVertexTest() {
    var trainingDataset = new TuningDataset {
      GcsUri = "gs://cloud-samples-data/ai-platform/generative_ai/gemini-1_5/text/sft_train_data.jsonl"
    };
    var config = new CreateTuningJobConfig {
      TunedModelDisplayName = "Model display name",
      EpochCount = 1,
      Method = TuningMethod.PREFERENCE_TUNING,
    };
    var tuningJob = await vertexClient.Tunings.TuneAsync(modelName, trainingDataset, config);
    Assert.IsNotNull(tuningJob);
  }

  [TestMethod]
  public async Task TunePreferenceTuningGeminiTest() {
    var trainingDataset = new TuningDataset {
      GcsUri = "gs://cloud-samples-data/ai-platform/generative_ai/gemini-1_5/text/sft_train_data.jsonl"
    };
    var config = new CreateTuningJobConfig {
      TunedModelDisplayName = "Model display name",
      EpochCount = 1,
      Method = TuningMethod.PREFERENCE_TUNING,
    };
    var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () => {
      await geminiClient.Tunings.TuneAsync(modelName, trainingDataset, config);
    });

    StringAssert.Contains(ex.Message, "not supported in Gemini API");
  }

  [TestMethod]
  public async Task TunePreferenceTuningWithBetaVertexTest() {
    var trainingDataset = new TuningDataset {
      GcsUri = "gs://cloud-samples-data/ai-platform/generative_ai/gemini-1_5/text/sft_train_data.jsonl"
    };
    var config = new CreateTuningJobConfig {
      TunedModelDisplayName = "Model display name",
      EpochCount = 1,
      Method = TuningMethod.PREFERENCE_TUNING,
      Beta = 0.5,
    };
    var tuningJob = await vertexClient.Tunings.TuneAsync(modelName, trainingDataset, config);
    Assert.IsNotNull(tuningJob);
  }

  [TestMethod]
  public async Task TunePreferenceTuningWithBetaGeminiTest() {
    var trainingDataset = new TuningDataset {
      GcsUri = "gs://cloud-samples-data/ai-platform/generative_ai/gemini-1_5/text/sft_train_data.jsonl"
    };
    var config = new CreateTuningJobConfig {
      TunedModelDisplayName = "Model display name",
      EpochCount = 1,
      Method = TuningMethod.PREFERENCE_TUNING,
      Beta = 0.5,
    };
    var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () => {
      await geminiClient.Tunings.TuneAsync(modelName, trainingDataset, config);
    });

    StringAssert.Contains(ex.Message, "not supported in Gemini API");
  }

  [TestMethod]
  public async Task TuneWithConfigVertexTest() {
    var trainingDataset = new TuningDataset {
      GcsUri = "gs://cloud-samples-data/ai-platform/generative_ai/gemini-2_0/text/sft_train_data.jsonl"
    };
    var validationDataset = new TuningValidationDataset {
      GcsUri = "gs://cloud-samples-data/ai-platform/generative_ai/gemini-2_0/text/sft_validation_data.jsonl"
    };
    var config = new CreateTuningJobConfig {
      TunedModelDisplayName = "Tuned Model",
      EpochCount = 3,
      LearningRateMultiplier = 0.5,
      ValidationDataset = validationDataset,
    };
    var tuningJob = await vertexClient.Tunings.TuneAsync(modelName, trainingDataset, config);
    Assert.IsNotNull(tuningJob);
  }

  [TestMethod]
  public async Task TuneWithConfigGeminiTest() {
    var trainingDataset = new TuningDataset {
      GcsUri = "gs://cloud-samples-data/ai-platform/generative_ai/gemini-2_0/text/sft_train_data.jsonl"
    };
    var validationDataset = new TuningValidationDataset {
      GcsUri = "gs://cloud-samples-data/ai-platform/generative_ai/gemini-2_0/text/sft_validation_data.jsonl"
    };
    var config = new CreateTuningJobConfig {
      TunedModelDisplayName = "Tuned Model",
      EpochCount = 3,
      LearningRateMultiplier = 0.5,
      ValidationDataset = validationDataset,
    };
    var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () => {
      await geminiClient.Tunings.TuneAsync(modelName, trainingDataset, config);
    });

    StringAssert.Contains(ex.Message, "not supported in Gemini API");
  }

  [TestMethod]
  public async Task TuneSimpleGeminiTest() {
    var trainingDataset = new TuningDataset {
      GcsUri = "gs://cloud-samples-data/ai-platform/generative_ai/gemini-1_5/text/sft_train_data.jsonl"
    };
    var config = new CreateTuningJobConfig {
      EpochCount = 1
    };

    var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () => {
      await geminiClient.Tunings.TuneAsync(modelName, trainingDataset, config);
    });

    StringAssert.Contains(ex.Message, "not supported in Gemini API");
  }

  // TODO(ayushagra): Enable this test once the distillation e2e test is out of autopush.
  [TestMethod]
  public async Task TuneDistillationVertexTest() {
    Assert.Inconclusive("Vertex distillation test is currently only supported in autopush.");
    var baseModel = "meta/llama3_1@llama-3.1-8b-instruct";
    var trainingDataset = new TuningDataset {
      GcsUri = "gs://nathreya-oss-tuning-sdk-test/distillation-openai-opposites.jsonl"
    };
    var validationDataset = new TuningValidationDataset {
      GcsUri = "gs://nathreya-oss-tuning-sdk-test/distillation-val-openai-opposites.jsonl"
    };
    var config = new CreateTuningJobConfig {
      Method = TuningMethod.DISTILLATION,
      BaseTeacherModel = "deepseek-ai/deepseek-v3.1-maas",
      EpochCount = 20,
      ValidationDataset = validationDataset,
      OutputUri = "gs://nathreya-oss-tuning-sdk-test/ayushagra-distillation-test-folder",
      HttpOptions = new HttpOptions {
        ApiVersion = "v1beta1",
        BaseUrl = "https://us-central1-autopush-aiplatform.sandbox.googleapis.com/"
      }
    };

    var tuningJob = await vertexClient.Tunings.TuneAsync(baseModel, trainingDataset, config);

    Assert.IsNotNull(tuningJob);
  }

  [TestMethod]
  public async Task TuneDistillationGeminiTest() {
    var baseModel = "meta/llama3_1@llama-3.1-8b-instruct";
    var trainingDataset = new TuningDataset {
      GcsUri = "gs://nathreya-oss-tuning-sdk-test/distillation-openai-opposites.jsonl"
    };
    var config = new CreateTuningJobConfig {
      Method = TuningMethod.DISTILLATION,
      BaseTeacherModel = "deepseek-ai/deepseek-v3.1-maas",
    };

    var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () => {
      await geminiClient.Tunings.TuneAsync(baseModel, trainingDataset, config);
    });

    StringAssert.Contains(ex.Message, "not supported in Gemini API");
  }
}
