using CodeFramework.Runtime.Observer;
using UnityEngine;

namespace CodeFramework
{
    public class TickableCustomFactory
    {
        public static ObserverSubject<float> Construct()
        {
            GameObject gameObject = new GameObject();
            return gameObject.AddComponent<TickableObject>();
        }
    }
}