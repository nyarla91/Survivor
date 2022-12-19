using Extentions;
using Gameplay.Projectiles;
using UnityEngine;

namespace Gameplay.Weapon
{
    public abstract class ResourceBasedAttackSpeedWeaponBehaviour : ProjectileWeaponBehaviour<Projectile>
    {
        protected abstract ResourceFacade Resource { get; }
        protected override float AttackPeriod
        {
            get
            {
                float missingPercent = Resource.Value / Resource.MaxValue;
                return Details.AttackPeriod * PercentToAttackPeriodMultiplier(missingPercent);
            }
        }

        protected abstract float PercentToAttackPeriodMultiplier(float percent);
    }
}