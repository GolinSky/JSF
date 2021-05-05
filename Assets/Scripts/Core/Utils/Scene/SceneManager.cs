using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Utils.Scene
{
    public static class SceneTools
    {
        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public static AsyncOperation LoadSceneAsync(string sceneName)
        {
            return SceneManager.LoadSceneAsync(sceneName);
        }

        public static UnityEngine.SceneManagement.Scene ActiveScene => SceneManager.GetActiveScene();
    }
}