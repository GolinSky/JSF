using System.Threading.Tasks;
using CodeFramework.Examples.RestTemplateEntity.Dto;
using CodeFramework.Examples.RestTemplateEntity.Proxy;
using CodeFramework.RetrogitRestPackage.Attributes.Methods;
using CodeFramework.RetrogitRestPackage.Attributes.Parameters;
using CodeFramework.Runtime.Proxy;
using RestSharp;

namespace CodeFramework.Examples.RestTemplateEntity.Rest
{
    public interface ITemplateRestApi :IRestServiceApi
    {
        [Get("uuid")]
        Task<RestResponse<UIdDto>> GetUId();

        
        [Get("delay/{delay}")]
        RestResponse<DelayedDto> GetWithDelay([Path("delay")]int delay);
    }
}
