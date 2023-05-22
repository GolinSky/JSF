using CodeFramework.RetrogitRestPackage;
using CodeFramework.Runtime.BaseServices.SerializerService;
using RestSharp;

namespace CodeFramework.Runtime.Proxy
{
    public abstract class BaseProxy<T,V> : IProxy<T> where T : IHttpContext where V: class, IRestServiceApi
    {
        protected readonly V restService;
        private readonly RestAdapter adapter;
        protected BaseProxy(IServerModelMiddleWare serverModelMiddleWare)
        {
            adapter = new RestAdapter(serverModelMiddleWare.ServerUri.AbsoluteUri);
            restService = adapter.Create<V>();
            
        }
        
        
        public abstract void Request(T context);

    }
    
    
    public abstract class BaseProxy<T,V,D> : BaseProxy<T,V> where V : class, IRestServiceApi where T : IHttpContext
    {
        protected readonly ISerializerService serializerService;
        
        protected virtual void UpdateDto(RestResponse<D> restResponse)
        {
            D d = serializerService.Deserialize<D>(restResponse.Content);
            // serviceLayer.UpdateDto(d);
        }


        protected BaseProxy(IServerModelMiddleWare serverModelMiddleWare) : base(serverModelMiddleWare)
        {
        }
    }
}
