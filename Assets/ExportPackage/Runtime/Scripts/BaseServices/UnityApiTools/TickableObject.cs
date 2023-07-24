using CodeFramework.Runtime.Controllers.Observer;
using UnityEngine;

namespace CodeFramework
{
    public sealed class TickableObject : ObserverSubject<float>
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            NotifyObservers(Time.deltaTime);
        }
    }
}