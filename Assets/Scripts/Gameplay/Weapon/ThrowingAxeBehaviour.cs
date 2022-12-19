using Gameplay.Projectiles;

namespace Gameplay.Weapon
{
    public class ThrowingAxeBehaviour : ProjectileWeaponBehaviour<Projectile>
    {
        private Projectile _projectile;
        protected override bool AttackCondition => _projectile != null;

        protected override void ProcessProjectile(Projectile projectile)
        {
            _projectile = projectile;
            projectile.OnPoolDisable += _ =>
            {
                _projectile = null;
            };
        }
    }
}