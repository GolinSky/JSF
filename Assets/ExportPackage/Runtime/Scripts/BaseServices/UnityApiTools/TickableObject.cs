using CodeFramework.Runtime.Observer;
using UnityEngine;

namespace CodeFramework
{
    public class TickableObject : ObserverSubject<float>
    {
        private void Update()
        {
            NotifyObservers(Time.deltaTime);
        }
    }
}