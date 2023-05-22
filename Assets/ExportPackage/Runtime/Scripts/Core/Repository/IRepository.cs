using UnityEngine;

namespace CodeFramework
{
    public interface IRepository<TKey>
    {
        TResource Load<TResource>(TKey key) where TResource : Object;
    }
}