using UnityEngine;
using UnityEditor;

namespace CodeFramework.Editor
{
    public static class FileValidationService
    {
        private const string ResourcesFolderName = "Resources";
        private static readonly string ResourcesPath = $"Assets/{ResourcesFolderName}";
        
        [MenuItem("JSF/Validate Project", false, 1)]
        public static void Validate()
        {
            var projectSettings = EditorConfiguration.GetDefaultRepository().Load<ProjectSettings>(EditorConfiguration.ProjectSettingsName);
            if (projectSettings == null)
            {
                Debug.Log("Missing ProjectSettings asset. Create new one");
                projectSettings = ScriptableObject.CreateInstance<ProjectSettings>();
                if (!AssetDatabase.IsValidFolder(ResourcesPath))
                {
                    AssetDatabase.CreateFolder("Assets", ResourcesFolderName);
                }

                AssetDatabase.CreateAsset(projectSettings, $"{ResourcesPath}/{EditorConfiguration.ProjectSettingsName}.asset");
                //AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
    }

}