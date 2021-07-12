using Examples.ExampleEntity.Controller;
using Examples.ExampleEntity.View;
using Runtime.Scripts.Extensions.MonoInstaller;
using Runtime.Scripts.Patterns.MVC.Controller;
using Runtime.Scripts.Utils.Ui.Fps;
using UnityEngine;
using Zenject;

namespace Examples.ContextEntity.Scene.Example
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
