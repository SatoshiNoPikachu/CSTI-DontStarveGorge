using DontStarveGorge.Cooking;
using HarmonyLib;

namespace DontStarveGorge.Patcher;

[HarmonyPatch(typeof(GraphicsManager))]
public static class GraphicsManagerPatch
{
    [HarmonyPostfix, HarmonyPatch("Init")]
    public static void Init_Postfix()
    {
        RecipeBook.CreateUI();
    }
}