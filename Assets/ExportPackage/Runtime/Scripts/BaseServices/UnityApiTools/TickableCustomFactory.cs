using CodeFramework.Runtime.Observer;
using UnityEngine;

namespace CodeFramework
{
    public class TickableCustomFactory:IFactory<ObserverSubject<float>>
    {
        public ObserverSubject<float> Construct()
        {
            GameObject gameObject = new GameObject();
            return gameObject.AddComponent<TickableObject>();
        }
    }
}