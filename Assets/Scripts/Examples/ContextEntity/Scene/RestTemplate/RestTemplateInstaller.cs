using UnityEngine.Examples.RestTemplateEntity.Controller;
using UnityEngine.Examples.RestTemplateEntity.MiddleWare;
using UnityEngine.Examples.RestTemplateEntity.Proxy;
using UnityEngine.Examples.RestTemplateEntity.View;
using UnityEngine.MyPackage.Runtime.Scripts.Extensions.MonoInstaller;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Controller;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.Proxy;
using Zenject;

namespace UnityEngine.Examples.ContextEntity.Scene.RestTemplate
{
    public class RestTemplateInstaller : MonoInstaller
    {
        [SerializeField] private RestTemplateView restTemplateView;


        private void OnValidate()
        {
            this.FindViewDependency(ref restTemplateView);
        }

        public override void InstallBindings()
        {
            Container.Bind<IServerModelMiddleWare>()
                .To<RestTemplateMiddleWare>()
                .AsSingle();


            Container.Bind<IProxy<IHttpContext>>()
                .To<RestTemplateProxy>()
                .WhenInjectedInto<TemplateController>();

            Container.Bind<IController>()
                .To<TemplateController>()
                .WithArguments(restTemplateView)
                .WhenInjectedInto<RestTemplateView>();
        }
    }
}