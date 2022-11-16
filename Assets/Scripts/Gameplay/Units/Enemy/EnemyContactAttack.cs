using System;
using Extentions;
using UnityEngine;

namespace Gameplay.Units.Enemy
{
    public class EnemyContactAttack : MonoBehaviour
    {
        [SerializeField] private float _damagePerSecond;

        private Timer _cooldown;

        private void Awake()
        {
            _cooldown = new Timer(this, 1);
            _cooldown.Restart();
        }
    }
}