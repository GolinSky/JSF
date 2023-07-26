using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeFramework.Runtime.Controllers.BaseServices.EntryPointServices
{
    public static class EntryPoint 
    {
        [RuntimeInitializeOnLoadMethod]
        private static void OnRuntimeInitializeOnLoadMethod()
        {
            // Debug.Log("Execute default game pipeline");
            // GameContext gameContext = Configuration.GetDefaultRepository().Load<GameContext>(Configuration.GameContextName);
            // if (gameContext == null)
            // {
            //     Debug.LogError($"Skipped default game pipeline. GameContext is not find at path {Configuration.GameContextName}");
            //     return;
            // }
            //
            // IEntryPoint service = gameContext.GameService;
            // service.StartGame();

            var types = FindAllDerivedTypes<IEntryPoint>();

            Type searchedType = null;
            foreach (var type in types)
            {
                var attribute = Attribute.GetCustomAttribute(type, typeof(EntryPointAttribute));
                if (attribute != null)
                {
                    searchedType = type;
                    break;
                }
            }

            if (searchedType != null)
            {
                IEntryPoint entryPoint = (IEntryPoint)Activator.CreateInstance(searchedType);
                entryPoint.StartGame();
            }
        }

        public static IEnumerable<Type> FindAllDerivedTypes<T>()
        {
            var type = typeof(T);
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
        }
    }
}
