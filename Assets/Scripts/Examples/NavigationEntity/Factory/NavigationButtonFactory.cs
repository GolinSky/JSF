using UnityEngine.Examples.NavigationEntity.Model;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.ModelService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Factory;

namespace UnityEngine.Examples.NavigationEntity.Factory
{
    public class NavigationButtonFactory : IMonoBehaviourFactory<IButtonView<SceneType>, NavigationType, RectTransform>
    {
        private readonly IModelService modelService; 

        public NavigationButtonFactory(IModelService modelService)
        {
            this.modelService = modelService;
        }
        
        public IButtonView<SceneType> CreateEntity(NavigationType id, RectTransform parent)
        {
            return Object.Instantiate(modelService.GetModel<NavigationModel>().GetById(id), parent);
        }
    }
}


