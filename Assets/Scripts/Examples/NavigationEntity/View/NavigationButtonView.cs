using System;
using UnityEngine.MyPackage.Runtime.Scripts.BaseServices.SceneService.Service;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Factory;
using UnityEngine.UI;

namespace UnityEngine.Examples.NavigationEntity.View
{
    public class NavigationButtonView : MonoBehaviour, IButtonView<SceneType>
    {
        [SerializeField] private Button button;
        [SerializeField] private Text text;
        private SceneType context;
        
        public void SetContext(SceneType context)
        {
            text.text = context.ToString();
            this.context = context;
        }

        public void AddListener(Action<SceneType> action)
        {
            button.onClick.AddListener(() => action.Invoke(context));
        }

        public void RemoveListener(Action<SceneType> action)
        {
            button.onClick.RemoveListener(() => action.Invoke(context));
        }
    }
}

public interface IButtonView<T>:IEntity where T:struct
{
    void SetContext(T context);
    void AddListener(Action<T> action);
    void RemoveListener(Action<T> action);
}
