# Changelog

## Version 0.4.0, released 2025-11-05


### New features

* Add FileSearch tool and associated FileSearchStore management APIs ([9869797](https://github.com/googleapis/dotnet-genai/commit/98697979ae6120f6ede560da21c9e5c6c7105648))
* Add RecontextImage support in Dotnet SDK ([f314213](https://github.com/googleapis/dotnet-genai/commit/f314213803c69a68eb63984883a51373e6501a5b))
* Add safety_filter_level and person_generation for Imagen upscaling ([299c8d3](https://github.com/googleapis/dotnet-genai/commit/299c8d390fa2b41ac0e67af65186b723e2406f06))
* Added phish filtering feature. ([deaf715](https://github.com/googleapis/dotnet-genai/commit/deaf715682d73a126e681163ca2df5ab1480532a))
* Auto-detect MIME type in Image.FromFile in Dotnet SDK ([8d0b59e](https://github.com/googleapis/dotnet-genai/commit/8d0b59ea127a56c1f01bbb4d882e910744729f84))


### Documentation improvements

* Add docstring for enum classes that are not supported in Gemini or Vertex API ([91da8bf](https://github.com/googleapis/dotnet-genai/commit/91da8bf2f93fdc10f8e6c4a5129ac1fff3bf9bf5))

## Version 0.3.0, released 2025-10-24


### New features

* Add enable_enhanced_civic_answers in GenerationConfig ([5eff838](https://github.com/googleapis/dotnet-genai/commit/5eff838364d5d1c0b3f7bd523a451bd2f7e08e58))
* Add Imagen EditImage support in Dotnet SDK ([3055dca](https://github.com/googleapis/dotnet-genai/commit/3055dcaf5874c76e8b5c2987b499d59bebfbd9ba))
* Add labels field to Imagen configs ([20ecf3f](https://github.com/googleapis/dotnet-genai/commit/20ecf3f9595549378fe4c805cb4316405e93df52))
* Add SegmentImage support in Dotnet SDK ([2201d74](https://github.com/googleapis/dotnet-genai/commit/2201d74da2eff6acaa8fb619143ccc18d2b663f0))
* Enable Google Maps tool for Genai. ([794fba8](https://github.com/googleapis/dotnet-genai/commit/794fba8642d78f56e38a0e12cbf8eb8d30645dc1))
* Support enableWidget feature in GoogleMaps ([7d4ff93](https://github.com/googleapis/dotnet-genai/commit/7d4ff935bd7031ac4f3572ccaa3323e99679255b))
* support jailbreak in HarmCategory and BlockedReason ([11210cf](https://github.com/googleapis/dotnet-genai/commit/11210cf753f09c58260c506f7c0a84f6df02a310))
* support netstandard2.1 build (fix [#56](https://github.com/googleapis/dotnet-genai/issues/56)) ([6803eeb](https://github.com/googleapis/dotnet-genai/commit/6803eeb80bfdb3173b1b602c4f391c5b0d7d7d8d))


### Documentation improvements

* Add docstring for classes and fields that are not supported in Gemini or Vertex API ([d1be9eb](https://github.com/googleapis/dotnet-genai/commit/d1be9ebb67394eae7cc8db5f78e9e545e31053bf))
* update full API reference GitHub Page in README ([353b288](https://github.com/googleapis/dotnet-genai/commit/353b2884d117e2cb8d9a46eb82a84990ab90db97))
* update README to reflect the support of netstandard2.1 ([ffb5c42](https://github.com/googleapis/dotnet-genai/commit/ffb5c4240dda5a5711345dd4c18105642225d010))
* update readme to trigger release please ([a916ba0](https://github.com/googleapis/dotnet-genai/commit/a916ba0a3e7ca183666040b8d6681d59e7f4886f))

## Changelog

### Features

* Add support for `GenerateContentAsync`, `GenerateContentStreamAsync`, `GenerateImagesAsync`, and 3 Live APIs, which includes `SendClientContentAsync`, `SendRealtimeInputAsync` and `SendToolResponseAsync`.([c9fbf99](https://github.com/googleapis/dotnet-genai/commit/c9fbf99b6bac159260ed66938854c4e8c211e910))

* Add `FunctionResponsePart` & `ToolComputerUse.excludedPredefinedFunctions`. ([29210c6](https://github.com/googleapis/dotnet-genai/commit/29210c64cdc8ff534ddbe49ef7e3d1b1861f2902))

### Documentation

* Automatically generate API documentation and host it in GitHub Pages([5538043](https://github.com/googleapis/dotnet-genai/commit/5538043ea91a2fad1bb75d14e08414dfe3a2d6b5))
