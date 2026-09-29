using HarmonyLib;
using Jotunn.Managers;
using TheQueensDeadBruh.Features;

namespace TheQueensDeadBruh.Patches;

internal static class FejdStartupPatches
{
    [HarmonyPatch(typeof(FejdStartup), nameof(FejdStartup.Awake))]
    [HarmonyAfter("vapok.common.LocalizationManager", "org.bepinex.helpers.LocalizationManager")]
    [HarmonyBefore("vapok.common.ItemManager", "org.bepinex.helpers.ItemManager")]
    private static class FejdStartupAwakePatch
    {
        [HarmonyPrepare]
        private static bool Prepare() => !GUIManager.IsHeadless();

        private static void Prefix()
        {
            TheQueensDeadBruh.Waiter.ValheimIsAwake(true);
            DisableMistlandsMistComponent.Reset();
        }
    }
}