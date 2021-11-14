using System;
using UnityEngine.UI;

namespace UnityEngine.Examples.RestTemplateEntity.View
{
    public class RestUidView : MyPackage.Runtime.Scripts.Patterns.MVC.View.View
    {
        [SerializeField] private Button button;

        public void AddListener(Action action) => button.onClick.AddListener(action.Invoke);
        public void RemoveListener(Action action) => button.onClick.RemoveListener(action.Invoke);
    }
}
