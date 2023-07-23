namespace CodeFramework.Editor
{
    public interface ICodeGeneratingTemplate:IEntityProvider
    {
        string GetTemplate(string name);
    }
}