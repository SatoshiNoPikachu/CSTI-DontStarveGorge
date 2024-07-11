using System;
using System.Linq;

namespace DontStarveGorge.Cooking;

/// <summary>
/// 烹饪条件组
/// </summary>
[Serializable]
public class CookingConditionGroup
{
    public CookingCondition[] CookingConditions;

    public bool Test(FoodTags tags, int quantity)
    {
        return CookingConditions.All(condition => condition.Test(tags, quantity));
    }
}