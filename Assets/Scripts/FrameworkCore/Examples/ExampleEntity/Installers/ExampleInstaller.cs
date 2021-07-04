using FrameworkCore.Examples.ExampleEntity.Controller;
using FrameworkCore.Examples.ExampleEntity.View;
using FrameworkCore.Patterns.MVC.Controller;
using Zenject;

namespace FrameworkCore.Examples.ExampleEntity.Installers
{
    public class ExampleInstaller : MonoInstaller
    {
        public ExampleView exampleView;

        public override void InstallBindings()
        {
            Container.Bind<ExampleController>().AsSingle().WithArguments(exampleView);
            Container.Bind<IController>()
                .To<ExampleController>()
                .FromResolve();
        }
    }
}
