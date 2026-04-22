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

using Google.GenAI;
using Google.GenAI.Gaos.Models.Interactions;
using Google.GenAI.Gaos.Models.Requests;

bool isVertex = args.Contains("--vertex", StringComparer.OrdinalIgnoreCase);
Console.WriteLine(isVertex ? "Running in Vertex AI mode." : "Running in Gemini API mode.");

Client client = new Client(vertexAI: isVertex);

CreateModelInteraction parameters = new()
{
    Input = InteractionsInput.CreateStr("Tell me a story in 300 words."),
    Model = Model.Gemini25Flash,
    Stream = true,
};

var response = await client.Interactions.CreateAsync(
    CreateInteractionRequestBody.CreateCreateModelInteraction(parameters)
);

var stream = response.InteractionSSEStreamEvent;
if (stream != null)
{
    while (true)
    {
        var sseEvent = await stream.Next();
        if (sseEvent == null) break;

        var stepDelta = sseEvent.GetDataStepDelta();
        var textDelta = stepDelta?.GetDeltaText();
        if (textDelta != null)
        {
            Console.Write(textDelta.Text);
        }
    }
}

Console.WriteLine();
