using System;
using Content;
using UnityEngine;

namespace RunProgress
{
    [Serializable]
    public class PlayerWeapon
    {
        public const float UpgradeModifier = 1;
        
        [field: SerializeField] public WeaponDetails Details { get; private set; }
        [field: SerializeField] public int Level { get; private set; }

        public float TotalDamagePerAttack => Details.DamagePerAttack + Details.DamagePerAttack * (Level - 1) * UpgradeModifier;
        
        public PlayerWeapon(WeaponDetails details, int level)
        {
            Details = details;
            Level = level;
        }

        public void Upgrade() => Level++;
    }
}