namespace FrameworkCore.Patterns.Observer
{
    public interface ICustomObserver<T>
    {
        void UpdateState(T state);
    }
}