using System;
using UnityEngine;
using UnityEngine.UI;

namespace DontStarveGorge.View.RecipeBook;

public class SliderScrollBar : MonoBehaviour
{
    public Button TopButton;

    public Button BtmButton;

    public Slider Slider;

    public ScrollRect ScrollRect;

    private RectTransform _scrollRect;

    private RectTransform _contentRect;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        Slider?.onValueChanged.AddListener(OnSliderValueChanged);
        if (!ScrollRect) return;
        _scrollRect = ScrollRect.gameObject.GetComponent<RectTransform>();
        ScrollRect.onValueChanged.AddListener(OnScrollRectValueChanged);
        if (!ScrollRect.content) return;
        _contentRect = ScrollRect.content.gameObject.GetComponent<RectTransform>();
        ScrollRect.content.gameObject.AddComponent<ContentChangeCallback>().OnContentChange = OnContentChange;
        OnContentChange();
    }

    private void OnScrollRectValueChanged(Vector2 v)
    {
        Slider.value = v.y;
    }

    private void OnSliderValueChanged(float v)
    {
        ScrollRect.verticalNormalizedPosition = v;
    }

    private void OnContentChange()
    {
        var isNeedScroll = _scrollRect.sizeDelta.y < _contentRect.sizeDelta.y;
        Slider.interactable = isNeedScroll;
        if (isNeedScroll) Slider.value = ScrollRect.verticalNormalizedPosition;
    }

    private class ContentChangeCallback : MonoBehaviour
    {
        public Action OnContentChange;

        private void OnRectTransformDimensionsChange()
        {
            OnContentChange?.Invoke();
        }
    }
}