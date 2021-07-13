using EventHandlerUtils;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.ModelService.Service;

namespace UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Service
{
    public abstract class BaseLevelService<T> : IBaseLevelService<T>
    {
        private T PreviousScene;

        public Handler<T> SceneLoadedHandler { get; } = new Handler<T>();
        public Handler<T> SceneUnloadedHandler { get; } = new Handler<T>();
        public T CurrentScene { get; private set; }
        protected abstract T EntryScene { get; }

        public BaseLevelService(IModelService modelService)
        {

        }

        public abstract AsyncOperation LoadSceneAsync();
     

        public void LoadScene(T sceneType)
        {
            PreviousScene = CurrentScene;
            CurrentScene = sceneType;
            SceneUnloadedHandler?.Invoke(PreviousScene);
            SceneLoadedHandler?.Invoke(sceneType);
            InternalLoadScene();
        }

        protected abstract void InternalLoadScene();
    }

    public interface IBaseLevelService<T>:ILoadAsync
    {
        void LoadScene(T sceneType);
        T CurrentScene { get; }
    }

    public interface ILoadAsync
    {
        AsyncOperation LoadSceneAsync();
    }

    public enum SceneType
    {
        Unset = -1,
        Loading = 0,
        Example = 9999,
    }

}