using System;

namespace CodeFramework.Runtime.Controllers.Utils.TimeEntity.TimerEntity.Controller
{
    public interface ITimer: IListener
    {
        bool IsComplete { get; }
        float TimeLeft { get; }
        void UpdateTimer();
        void ChangeDelay(float newDelay);
        void AppendTime(float appendDelay);
        void Reset();
        
    }

    public interface IListener
    {
        // void AddListener(Action action);
        // void RemoveListener(Action action);
        
        event Action TimerHandler;
    }
}