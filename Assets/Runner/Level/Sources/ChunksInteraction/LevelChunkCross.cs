using Runner.Player;
using UnityEngine;

namespace Runner.Level
{
    [RequireComponent(typeof(Collider))]
    public class LevelChunkCross : MonoBehaviour
    {
        [SerializeField] private LevelLineChunkModel _chunkModel;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<IPlayerChunkCrossed>(out var player))
            {
                if (_chunkModel.ShowInStatistic)
                    player.OnChunkCrossed(_chunkModel.ID);
            }
        }
    }
}

