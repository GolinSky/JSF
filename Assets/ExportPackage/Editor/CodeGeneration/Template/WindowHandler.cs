using CodeFramework.Runtime.Controllers.ConfigurationService;
using Editor.EditorWindows;
using ExportPackage.Editor;
using UnityEditor;
using UnityEngine;

namespace CodeFramework.Editor
{
    public class WindowHandler
    {
        private CreateTemplateWindow window;
        
        public ICodeGeneratingTemplate GenerationTemplate { get; }
        protected string EntityType { get; }
        protected ProjectSettings ProjectSettings { get;  }



        public WindowHandler(ICodeGeneratingTemplate generationTemplate)
        {
            ProjectSettings = Resources.Load<ProjectSettings>(Configuration.ProjectSettingsPath);

            GenerationTemplate = generationTemplate;
            EntityType = generationTemplate.EntityType;
            window = WindowFactory.CreateTemplateWindow(EntityType);
            window.OnClosed += OnClosed;
            window.Show();
        }


        private void OnClosed()
        {
            window.OnClosed -= OnClosed;
            var result = window.Result;
            var name = $"{result}{EntityType}";
            ProjectWindowUtil.CreateAssetWithContent($"{name}.cs", GenerationTemplate.GetTemplate(result));
        }
    }
}