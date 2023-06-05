using Runner.Level.ChunksInteraction;
using Runner.Player;

namespace Runner.Level
{
    public class LevelVictoryChunk : LevelInteractiveChunk
    {
        protected override void OnPlayerTriggered(IPlayerInteraction player)
        {
            player.OnVictoryReached();
        }
    }
}

