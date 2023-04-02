using RestSharp;

namespace CodeFramework.RetrogitRestPackage.Attributes.Methods
{
    [RestMethod(Method.PUT)]
    public class PutAttribute : ValueAttribute
    {
        public PutAttribute(string path)
        {
            this.Value = path;
        }
    }
}