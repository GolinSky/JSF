using CodeFramework.Runtime.Controllers.ConfigurationService;
using UnityEngine;
using UnityEditor;

namespace ExportPackage.Editor
{
    public static class FileValidationService
    {
        private const string ResourcesFolderName = "Resources";
        private static readonly string ResourcesPath = $"Assets/{ResourcesFolderName}";
        
        [MenuItem("JSF/Validate Project", false, 1)]
        public static void Validate()
        {
            var projectSettings = Configuration.GetDefaultRepository().Load<ProjectSettings>(Configuration.ProjectSettingsName);
            if (projectSettings == null)
            {
                Debug.Log("Missing ProjectSettings asset. Create new one");
                projectSettings = ScriptableObject.CreateInstance<ProjectSettings>();
                if (!AssetDatabase.IsValidFolder(ResourcesPath))
                {
                    AssetDatabase.CreateFolder("Assets", ResourcesFolderName);
                }

                AssetDatabase.CreateAsset(projectSettings, $"{ResourcesPath}/{Configuration.ProjectSettingsName}.asset");
                //AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
    }

}