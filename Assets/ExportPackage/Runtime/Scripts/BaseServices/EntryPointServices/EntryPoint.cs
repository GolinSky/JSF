using CodeFramework.Runtime.ConfigurationService;
using UnityEngine;

namespace CodeFramework.Runtime.BaseServices.EntryPointServices
{
    public static class EntryPoint 
    {
        [RuntimeInitializeOnLoadMethod]
        private static void OnRuntimeInitializeOnLoadMethod()
        {
            Debug.Log("RuntimeInitializeOnLoadMethod");

            GameContext gameContext = Resources.Load<GameContext>(Configuration.GameContextPath);
            if (gameContext == null)
            {
                Debug.LogError($"Skipped default game pipeline. GameContext is not find at path {Configuration.GameContextPath}");
                return;
            }

            IEntryPoint service = gameContext.GameService;
            service.Start();
        }
    }
}
