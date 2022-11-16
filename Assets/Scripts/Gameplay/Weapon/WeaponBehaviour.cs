using System;
using System.Linq;
using Content;
using Extentions;
using Gameplay.Units;
using Gameplay.Units.Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Weapon
{
    public abstract class WeaponBehaviour : Transformable
    {
        [SerializeField] private WeaponDetails _details;

        private Timer _cooldown;
        private OverlapTrigger2D Overlap { get; set; }

        private CircleCollider2D Range { get; set; }

        protected virtual Hit Hit => new Hit(Details.DamagePerAttack);
        protected Transform Target { get; private set; }
        protected WeaponDetails Details => _details;

        public float ZRotation
        {
            get => Transform.rotation.eulerAngles.z;
            set => Transform.rotation = Quaternion.Euler(0, 0, value);
        }

        public event Action<Transform> OnAttack; 

        private void Awake()
        {
            Overlap = GetComponent<OverlapTrigger2D>();
            Range = GetComponent<CircleCollider2D>();
            _cooldown = new Timer(this, Details.AttackPeriod);
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
            ZRotation = Random.Range(0, 360);
            Range.radius = _details.AttackRange;
        }

        private void FixedUpdate()
        {
            UpdateTarget();
            RotateTowardsTarget();
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

        private void RotateTowardsTarget()
        {
            if (Target == null)
                return;

            float targetZ = Transform.DirectionTo2D(Target).ToDegrees();
            ZRotation = Mathf.LerpAngle(ZRotation, targetZ, 0.5f);
        }
    }
}