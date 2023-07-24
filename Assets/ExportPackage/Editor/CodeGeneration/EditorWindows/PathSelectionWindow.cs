using CodeFramework.Editor.EditorWindows;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace CodeFramework.Editor
{
    public interface IPathSelectionWindow : IEntityProvider
    {
        string Path { get; }
    }
    public class PathSelectionWindow : CustomEditorWindow<string>, IPathSelectionWindow
    {
        private readonly string name;
        
        private Label pathLabelText;

        public string Value => name;
        public string Path => Result1;

        public PathSelectionWindow(string name)
        {
            this.name = name;
        }
        private void CreateGUI()
        {
            VisualElement root = rootVisualElement;
            root.Add(CreateLabel($"Path folder for {name}"));
            pathLabelText = CreateLabel("....");
            root.Add(pathLabelText);
            // Create button
            root.Add(CreateButton( $"Select path of {name}", action:OnClicked));
            root.Add(CreateButton( $"Save path", action:OnSave));
        }

        private void OnSave()
        {
            // var isValid = Uri.IsWellFormedUriString(Result, UriKind.RelativeOrAbsolute); check why not worked
            if (string.IsNullOrEmpty(Result1)) // validate for path pattern here
            {
                Debug.LogError("Path is null or empty");
                return;
            }
            
            InvokeClosedEvent();
        }

        private void OnClicked()
        {
            var path = EditorUtility.OpenFolderPanel("Select Root Folder", Application.dataPath, "Scripts");
            pathLabelText.text = path;
            Result1 = path;
        }
    }
}