using UnityEditor;

namespace CodeFramework.Editor
{
    public class TemplateWindowHandler:WindowHandler<ICodeGeneratingTemplate, CreateTemplateWindow>
    {
        public TemplateWindowHandler(ICodeGeneratingTemplate generationTemplate) : base(generationTemplate)
        {
        }

        protected override void OnClosedInternal()
        {
            var result = window.Result1;
            var name = $"{result}{EntityType}";
            ProjectWindowUtil.CreateAssetWithContent($"{name}.cs", Provider.GetTemplate(result));
        }
    }
}