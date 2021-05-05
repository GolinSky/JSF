namespace Core.Patterns.Observer
{
    public interface ICustomObserver<T>
    {
        void UpdateState(T state);
    }
}