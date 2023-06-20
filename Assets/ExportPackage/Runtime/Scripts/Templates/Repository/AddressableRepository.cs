using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeFramework
{
    public class AddressableRepository: IRepository<string>
    {
        public TResource Load<TResource>(string key) where TResource : Object
        {
            return LoadAsync<TResource>(key).Result;
        }
        
        private async Task<TResource> LoadAsync<TResource>(string key) where TResource : Object
        {
            var op =Addressables.LoadAssetAsync<TResource>(key).Task;
            var result = await op;
            //return result;
            return op.Result;
        }
    }
    
  
}