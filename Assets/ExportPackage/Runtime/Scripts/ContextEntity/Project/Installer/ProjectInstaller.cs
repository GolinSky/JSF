using CodeFramework.Runtime.BaseServices.ModelService.Service;
using Zenject;

namespace CodeFramework.Runtime.ContextEntity.Project.Installer
{
    public class ProjectInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.Bind<IModelService>().To<ModelService>().AsSingle().NonLazy();
        }
    }
}