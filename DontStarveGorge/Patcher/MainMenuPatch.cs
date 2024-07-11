using HarmonyLib;

namespace DontStarveGorge.Patcher;

[HarmonyPatch(typeof(MainMenu))]
public static class MainMenuPatch
{
    [HarmonyPostfix, HarmonyPatch("Awake")]
    public static void Awake_Postfix()
    {

    }
}