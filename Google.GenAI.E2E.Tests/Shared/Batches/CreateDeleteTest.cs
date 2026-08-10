using System.Collections.Generic;
using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.Shared.Batches
{
    [TestClass]
    public class CreateDeleteTest : SharedBaseTest
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
        public async Task TestCreateDeleteMldev()
        {
            SkipGeminiInApiMode();
            await RunLive(async () =>
            {
                var job = await geminiClient.Batches.CreateAsync(modelName, NewInlinedSource(), null);
                Assert.IsNotNull(job);
                Assert.IsFalse(string.IsNullOrEmpty(job.Name), "Created batch job should have a name.");

                // Delete on the happy path, and best-effort in the finally so a failed
                // assertion cannot leak a live batch job.
                bool deleted = false;
                try
                {
                    var deleteResponse = await geminiClient.Batches.DeleteAsync(job.Name);
                    Assert.IsNotNull(deleteResponse);
                    deleted = true;
                }
                finally
                {
                    if (!deleted)
                    {
                        await TryCleanupAsync(() => geminiClient.Batches.DeleteAsync(job.Name));
                    }
                }
            });
        }
    }
}
