using System;
using CodeFramework.Editor.EditorWindows;

namespace Editor.EditorWindows
{
    public static class WindowFactory
    {
        public static TCustomEditorWindow CreateWindow<TCustomEditorWindow>(string name) where TCustomEditorWindow:CustomEditorWindow<string>
        {
            return (TCustomEditorWindow)Activator.CreateInstance(typeof(TCustomEditorWindow), name);
        }
    }
}