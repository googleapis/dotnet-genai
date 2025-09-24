Google Gen AI .Net SDK provides an interface for developers to integrate
Google's generative models into their .Net applications. It supports the
[Gemini Developer API](https://ai.google.dev/gemini-api/docs) and
[Vertex AI](https://cloud.google.com/vertex-ai/generative-ai/docs/learn/overview)
APIs.

## Install

```
dotnet add package Google.GenAI
```

## Imports

```csharp
using Google.GenAI;
using Google.GenAI.Types;
```

## Create a client

Please run one of the following code blocks to create a client for
different services ([Gemini Developer API](https://ai.google.dev/gemini-api/docs) or [Vertex AI](https://cloud.google.com/vertex-ai/generative-ai/docs/learn/overview)).

```csharp
using Google.GenAI;

//  Only run this block for Gemini Developer API
var client = new Client(apiKey: apiKey);
```

```csharp
using Google.GenAI;

// only run this block for Vertex AI API
client = new Client(
    project: project, location: location, vertexAI: true
)
```

**(Optional) Using environment variables:**

You can create a client by configuring the necessary environment variables.
Configuration setup instructions depends on whether you're using the Gemini
Developer API or the Gemini API in Vertex AI.

**Gemini Developer API:** Set the `GOOGLE_API_KEY`. It will automatically be
picked up by the client.

```bash
export GEMINI_API_KEY='your-api-key'
```

**Gemini API on Vertex AI:** Set `GOOGLE_GENAI_USE_VERTEXAI`,
`GOOGLE_CLOUD_PROJECT` and `GOOGLE_CLOUD_LOCATION`, as shown below:

```bash
export GOOGLE_GENAI_USE_VERTEXAI=true
export GOOGLE_CLOUD_PROJECT='your-project-id'
export GOOGLE_CLOUD_LOCATION='us-central1'
```

```csharp
using Google.GenAI;

client = new Client();
```

## Types
Parameter types are specified in the `Google.GenAI.Types` namespace.

## Models
The `client.Models` module exposes model inferencing. See `Create a client`
section above to initialize a client.

### Generate Content

#### With simple text content

```csharp
var response = await client.Models.GenerateContentAsync(
        model: "gemini-2.0-flash", contents: "why is the sky blue?"
    );
```
