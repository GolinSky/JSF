using RestSharp;

namespace CodeFramework.RetrogitRestPackage.Attributes.Methods
{
    [RestMethod(Method.DELETE)]
    public class DeleteAttribute : ValueAttribute
    {
        public DeleteAttribute(string path)
        {
            this.Value = path;
        }
    }
}