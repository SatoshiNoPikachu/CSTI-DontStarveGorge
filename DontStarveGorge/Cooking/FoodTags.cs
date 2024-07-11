using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DontStarveGorge.Cooking;

/// <summary>
/// 食物标签组
/// </summary>
public class FoodTags
{
    private readonly Dictionary<FoodTag, int> _tags = new();

    public int this[FoodTag tag]
    {
        get => GetValue(tag);
        set => SetValue(tag, value);
    }

    public void SetValue(FoodTag tag, int value)
    {
        _tags[tag] = value;
    }

    public int GetValue(FoodTag tag)
    {
        return _tags.TryGetValue(tag, out var value) ? value : 0;
    }

    public bool IsOnly(FoodTag[] tags)
    {
        foreach (var (tag, value) in _tags)
        {
            if (!tags.Contains(tag) && value != 0) return false;
        }

        return true;
    }

    public bool IsNot(IEnumerable<FoodTag> tags)
    {
        return tags.All(tag => this[tag] == 0);
    }

    public override string ToString()
    {
        var text = new StringBuilder();
        foreach (var (tag, value) in _tags)
        {
            text.Append($"{tag.name} {value}, ");
        }

        if (text.Length > 2) text.Remove(text.Length - 2, 2);
        return text.ToString();
    }
}