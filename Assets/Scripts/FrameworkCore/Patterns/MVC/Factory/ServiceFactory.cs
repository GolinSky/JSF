using System;
using System.Collections.Generic;
using FrameworkCore.BaseServices.SceneService.Service;

namespace FrameworkCore.Patterns.MVC.Factory
{
    public static class ServiceFactory
    {
        private static Dictionary<Type, Service.BaseServiceLayer> ServiceDictionary =
            new Dictionary<Type, Service.BaseServiceLayer>();

        public static T GetService<T>() where T : Service.BaseServiceLayer
        {
            if (ServiceDictionary.ContainsKey(typeof(T)))
            {
                return ServiceDictionary[typeof(T)] as T;
            }
            else
            {
                var instance = (T) Activator.CreateInstance(typeof(T));
                ServiceDictionary.Add(typeof(T), instance);
                return instance;
            }
        }

        public static void ResetLayers(SceneType sceneType)
        {
            foreach (var serviceLayer in ServiceDictionary.Values)
            {
                if (serviceLayer.ResetScene == sceneType)
                {
                    serviceLayer.Reset();
                }
            }
        }
}
}