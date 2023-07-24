using ExportPackage.Editor;
using UnityEditor;

namespace CodeFramework.Editor
{
    [InitializeOnLoad]
    public sealed class EditorStartup
    {
        private EditorStartup()
        {
            if (!EditorApplication.isPlayingOrWillChangePlaymode)
            {
                FileValidationService.Validate();
            }
        }
    }
}