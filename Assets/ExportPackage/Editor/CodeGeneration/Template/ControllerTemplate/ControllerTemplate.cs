using System;

namespace CodeFramework.Editor
{
    public class ControllerTemplate : CodeGeneratingTemplate
    {
        private const string Template = @"using CodeFramework.Runtime.Controllers;
using CodeFramework.Runtime.Controllers.BaseServices;

namespace {0}.Runtime.Controllers
{{
    public interface I{2}ViewController:IViewController
    {{
        
    }}

    public class {2}Controller: Controller, I{2}ViewController
    {{
        public {2}Controller(IGameService gameService) : base(gameService) {{}}
    }}
}}";

        public override string EntityType => "Controller";
        


        public override string GetTemplate(string name)
       {
           return String.Format(Template,
               ProjectSettings.ProjectName,
               EntityType,
               name);
       }
    }
}