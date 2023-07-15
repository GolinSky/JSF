using System;
using CodeFramework.Runtime.Controllers.ConfigurationService;
using Editor.EditorWindows;
using ExportPackage.Editor;
using UnityEditor;
using UnityEngine;

namespace CodeFramework.Editor
{

    public class TemplateFactory
    {
        private static CreateTemplateWindow window;

        [MenuItem("Assets/Create/JSF/Entity/Controller", false, 1)]
        private static void CreateController()
        {
            var windowHandler = new WindowHandler(new ControllerTemplate());
        }


    
    }
}