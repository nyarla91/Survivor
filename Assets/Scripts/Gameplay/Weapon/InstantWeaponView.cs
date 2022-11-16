using DG.Tweening;
using UnityEngine;

namespace Gameplay.Weapon
{
    public class InstantWeaponView : WeaponView
    {
        protected override void Animate(Transform target)
        {
            float distance = Vector2.Distance(Transform.position, target.position);
            Sprite.DOComplete();
            Sprite.DOLocalMoveX(distance, 0.1f).onComplete += () =>
            {
                Sprite.DOLocalMoveX(0, 0.4f);
            };
        }
    }
}