using Content;
using RunProgress;
using UnityEngine;

namespace Shop
{
    public class WeaponUpgradeCardView : ShopCardView<PlayerWeapon>
    {
        protected override string GetDisplayText(PlayerWeapon obj)
        {
            WeaponDetails details = obj.Details;
            if (obj.Details == null)
                print("Allo");
            string text = $"{details.Name}\n \n";
            text += $"Damage: <color=#ff0000ff>{obj.TotalDamagePerAttack}</color>";
            text += $"+<color=#ffa500ff>{details.DamagePerAttack * PlayerWeapon.UpgradeModifier}</color>\n";
            text += $"Cooldown: <color=#00ff00ff>{details.AttackPeriod}</color>\n";
            text += $"Range: <color=#00ffffff>{details.AttackRange}</color>\n \n";
            text += $"{details.AbilityDescription}\n \n";
            text += $"{(details is ProjectileWeaponDetails ? "Melee" : "Ranged")}, ";
            text += $"{(details.DamageType == DamageType.Magic ? "Magic" : "Physical")}";
            return text;
        }

        protected override Sprite GetIcon(PlayerWeapon obj) => obj.Details.Sprite;
    }
}