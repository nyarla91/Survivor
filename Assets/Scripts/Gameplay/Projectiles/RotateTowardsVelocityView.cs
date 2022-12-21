using System;
using Extentions;
using UnityEngine;

namespace Gameplay.Projectiles
{
    public class RotateTowardsVelocityView : LazyGetComponent<Rigidbody2D>
    {
        [SerializeField] private Transform _target;

        private void Update()
        {
            float zRotation = Lazy.velocity.ToDegrees();
            _target.rotation = Quaternion.Euler(0, 0, zRotation);
        }

        private void OnValidate()
        {
            if (_target == null)
                _target = Transform;
        }
    }
}