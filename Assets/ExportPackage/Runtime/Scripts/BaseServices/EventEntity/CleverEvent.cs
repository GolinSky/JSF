using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFramework.Runtime.Controllers.BaseServices.EventEntity
{
    public class CleverEvent<T>
    {
        private T subject;
        private  List<Action<T>> Actions = new List<Action<T>>();

        public void AddListener(Action<T> listenerAction, bool waitForNextInvocation = false)
        {
            if (listenerAction == null)
                return;
            
            Actions.Add(listenerAction);
            if (subject != null && !waitForNextInvocation)
            {
                listenerAction.Invoke(subject);
            }
        }

        public void RemoveListener(Action<T> listenerAction) => Actions.Remove(listenerAction);

        public void Invoke(T value)
        {
            if (value == null) return;
         
            subject = value;
            
            if (Actions == null)
                return;
        
            Actions.Where(x=>x!=null).ToList().ForEach(x=>x.Invoke(subject));
        }

        public void Reset()
        {
            Actions = null;
        }
    }
}

