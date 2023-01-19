using Gameplay.Projectiles;
using Gameplay.Units.Character;
using Zenject;

namespace Gameplay.Weapon
{
    public class VampireScepterBehaviour : ProjectileWeaponBehaviour<Projectile>
    {
        [Inject] private CharacterComposition Character { get; }
        
        protected override void ProcessProjectile(Projectile projectile)
        {
            projectile.OnHitboxHit += _ =>
            {
                Character.VitalsPool.RestoreHealth(projectile.Hit.Damage * 0.01f);
            };
        }
    }
}