﻿using UnityEngine;

namespace FrameworkCore.BaseServices.EntryPointServices
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
