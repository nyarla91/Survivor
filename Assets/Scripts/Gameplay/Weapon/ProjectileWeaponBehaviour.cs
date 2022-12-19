using Content;
using Extentions;
using Extentions.Factory;
using Gameplay.Projectiles;
using Gameplay.Units;
using UnityEngine;

namespace Gameplay.Weapon
{
    public class ProjectileWeaponBehaviour<T> : WeaponBehaviour where T : Projectile
    {
        private PoolFactory _projectilesFactory;

        private PoolFactory ProjectilesFactory => _projectilesFactory ??= GetComponent<PoolFactory>();
        protected override Hit Hit => new Hit(Details.DamagePerAttack / Details.ProjectilesPerShot);
        protected new ProjectileWeaponDetails Details => ((ProjectileWeaponDetails) base.Details);

        protected override void Attack(Transform target)
        {
            Vector2 direction = Transform.DirectionTo2D(target);
            if (Details.ProjectilesPerShot == 1)
            {
                SpawnProjectile(0);
            }
            else
            {
                for (float i = 0; i < Details.ProjectilesPerShot; i++)
                {
                    float angleOffset = 0;
                    if (Details.ProjectilesPerShot > 1)
                    {
                        float maxAngle = Details.SpreadAngle / 2;
                        float t = i / (Details.ProjectilesPerShot - 1);
                        angleOffset = Details.SpreadAngle * MathExtentions.EvaluateLine(-maxAngle, maxAngle, t);
                    }
                    SpawnProjectile(angleOffset);
                }
            }

            void SpawnProjectile(float angleOffset)
            {
                T projectile = ProjectilesFactory.GetNewObject<T>(Transform.position);
                projectile.Init(EntityOwner.Player, Hit, direction.Rotated(angleOffset) * Details.ProjectileSpeed);
                ProcessProjectile(projectile);
            }
        }

        protected virtual void ProcessProjectile(T projectile) { }
    }
}