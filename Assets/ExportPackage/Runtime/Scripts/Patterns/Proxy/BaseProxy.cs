using RestSharp;
using Retrofit.Net;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SerializerService;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.ServiceLayer;
using Zenject;

namespace UnityEngine.MyPackage.Runtime.Scripts.Patterns.Proxy
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
        [Inject] protected readonly IDtoLayer<D> serviceLayer;
        [Inject] protected readonly ISerializerService serializerService;
        
        protected virtual void UpdateDto(RestResponse<D> restResponse)
        {
            D d = serializerService.Deserialize<D>(restResponse.Content);
            serviceLayer.UpdateDto(d);
        }


        protected BaseProxy(IServerModelMiddleWare serverModelMiddleWare) : base(serverModelMiddleWare)
        {
        }
    }
}
