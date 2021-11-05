using System;

namespace UnityEngine.MyPackage.Runtime.Scripts.BaseServices.EventEntity
{
    public class CleverEvent
    {
        private bool isInvoked;

        private event Action Actions;

        public void AddListener(Action listenerAction)
        {
            Actions += listenerAction;
            if (!isInvoked || listenerAction == null)
                return;
            listenerAction();
        }

        public void RemoveListener(Action listenerAction) => Actions -= listenerAction;

        public void Invoke()
        {
            if (Actions == null)
                return;
        
            isInvoked = true;
            Actions.Invoke();
        }

        public void Reset()
        {
            Actions = null;
        }
    }
}

