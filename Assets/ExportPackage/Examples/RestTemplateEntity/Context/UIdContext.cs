namespace CodeFramework.Examples.RestTemplateEntity.Context
{
    public struct UIdContext
    {
        public string UId { get; private set; }

        public UIdContext(string uIdContext)
        {
            UId = uIdContext;
        }
    }
}