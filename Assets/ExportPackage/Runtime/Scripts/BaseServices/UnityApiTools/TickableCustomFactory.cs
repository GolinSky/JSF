using CodeFramework.Runtime.Controllers.Observer;
using GofPatterns.Patterns.Behavioral.Observer.Custom;
using UnityEngine;

namespace CodeFramework
{
    public class TickableCustomFactory:IFactory<ICustomSubject<float>>
    {
        public ICustomSubject<float> Construct()
        {
            GameObject gameObject = new GameObject();
            return gameObject.AddComponent<TickableObject>();
        }
    }
}