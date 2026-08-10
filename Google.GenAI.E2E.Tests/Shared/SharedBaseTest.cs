using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared
{
    /// <summary>
    /// Base class for the curated "shared" integration tests, mirrored from
    /// google/cloud/aiplatform/sdk/genai/replays/tests/shared and run by the nightly
    /// API-mode job. See go/genai-sdk:integration-testing.
    /// </summary>
    public abstract class SharedBaseTest
    {
        protected Client vertexClient;
        protected Client geminiClient;

        /// <summary>Flash is cheaper and faster than the corpus GEMINI_MODEL for API-mode runs.</summary>
        protected string modelName = "gemini-3.6-flash";

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void SetupClients()
        {
            // This suite ships no recordings: it exists to exercise the live backends from
            // the nightly API-mode jobs, so it is skipped in replay mode. The tests are still
            // compiled, so a break is caught at build time.
            if (TestServer.IsReplayMode)
            {
                Assert.Inconclusive(
                    "Skipping shared integration tests in replay mode: this suite ships no "
                        + "recordings and runs live in the nightly jobs.");
            }

            // Recording key. Namespace-qualified so that classes sharing a simple name
            // across feature folders cannot overwrite each other's recording.
            var recordingKey = $"{GetType().FullName}.{TestContext.TestName}";

            var geminiClientHttpOptions = new HttpOptions
            {
                Headers = new Dictionary<string, string> { { "Test-Name", recordingKey } },
                BaseUrl = "http://localhost:1453"
            };
            var vertexClientHttpOptions = new HttpOptions
            {
                Headers = new Dictionary<string, string> { { "Test-Name", recordingKey } },
                BaseUrl = "http://localhost:1454"
            };

            string project = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT") ?? "cloud-llm-preview1";
            string location = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_LOCATION") ?? "us-central1";

            // GOOGLE_API_KEY is the variable every other GenAI SDK uses.
            string apiKey = System.Environment.GetEnvironmentVariable("GEMINI_API_KEY");
            if (string.IsNullOrEmpty(apiKey))
            {
                apiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
            }
            if (string.IsNullOrEmpty(apiKey))
            {
                // Never fall back to a placeholder: that records 400 API_KEY_INVALID.
                if (!TestServer.IsReplayMode)
                {
                    Assert.Fail(
                        "GEMINI_API_KEY (or GOOGLE_API_KEY) must be set when running against the live API.");
                }
                // Replay mode never reaches the network; the proxy serves recorded responses.
                apiKey = "replay-mode-placeholder";
            }

            vertexClient = new Client(project: project, location: location, vertexAI: true,
                                      credential: TestServer.GetCredentialForTestMode(),
                                      httpOptions: vertexClientHttpOptions);
            geminiClient = new Client(apiKey: apiKey, vertexAI: false, httpOptions: geminiClientHttpOptions);
        }

        /// <summary>
        /// Skips the current test when the job has selected the other backend, via
        /// GOOGLE_GENAI_RUN_{VERTEX,GEMINI}_ONLY_IN_API_MODE. When neither is set, both run.
        /// </summary>
        protected void SkipIfBackendDisabled(bool isVertex)
        {
            // Replay mode never reaches here: SetupClients already skips the whole suite.
            bool vertexOnly = !string.IsNullOrEmpty(
                System.Environment.GetEnvironmentVariable("GOOGLE_GENAI_RUN_VERTEX_ONLY_IN_API_MODE"));
            bool geminiOnly = !string.IsNullOrEmpty(
                System.Environment.GetEnvironmentVariable("GOOGLE_GENAI_RUN_GEMINI_ONLY_IN_API_MODE"));

            if (isVertex && geminiOnly)
            {
                Assert.Inconclusive("Skipping Vertex AI tests in API mode (GEMINI ONLY config enabled).");
            }
            else if (!isVertex && vertexOnly)
            {
                Assert.Inconclusive("Skipping Gemini API tests in API mode (VERTEX ONLY config enabled).");
            }
        }

        /// <summary>Skip guard for a Vertex AI / Agent Platform backed test.</summary>
        protected void SkipVertexInApiMode() => SkipIfBackendDisabled(isVertex: true);

        /// <summary>Skip guard for a Gemini API (mldev) backed test.</summary>
        protected void SkipGeminiInApiMode() => SkipIfBackendDisabled(isVertex: false);

        /// <summary>True when the exception is a 429 RESOURCE_EXHAUSTED quota error.</summary>
        protected static bool IsQuotaError(Exception e)
        {
            if (e == null)
            {
                return false;
            }
            if (e is ClientError ce && (ce.StatusCode == 429 || ce.Status == "RESOURCE_EXHAUSTED"))
            {
                return true;
            }
            return e.Message != null && e.Message.Contains("RESOURCE_EXHAUSTED");
        }

        /// <summary>
        /// Marks the test inconclusive rather than failing on a 429, which indicates quota
        /// rather than a regression.
        /// </summary>
        protected static void SkipOnQuota(Exception e)
        {
            if (IsQuotaError(e))
            {
                Assert.Inconclusive($"Resource exhausted (429). Skipping test instead of failing: {e.Message}");
            }
        }

        /// <summary>
        /// Runs a live call, converting a 429 into an inconclusive result.
        /// </summary>
        protected static async Task RunLive(Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (Exception e)
            {
                SkipOnQuota(e);
                throw;
            }
        }

        /// <summary>Best-effort cleanup that never masks the real test result.</summary>
        protected static async Task TryCleanupAsync(Func<Task> cleanup)
        {
            try
            {
                await cleanup();
            }
            catch (Exception e)
            {
                Console.WriteLine($"[cleanup] ignored failure: {e.Message}");
            }
        }
    }
}
