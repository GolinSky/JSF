using RestSharp;
using Retrofit.Net;
using UnityEngine.Examples.RestTemplateEntity.Dto;
using UnityEngine.Examples.RestTemplateEntity.Rest;
using UnityEngine.Examples.RestTemplateEntity.View;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Controller;

namespace UnityEngine.Examples.RestTemplateEntity.Controller
{
    public class TemplateController : Controller<RestTemplateView>
    {
        public TemplateController(RestTemplateView view) : base(view)
        {
            
            RestAdapter adapter = new RestAdapter("http://httpbin.org");
            ITemplateRestService service = adapter.Create<ITemplateRestService>();
            RestResponse<TestDto> personResponse = service.GetUId();
            
            Debug.Log(personResponse.Data);
        }
    }
}
