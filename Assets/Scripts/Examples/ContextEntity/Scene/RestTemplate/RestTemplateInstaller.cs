using UnityEngine.Examples.RestTemplateEntity.Context;
using UnityEngine.Examples.RestTemplateEntity.Controller;
using UnityEngine.Examples.RestTemplateEntity.Dto;
using UnityEngine.Examples.RestTemplateEntity.HttpContext;
using UnityEngine.Examples.RestTemplateEntity.MiddleWare;
using UnityEngine.Examples.RestTemplateEntity.Proxy;
using UnityEngine.Examples.RestTemplateEntity.ServiceLayer;
using UnityEngine.Examples.RestTemplateEntity.View;
using UnityEngine.MyPackage.Runtime.Scripts.Extensions.MonoInstaller;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Controller;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.ServiceLayer;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.Proxy;
using Zenject;

namespace UnityEngine.Examples.ContextEntity.Scene.RestTemplate
{
    public class RestTemplateInstaller : MonoInstaller
    {
        [SerializeField] private RestUidView restUidView;
        [SerializeField] private UIdView uIdView;


        private void OnValidate()
        {
            this.FindViewDependency(ref restUidView);
            this.FindViewDependency(ref uIdView);
        }

        public override void InstallBindings()
        {
            Container.Bind<IServerModelMiddleWare>()
                .To<RestTemplateMiddleWare>()
                .AsSingle();

            Container.Bind(typeof(IContextLayer<UIdContext>), typeof(IDtoLayer<UIdDto>))
                .To<UIdServiceLayer>()
                .AsSingle();

            Container.Bind<IProxy<IHttpContext>>()
                .To<RestTemplateProxy>()
                .WhenInjectedInto<UIdRestController>();

            Container.Bind<IProxy<IDelayHttpContext>>()
                .To<RestDelayProxy>()
                .AsSingle();

            Container.Bind<IController>()
                .To<UIdRestController>()
                .WithArguments(restUidView)
                .WhenInjectedInto<RestUidView>();
            
            Container.Bind<IController>()
                .To<UIdController>()
                .WithArguments(uIdView)
                .WhenInjectedInto<UIdView>();
            
            
        }
    }
}