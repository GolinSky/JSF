namespace UnityEngine.MyPackage.Runtime.Scripts.BaseServices.EntryPointServices
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
