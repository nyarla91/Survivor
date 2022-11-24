using System;
using Content;
using UnityEngine;

namespace RunProgress
{
    [Serializable]
    public class PlayerWeapon
    {
        [field: SerializeField] public WeaponDetails Weapon { get; private set; }
        [field: SerializeField] public int Level { get; private set; }

        public PlayerWeapon(WeaponDetails weapon, int level)
        {
            Weapon = weapon;
            Level = level;
        }
    }
}