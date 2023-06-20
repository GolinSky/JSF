namespace CodeFramework
{
    public interface IEntity
    {
        string Id { get; }

        void Init(IHub<IService> serviceHub);
        
        void Release();
    }
}