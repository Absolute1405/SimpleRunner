using FlexEngine.Essence.AppFlow;
using UnityEngine;

namespace Runner.Player
{
    public class PlayerPosition : MonoBehaviour, IUpdatable
    {
        private Vector3 _startPosition;
        private IReadOnlySpeed _speed;
        private Vector3 _cachedContinuePosition;

        public void Initialize(Vector3 startPosition, IReadOnlySpeed speed)
        {
            _startPosition = startPosition;
            _speed = speed;
        }

        public void OnRestart()
        {
            transform.position = _startPosition;
        }

        public void OnContinue()
        {
            transform.position = _cachedContinuePosition;
        }

        public void CacheContinuePosition(Vector3 cachedPosition)
        {
            _cachedContinuePosition = cachedPosition;
        }
        
        public void DoUpdate()
        {
            if (!enabled)
                return;
            
            Vector3 movement = Vector3.forward * _speed.CurrentValue * Time.deltaTime;
            transform.Translate(movement);
        }

        public void SetEnabled(bool value) => enabled = value;
    }
}

