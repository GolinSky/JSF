using CodeFramework.Editor;

namespace Editor.EditorWindows
{
    public class WindowFactory
    {
        public static CreateTemplateWindow CreateTemplateWindow(string entityType)
        {
            return new CreateTemplateWindow(entityType);
        }
    }
}