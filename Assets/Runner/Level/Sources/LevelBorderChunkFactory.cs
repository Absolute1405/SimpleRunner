using Runner.Shared;

namespace Runner.Level
{
    public class LevelBorderChunkFactory : AddressableCachedFactory<LevelChunk>
    {
        public string ChunkId { get; private set; }
        private LevelChunkPriorityChance[] _sortedChances;

        public void SetChunkId(string id)
        {
            ChunkId = id;
        }

        public LevelChunk GenerateChunk()
        {
            LevelChunk chunk = GetCachedInstance(transform);
            return chunk;
        }
    }
}

