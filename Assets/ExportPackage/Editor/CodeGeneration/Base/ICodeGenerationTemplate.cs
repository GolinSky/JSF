namespace CodeFramework.Editor
{
    public interface ICodeGeneratingTemplate
    {
        string EntityType { get; }
        string GetTemplate(string name);
    }
}