using RestSharp;
using UnityEngine.Examples.RestTemplateEntity.Dto;
using UnityEngine.Examples.RestTemplateEntity.Rest;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.Proxy;

namespace UnityEngine.Examples.RestTemplateEntity.Proxy
{
    public class RestTemplateProxy : BaseProxy<IHttpContext, ITemplateRestApi, UIdDto>
    {
        public override void Request(IHttpContext context)
        {
            Test();
        }

        private async void Test()
        {
            await restService.GetUId();
            
            UpdateDto(restService.GetUId().Result);
        }

        public RestTemplateProxy(IServerModelMiddleWare serverModelMiddleWare) : base(serverModelMiddleWare)
        {
        }
    }
}