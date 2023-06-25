using CodeFramework.Runtime.Observer;
using UnityEngine;

namespace CodeFramework
{
    public class TickableObject : ObserverSubject<float>
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            NotifyObservers(Time.deltaTime);
        }
    }
}