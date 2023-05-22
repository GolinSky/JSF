using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeFramework.Runtime.BaseServices
{
    public abstract class SceneModel<TSceneKey>: ScriptableObject
    {
        [SerializeField] private DictionaryWrapper<TSceneKey, SceneReference> sceneDictionaryWrapper;

        protected Dictionary<TSceneKey, SceneReference> SceneDictionary => sceneDictionaryWrapper.Dictionary;

        public SceneReference GetSceneReference(TSceneKey key)
        {
            if (SceneDictionary.TryGetValue(key, out var reference))
            {
                return reference;
            }

            return null;//todo: add throw exception
        }

        public TSceneKey GetKeyByScene(Scene scene)
        {
            foreach (var keyValuePair in SceneDictionary)
            {
                if (keyValuePair.Value.ScenePath.Equals(scene.path))
                {
                    return keyValuePair.Key;
                }
            }

            //todo: add throw exception
            return default;
        }
    }
}