# RegisterFiles Sample

This sample demonstrates how to register files from Google Cloud Storage (GCS) for use with the Gemini Developer API (MLDev).

## Prerequisites

- An API key for the Gemini Developer API.
- Google Cloud credentials (ADC) with access to the GCS buckets you want to register.

## Setup

Set the following environment variable:

```bash
export GOOGLE_API_KEY="your-api-key"
```

Ensure you have authenticated with Google Cloud:

```bash
gcloud auth application-default login --scopes="https://www.googleapis.com/auth/cloud-platform,https://www.googleapis.com/auth/devstorage.read_only"
```

## Running the sample

```bash
dotnet run
```

## Note

`RegisterFiles` is only supported in the Gemini Developer client, not Vertex AI.
It requires OAuth credentials (GoogleCredential) even though the rest of the
client uses an API key.