using CodeFramework.Editor.EditorWindows;
using Editor.EditorWindows;
using ExportPackage.Runtime.Scripts.Other;

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
            ProjectSettings = EditorConfiguration.GetDefaultRepository().Load<ProjectSettings>(EditorConfiguration.ProjectSettingsName);

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