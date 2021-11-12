using UnityEngine.Examples.RestTemplateEntity.View;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Controller;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.Proxy;
using Zenject;

namespace UnityEngine.Examples.RestTemplateEntity.Controller
{
    public class TemplateController : Controller<RestTemplateView>
    {
        [Inject] private readonly IProxy<IHttpContext> proxy;
        public TemplateController(RestTemplateView view) : base(view)
        {
        
        }
        
        public override void AddListeners()
        {
            base.AddListeners();
            View.AddListener(SendRequest);
        }

        public override void RemoveListeners()
        {
            base.RemoveListeners();
            View.RemoveListener(SendRequest);
        }

        private void SendRequest()
        {
            proxy.Request(null);
        }
    }
}
