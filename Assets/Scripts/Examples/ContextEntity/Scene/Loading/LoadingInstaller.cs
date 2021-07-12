using Runtime.Scripts.BaseServices.SceneService.Controller;
using Zenject;

namespace Examples.ContextEntity.Scene.Loading
{
    public class LoadingInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
           Container.Bind<ITickable>().To<SceneLoaderController>().AsSingle().NonLazy();
        }
    }
}