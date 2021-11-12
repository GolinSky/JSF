using RestSharp;
using Retrofit.Net.Attributes.Methods;
using UnityEngine.Examples.RestTemplateEntity.Dto;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.Proxy;

namespace UnityEngine.Examples.RestTemplateEntity.Rest
{
    public interface ITemplateRestService :IRestService
    {
        [Get("uuid")]
        RestResponse<TestDto> GetUId();
    }
}
