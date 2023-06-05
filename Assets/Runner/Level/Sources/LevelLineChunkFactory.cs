using Runner.Shared;

namespace Runner.Level
{
    public class LevelLineChunkFactory : AddressableCachedFactory<LevelChunk>
    {
        public LevelChunkPriority Priority { get; private set; }
        private bool _canSpawnBooster;

        public void Configure(LevelChunkPriority priority, bool canSpawnBooster)
        {
            Priority = priority;
            _canSpawnBooster = canSpawnBooster;
        }
        
        public LevelChunk GenerateChunk()
        {
            LevelChunk chunk = GetCachedInstance(transform);
            chunk.Initialize(_canSpawnBooster);
            return chunk;
        }
    }
}

