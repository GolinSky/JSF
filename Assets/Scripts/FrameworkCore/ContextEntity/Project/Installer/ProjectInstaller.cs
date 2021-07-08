using FrameworkCore.BaseServices.ModelService.Service;
using FrameworkCore.BaseServices.SceneService.Service;
using Zenject;

namespace FrameworkCore.ContextEntity.Project.Installer
{
    public class ProjectInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.Bind<IModelService>().To<ModelService>().AsSingle().NonLazy();
            Container.Bind<ILevelService>().To<LevelService>().AsSingle().NonLazy();
        }
    }
}