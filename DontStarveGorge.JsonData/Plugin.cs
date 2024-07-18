using System.IO;
using BepInEx;

namespace DontStarveGorge.JsonData;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
internal class Plugin : BaseUnityPlugin
{
    private const string PluginGuid = "Pikachu.DontStarveGorge.JsonData";
    public const string PluginName = "DontStarveGorgeJsonData";
    public const string PluginVersion = "1.0.0";
    
    public static Plugin Instance = null!;
    public static string PluginPath => Path.GetDirectoryName(Instance.Info.Location);
    
    private void Awake()
    {
        Instance = this;
    }
}