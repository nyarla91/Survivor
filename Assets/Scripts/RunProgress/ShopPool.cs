using System;
using System.Collections.Generic;
using System.Linq;
using Content;
using Extentions;
using UnityEngine;

namespace RunProgress
{
    public class ShopPool : MonoBehaviour
    {
        [SerializeField] private List<WeaponDetails> _startingWeapons;

        private List<WeaponDetails> _weapons;

        public WeaponDetails[] Weapons => _weapons.ToArray();

        public void Reset()
        {
            _weapons = _startingWeapons.ToList();
        }

        public void RemoveWeapon(WeaponDetails weapon) => _weapons.TryRemove(weapon);

        private void Start()
        {
            Reset();
        }
    }
}