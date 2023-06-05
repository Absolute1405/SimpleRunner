using System;
using FlexEngine.Essence.AppFlow;
using UnityEngine;

namespace Runner.Player
{
    public class PlayerTrapInteraction : MonoBehaviour, IPlayerTrapInteraction, IEnablable, IPlayerPitInteraction
    {
        public event Action TrapTriggered;
        public event Action<Vector3> ContinuePositionSaved;
        public event Action PitReached;

        public void OnTrapTriggered(Vector3 continuePosition)
        {
            if (!enabled)
                return;
            
            TrapTriggered?.Invoke();
            ContinuePositionSaved?.Invoke(continuePosition);
        }

        public void OnPitReached(Vector3 continuePosition)
        {
            TrapTriggered?.Invoke();
            ContinuePositionSaved?.Invoke(continuePosition);
            PitReached?.Invoke();
        }

        public void SetEnabled(bool value)
        {
            enabled = value;
        }
    }

    public interface IPlayerTrapInteraction
    {
        void OnTrapTriggered(Vector3 continuePosition);
    }
    
    public interface IPlayerPitInteraction
    {
        void OnPitReached(Vector3 continuePosition);
    }
}

