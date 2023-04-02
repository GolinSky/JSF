using CodeFramework.Examples.RestTemplateEntity.Dto;
using CodeFramework.Examples.RestTemplateEntity.Rest;
using CodeFramework.Runtime.Proxy;

namespace CodeFramework.Examples.RestTemplateEntity.Proxy
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