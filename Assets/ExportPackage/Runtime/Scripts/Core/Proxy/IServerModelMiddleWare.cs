using System;

namespace CodeFramework.Runtime.Controllers.Proxy
{
    public interface IServerModelMiddleWare
    {
        Uri ServerUri { get; }
    }
}