using Extentions;
using Gameplay.Units.Player;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CameraFollow : Transformable
    {
        [SerializeField] private float _speed;
        
        private Transform _target;
        private Vector3 _destination;
        
        [Inject]
        private void Construct(CharacterMovement character)
        {
            _target = character.Transform;
            Transform.position = _target.position.WithZ(Transform.position.z);
        }

        private void Update()
        {
            if (_target != null)
                _destination = _target.position.WithZ(Transform.position.z);
            Transform.position = Vector3.Lerp(Transform.position, _destination, _speed * Time.deltaTime);
        }
    }
}