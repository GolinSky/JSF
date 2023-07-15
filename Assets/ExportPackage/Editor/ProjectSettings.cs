using System;
using UnityEngine;

namespace ExportPackage.Editor
{
    [Serializable]
    [CreateAssetMenu(fileName = "ProjectSettings", menuName = "JSF/Data/ProjectSettings", order = 1)]
    public sealed class ProjectSettings:ScriptableObject
    {
        [field:SerializeField] public string ProjectName { get; private set; }
        
    }
}