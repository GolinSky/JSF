using System;

namespace FrameworkCore.MonoBehaviourEntity.Service
{
    public interface IUpdater
    {
        event Action OnUpdate;
    }
}
