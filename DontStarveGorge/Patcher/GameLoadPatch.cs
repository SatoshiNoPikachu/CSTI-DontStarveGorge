using System.Collections.Generic;
using System.Linq;
using DontStarveGorge.Common;
using DontStarveGorge.Cooking;
using DontStarveGorge.Data;
using HarmonyLib;
using UnityEngine;

namespace DontStarveGorge.Patcher;

[HarmonyPatch(typeof(GameLoad))]
public static class GameLoadPatch
{
    [HarmonyPostfix, HarmonyPatch("LoadMainGameData")]
    public static void LoadMainGameData_Postfix()
    {
        AssetManager.LoadAsset(Plugin.PluginPath);
        Loader.LoadAllData(DataCatalog.Catalog);

        var book = ScriptableObject.CreateInstance<RecipeBook>();
        book.Foods = new Food[70];
        book.name = "Gorge_RecipeBook";
        var cards =
            (from obj in GameLoad.Instance.DataBase.AllData where obj is CardData select obj as CardData).ToList();
        for (var i = 1; i < 71; i++)
        {
            var card = cards.Find(card => card.name == $"Don't Starve Gorge_Food_{i:00}");
            var food = ScriptableObject.CreateInstance<Food>();
            food.name = $"Food_{i:00}";
            food.Card = card;
            book.Foods[i - 1] = food;
        }

        Database.AddData(typeof(RecipeBook), new Dictionary<string, object>
        {
            [book.name] = book
        });
    }
}