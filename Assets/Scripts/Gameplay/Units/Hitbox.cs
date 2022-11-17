using System;
using Extentions;
using UnityEngine;

namespace Gameplay.Units
{
    public class Hitbox : Transformable
    {
        private VitalsPool _vitalsPool;

        public event Action<Hit> OnHitTake;
        
        public void TakeHit(Hit hit)
        {
            _vitalsPool?.TakeDamage(hit.Damage);
            OnHitTake?.Invoke(hit);
        }

        private void Awake()
        {
            _vitalsPool = GetComponent<VitalsPool>();
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