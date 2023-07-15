namespace CodeFramework.Runtime.Controllers.Proxy
{
    public interface IProxy<in T> where T:IHttpContext
    {
        void Request(T context);
    }
}
