using System;
using System.Linq;

namespace DontStarveGorge.Cooking;

/// <summary>
/// 烹饪条件
/// </summary>
[Serializable]
public class CookingCondition
{
    public CompareMethod CompareMethod;
    
    public FoodTag[] FoodTags;
    
    public int Value;

    public bool QuantityDifferenceValue;

    public bool Test(FoodTags tags, int quantity)
    {
        var v1 = FoodTags.Sum(tag => tags[tag]);
        var v2 = QuantityDifferenceValue ? quantity - Value : Value;

        return CompareMethod switch
        {
            CompareMethod.Greater => v1 > v2,
            CompareMethod.Less => v1 < v2,
            CompareMethod.Equal => v1 == v2,
            CompareMethod.NotEqual => v1 != v2,
            CompareMethod.GreaterOrEqual => v1 >= v2,
            CompareMethod.LessOrEqual => v1 <= v2,
            _ => false
        };
    }
}