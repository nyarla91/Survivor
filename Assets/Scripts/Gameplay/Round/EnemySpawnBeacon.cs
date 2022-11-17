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
        
        public async void Init(EnemySpawnDetails enemy)
        {
            Timer delay = new Timer(this, _delay);
            delay.Start();
            
            await delay.Await();

            ContainerFactory.Instantiate<EnemyStatus>(enemy.Enemy, Transform.position);
            PoolDisable();
        }

        public override void PoolDisable()
        {
            
            base.PoolDisable();
        }
    }
}