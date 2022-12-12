using Content;
using UnityEngine;

namespace Shop.Weapon.Purchase
{
    public class WeaponPurchaseCardView : ShopCardView<WeaponDetails>
    {
        protected override string GetDisplayText(WeaponDetails item)
        {
            string text = $"{item.Name}\n \n";
            text += $"Damage: <color=#ff0000ff>{item.DamagePerAttack}</color>\n";
            text += $"Cooldown: <color=#00ff00ff>{item.AttackPeriod}</color>\n";
            text += $"Range: <color=#00ffffff>{item.AttackRange}</color>\n \n";
            text += $"{item.AbilityDescription}\n \n";
            text += $"{(item is ProjectileWeaponDetails ? "Melee" : "Ranged")}, ";
            text += $"{(item.DamageType == DamageType.Magic ? "Melee" : "Ranged")}";
            return text;
        }

        protected override Sprite GetIcon(WeaponDetails item) => item.Sprite;
    }
}