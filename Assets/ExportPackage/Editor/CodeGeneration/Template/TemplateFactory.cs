using UnityEditor;

namespace CodeFramework.Editor
{

    public class TemplateFactory
    {
        [MenuItem("Assets/Create/JSF/Entity/Controller", false, 1)]
        private static void CreateController()
        {
            Construct(new ControllerTemplate());
        }

        [MenuItem("Assets/Create/JSF/Entity/View", false, 1)]
        private static void CreateView()
        {
            Construct(new ViewTemplate());
        }
        
        [MenuItem("Assets/Create/JSF/Entity/Repository", false, 1)]
        private static void CreateRepository()
        {
            Construct(new RepositoryTemplate());
        }
        

        private static void Construct(CodeGeneratingTemplate template)
        {
            new TemplateWindowHandler(template);
        }
    }
}