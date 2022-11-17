using System.Collections;
using Content;
using Extentions;
using Extentions.Factory;
using UnityEngine;

namespace Gameplay.Round
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private PoolFactory _beaconFactory;
        [SerializeField] private PoolFactory _enemyFactory;
        [SerializeField] private PoolFactory _experienceFactory;
        [SerializeField] private BoxCollider2D _spawnArea;
        [SerializeField] private EnemySpawnCycle _cycle;

        private async void Awake()
        {
            await _cycle.Load();
        }

        private async void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            EnemySpawnDetails[] enemies = _cycle.Enemies;
            for (int i = 0; i < enemies.Length; i = (i + 1).RepeatIndex(enemies.Length))
            {
                yield return new WaitForSeconds(enemies[i].SpawnDelay);
                for (int j = 0; j < enemies[i].Count; j++)
                {
                    Vector2 position = _spawnArea.bounds.RandomPointInBounds2D();
                    EnemySpawnBeacon beacon = _beaconFactory.GetNewObject<EnemySpawnBeacon>(position);
                    beacon.Init(_enemyFactory, enemies[i]);
                }
            }
        }

        private void OnDestroy()
        {
            _cycle.Unload();
        }
    }
}