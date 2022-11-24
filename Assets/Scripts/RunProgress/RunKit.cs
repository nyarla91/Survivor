using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RunProgress
{
    public class RunKit : MonoBehaviour
    {
        [SerializeField] private List<PlayerWeapon> _weapons;

        public List<PlayerWeapon> Weapons => _weapons.ToList();
    }
}