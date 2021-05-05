using System;
using System.Collections.Generic;
using Core.BaseServices.SceneService.Service;
using UnityEngine;

namespace Core.Utils.State
{
    public class SceneComponentResolver : MonoBehaviour
    {
        [SerializeField] private List<SceneComponentPreset> sceneComponentList;

        private void Start()
        {
            ValidateComponents(BaseServices.SceneService.Service.SceneService.TargetLevel);
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
