using System;
using Extentions;
using Extentions.Factory;
using Gameplay.Infrastrucure;
using Gameplay.Units;
using UnityEngine;
using Zenject;

namespace Gameplay.Projectiles
{
    public class Projectile : PooledObject
    {
        [SerializeField] [Tooltip("Set -1 to disable")] private float _maxTravelDistance = 10;
        [SerializeField] private bool _destroyedOnHit = true;
        
        private EntityLayersSettings _entityLayersSettings;
        
        private EntityOwner _owner;
        private Vector2 _direction;
        private float _speed;
        private float _distanceTraveled;

        private Rigidbody2D _rigidbody;
        private Rigidbody2D Rigidbody => _rigidbody ??= GetComponent<Rigidbody2D>();
        public Hit Hit { get; private set; }

        public Vector3 Direction
        {
            get => _direction;
            set
            {
                _direction = value.normalized;
            }
        }

        public float Speed
        {
            get => _speed;
            set
            {
                _speed = value;
            }
        }

        public Vector2 Velocity
        {
            get => Direction * Speed;
            set
            {
                Direction = value.normalized;
                Speed = value.magnitude;
            }
        }

        public EntityOwner Owner
        {
            get => _owner;
            set
            {
                _owner = value;
                gameObject.layer = _entityLayersSettings.Layers[value];
            }
        }
        
        [Inject] private Pause Pause { get; set; }

        public event Action<Hitbox> OnHitboxHit;

        [Inject]
        private void Construct(EntityLayersSettings entityLayersSettings)
        {
            _entityLayersSettings = entityLayersSettings;
        }

        public void Init(EntityOwner owner, Hit hit, Vector2 velocity)
        {
            Owner = owner;
            Hit = hit;
            Velocity = velocity;
        }


        public override void PoolDisable()
        {
            Velocity = Vector2.zero;
            base.PoolDisable();
        }

        private void FixedUpdate()
        {
            Rigidbody.velocity = Pause.IsPaused ? Vector2.zero : (Speed * Direction);
            
            if (_maxTravelDistance.ApproximatelyEqual(-1, 0.001f))
                return;
            _distanceTraveled = Rigidbody.velocity.magnitude;
            if (_distanceTraveled >= _maxTravelDistance)
                PoolDisable();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Hitbox hitbox))
                return;
            
            hitbox.TakeHit(Hit);
            OnHitboxHit?.Invoke(hitbox);
            if (_destroyedOnHit)
                PoolDisable();
        }
    }
}