using RestSharp;
using UnityEngine.Examples.RestTemplateEntity.Dto;
using UnityEngine.Examples.RestTemplateEntity.Rest;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.Proxy;

namespace UnityEngine.Examples.RestTemplateEntity.Proxy
{
    public class RestTemplateProxy : BaseProxy<IHttpContext, ITemplateRestService>
    {
        public override void Request(IHttpContext context)
        {
            RestResponse<TestDto> personResponse = restService.GetUId();
            Debug.Log(personResponse.Data);
        }

        public RestTemplateProxy(IServerModelMiddleWare serverModelMiddleWare) : base(serverModelMiddleWare)
        {
        }
    }
}