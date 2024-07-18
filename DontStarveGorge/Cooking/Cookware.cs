using System;
using System.Collections.Generic;
using DontStarveGorge.Data;
using UnityEngine;

namespace DontStarveGorge.Cooking;

/// <summary>
/// 炊具
/// </summary>
[Serializable]
public class Cookware : ScriptableObject
{
    public static readonly Dictionary<CardData, Cookware> CardDict = new();

    /// <summary>
    /// 普通炊具绑定卡牌
    /// </summary>
    public CardData GeneralCookwareCard;

    /// <summary>
    /// 普通炊具图标
    /// </summary>
    public Sprite GeneralCookwareIcon;

    /// <summary>
    /// 大炊具绑定卡牌
    /// </summary>
    public CardData GreaterCookwareCard;

    /// <summary>
    /// 大炊具图标
    /// </summary>
    public Sprite GreaterCookwareIcon;

    /// <summary>
    /// 内容物是否是容器
    /// </summary>
    public bool IsContentContainer;

    static Cookware()
    {
        Loader.LoadCompleteEvent += OnLoadComplete;
    }

    private static void OnLoadComplete()
    {
        CardDict.Clear();

        var data = Database.GetData<Cookware>().Values;
        foreach (var obj in data)
        {
            var card = obj.GeneralCookwareCard;

            if (card is not null)
            {
                if (CardDict.ContainsKey(card))
                {
                    Plugin.Log.LogWarning($"Card {card.name} has multiple Cookware binding.");
                    continue;
                }

                CardDict[obj.GeneralCookwareCard] = obj;
            }

            card = obj.GreaterCookwareCard;
            if (card is null) continue;
            if (CardDict.ContainsKey(card))
            {
                Plugin.Log.LogWarning($"Card {card.name} has multiple Cookware binding.");
                continue;
            }

            CardDict[obj.GeneralCookwareCard] = obj;
        }
    }

    // public static void IsCooking(InGameCardBase card, ref bool result)
    // {
    //     if (!result) return;
    //     if (card is null or { CardModel: null } or { HasInventoryContent: false }) return;
    //     if (!CardDict.TryGetValue(card.CardModel, out var cookware)) return;
    //     if (!cookware.IsContentContainer) return;
    //
    //     result = card.CardsInInventory[0].MainCard.HasInventoryContent;
    // }
}