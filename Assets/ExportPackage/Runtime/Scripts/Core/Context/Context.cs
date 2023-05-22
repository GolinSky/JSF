using System.Collections.Generic;

namespace CodeFramework
{
    public interface IContext<T>
    {
        List<T> Data { get; }
        List<T> LoadContext();
    }
}