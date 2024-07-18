using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DontStarveGorge.View.RecipeBook;

public class RecipeButton : MonoBehaviour
{
    public bool Active
    {
        get => gameObject.activeSelf;
        set => gameObject.SetActive(value);
    }

    [SerializeField] private TextMeshProUGUI NoText;

    [SerializeField] private GameObject Lock;

    [SerializeField] private Image FoodImage;

    [SerializeField] private GameObject Coins;

    [SerializeField] private GameObject Cookwares;

    [SerializeField] private Image Coin1;

    [SerializeField] private Image Coin2;

    [SerializeField] private Image Cookware1;

    [SerializeField] private Image Cookware2;

    public void Setup(int no, Sprite food, Sprite coin1, Sprite coin2, Sprite cookware1, Sprite cookware2)
    {
        Lock.SetActive(true);
        FoodImage.gameObject.SetActive(false);
        Coins.SetActive(false);
        Cookwares.SetActive(false);

        NoText.text = $"{no:00}";
        FoodImage.sprite = food;
        SetImage(Coin1, coin1);
        SetImage(Coin2, coin2);
        SetImage(Cookware1, cookware1);
        SetImage(Cookware2, cookware2);

        Active = true;
    }

    private static void SetImage(Image image, Sprite sprite)
    {
        if (image is null) return;
        image.sprite = sprite;
        image.gameObject.SetActive(sprite is not null);
    }

    public void Unlock()
    {
        Lock.SetActive(false);
        FoodImage.gameObject.SetActive(true);
        Coins.SetActive(true);
        Cookwares.SetActive(true);
    }
}