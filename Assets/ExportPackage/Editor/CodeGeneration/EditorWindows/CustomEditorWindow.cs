using System;
using UnityEditor;

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

    }
    
    public abstract class CustomEditorWindow<TResult>: CustomEditorWindow
    {
        public virtual TResult Result { get; protected set; }
    }
}