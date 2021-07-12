namespace UnityEngine.Package.Runtime.Scripts.Patterns.Observer
{
    public interface ICustomObserver<T>
    {
        void UpdateState(T state);
    }
}