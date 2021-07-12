using Runtime.Scripts.BaseServices.SceneService.Service;
using Runtime.Scripts.Patterns.MVC.Controller;
using UnityEngine;

namespace Runtime.Scripts.BaseServices.SceneService.Controller
{
    public class SceneLoaderController : UpdateController
    {
        private AsyncOperation asyncOperation;
        private const float ProgressValue = 0.89f;
        public SceneLoaderController(ILevelService levelService) 
        {
            asyncOperation = levelService.LoadSceneAsync();
            asyncOperation.allowSceneActivation = false;   
        }

        public override void Tick()
        {
            if (asyncOperation.progress > ProgressValue)
            {
                asyncOperation.allowSceneActivation = true;
            }
        }
    }
}