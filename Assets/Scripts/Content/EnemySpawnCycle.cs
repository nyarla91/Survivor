using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Extentions;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Content
{
    [CreateAssetMenu(menuName = "Enemy Spawn Cycle", order = 0)]
    public class EnemySpawnCycle : ScriptableObject
    {
        [SerializeField] private EnemySpawnDetails[] _enemies;

        public EnemySpawnDetails[] Enemies => _enemies.ToArray();

        public async Task Load()
        {
            int enemiesLoaded = 0;
            foreach (EnemySpawnDetails enemy in _enemies)
            {
                LoadEnemy(enemy);
            }
            await enemiesLoaded.WaitForCondition(loaded => loaded == _enemies.Length, 20);

            async void LoadEnemy(EnemySpawnDetails enemy)
            {
                await enemy.Load();
                enemiesLoaded++;
            }
        }

        public void Unload() => _enemies.Foreach(enemy => enemy.Unload());
    }

    [Serializable]
    public class EnemySpawnDetails
    {
        [SerializeField] private AssetReference _enemyReference;
        
        [field: SerializeField] public float SpawnDelay{ get; private set; }
        [field: SerializeField] public int Count { get; private set; }
        public GameObject Enemy { get; private set; }

        public async Task Load()
        {
            Enemy = await _enemyReference.LoadAssetAsync<GameObject>().Task;
        }

        public void Unload()
        {
            Enemy = null;
            _enemyReference.ReleaseAsset();
        }
    }
}