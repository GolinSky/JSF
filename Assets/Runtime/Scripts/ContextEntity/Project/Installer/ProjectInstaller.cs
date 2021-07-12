using Runtime.Scripts.BaseServices.ModelService.Service;
using Runtime.Scripts.BaseServices.SceneService.Service;
using Runtime.Scripts.Patterns.MVC.Factory;
using Zenject;

namespace Runtime.Scripts.ContextEntity.Project.Installer
{
    public class ProjectInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.Bind<IModelService>().To<ModelService>().AsSingle().NonLazy();
            Container.Bind<IServiceFactory>().To<ServiceFactory>().AsSingle().NonLazy();
            Container.Bind<ILevelService>().To<LevelService>().AsSingle().NonLazy();
        }
    }
}