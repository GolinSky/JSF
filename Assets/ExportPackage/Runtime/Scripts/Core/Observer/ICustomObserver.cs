namespace CodeFramework.Runtime.Observer
{
    public interface ICustomObserver<T>
    {
        void UpdateState(T state);
    }
}