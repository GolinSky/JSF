using System;
using UnityEngine;

namespace FrameworkCore.MonoBehaviourEntity.Service
{
    public class MonoBehaviourUpdater : MonoBehaviour, IUpdater
    {
        public event Action OnUpdate;

        private void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}
