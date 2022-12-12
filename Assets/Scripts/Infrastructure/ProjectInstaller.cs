using RunProgress;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _runProgressionPrefab;
        
        public override void InstallBindings()
        {
            GameObject runProgression = Container.InstantiatePrefab(_runProgressionPrefab);
            Container.Bind<PlayerLevel>().FromInstance(runProgression.GetComponent<PlayerLevel>());
            Container.Bind<PlayerKit>().FromInstance(runProgression.GetComponent<PlayerKit>());
            Container.Bind<PlayerStats>().FromInstance(runProgression.GetComponent<PlayerStats>());
            Container.Bind<RunRounds>().FromInstance(runProgression.GetComponent<RunRounds>());
            Container.Bind<ShopPool>().FromInstance(runProgression.GetComponent<ShopPool>());
            Container.Bind<RunSceneLoader>().FromInstance(runProgression.GetComponent<RunSceneLoader>());
        }
    }
}