using Extentions;

namespace Gameplay.Units.Enemy
{
    public class EnemyStatus : Transformable
    {
        public HealthPool HealthPool { get; private set; }

        private void Awake()
        {
            HealthPool = GetComponent<HealthPool>();
            HealthPool.OnDie += () => Destroy(gameObject);
        }
    }
}