using UnityEngine;

namespace Runner.Level
{
    public struct LevelConnectionPoint
    {
        public Vector3 Position { get; }
        public Quaternion Rotation { get; }
        
        public LevelConnectionPoint(Transform transform)
        {
            Position = transform.position;
            Rotation = transform.rotation;
        }
        
        public LevelConnectionPoint(Vector3 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }
    }
}

