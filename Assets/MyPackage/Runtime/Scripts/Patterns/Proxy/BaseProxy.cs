using System.Collections.Generic;
using RestSharp;
using Retrofit.Net;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SerializerService;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.ServiceLayer;
using Zenject;

namespace UnityEngine.MyPackage.Runtime.Scripts.Patterns.Proxy
{
    public abstract class BaseProxy<T,V,D> : IProxy<T> where T : IHttpContext where V: class, IRestService
    {
        [Inject] protected readonly IDtoLayer<D> serviceLayer;
        [Inject] protected readonly ISerializerService serializerService;
        protected readonly V restService;
        private readonly RestAdapter adapter;
        protected BaseProxy(IServerModelMiddleWare serverModelMiddleWare)
        {
            adapter = new RestAdapter(serverModelMiddleWare.ServerUri.AbsoluteUri);
            restService = adapter.Create<V>();
            
        }

        protected virtual void UpdateDto(RestResponse<D> restResponse)
        {
            D d = serializerService.Deserialize<D>(restResponse.Content);
            serviceLayer.UpdateDto(d);
        }
        
        public abstract void Request(T context);

    }
}
