using UnityEngine;
using Component = UnityEngine.Component;
using MonoInstaller = Zenject.MonoInstaller;

namespace Extentions.Factory
{
    public class ContainerFactory : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ContainerFactory>().FromInstance(this).AsSingle();
        }

        public T Instantiate<T>(GameObject prefab, Transform parent) where T : Component
            => Instantiate(prefab, parent).GetComponent<T>();
        
        public GameObject Instantiate(GameObject prefab, Transform parent) 
            => Container.InstantiatePrefab(prefab, parent);
    }
}