using System;
using UnityEngine;

namespace Runner.Level
{
    [Serializable]
    public class LevelChunkPriorityChance
    {
        [SerializeField] private LevelChunkPriority _priority;
        [SerializeField, Range(0, 1f)] private float _chance;

        public LevelChunkPriority Priority => _priority;

        public float Chance => _chance;
    }
}

