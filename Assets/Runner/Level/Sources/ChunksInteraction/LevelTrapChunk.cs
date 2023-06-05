using Runner.Player;
using UnityEngine;

namespace Runner.Level
{
    [RequireComponent(typeof(Collider))]
    public class LevelTrapChunk : MonoBehaviour
    {
        [SerializeField] private Transform _continuePoint;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<IPlayerTrapInteraction>(out var player))
            {
                player.OnTrapTriggered(_continuePoint.position);
            }
        }
    }
}

