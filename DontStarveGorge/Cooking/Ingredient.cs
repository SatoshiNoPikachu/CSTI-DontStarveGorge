using System;
using UnityEngine;

namespace DontStarveGorge.Cooking;

/// <summary>
/// 食材
/// </summary>
[Serializable]
public class Ingredient : ScriptableObject
{
    public CardData Card;

    public FoodTag[] FoodTags;
}