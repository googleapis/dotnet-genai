using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Tunings
{
    [TestClass]
    public class CreateTest : SharedBaseTest
    {
        // Canonical tunings/create test: test_tune. baseModel is "gemini-3.1-flash-lite" --
        // the previous "models/gemini-1.5-flash-001-tuning" was a retired model and used
        // Gemini-Developer-API path syntax against the Vertex client.
        private const string TunableModelName = "gemini-3.1-flash-lite";
        private const string TrainingDatasetUri =
            "gs://cloud-samples-data/ai-platform/generative_ai/gemini-2_0/text/sft_train_data.jsonl";
        private static TuningDataset NewTrainingDataset() =>
            new TuningDataset { GcsUri = TrainingDatasetUri };

        private static CreateTuningJobConfig NewConfig() =>
            new CreateTuningJobConfig { EpochCount = 1 };

        [TestMethod]
        public async Task TestCreateVertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                var tuningJob = await vertexClient.Tunings.TuneAsync(
                    TunableModelName, NewTrainingDataset(), NewConfig());
                Assert.IsNotNull(tuningJob);

                // Cancel the job we just submitted. Without this the nightly leaves a real
                // SFT training job running to completion every night, which is the single
                // most expensive resource leak in this suite.
                try
                {
                    Assert.IsFalse(string.IsNullOrEmpty(tuningJob.Name),
                                   "Submitted tuning job should have a name.");
                }
                finally
                {
                    if (!string.IsNullOrEmpty(tuningJob.Name))
                    {
                        await TryCleanupAsync(() => vertexClient.Tunings.CancelAsync(tuningJob.Name));
                    }
                }
            });
        }
    }
}
