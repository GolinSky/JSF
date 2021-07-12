using System;
using System.Collections.Generic;
using UnityEngine.Package.Runtime.Scripts.BaseServices.SceneService.Service;
using Zenject;

namespace UnityEngine.Package.Runtime.Scripts.Utils.State
{
    public class SceneComponentResolver : MonoBehaviour
    {
        [SerializeField] private List<SceneComponentPreset> sceneComponentList;
        [Inject]
        private readonly ILevelService levelService;
        private void Start()
        {
            ValidateComponents(levelService.CurrentScene);
        }

        private void ValidateComponents(SceneType targetLevel)
        {
            sceneComponentList.ForEach(x=>x.ResolveState(targetLevel));
        }
    }

    [Serializable]
    public class SceneComponentPreset
    {
        [SerializeField] private GameObject target;
        [SerializeField] private List<SceneType> blockerSceneList;

        public void ResolveState(SceneType currentScene)
        {
            SetActive(!blockerSceneList.Contains(currentScene));
        }

        private void SetActive(bool state) => target.SetActive(state);
    }
   
}
