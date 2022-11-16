using DG.Tweening;
using UnityEngine;

namespace Gameplay.Weapon
{
    public class ProjectileWeaponView : WeaponView
    {
        protected override void Animate(Transform target)
        {
            Sprite.DOComplete();
            Sprite.DOLocalMoveX(-0.3f, 0.1f).onComplete += () =>
            {
                Sprite.DOLocalMoveX(0, 0.2f);
            };
        }
    }
}