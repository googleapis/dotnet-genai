Google Gen AI .Net SDK provides an interface for developers to integrate
Google's generative models into their .Net applications. It supports the
[Gemini Developer API](https://ai.google.dev/gemini-api/docs) and
[Vertex AI](https://cloud.google.com/vertex-ai/generative-ai/docs/learn/overview)
APIs.

## Supported .NET version

This library is built for and requires .NET 8.0 or a later compatible version.

## Full API Reference

The full API reference is hosted in the [dedicated GitHub Page for this repo](https://googleapis.github.io/dotnet-genai/api/index.html)

## Install
In your dotnet project directory, type the the following command

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
using Google.GenAI;
using Google.GenAI.Types;

public class GenerateContentSimpleText {
  public static async Task main() {
    // assuming credentials are set up in environment variables as instructed above.
    var client = new Client();
    var response = await client.Models.GenerateContentAsync(
      model: "gemini-2.0-flash", contents: "why is the sky blue?"
    );
    Console.WriteLine(response.Candidates[0].Content.Parts[0].Text);
  }
}
```
#### System Instructions and Other Configs

The output of the model can be influenced by several optional settings
available in GenerateContentAsync's config parameter. For example, to make a model more
deterministic, lowering the `Temperature` parameter reduces randomness, with
values near 0 minimizing variability. Capabilities and parameter defaults for
each model is shown in the
[Vertex AI docs](https://cloud.google.com/vertex-ai/generative-ai/docs/models/gemini/2-5-flash)
and [Gemini API docs](https://ai.google.dev/gemini-api/docs/models) respectively.

```csharp
using Google.GenAI;
using Google.GenAI.Types;

public class GenerateContentWithConfig {
  public static async Task main() {
    // assuming credentials are set up in environment variables as instructed above.
    var client = new Client();
    var generateContentConfig =
    new GenerateContentConfig {
        SystemInstruction = new Content
        {
          Parts = new List<Part> {
              new Part {Text = "I say high you say low."}
          }
        },
        Temperature = 0.1,
        MaxOutputTokens = 3
    };
    var response = await client.Models.GenerateContentAsync(
        model: "gemini-2.0-flash",
        contents: "high",
        config: generateContentConfig
    );
    Console.WriteLine(response.Candidates[0].Content.Parts[0].Text);
  }
}

```

#### Safety Settings

```csharp
using Google.GenAI;
using Googel.GenAI.Types;

class GenerateContentWithSafetySettings {
  public static async Task main() {
    // assuming credentials are set up in environment variables as instructed above.
    var client = new Client();

    var safetySettings = new List<SafetySetting> {
      new SafetySetting {
        Category = HarmCategory.HARM_CATEGORY_HATE_SPEECH,
        Threshold = HarmBlockThreshold.BLOCK_LOW_AND_ABOVE
      }
    };
    var generateContentConfig = new GenerateContentConfig
    {
      SafetySettings =  new List<SafetySetting>(safetySettings)
    };
    var response = await client.Models.GenerateContentAsync(
        model: "gemini-2.0-flash",
        contents: "say something hateful",
        config: generateContentConfig
    );
    Console.WriteLine(response.Candidates[0].SafetyRatings);
  }
}
```

#### Json response scehema

However you define your schema, don't duplicate it in your input prompt,
including by giving examples of expected JSON output. If you do, the generated
output might be lower in quality.

```csharp
using Goolge.GenAI;
using Google.GenAI.Types;

public class GenerateContentWithJsonSchema {
  public static async Task main() {
    // assuming credentials are set up in environment variables as instructed above.
    var client = new Client();

    // define the response schema you desire
    Schema countryInfo = new Schema {
      Properties =
        new Dictionary<string, Schema> {
          {
            "title", new Schema { Type = Type.STRING, Title = "Title" }
          },
          {
            "population", new Schema { Type = Type.INTEGER, Title = "Population" }
          },
          {
            "capital", new Schema { Type = Type.STRING, Title = "Capital" }
          },
          {
            "continent", new Schema { Type = Type.STRING, Title = "Continent" }
          },
          {
            "language", new Schema { Type = Type.STRING, Title = "Language" }
          }
        },
      PropertyOrdering =
          new List<string> { "title", "population", "capital", "continent", "language" },
      Required = new List<string> { "title", "population", "capital", "continent", "language" },
      Title = "CountryInfo", Type = Type.OBJECT
    };

    var response = await client.Models.GenerateContentAsync(
        model: "gemini-2.0-flash",
        contents: "Give me information about Australia",
        config: new GenerateContentConfig {
            ResponseMimeType = "application/json",
            ResponseSchema = countryInfo
        }
    );

    string text = response.Candidates[0].Content.Parts[0].Text;
    var parsedText = JsonSerializer.Deserialize<Dictionary<string, object>>(text);
    Console.WriteLine(parsedText);
  }
}

```

### Generate Content Stream

The usage of GenerateContentStreamAsync is similar to GenerateContentAsync, this section shows one simple example to showcase the nuance in the usage.

```csharp
using Google.GenAI;
using Google.GenAI.Types;

class GenerateContentStreamSimpleText {
  public static async Task main() {

    // assuming credentials are set up in environment variables as instructed above.
    var client = new Client();
    await foreach (var chunk in client.Models.GenerateContentStreamAsync(
        model: "gemini-2.0-flash",
        contents: "why is the sky blue?"
    )) {
        Console.WriteLine(chunk.Candidates[0].Content.Parts[0].Text);
    }
  }
}

```

### Generate Images

```csharp
using Google.GenAI;
using Google.GenAI.Types;

public class GenerateImagesSimple {
  public static async Task main() {
    // assuming credentials are set up in environment variables as instructed above.
    var client = new Client();
    var generateImagesConfig = new GenerateImagesConfig
    {
      NumberOfImages = 1,
      AspectRatio = "1:1",
      SafetyFilterLevel = SafetyFilterLevel.BLOCK_LOW_AND_ABOVE,
      PersonGeneration = PersonGeneration.DONT_ALLOW,
      IncludeSafetyAttributes = true,
      IncludeRaiReason = true,
      OutputMimeType = "image/jpeg",
    };
    var response = await client.Models.GenerateImagesAsync(
      model: "imagen-3.0-generate-002",
      prompt: "Red skateboard",
      config: generateImagesConfig
    );
    // Do something with the generated image
    var image = response.GeneratedImages.First().Image;
  }
}
```

### Upscale Image

Upscaling an image is only supported on the Vertex AI client.

```csharp
using Google.GenAI;
using Google.GenAI.Types;

public class UpscaleImageSimple {
  public static async Task main() {
    // assuming credentials are set up in environment variables as instructed above.
    var client = new Client();
    var upscaleImageConfig = new UpscaleImageConfig {
      OutputMimeType = "image/jpeg", EnhanceInputImage = true
    };
    var image; // Image to upscale here
    var response = await client.Models.UpscaleImageAsync(
      model: modelName, image: image, upscaleFactor: "x2",
      config: upscaleImageConfig);

    // Do something with the generated image
    var image = response.GeneratedImages.First().Image;
  }
}
```