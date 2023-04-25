using UnityEngine;
using Zenject;

namespace CodeFramework.Test
{
    public class SimpleInstaller : MonoInstaller
    {
        [SerializeField] protected SimpleView simpleViewPrefab;
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SimpleController>()
                .AsSingle()
                .NonLazy();
            
            Container.InstantiatePrefab(simpleViewPrefab);
        }
    }
}