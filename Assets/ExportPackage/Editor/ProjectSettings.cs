using System;
using CodeFramework.RetrogitRestPackage.Attributes.Methods;
using CodeFramework.Runtime.Controllers;
using UnityEditor;
using UnityEngine;

namespace ExportPackage.Editor
{
    public enum FrameworkPath
    {
        Root = 0,
        Controller = 1,
        View = 2,
    }
    
    [Serializable]
    [CreateAssetMenu(fileName = "ProjectSettings", menuName = "JSF/Data/ProjectSettings", order = 1)]
    public sealed class ProjectSettings:ScriptableObject
    {
        [field:SerializeField] public string ProjectName { get; private set; }
        
        [Head("Folder Path:")]
        [field: SerializeField] protected string RootPath { get; private set; }
        [field: SerializeField] protected string ViewPath { get; private set; }
        [field: SerializeField] protected string ControllerPath { get; private set; }

        public void UpdatePath(FrameworkPath frameworkPath, string path)
        {
            switch (frameworkPath)
            {
                case FrameworkPath.Root:
                    RootPath = path;
                    break;
                case FrameworkPath.Controller:
                    ControllerPath = path;
                    break;
                case FrameworkPath.View:
                    ViewPath = path;
                    break;
            }
        }
    }
}