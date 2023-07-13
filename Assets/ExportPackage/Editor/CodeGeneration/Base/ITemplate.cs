namespace CodeFramework.Editor
{
    public interface ICodeGenerationTemplate<in TCodeGenerationParams>
        where TCodeGenerationParams : ICodeGenerationParams
    {
        string GetTemplate(TCodeGenerationParams generationParams);
    }
}