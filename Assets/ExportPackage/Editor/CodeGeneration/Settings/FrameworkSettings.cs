using CodeFramework.Editor;
using ExportPackage.Editor.CodeGeneration.EditorWindows;
using UnityEditor;

namespace ExportPackage.Editor.CodeGeneration.Settings
{
    public class FrameworkSettings
    {
        [MenuItem("JSF/Settings/Change Folders Path/Root", false, 1)]
        private static void SelectRootFolder()
        {
            ChangeFolderPath(FrameworkPath.Root);
        }
        
        [MenuItem("JSF/Settings/Change Folders Path/Controller", false, 1)]
        private static void SelectControllerFolder()
        {
            ChangeFolderPath(FrameworkPath.Controller);
        }
        
        [MenuItem("JSF/Settings/Change Folders Path/View", false, 1)]
        private static void SelectViewFolder()
        {
            ChangeFolderPath(FrameworkPath.View);
        }

        private static void ChangeFolderPath(FrameworkPath path)
        {
            new PathWindowHandler(new PathSelectionWindow(path.ToString()), path);
        }
    }
}