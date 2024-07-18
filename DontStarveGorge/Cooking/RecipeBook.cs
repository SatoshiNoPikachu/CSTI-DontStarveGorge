using System;
using DontStarveGorge.Data;
using DontStarveGorge.View.RecipeBook;

namespace DontStarveGorge.Cooking;

/// <summary>
/// 食谱
/// </summary>
[Serializable]
public class RecipeBook : UniqueIDScriptable
{
    public static RecipeBookPopup Popup;

    public static void CreateUI()
    {
        if (Popup) return;
        Popup = RecipeBookPopup.Create();
        Setup(Database.GetData<RecipeBook>("Gorge_RecipeBook"));
    }

    public static void Setup(RecipeBook book)
    {
        if (book?.Foods is null) return;
        var foods = book.Foods;
        var buttons = Popup.RecipeButtons;
        for (var i = 0; i < foods.Length; i++)
        {
            if (i >= buttons.Count) Popup.AddRecipeButton();
            buttons[i].Setup(i + 1, foods[i].FoodImage, null, null, null, null);
            buttons[i].Unlock();
        }
    }

    public Food[] Foods;
}