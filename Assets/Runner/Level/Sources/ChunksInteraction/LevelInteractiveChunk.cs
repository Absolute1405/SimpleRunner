using Runner.Player;
using UnityEngine;

namespace Runner.Level.ChunksInteraction
{
    [RequireComponent(typeof(Collider))]
    public abstract class LevelInteractiveChunk : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<IPlayerInteraction>(out var player))
            {
                OnPlayerTriggered(player);
            }
        }

        protected abstract void OnPlayerTriggered(IPlayerInteraction player);
    }
}

