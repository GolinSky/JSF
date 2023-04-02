using UnityEngine;

namespace CodeFramework.Runtime.BaseServices.EntryPointServices
{
    public class EntryPoint 
    {
        [RuntimeInitializeOnLoadMethod]
        private static void InitializePrimarySystem()
        {
            Debug.Log("InitializePrimarySystem");
            //
        }
        
    }
}
