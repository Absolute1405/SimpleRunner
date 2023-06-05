using Runner.Shared;
using UnityEngine;

namespace Runner.Level
{
    public class LevelChunksLineFactory : AddressableCachedFactory<LevelChunksLine>
    {
        public LevelChunksLine Create(LevelConnectionPoint startPoint, Transform levelRoot)
        {
            LevelChunksLine result = GetCachedInstance(levelRoot);
            result.SetStartPoint(startPoint);
            return result;
        }
    }
}

