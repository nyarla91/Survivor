using System.Collections;
using Content;
using Extentions;
using Extentions.Factory;
using Extentions.Menu;
using UnityEngine;
using Zenject;

namespace Gameplay.Round
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private PoolFactory _beaconFactory;
        [SerializeField] private PoolFactory _enemyFactory;
        [SerializeField] private PoolFactory _experienceFactory;
        [SerializeField] private BoxCollider2D _spawnArea;
        [SerializeField] private EnemySpawnCycle _cycle;

        [Inject] private Pause Pause { get; set; }
        
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
            Timer _spawnTimer = new Timer(this, enemies[0].SpawnDelay, Pause);
            for (int i = 0; i < enemies.Length; i = (i + 1).RepeatIndex(enemies.Length))
            {
                _spawnTimer.Length = enemies[i].SpawnDelay;
                _spawnTimer.Restart();
                yield return _spawnTimer.Yield;
                for (int j = 0; j < enemies[i].Count; j++)
                {
                    Vector2 position = _spawnArea.bounds.RandomPointInBounds2D();
                    EnemySpawnBeacon beacon = _beaconFactory.GetNewObject<EnemySpawnBeacon>(position);
                    beacon.Init(_enemyFactory, _experienceFactory, enemies[i]);
                }
            }
        }

        private void OnDestroy()
        {
            _cycle.Unload();
        }
    }
}