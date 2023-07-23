using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace CodeFramework.Editor.EditorWindows
{
    public abstract class CustomEditorWindow: EditorWindow
    { 
        public event Action OnClosed;

        protected void InvokeClosedEvent()
        {
      
            OnClosed?.Invoke();
            Close();
        }


        protected Button CreateButton(string text, string name = null, Action action = null)
        {
            var button = new Button
            {
                name = name??$"button:{Time.time}",
                text = text
            };
            if (action != null)
            {
                button.clicked += action;
            }

            return button;
        }

        protected TextField CreateTextField(string text, string name = null)
        {
            var textField = new TextField
            {
                name = name??$"button:{Time.time}",
                tooltip = $"Enter  name..."
            };
            return textField;
        }

        protected Label CreateLabel(string text, string name = null )
        {
             var label = new Label(text);
             if (name != null)
             {
                 label.name = name;
             }

             return label;
        }

    }
    
    public abstract class CustomEditorWindow<TResult>: CustomEditorWindow
    {
        public virtual TResult Result1 { get; protected set; }
    }
}