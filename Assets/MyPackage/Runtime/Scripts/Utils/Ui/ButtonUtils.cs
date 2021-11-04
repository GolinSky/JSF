﻿using System;
using UnityEngine.UI;

namespace UnityEngine.MyPackage.Runtime.Scripts.Utils.Ui
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