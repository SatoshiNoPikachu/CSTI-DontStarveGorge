using System;

namespace DontStarveGorge.Cooking;

/// <summary>
/// 食物
/// </summary>
[Serializable]
public class Food : UniqueIDScriptable
{
    public CardData Card;
    
    public FoodType[] FoodTypes;
    
    public Recipe Recipe;

    public CoinValue CoinValue;
}