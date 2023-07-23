using CodeFramework.Editor;
using ExportPackage.Editor.CodeGeneration.EditorWindows;
using UnityEditor;

namespace ExportPackage.Editor.CodeGeneration.Settings
{
    public class FrameworkSettings
    {
        [MenuItem("JSF/Settings/Change Root Folder", false, 1)]
        private static void SelectRootFolder()
        {
            new PathWindowHandler(new PathSelectionWindow("Root"), FrameworkPath.Root);
        }
    }
}