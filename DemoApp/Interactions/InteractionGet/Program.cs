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

bool isVertex = args.Contains("--vertex", StringComparer.OrdinalIgnoreCase);
Console.WriteLine(isVertex ? "Running in Vertex AI mode." : "Running in Gemini API mode.");

Client client = new Client(vertexAI: isVertex);

if (isVertex)
{
    Console.WriteLine("Interactions API is not yet supported on Vertex AI");
    return;
}

// First, create an interaction to get an ID.
CreateModelInteractionParams createParams = new()
{
    Input = "Why is the sky blue?",
    Model = Model.Gemini2_5Flash,
};

Interaction createdInteraction = await client.Interactions.Create(new() { Body = createParams });
string id = createdInteraction.ID;
Console.WriteLine($"Created Interaction ID: {id}");

// Now, retrieve the interaction using the ID.
Interaction retrievedInteraction = await client.Interactions.Get(id);
Console.WriteLine($"Retrieved Interaction ID: {retrievedInteraction.ID}");
Console.WriteLine($"Status: {retrievedInteraction.Status}");

// Print the text outputs from the retrieved interaction.
foreach (var output in retrievedInteraction?.Outputs ?? [])
{
    if (output.TryPickText(out var text))
    {
        Console.WriteLine($"Output: {text.Text}");
    }
}
