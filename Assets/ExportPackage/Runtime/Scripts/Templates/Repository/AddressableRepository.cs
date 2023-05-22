using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeFramework
{
    public class AddressableRepository: IRepository<string>
    {
        public  TResource Load<TResource>(string key) where TResource : Object
        {
            return Addressables.LoadAssetAsync<TResource>(key).Result;
        }
    }
    
  
}