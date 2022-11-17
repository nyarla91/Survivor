using Extentions;
using Extentions.Factory;
using UnityEngine;

namespace Gameplay.Units.Enemy
{
    public class EnemyStatus : PooledObject
    {
        [SerializeField] private int _expirienceDropped;
        
        public VitalsPool VitalsPool { get; private set; }

        public override void Reset()
        {
            base.Reset();
            VitalsPool.Ressurect();
        }

        private void Awake()
        {
            VitalsPool = GetComponent<VitalsPool>();
            VitalsPool.Health.OnOver += PoolDisable;
        }
    }
}