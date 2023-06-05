using System.Collections.Generic;
using System.Threading.Tasks;
using Runner.Boosters;
using Runner.Level.Settings;
using Runner.Player;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Runner.Level
{
    public class GameFactories : MonoBehaviour
    {
        [SerializeField] private LevelLineChunkFactory _lineChunkFactoryTemplate;
        [SerializeField] private LevelBorderChunkFactory _borderChunkFactoryTemplate;
        [SerializeField] private BoosterFactory _boosterFactoryTemplate;

        [SerializeField] private LevelEndChunkFactory _endChunkFactory;
        [SerializeField] private LevelChunksLineFactory _chunksLineFactory;
        [SerializeField] private PlayerFactory _playerFactory;

        private LevelLineChunkFactory[] _lineChunkFactories;
        private LevelBorderChunkFactory[] _borderChunkFactories;
        private BoosterFactory[] _boosterFactories;
        
        public async Task<LevelFactoriesContainer> CreateLevelFactories(LevelSettings settings)
        {
            int maxBorderChunksOnScene = settings.LinesAmount * (settings.LevelChunksLineSettings.InlineChunksMaxAmount - 1);
            int maxLineChunksOnScene = settings.LevelChunksLineSettings.InlineChunksMaxAmount * settings.LinesAmount - 1;
            int boosterPlacesCount = maxLineChunksOnScene;

            _lineChunkFactories = await CreateLineChunkFactories(settings.LevelChunksSettings.LineChunkModels, maxLineChunksOnScene);
            _borderChunkFactories = await CreateBorderChunkFactories(settings.LevelChunksSettings.BorderChunkModels, maxBorderChunksOnScene);
            _boosterFactories = await CreateBoosterFactories(settings.BoostersConfig.BoosterModels, boosterPlacesCount);
            
            await InitEndChunkFactory(settings.LevelChunksSettings.EndChunkModel, settings.LinesAmount);
            await InitChunksLineFactory(settings.LevelChunksLineSettings.Template, settings.LinesAmount);

            return new LevelFactoriesContainer(_lineChunkFactories, _borderChunkFactories, _endChunkFactory,
                _chunksLineFactory, _boosterFactories);
        }

        private async Task<LevelLineChunkFactory[]> CreateLineChunkFactories(LevelLineChunkModel[] models,
            int maxChunksOnScene)
        {
            List<LevelLineChunkFactory> result = new List<LevelLineChunkFactory>();
            
            foreach (var model in models)
            {
                LevelLineChunkFactory lineChunkFactory = await CreateLineChunkFactory(model, maxChunksOnScene);
                result.Add(lineChunkFactory);
            }

            return result.ToArray();
        }
        
        private async Task<LevelBorderChunkFactory[]> CreateBorderChunkFactories(LevelBorderChunkModel[] models,
            int maxChunksOnScene)
        {
            List<LevelBorderChunkFactory> result = new List<LevelBorderChunkFactory>();
            
            foreach (var model in models)
            {
                LevelBorderChunkFactory borderChunkFactory = await CreateBorderChunkFactory(model, maxChunksOnScene);
                result.Add(borderChunkFactory);
            }

            return result.ToArray();
        }

        private async Task<LevelLineChunkFactory> CreateLineChunkFactory(LevelLineChunkModel model, int maxChunksOnScene)
        {
            LevelLineChunkFactory result = Instantiate(_lineChunkFactoryTemplate, transform);
            result.Configure(model.Priority, model.CanSpawnBooster);
            await result.CreateCache(maxChunksOnScene, model.AddressableTemplate);
            return result;
        }
        
        private async Task<LevelBorderChunkFactory> CreateBorderChunkFactory(LevelBorderChunkModel model, int maxChunksOnScene)
        {
            LevelBorderChunkFactory result = Instantiate(_borderChunkFactoryTemplate, transform);
            result.SetChunkId(model.ID);
            await result.CreateCache(maxChunksOnScene, model.AddressableTemplate);
            return result;
        }
        
        private async Task InitEndChunkFactory(LevelEndChunkModel model, int maxLines)
        {
            await _endChunkFactory.CreateCache(maxLines, model.AddressableTemplate);
        }
        
        private async Task InitChunksLineFactory(AssetReference chunksLineTemplate, int maxLinesOnScene)
        {
            await _chunksLineFactory.CreateCache(maxLinesOnScene, chunksLineTemplate);
        }
        
        private async Task<BoosterFactory[]> CreateBoosterFactories(BoosterModel[] models,
            int maxBoosterPlacesOnScene)
        {
            List<BoosterFactory> result = new List<BoosterFactory>();
            
            foreach (var model in models)
            {
                BoosterFactory boosterFactory = await CreateBoosterFactory(model, maxBoosterPlacesOnScene);
                boosterFactory.Configure(model.Chance);
                result.Add(boosterFactory);
            }

            return result.ToArray();
        }
        
        public async Task<BoosterFactory> CreateBoosterFactory(BoosterModel model, int maxBoostersPlacesOnScene)
        {
            BoosterFactory result = Instantiate(_boosterFactoryTemplate, transform);
            await result.CreateCache(maxBoostersPlacesOnScene, model.AddressableTemplate);
            return result;
        }
        
        public async Task<PlayerFactory> InitPlayerFactory(AssetReference playerTemplate)
        {
            await _playerFactory.CreateCache(1, playerTemplate);
            return _playerFactory;
        }
    }

    public struct LevelFactoriesContainer
    {
        public LevelLineChunkFactory[] LineChunkFactories { get; }
        public LevelBorderChunkFactory[] BorderChunkFactories { get; }
        public LevelEndChunkFactory EndChunkFactory { get; }
        public LevelChunksLineFactory ChunksLineFactory { get; }
        public BoosterFactory[] BoosterFactories { get; }

        public LevelFactoriesContainer(LevelLineChunkFactory[] lineChunkFactories, LevelBorderChunkFactory[] borderChunkFactories, 
            LevelEndChunkFactory endChunkFactory, LevelChunksLineFactory chunksLineFactory, BoosterFactory[] boosterFactories)
        {
            LineChunkFactories = lineChunkFactories;
            BorderChunkFactories = borderChunkFactories;
            EndChunkFactory = endChunkFactory;
            ChunksLineFactory = chunksLineFactory;
            BoosterFactories = boosterFactories;
        }
    }
}

