using FrameworkCore.BaseServices.SceneService.Service;
using FrameworkCore.MonoBehaviourEntity.Service;
using FrameworkCore.Patterns.MVC.Controller;
using UnityEngine;

namespace FrameworkCore.BaseServices.SceneService.Controller
{
    public class SceneLoadAsynController : UpdateController
    {
        private AsyncOperation asyncOperation;
        private const float ProgressValue = 0.89f;
        public SceneLoadAsynController(IUpdater updater, ILevelService levelService) : base(updater)
        {
            asyncOperation = levelService.LoadSceneAsync();
            asyncOperation.allowSceneActivation = false;   
        }
        
        protected override void Update()
        {
            if (asyncOperation.progress > ProgressValue)
            {
                asyncOperation.allowSceneActivation = true;
            }
        }
    }
}