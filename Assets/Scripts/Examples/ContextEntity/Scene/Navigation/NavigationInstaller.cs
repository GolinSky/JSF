using UnityEngine.Examples.NavigationEntity.Controller;
using UnityEngine.Examples.NavigationEntity.Factory;
using UnityEngine.Examples.NavigationEntity.Model;
using UnityEngine.Examples.NavigationEntity.View;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.Extensions.MonoInstaller;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Controller;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Factory;
using Zenject;

namespace UnityEngine.Examples.ContextEntity.Scene.Navigation
{
    public class NavigationInstaller : MonoInstaller
    {
        [SerializeField] private NavigationView navigationView;

        private void OnValidate()
        {
            this.FindViewDependency(ref navigationView);
        }

        public override void InstallBindings()
        {
            Container.Bind<IController>()
                .To<NavigationController>()
                .WithArguments(navigationView)
                .WhenInjectedInto<NavigationView>();

            Container.Bind<IMonoBehaviourFactory<IButtonView<SceneType>, NavigationType, RectTransform>>()
                .To<NavigationButtonFactory>()
                .WhenInjectedInto<NavigationController>();

        }
    }
}