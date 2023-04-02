using System;
using CodeFramework.Runtime.Controller;
using Zenject;

namespace CodeFramework.Runtime.View
{
    public abstract class ViewBinding<TIViewController> : CustomMonoBehaviour
    where TIViewController : IViewController
    {
        [Inject]
        protected TIViewController ViewController { get; private set; }
        


    }
}