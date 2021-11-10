using UnityEngine.Examples.RestTemplateEntity.View;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Controller;

namespace UnityEngine.Examples.RestTemplateEntity.Controller
{
    public class TemplateController : Controller<RestTemplateView>
    {
        public TemplateController(RestTemplateView view) : base(view)
        {
            
            // RetrofitAdapter adapter = new RetrofitAdapter.Builder()
            //     .SetEndpoint("http://httpbin.org")
            //     .Build();
            // var httpService = adapter.Create<IHttpBinTemplateInterface>();
        }
    }
}
