using System.Collections.Generic;
using Runner.GameFlow;
using Runner.Player;

namespace Runner.Shared
{
    public class GameStatistics : IReadOnlyPlayerStatistics, IRestartListener
    {
        private readonly Dictionary<string, int> _chunksCompletionMap = new Dictionary<string, int>();
        private readonly IPlayerStatisticsEnter _player;

        public GameStatistics(IPlayerStatisticsEnter player)
        {
            _player = player;
            _player.ChunkCrossed += PlayerOnChunkCrossed;
        }

        private void PlayerOnChunkCrossed(string id)
        {
            if (!_chunksCompletionMap.ContainsKey(id))
            {
                _chunksCompletionMap.Add(id, 1);
                return;
            }

            _chunksCompletionMap[id]++;
        }

        public int GetAmountOf(string id)
        {
            if (!_chunksCompletionMap.ContainsKey(id))
            {
                return 0;
            }

            return _chunksCompletionMap[id];
        }

        public void OnRestart()
        {
            _chunksCompletionMap.Clear();
        }
    }

    public interface IReadOnlyPlayerStatistics
    {
        int GetAmountOf(string id);
    }
}

