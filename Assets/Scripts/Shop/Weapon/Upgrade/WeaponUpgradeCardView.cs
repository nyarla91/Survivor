using Content;
using RunProgress;
using UnityEngine;

namespace Shop.Weapon.Upgrade
{
    public class WeaponUpgradeCardView : ShopCardView<PlayerWeapon>
    {
        protected override string GetDisplayText(PlayerWeapon item)
        {
            WeaponDetails details = item.Details;
            string text = $"{details.Name}\n \n";
            text += $"Damage: <color=#ff0000ff>{item.TotalDamagePerAttack}</color>";
            text += $"+<color=#ffa500ff>{details.DamagePerAttack * PlayerWeapon.UpgradeModifier}</color>\n";
            text += $"Cooldown: <color=#00ff00ff>{details.AttackPeriod}</color>\n";
            text += $"Range: <color=#00ffffff>{details.AttackRange}</color>\n \n";
            text += $"{details.AbilityDescription}\n \n";
            text += $"{(details is ProjectileWeaponDetails ? "Melee" : "Ranged")}, ";
            text += $"{(details.DamageType == DamageType.Magic ? "Magic" : "Physical")}";
            return text;
        }

        protected override Sprite GetIcon(PlayerWeapon item) => item.Details.Sprite;
    }
}