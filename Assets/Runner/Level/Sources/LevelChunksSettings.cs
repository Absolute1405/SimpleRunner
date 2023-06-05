using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Runner.Level.Settings;
using UnityEngine;

namespace Runner.Level
{
    [Serializable]
    public class LevelChunksSettings
    {
        [SerializeField] private LevelChunkSpawnChances _generationSettings;
        
        [Header("Chunk variety")]
        [SerializeField] private LevelLineChunkModel[] _lineChunkModels;
        [SerializeField] private LevelBorderChunkModel[] _borderChunkModels;
        [SerializeField] private LevelEndChunkModel _endChunkModel;
        
        public LevelLineChunkModel[] LineChunkModels => _lineChunkModels;

        public LevelBorderChunkModel[] BorderChunkModels => _borderChunkModels;

        public LevelEndChunkModel EndChunkModel => _endChunkModel;

        public LevelChunkSpawnChances GenerationSettings => _generationSettings;

        public LevelLineChunkModel[] GetModelsForStatistic()
        {
            return _lineChunkModels.Where(x => x.ShowInStatistic).ToArray();
        }
    }
}

