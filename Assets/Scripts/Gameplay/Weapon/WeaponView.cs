using Extentions;
using UnityEngine;

namespace Gameplay.Weapon
{
    public abstract class WeaponView : Transformable
    {
        [field: SerializeField] protected Transform Sprite { get; private set; }

        private WeaponBehaviour _model;
        protected WeaponBehaviour Model => _model ??= GetComponentInParent<WeaponBehaviour>();

        private void Awake()
        {
            Model.OnAttack += Animate;
        }

        protected abstract void Animate(Transform target);
    }
}