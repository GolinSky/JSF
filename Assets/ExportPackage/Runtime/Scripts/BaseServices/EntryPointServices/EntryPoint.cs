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
            //todo list
            //1. make IEntryPoint Factory -> move all reflection and type&attributes searching to factory
            //2. add logs + add validation for checking entry point attribute
            
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

        private static IEnumerable<Type> FindAllDerivedTypes<T>()
        {
            var type = typeof(T);
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
        }
    }
}
