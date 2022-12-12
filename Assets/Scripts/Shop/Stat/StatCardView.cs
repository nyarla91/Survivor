using RunProgress;
using UnityEngine;

namespace Shop.Stat
{
    public class StatCardView : ShopCardView<ModifiedStat>
    {
        protected override string GetDisplayText(ModifiedStat item)
        {
            string text = $"{item.DisplayName}";
            text += $"\n<color=#ffa500ff>{item.Value}{item.DisplaySuffix}</color>";
            string sign = item.AmplificationPerLevel < 0 ? "" : "+";
            text += $"\n<color=#00ff00ff>{sign}{item.AmplificationPerLevel}{item.DisplaySuffix}</color>";
            return text;
        }

        protected override Sprite GetIcon(ModifiedStat item) => item.Icon;
    }
}