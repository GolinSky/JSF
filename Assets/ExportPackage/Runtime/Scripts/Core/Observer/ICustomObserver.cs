namespace CodeFramework.Runtime.Controllers.Observer
{
    public interface ICustomObserver<T>
    {
        void UpdateState(T state);
    }
}