namespace CodeFramework
{
    public interface IRepository<TResource, TKey>
    {
        TResource Load(TKey key);
    }
}