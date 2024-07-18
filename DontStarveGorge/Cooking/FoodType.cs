using System;
using UnityEngine;

namespace DontStarveGorge.Cooking;

/// <summary>
/// 食物类型
/// </summary>
[Serializable]
public class FoodType : ScriptableObject
{
    /// <summary>
    /// 类型名
    /// </summary>
    public LocalizedString TypeName;

    /// <summary>
    /// 文本颜色
    /// </summary>
    public string TextColor;
}