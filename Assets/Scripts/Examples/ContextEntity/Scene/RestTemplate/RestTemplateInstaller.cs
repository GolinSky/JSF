using UnityEngine.Examples.RestTemplateEntity.Controller;
using UnityEngine.Examples.RestTemplateEntity.View;
using UnityEngine.MyPackage.Runtime.Scripts.Extensions.MonoInstaller;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Controller;
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
            Container.Bind<IController>()
                .To<TemplateController>()
                .WithArguments(restTemplateView)
                .WhenInjectedInto<RestTemplateView>();
        }
    }
}