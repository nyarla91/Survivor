using Content;
using Gameplay.Units;
using UnityEngine;

namespace Gameplay.Weapon
{
    public class InstantWeaponBehaviour : WeaponBehaviour
    {
        protected new InstantWeaponDetails Details => ((InstantWeaponDetails) base.Details);

        private Hit PrimaryTargetHit => new Hit(Details.DamagePerAttack);
        private Hit SplashHit => new Hit(Details.DamagePerAttack * Details.SplashDamageModifier);
        
        protected override void Attack(Transform target)
        {
            Hitbox primaryTarget = target.GetComponent<Hitbox>();
            primaryTarget.TakeHit(PrimaryTargetHit);
            
            LayerMask mask = LayerMask.GetMask("Enemy");
            Collider2D[] splash = Physics2D.OverlapCircleAll(target.position, Details.AttackSplash, mask);
            foreach (Collider2D splashCollider in splash)
            {
                if (splashCollider.TryGetComponent(out Hitbox hitbox) && hitbox != primaryTarget)
                    hitbox.TakeHit(SplashHit);
            }
        }
    }
}