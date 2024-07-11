using System;
using System.Collections.Generic;
using System.Linq;
using Object = UnityEngine.Object;

namespace DontStarveGorge.Data;

/// <summary>
/// 数据库
/// </summary>
public static class Database
{
    /// <summary>
    /// 数据字典
    /// </summary>
    public static readonly Dictionary<Type, Dictionary<string, object>> AllData = new();

    /// <summary>
    /// 获取数据字典
    /// </summary>
    /// <typeparam name="T">引用数据类型</typeparam>
    /// <returns>数据字典</returns>
    public static Dictionary<string, object> GetData<T>() where T : class
    {
        var type = typeof(T);
        return AllData.TryGetValue(type, out var dict) ? dict : null;
    }

    /// <summary>
    /// 根据键获取数据
    /// </summary>
    /// <param name="key">数据键</param>
    /// <typeparam name="T">引用数据类型</typeparam>
    /// <returns>数据</returns>
    public static T GetDataFromKey<T>(string key) where T : class
    {
        var dict = GetData<T>();
        if (dict is null) return null;
        return dict.TryGetValue(key, out var data) ? data as T : null;
    }
    
    /// <summary>
    /// 根据多个键获取数据
    /// </summary>
    /// <param name="keys">可迭代的数据键序列</param>
    /// <typeparam name="T">引用数据类型</typeparam>
    /// <returns>数据列表</returns>
    public static List<T> GetDataFromKey<T>(IEnumerable<string> keys) where T : class
    {
        var dict = GetData<T>();
        if (dict is null) return null;
        var list = new List<T>();
        foreach (var key in keys)
        {
            if (!dict.TryGetValue(key, out var data)) continue;
            switch (data)
            {
                case Object unityObj:
                    list.Add(unityObj.SafeAccess() as T);
                    break;
                case null:
                    list.Add(null);
                    break;
                default:
                    list.Add(data as T);
                    break;
            }
        }

        return list;
    }

    public static void AddData(Type type, Dictionary<string, object> objects)
    {
        AllData[type] = objects;
    }

    public static void Clear()
    {
        foreach (var obj in AllData.Values.SelectMany(data => data.Values))
        {
            if (obj is Object unityObj) Object.Destroy(unityObj);
        }

        AllData.Clear();
    }
}