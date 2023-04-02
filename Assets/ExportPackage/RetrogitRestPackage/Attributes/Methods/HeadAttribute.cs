using RestSharp;

namespace CodeFramework.RetrogitRestPackage.Attributes.Methods
{
    [RestMethod(Method.HEAD)]
    public class HeadAttribute : ValueAttribute
    {
        public HeadAttribute(string path)
        {
            this.Value = path;
        }
    }
}