using FlexEngine.Essence.AppFlow;
using UnityEngine;

namespace Runner.Player
{
    public class PlayerJump : MonoBehaviour, IEnablable
    {
        [SerializeField] private Rigidbody _rigidbody;

        private float _jumpForce;

        public void Initialize(float jumpForce)
        {
            _jumpForce = jumpForce;
        }
        
        public void DoJump()
        {
            if (!enabled)
                return;
            
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        public void SetEnabled(bool value) => enabled = value;
    }
}

