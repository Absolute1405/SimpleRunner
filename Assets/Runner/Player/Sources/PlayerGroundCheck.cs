using System;
using UnityEngine;

namespace Runner.Player
{
    [RequireComponent(typeof(Collider))]
    public class PlayerGroundCheck : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private LayerMask _groundLayerMask;

        public event Action OnGround;
        public bool Grounded { get; private set; }
        
        private float _maxGroundDistance;
        private const float maxGroundDistanceOffset = 0.1f;
        
        
        public void Initialize()
        {
            _maxGroundDistance = _collider.bounds.extents.y;
        }
        
        public void DoFixedUpdate()
        {
            Grounded = Physics.Raycast(transform.position, -Vector3.up, _maxGroundDistance + maxGroundDistanceOffset, _groundLayerMask);
            
            if (Grounded)
            {
                if (_rigidbody.velocity.y < 0)
                    OnGround?.Invoke();
            }
        }
    }
}

