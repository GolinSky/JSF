using System.Collections.Generic;
using System.Linq;
using UnityEngine.Examples.LevelEntity.Model;
using UnityEngine.Examples.NavigationEntity.Model;
using UnityEngine.Examples.NavigationEntity.View;
using UnityEngine.LevelEntity.Service;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.ModelService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Controller;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Factory;
using UnityEngine.UI;
using Zenject;

namespace UnityEngine.Examples.NavigationEntity.Controller
{
    public class NavigationController : Controller<NavigationView>
    {
        private const NavigationType ButtonType = NavigationType.USUAL_BUTTON;

        private readonly List<Button> buttons;
        private readonly List<IButtonView<SceneType>> buttonList;
        private readonly List<SceneType> sceneTypesList;
        [Inject]
        private readonly ILevelService levelService;

        public NavigationController(NavigationView view, IServiceFactory serviceFactory, IModelService modelService, IMonoBehaviourFactory<IButtonView<SceneType>,NavigationType, RectTransform> baseFactory) : base(view, serviceFactory)
        {
            var levelModel = modelService.GetModel<LevelModel>();
            var keys = levelModel.Keys.ToList(); 
            
            buttonList = new List<IButtonView<SceneType>>();
            foreach (var x in keys)
            {
                IButtonView<SceneType> button = baseFactory.CreateEntity(ButtonType, view.ButtonParentRect);
                button.SetContext(x);
                buttonList.Add(button);
            }
        }

        public override void AddListeners()
        {
            base.AddListeners();
            buttonList.ForEach(x=>x.AddListener(HandleOnClickEvent));
        }

        public override void RemoveListeners()
        {
            base.RemoveListeners();
            buttonList.ForEach(x=>x.RemoveListener(HandleOnClickEvent));
        }

        private void HandleOnClickEvent(SceneType type)
        {
            levelService.LoadScene(type);
        }
    }
}
