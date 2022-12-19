using System;
using Extentions;
using Extentions.Menu;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay.Weapon
{
    public abstract class WeaponView : Transformable
    {
        [field: SerializeField] protected Transform Sprite { get; private set; }
        [field: SerializeField] protected SpriteRenderer Renderer { get; private set; }

        private WeaponBehaviour _model;
        protected WeaponBehaviour Model => _model ??= GetComponentInParent<WeaponBehaviour>();

        public float ZRotation
        {
            get => Transform.rotation.eulerAngles.z;
            set => Transform.rotation = Quaternion.Euler(0, 0, value);
        }
        [Inject] private Pause Pause { get; set; }

        private void Start()
        {
            ZRotation = Random.Range(0, 360);
            Model.OnAttack += Animate;
            Renderer.sprite = Model.Details.Sprite;
        }

        private void FixedUpdate()
        {
            if (_model.Target == null || Pause.IsPaused)
                return;

            float targetZ = Transform.DirectionTo2D(_model.Target).ToDegrees();
            ZRotation = Mathf.LerpAngle(ZRotation, targetZ, 0.5f);
        }

        protected abstract void Animate(Transform target);
    }
}