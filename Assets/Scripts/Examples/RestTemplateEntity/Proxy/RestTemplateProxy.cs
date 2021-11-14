using RestSharp;
using UnityEngine.Examples.RestTemplateEntity.Dto;
using UnityEngine.Examples.RestTemplateEntity.Rest;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.Proxy;

namespace UnityEngine.Examples.RestTemplateEntity.Proxy
{
    public class RestTemplateProxy : BaseProxy<IHttpContext, ITemplateRestService, UIdDto>
    {
        public override void Request(IHttpContext context)
        {
            RestResponse<UIdDto> personResponse = restService.GetUId();
            UpdateDto(personResponse);
        }

        public RestTemplateProxy(IServerModelMiddleWare serverModelMiddleWare) : base(serverModelMiddleWare)
        {
        }
    }
}