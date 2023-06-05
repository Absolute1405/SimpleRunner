using System.Linq;
using Runner.Boosters;
using Runner.GameFlow;
using Runner.Level.Settings;
using UnityEngine;

namespace Runner.Level
{
    public class LevelConstructor : IRestartListener
    {
        private readonly Direction _startDirection;
        private readonly int _linesAmount;
        private readonly LevelBoosterConstructor _boosterConstructor;
        private readonly LevelLineConstructor _lineConstructor;
        private readonly LevelBordersConstructor _bordersConstructor;

        public LevelConstructor(LevelFactoriesContainer factoriesContainer, LevelSettings levelSettings, Direction startDirection, Transform levelRoot)
        {
            _startDirection = startDirection;
            _linesAmount = levelSettings.LinesAmount;

            _bordersConstructor = new LevelBordersConstructor(factoriesContainer.BorderChunkFactories, factoriesContainer.EndChunkFactory);
            _lineConstructor = new LevelLineConstructor(factoriesContainer.LineChunkFactories,
                levelSettings.LevelChunksSettings.GenerationSettings.GetSortedPriorityChances(),
                factoriesContainer.ChunksLineFactory, levelSettings.LevelChunksLineSettings, levelRoot);

            _boosterConstructor = new LevelBoosterConstructor(factoriesContainer.BoosterFactories, levelSettings.BoostersConfig);
        }

        private void CreateLevel()
        {
            LevelConnectionPoint connectionPoint = new LevelConnectionPoint(Vector3.zero,
                Quaternion.LookRotation(DirectionsMap.GetDirectionVector(_startDirection)));

            for (int i = 0; i < _linesAmount - 1; i++)
            {
                LevelChunk borderChunk = _bordersConstructor.GenerateBorderChunk();
                LevelChunksLine line = _lineConstructor.CreateLine(connectionPoint, borderChunk, i == 0);
                
                _boosterConstructor.FillWithBoosters(line.LineChunks.ToArray());
                connectionPoint = line.LineConnectionPoint;
            }
            
            LevelChunk endChunk = _bordersConstructor.GenerateEndChunk();
            LevelChunksLine lastLine = _lineConstructor.CreateLine(connectionPoint, endChunk, false);
        }


        
        public void OnRestart()
        {
            _lineConstructor.ClearLines();
            _bordersConstructor.Clear();
            _boosterConstructor.Clear();
            
            CreateLevel();
        }
    }
}

