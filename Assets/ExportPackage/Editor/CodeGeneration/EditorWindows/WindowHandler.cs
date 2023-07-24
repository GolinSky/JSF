using CodeFramework.Editor.EditorWindows;
using CodeFramework.Runtime.Controllers.ConfigurationService;
using Editor.EditorWindows;
using ExportPackage.Editor;
using ExportPackage.Runtime.Scripts.Other;
using UnityEngine;

namespace CodeFramework.Editor
{
    public interface IEntityProvider:IProvider<string>
    {
        
    }
    public abstract class WindowHandler<TEntityProvider, TCustomEditorWindow> 
        where TEntityProvider:IEntityProvider
        where TCustomEditorWindow:CustomEditorWindow<string>
    {
        protected TCustomEditorWindow window;
        
        public TEntityProvider Provider { get; }
        protected string EntityType { get; }
        protected ProjectSettings ProjectSettings { get; }


        protected WindowHandler(TEntityProvider provider)
        {
            ProjectSettings = Configuration.GetDefaultRepository().Load<ProjectSettings>(Configuration.ProjectSettingsName);

            Provider = provider;
            EntityType = Provider.Value;
            window = WindowFactory.CreateWindow<TCustomEditorWindow>(EntityType);
            window.OnClosed += OnClosed;
            window.Show();
        }


        private void OnClosed()
        {
            OnClosedInternal();
            window.OnClosed -= OnClosed;
        }

        protected abstract void OnClosedInternal();
    }
}