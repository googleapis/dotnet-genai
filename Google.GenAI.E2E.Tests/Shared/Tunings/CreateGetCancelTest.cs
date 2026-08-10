using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Tunings
{
    [TestClass]
    public class CreateGetCancelTest : SharedBaseTest
    {
        // Canonical tunings/create_get_cancel test: test_create_get_cancel.
        private const string TunableModelName = "gemini-3.1-flash-lite";
        private const string TrainingDatasetUri =
            "gs://cloud-samples-data/ai-platform/generative_ai/gemini-2_0/text/sft_train_data.jsonl";
        private static TuningDataset NewTrainingDataset() =>
            new TuningDataset { GcsUri = TrainingDatasetUri };

        private static CreateTuningJobConfig NewConfig() =>
            new CreateTuningJobConfig { EpochCount = 1 };

        [TestMethod]
        public async Task TestCreateGetCancelVertex()
        {
            SkipVertexInApiMode();
            await RunLive(async () =>
            {
                var tuningJob = await vertexClient.Tunings.TuneAsync(
                    TunableModelName, NewTrainingDataset(), NewConfig());
                Assert.IsNotNull(tuningJob);
                Assert.IsFalse(string.IsNullOrEmpty(tuningJob.Name),
                               "Submitted tuning job should have a name.");

                // Cancel in a finally: without it, a failure in Get leaves a real SFT
                // training job running.
                try
                {
                    var getJob = await vertexClient.Tunings.GetAsync(tuningJob.Name);
                    Assert.IsNotNull(getJob);
                    Assert.AreEqual(tuningJob.Name, getJob.Name);
                }
                finally
                {
                    await TryCleanupAsync(() => vertexClient.Tunings.CancelAsync(tuningJob.Name));
                }
            });
        }
    }
}
