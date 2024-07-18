using System;
using System.Collections.Generic;
using DontStarveGorge.Data;

namespace DontStarveGorge.Cooking;

/// <summary>
/// 食材
/// </summary>
[Serializable]
public class Ingredient : UniqueIDScriptable
{
    public static readonly Dictionary<CardData, Ingredient> CardDict = new();

    /// <summary>
    /// 绑定卡牌
    /// </summary>
    public CardData Card;

    /// <summary>
    /// 食物标签
    /// </summary>
    public IngredientTag[] FoodTags;

    static Ingredient()
    {
        Loader.LoadCompleteEvent += OnLoadComplete;
    }

    private static void OnLoadComplete()
    {
        CardDict.Clear();

        var data = Database.GetData<Ingredient>().Values;
        foreach (var obj in data)
        {
            var card = obj.Card;
            if (card is null) continue;
            if (CardDict.ContainsKey(card))
            {
                Plugin.Log.LogWarning($"Card {card.name} has multiple Ingredient binding.");
                continue;
            }

            CardDict[obj.Card] = obj;
        }
    }
}