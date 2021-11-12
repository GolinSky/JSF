namespace UnityEngine.MyPackage.Runtime.Scripts.Patterns.Proxy
{
    public interface IProxy<in T> where T:IHttpContext
    {
        void Request(T context);
    }
}
