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
        }
    }
}