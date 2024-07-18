using System;
using System.Linq;
using UnityEngine;

namespace DontStarveGorge.Cooking;

/// <summary>
/// 烹饪配方
/// </summary>
[Serializable]
public class Recipe
{
    /// <summary>
    /// 厨具
    /// </summary>
    public Cookware[] Cookwares;

    /// <summary>
    /// 食材数量
    /// </summary>
    public Vector2Int IngredientQuantity;

    /// <summary>
    /// 仅允许含有的食材标签
    /// </summary>
    public IngredientTag[] OnlyTags;

    /// <summary>
    /// 不允许含有的食材标签
    /// </summary>
    public IngredientTag[] NotTags;

    /// <summary>
    /// 烹饪失败条件组
    /// </summary>
    public CookingConditionGroup[] CookingFailConditionGroups;

    /// <summary>
    /// 是否显示大炊具图标
    /// </summary>
    public bool IsShowGreaterIcon;

    public bool Test(Cookware cookware, IngredientTags tags, int quantity)
    {
        if (!Cookwares.Contains(cookware)) return false;
        
        var min = IngredientQuantity.x;
        var max = IngredientQuantity.y;
        if (max < min) max = 0;
        if (min > quantity || max < quantity) return false;

        return tags.IsOnly(OnlyTags) && tags.IsNot(NotTags) &&
               CookingFailConditionGroups.All(condition => !condition.Test(tags, quantity));
    }
}