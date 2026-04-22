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


bool isVertex = args.Contains("--vertex", StringComparer.OrdinalIgnoreCase);
Console.WriteLine(isVertex ? "Running in Vertex AI mode." : "Running in Gemini API mode.");

Client client = new Client(vertexAI: isVertex);

if (isVertex)
{
    Console.WriteLine("Interactions API is not yet supported on Vertex AI");
    return;
}

SpeechConfig speechConfig = new()
{
    Voice = "achernar",
    Language = "en-US"
};

GenerationConfig generationConfig = new()
{
    SpeechConfig = new List<SpeechConfig> { speechConfig }
};

CreateModelInteraction params1 = new()
{
    Model = Model.Gemini25FlashPreviewTts,
    ResponseModalities = new List<ResponseModality> { ResponseModality.Audio },
    GenerationConfig = generationConfig,
    Input = InteractionsInput.CreateStr("Say cheerfully: Have a wonderful day!")
};

var response_interaction = await client.Interactions.CreateAsync(CreateInteractionRequestBody.CreateCreateModelInteraction(params1));
var interaction = response_interaction.Interaction;

Console.WriteLine($"Interaction ID: {interaction.Id}");
Console.WriteLine($"Status: {interaction.Status}");

if (interaction?.OutputAudio?.Data != null && interaction.OutputAudio.Data.Length > 100)
{
    Console.WriteLine($"Output: [Content with large data] Data={interaction.OutputAudio.Data.Substring(0, 100)}... [truncated]");
}
else if (interaction?.OutputAudio != null)
{
    Console.WriteLine($"Output: {interaction.OutputAudio.Data}");
}
