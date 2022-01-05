using System.Threading.Tasks;
using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using UnityEngine.Examples.RestTemplateEntity.Dto;
using UnityEngine.Examples.RestTemplateEntity.Proxy;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.Proxy;

namespace UnityEngine.Examples.RestTemplateEntity.Rest
{
    public interface ITemplateRestApi :IRestServiceApi
    {
        [Get("uuid")]
        Task<RestResponse<UIdDto>> GetUId();

        
        [Get("delay/{delay}")]
        RestResponse<DelayedDto> GetWithDelay([Path("delay")]int delay);
    }
}
