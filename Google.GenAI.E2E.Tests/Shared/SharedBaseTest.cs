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
        // test-server proxy endpoints (see test-server.yml). The port determines which
        // upstream host the request is forwarded to, so it must agree with the location:
        // "global" resolves to aiplatform.googleapis.com, a region to
        // <region>-aiplatform.googleapis.com.
        private const string MldevProxyUrl = "http://localhost:1453";
        private const string VertexRegionalProxyUrl = "http://localhost:1454";
        private const string VertexGlobalProxyUrl = "http://localhost:1455";

        protected Client vertexClient;
        protected Client geminiClient;

        /// <summary>Flash is cheaper and faster than the corpus GEMINI_MODEL for API-mode runs.</summary>
        protected string modelName = "gemini-3.6-flash";

        /// <summary>
        /// Region a test class needs its Vertex client pinned to, or null to use
        /// GOOGLE_CLOUD_LOCATION as-is.
        ///
        /// Only applied when the configured location is "global", mirroring the Python
        /// shared suite (tests/conftest.py). Tuning is the one module that needs this:
        /// tuning jobs are not supported on the global endpoint.
        /// </summary>
        protected virtual string VertexLocationOverride => null;

        /// <summary>
        /// Retry options applied to every request both test clients make, so that a transient
        /// 5xx or 429 does not fail the nightly. Keep aligned with conftest.py in the Python
        /// SDK tests.
        /// </summary>
        private static HttpRetryOptions NewSharedTestRetryOptions() =>
            new HttpRetryOptions
            {
                Attempts = 3,
                InitialDelay = 1.0,
                MaxDelay = 10.0,
                ExpBase = 2.0,
                HttpStatusCodes = new List<int> { 408, 429, 500, 502, 503, 504 },
            };

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

            string project = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT") ?? "cloud-llm-preview1";
            string location = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_LOCATION") ?? "us-central1";

            // Pin to a region when this class requires one and the job is configured for
            // global (the nightly agent platform job). Leaves an already-regional
            // configuration untouched.
            if (!string.IsNullOrEmpty(VertexLocationOverride)
                && location.Equals("global", StringComparison.OrdinalIgnoreCase))
            {
                location = VertexLocationOverride;
            }

            // Route through the proxy endpoint that matches the resolved location.
            string vertexProxyUrl = location.Equals("global", StringComparison.OrdinalIgnoreCase)
                ? VertexGlobalProxyUrl
                : VertexRegionalProxyUrl;

            var geminiClientHttpOptions = new HttpOptions
            {
                Headers = new Dictionary<string, string> { { "Test-Name", recordingKey } },
                BaseUrl = MldevProxyUrl,
                RetryOptions = NewSharedTestRetryOptions()
            };
            var vertexClientHttpOptions = new HttpOptions
            {
                Headers = new Dictionary<string, string> { { "Test-Name", recordingKey } },
                BaseUrl = vertexProxyUrl,
                RetryOptions = NewSharedTestRetryOptions()
            };

            // GOOGLE_API_KEY is the variable every other GenAI SDK uses.
            string apiKey = System.Environment.GetEnvironmentVariable("GEMINI_API_KEY");
            if (string.IsNullOrEmpty(apiKey))
            {
                apiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
            }
            if (string.IsNullOrEmpty(apiKey))
            {
                // Never fall back to a placeholder: that records 400 API_KEY_INVALID.
                //
                // The agent platform job runs Vertex only, with no API key at all, so the
                // key is only required when the Gemini API backend will actually be used.
                bool vertexOnly = !string.IsNullOrEmpty(
                    System.Environment.GetEnvironmentVariable("GOOGLE_GENAI_RUN_VERTEX_ONLY_IN_API_MODE"));
                if (!TestServer.IsReplayMode && !vertexOnly)
                {
                    Assert.Fail(
                        "GEMINI_API_KEY (or GOOGLE_API_KEY) must be set when running against the live API.");
                }
                // Unused: replay mode is served from recordings, and Vertex-only runs never
                // touch the Gemini API client.
                apiKey = "unused-placeholder";
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
