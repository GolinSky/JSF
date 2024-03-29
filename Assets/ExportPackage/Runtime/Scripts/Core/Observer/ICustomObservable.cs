﻿namespace CodeFramework.Runtime.Controllers.Observer
{
    public interface ICustomObservable<T>
    {
        void AddObserver(ICustomObserver<T> o);
        void RemoveObserver(ICustomObserver<T> o);
        //void NotifyObservers(T state);
        
        T CurrentState { get; }
    }
}
