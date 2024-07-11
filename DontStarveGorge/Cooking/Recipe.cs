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
    public Cookware[] Cookwares;
    
    public Vector2Int IngredientQuantity;

    public FoodTag[] OnlyTags;

    public FoodTag[] NotTags;

    public CookingConditionGroup[] CookingFailConditionGroups;

    public bool Test(Cookware cookware, FoodTags tags, int quantity)
    {
        var min = IngredientQuantity.x;
        var max = IngredientQuantity.y;
        if (max < min) max = 0;
        
        if (!Cookwares.Contains(cookware)) return false;
        if (min > quantity || max < quantity) return false;

        return tags.IsOnly(OnlyTags) && tags.IsNot(NotTags) &&
               CookingFailConditionGroups.All(condition => !condition.Test(tags, quantity));
    }
}