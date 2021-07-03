using UnityEngine;

namespace FrameworkCore.BaseServices.SceneService.View
{
    public class LevelView : MonoBehaviour
    {
        
        private AsyncOperation asyncOperation;
        private const double ProgressValue = 0.89;

        private void Start()
        {
            asyncOperation = BaseServices.SceneService.Service.SceneService.LoadSceneAsync();
            asyncOperation.allowSceneActivation = false;    
        }

        private void Update()
        {
            if (asyncOperation.progress > ProgressValue)
            {
                asyncOperation.allowSceneActivation = true;
            }
        }
    }
}