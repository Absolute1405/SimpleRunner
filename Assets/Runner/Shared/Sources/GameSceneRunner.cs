using System.Threading.Tasks;
using FlexEngine.Essence.ScenesManagement;
using Runner.GameFlow;
using Runner.Level;
using Runner.Level.Settings;
using Runner.Player;
using Runner.Stats;
using Runner.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Runner.Shared
{
    public class GameSceneRunner : SceneRunner<GameSceneArgs>
    {
        [SerializeField] private GameFactories _gameFactories;
        [SerializeField] private Transform _levelRoot;
        [SerializeField] private Transform _playerStartPoint;
        [SerializeField] private UIFacade _ui;
        [SerializeField] private GameUpdater _updater;
        [SerializeField] private GameInputController _inputController;
        [SerializeField] private CameraController _cameraController;

        private PlayerFacade _playerFacade;
        private LevelConstructor _levelConstructor;
        private GameEventsOperator _gameEventsOperator = new GameEventsOperator();
        private Speed _speed;
        private Health _health;
        private Invulnerable _invulnerable;
        private GameStatistics _statistics;
        
        public override async Task Load(GameSceneArgs args)
        {
            Addressables.InitializeAsync();

            LevelFactoriesContainer levelFactories = await _gameFactories.CreateLevelFactories(args.GameConfig.LevelSettings);
            _levelConstructor = new LevelConstructor(levelFactories, args.GameConfig.LevelSettings, args.GameConfig.StartDirection, _levelRoot);
            
            PlayerFactory playerFactory = await _gameFactories.InitPlayerFactory(args.GameConfig.PlayerConfig.PlayerTemplate);
            _playerFacade = playerFactory.Create(args.GameConfig.PlayerConfig.PlayerTemplate);
            
            Initialize(args.GameConfig);
        }

        private void Initialize(GameConfig gameConfig)
        {
            InitializeStats(gameConfig.StatsConfig);
            InitializePlayer(gameConfig.PlayerConfig, gameConfig.StartDirection);
            
            _statistics = new GameStatistics(_playerFacade.StatisticEnter);
            InitializeUI(gameConfig.LevelSettings);
            SetupGameEvents();
        }

        private void InitializeStats(StatsConfig config)
        {
            _speed = new Speed(config.BasicSpeed, config.BoostedSpeed, config.SpeedBoostDuration, config.ContinueSpeed, config.SpeedContinueSlowDuration);
            _updater.AddUpdateListener(_speed.BoostTimer);
            _updater.AddUpdateListener(_speed.SlowTimer);

            _health = new Health(config.BaseHealth, config.ContinueHealth, config.BoosterHealthRegen);
            _invulnerable = new Invulnerable(config.InvulnerableDuration, _playerFacade, _playerFacade.PlayerInteraction);
            _updater.AddUpdateListener(_invulnerable.Timer);
        }

        private void InitializePlayer(PlayerConfig config, Direction startDirection)
        {
            _playerFacade.Initialize(config, _playerStartPoint.position, _speed, startDirection);
            _playerFacade.PlayerInteraction.HealthBoosterTriggered += _health.IncreaseByBooster;
            _playerFacade.TrapInteraction.TrapTriggered += _health.DecreaseByTrap;
            _playerFacade.PlayerInteraction.SpeedBoosterTriggered += _speed.BoostSpeed;
            _inputController.JumpInput += _playerFacade.OnJumpTriggered;
            _cameraController.SetFollowTarget(_playerFacade.CameraFollowTarget);
            _updater.AddUpdateListener(_playerFacade);
            _updater.AddFixedUpdateListener(_playerFacade);
        }

        private void InitializeUI(LevelSettings levelSettings)
        {
            _ui.Initialize(levelSettings.LevelChunksSettings.GetModelsForStatistic(), _health, _statistics);
            _ui.LevelCompleted += OnLevelCompleted;
        }

        public override void Run(GameSceneArgs args)
        {
            _gameEventsOperator.StartGame();
        }

        private void SetupGameEvents()
        {
            _gameEventsOperator.FillRestartListenersInOrder(_levelConstructor, _speed, _health, _playerFacade, _invulnerable, _ui, _inputController, _statistics);
            _gameEventsOperator.FillGameOverListenersInOrder(_inputController, _playerFacade, _invulnerable, _ui);
            _gameEventsOperator.FillContinueListenersInOrder(_health, _inputController, _playerFacade, _invulnerable, _ui);
            _gameEventsOperator.FillVictoryListenersInOrder(_inputController, _playerFacade, _ui);
            _gameEventsOperator.FillRestartInvokersInOrder(_ui);
            _gameEventsOperator.FillContinueInvokersInOrder(_ui);
            _gameEventsOperator.FillGameOverInvokersInOrder(_health);
            _gameEventsOperator.FillVictoryInvokersInOrder(_playerFacade.PlayerInteraction);
        }

        private void OnDestroy()
        {
            ClearLevel();
        }

        private void ClearLevel()
        {
            _updater.RemoveAllUpdateListeners();
            _updater.RemoveAllFixedUpdateListeners();
            _gameEventsOperator.Clear();
            
            _playerFacade.PlayerInteraction.HealthBoosterTriggered -= _health.IncreaseByBooster;
            _playerFacade.TrapInteraction.TrapTriggered -= _health.DecreaseByTrap;
            _playerFacade.PlayerInteraction.SpeedBoosterTriggered -= _speed.BoostSpeed;
            _inputController.JumpInput -= _playerFacade.OnJumpTriggered;
            _ui.LevelCompleted -= OnLevelCompleted;
        }
        
        private void OnLevelCompleted()
        {
            _gameEventsOperator.StartGame();
        }
    }
}

