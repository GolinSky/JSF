using FrameworkCore.BaseServices.SceneService.Controller;
using Zenject;

namespace FrameworkCore.ContextEntity.Scene.Loading
{
    public class LoadingInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
           Container.Bind<ITickable>().To<SceneLoaderController>().AsSingle().NonLazy();
        }
    }
}