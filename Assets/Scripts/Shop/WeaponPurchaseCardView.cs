using Content;
using UnityEngine;

namespace Shop
{
    public class WeaponPurchaseCardView : ShopCardView<WeaponDetails>
    {
        protected override string GetDisplayText(WeaponDetails obj)
        {
            string text = $"{obj.Name}\n \n";
            text += $"Damage: <color=#ff0000ff>{obj.DamagePerAttack}</color>\n";
            text += $"Cooldown: <color=#00ff00ff>{obj.AttackPeriod}</color>\n";
            text += $"Range: <color=#00ffffff>{obj.AttackRange}</color>\n \n";
            text += $"{obj.AbilityDescription}\n \n";
            text += $"{(obj is ProjectileWeaponDetails ? "Melee" : "Ranged")}, ";
            text += $"{(obj.DamageType == DamageType.Magic ? "Melee" : "Ranged")}";
            return text;
        }

        protected override Sprite GetIcon(WeaponDetails obj) => obj.Sprite;
    }
}