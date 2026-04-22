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
using Google.GenAI.Interactions.Core;

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

CreateModelInteractionParams params1 = new()
{
    Model = "gemini-2.5-flash-preview-tts",
    ResponseModalities = new List<ApiEnum<string, ResponseModality>> { (ApiEnum<string, ResponseModality>)ResponseModality.Audio },
    GenerationConfig = generationConfig,
    Input = "Say cheerfully: Have a wonderful day!"
};

Interaction interaction = await client.Interactions.Create(new() { Body = params1 });

Console.WriteLine($"Interaction ID: {interaction.ID}");
Console.WriteLine($"Status: {interaction.Status}");

foreach (var output in interaction?.Outputs ?? [])
{
    if (output.Data != null && output.Data.Length > 100)
    {
        Console.WriteLine($"Output: [Content with large data] Data={output.Data.Substring(0, 100)}... [truncated]");
    }
    else
    {
        Console.WriteLine($"Output: {output}");
    }
}
