using DontStarveGorge.Cooking;
using HarmonyLib;

namespace DontStarveGorge.Patcher;

[HarmonyPatch(typeof(InGameCardBase))]
public static class InGameCardBasePatch
{
    // [HarmonyPostfix, HarmonyPatch("IsCooking")]
    // public static void IsCooking_Postfix(InGameCardBase __instance, ref bool __result)
    // {
    //     Cookware.IsCooking(__instance, ref __result);
    // }
    //
    // [HarmonyPostfix, HarmonyPatch("CookingIsPaused")]
    // public static void CookingIsPaused_Postfix(InGameCardBase __instance, ref bool __result)
    // {
    //     Cookware.IsCooking(__instance, ref __result);
    // }
}