using System;
using RestSharp;

namespace CodeFramework.RetrogitRestPackage.Attributes.Methods
{
    public class RestMethodAttribute : Attribute
    {
        public Method Method { get; private set; }

        public RestMethodAttribute(Method method)
        {
            this.Method = method;
        }
    }
}