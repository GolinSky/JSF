using System;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Utils.Ui
{
    [Serializable]
    public class ButtonUtils<T> where T : struct
    {
        [SerializeField] protected T id;
        [SerializeField] protected Button button;

        public T Id => id;
        public void AddListener(Action action)
        {
            button.onClick.AddListener(action.Invoke);
        }

        public void RemoveListeners()
        {
            button.onClick.RemoveAllListeners();
        }
    }
}