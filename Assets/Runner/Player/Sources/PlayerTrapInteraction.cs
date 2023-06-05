using System;
using FlexEngine.Essence.AppFlow;
using UnityEngine;

namespace Runner.Player
{
    public class PlayerTrapInteraction : MonoBehaviour, IPlayerTrapInteraction, IEnablable
    {
        public event Action TrapTriggered;
        public event Action<Vector3> ContinuePositionSaved;

        public void OnTrapTriggered(Vector3 continuePosition)
        {
            if (!enabled)
                return;
            TrapTriggered?.Invoke();
            ContinuePositionSaved?.Invoke(continuePosition);
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
}

