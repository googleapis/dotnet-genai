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

using System.Text;
using Google.GenAI;
using Google.GenAI.Gaos.Models.Environments;
using Google.GenAI.Gaos.Models.Interactions;

bool isVertex = args.Contains("--vertex", StringComparer.OrdinalIgnoreCase);
if (isVertex)
{
    Console.WriteLine("Environment Files API is currently supported on Gemini API (MLDev). Skipping on Vertex.");
    return;
}

Console.WriteLine("Using Gemini Developer API (v1alpha)");
var httpOptions = new Google.GenAI.Types.HttpOptions { ApiVersion = "v1alpha" };
var baseUrl = System.Environment.GetEnvironmentVariable("GOOGLE_GENAI_BASE_URL");
if (!string.IsNullOrEmpty(baseUrl))
{
    httpOptions.BaseUrl = baseUrl;
}
Client client = new Client(vertexAI: false, httpOptions: httpOptions);

Console.WriteLine("\n--- 1. Creating Environment with Workspace Files ---");
var createReq = new CreateEnvironmentRequest
{
    Network = CreateEnvironmentRequestNetworkUnion.CreateCreateEnvironmentRequestNetworkEnum(CreateEnvironmentRequestNetworkEnum.Disabled),
    Sources =
    [
        new Source
        {
            Type = SourceType.Inline,
            Target = "main.py",
            Content = "print(\"Hello from .NET Environment Files demo!\")\n",
        },
        new Source
        {
            Type = SourceType.Inline,
            Target = "config.json",
            Content = "{\"version\": \"1.0\", \"debug\": true}\n",
        },
        new Source
        {
            Type = SourceType.Inline,
            Target = "src/utils.py",
            Content = "def greet(name: str) -> str:\n    return f\"Hello, {name}!\"\n",
        },
    ]
};

var createResponse = await client.Environments.CreateEnvironmentAsync(createReq);
var envId = createResponse?.Environment?.Id ?? throw new InvalidOperationException("No environment ID returned.");
Console.WriteLine($"Environment created successfully! ID: {envId}");

try
{
    Console.WriteLine("\n--- 2. Listing Files at Root Directory (path=\".\") ---");
    var rootFilesResponse = await client.Environments.Files.ListAsync(envId, path: ".");
    foreach (var file in rootFilesResponse?.GetEnvironmentFilesResponseValue?.Files ?? [])
    {
        Console.WriteLine($" - {file.Name} (type={file.Type?.ToString() ?? "unknown"}, size={file.SizeBytes ?? "unknown"} bytes)");
    }

    Console.WriteLine("\n--- 3. Querying Subdirectory (path=\"src\", recursive=true) ---");
    var srcFilesResponse = await client.Environments.Files.ListAsync(envId, path: "src", recursive: true);
    foreach (var file in srcFilesResponse?.GetEnvironmentFilesResponseValue?.Files ?? [])
    {
        Console.WriteLine($" - {file.Name} (path={file.Path})");
    }

    Console.WriteLine("\n--- 4. Querying Specific File Path (path=\"main.py\") ---");
    var mainFileResponse = await client.Environments.Files.ListAsync(envId, path: "main.py");
    foreach (var file in mainFileResponse?.GetEnvironmentFilesResponseValue?.Files ?? [])
    {
        Console.WriteLine($"main.py file size: {file.SizeBytes ?? "0"} bytes");
    }

    Console.WriteLine("\n--- 5. Uploading a New File (path=\"uploaded.txt\") ---");
    byte[] contentToUpload = Encoding.UTF8.GetBytes("Hello from .NET Environment Files upload demo!\n");
    var uploadResponse = await client.Environments.Files.UploadAsync(envId, "uploaded.txt", contentToUpload, "text/plain");
    Console.WriteLine($"Uploaded file name: {uploadResponse?.Files?.Files?[0]?.Name ?? "unknown"}");

    Console.WriteLine("\n--- 6. Downloading File Content (path=\"uploaded.txt\") ---");
    byte[] downloadedBytes = await client.Environments.Files.DownloadAsync(envId, "uploaded.txt");
    Console.WriteLine($"Downloaded uploaded.txt content:\n{Encoding.UTF8.GetString(downloadedBytes).Trim()}");
}
finally
{
    Console.WriteLine($"\n--- 7. Cleaning up Environment ID: {envId} ---");
    var deleteResponse = await client.Environments.DeleteEnvironmentAsync(envId);
    Console.WriteLine("Environment deleted successfully.");
}
