using DontStarveGorge.Cooking;

namespace DontStarveGorge.JsonData;

public static class Generator
{
    public static void Gen()
    {
        var data = new EditorJsonData.EditorJsonData(Plugin.PluginPath, "Gorge-");
        data.AddType<Food>(true);
        data.CreateJsonData();
    }
}