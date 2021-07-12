namespace Runtime.Scripts.Patterns.Observer
{
    public interface ICustomObserver<T>
    {
        void UpdateState(T state);
    }
}