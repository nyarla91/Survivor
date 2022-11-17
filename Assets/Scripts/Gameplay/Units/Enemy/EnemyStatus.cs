using Extentions;
using Extentions.Factory;

namespace Gameplay.Units.Enemy
{
    public class EnemyStatus : PooledObject
    {
        public HealthPool HealthPool { get; private set; }

        private void Awake()
        {
            HealthPool = GetComponent<HealthPool>();
            HealthPool.OnDie += PoolDisable;
        }

        public override void PoolDisable()
        {
            HealthPool.OnDie -= PoolDisable;
            HealthPool.Ressurect();
            base.PoolDisable();
        }
    }
}