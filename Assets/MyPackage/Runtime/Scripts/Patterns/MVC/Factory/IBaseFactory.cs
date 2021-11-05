namespace UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Factory
{
    
    //todo:refactor in such way like service layer was refactored
    public interface IMonoBehaviourFactory<T, ID,V> where T:IEntity where V:Transform
    {
        T CreateEntity(ID id, V parent); 
    }
    
    public interface IBaseFactory<T, ID> where T:IEntity
    {
        T CreateEntity(ID id);
    }

    public interface IEntity
    {
        
    }
}
