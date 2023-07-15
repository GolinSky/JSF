using CodeFramework.Runtime.Controllers.ConfigurationService;
using UnityEngine;
using UnityEditor;

namespace ExportPackage.Editor
{
    public static class FileValidationService
    {
        [MenuItem("JSF/Validate Project", false, 1)]

        public static void Validate()
        {
            var projectSettings = Resources.Load<ProjectSettings>(Configuration.ProjectSettingsPath);
            if (projectSettings == null)
            {
                Debug.Log("Missing ProjectSettings asset. Create new one");
                projectSettings = ScriptableObject.CreateInstance<ProjectSettings>();
                AssetDatabase.CreateAsset(projectSettings, $"Assets/Resources/{Configuration.ProjectSettingsPath}.asset");
                AssetDatabase.SaveAssets();
            }
        }
    }
}