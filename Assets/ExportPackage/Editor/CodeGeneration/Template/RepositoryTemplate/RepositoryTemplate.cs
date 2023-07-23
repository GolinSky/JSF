using System;

namespace CodeFramework.Editor
{
    public class RepositoryTemplate:CodeGeneratingTemplate
    {
        private const string Template =  @"using UnityEngine;
using CodeFramework;

namespace {0}.Runtime.{1}
{{
    public class {2}Repository: IRepository<string>
    {{
        public TResource Load<TResource>(string key) where TResource : Object
        {{
            
        }}
    }}
}}";

        public override string EntityType => "Repository";
        public override string GetTemplate(string name)
        {
            return String.Format(Template,
                ProjectSettings.ProjectName,
                EntityType,
                name);
        }
    }
}