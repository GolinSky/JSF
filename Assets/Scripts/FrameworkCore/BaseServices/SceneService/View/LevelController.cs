using FrameworkCore.BaseServices.SceneService.Service;
using FrameworkCore.Patterns.MVC.Controller;
using UnityEngine;

namespace FrameworkCore.BaseServices.SceneService.View
{
    public class LevelController : Controller<LevelView>
    {
        private AsyncOperation asyncOperation;
        private const float ProgressValue = 0.89f;
        
        public LevelController(LevelView view, ILevelService levelService) : base(view)
        {
            asyncOperation = levelService.LoadSceneAsync();
            asyncOperation.allowSceneActivation = false;    
        }

        public override void AddListeners()
        {
        }

        public override void RemoveListeners()
        {
        }

        public override void Execute()
        {
            base.Execute();
          
            
            if (asyncOperation.progress > ProgressValue)
            {
                asyncOperation.allowSceneActivation = true;
            }
        }
    }
}