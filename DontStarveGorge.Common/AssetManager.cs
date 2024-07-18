using System.IO;
using UnityEngine;

namespace DontStarveGorge.Common;

public class AssetManager
{
    private static AssetBundle _resources;

    public static void LoadAsset(string path)
    {
        _resources = AssetBundle.LoadFromFile(Path.Combine(path, "resources.ab"));
    }

    public static T GetAsset<T>(string name) where T : Object
    {
        return _resources.LoadAsset<T>(name);
    }
}