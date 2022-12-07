using DG.Tweening;
using Extentions;
using UnityEngine;

namespace Gameplay.Units
{
    public class UnitView : Transformable
    {
        [SerializeField] private Hitbox _hitbox;
        
        private SpriteRenderer _spriteRenderer;
        public SpriteRenderer SpriteRenderer => _spriteRenderer ??= GetComponent<SpriteRenderer>();

        private void Awake()
        {
            _hitbox.OnHitTake += Shake;
        }

        private void Shake(Hit _)
        {
            Transform.DOComplete();
            Transform.DOShakeScale(0.2f, Vector2.one);
        }

        private void OnDestroy()
        {
            Transform.DOKill();
        }
    }
}