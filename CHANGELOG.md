# Changelog

## Version 1.5.0, released 2026-03-18


### New features

* Support include_server_side_tool_invocations for genai. ([c304c12](https://github.com/googleapis/dotnet-genai/commit/c304c12289e1c0ce74e6f810481217900b742814))
* Update to Microsoft.Extensions.AI.Abstractions 10.4.0 ([#247](https://github.com/googleapis/dotnet-genai/issues/247)) ([b16b93f](https://github.com/googleapis/dotnet-genai/commit/b16b93f7f20409b552ff720cbfe412bef2e7e644))


### Bug fixes

* use deep copy in Common.cs to avoid large string operation that introduces OutOfMemeory exceptions ([501e586](https://github.com/googleapis/dotnet-genai/commit/501e5864904364000cfa910a56859047231477c5))

## Version 1.4.0, released 2026-03-12


### New features

* Add inference_generation_config to EvaluationConfig for Tuning ([9c46031](https://github.com/googleapis/dotnet-genai/commit/9c460311d71e70e23b5c29e691e9499d521b4257))
* Allow custom endpoints for authentication with Vertex AI in C# ([da18a06](https://github.com/googleapis/dotnet-genai/commit/da18a068076682354faf52c9098d6a778e70c74a))
* enable language code for audio transcription config in Live API for Vertex AI ([e723b0a](https://github.com/googleapis/dotnet-genai/commit/e723b0a61db33949057111b3e644d28f05c13eb6))
* Implement RegisterFiles ([aa946e4](https://github.com/googleapis/dotnet-genai/commit/aa946e43c783f9e97ad5c27fa5bde44a43225e63))


### Bug fixes

* Compilation for .NET SDK versions 8.0.300 and 8.0.301 ([2ec2fd5](https://github.com/googleapis/dotnet-genai/commit/2ec2fd5d56d2587ead922ac5ed3841df9684c461))

## Version 1.3.0, released 2026-03-02


### New features

* create Part.FromText, Part.FromUri, Part.FromBytes, Part.FromFunctionCall, Part.FromFunctionResponse, Part.FromExecutableCode, Part.FromCodeExecutionResult, quick accessors to facilitate fast Part record creation ([bc4203e](https://github.com/googleapis/dotnet-genai/commit/bc4203e206dadf33b1c7287f8dd12958768298b9))
* include response.Text, response.FunctionCalls, response.ExecutableCode, response.CodeExecutionResult response.Parts quick accessor to GenerateContentResponse record ([94b99d6](https://github.com/googleapis/dotnet-genai/commit/94b99d64a1ad4989b28086e7f78003cb4e737f50))
* Update data types from discovery doc. ([b9218ac](https://github.com/googleapis/dotnet-genai/commit/b9218ac8b1ac941969f984845845a954eeb1cd1e))


### Bug fixes

* Use response ID as message ID in chat client implementation ([df5231e](https://github.com/googleapis/dotnet-genai/commit/df5231e5a4c1c47d99f0aa4c045157040239ea88))

## Version 1.2.0, released 2026-02-25


### New features

* Add Image Grounding support to GoogleSearch tool ([2c81645](https://github.com/googleapis/dotnet-genai/commit/2c8164584b2a48da69ed88fd5a9b1b1bed45d801))
* enable server side MCP and disable all other AFC when server side MCP is configured. ([46ca4c1](https://github.com/googleapis/dotnet-genai/commit/46ca4c191b8623c81f38e2602954a2bbfc208b33))

## Version 1.1.0, released 2026-02-19


### New features

* Support multimodal embedding for Gemini Embedding 2.0 and support MaaS models in Models.embed_content() (Vertex AI API) ([0af5cf5](https://github.com/googleapis/dotnet-genai/commit/0af5cf527989fb4ae6bc782afae51fc7f7fc3ea8))
* Update to M.E.AI.Abstractions 10.3.0 and add reasoning support ([2d51687](https://github.com/googleapis/dotnet-genai/commit/2d516870b37eac6dbe576f44f4ddc8b028be1093))

## Version 1.0.0, released 2026-02-12


### ⚠ BREAKING CHANGES

* Refactor enums to use smart string struct representations for forward compatibility, change enum value names from UPPER_SNAKE_CASE to PascalCase to conform to Dotnet naming conventions

### New features

* enable cancellation token ([#86](https://github.com/googleapis/dotnet-genai/issues/86)) ([c409d99](https://github.com/googleapis/dotnet-genai/commit/c409d991c58c5aa47de9c57a6a86e3c00a3f4c46))
* Refactor enums to use smart string struct representations for forward compatibility, change enum value names from UPPER_SNAKE_CASE to PascalCase to conform to Dotnet naming conventions ([14fb35b](https://github.com/googleapis/dotnet-genai/commit/14fb35b43507273baca1fa9138be80b22dd2bcf1))
* Support encryption_spec in tuning job creation configuration for GenAI SDK ([c5ac0d2](https://github.com/googleapis/dotnet-genai/commit/c5ac0d2dfada6ebefabbf55038752350b04a4a31))


### Miscellaneous chores

* release 1.0.0 ([d6277aa](https://github.com/googleapis/dotnet-genai/commit/d6277aa3c864a6db8a972e2fc1b6e7d2060ae5f3))


### Documentation improvements

* Add docstrings to C# and Python SDK Operations methods. ([06e84cd](https://github.com/googleapis/dotnet-genai/commit/06e84cd6e56fa19b8c58a031a0d7fd34438183fa))
* fix typo in readme ([#179](https://github.com/googleapis/dotnet-genai/issues/179)) ([43f2c02](https://github.com/googleapis/dotnet-genai/commit/43f2c02bf3dafd3b8d918f31b8e70609debd67f4))
* update cancellation token docs ([008b666](https://github.com/googleapis/dotnet-genai/commit/008b666f36e30204b761ed817030c4257e3a82d7))

## Version 0.15.0, released 2026-02-04


### New features

* Update data types from discovery doc. ([e504eb8](https://github.com/googleapis/dotnet-genai/commit/e504eb8285657a71dffed9bb3abdbb4731fc6844))


### Documentation improvements

* Update Dotnet Test Server usage caveats for recording redaction in E2E test dev guide ([6f517b6](https://github.com/googleapis/dotnet-genai/commit/6f517b67c86500202c9e274e74f8acf944886df0))

## Version 0.14.0, released 2026-01-30


### New features

* Support distillation tuning ([1c6c012](https://github.com/googleapis/dotnet-genai/commit/1c6c012ac4e8fee31508edb95e62758ab017a826))
* Support OSS Tuning in GenAI SDK ([2e897ed](https://github.com/googleapis/dotnet-genai/commit/2e897ed6b02915b3f82deb781956cee59af53c5f))


### Bug fixes

* Add metadata in batch inlined response ([4d3e138](https://github.com/googleapis/dotnet-genai/commit/4d3e138ad21e6ce78586474594e3404b98e2f342))

## Version 0.13.1, released 2026-01-22


### Bug fixes

* use converter to parse LiverServerMessage ([2420c8b](https://github.com/googleapis/dotnet-genai/commit/2420c8b57f3b2f778679196d12008663deabaa3b))

## Version 0.13.0, released 2026-01-18


### New features

* Add ModelArmorConfig support for prompt and response sanitization via the Model Armor service ([8c8ab76](https://github.com/googleapis/dotnet-genai/commit/8c8ab768fd4723958728d276f4d1d08fe5eef055))
* Update data types from discovery doc. ([5e95a01](https://github.com/googleapis/dotnet-genai/commit/5e95a012247f1eab30936f6d6b29740675c762a8))
* Update data types from discovery doc. ([ee91b30](https://github.com/googleapis/dotnet-genai/commit/ee91b30a17c695203c15dcd9ad91c96b332d60f5))

## Version 0.12.0, released 2026-01-15


### New features

* voice activity support ([ca3ce95](https://github.com/googleapis/dotnet-genai/commit/ca3ce95e48f1fc6dff23110385dd124d887f0b47))

## Version 0.11.0, released 2026-01-14


### New features

* Add Microsoft.Extensions.AI implementations to Google.GenAI ([e39b1f5](https://github.com/googleapis/dotnet-genai/commit/e39b1f540ec1895ea35fb7a52dc30116a57090ba))

## Version 0.10.0, released 2026-01-07


### ⚠ BREAKING CHANGES

* replace netstandard2.1 target with netstandard2.0

### New features

* Add minimal and medium thinking levels. ([60ba497](https://github.com/googleapis/dotnet-genai/commit/60ba49781b9d75ed2a2de9e274cb68d16197f5e9))
* Add minimal and medium thinking levels. ([e8e5fb2](https://github.com/googleapis/dotnet-genai/commit/e8e5fb264873e9508dd890eaa3ca4057fee886a2))
* Add minimal and medium thinking levels. ([06f8a92](https://github.com/googleapis/dotnet-genai/commit/06f8a9242034c08dfe9fdc6e068c15a498423e19))
* Add PersonGeneration to ImageConfig for Vertex Gempix ([d147baa](https://github.com/googleapis/dotnet-genai/commit/d147baa9f4aaa6ed7687c2c2b3c2099d68f834fe))
* Add Support for .Net Standard 2.0 ([35248b5](https://github.com/googleapis/dotnet-genai/commit/35248b52ac4a0c669cfc6a183b7d42454ccecbf0))
* Add Support for .Net Standard 2.0 ([35248b5](https://github.com/googleapis/dotnet-genai/commit/35248b52ac4a0c669cfc6a183b7d42454ccecbf0))
* Add Support for .Net Standard 2.0 ([#90](https://github.com/googleapis/dotnet-genai/issues/90)) ([aa628a0](https://github.com/googleapis/dotnet-genai/commit/aa628a0fa2e093dc600deed16c55bd728516b839))
* Add ultra high resolution to the media resolution in Parts. ([f9a971f](https://github.com/googleapis/dotnet-genai/commit/f9a971f8980264f5cfbc55b8b258aa6721f8e402))
* replace netstandard2.1 target with netstandard2.0 ([40da95d](https://github.com/googleapis/dotnet-genai/commit/40da95d5902c86a853ccca56d7343784b2f45d50))
* support multi speaker for Vertex AI ([8a81239](https://github.com/googleapis/dotnet-genai/commit/8a812397982f66d1d17555e59c1d94f3f6c5b018))


### Documentation improvements

* Update Virtual Try-On model id in samples and docstrings ([6dbbac8](https://github.com/googleapis/dotnet-genai/commit/6dbbac8437551ec333e71d7970356b4d0b935972))

## Version 0.9.0, released 2025-12-10


### New features

* Add enableEnhancedCivicAnswers feature in GenerateContentConfig ([f2e199d](https://github.com/googleapis/dotnet-genai/commit/f2e199d084fec74b68119dcfdc4542f193fd2a58))
* Add IMAGE_RECITATION and IMAGE_OTHER enum values to FinishReason ([7a825bd](https://github.com/googleapis/dotnet-genai/commit/7a825bd86a53f34cdcf74c2463900a3939ed8d77))
* Add voice activity detection signal. ([6ff3f01](https://github.com/googleapis/dotnet-genai/commit/6ff3f0137114b30e9a0c03067570c33ae05f805f))

## Version 0.8.0, released 2025-12-08


### New features

* Add DownloadAsync overloaded methods for Video and GeneratedVideo ([fb1cb85](https://github.com/googleapis/dotnet-genai/commit/fb1cb85dd0531f7f0c7aad00b578b6e3224e8cbe))
* Add DownloadToFileAsync overloaded methods for Video and GeneratedVideo ([3e57601](https://github.com/googleapis/dotnet-genai/commit/3e5760186ff06e2ae250b8cdda7ad238ed81d1f7))
* Support ReplicatedVoiceConfig ([66e7cd4](https://github.com/googleapis/dotnet-genai/commit/66e7cd4524a7a3927af649c6fb4e825380a47201))

## Version 0.7.0, released 2025-12-04


### New features

* Add Caches module to Dotnet SDK (create, get, delete, update, list) ([dce6173](https://github.com/googleapis/dotnet-genai/commit/dce61736426d404b28b678ac835174f8c686f717))
* Add generate_videos Video Generation and generic operations support in Dotnet SDK ([1a18f8c](https://github.com/googleapis/dotnet-genai/commit/1a18f8cacf2a16979e6838a80828b9f138f9d9b0))
* Add support for models.embed_content(), models.get(), models.update(), and models.delete() in C# SDK ([a3b8c21](https://github.com/googleapis/dotnet-genai/commit/a3b8c21a2bb54de8707e4919834a9ef40984f574))
* Add support for Tunings.tune() and Tunings.get() in Dotnet SDK ([39b7e6c](https://github.com/googleapis/dotnet-genai/commit/39b7e6c67f770d87bb70219c006e1e7ab078fbfc))
* create pager ([aa20330](https://github.com/googleapis/dotnet-genai/commit/aa20330772619423aafb2c55d8750b6bf4674c9a))
* Support Batches module for C# SDK (Create, CreateEmbeddings, Get, Cancel, List, Delete) ([3cb3486](https://github.com/googleapis/dotnet-genai/commit/3cb34867b117c3e1a17878cb99df9c81d8f4e7db))
* support compute tokens in Models module ([9ec457e](https://github.com/googleapis/dotnet-genai/commit/9ec457e61d833ccecad137f55bd38325c95d0f25))
* support count tokens feature in Models module ([b9b095c](https://github.com/googleapis/dotnet-genai/commit/b9b095cd11bf4bf33c8fb612288d34cf82021758))
* support Files List, Get, Upload, Download, Delete ([904b1aa](https://github.com/googleapis/dotnet-genai/commit/904b1aa7b33f694a2d9fda5fee93f36c0f3fa966))
* Support Models.ListAsync(), quota project authentication, and URL filter handling for list methods ([bec0233](https://github.com/googleapis/dotnet-genai/commit/bec0233baae5e00842af72b904fa459573159aeb))
* Support the cancel method in the C# SDK Tunings module ([26a0bb3](https://github.com/googleapis/dotnet-genai/commit/26a0bb379b1f43dea93002dad6422ea579ed8820))
* Support the list method in the Dotnet SDK Tunings module ([2072ba1](https://github.com/googleapis/dotnet-genai/commit/2072ba16730dd47726501b07afccc13049d75447))


### Bug fixes

* use timeout cancellation token for live close async ([b385da5](https://github.com/googleapis/dotnet-genai/commit/b385da5a0c86a583c49bbb51f3c6e2da57c06171))


### Documentation improvements

* Recommend using response_json_schema in error messages and docstrings. ([fd564bc](https://github.com/googleapis/dotnet-genai/commit/fd564bc963a24440317f40b75a096fb8829022a2))
* update count tokens example in README ([b333a7c](https://github.com/googleapis/dotnet-genai/commit/b333a7c7c54f0e3fdaf7338ae7f807b955e332b0))

## Version 0.6.0, released 2025-11-18


### New features

* add display name to FunctionResponseBlob ([4385bf9](https://github.com/googleapis/dotnet-genai/commit/4385bf9b170294ca6a8403f059ff080555277698))
* add display name to FunctionResponseFileData ([5ad6397](https://github.com/googleapis/dotnet-genai/commit/5ad6397746defd5a19a5c46c804c0fc7a8f2f59f))
* Add generate_content_config.thinking_level ([1773949](https://github.com/googleapis/dotnet-genai/commit/17739497e3c5ec480e540b665a0bf039d243bcf6))
* Add image output options to ImageConfig for Vertex ([06bee26](https://github.com/googleapis/dotnet-genai/commit/06bee2636da98d0fdfda539b23253317ec16d379))
* Add part.media_resolution ([1773949](https://github.com/googleapis/dotnet-genai/commit/17739497e3c5ec480e540b665a0bf039d243bcf6))
* support Function call argument streaming for all languages ([467fbe4](https://github.com/googleapis/dotnet-genai/commit/467fbe4a12e16866f5544d58582983e25ed1b1e1))

## Version 0.5.0, released 2025-11-12


### New features

* Add FileSearch tool and associated FileSearchStore management APIs ([b4734d7](https://github.com/googleapis/dotnet-genai/commit/b4734d70b8d243f78ed27e6c548036fec82d6ee9))
* Add image_size to ImageConfig (Early Access Program) ([587208c](https://github.com/googleapis/dotnet-genai/commit/587208caa6554ec2f5beb2862f69ed38c430346c))


### Bug fixes

* Fix base_steps parameter for recontext_image ([0f22c7e](https://github.com/googleapis/dotnet-genai/commit/0f22c7e6ce2f257faff75786496f25136b616ca6))

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
