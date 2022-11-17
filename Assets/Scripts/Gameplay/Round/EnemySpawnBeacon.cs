using System;
using Content;
using Extentions;
using Extentions.Factory;
using Gameplay.Units.Enemy;
using UnityEngine;
using Zenject;

namespace Gameplay.Round
{
    public class EnemySpawnBeacon : PooledObject
    {
        [SerializeField] private float _delay;

        
        [Inject] private ContainerFactory ContainerFactory { get; set; }
        
        public async void Init(PoolFactory factory, EnemySpawnDetails enemy)
        {
            Timer delay = new Timer(this, _delay);
            delay.Start();
            
            await delay.Await();

            GameObject prefab = enemy.Enemy;
            factory.GetNewObject<EnemyStatus>(Transform.position, prefab, null, prefab.name);
            PoolDisable();
        }

        public override void PoolDisable()
        {
            
            base.PoolDisable();
        }
    }
}