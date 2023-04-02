using System.Collections.Generic;
using UnityEngine;

namespace CodeFramework.Runtime.Observer
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

        public virtual void NotifyObservers(T state)
        {
            currentState = state;
            customObserversList.ForEach(x=>x.UpdateState(state));
        }

    }
}
