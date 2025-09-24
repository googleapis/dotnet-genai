This project demonstrates a real-time, voice-to-voice conversation with the
Gemini's live API. The architecture consists of three components: a frontend web
page (HTML/JavaScript) that captures microphone audio and plays responses, a
local ASP.NET Core server that acts as a WebSocket relay, and the remote Gemini
Live API which processes the audio. When you speak, your voice is streamed from
the browser to the local server, which forwards it to Gemini. Gemini's spoken
response is then streamed back through the server to the browser for immediate
playback, enabling a seamless conversational experience.

## Steps
1. assume you are in the directory of this README file.
2. `gcloud auth login` and follow the prompt to set up application default credential.
3. set your Google cloud project to env var `GOOGLE_CLOUD_PROJECT`.
4. set your Google cloud location to env var `GOOGLE_CLOUD_LOCATION`.
5. set your api key to env var `GOOGLE_API_KEY`.
5. run `dotnet run` to test Gemini API endpoint
6. run `dotnet run --vertex true` to test Vertex endpoint
7. click to http://localhost:5000 url in the terminal.
8. interact with the browser by talking to it.
