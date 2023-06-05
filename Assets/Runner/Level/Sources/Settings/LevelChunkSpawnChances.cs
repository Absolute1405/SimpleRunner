using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Runner.Level.Settings
{
    [CreateAssetMenu(menuName = "Runner/Level/ChunkSpawnChances", fileName = "LevelChunkSpawnChances")]
    public class LevelChunkSpawnChances : ScriptableObject
    {
        [SerializeField] private LevelChunkPriorityChance[] _chances;
        
        public LevelChunkPriorityChance[] GetSortedPriorityChances()
        {
            var sortedList = new SortedList<float, LevelChunkPriorityChance>();

            foreach (var priorityChance in _chances)
            {
                sortedList.Add(priorityChance.Chance, priorityChance);
            }

            return sortedList.Values.ToArray();
        }
    }
}

