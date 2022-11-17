using Gameplay.Infrastrucure;
using Gameplay.Units.Player;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private EntityLayersSettings entityLayersSettings;
        [SerializeField] private Transform _characterSpawnPoint;
        [SerializeField] private GameObject _characterPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<EntityLayersSettings>().FromInstance(entityLayersSettings).AsSingle();
            
            CharacterComposition composition = Container.InstantiatePrefab(_characterPrefab).GetComponent<CharacterComposition>();
            Container.Bind<CharacterComposition>().FromInstance(composition).AsSingle();
            Container.Bind<CharacterMovement>().FromInstance(composition.Movement).AsSingle();
        }
    }
}