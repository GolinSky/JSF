using UnityEngine;

namespace CodeFramework
{
    public class ResourceRepository : IRepository<string>
    {
        public TResource Load<TResource>(string key) where TResource : Object
        {
            return Resources.Load<TResource>(key);
        }
    }
}