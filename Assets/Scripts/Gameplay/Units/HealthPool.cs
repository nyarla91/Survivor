using System;
using UnityEngine;

namespace Gameplay.Units
{
    public class HealthPool : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;

        private float _health;

        public float Health
        {
            get => _health;
            private set
            {
                if (IsDead)
                    return;
                
                value = Mathf.Clamp(value, 0, MaxHealth);
                if (value.Equals(Health))
                    return;

                _health = value;
                OnHealthChanged?.Invoke(_health, _maxHealth);
                if (Health == 0)
                {
                    OnDie?.Invoke();
                    IsDead = true;
                }
            }
        }

        public float MaxHealth
        {
            get => _maxHealth;
            private set => _maxHealth = value;
        }
        
        public bool IsDead { get; private set; }

        public event Action<float, float> OnHealthChanged;
        public event Action OnDie; 

        public void TakeDamage(float damage)
        {
            if (damage <= 0)
                return;

            Health -= damage;
        }

        public void Ressurect()
        {
            IsDead = false;
            Health = MaxHealth;
        }

        private void Start()
        {
            Health = MaxHealth;
        }
    }
}