using CodeFramework.Editor;
using UnityEngine;

namespace ExportPackage.Editor.CodeGeneration.EditorWindows
{
    public class PathWindowHandler:WindowHandler<IPathSelectionWindow, PathSelectionWindow>
    {
        private readonly FrameworkPath frameworkPath;

        public PathWindowHandler(IPathSelectionWindow provider, FrameworkPath frameworkPath) : base(provider)
        {
            this.frameworkPath = frameworkPath;
        }

        protected override void OnClosedInternal()
        {
           
            ProjectSettings.UpdatePath(frameworkPath,  window.Path);
        }
    }
}