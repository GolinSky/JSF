using UnityEngine;

namespace CodeFramework.Runtime.Extensions.MonoInstaller
{
    public static class MonoInstallerExtension 
    {
        public static void FindViewDependency<T>(this Zenject.MonoInstaller monoInstaller, ref T t) where T : Object
        {
            if (t == null)
            {
                var result = Object.FindObjectOfType<T>();
                if (result)
                {
                    t =  result;
                }
            }
        }
    }
}
