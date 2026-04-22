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
using Google.GenAI.Gaos.Models.Interactions;
using Google.GenAI.Gaos.Models.Requests;
using System.Text.Json;

bool isVertex = args.Contains("--vertex", StringComparer.OrdinalIgnoreCase);
Console.WriteLine(isVertex ? "Running in Vertex AI mode." : "Running in Gemini API mode.");

Client client = new Client(vertexAI: isVertex);

if (isVertex)
{
    Console.WriteLine("Interactions API is not yet supported on Vertex AI");
    return;
}

var format = new Dictionary<string, object>
{
    ["type"] = "array",
    ["description"] = "A list of colors"
};

CreateModelInteraction params1 = new()
{
    Model = Model.Gemini25Flash,
    Input = InteractionsInput.CreateStr("Which are the colors of a rainbow"),
    ResponseMimeType = "application/json",
    ResponseFormat = CreateModelInteractionResponseFormat.CreateResponseFormat(ResponseFormat.CreateMapOfAny(format))
};

var response_interaction = await client.Interactions.CreateAsync(CreateInteractionRequestBody.CreateCreateModelInteraction(params1));
var interaction = response_interaction.Interaction;

Console.WriteLine(interaction);
