using UnityEditor;

namespace ExportPackage.Editor
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