using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Controller;
using Zenject;

namespace UnityEngine.Examples.ContextEntity.Scene.Loading
{
    public class LoadingInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ITickable>().To<SceneLoaderController>().AsSingle().NonLazy();
        }
    }
}