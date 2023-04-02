using CodeFramework.Runtime.Proxy;

namespace CodeFramework.Examples.RestTemplateEntity.HttpContext
{
    public interface IDelayHttpContext : IHttpContext
    {
        int Duration { get; }
    }
}
