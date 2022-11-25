using Extentions;
using Extentions.Menu;
using Gameplay.Units.Player;
using UnityEngine;
using Zenject;

namespace Gameplay.Units.Enemy
{
    public class EnemyMovement : LazyGetComponent<Rigidbody2D>
    {
        [SerializeField] private float _approachSpeed;
        [SerializeField] private float _retreatSpeed;
        [SerializeField] private float _preferedDistance;
        [SerializeField] [Tooltip("The less, the smoother acceleration")] private float _lerpBlend;

        private Transform _character;
        
        [Inject] private Pause Pause { get; set; }
        
        [Inject]
        private void Construct(CharacterMovement character)
        {
            _character = character.Transform;
        }

        private void FixedUpdate()
        {
            if (Pause.IsPaused)
            {
                Lazy.velocity = Vector2.zero;
                return;
            }
            
            float distanceToPlayer = Vector3.Distance(Transform.position.WithZ(0), _character.position.WithZ(0));
            
            float speed;
            if (distanceToPlayer.ApproximatelyEqual(_preferedDistance,0.5f))
                speed = 0;
            else if (distanceToPlayer > _preferedDistance)
                speed = _approachSpeed;
            else
                speed = -_retreatSpeed;

            Vector2 targetVelocity = Transform.DirectionTo2D(_character) * speed; 
            Lazy.velocity = Vector2.Lerp(Lazy.velocity, targetVelocity, Time.fixedDeltaTime * _lerpBlend);
        }
    }
}