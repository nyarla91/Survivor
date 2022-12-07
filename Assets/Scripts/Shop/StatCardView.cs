using Extentions;
using RunProgress;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class StatCardView : ShopCardView<ModifiedStat>
    {
        protected override string GetDisplayText(ModifiedStat obj)
        {
            string text = $"{obj.DisplayName}";
            text += $"\n<color=#ffa500ff>{obj.Value}{obj.DisplaySuffix}</color>";
            string sign = obj.AmplificationPerLevel < 0 ? "" : "+";
            text += $"\n<color=#00ff00ff>{sign}{obj.AmplificationPerLevel}{obj.DisplaySuffix}</color>";
            return text;
        }

        protected override Sprite GetIcon(ModifiedStat obj) => obj.Icon;
    }
}