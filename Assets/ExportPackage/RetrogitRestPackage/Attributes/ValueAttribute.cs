using System;

namespace CodeFramework.RetrogitRestPackage.Attributes
{
    public class ValueAttribute : Attribute
    {
        public string Value { get; protected set; }
    }
}