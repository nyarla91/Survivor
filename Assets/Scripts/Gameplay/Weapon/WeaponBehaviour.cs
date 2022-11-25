using System;
using System.Linq;
using Content;
using Extentions;
using Extentions.Menu;
using Gameplay.Units;
using Gameplay.Units.Enemy;
using UnityEngine;
using Zenject;

namespace Gameplay.Weapon
{
    public abstract class WeaponBehaviour : Transformable
    {
        [SerializeField] private WeaponDetails _details;

        private Timer _cooldown;
        private OverlapTrigger2D Overlap { get; set; }

        private CircleCollider2D Range { get; set; }

        protected virtual Hit Hit => new Hit(Details.DamagePerAttack);
        public Transform Target { get; private set; }
        protected WeaponDetails Details => _details;
        
        [Inject] private Pause Pause { get; set; }

        public event Action<Transform> OnAttack; 

        private void Awake()
        {
            Overlap = GetComponent<OverlapTrigger2D>();
            Range = GetComponent<CircleCollider2D>();
            _cooldown = new Timer(this, Details.AttackPeriod, Pause);
            _cooldown.Restart();
        }

        private bool TryAttack()
        {
            if (_cooldown.IsOn || Target == null)
                return false;
            Attack(Target);
            OnAttack?.Invoke(Target);
            return true;
        }

        protected abstract void Attack(Transform target);

        private void Start()
        {
            Range.radius = _details.AttackRange;
        }

        private void FixedUpdate()
        {
            UpdateTarget();
            if (TryAttack())
                _cooldown.Restart();
        }

        private void UpdateTarget()
        {
            Transform[] possibleTargets = Overlap.GetContent<EnemyMovement>().Select(enemy => enemy.Transform).ToArray();
            if (possibleTargets.Length == 0)
            {
                Target = null;
                return;
            }

            Target = possibleTargets.OrderBy(t =>
                Vector2.Distance(Transform.position, t.position)).ToArray()[0];
        }
    }
}