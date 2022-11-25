using System;
using Extentions;
using Extentions.Menu;
using UnityEngine;
using Zenject;

namespace Gameplay.Units
{
    public class VitalsPool : MonoBehaviour
    {
        [SerializeField] private Resource _health;
        [SerializeField] private Resource _shields;
        [SerializeField] private float _shieldRegenreration;

        public ResourceFacade Health => _health.Facade;
        public ResourceFacade Shields => _shields.Facade;
        
        [Inject] private Pause Pause { get; set; }

        public bool IsDead { get; private set; }

        public void TakeDamage(float damage)
        {
            if (damage <= 0 || IsDead)
                return;

            _health.Value -= Mathf.Max(damage - _shields.Value, 0);
            _shields.Value -= damage;
        }

        public void RestoreHealth(float health)
        {
            if (health <= 0 || IsDead)
                return;

            _health.Value += health;
        }

        public void RestoreShields(float shields)
        {
            if (shields <= 0 || IsDead)
                return;

            _shields.Value += shields;
        }

        public void Ressurect()
        {
            IsDead = false;
            _health.Value = _health.MaxValue;
        }

        private void Awake()
        {
            _health.OnOver += () => IsDead = true;
        }

        private void Start()
        {
            _health.Value = _health.MaxValue;
        }

        private void FixedUpdate()
        {
            if (Pause.IsPaused)
                return;
            RestoreShields(_shieldRegenreration * Time.fixedDeltaTime);
        }
    }
}