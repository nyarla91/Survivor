using Content;
using UnityEngine;

namespace Shop
{
    public class WeaponPurchaseCardView : ShopCardView<WeaponDetails>
    {
        protected override string GetDisplayText(WeaponDetails obj)
        {
            string text = $"{obj.Name}\n \n";
            text += $"Damage: {obj.DamagePerAttack}\n";
            text += $"Cooldown: {obj.AttackPeriod}\n";
            text += $"Range: {obj.AttackRange}\n \n";
            text += $"{obj.AbilityDescription}\n \n";
            text += $"{(obj is ProjectileWeaponDetails ? "Melee" : "Ranged")}, ";
            text += $"{(obj.DamageType == DamageType.Magic ? "Melee" : "Ranged")}";
            return text;
        }

        protected override Sprite GetIcon(WeaponDetails obj) => obj.Sprite;
    }
}