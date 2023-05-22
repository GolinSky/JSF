using CodeFramework;

namespace ExportPackage.Runtime.Scripts.Core
{
    public interface IHub<TEntity> where TEntity:IEntity
    {
        TEntity Get(string id);
        void Remove(TEntity entity);

    }
}