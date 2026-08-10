using System.Collections.Generic;
using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Batches
{
    [TestClass]
    public class CreateGetCancelTest : SharedBaseTest
    {
        private static BatchJobSource NewInlinedSource()
        {
            return new BatchJobSource
            {
                InlinedRequests = new List<InlinedRequest>
                {
                    new InlinedRequest
                    {
                        Contents = new List<Content>
                        {
                            new Content
                            {
                                Parts = new List<Part> { new Part { Text = "Why is the sky blue?" } },
                                Role = "user"
                            }
                        }
                    }
                }
            };
        }

        [TestMethod]
        public async Task TestCreateGetCancelMldev()
        {
            SkipGeminiInApiMode();
            await RunLive(async () =>
            {
                var job = await geminiClient.Batches.CreateAsync(modelName, NewInlinedSource(), null);
                Assert.IsNotNull(job);
                Assert.IsFalse(string.IsNullOrEmpty(job.Name), "Created batch job should have a name.");

                // Cancel in a finally so a failed assertion cannot leak a running job.
                try
                {
                    var getJob = await geminiClient.Batches.GetAsync(job.Name);
                    Assert.IsNotNull(getJob);
                    Assert.AreEqual(job.Name, getJob.Name);
                }
                finally
                {
                    await TryCleanupAsync(() => geminiClient.Batches.CancelAsync(job.Name));
                    await TryCleanupAsync(() => geminiClient.Batches.DeleteAsync(job.Name));
                }
            });
        }
    }
}
