using System;

namespace CodeFramework.Editor
{
    public class ViewTemplate:CodeGeneratingTemplate
    {
        private const string Template = @"using CodeFramework.Runtime.Controllers.View;

namespace {0}.Runtime.Views
{{
    public class {2}View : View<I{2}ViewController>
    {{

        
    }}
}}";
        public override string EntityType => "View";
        
        public override string GetTemplate(string name)
        {
            return String.Format(Template,
                ProjectSettings.ProjectName,
                EntityType,
                name);
        }
    }
}