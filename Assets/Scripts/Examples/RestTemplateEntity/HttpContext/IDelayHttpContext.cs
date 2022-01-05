using UnityEngine.MyPackage.Runtime.Scripts.Patterns.Proxy;

namespace UnityEngine.Examples.RestTemplateEntity.HttpContext
{
    public interface IDelayHttpContext : IHttpContext
    {
        int Duration { get; }
    }
}
