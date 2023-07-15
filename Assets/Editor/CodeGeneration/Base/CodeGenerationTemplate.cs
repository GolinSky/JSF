using CodeFramework.Runtime.Controllers.ConfigurationService;
using ExportPackage.Editor;
using UnityEngine;

namespace CodeFramework.Editor
{
    public abstract class CodeGenerationTemplate: ICodeGenerationTemplate
    {
        public abstract string EntityType { get; }
        protected ProjectSettings ProjectSettings { get; }

        protected CodeGenerationTemplate( )
        {
            ProjectSettings = Resources.Load<ProjectSettings>(Configuration.ProjectSettingsPath);

        }
        
        public abstract string GetTemplate(string name);
    }
}