using Runner.Shared;

namespace Runner.Level
{
    public class LevelEndChunkFactory : AddressableCachedFactory<LevelChunk>
    {
        public LevelChunk GenerateChunk()
        {
            return GetCachedInstance(transform);
        }
    }
}

