namespace CodeFramework.Runtime.Proxy
{
    public interface IProxy<in T> where T:IHttpContext
    {
        void Request(T context);
    }
}
