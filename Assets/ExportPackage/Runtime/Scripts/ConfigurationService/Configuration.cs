using CodeFramework.Runtime.Controllers.BaseServices;
using ExportPackage.Editor;

namespace CodeFramework.Runtime.Controllers.ConfigurationService
{
    public class Configuration //can use smth which data can be changed  - create scriptable object and set default settings
    {
        public const string GameContextPath = nameof(GameContext);
        public const string ProjectSettingsName = nameof(ProjectSettings);
    }
}
