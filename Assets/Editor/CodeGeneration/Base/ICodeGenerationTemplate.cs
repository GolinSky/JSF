namespace CodeFramework.Editor
{
    public interface ICodeGenerationTemplate
    {
        string EntityType { get; }
        string GetTemplate(string name);
    }
}