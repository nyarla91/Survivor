using Extentions;
using Extentions.Factory;
using Gameplay.Collectables;
using UnityEngine;

namespace Gameplay.Units.Enemy
{
    public class EnemyStatus : PooledObject
    {
        [SerializeField] private int _expirienceDropped;
        
        public VitalsPool VitalsPool { get; private set; }
        public PoolFactory ExperienceFactory { get; set; }

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

        public override void PoolDisable()
        {
            for (int i = 0; i < _expirienceDropped; i++)
            {
                Vector2 point = Transform.position + (Vector3) Random.insideUnitCircle;
                ExperienceFactory.GetNewObject<ExperienceOrb>(point.WithZ(1));
            }
            base.PoolDisable();
        }
    }
}