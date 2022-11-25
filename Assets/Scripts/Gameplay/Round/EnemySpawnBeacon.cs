using System;
using Content;
using Extentions;
using Extentions.Factory;
using Extentions.Menu;
using Gameplay.Units.Enemy;
using UnityEngine;
using Zenject;

namespace Gameplay.Round
{
    public class EnemySpawnBeacon : PooledObject
    {
        [SerializeField] private float _delay;

        
        [Inject] private ContainerFactory ContainerFactory { get; set; }
        [Inject] private Pause Pause { get; set; }
        
        public async void Init(PoolFactory enemyFactory, PoolFactory experienceFactory, EnemySpawnDetails enemy)
        {
            Timer delay = new Timer(this, _delay, Pause);
            delay.Start();
            
            await delay.GetTask();

            GameObject prefab = enemy.Enemy;
            EnemyStatus newEnemy = enemyFactory.GetNewObject<EnemyStatus>(Transform.position, prefab, null, prefab.name);
            newEnemy.ExperienceFactory = experienceFactory;
            PoolDisable();
        }

        public override void PoolDisable()
        {
            
            base.PoolDisable();
        }
    }
}