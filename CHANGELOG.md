# Changelog

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
