using System;
using FlexEngine.Essence.AppFlow;
using UnityEngine;

namespace Runner.Shared
{
    public class Timer : IUpdatable
    {
        public bool enabled { get; private set; }
        public event Action TimeIsOver;

        public float Value { get; private set; } = 0;
        
        public void SetEnabled(bool value)
        {
            enabled = value;
        }

        public void DoUpdate()
        {
            if(!enabled)
                return;
            
            Value -= Time.deltaTime;

            if (Value <= 0)
            {
                SetEnabled(false);
                TimeIsOver?.Invoke();
            }
        }

        public void AddTime(float seconds)
        {
            Value += seconds;
            SetEnabled(true);
        }

        public void StopTimer()
        {
            SetEnabled(false);
        }
    }
}

