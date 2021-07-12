using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace UnityEngine.Package.Runtime.Scripts.Utils.Ui
{
    public static class UiExtentionToolManager 
    {
        public static void InitDropDown(this Dropdown dropdown, List<string> option, Action<int> callBack = null, bool invokeOnAwake = false)
        {
            dropdown.ClearOptions();
            dropdown.onValueChanged.RemoveAllListeners();
            dropdown.AddOptions(option);
            
            if(callBack == null) return;
            
            dropdown.onValueChanged.AddListener(callBack.Invoke);

            if (invokeOnAwake)
            {
                callBack?.Invoke(0);
            }
        }
    }
}
