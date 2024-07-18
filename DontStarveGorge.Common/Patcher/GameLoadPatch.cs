using HarmonyLib;

namespace DontStarveGorge.Common.Patcher;

[HarmonyPatch(typeof(GameLoad))]
public static class GameLoadPatch
{
    [HarmonyPostfix, HarmonyPatch("LoadMainGameData")]
    public static void LoadMainGameData_Postfix()
    {
    }
}