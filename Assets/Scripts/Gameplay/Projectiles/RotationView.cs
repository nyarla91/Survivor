using Extentions;
using UnityEngine;

namespace Gameplay.Projectiles
{
    public class RotationView : Transformable
    {
        [SerializeField] private Transform _target;
        [SerializeField] [Tooltip("Degrees per second")] private float _rotationSpeed;
        [SerializeField] private bool _clockwise = true;

        private void Update()
        {
            float delta = _rotationSpeed * Time.deltaTime;
            if (_clockwise)
                delta = -delta;
            _target.Rotate(0, 0, delta);
        }

        private void OnValidate()
        {
            if (_target == null)
                _target = Transform;
        }
    }
}