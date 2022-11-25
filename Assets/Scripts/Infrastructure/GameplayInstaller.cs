using Extentions.Menu;
using Gameplay.Infrastrucure;
using Gameplay.Units.Player;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private EntityLayersSettings _entityLayersSettings;
        [SerializeField] private Transform _characterSpawnPoint;
        [SerializeField] private GameObject _characterPrefab;
        [SerializeField] private GameObject _pausePrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<EntityLayersSettings>().FromInstance(_entityLayersSettings).AsSingle();
            BindFromPrefab<Pause>(_pausePrefab, Vector3.zero);
            
            CharacterComposition composition = BindFromPrefab<CharacterComposition>(_characterPrefab, _characterSpawnPoint.position);
            Container.Bind<CharacterMovement>().FromInstance(composition.Movement).AsSingle();
        }
        
        private T BindFromPrefab<T>(GameObject prefab, Vector3 position, Transform parent = null) where T : Component
        {
            T instance = Container.InstantiatePrefab(prefab, position, Quaternion.identity, parent).GetComponent<T>();
            Container.Bind<T>().FromInstance(instance).AsSingle();
            return instance;
        }
    }
}