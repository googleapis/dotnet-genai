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

using System;
using System.Text.Json;
using Google.GenAI;
using Google.GenAI.Types;

Console.WriteLine("Verifying Native AOT compatibility...");
var client = new Client(apiKey: "fake-test-key");
Console.WriteLine($"Client initialized: {client != null}");
Console.WriteLine($"Models available: {client.Models != null}");

var customOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
var parsedContent = Content.FromJson("{\"parts\":[{\"text\":\"Hello AOT\"}]}", customOptions);
if (parsedContent?.Parts?[0]?.Text != "Hello AOT")
{
    throw new Exception("Failed to deserialize Content with custom JsonSerializerOptions under AOT.");
}
Console.WriteLine($"Content.FromJson with custom options verified: {parsedContent.Parts[0].Text}");

var readOnlyOptions = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
    TypeInfoResolver = System.Text.Json.Serialization.Metadata.JsonTypeInfoResolver.Combine()
};
readOnlyOptions.MakeReadOnly();
var readOnlyContent = Content.FromJson("{\"parts\":[{\"text\":\"Hello AOT ReadOnly\"}]}", readOnlyOptions);
if (readOnlyContent?.Parts?[0]?.Text != "Hello AOT ReadOnly")
{
    throw new Exception("Failed to deserialize Content with read-only JsonSerializerOptions under AOT.");
}
Console.WriteLine($"Content.FromJson with read-only options verified: {readOnlyContent.Parts[0].Text}");

#if TEST_INTERACTIONS
// This code path tests that Interactions access produces compile/trim warnings when compiled with Native AOT
var interactions = client.Interactions;
Console.WriteLine($"Interactions: {interactions != null}");
#endif
