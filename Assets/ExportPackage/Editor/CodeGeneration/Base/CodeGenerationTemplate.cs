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
            ProjectSettings = Resources.Load<ProjectSettings>(EditorConfiguration.ProjectSettingsName);//todo:Create editorConfiguration

        }
        
        public abstract string GetTemplate(string name);
    }
}