﻿using DontStarveGorge.Cooking;

namespace DontStarveGorge.Data;

/// <summary>
/// 数据目录
/// </summary>
public static class DataCatalog
{
    public static readonly DataInfo[] Catalog = [
        new DataInfo(typeof(Food), "Gorge-Food"),
        new DataInfo(typeof(FoodTag), "Gorge-FoodTag"),
        new DataInfo(typeof(FoodType), "Gorge-EggGroup"),
        new DataInfo(typeof(Cookware), "Gorge-Cookware"),
        new DataInfo(typeof(Ingredient), "Gorge-Ingredient"),
    ];
}