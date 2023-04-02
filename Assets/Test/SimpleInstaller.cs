using Zenject;

namespace CodeFramework.Test
{
    public class SimpleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Container.Bind<SimpleController>()
            //     .To<ISimpleViewController>()
            //     .AsSingle()
            //     .WhenInjectedInto<SimpleView>();
        }
    }
}