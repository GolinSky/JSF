using UnityEngine.Examples.ExampleEntity.Controller;
using UnityEngine.Examples.ExampleEntity.Service;
using UnityEngine.Examples.ExampleEntity.View;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.ServiceLayer;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.View;
using UnityEngine.MyPackage.Runtime.Scripts.Utils.Ui.Fps;
using Zenject;

namespace UnityEngine.Examples.ContextEntity.Scene.Example
{
    public class ExampleInstaller : MonoInstaller
    {
        [SerializeField] private ExampleView exampleView;
        [SerializeField] private FpsCounterView fpsCounterView;

        private void OnValidate()
        {
            // this.FindViewDependency(ref exampleView);
            //  this.FindViewDependency(ref fpsCounterView);
        }

        public override void InstallBindings()
        {
            
            Container.BindInterfacesTo<ExampleServiceLayer>()
                .AsSingle()
                .NonLazy();

            Container.Bind<IView<string>>()
                .To<ExampleView>()
                .FromInstance(exampleView)
                .WhenInjectedInto<ExampleController>();

            Container.Bind<IView<string>>()
                .To<FpsCounterView>()
                .FromInstance(fpsCounterView)
                .WhenInjectedInto<FpsCounterController>();
            
          
            Container.BindInterfacesTo<ExampleController>()
                .AsSingle();
            Container.BindInterfacesTo<FpsCounterController>()
                .AsSingle();
        }
    }
}