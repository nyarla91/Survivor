using System;
using Extentions;
using Extentions.Factory;
using Extentions.Menu;
using Gameplay.Infrastrucure;
using Gameplay.Units;
using UnityEngine;
using Zenject;

namespace Gameplay.Projectiles
{
    public class Projectile : PooledObject
    {
        private EntityLayersSettings _entityLayersSettings;
        
        private EntityOwner _owner;
        private Hit _hit;
        private Vector2 _direction;
        private float _speed;

        private Rigidbody2D _rigidbody;
        private Rigidbody2D Rigidbody => _rigidbody ??= GetComponent<Rigidbody2D>();

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

        [Inject]
        private void Construct(EntityLayersSettings entityLayersSettings)
        {
            _entityLayersSettings = entityLayersSettings;
        }

        public void Init(EntityOwner owner, Hit hit, Vector2 velocity)
        {
            Owner = owner;
            _hit = hit;
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
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Hitbox hitbox))
                return;
            
            hitbox.TakeHit(_hit);
            PoolDisable();
        }
    }
}