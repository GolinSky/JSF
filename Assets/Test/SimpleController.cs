using System;
using System.Globalization;
using CodeFramework.Runtime.Controller;


namespace CodeFramework.Test
{
    public interface ISimpleViewController : IViewController
    {
        string SimpleText { get; }
    }


    public interface ISimpleController : IController, ISimpleViewController {}


    public class SimpleController : Controller, ISimpleController
    {
        public string SimpleText { get; }

        public SimpleController()
        {
            SimpleText = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
        }
    }
}