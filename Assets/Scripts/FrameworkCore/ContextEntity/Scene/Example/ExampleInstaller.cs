using FrameworkCore.Examples.ExampleEntity.Controller;
using FrameworkCore.Examples.ExampleEntity.View;
using FrameworkCore.Extensions.MonoInstaller;
using FrameworkCore.Patterns.MVC.Controller;
using FrameworkCore.Utils.Ui.Fps;
using UnityEngine;
using Zenject;

namespace FrameworkCore.ContextEntity.Scene.Example
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
