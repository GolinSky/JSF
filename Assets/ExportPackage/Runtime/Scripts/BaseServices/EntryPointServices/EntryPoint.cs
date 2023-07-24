using CodeFramework.Runtime.Controllers.ConfigurationService;
using UnityEngine;

namespace CodeFramework.Runtime.Controllers.BaseServices.EntryPointServices
{
    public static class EntryPoint 
    {
        [RuntimeInitializeOnLoadMethod]
        private static void OnRuntimeInitializeOnLoadMethod()
        {
            Debug.Log("Execute default game pipeline");
            GameContext gameContext = Configuration.GetDefaultRepository().Load<GameContext>(Configuration.GameContextName);
            if (gameContext == null)
            {
                Debug.LogError($"Skipped default game pipeline. GameContext is not find at path {Configuration.GameContextName}");
                return;
            }

            IEntryPoint service = gameContext.GameService;
            service.Start();
        }
    }
}
