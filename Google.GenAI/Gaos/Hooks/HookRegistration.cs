// Copyright 2026 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


namespace Google.GenAI.Gaos.Hooks
{
    /// <summary>
    /// Hook Registration File.
    /// </summary>
    /// <remarks>
    /// This file is only ever generated once on the first generation and then is free to be modified.
    /// Any hooks you wish to add should be registered in the InitHooks function. Feel free to define them
    /// in this file or in separate files in the Hooks folder.
    /// </remarks>
    public static class HookRegistration
    {
        /// <summary>
        /// Initializes hooks.
        /// </summary>
        /// <remarks>
        /// Add hooks by calling the appropriate registration method on the hooks parameter.
        /// Available hook interfaces: ISDKInitHook, IBeforeRequestHook, IAfterSuccessHook, IAfterErrorHook.
        /// </remarks>
        /// <param name="hooks">The hooks manager to register hooks with.</param>
        public static void InitHooks(IHooks hooks)
        {
            var authHook = new GoogleGenAIAuthHook();
            hooks.RegisterBeforeRequestHook(authHook);

            var lyriaHook = new LegacyLyriaShimHook();
            hooks.RegisterAfterSuccessHook(lyriaHook);
        }
    }
}