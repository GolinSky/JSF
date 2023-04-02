using RestSharp;

namespace CodeFramework.RetrogitRestPackage.Attributes.Methods
{
    [RestMethod(Method.GET)]
    public class GetAttribute : ValueAttribute
    {
        public GetAttribute(string path)
        {
            this.Value = path;
        }
    }
}