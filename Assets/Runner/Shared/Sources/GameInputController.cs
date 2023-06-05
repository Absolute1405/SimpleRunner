using System;
using Runner.GameFlow;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runner.Shared
{
    public class GameInputController : MonoBehaviour, IGameOverListener, IRestartListener, IContinueListener, IVictoryListener
    {
        public event Action JumpInput;

        public void OnTap(InputAction.CallbackContext context)
        {
            if (!enabled)
                return;
            
            if (context.started)
                JumpInput?.Invoke();
        }

        public void OnGameOver()
        {
            enabled = false;
        }

        public void OnRestart()
        {
            enabled = true;
        }

        public void OnContinue()
        {
            enabled = true;
        }

        public void OnVictory()
        {
            enabled = false;
        }
    }
}

