namespace UnityEngine.Package.Runtime.Scripts.Extensions.MonoInstaller
{
    public static class MonoInstallerExtension 
    {
        public static void FindViewDependency<T>(this Zenject.MonoInstaller monoInstaller, ref T t) where  T:Patterns.MVC.View.View
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
