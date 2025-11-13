# Changelog

## Version 0.2.0, released 2025-11-13


### New features

* Add `ImageConfig` to `GenerateContentConfig` ([03c0426](https://github.com/googleapis/dotnet-genai/commit/03c0426d285d5f5d89499c639fab5e3faa4a3336))
* Add `NO_IMAGE` enum value to `FinishReason` ([c6424b3](https://github.com/googleapis/dotnet-genai/commit/c6424b30682a7d9d2b071fa888b9f27fa3444c5d))
* add display name to FunctionResponseBlob ([4385bf9](https://github.com/googleapis/dotnet-genai/commit/4385bf9b170294ca6a8403f059ff080555277698))
* Add enable_enhanced_civic_answers in GenerationConfig ([5eff838](https://github.com/googleapis/dotnet-genai/commit/5eff838364d5d1c0b3f7bd523a451bd2f7e08e58))
* Add FileSearch tool and associated FileSearchStore management APIs ([b4734d7](https://github.com/googleapis/dotnet-genai/commit/b4734d70b8d243f78ed27e6c548036fec82d6ee9))
* Add FileSearch tool and associated FileSearchStore management APIs ([9869797](https://github.com/googleapis/dotnet-genai/commit/98697979ae6120f6ede560da21c9e5c6c7105648))
* Add FunctionResponsePart & ToolComputerUse.excludedPredefinedFunctions ([29210c6](https://github.com/googleapis/dotnet-genai/commit/29210c64cdc8ff534ddbe49ef7e3d1b1861f2902))
* Add image_size to ImageConfig (Early Access Program) ([587208c](https://github.com/googleapis/dotnet-genai/commit/587208caa6554ec2f5beb2862f69ed38c430346c))
* Add Imagen EditImage support in Dotnet SDK ([3055dca](https://github.com/googleapis/dotnet-genai/commit/3055dcaf5874c76e8b5c2987b499d59bebfbd9ba))
* Add labels field to Imagen configs ([20ecf3f](https://github.com/googleapis/dotnet-genai/commit/20ecf3f9595549378fe4c805cb4316405e93df52))
* Add RecontextImage support in Dotnet SDK ([f314213](https://github.com/googleapis/dotnet-genai/commit/f314213803c69a68eb63984883a51373e6501a5b))
* Add safety_filter_level and person_generation for Imagen upscaling ([299c8d3](https://github.com/googleapis/dotnet-genai/commit/299c8d390fa2b41ac0e67af65186b723e2406f06))
* Add SegmentImage support in Dotnet SDK ([2201d74](https://github.com/googleapis/dotnet-genai/commit/2201d74da2eff6acaa8fb619143ccc18d2b663f0))
* Add thinking_config for live ([643d4e1](https://github.com/googleapis/dotnet-genai/commit/643d4e18c2ec769fdadb4c5ce31b35bfd147ca15))
* Added phish filtering feature. ([deaf715](https://github.com/googleapis/dotnet-genai/commit/deaf715682d73a126e681163ca2df5ab1480532a))
* Auto-detect MIME type in Image.FromFile in Dotnet SDK ([8d0b59e](https://github.com/googleapis/dotnet-genai/commit/8d0b59ea127a56c1f01bbb4d882e910744729f84))
* Enable Google Maps tool for Genai. ([794fba8](https://github.com/googleapis/dotnet-genai/commit/794fba8642d78f56e38a0e12cbf8eb8d30645dc1))
* rename ComputerUse tool (early access) ([64891b3](https://github.com/googleapis/dotnet-genai/commit/64891b35b23d3613f571fd624b75eb22d2056c07))
* set up automatic doc publishing ([5538043](https://github.com/googleapis/dotnet-genai/commit/5538043ea91a2fad1bb75d14e08414dfe3a2d6b5))
* Support enableWidget feature in GoogleMaps ([7d4ff93](https://github.com/googleapis/dotnet-genai/commit/7d4ff935bd7031ac4f3572ccaa3323e99679255b))
* support jailbreak in HarmCategory and BlockedReason ([11210cf](https://github.com/googleapis/dotnet-genai/commit/11210cf753f09c58260c506f7c0a84f6df02a310))
* support netstandard2.1 build (fix [#56](https://github.com/googleapis/dotnet-genai/issues/56)) ([6803eeb](https://github.com/googleapis/dotnet-genai/commit/6803eeb80bfdb3173b1b602c4f391c5b0d7d7d8d))


### Bug fixes

* Fix base_steps parameter for recontext_image ([0f22c7e](https://github.com/googleapis/dotnet-genai/commit/0f22c7e6ce2f257faff75786496f25136b616ca6))
* manually update change log to release ([09d356c](https://github.com/googleapis/dotnet-genai/commit/09d356cb8c18d7d323e4482a7d2f3fd7c0bce031))
* update release-type for release-please (fix [#10](https://github.com/googleapis/dotnet-genai/issues/10)) ([83dd211](https://github.com/googleapis/dotnet-genai/commit/83dd211e6414f37bb7f944265c8ae83b7d33eb01))
* use `Audio` instead of `Media` field in the DemoApp for SendRealtimeInputAsync method of Live. ([6e70eb3](https://github.com/googleapis/dotnet-genai/commit/6e70eb376869bae096a5c8f0d69fac6b866425c2))


### Miscellaneous chores

* update change log for release please ([ce96e56](https://github.com/googleapis/dotnet-genai/commit/ce96e56efa4e508ff1c2a3fea2690319e0b040c5))
* update release please config ([db77b3f](https://github.com/googleapis/dotnet-genai/commit/db77b3fc946648f94736079abd1a2d9943bc73a1))


### Documentation improvements

* Add docstring for classes and fields that are not supported in Gemini or Vertex API ([d1be9eb](https://github.com/googleapis/dotnet-genai/commit/d1be9ebb67394eae7cc8db5f78e9e545e31053bf))
* Add docstring for enum classes that are not supported in Gemini or Vertex API ([91da8bf](https://github.com/googleapis/dotnet-genai/commit/91da8bf2f93fdc10f8e6c4a5129ac1fff3bf9bf5))
* ensure _site is created for gh-pages branch ([4a378d0](https://github.com/googleapis/dotnet-genai/commit/4a378d098f0f844a4d4499bc784ce2b95fd26303))
* update full API reference GitHub Page in README ([353b288](https://github.com/googleapis/dotnet-genai/commit/353b2884d117e2cb8d9a46eb82a84990ab90db97))
* update readme ([ed3df31](https://github.com/googleapis/dotnet-genai/commit/ed3df312886a37a1797077f74560633d7606391d))
* update README in Google.GenAI ([49489c6](https://github.com/googleapis/dotnet-genai/commit/49489c68d4ff40efdeea877dfa9c35f87c39a392))
* update README to reflect the support of netstandard2.1 ([ffb5c42](https://github.com/googleapis/dotnet-genai/commit/ffb5c4240dda5a5711345dd4c18105642225d010))
* update readme to trigger release please ([a916ba0](https://github.com/googleapis/dotnet-genai/commit/a916ba0a3e7ca183666040b8d6681d59e7f4886f))

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
