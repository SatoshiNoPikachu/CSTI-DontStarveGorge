using System;
using System.Collections.Generic;
using DontStarveGorge.Data;
using UnityEngine;

namespace DontStarveGorge.Cooking;

/// <summary>
/// 食材
/// </summary>
[Serializable]
public class Ingredient : ScriptableObject
{
    public static Dictionary<CardData, Ingredient> IngredientDict = new();
    
    public CardData Card;

    public FoodTag[] FoodTags;

    static Ingredient()
    {
        Loader.LoadCompleteEvent += OnLoadComplete;
    }

    private static void OnLoadComplete()
    {
        IngredientDict.Clear();

        var data = Database.GetData<Ingredient>().Values;
        foreach (var ingredient in data)
        {
            var card = ingredient.Card;
            if (card is null) continue;
            if (IngredientDict.ContainsKey(card))
            {
                Plugin.Log.LogWarning($"Card {card.name} has multiple ingredient binding.");
                continue;
            }

            IngredientDict[ingredient.Card] = ingredient;
        }
    }
}