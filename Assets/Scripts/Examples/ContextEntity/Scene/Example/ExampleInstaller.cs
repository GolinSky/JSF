using UnityEngine.Examples.ExampleEntity.Controller;
using UnityEngine.Examples.ExampleEntity.View;
using UnityEngine.Package.Runtime.Scripts.Extensions.MonoInstaller;
using UnityEngine.Package.Runtime.Scripts.Patterns.MVC.Controller;
using UnityEngine.Package.Runtime.Scripts.Utils.Ui.Fps;
using Zenject;

namespace UnityEngine.Examples.ContextEntity.Scene.Example
{
    public class ExampleInstaller : MonoInstaller
    {
        [SerializeField] private ExampleView exampleView;
        [SerializeField] private FpsCounterView fpsCounterView;

        private void OnValidate()
        {
            this.FindViewDependency(ref exampleView);
            this.FindViewDependency(ref fpsCounterView);
        }
        
        public override void InstallBindings()
        {
            Container.Bind<IController>()
                .To<ExampleController>()
                .WithArguments(exampleView)
                .WhenInjectedInto<ExampleView>();
            
            Container.Bind<IController>()
                .To<FpsCounterController>()
                .WithArguments(fpsCounterView)
                .WhenInjectedInto<FpsCounterView>();

        }
    }
}
