using System;
using FlexEngine.Essence.AppFlow;
using Runner.GameFlow;
using Runner.Level;
using UnityEngine;

namespace Runner.Player
{
    public class PlayerInteraction : MonoBehaviour, IPlayerInteraction, IEnablable, IVictoryInvoker, IPlayerInvulnerableTrigger
    {
        public event Action<Direction> TurnTriggered;
        public event Action SpeedBoosterTriggered;
        public event Action InvulBoosterTriggered;
        public event Action HealthBoosterTriggered;
        public event Action Victory;

        public void OnTurnChunkTriggered(Direction newDirection)
        {
            if (!enabled)
                return;
            
            TurnTriggered?.Invoke(newDirection);
        }

        public void OnHealthBoosterTriggered()
        {
            if (!enabled)
                return;
            HealthBoosterTriggered?.Invoke();
        }

        public void OnSpeedBoosterTriggered()
        {
            if (!enabled)
                return;
            SpeedBoosterTriggered?.Invoke();
        }
        
        public void OnInvulnerableBoosterTriggered()
        {
            if (!enabled)
                return;
            InvulBoosterTriggered?.Invoke();
        }

        public void OnVictoryReached()
        {
            if (!enabled)
                return;
            Victory?.Invoke();
        }

        public void SetEnabled(bool value) => enabled = value;
    }

    public interface IPlayerInteraction
    {
        void OnTurnChunkTriggered(Direction newDirection);

        void OnHealthBoosterTriggered();
        void OnInvulnerableBoosterTriggered();

        void OnSpeedBoosterTriggered();
        void OnVictoryReached();
    }

    public interface IPlayerInvulnerableTrigger
    {
        event Action InvulBoosterTriggered;
    }
}

