/*
 * Copyright 2026 Google LLC
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

using Google.GenAI;
using Google.GenAI.Interactions.Models.Interactions;

namespace InteractionDeepResearch;

class Program
{
    static async Task Main(string[] args)
    {
        string? vertexAIEnv = System.Environment.GetEnvironmentVariable("GOOGLE_GENAI_USE_VERTEXAI");
        bool isVertexAI = vertexAIEnv != null && vertexAIEnv.ToLower() == "true";

        if (!isVertexAI)
        {
            Console.Error.WriteLine("Deep Research is only supported on Vertex AI. Please set GOOGLE_GENAI_USE_VERTEXAI=true.");
            return;
        }

        Client client = new Client(vertexAI: true);

        Console.WriteLine("--- Starting Deep Research Interaction ---");

        var interactions = client.Interactions.WithOptions(options =>
        {
            options.ApiVersion = "v1beta1";
            return options;
        });

        CreateAgentInteractionParams agentParams = new()
        {
            Agent = "deep-research-pro-preview-12-2025",
            Input = "I want to learn more about the history of Hadrian's Wall",
            Background = true,
        };

        var createParams = new InteractionCreateParams()
        {
            Body = agentParams
        };

        string? interactionId = null;

        Console.WriteLine("--- Sending Create Request ---");

        // We use CreateStreaming to see progress events
        await foreach (var messageEvent in interactions.CreateStreaming(createParams))
        {
            if (messageEvent.TryPickStart(out var startEvent))
            {
                interactionId = startEvent.Interaction.ID;
                Console.WriteLine($"Started Interaction ID: {interactionId}");
            }

            if (messageEvent.TryPickStatusUpdate(out var statusUpdate))
            {
                Console.WriteLine($"Event: StatusUpdate - {statusUpdate.Status}");
            }
            else if (messageEvent.TryPickContentDelta(out var contentDelta))
            {
                if (contentDelta.Delta.TryPickText(out var text))
                {
                    Console.Write(text.TextValue);
                }
                else
                {
                    Console.WriteLine("\n[Agent Activity]");
                }
            }
            else if (messageEvent.TryPickComplete(out var complete))
            {
                Console.WriteLine("\nEvent: Complete");
                break;
            }

            // We only want to capture the ID from the first few events and then we can let it run in background
            // or we can wait. The Java example limits to 1 event to capture ID and then resumes.
            // Let's mimic Java: capture ID from start event and then break to resume.
            if (interactionId != null)
            {
                break;
            }
        }

        if (interactionId == null)
        {
            Console.Error.WriteLine("Failed to capture interaction ID.");
            return;
        }

        Console.WriteLine($"\n--- Resuming Interaction: {interactionId} ---");

        // Resume the stream
        await foreach (var messageEvent in interactions.GetStreaming(interactionId))
        {
            if (messageEvent.TryPickStatusUpdate(out var statusUpdate))
            {
                Console.WriteLine($"\n[Status update: {statusUpdate.Status}]");
            }
            else if (messageEvent.TryPickContentDelta(out var contentDelta))
            {
                if (contentDelta.Delta.TryPickText(out var text))
                {
                    Console.Write(text.TextValue);
                }
                else
                {
                    Console.WriteLine("\n[Agent Activity]");
                }
            }
        }

        Console.WriteLine();
    }
}
