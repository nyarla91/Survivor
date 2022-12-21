using System;
using System.Linq;
using Content;
using Extentions;
using Extentions.Menu;
using Gameplay.Units;
using Gameplay.Units.Enemy;
using RunProgress;
using UnityEngine;
using Zenject;

namespace Gameplay.Weapon
{
    public abstract class WeaponBehaviour : Transformable
    {
        private Timer _cooldown;
        private OverlapTrigger2D Overlap { get; set; }
        private CircleCollider2D Range { get; set; }

        protected virtual float AttackPeriod => Details.AttackPeriod;
        protected virtual bool AttackCondition => true;
        protected virtual Hit Hit => new Hit(PlayerWeapon.TotalDamagePerAttack);
        public Transform Target { get; private set; }
        public PlayerWeapon PlayerWeapon { get; private set; }
        public int Level => PlayerWeapon.Level;
        public WeaponDetails Details => PlayerWeapon.Details;

        [Inject] private Pause Pause { get; set; }

        public event Action<Transform> OnAttack; 

        public void Init(PlayerWeapon weapon)
        {
            PlayerWeapon = weapon;
            Range.radius = Details.AttackRange;
            _cooldown = new Timer(this, Details.AttackPeriod, Pause);
            _cooldown.Restart();
        }

        private bool TryAttack()
        {
            if (_cooldown.IsOn || Target == null || ! AttackCondition)
                return false;
            Attack(Target);
            OnAttack?.Invoke(Target);
            _cooldown.Length = AttackPeriod;
            return true;
        }

        protected abstract void Attack(Transform target);

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

        private void Awake()
        {
            Overlap = GetComponent<OverlapTrigger2D>();
            Range = GetComponent<CircleCollider2D>();
        }
    }
}