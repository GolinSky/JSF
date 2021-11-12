using Retrofit.Net;

namespace UnityEngine.MyPackage.Runtime.Scripts.Patterns.Proxy
{
    public abstract class BaseProxy<T,V> : IProxy<T> where T : IHttpContext where V: class, IRestService
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
}
