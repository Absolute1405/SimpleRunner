using System.Linq;
using FlexEngine.Essence;

namespace Runner.Level
{
    public class LevelBordersConstructor
    {
        private readonly LevelBorderChunkFactory[] _borderChunkFactories;
        private readonly LevelEndChunkFactory _endChunkFactory;
        private string _lastSpawnedBorderId = string.Empty;

        public LevelBordersConstructor(LevelBorderChunkFactory[] borderChunkFactories, LevelEndChunkFactory endChunkFactory)
        {
            _borderChunkFactories = borderChunkFactories;
            _endChunkFactory = endChunkFactory;
        }

        public LevelChunk GenerateEndChunk()
        {
            return _endChunkFactory.GenerateChunk();
        }

        public LevelChunk GenerateBorderChunk()
        {
            LevelBorderChunkFactory borderChunkFactory = ChooseBorderChunkFactory();
            return borderChunkFactory.GenerateChunk();
        }
        
        
        private LevelBorderChunkFactory ChooseBorderChunkFactory()
        {
            LevelBorderChunkFactory result = _borderChunkFactories
                .Where(x => x.ChunkId != _lastSpawnedBorderId)
                .GetRandom();

            _lastSpawnedBorderId = result.ChunkId;
            return result;
        }

        public void Clear()
        {
            foreach (var factory in _borderChunkFactories)
            {
                factory.ReturnSpawnedInstancesToCache();
            }
            
            _endChunkFactory.ReturnSpawnedInstancesToCache();
        }
    }
}

