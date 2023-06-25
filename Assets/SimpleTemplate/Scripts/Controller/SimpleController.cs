﻿using System;
using System.Globalization;
using CodeFramework.Runtime;
using CodeFramework.Runtime.BaseServices;


namespace CodeFramework.Test
{
    public interface ISimpleViewController : IViewController
    {
        string SimpleText { get; }
        event Action<string> OnUpdate;
    }


    public interface ISimpleController : IController, ISimpleViewController {}


    public class SimpleController : Controller, ISimpleController,  IDisposable
    {
        public event Action<string> OnUpdate;

        public string SimpleText { get; private set; }

        public SimpleController(IGameService gameService) : base(gameService)
        {
            SimpleText = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
        }

        public void Tick()
        {
            SimpleText = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
            OnUpdate?.Invoke(SimpleText);
        }

        public void Initialize()
        {
            
        }

        public void Dispose()
        {
        }
    }
}