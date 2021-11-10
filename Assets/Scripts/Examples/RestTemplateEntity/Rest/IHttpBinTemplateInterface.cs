using RestSharp;
using Retrofit.Net.Attributes.Methods;
using UnityEngine.Examples.RestTemplateEntity.Dto;

namespace UnityEngine.Examples.RestTemplateEntity.Rest
{
    public interface ITemplateRestService 
    {
        [Get("uuid")]
        RestResponse<TestDto> GetUId();
    }
}
