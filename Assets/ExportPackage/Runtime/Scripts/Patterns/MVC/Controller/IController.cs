namespace UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Controller
{
    public interface IController
    {
        void AddListeners();
        void RemoveListeners();
        void Execute();
    }
}