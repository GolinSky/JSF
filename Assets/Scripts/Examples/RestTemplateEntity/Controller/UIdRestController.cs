﻿using UnityEngine.Examples.RestTemplateEntity.HttpContext;
using UnityEngine.Examples.RestTemplateEntity.View;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Controller;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.Proxy;
using Zenject;

namespace UnityEngine.Examples.RestTemplateEntity.Controller
{
    public class UIdRestController : Controller<RestUidView>, IDelayHttpContext
    {
        [Inject] private readonly IProxy<IHttpContext> proxy;
        [Inject] private readonly IProxy<IDelayHttpContext> delayedProxy;
        public UIdRestController(RestUidView view) : base(view)
        {
        
        }
        
        public override void AddListeners()
        {
            base.AddListeners();
            View.AddListener(SendRequest);
        }

        public override void RemoveListeners()
        {
            base.RemoveListeners();
            View.RemoveListener(SendRequest);
        }

        private void SendRequest()
        {
            proxy.Request(null);
            delayedProxy.Request(this);
        }

        public int Duration => 3;
    }
}
