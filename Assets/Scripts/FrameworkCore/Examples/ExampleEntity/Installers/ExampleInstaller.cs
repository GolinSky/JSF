using FrameworkCore.Examples.ExampleEntity.Controller;
using FrameworkCore.Examples.ExampleEntity.View;
using FrameworkCore.Patterns.MVC.Controller;
using FrameworkCore.Utils.Ui.Fps;
using UnityEngine;
using Zenject;

namespace FrameworkCore.Examples.ExampleEntity.Installers
{
    public class ExampleInstaller : MonoInstaller
    {
        [SerializeField] private ExampleView exampleView;
        [SerializeField] private FpsCounterView fpsCounterView;

        private void OnValidate()
        {
            FindViewDependency(ref exampleView);
            FindViewDependency(ref fpsCounterView);
        }
 
        private void FindViewDependency<T>(ref T t) where  T:Patterns.MVC.View.View
        {
            if (t == null)
            {
                var result = FindObjectOfType<T>();
                if (result)
                {
                    t =  result;
                }
            }
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
