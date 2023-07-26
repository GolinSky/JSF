namespace CodeFramework.Editor
{
    public static class EditorConfiguration //can use smth which data can be changed  - create scriptable object and set default settings
    {
        public const string ProjectSettingsName = nameof(ProjectSettings);


        public static IRepository<string> GetDefaultRepository()
        {
            return new ResourceRepository();
        }
    }
}
