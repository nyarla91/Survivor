using System;
using Extentions;
using Extentions.Factory;
using UnityEngine;
using Zenject;

namespace Gameplay.Weapon
{
    public class AbyssSwordBehaviour : InstantWeaponBehaviour
    {
        [SerializeField] private PoolFactory _factory;
        [SerializeField] [Range(0, 1)] [Tooltip("Percent of base damage")] private float _abyssDpsPercent;
        [SerializeField] private float _abyssAreaDuration;
        
        [Inject] private Pause Pause { get; set; }
        
        protected override void Attack(Transform target)
        {
            base.Attack(target);
            AbyssArea abyssArea = _factory.GetNewObject<AbyssArea>(target.position);
            abyssArea.Init(Pause, PlayerWeapon.TotalDamagePerAttack * _abyssDpsPercent, _abyssAreaDuration);
        }
    }
}