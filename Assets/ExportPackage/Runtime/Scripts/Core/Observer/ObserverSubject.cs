using System.Collections.Generic;
using UnityEngine;

namespace CodeFramework.Runtime.Controllers.Observer
{
    public class ObserverSubject<T> : MonoBehaviour, ICustomObservable<T>
    {
        private List<ICustomObserver<T>> customObserversList = new List<ICustomObserver<T>>();
        public static ObserverSubject<T> ObserverInstance { get; private set; }

        protected T currentState;
        public T CurrentState => currentState;

        protected virtual void Awake()
        {
            ObserverInstance = this;
        }

        public void AddObserver(ICustomObserver<T> o)
        {
            customObserversList.Add(o);
            o.UpdateState(currentState);
        }

        public void RemoveObserver(ICustomObserver<T> o)
        {
            customObserversList.Remove(o);
        }

        protected virtual void NotifyObservers(T state)
        {
            currentState = state;
            for (var i = 0; i < customObserversList.Count; i++)
            {
                customObserversList[i].UpdateState(state);
            }
        }

    }
}
