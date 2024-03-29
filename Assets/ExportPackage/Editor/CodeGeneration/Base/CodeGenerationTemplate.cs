using CodeFramework.Runtime.Controllers.ConfigurationService;
using ExportPackage.Editor;
using UnityEngine;

namespace CodeFramework.Editor
{
    public abstract class CodeGeneratingTemplate: ICodeGeneratingTemplate
    {
        public abstract string EntityType { get; }
        protected ProjectSettings ProjectSettings { get; }
        
        public string Value => EntityType;

        protected CodeGeneratingTemplate( )
        {
            ProjectSettings = Resources.Load<ProjectSettings>(Configuration.ProjectSettingsName);

        }
        
        public abstract string GetTemplate(string name);
    }
}