using System;
using UnityEngine;

namespace DontStarveGorge.Cooking;

[Serializable]
public class FoodType : ScriptableObject
{
    public LocalizedString TypeName;

    public string TextColor;
}