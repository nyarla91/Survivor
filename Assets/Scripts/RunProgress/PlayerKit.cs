using System.Collections.Generic;
using System.Linq;
using Content;
using UnityEngine;

namespace RunProgress
{
    public class PlayerKit : MonoBehaviour
    {
        [SerializeField] private List<PlayerWeapon> _weapons;

        public List<PlayerWeapon> Weapons => _weapons.ToList();

        public void AddWeapon(WeaponDetails weapon)
        {
            _weapons.Add(new PlayerWeapon(weapon, 1));
        }
    }
}