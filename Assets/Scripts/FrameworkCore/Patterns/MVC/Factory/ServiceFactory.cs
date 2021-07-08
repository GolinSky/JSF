using System;
using System.Collections.Generic;
using FrameworkCore.BaseServices.ModelService.Service;
using FrameworkCore.BaseServices.SceneService.Service;
using FrameworkCore.Patterns.MVC.Service;
using Zenject;

namespace FrameworkCore.Patterns.MVC.Factory
{
    public class ServiceFactory : IServiceFactory
    {
        private Dictionary<Type, BaseServiceLayer> ServiceDictionary =
            new Dictionary<Type, BaseServiceLayer>();

        [Inject]
        private readonly IModelService modelService;
        

        public T GetService<T>() where T : BaseServiceLayer
        {
            if (ServiceDictionary.ContainsKey(typeof(T)))
            {
                return ServiceDictionary[typeof(T)] as T;
            }

            return CreateServiceLayer<T>();
        }

        private T CreateServiceLayer<T>() where T : BaseServiceLayer
        {
            var instance = (T) Activator.CreateInstance(typeof(T), modelService);
            ServiceDictionary.Add(typeof(T), instance);
            return instance;
        }


        public void ResetLayers(SceneType sceneType)
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


    public interface IServiceFactory
    {
        T GetService<T>() where T : BaseServiceLayer;
        void ResetLayers(SceneType sceneType);
    }
}