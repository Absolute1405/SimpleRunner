using UnityEngine;

namespace Runner.Level
{
    public static class TransformExtension
    {
        public static LevelConnectionPoint ConvertToConnectionPoint(this Transform transform)
        {
            return new LevelConnectionPoint(transform);
        }
    }
}

