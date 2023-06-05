using Runner.Player;
using UnityEngine;

namespace Runner.Level
{
    [RequireComponent(typeof(Collider))]
    public class LevelChunkPit : MonoBehaviour
    {
        [SerializeField] private Transform _continuePoint;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<IPlayerPitInteraction>(out var player))
            {
                player.OnPitReached(_continuePoint.position);
            }
        }
    }
}

