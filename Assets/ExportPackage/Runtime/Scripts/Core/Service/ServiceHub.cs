using System.Collections.Generic;
using System.Linq;

namespace CodeFramework
{
    public class ServiceHub:IHub<IService>
    {
        protected List<IService> services;

        public ServiceHub(IEnumerable<IService> services)
        {
            var enumerable = services as IService[] ?? services.ToArray();
            this.services = enumerable.ToList();
            foreach (var service in enumerable)
            {
                service.Init(this);
            }
        }

        public TEntity Get<TEntity>()
        {
            foreach (var service in services)
            {
                if (service is TEntity entity)
                {
                    return entity;
                }
            }
        
            return default;
        }

        public void Remove(IService entity)
        {
            services?.Remove(entity);
        }
    }
}