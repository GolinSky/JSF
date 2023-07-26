using System;
using System.Runtime.Serialization;
using CodeFramework.Runtime.Controllers.BaseServices;
using UnityEngine;

namespace CodeFramework.Editor
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
        [field: Header("Root Path")]
        [field: SerializeField] public string RootPath { get; private set; }
        [field: SerializeField] public string ViewPath { get; private set; }
        [field: SerializeField] public string ControllerPath { get; private set; }

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