using System;
using UnityEngine;

namespace CodeFramework.Runtime.Controllers.Utils.TimeEntity.TimerEntity.Controller
{
    public class TimerController: ITimer
    {
        public event Action TimerHandler;

        private float delay;
        private float timer;

        public TimerController(float delay)
        {
            this.delay = delay;
        }

        private bool isComplete;

        public bool IsComplete
        {
            get
            {
                var newValue = timer < Time;

                if (isComplete != newValue)
                {
                    isComplete = newValue;
                    if (isComplete)
                    {
                        TimerHandler.Invoke();
                    }
                }
                return isComplete;
            }
        }

        private float Time => UnityEngine.Time.time;

        public float TimeLeft => IsComplete ? default : Mathf.Abs(Time - timer);
      
        public void UpdateTimer()
        {
            timer = UnityEngine.Time.time + delay;
        }

        public void ChangeDelay(float newDelay)
        {
            delay = newDelay;
        }

        public void Reset()
        {
            timer = default;
        }

        public void AppendTime(float appendDelay)
        {
            timer += appendDelay;
        }

    }
}