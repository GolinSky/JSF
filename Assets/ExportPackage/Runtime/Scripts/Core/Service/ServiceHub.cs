using System.Collections.Generic;

namespace ExportPackage.Runtime.Scripts.Core
{
    public class ServiceHub:IHub<IService>
    {
        protected Dictionary<string, IService> Services { get; }

        public ServiceHub(IEnumerable<IService> services)
        {
            Services = new Dictionary<string, IService>();
            foreach (var service in services)
            {
                Services.Add(service.Id, service);
            }
        }
        
        public IService Get(string id)
        {
            if (Services.TryGetValue(id, out var service))
            {
                return service;
            }

            return default;
        }

        public void Remove(IService entity)
        {
            foreach (var keyValuePair in Services)
            {
                if (keyValuePair.Value == entity)
                {
                    Services.Remove(keyValuePair.Key);//it can 
                    break;
                }
            }
        }
    }
}