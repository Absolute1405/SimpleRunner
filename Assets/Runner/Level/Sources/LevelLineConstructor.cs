using System;
using System.Collections.Generic;
using System.Linq;
using FlexEngine.Essence;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runner.Level
{
    public class LevelLineConstructor
    {
        private readonly LevelLineChunkFactory[] _lineChunkFactories;
        private readonly LevelChunksLineFactory _chunksLineFactory;
        private readonly LevelChunkPriorityChance[] _sortedChances;
        private readonly LevelChunksLineSettings _settings;
        private readonly Transform _levelRoot;

        public LevelLineConstructor(LevelLineChunkFactory[] lineChunkFactories, LevelChunkPriorityChance[] sortedChances, 
            LevelChunksLineFactory chunksLineFactory, LevelChunksLineSettings settings, Transform levelRoot)
        {
            _lineChunkFactories = lineChunkFactories;
            _sortedChances = sortedChances;
            _chunksLineFactory = chunksLineFactory;
            _settings = settings;
            _levelRoot = levelRoot;
        }

        public LevelChunksLine CreateLine(LevelConnectionPoint startPoint, LevelChunk lastChunk, bool firstChunkIsDefault)
        {
            LevelChunksLine line = _chunksLineFactory.Create(startPoint, _levelRoot);
            
            var chunks = new List<LevelChunk>();
            int inlineChunksAmount = _settings.GetRandomInlineChunksAmount();
            LevelChunk[] lineChunks = CreateChunks(inlineChunksAmount, firstChunkIsDefault);

            chunks.AddRange(lineChunks);
            line.FillWithChunks(chunks, lastChunk);

            return line;
        }
        
        private LevelChunk[] CreateChunks(int amount, bool firstChunkIsDefault)
        {
            var result = new List<LevelChunk>();

            for (int i = 0; i < amount; i++)
            {
                if (i == 0 && firstChunkIsDefault)
                {
                    LevelChunk defaultChunk = GenerateChunkWithPriority(LevelChunkPriority.Default);
                    result.Add(defaultChunk);
                    continue;
                }

                LevelChunkPriority priority = ChoosePriority();
                LevelChunk chunk = GenerateChunkWithPriority(priority);
                result.Add(chunk);
            }

            return result.ToArray();
        }
        
        private LevelLineChunkFactory GetRandomChunkFactoryWithPriority(LevelChunkPriority priority)
        {
            LevelLineChunkFactory factoryWithPriority = _lineChunkFactories
                .Where(x => x.Priority == priority)
                .GetRandom();

            if (factoryWithPriority == null)
                throw new InvalidOperationException($"Cant find chunk factory with priority: {priority}");

            return factoryWithPriority;
        }

        private LevelChunk GenerateChunkWithPriority(LevelChunkPriority priority)
        {
            LevelLineChunkFactory factory = GetRandomChunkFactoryWithPriority(priority);
            return factory.GenerateChunk();
        }

        private LevelChunkPriority ChoosePriority()
        {
            float rand = Random.Range(0, 1f);

            foreach (var priorityChance in _sortedChances)
            {
                if (priorityChance.Chance >= rand)
                {
                    return priorityChance.Priority;
                }
            }
            
            Debug.LogError("Cant choose level priority");
            return LevelChunkPriority.Default;
        }

        public void ClearLines()
        {
            foreach (var factory in _lineChunkFactories)
            {
                factory.ReturnSpawnedInstancesToCache();
            }
            
            _chunksLineFactory.ReturnSpawnedInstancesToCache();
        }
    }
}

