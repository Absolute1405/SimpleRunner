using Runner.Player;
using UnityEngine;

namespace Runner.Level.ChunksInteraction
{
    public class LevelTurnChunk : LevelInteractiveChunk
    {
        [SerializeField] private Direction _turnDirection;
        
        protected override void OnPlayerTriggered(IPlayerInteraction player)
        {
            player.OnTurnChunkTriggered(_turnDirection);
        }
    }
}

