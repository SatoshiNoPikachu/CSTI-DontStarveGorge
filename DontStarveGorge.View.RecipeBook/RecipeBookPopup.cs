using System.Collections.Generic;
using DontStarveGorge.Common;
using UnityEngine;

namespace DontStarveGorge.View.RecipeBook;

public class RecipeBookPopup : MonoBehaviour
{
    public static RecipeBookPopup Create()
    {
        var parent = EncounterPopup.Instance.SafeAccess()?.transform.parent;
        if (parent is null) return null;
        var prefab = AssetManager.GetAsset<GameObject>("GorgeRecipeBookPopup");
        var go = Instantiate(prefab, parent, false);
        go.name = "GorgeRecipeBookPopup";
        return go.GetComponent<RecipeBookPopup>();
    }

    public List<RecipeButton> RecipeButtons { get; } = [];

    [SerializeField] private RecipeButton RecipeButtonPrefab;

    [SerializeField] private GameObject RecipeBookPanel;

    [SerializeField] private GameObject AchievementPanel;

    [SerializeField] private GameObject RecipeTableViewport;

    [SerializeField] private RectTransform RecipeButtonTable;

    private void Awake()
    {
        RecipeTableViewport.AddComponent<NonDrawingGraphic>();
    }

    public RecipeButton AddRecipeButton()
    {
        var btn = Instantiate(RecipeButtonPrefab, RecipeButtonTable, false);
        RecipeButtons.Add(btn);
        return btn;
    }
}