using System;
using Extentions;
using UnityEngine;

namespace Gameplay.Units
{
    public class Hitbox : Transformable
    {
        private HealthPool _healthPool;

        public event Action<Hit> OnHitTake;
        
        public void TakeHit(Hit hit)
        {
            _healthPool?.TakeDamage(hit.Damage);
            OnHitTake?.Invoke(hit);
        }

        private void Awake()
        {
            _healthPool = GetComponent<HealthPool>();
        }
    }
    
    public class Hit
    {
        public float Damage { get; }

        public Hit(float damage)
        {
            Damage = damage;
        }
    }
}