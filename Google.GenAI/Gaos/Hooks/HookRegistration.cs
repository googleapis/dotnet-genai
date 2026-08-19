
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