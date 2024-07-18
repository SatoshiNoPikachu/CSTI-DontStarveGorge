using System;
using UnityEngine;

namespace DontStarveGorge.Cooking;

/// <summary>
/// 食物
/// </summary>
[Serializable]
public class Food : UniqueIDScriptable
{
    public Sprite FoodImage => Card?.CardImage;

    /// <summary>
    /// 绑定卡牌
    /// </summary>
    public CardData Card;

    /// <summary>
    /// 食物类型
    /// </summary>
    public FoodType[] FoodTypes;

    /// <summary>
    /// 配方
    /// </summary>
    public Recipe Recipe;

    /// <summary>
    /// 硬币价值
    /// </summary>
    public CoinValue CoinValue;

    /// <summary>
    /// 普通图像
    /// </summary>
    public Sprite GeneralImage;

    /// <summary>
    /// 装盘图像
    /// </summary>
    public Sprite PlatedImage;
}